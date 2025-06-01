using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoldenCoinChallan
{
    public partial class Form1
    {
        private void getGodownTransferSlips()
        {
            if (dtpFrom.Value.Date <= dtpTo.Value.Date)
            {
                dgvGodownTrfDetail.DataSource = vwGodownTrfSlipsTableAdapter.GetDataBy(dtpFrom.Value.Date, dtpTo.Value.Date);
                dgvGodownTrfDetail.Update();
                dgvGodownTrfDetail.Refresh();

                dgvGodownTrfPSlips.DataSource = vwGodownTrfSlipsTableAdapter.GetPSlips(dtpFrom.Value.Date, dtpTo.Value.Date);
                dgvGodownTrfPSlips.Update();
                dgvGodownTrfPSlips.Refresh();
            }
            else if (dtpFrom.Value.Date > dtpTo.Value.Date)
            {
                MessageBox.Show("Start Date should be less than or equal to End Date.");
            }
            else
            {
                MessageBox.Show("Dates cannot be greater than Today's Date.");
            }
        }
    }
}
