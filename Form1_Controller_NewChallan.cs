using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoldenCoinChallan
{
    public partial class Form1
    {
        DataTable dt_ItemNameSize = new DataTable();
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
            dgvNewItem.DataSource = dt_ItemNameSize;
            dgvNewItem.DisplayMember = "ItemName";
            dgvNewItem.ValueMember = "ItemSize";

            //dgvNewChallan.Rows[0].Cells["ItemName"].Value = "Select Item";
            //dgvNewItem.DataPropertyName = "ItemName";
            //dgvNewChallan.Update();
            //dgvNewChallan.Refresh();
        }
        private void TxtItemSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txtItemSize = sender as TextBox;
            if (txtItemSize != null && txtItemSize.Name.Contains("Size"))
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
                        txtItemSize.BackColor = Color.White; // Reset background color if valid input

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
            if (txtItemSize != null)
            {
                int.TryParse(txtItemSize.Text.ToString(), out newSizeVal);
                if (oldSizeVal != newSizeVal)
                {
                    challanTotal = challanTotal - oldSizeVal + newSizeVal;
                    labelTotal.Text = "Total " + challanTotal.ToString();
                    oldSizeVal = newSizeVal = 0;
                }
            }
        }
        private void TxtItemNameFilter_TextChanged(object sender, EventArgs e)
        {
            TextBox txtItemNameFilter = sender as TextBox;
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
            //DataTable ds_ItemName = (DataTable) comboBoxItemName.DataSource;
            //DataTable ds_ItemName = dt_ItemNameSize.Copy();

            //DataRow[] ds_ItemName = dt_ItemNameSize.Select("ItemName LIKE '%" + filterText + "%' and ItemName <>'Select Item'");
            DataRow[] ds_ItemName = dt_ItemNameSize.Select("ItemName LIKE '%" + filterText + "%'");

            //DataRow rowSelectItem = dt_ItemNameSize.NewRow();
            //rowSelectItem["ItemName"] = "Select Item";
            //rowSelectItem["ItemSize"] = "0";
            //ds_ItemName.

            //DataRow firstRow = (ds_ItemName.Length > 0) ? (ds_ItemName.CopyToDataTable().AsEnumerable().FirstOrDefault()) : (dt_ItemNameSize.AsEnumerable().FirstOrDefault());

            ////dgvNewChallan.Rows[rowIndex].Cells["ItemName"].Value = (ds_ItemName.Length > 0) ? (ds_ItemName.CopyToDataTable().AsEnumerable().FirstOrDefault())["ItemName"] : (dt_ItemNameSize.AsEnumerable().FirstOrDefault())["ItemName"];
            //dgvNewChallan.Rows[rowIndex].Cells["ItemName"].Value = firstRow["ItemName"];
            dgvNewChallan.Rows[rowIndex].Cells["ItemName"].Value = null;


            ////comboBoxItemName.DataSource = null; // Clear the previous data source
            comboBoxItemName.DataSource = (ds_ItemName.Length > 0) ? ds_ItemName.CopyToDataTable() : dt_ItemNameSize;

            comboBoxItemName.DisplayMember = "ItemName";
            comboBoxItemName.ValueMember = "ItemSize";

            //dgvNewChallan.CurrentRow.Cells["ItemName"].Value = "Select Item";

        }

        private void newChallan_RemoveRows()
        {
            int sumDeletedRows = 0;
            foreach (DataGridViewColumn column in dgvNewChallan.Columns)
            {
                if (column.Name.Contains("Size") && dgvNewChallan.Columns.Contains(column.Name))
                {
                    sumDeletedRows += deletedRows.Where(row => row.Cells[column.Index] != null && !String.IsNullOrEmpty(row.Cells[column.Index].Value.ToString())).Sum(row => Convert.ToInt16(row.Cells[column.Index].Value));
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
                    if (!dgvNewChallan.Columns[cell.ColumnIndex].Name.Contains("Name"))
                    {
                        cell.ReadOnly = true;
                        cell.Style.BackColor = Color.DarkGray;
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
                        dgvNewChallan.CurrentRow.Cells["Size_" + size].Style.BackColor = Color.White;
                    }
                    else
                    {
                        if (firstActiveSize.Length == 0)
                            firstActiveSize = "Size_Misc";
                        dgvNewChallan.CurrentRow.Cells["Size_Misc"].ReadOnly = false;
                        dgvNewChallan.CurrentRow.Cells["Size_Misc"].Style.BackColor = Color.White;
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
                        if (cell.ReadOnly == true && cell.Style.BackColor == Color.DarkGray && cell.Value != null)
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
    }
}
