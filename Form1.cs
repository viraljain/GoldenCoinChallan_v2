using GoldenCoinChallan.AA_2023_2024DataSetTableAdapters;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace GoldenCoinChallan
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Text == "Godown Transfer")
            {
                //For GODOWNTRANSFER Tab - Call the method to populate the DataGridView on the right to show PSlips transferred to Godown in the specified date range
                this.vwGodownTrfSlipsTableAdapter.FillBy(this.aA_2023_2024DataSet.vwGodownTrfSlips, dtpFrom.Value.Date, dtpTo.Value.Date);
            }
            else if (tabControl1.SelectedTab.Text == "New Challan")
            {
                //For NEW CHALLAN Tab - Call the method to populate the DataGridView Item Name DropDown ComboBox
                newChallan_Load();
            }
            else if (tabControl1.SelectedTab.Text == "Challan Print")
            {
                //For CHALLANPRINT Tab - Call the method to populate the DataGridView on the right to current challan details & ReportViewer
                /* DataGridView is linked to viewChallanPrintBindingSource which is linked to ViewChallanPrintTableAdapter
                 * and the DataGridView is populated with the data from the DataSet
                 * The DataGridView is used to show the current challan details
                 * Below code is used to popuplate the DataGridView on the right to current challan details
                 */
                this.viewChallanListTableAdapter1.Fill(this.aA_2023_2024DataSet.ViewChallanList);
            }
        }
        #region FORM RESIZE LOGIC
        /*		FORM RESIZE LOGIC START		*/
        private void Form1_Resize(object sender, EventArgs e)
        {
            //try
            //{
            //    if (Form1.ActiveForm!=null && Form1.ActiveForm.Height > 0 && Form1.ActiveForm.Width > 0)
            //    {
            //        Int32 windowHeight = Convert.ToInt32(Form1.ActiveForm.Height);
            //        Int32 windowWidth = Convert.ToInt32(Form1.ActiveForm.Width);
            //        reportViewer1.Height = Convert.ToInt32(windowHeight * .8745);
            //        reportViewer1.Width = Convert.ToInt32(windowWidth * .54);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("A windows resize error has occurred. Kindly restart the application");
            //}
        }
        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            //try
            //{
            //    if (Form1.ActiveForm != null && Form1.ActiveForm.Height > 0 && Form1.ActiveForm.Width > 0)
            //    {
            //        Int32 windowHeight = Convert.ToInt32(Form1.ActiveForm.Height);
            //        Int32 windowWidth = Convert.ToInt32(Form1.ActiveForm.Width);
            //        reportViewer1.Height = Convert.ToInt32(windowHeight * .8745);
            //        reportViewer1.Width = Convert.ToInt32(windowWidth * .54);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("A windows resize error has occurred. Kindly restart the application");
            //}
        }
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                if (Form1.ActiveForm != null && Form1.ActiveForm.Height > 0 && Form1.ActiveForm.Width > 0)
                {
                    Int32 windowHeight = Convert.ToInt32(Form1.ActiveForm.Height);
                    Int32 windowWidth = Convert.ToInt32(Form1.ActiveForm.Width);
                    reportViewerChallanPrint.Height = Convert.ToInt32(windowHeight * .8745);
                    reportViewerChallanPrint.Width = Convert.ToInt32(windowWidth * .54);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("A windows resize error has occurred. Kindly restart the application");
            }
        }
        /*		FORM RESIZE LOGIC ENDS		*/
        #endregion

        #region NEW CHALLAN LOGIC

        private void dgvNewChallan_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvNewChallan.CurrentCell.OwningColumn.Name == "ItemNameFilter" && e.Control is TextBox txtItemNameFilter)
            {
                if (txtItemNameFilter != null)
                {
                    txtItemNameFilter.TextChanged -= TxtItemNameFilter_TextChanged;
                    txtItemNameFilter.TextChanged += TxtItemNameFilter_TextChanged;
                }
            }
            else if (dgvNewChallan.CurrentCell.OwningColumn.Name.Contains("Size") && e.Control is TextBox txtItemSize)
            {
                if (txtItemSize != null)
                {
                    txtItemSize.KeyPress -= TxtItemSize_KeyPress;
                    txtItemSize.KeyPress += TxtItemSize_KeyPress;
                    //txtItemSize.KeyUp -= TxtItemSize_KeyUp;
                    //txtItemSize.KeyUp += TxtItemSize_KeyUp;
                    txtItemSize.GotFocus -= TxtItemSize_GotFocus;
                    txtItemSize.GotFocus += TxtItemSize_GotFocus;
                    txtItemSize.LostFocus -= TxtItemSize_LostFocus;
                    txtItemSize.LostFocus += TxtItemSize_LostFocus;
                }
            }
            else if (dgvNewChallan.CurrentCell.OwningColumn.Name == "ItemName" && e.Control is ComboBox comboboxItemName)
            {
                if (comboboxItemName != null)
                {
                    //comboboxItemName.TextChanged -= comboboxItemName_TextChanged;
                    //comboboxItemName.TextChanged += comboboxItemName_TextChanged;
                    comboboxItemName.SelectedIndexChanged -= comboboxItemName_TextChanged;
                    comboboxItemName.SelectedIndexChanged += comboboxItemName_TextChanged;

                    //comboboxItemName.SelectionChangeCommitted -= comboboxItemName_SelectionChangeCommitted;
                    //comboboxItemName.SelectionChangeCommitted += comboboxItemName_SelectionChangeCommitted;
                    if (comboboxItemName.SelectedIndex == 0)
                    {
                        comboboxItemName_TextChanged(sender, e);
                    }
                }
            }
        }

        private void dgvNewChallan_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            newChallan_RemoveRows();
        }
        private void dgvNewChallan_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult userResponse_deleteRow = MessageBox.Show(Text = "Are you sure you want to delete the selected rows?", "Item Deletion Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (userResponse_deleteRow == DialogResult.No)
                e.Cancel = true;
            else
            {
                userResponse_deleteRow = MessageBox.Show(Text = "Please confirm again that you want to delete the selected rows?", "Item Deletion Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (userResponse_deleteRow == DialogResult.No)
                    e.Cancel = true;
                else
                {
                    newChallan_UserDeletingRow(sender, e);
                    //dgvNewChallan_RowsRemoved(sender, e);
                    //dgvNewChallan.Rows.RemoveAt(e.RowIndex);
                    //dgvNewChallan.Rows.Remove(dgvNewChallan.CurrentRow);
                }
            }
        }
        private void comboboxItemName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            dgvNewChallan.EndEdit();
        }
        #endregion

        #region CHALLAN PRINT LOGIC
        private void btnGenChallan_Click(object sender, EventArgs e)
        {
            generateChallan();
        }
        private void viewChallanPrintDataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBoxChallan.Text = dgvChallanList["dgvTextBoxBillNo", e.RowIndex].Value.ToString();
            showChallanData();
        }
        #endregion

        #region GODOWN TRANSFER LOGIC

        private void btnGetGodownTrfSlips_Click(object sender, EventArgs e)
        {
            getGodownTransferSlips();
        }



        #endregion

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
                            MessageBox.Show("Please fill all the rows before inserting");
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



                        //newChallan = dtNewChallan.AsEnumerable().ToList().ForEach(row => String.Join("\t", row.ItemArray));
                        //dtNewChallan.Rows.Add(
                        //     ,
                        //    row.Cells["ItemSize"].Value.ToString(),
                        //    row.Cells["ItemQty"].Value.ToString(),
                        //    row.Cells["ItemNameUnitSize"].Value.ToString()
                        //);
                    }
                    string newChallan = "";
                    //foreach (DataRow dtRow in dtNewChallan.Rows)
                    //{
                    //    foreach (var cell in dtRow.ItemArray)
                    //    {
                    //        newChallan += cell.ToString() + "\t";
                    //    }
                    //    newChallan += Environment.NewLine;
                    //}
                    newChallan = string.Join(Environment.NewLine,
    dtNewChallan.AsEnumerable().Select(rowCurr => string.Join("\t", rowCurr.ItemArray.Select(item => item.ToString()))));
                    //newChallan = dtNewChallan.AsEnumerable().ToList().ForEach(rowCurr => String.Join("\t", rowCurr.ItemArray.Select(item=>item.ToString())));
                    MessageBox.Show(newChallan);
                }

                using (SqlConnection sqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GoldenCoinChallan.Properties.Settings.AA_2023_2024ConnectionString"].ConnectionString))
                {
                    using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(sqlConnection))
                    {
                        sqlConnection.Open();
                        sqlBulkCopy.ColumnMappings.Add("ItemName", "ItemName");
                        sqlBulkCopy.ColumnMappings.Add("ItemSize", "ItemSize");
                        sqlBulkCopy.ColumnMappings.Add("ItemQty", "ItemQty");
                        sqlBulkCopy.ColumnMappings.Add("ItemUnit", "ItemUnit");

                        sqlBulkCopy.DestinationTableName = "tblNewChallanTemp";
                        sqlBulkCopy.WriteToServer(dtNewChallan);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR Occurred - " + ex.Message);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Form1_Load(sender,e);
        }
    }
}
