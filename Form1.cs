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
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace GoldenCoinChallan
{
    public partial class Form1 : Form
    {
        private readonly IChallanService _challanService;

        public Form1(IChallanService challanService) => _challanService = challanService;

        public Form1() : this(Program.ServiceProvider.GetService<IChallanService>())
        {
            InitializeComponent();
            //tabControl1.SelectedTab = tabControl1.TabPages["tabPageNewChallan"];
            tabControl1.SelectedTab = tabControl1.TabPages["tabPageChallanPrint"];
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

        private void dgvNewChallan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (sender is ComboBox cb)
                {
                    dgvNewChallan.CurrentCell.Value = cb.SelectedValue ?? cb.Text;
                    e.Handled = true;
                }
                e.SuppressKeyPress = true; // prevent default behavior (like moving to next row)
                SendKeys.Send("{TAB}");    // simulate Tab key
            }
        }


        private void dgvNewChallan_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            string dgvCurrentColumnName = dgvNewChallan.CurrentCell.OwningColumn.Name;
            if (e.Control is TextBox tb)
            {
                tb.KeyDown -= dgvNewChallan_KeyDown;
                tb.KeyDown += dgvNewChallan_KeyDown;
            }
            else if (e.Control is ComboBox cb)
            {
                cb.DropDownStyle = ComboBoxStyle.DropDown;
                cb.DroppedDown = true;

                cb.KeyDown -= dgvNewChallan_KeyDown;
                cb.KeyDown += dgvNewChallan_KeyDown;

                if (cb.Items.Count == 1)
                {
                    cb.SelectedIndex = 0;
                }
            }
            if (dgvCurrentColumnName == "ItemNameFilter" && e.Control is TextBox txtItemNameFilter)
            {
                if (txtItemNameFilter != null)
                {
                    txtItemNameFilter.KeyPress -= TxtItemSize_KeyPress;
                    txtItemNameFilter.TextChanged -= TxtItemNameFilter_TextChanged;
                    txtItemNameFilter.TextChanged += TxtItemNameFilter_TextChanged;
                }
            }
            else if (dgvCurrentColumnName.Contains("Size") && e.Control is TextBox txtItemSize)
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
            else if (dgvCurrentColumnName == "ItemName" && e.Control is ComboBox comboboxItemName)
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
                        comboboxItemName_TextChanged(comboboxItemName, e);
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

        private void comboBoxDealerName_Enter(object sender, EventArgs e)
        {
            comboBoxDealerName.IntegralHeight = false;
            int visibleItems = Math.Min(4, comboBoxDealerName.MaxDropDownItems);
            comboBoxDealerName.DropDownHeight = comboBoxDealerName.ItemHeight * visibleItems;
            comboBoxDealerName.DroppedDown = true;
            comboBoxDealerName.IntegralHeight = false;
            visibleItems = Math.Min(4, comboBoxDealerName.MaxDropDownItems);
            comboBoxDealerName.DropDownHeight = comboBoxDealerName.ItemHeight * visibleItems;
        }

        private void tabPageNewChallan_Enter(object sender, EventArgs e)
        {
            comboBoxDealerName.Focus();
            comboBoxDealerName.DroppedDown = true;
        }

        private void comboBoxDealerName_KeyPress(object sender, KeyPressEventArgs e)
        {
            comboBoxDealerName.DroppedDown = true;
            // Force dropdown to resize based on current items
            int visibleItems = comboBoxDealerName.MaxDropDownItems;
            comboBoxDealerName.DropDownHeight = comboBoxDealerName.ItemHeight * visibleItems;
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



        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Form1_Load(sender, e);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                // If focus is inside DataGridView
                if (this.ActiveControl is DataGridView dgv)
                {
                    do
                    {
                        // If last column, move to first cell of next row
                        if (dgv.CurrentCell.ColumnIndex == dgv.ColumnCount - 1)
                        {
                            int nextRow = dgv.CurrentCell.RowIndex + 1;
                            if (nextRow < dgv.RowCount)
                            {
                                dgv.CurrentCell = dgv.Rows[nextRow].Cells[0];
                            }
                            else
                            {
                                this.SelectNextControl(this.ActiveControl, true, true, true, true);
                            }
                        }
                        else
                        {
                            // Otherwise move to next column

                            dgv.CurrentCell = dgv.Rows[dgv.CurrentCell.RowIndex]
                                               .Cells[dgv.CurrentCell.ColumnIndex + 1];
                            //} while (dgv.CurrentCell.ReadOnly == true || (dgv.CurrentCell.ColumnIndex != dgv.ColumnCount - 1));

                        }
                    } while ((dgv.CurrentCell.ReadOnly == true) && (this.ActiveControl.Name != "buttonNewChallanInsert"));
                }
                else if (this.ActiveControl.Parent.Parent is DataGridView dgv1)
                {
                    if (dgvNewChallan.CurrentCell is DataGridViewComboBoxCell)
                    {
                        ComboBox cb = dgvNewChallan.EditingControl as ComboBox;
                        if (cb != null)
                        {
                            // Auto-select if only one item remains
                            if (cb.Items.Count == 1)
                            {
                                cb.SelectedIndex = 0;
                            }

                            // Commit the selection back to the cell
                            dgvNewChallan.CurrentCell.Value = cb.SelectedValue ?? cb.Text;
                        }
                    }
                    do
                    {
                        // If last column, move to first cell of next row
                        if (dgv1.CurrentCell.ColumnIndex == dgv1.ColumnCount - 1)
                        {
                            int nextRow = dgv1.CurrentCell.RowIndex + 1;
                            if (nextRow < dgv1.RowCount)
                            {
                                dgv1.CurrentCell = dgv1.Rows[nextRow].Cells[0];
                            }
                            else
                                this.SelectNextControl(this.ActiveControl, true, true, true, true);
                        }
                        else
                        {
                            // Otherwise move to next column

                            dgv1.CurrentCell = dgv1.Rows[dgv1.CurrentCell.RowIndex]
                                                             .Cells[dgv1.CurrentCell.ColumnIndex + 1];
                            //} while (dgv1.CurrentCell.ReadOnly==true||(dgv1.CurrentCell.ColumnIndex != dgv1.ColumnCount - 1));
                        }
                    } while ((dgv1.CurrentCell.ReadOnly == true) && (this.ActiveControl.Name != "buttonNewChallanInsert"));
                }
                else
                {
                    // For other controls, behave like Tab
                    this.SelectNextControl(this.ActiveControl, true, true, true, true);
                }

                return true; // handled
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private async void btnTallyExport_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Tally XML Export - Work in Progress. -> " + textBoxChallan.Text);
            try
            {
                string challanNo = textBoxChallan.Text; // from a textbox
                string xml = await _challanService.GenerateTallyXMLAsync(challanNo);
                string fileName = $"Challan_{challanNo.Replace("/", "_").Replace("\\", "_")}.xml";
                string exportPath = fileName;
                //Save to file using SAVE DIALOG as a backup option if export path is not set or does not exist in settings
                var saveDialog = new SaveFileDialog
                {
                    Filter = "XML Files|*.xml",
                    FileName = fileName
                };

                //if (saveDialog.ShowDialog() == DialogResult.OK)
                //{
                //    System.IO.File.WriteAllText(saveDialog.FileName, xml);
                //    //MessageBox.Show("Tally XML exported successfully!");
                //    labelStatus.Text = fileName + " exported successfully";
                //    labelStatus.BackColor = Color.LightGreen;
                //}

                if (Directory.Exists(Properties.Settings.Default.ExportPathXML))
                {
                    exportPath = Path.Combine(Properties.Settings.Default.ExportPathXML, fileName);
                }
                else if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    exportPath = saveDialog.FileName;
                }
                else
                {
                    labelStatus.Text = "Export path does not exist. Please check the settings.";
                    labelStatus.BackColor = Color.LightCoral;
                    return;
                }
                System.IO.File.WriteAllText(exportPath, xml);
                labelStatus.Text = fileName + " exported successfully to " + exportPath.Replace(fileName,"");
                labelStatus.BackColor = Color.LightGreen;                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
                labelStatus.Text = $"Error: {ex.Message}";
                labelStatus.BackColor = Color.LightCoral;
            }
        }
    }
}
