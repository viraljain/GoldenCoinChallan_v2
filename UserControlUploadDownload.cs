using ClosedXML.Excel;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace GoldenCoinChallan
{
    public partial class ucUploadDownload : UserControl
    {
        public ucUploadDownload()
        {
            InitializeComponent();
        }

        private void btnUploadTallyPurchaseExcel_Click(object sender, EventArgs e)
        {
            using (ofd)
            {
                ofd.Filter = "Excel Files|*.xlsx;*.xls";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    var dt = ReadExcelToDataTable(ofd.FileName);
                    UploadToTempTable(dt);
                    MessageBox.Show("Excel uploaded to temp table successfully!");
                }
            }
        }

        private void UploadToTempTable(DataTable dt)
        {
            using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GoldenCoinChallan.Properties.Settings.AA_2023_2024ConnectionString"].ConnectionString))
            {
                conn.Open();
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(conn))
                {
                    bulkCopy.DestinationTableName = "#TempPurchase"; // temp table
                    foreach (DataColumn col in dt.Columns)
                    {
                        bulkCopy.ColumnMappings.Add(col.ColumnName, col.ColumnName);
                    }
                    bulkCopy.WriteToServer(dt);
                }
            }
        }

        public DataTable ReadExcelToDataTable(string filePath)
        {
            var dt = new DataTable();

            using (var workbook = new XLWorkbook(filePath))
            {
                var ws = workbook.Worksheet(1); // first sheet
                bool firstRow = true;

                foreach (var row in ws.RowsUsed()) // only rows with data
                {
                    if (firstRow)
                    {
                        // Create columns from header row
                        foreach (var cell in row.Cells())
                            dt.Columns.Add(cell.Value.ToString());
                        firstRow = false;
                    }
                    else
                    {
                        // Add row values
                        dt.Rows.Add(row.Cells().Select(c => c.Value.ToString()).ToArray());
                    }
                }
            }

            return dt;
        }
    }
}
