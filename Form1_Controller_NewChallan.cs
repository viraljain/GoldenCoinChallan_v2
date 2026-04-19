using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoldenCoinChallan
{
    public partial class Form1
    {
        DataTable dt_ItemNameSize = new DataTable(), dt_DealerName = new DataTable();
        BindingSource bsDealerName = new BindingSource(), bsItemName = new BindingSource();
        int challanTotal = 0, oldSizeVal = 0, newSizeVal = 0;
        private void newChallan_Load()
        {
            this.newChallanItemTableAdapter1.Fill(this.aA_2023_2024DataSet.ViewNewChallan);
            DataGridViewComboBoxColumn dgvNewItem = (DataGridViewComboBoxColumn)dgvNewChallan.Columns["ItemName"];

            dt_ItemNameSize = this.newChallanItemTableAdapter1.GetItemNameWithSizes().Distinct().CopyToDataTable();

            DataRow rowSelectItem = dt_ItemNameSize.NewRow();
            rowSelectItem["ItemName"] = "Select Item";
            rowSelectItem["ItemSize"] = "0";

            //dt_ItemNameSize.Rows.InsertAt(rowSelectItem, 0);
            //dgvNewItem.DataSource = dt_ItemNameSize;
            bsItemName.DataSource = dt_ItemNameSize;
            dgvNewItem.DataSource = bsItemName;
            dgvNewItem.DisplayMember = "ItemName";
            dgvNewItem.ValueMember = "ItemSize";


            /* Dealer Name Fetching */
            dt_DealerName = this.newChallanItemTableAdapter1.GetDealerNameWithDetails();
            bsDealerName.DataSource = dt_DealerName;
            bsDealerName.Sort = "DealerName";
            //comboBoxDealerName.DataSource = dt_DealerName; 
            comboBoxDealerName.DataSource = bsDealerName;
            comboBoxDealerName.DisplayMember = "DealerName"; comboBoxDealerName.ValueMember = "DealerId";

            comboBoxDealerName.IntegralHeight = false;
        }
        private void TxtItemSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txtItemSize = sender as TextBox;
            if (txtItemSize != null)
            {
                // Allow only digits and control characters (like backspace)
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true; // Prevent the character from being entered
                    txtItemSize.BackColor = Color.OrangeRed;
                }
                else
                {
                    if (txtItemSize.BackColor == Color.OrangeRed)
                    {
                        txtItemSize.BackColor = (dgvNewChallan.CurrentCell.RowIndex % 2 != 0) ? Color.FromArgb(222, 255, 255) : Color.White; // Reset background color if valid input
                    }
                }
            }
        }

        private void TxtItemSize_GotFocus(object sender, EventArgs e)
        {
            TextBox txtItemSize = sender as TextBox;
            if (txtItemSize != null)
            {
                int.TryParse(txtItemSize.Text.ToString(), out oldSizeVal);
            }
        }

        private void TxtItemSize_LostFocus(object sender, EventArgs e)
        {
            TextBox txtItemSize = sender as TextBox;
            int rowTotal = Convert.ToInt16(dgvNewChallan.Rows[dgvNewChallan.CurrentCell.RowIndex].Cells["rowTotal"].Value);
            if (txtItemSize != null)
            {
                int.TryParse(txtItemSize.Text.ToString(), out newSizeVal);
                if (oldSizeVal != newSizeVal)
                {
                    challanTotal = challanTotal - oldSizeVal + newSizeVal;
                    rowTotal += newSizeVal - oldSizeVal;
                    labelTotal.Text = "Total " + challanTotal.ToString();
                    oldSizeVal = newSizeVal = 0;
                    dgvNewChallan.Rows[dgvNewChallan.CurrentCell.RowIndex].Cells["rowTotal"].Value = rowTotal;
                }
            }
        }

        private void dgvNewChallan_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvNewChallan.Columns[e.ColumnIndex].Name == "ItemName") // your ComboBox column
            {
                // Force edit mode immediately
                dgvNewChallan.BeginEdit(true);

                // Grab the live ComboBox editing control
                ComboBox cb = dgvNewChallan.EditingControl as ComboBox;
                if (cb != null)
                {
                    cb.DropDownStyle = ComboBoxStyle.DropDown; // allow typing
                    cb.DroppedDown = true;                     // open dropdown automatically
                }
            }
        }

        int rowIndex = -1;
        private void TxtItemNameFilter_TextChanged(object sender, EventArgs e)
        {
            TextBox txtItemNameFilter = sender as TextBox;
            if (rowIndex != dgvNewChallan.CurrentCell.RowIndex)
            {
                bsItemName.Filter = "";
            }
            if (txtItemNameFilter != null)
            {
                GetFilteredItems(txtItemNameFilter.Text);
            }
        }

        // Example method to filter items based on text input
        private void GetFilteredItems(string filterText)
        {
            int rowIndex = dgvNewChallan.CurrentCell.RowIndex;

            DataGridViewComboBoxCell comboBoxItemName = (DataGridViewComboBoxCell)dgvNewChallan.Rows[rowIndex].Cells["ItemName"];

            // Filter ComboBox items dynamically
            DataRow[] ds_ItemName = dt_ItemNameSize.Select("ItemName LIKE '%" + filterText + "%'");

            dgvNewChallan.Rows[rowIndex].Cells["ItemName"].Value = null;

            comboBoxItemName.DataSource = (ds_ItemName.Length > 0) ? ds_ItemName.CopyToDataTable() : dt_ItemNameSize;
            comboBoxItemName.DisplayMember = "ItemName";
            comboBoxItemName.ValueMember = "ItemSize";

            //BindingSource bsItemNameRow = new BindingSource { DataSource = bsItemName.DataSource };
            //bsItemNameRow.Filter = "ItemName LIKE '%" + filterText + "%'";
            //comboBoxItemName.DataSource = bsItemNameRow;
            //dgvNewChallan.CurrentRow.Cells["ItemName"].Value = "Select Item";

            // Ensure cell is in edit mode, then open dropdown
            if (!dgvNewChallan.IsCurrentCellInEditMode)
                dgvNewChallan.BeginEdit(true);
        }

        private void newChallan_RemoveRows()
        {
            int sumDeletedRows = 0;
            foreach (DataGridViewColumn column in dgvNewChallan.Columns)
            {
                if (column.Name.Contains("Size") && dgvNewChallan.Columns.Contains(column.Name))
                {
                    sumDeletedRows += deletedRows.Where(row => row.Cells[column.Index] != null && !(row.Cells[column.Index].Value == null)).Sum(row => Convert.ToInt16(row.Cells[column.Index].Value));
                    //sumDeletedRows += deletedRows.Where(row => row.Cells[column.Index] != null && row.Cells[column.Index].Value.ToString().Length>0).Sum(row => Convert.ToInt16(row.Cells[column.Index].Value));

                }
            }
            challanTotal -= sumDeletedRows;
            labelTotal.Text = "Total " + challanTotal.ToString();
            sumDeletedRows = 0;
            deletedRows.Clear();
        }

        List<DataGridViewRow> deletedRows = new List<DataGridViewRow>();
        private void newChallan_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            deletedRows.Add(e.Row);
        }

        private void comboboxItemName_TextChanged(object sender, EventArgs e)
        {
            ComboBox comboBoxItemName = sender as ComboBox;
            if (comboBoxItemName != null && comboBoxItemName.SelectedValue != null && comboBoxItemName.SelectedValue.ToString().Replace("/", "_") != "System.Data.DataRowView")
            {
                string selectedValue = comboBoxItemName.SelectedValue.ToString();
                string[] availableSizes = selectedValue.Replace("/", "_").Split(new String[] { "|||" }, StringSplitOptions.RemoveEmptyEntries);
                dgvNewChallan.CurrentRow.Cells["UnitName"].Value = availableSizes[1];
                availableSizes = availableSizes.Skip(2).ToArray();

                //dgvNewChallan.CurrentRow.ReadOnly = true;
                dgvNewChallan.CurrentRow.Cells["ItemName"].ReadOnly = false;

                foreach (DataGridViewCell cell in dgvNewChallan.CurrentRow.Cells)
                {
                    if (!dgvNewChallan.Columns[cell.ColumnIndex].Name.Contains("Name") && !dgvNewChallan.Columns[cell.ColumnIndex].Name.Contains("Total"))
                    {
                        cell.ReadOnly = true;
                        cell.Style.BackColor = (dgvNewChallan.CurrentCell.RowIndex % 2 != 0) ? Color.CadetBlue : Color.DarkGray;
                        //cell.Value = ""; // Clear the value of the cell
                    }
                }

                string firstActiveSize = "";
                foreach (var size in availableSizes)
                {
                    if (dgvNewChallan.Columns.Contains("Size_" + size))
                    {
                        if (firstActiveSize.Length == 0)
                            firstActiveSize = "Size_" + size;
                        dgvNewChallan.CurrentRow.Cells["Size_" + size].ReadOnly = false;
                        dgvNewChallan.CurrentRow.Cells["Size_" + size].Style.BackColor = (dgvNewChallan.CurrentCell.RowIndex % 2 != 0) ? Color.FromArgb(222, 255, 255) : Color.White; // Reset background color if valid input;
                    }
                    else
                    {
                        if (firstActiveSize.Length == 0)
                            firstActiveSize = "Size_Misc";
                        dgvNewChallan.CurrentRow.Cells["Size_Misc"].ReadOnly = false;
                        dgvNewChallan.CurrentRow.Cells["Size_Misc"].Style.BackColor = (dgvNewChallan.CurrentCell.RowIndex % 2 != 0) ? Color.FromArgb(222, 255, 255) : Color.White;
                        dgvNewChallan.CurrentRow.Cells["Size_Misc"].OwningColumn.HeaderText = size;
                        dgvNewChallan.CurrentRow.Cells["Size_Misc"].OwningColumn.Visible = true;
                    }
                }
                //It is causing some issue with the selected index of the combobox.
                //dgvNewChallan.CurrentRow.Cells[firstActiveSize].Selected = true;

                //To clear only invalid non-empty cells & keep valid non-empty cells.
                foreach (DataGridViewCell cell in dgvNewChallan.CurrentRow.Cells)
                {
                    if (!dgvNewChallan.Columns[cell.ColumnIndex].Name.Contains("Name"))
                    {
                        if (cell.ReadOnly == true && (cell.Style.BackColor == Color.DarkGray || cell.Style.BackColor == Color.CadetBlue) && cell.Value != null)
                        {
                            if (!String.IsNullOrEmpty(cell.Value.ToString()))
                            {
                                challanTotal -= Convert.ToInt16(cell.Value);
                            }
                            cell.Value = ""; // Clear the value of the cell                            
                        }
                    }
                }
                labelTotal.Text = "Total " + challanTotal.ToString();
            }
        }
        #region Non-working Editable Combobox in DataGridView
        /****** Non-working Editable Combobox in DataGridView ******
		 * private void dgvNewChallan_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
        	if (e.Control is ComboBox comboBox)
        	{
        		comboBox.DropDownStyle = ComboBoxStyle.DropDown; // Set the ComboBox to DropDown style

        		//comboBox.TextChanged -= ComboBox_TextChanged; // Remove previous event handler
        		//comboBox.TextChanged += ComboBox_TextChanged; // Add new event handler
        		//comboBox.KeyUp -= ComboBox_TextChanged; // Remove previous event handler
        		//comboBox.KeyUp += ComboBox_TextChanged; // Add new event handler

        		comboBox.SelectedIndexChanged -= ComboBox_SelectedIndexChanged; // Remove previous event handler
        		comboBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged; // Add new event handler

        	}
        }
         Filter items dynamically
        void ComboBox_TextChanged(object sender, EventArgs e)
		{
			if (sender is ComboBox comboBox)
			{
				string filterText = comboBox.Text.ToLower();
				comboBox.
				if (filterText.Length >= 5)
				{
					//DataGridViewComboBoxColumn dgvNewItem = (DataGridViewComboBoxColumn)dgvNewChallan.Columns[0];
					DataGridViewComboBoxColumn dgvNewItem = (DataGridViewComboBoxColumn)dgvNewChallan.Columns[0];

					dgvNewItem.DataSource = this.newChallanItemTableAdapter1.GetItemNameWithSizes().Distinct().CopyToDataTable();
					dgvNewItem.DisplayMember = "ItemName";
					dgvNewItem.ValueMember = "ItemSize";

					

		// Assuming you have a DataTable with a column named "ItemName"                
		var filteredItems = dgvNewItem.Items.Cast<DataRowView>().Where(item => item["ItemName"].ToString().ToLower().Contains(filterText)).Distinct().ToList();

		comboBox.DataSource = new BindingSource(filteredItems, null);
	}

				if (comboBox.Items.Count <= 5)
				{
					DataGridViewComboBoxColumn dgvNewItem = (DataGridViewComboBoxColumn)dgvNewChallan.Columns[0];

	dgvNewItem.DataSource = this.newChallanItemTableAdapter1.GetItemNameWithSizes().Distinct().CopyToDataTable();
	dgvNewItem.DisplayMember = "ItemName";
	dgvNewItem.ValueMember = "ItemSize";
	}
}
		}
		void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
{
	//int selectedProductIndex = 0;
	if (sender is ComboBox comboBox)
	{
		if (comboBox.SelectedIndex >= 0)
		{
			//selectedProductIndex = comboBox.SelectedIndex;
			//MessageBox.Show($"Selected Item: {selectedItem}, Selected Value:{comboBox.SelectedValue}");

			string[] availableSizes = comboBox.SelectedValue.ToString().Replace("/", "").Split(',');
			//dgvNewChallan.CurrentRow.ReadOnly = true;
			dgvNewChallan.CurrentRow.Cells["ItemName"].ReadOnly = false;
			//dgvNewChallan.CurrentRow.Cells.Cast<DataGridViewCell>().Where(cell => dgvNewChallan.Columns[cell.ColumnIndex].Name!="ItemName").ReadOnly = false;

			foreach (DataGridViewCell cell in dgvNewChallan.CurrentRow.Cells)
			{
				if (dgvNewChallan.Columns[cell.ColumnIndex].Name != "ItemName")
				{
					cell.ReadOnly = true;
					cell.Style.BackColor = Color.DarkGray;
				}
			}

			string firstActiveSize = "";
			foreach (var size in availableSizes)
			{
				//dgvNewChallan.CurrentRow.DefaultCellStyle.BackColor = Color.DarkGray;
				if (dgvNewChallan.Columns.Contains("Size" + size))
				{
					if (firstActiveSize.Length == 0)
						firstActiveSize = "Size" + size;
					dgvNewChallan.CurrentRow.Cells["Size" + size].ReadOnly = false;
					dgvNewChallan.CurrentRow.Cells["Size" + size].Style.BackColor = Color.White;
				}
			}

			//Explicitly set the selected index to the current index as it is randomly getting changed.
			//comboBox.SelectedIndex = selectedProductIndex;
			//dgvNewChallan.CurrentRow.Cells[firstActiveSize].Selected = true;
		}
	}
}
*/
        #endregion

        DataRowView currentDealerRow;
        private void comboBoxDealerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDealerName.SelectedIndex >= 0)
            {
                currentDealerRow = (DataRowView)((ComboBox)sender).Items[comboBoxDealerName.SelectedIndex];
                //string displayText = $"{currentDealerRow["DealerName"].ToString().ToUpper(),-15} " + Environment.NewLine +
                //    $"{currentDealerRow["Add1"]}, {currentDealerRow["Add2"]}, {currentDealerRow["Add3"]}";
                string displayText = $"{currentDealerRow["DealerName"],-15} ";
                labelDealerDetails.Text = displayText;
            }
        }

        private void buttonNewChallanInsert_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtNewChallan = new DataTable();
                dtNewChallan.Columns.Add("ItemName", typeof(string));
                dtNewChallan.Columns.Add("ItemSize", typeof(string));
                dtNewChallan.Columns.Add("ItemQty", typeof(Int16));
                dtNewChallan.Columns.Add("ItemUnit", typeof(string));

                string itemName = string.Empty, itemUnit = String.Empty, itemSize = String.Empty;
                int itemQty = 0;

                foreach (DataGridViewRow row in dgvNewChallan.Rows)
                {
                    if (row.IsNewRow)
                    {
                        if (row.Index == 0)
                        {
                            MessageBox.Show("Please fill all the rows before inserting");
                            return;
                        }
                    }
                    else
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

                                dtNewChallan.Rows.Add(itemName, itemSize, itemQty, itemUnit);
                            }
                        }
                    }

                    /// Logic for displaying new challan details in MessageBox before sending to DB.
                    ///
                    //string newChallan = "";
                    //newChallan = string.Join(
                    //                 Environment.NewLine,
                    //                 dtNewChallan
                    //                 .AsEnumerable()
                    //                 .Select(rowCurr => string.Join("\t", rowCurr.ItemArray.Select(item => item.ToString()))));

                    //newChallan = dtNewChallan.AsEnumerable().ToList().ForEach(rowCurr => String.Join("\t", rowCurr.ItemArray.Select(item=>item.ToString())));
                    //MessageBox.Show(newChallan);
                }

                /// Temporarily inserting only Item Table from WindowsForm to DB.
                /// In the final execution, all details will be stored in DataTable followed by TempTable & then Stored Procedure will be executed.
                /// In the Stored Procedure, Remember to use transactions such that changes can be rolled back in case of error at any step.
                /// 
                using (SqlConnection sqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GoldenCoinChallan.Properties.Settings.AA_2023_2024ConnectionString"].ConnectionString))
                {
                    ///Inserting Header Information into TEMP Challan Header Table
                    string sqlQueryChallanHeader = "INSERT INTO tblNewChallanTemp_Header(DealerName, DealerCode, Remarks, TotalItemQty) " +
                        "VALUES (@DealerName, @DealerCode, @Remarks, @TotalItemQty)";
                    using (SqlCommand sqlCmdChallanHeader = new SqlCommand(sqlQueryChallanHeader, sqlConnection))
                    {
                        sqlCmdChallanHeader.Parameters.AddWithValue("@DealerName", comboBoxDealerName.Text.ToString());
                        sqlCmdChallanHeader.Parameters.AddWithValue("@DealerCode", comboBoxDealerName.SelectedValue.ToString());
                        sqlCmdChallanHeader.Parameters.AddWithValue("@Remarks", textBoxNewChallanRemark.Text);
                        sqlCmdChallanHeader.Parameters.AddWithValue("@TotalItemQty", challanTotal);

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

                    using (SqlCommand sqlCmdSPNewChallan = new SqlCommand("sp_NewChallan", sqlConnection))
                    {
                        sqlCmdSPNewChallan.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = sqlCmdSPNewChallan.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                MessageBox.Show("Challan created successfully! Challan No. is " + reader.GetString(0));
                                dgvNewChallan.Rows.Clear();
                                challanTotal = 0;
                                labelTotal.Text = "Total 0";
                                textBoxNewChallanRemark.Text = "";
                                comboBoxDealerName.Focus();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR Occurred - " + ex.Message);
            }
        }
        private void comboBoxDealerName_TextUpdated(object sender, EventArgs e)
        {
            string filterText = comboBoxDealerName.Text.Replace("'", "''"); // escape quotes
            bsDealerName.Filter = $"DealerName LIKE '%{filterText}%'";
            comboBoxDealerName.DroppedDown = true;

            // Preserve user input
            comboBoxDealerName.Text = filterText;
            comboBoxDealerName.SelectionStart = filterText.Length;
        }

        private void comboBoxDealerName_DropDown(object sender, EventArgs e)
        {
            comboBoxDealerName.IntegralHeight = false;
            int visibleItems = Math.Min(8, comboBoxDealerName.MaxDropDownItems);
            comboBoxDealerName.DropDownHeight = comboBoxDealerName.ItemHeight * visibleItems;
        }

        private void comboBoxDealerName_Leave(object sender, EventArgs e)
        {
            bsDealerName.RemoveFilter();

            comboBoxDealerName.SelectedIndex = bsDealerName.Find("DealerName", currentDealerRow["DealerName"]);
        }

        private void buttonResetChallan_Click(object sender, EventArgs e)
        {
            DialogResult userResponse_deleteRow = MessageBox.Show(Text = "Are you sure you want to delete the selected rows?", "Item Deletion Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (userResponse_deleteRow == DialogResult.No)
                return;
            else
            {
                userResponse_deleteRow = MessageBox.Show(Text = "Please confirm again that you want to delete the selected rows?", "Item Deletion Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (userResponse_deleteRow == DialogResult.No)
                    return;
                else
                {
                    dgvNewChallan.Rows.Clear();
                    challanTotal = 0;
                    labelTotal.Text = "Total 0";
                    textBoxNewChallanRemark.Text = "";
                    bsDealerName.RemoveFilter();
                    comboBoxDealerName.Focus();
                    labelDealerName.Text = "";
                }
            }
        }
    }
}
