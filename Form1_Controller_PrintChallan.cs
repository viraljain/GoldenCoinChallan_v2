using GoldenCoinChallan.AA_2023_2024DataSetTableAdapters;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoldenCoinChallan
{
    public partial class Form1
    {
        private async Task showChallanData()
        //private void showChallanData()
        {
            string challanNo = textBoxChallan.Text;

            using (var tempViewChallanPrintTableAdapter = new ViewChallanPrintTableAdapter())
            {
                //Below code is used to populate the report viewer
                //DataTable resTable = await Task.Run(() => this.viewChallanPrintTableAdapter.GetDataBy(challanNo));
                DataTable resTable = await Task.Run(() => tempViewChallanPrintTableAdapter.GetDataBy(challanNo));
                //DataTable resTable = this.viewChallanPrintTableAdapter.GetDataBy(textBoxChallan.Text); 

                var rds = new ReportDataSource("DSViewChallanPrint", resTable as DataTable);
                this.reportViewerChallanPrint.LocalReport.DataSources.Clear();

                this.reportViewerChallanPrint.LocalReport.DataSources.Add(rds);
                this.reportViewerChallanPrint.LocalReport.Refresh();
                this.reportViewerChallanPrint.RefreshReport();
            }            
        }

        private void generateChallan() 
        {
            panel1.Visible = lblChallanProgress.Visible = progressBar1.Visible = true;
            panel1.BringToFront();

            System.Threading.Thread.Sleep(30);
            MessageBox.Show("Challan is being generated!!!");

            //Call the method to populate the DataGridView on the right to current challan details & ReportViewer
            showChallanData();

            panel1.Visible = lblChallanProgress.Visible = false;

            /* DataGridView is linked to viewChallanPrintBindingSource which is linked to ViewChallanPrintTableAdapter
			 * and the DataGridView is populated with the data from the DataSet
			 * The DataGridView is used to show the current challan details
			 * Below code is used to popuplate the DataGridView on the right to current challan details
			 */
            //this.viewChallanListTableAdapter1.Fill(this.aA_2023_2024DataSet.ViewChallanList);
        }
        private void buttonChallanPrintRefresh_Click(object sender, EventArgs e)
        {
            this.viewChallanListTableAdapter1.Fill(this.aA_2023_2024DataSet.ViewChallanList);
        }
    }
}
