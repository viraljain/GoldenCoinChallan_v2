using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoldenCoinChallan
{
    public partial class Form1
    {
        private void btnModifyChallan_Click(object sender, EventArgs e)
        {
            mode = enumNewChallanMode.ModifyRender;
            fetchChallan(sender, e);
            mode = enumNewChallanMode.Modify;
        }

        private void buttonSplitChallan_Click(object sender, EventArgs e)
        {
            if (textBoxChallan.Text.Trim().ToUpper().StartsWith("PI"))
            {
                MessageBox.Show("Error - Packing Split cannot be splitted.");
                return;
            }

            dgvNewChallan.ReadOnly = true;
            mode = enumNewChallanMode.Split;
            fetchChallan(sender, e);
        }
        public void fetchChallan(object sender, EventArgs e)
        {
            try
            {
                string challanNo = textBoxChallan.Text.Trim();
                if (string.IsNullOrEmpty(challanNo)) return;

                using (var conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GoldenCoinChallan.Properties.Settings.AA_2023_2024ConnectionString"].ConnectionString))
                using (var cmdGetChallan = new SqlCommand("sp_GetChallanData", conn))
                {
                    cmdGetChallan.CommandType = CommandType.StoredProcedure;
                    cmdGetChallan.Parameters.AddWithValue("@ChallanNo", challanNo);
                    cmdGetChallan.Parameters.AddWithValue("@Mode", "PDF");

                    var dtGetChallan = new DataTable();
                    conn.Open();

                    using (var reader = cmdGetChallan.ExecuteReader())
                    {
                        dtGetChallan.Load(reader);
                    }

                    if (dtGetChallan.Rows.Count > 0)
                    {
                        //newChallan_Load();
                        dgvNewChallan.Rows.Clear();
                        challanTotal = 0;
                        labelTotal.Text = "Total 0";
                        textBoxNewChallanRemark.Text = "";
                        labelDealerName.Text = "";
                        textBoxPackingSlip.Text = "";

                        var row = dtGetChallan.Rows[0];
                        labelNewChallanNumber.Text = row.Field<string>("BillNo");
                        dateNewChallan.Value = row.Field<DateTime>("Date");
                        labelTotal.Text = "Total " + row.Field<Double>("TotQty").ToString();

                        tabControl1.SelectedTab = tabPageNewChallan; // switch to edit tab

                        if (challanNo.ToUpper().StartsWith("PI"))
                        {
                            radioButtonPackingSlipTransfer.Checked = true;
                            radioButtonPackingSlipTransfer_CheckedChanged(sender, EventArgs.Empty);
                            //comboBoxDealerName.SelectedIndex = comboBoxDealerName.FindString(row.Field<string>("NAME"));
                            textBoxPackingSlip.Text = row.Field<string>("Remark");
                            buttonNewChallanInsert.Text = "&Update Packing Slip";
                        }
                        else
                        {
                            radioButtonNewChallan.Checked = true;
                            radioButtonNewChallan_CheckedChanged(sender, EventArgs.Empty);
                            comboBoxDealerName.SelectedIndex = comboBoxDealerName.FindString(row.Field<string>("NAME"));
                            textBoxNewChallanRemark.Text = row.Field<string>("Remark");
                            buttonNewChallanInsert.Text = "&Update Challan";
                        }

                        /**************** DETAILS DISPLAY LOGIC ****************/
                        var rows = dtGetChallan.AsEnumerable();

                        var challanItemGroup = rows
                            .Where(r => !string.IsNullOrWhiteSpace(r.Field<string>("ItemName")))
                            .GroupBy(r => new
                            {
                                ItemName = r.Field<string>("ItemName").Trim(),
                                Unit = dtGetChallan.Columns.Contains("FieldValue1") ? (r["FieldValue1"]?.ToString() ?? "") : ""
                            });


                        var itemNameColumn = dgvNewChallan.Columns["ItemName"] as DataGridViewComboBoxColumn;
                        foreach (var challanItem in challanItemGroup)
                        {
                            string itemName = challanItem.Key.ItemName.Replace("D.", "Divya").Replace("M.", "Maestro").Replace("Cmndr", "Commander");
                            string unit = challanItem.Key.Unit;

                            // add single row per distinct item+unit
                            int newIndex = dgvNewChallan.Rows.Add();
                            var targetRow = dgvNewChallan.Rows[newIndex];

                            // set item name + unit once using your existing helper
                            var nameCell = targetRow.Cells["ItemName"];
                            //setComboCellByDisplayOrValue(nameCell, itemName, unit);
                            //var dsSource = itemNameColumn.DataSource as DataTable;
                            var dsSource1 = itemNameColumn.DataSource as BindingSource;
                            var dsSource = dsSource1.DataSource as DataTable; // try both if not sure which one is set
                            if (dsSource != null)
                            {
                                var displayMember = itemNameColumn.DisplayMember;
                                var valueMember = itemNameColumn.ValueMember;
                                var found = dsSource.AsEnumerable()
                                                    .FirstOrDefault(r => string.Equals(r.Field<string>(displayMember), itemName, StringComparison.OrdinalIgnoreCase));
                                if (found != null)
                                {
                                    // if ValueMember contains unit concatenated, use that; otherwise just set the value
                                    nameCell.Value = found[valueMember];
                                    //comboboxItemName_TextChanged(nameCell, EventArgs.Empty); // trigger size column population if needed
                                    dgvNewChallan.CurrentCell = nameCell;
                                    dgvNewChallan.BeginEdit(true);

                                    if (dgvNewChallan.EditingControl is ComboBox cb)
                                    {
                                        //cb.Text = "SomeValue"; // set programmatically
                                        comboboxItemName_TextChanged(cb, EventArgs.Empty); // manually trigger
                                    }

                                }
                            }
                            int challanItemSum = 0;
                            // populate size columns from group's rows
                            foreach (var dr in challanItem)
                            {
                                string itemSize = dr.Table.Columns.Contains("ItemSize") ? (dr["ItemSize"]?.ToString().Split('/')[0] ?? "") : "";
                                // adjust if quantity is in a different column (ItemDesc / Qty)
                                int qty = 0;
                                //int.TryParse(dr.Table.Columns.Contains("ItemDesc") ? dr["ItemDesc"]?.ToString() : dr["Qty"]?.ToString(), out qty);
                                int.TryParse(dr["Qty"]?.ToString(), out qty);

                                if (string.IsNullOrWhiteSpace(itemSize)) continue;

                                var sizeCol = dgvNewChallan.Columns.Cast<DataGridViewColumn>()
                                                .FirstOrDefault(c => c.Name.Contains("_" + itemSize) ||
                                                                     string.Equals(c.HeaderText, itemSize, StringComparison.OrdinalIgnoreCase));
                                if (sizeCol != null)
                                {
                                    // if multiple rows in same group map to same size, sum them (optional)
                                    var curVal = targetRow.Cells[sizeCol.Index].Value;
                                    int curQty = 0;
                                    int.TryParse(curVal?.ToString() ?? "0", out curQty);
                                    targetRow.Cells[sizeCol.Index].Value = (curQty + qty).ToString();
                                    challanItemSum += qty;
                                    challanTotal += qty;
                                }
                                else
                                {
                                    // size column not found - skip or handle (e.g., add column)
                                }
                            }
                            targetRow.Cells["rowTotal"].Value = challanItemSum.ToString();
                        }

                    }
                    else
                    {
                        MessageBox.Show("Challan/Packing Slip not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    if (challanNo.ToUpper().StartsWith("PI"))
                    {
                        textBoxPackingSlip.Focus();
                    }
                    else
                        textBoxNewChallanRemark.Focus();
                    // Bind details to DataGridView (allow edits/add/remove)
                    //dgvNewChallan.DataSource = detailDt;                    
                    //dgvNewChallan.Columns["Id"].Visible = false; // hide PK if not needed
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching challan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonChallanSplit_Click(object sender, EventArgs e)
        {
            try
            {
                if (!dgvNewChallan.ReadOnly)
                { MessageBox.Show("Error - Use Split Challan Button to Split Challan. Challan cannot be splitted in Insert/Modify mode."); return; }
                if (dgvNewChallan.Rows.Count <= 2 || (dgvNewChallan.SelectedRows.Count == dgvNewChallan.Rows.Count - 1))
                { MessageBox.Show("Error - Challan should have minimum 2 main rows to split Challan. Also, atleast 1 row should be left in the current challan."); return; }
                if (dgvNewChallan.SelectedRows.Count < 1 || dgvNewChallan.CurrentRow.IsNewRow)
                { MessageBox.Show("Error - Select atleast 1 main Row to split Challan"); return; }

                DataTable dtNewChallan = new DataTable();
                dtNewChallan.Columns.Add("ItemName", typeof(string));
                dtNewChallan.Columns.Add("ItemSize", typeof(string));
                dtNewChallan.Columns.Add("ItemQty", typeof(Int16));
                dtNewChallan.Columns.Add("ItemUnit", typeof(string));

                DataTable dtModifyChallan = dtNewChallan.Clone();

                string itemName = string.Empty, itemUnit = String.Empty, itemSize = String.Empty;
                int itemQty = 0, totalNewChallan = 0, totalModifyChallan = 0;

                foreach (DataGridViewRow row in dgvNewChallan.Rows)
                {
                    if (row.Selected && !row.IsNewRow)
                    {
                        DataGridViewComboBoxCell cmbItemName = row.Cells["ItemName"] as DataGridViewComboBoxCell;
                        itemUnit = cmbItemName.Value.ToString().Split(new String[] { "|||" }, StringSplitOptions.RemoveEmptyEntries)[1];
                        itemName = cmbItemName.FormattedValue.ToString();
                        foreach (DataGridViewCell cell in row.Cells.Cast<DataGridViewCell>().ToList().Where(cell => cell.Value != null && cell.OwningColumn.Name.Contains("Size")))
                        {
                            if (cell.Value.ToString().Length > 0)
                            {
                                itemSize = cell.OwningColumn.Name.Split('_')[1];
                                int.TryParse(cell.Value.ToString(), out itemQty);

                                if (itemQty > 0)
                                {
                                    dtNewChallan.Rows.Add(itemName, itemSize, itemQty, itemUnit);
                                    totalNewChallan += itemQty;
                                }
                            }
                        }
                    }
                    else if (!row.IsNewRow)
                    {
                        DataGridViewComboBoxCell cmbItemName = row.Cells["ItemName"] as DataGridViewComboBoxCell;
                        itemUnit = cmbItemName.Value.ToString().Split(new String[] { "|||" }, StringSplitOptions.RemoveEmptyEntries)[1];
                        itemName = cmbItemName.FormattedValue.ToString();
                        foreach (DataGridViewCell cell in row.Cells.Cast<DataGridViewCell>().ToList().Where(cell => cell.Value != null && cell.OwningColumn.Name.Contains("Size")))
                        {
                            if (cell.Value.ToString().Length > 0)
                            {
                                itemSize = cell.OwningColumn.Name.Split('_')[1];
                                int.TryParse(cell.Value.ToString(), out itemQty);

                                if (itemQty > 0)
                                {
                                    dtModifyChallan.Rows.Add(itemName, itemSize, itemQty, itemUnit);
                                    totalModifyChallan += itemQty;
                                }
                            }
                        }
                    }
                }
                MessageBox.Show("Success - Challan can be splitted.");

                using (SqlConnection sqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GoldenCoinChallan.Properties.Settings.AA_2023_2024ConnectionString"].ConnectionString))
                {
                    /***********************************************************/
                    /************ INSERT SECTION (Splitted Selected Rows) ******/
                    /***********************************************************/
                    ///Inserting Header Information into TEMP Challan Header Table
                    string sqlQueryChallanHeader = "INSERT INTO tblNewChallanTemp_Header(DealerName, DealerCode, Remarks, TotalItemQty) " +
                        "VALUES (@DealerName, @DealerCode, @Remarks, @TotalItemQty)";
                    using (SqlCommand sqlCmdChallanHeader = new SqlCommand(sqlQueryChallanHeader, sqlConnection))
                    {
                        //New Challan Creation
                        if (radioButtonNewChallan.Checked)
                        {
                            sqlCmdChallanHeader.Parameters.AddWithValue("@DealerName", comboBoxDealerName.Text.ToString());
                            sqlCmdChallanHeader.Parameters.AddWithValue("@DealerCode", comboBoxDealerName.SelectedValue.ToString());
                            sqlCmdChallanHeader.Parameters.AddWithValue("@Remarks", "");
                            sqlCmdChallanHeader.Parameters.AddWithValue("@TotalItemQty", totalNewChallan);
                        }
                        sqlConnection.Open();
                        sqlCmdChallanHeader.ExecuteNonQuery();
                    }

                    ///Inserting Productwise Sizewise Qty Information into TEMP Challan Details Table
                    using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(sqlConnection))
                    {
                        //sqlConnection.Open();
                        sqlBulkCopy.ColumnMappings.Add("ItemName", "ItemName");
                        sqlBulkCopy.ColumnMappings.Add("ItemSize", "ItemSize");
                        sqlBulkCopy.ColumnMappings.Add("ItemQty", "ItemQty");
                        sqlBulkCopy.ColumnMappings.Add("ItemUnit", "ItemUnit");

                        sqlBulkCopy.DestinationTableName = "tblNewChallanTemp";
                        sqlBulkCopy.WriteToServer(dtNewChallan);
                    }

                    /*******    NEW CHALLAN    ******/
                    using (SqlCommand sqlCmdSPNewChallan = new SqlCommand("sp_NewChallan", sqlConnection))
                    {
                        sqlCmdSPNewChallan.CommandType = CommandType.StoredProcedure;
                        sqlCmdSPNewChallan.Parameters.Add("@Date", SqlDbType.DateTime).Value = DateTime.Now;

                        using (SqlDataReader reader = sqlCmdSPNewChallan.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (radioButtonNewChallan.Checked)
                                {
                                    MessageBox.Show("Challan " + labelNewChallanNumber.Text + " splitted successfully! New Challan No. is " + reader.GetString(0));
                                    //comboBoxDealerName.Focus();
                                }
                            }
                        }
                    }

                    /***********************************************************/
                    /********** MODIFY SECTION (Splitted UNSELECTED Rows) ******/
                    /***********************************************************/
                    ///Inserting Header Information into TEMP Challan Header Table
                    sqlQueryChallanHeader = "INSERT INTO tblNewChallanTemp_Header(DealerName, DealerCode, Remarks, TotalItemQty) " +
                        "VALUES (@DealerName, @DealerCode, @Remarks, @TotalItemQty)";
                    using (SqlCommand sqlCmdChallanHeader = new SqlCommand(sqlQueryChallanHeader, sqlConnection))
                    {
                        //New Challan Creation
                        if (radioButtonNewChallan.Checked)
                        {
                            sqlCmdChallanHeader.Parameters.AddWithValue("@DealerName", comboBoxDealerName.Text.ToString());
                            sqlCmdChallanHeader.Parameters.AddWithValue("@DealerCode", comboBoxDealerName.SelectedValue.ToString());
                            sqlCmdChallanHeader.Parameters.AddWithValue("@Remarks", textBoxNewChallanRemark.Text);
                            sqlCmdChallanHeader.Parameters.AddWithValue("@TotalItemQty", totalModifyChallan);
                        }
                        sqlCmdChallanHeader.ExecuteNonQuery();
                    }

                    ///Inserting Productwise Sizewise Qty Information into TEMP Challan Details Table
                    using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(sqlConnection))
                    {
                        //sqlConnection.Open();
                        sqlBulkCopy.ColumnMappings.Add("ItemName", "ItemName");
                        sqlBulkCopy.ColumnMappings.Add("ItemSize", "ItemSize");
                        sqlBulkCopy.ColumnMappings.Add("ItemQty", "ItemQty");
                        sqlBulkCopy.ColumnMappings.Add("ItemUnit", "ItemUnit");

                        sqlBulkCopy.DestinationTableName = "tblNewChallanTemp";
                        sqlBulkCopy.WriteToServer(dtModifyChallan);
                    }

                    /**** MODIFY CHALLAN ***************/
                    using (SqlCommand sqlCmdSPNewChallan = new SqlCommand("sp_ModifyChallan", sqlConnection))
                    {
                        sqlCmdSPNewChallan.CommandType = CommandType.StoredProcedure;
                        sqlCmdSPNewChallan.Parameters.AddWithValue("@ChallanID", labelNewChallanNumber.Text);
                        sqlCmdSPNewChallan.Parameters.AddWithValue("@DeleteFlag", "N");
                        sqlCmdSPNewChallan.Parameters.Add("@Date", SqlDbType.DateTime).Value = dateNewChallan.Value;

                        using (SqlDataReader reader = sqlCmdSPNewChallan.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                savePrintChallan(labelNewChallanNumber.Text);
                                savePrintChallan(reader.GetString(0));
                                if (radioButtonNewChallan.Checked)
                                {
                                    MessageBox.Show("Challan " + reader.GetString(0) + " UPDATED successfully!");
                                    buttonNewChallanInsert.Text = "&Insert Challan";
                                    comboBoxDealerName.Focus();
                                }
                                dgvNewChallan.Rows.Clear();
                                challanTotal = 0;
                                labelTotal.Text = "Total 0";
                                textBoxNewChallanRemark.Text = "";
                                textBoxPackingSlip.Text = "";
                                labelNewChallanNumber.Text = "";
                                dgvNewChallan.ReadOnly = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("CHALLAN SPLIT ERROR - " + ex.Message);
            }
        }
    }
}
