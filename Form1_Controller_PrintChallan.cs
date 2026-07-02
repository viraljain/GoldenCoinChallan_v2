using GoldenCoinChallan.AA_2023_2024DataSetTableAdapters;
using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;

namespace GoldenCoinChallan
{
    public partial class Form1
    {
        //private async Task showChallanData(string challanNo)
        private void showChallanData(string challanNo)
        {
            //string challanNo = textBoxChallan.Text;

            using (var tempViewChallanPrintTableAdapter = new ViewChallanPrintTableAdapter())
            {
                //Below code is used to populate the report viewer
                //DataTable resTable = await Task.Run(() => this.viewChallanPrintTableAdapter.GetDataBy(challanNo));
                //DataTable resTable = await Task.Run(() => tempViewChallanPrintTableAdapter.GetDataBy(challanNo));

                //20260701 - Replaced with PDF Viewer and Export to PDF functionality, so no need to populate the report viewer anymore
                //DataTable resTable = this.viewChallanPrintTableAdapter.GetDataBy(textBoxChallan.Text, "GEN");

                //var rds = new ReportDataSource("DSViewChallanPrint", resTable as DataTable);
                //this.reportViewerChallanPrint.LocalReport.DataSources.Clear();

                //this.reportViewerChallanPrint.LocalReport.DataSources.Add(rds);
                //this.reportViewerChallanPrint.LocalReport.Refresh();
                //this.reportViewerChallanPrint.RefreshReport();
            }
        }

        private void generateChallan(string challanNo)
        {
            //panel1.Visible = lblChallanProgress.Visible = progressBar1.Visible = true;
            //panel1.BringToFront();

            //System.Threading.Thread.Sleep(30);
            //MessageBox.Show("Challan is being generated!!!");

            //Call the method to populate the DataGridView on the right to current challan details & ReportViewer
            showChallanData(challanNo);

            //panel1.Visible = lblChallanProgress.Visible = false;

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

            var adapter = new vwGodownTrfSlipsTableAdapter();
            viewPackingSlipListBindingSource.DataSource = adapter.GetPSlipForModify();
            dgvPSlipList.DataSource = viewPackingSlipListBindingSource;
        }
        private void dgvChallanList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvChallanList.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                string action = dgvChallanList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();
                textBoxChallan.Text = dgvChallanList.Rows[e.RowIndex].Cells["dgvTextBoxBillNo"].Value?.ToString();
                switch (action)
                {
                    case "📩":
                        //MessageBox.Show("Tally Export " + dgvChallanList.Rows[e.RowIndex].Cells["dgvTextBoxBillNo"].Value?.ToString()); 
                        btnTallyExport_Click(sender, e);
                        break;
                    case "🖨️":
                        savePrintChallan(textBoxChallan.Text);
                        break;
                    default: return;
                }
            }
        }
        private void savePrintChallan(string challanNo)
        {
            LocalReport report = new LocalReport();
            report.ReportEmbeddedResource = "GoldenCoinChallan.Report_ChallanPrint.rdlc";
            //report.ReportPath = "Report_ChallanPrint.rdlc";           

            DataTable resTable = this.viewChallanPrintTableAdapter.GetDataBy(challanNo, "GEN");
            var rds = new ReportDataSource("DSViewChallanPrint", resTable as DataTable);

            report.DataSources.Add(rds);

            string deviceInfo = @"<DeviceInfo>
            <OutputFormat>PDF</OutputFormat>
            <PageWidth>8.27in</PageWidth>
            <PageHeight>11.64in</PageHeight>
            <MarginTop>0in</MarginTop>
            <MarginBottom>0in</MarginBottom>
            <MarginLeft>1.02mm</MarginLeft>
            <MarginRight>1.02mm</MarginRight>
            </DeviceInfo>";

            byte[] bytes = report.Render("PDF", deviceInfo);

            string fileName = $"{challanNo.Replace("/", "_").Replace("\\", "_")}.pdf";
            string exportPath = fileName;
            //Save to file using SAVE DIALOG as a backup option if export path is not set or does not exist in settings
            var saveDialog = new SaveFileDialog
            {
                Filter = "PDF Files|*.pdf",
                FileName = fileName
            };
            if (Directory.Exists(Properties.Settings.Default.ExportPathPDF))
            {
                exportPath = Path.Combine(Properties.Settings.Default.ExportPathPDF, fileName);
            }
            else if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                exportPath = saveDialog.FileName;
            }
            else
            {
                labelStatus.Text = "Export path does not exist. Please check the settings.";
                labelStatus.BackColor = System.Drawing.Color.LightCoral;
                return;
            }
            System.IO.File.WriteAllBytes(exportPath, bytes);
            labelStatus.Text = fileName + " exported successfully to " + exportPath.Replace(fileName, "");
            labelStatus.BackColor = System.Drawing.Color.LightGreen;

            /*
             * 20260701 - Replaced with PDF Viewer and Export to PDF functionality, so no need to print the PDF anymore
            // Print using default PDF viewer 
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = exportPath,
                //Direct Print Method - (not working in case of EDGE as PDF Viewer
                //Verb = "print",
                //CreateNoWindow = true,
                //WindowStyle = ProcessWindowStyle.Hidden
                //PDF Viewer Open Method
                UseShellExecute = true
            };
            Process.Start(psi);
            */
            //Working with 32-bit DLL but let's wait - can be enabled later
            //PrintPdf(exportPath);
        }

        private void PrintPdf(string pdfPath)
        {
            using (var document = PdfiumViewer.PdfDocument.Load(pdfPath))
            {
                using (var printDocument = document.CreatePrintDocument())
                {
                    printDocument.PrinterSettings = new PrinterSettings
                    {
                        Copies = 1,
                        // set printer name if not default
                        // PrinterName = "YourPrinterName"
                    };
                    printDocument.Print();
                }
            }
        }
    }
}
