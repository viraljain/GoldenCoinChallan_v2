using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenCoinChallan
{
    internal class ChallanTallyXMLGenerator : IChallanTallyXMLGenerator
    {
        public string Generate(Challan challan) {
            var sb = new StringBuilder();
            sb.AppendLine("<ENVELOPE>");
            sb.AppendLine("  <HEADER><TALLYREQUEST>Import Data</TALLYREQUEST></HEADER>");
            sb.AppendLine("  <BODY>");
            sb.AppendLine("    <IMPORTDATA>");
            sb.AppendLine("      <REQUESTDESC><REPORTNAME>Vouchers</REPORTNAME></REQUESTDESC>");
            sb.AppendLine("      <REQUESTDATA>");
            sb.AppendLine("        <TALLYMESSAGE>");
            sb.AppendLine($"          <VOUCHER VCHTYPE=\"{challan.VoucherType}\" ACTION=\"Create\">");
            sb.AppendLine($"            <DATE>{challan.Date:yyyyMMdd}</DATE>");
            sb.AppendLine($"            <VOUCHERTYPENAME>Delivery Note</VOUCHERTYPENAME>");
            sb.AppendLine($"            <PARTYLEDGERNAME>{challan.PartyLedgerName}</PARTYLEDGERNAME>");
            #region Deliberate/Forceful assignment of Consignee details to ABC such that user selects exact details from the Tally
            sb.AppendLine($"            <CONSIGNEEMAILINGNAME>ABC</CONSIGNEEMAILINGNAME>");
            sb.AppendLine($"            <BASICBASEPARTYNAME>ABC</BASICBASEPARTYNAME>");
            sb.AppendLine($"            <BASICBUYERNAME>ABC</BASICBUYERNAME>");
            #endregion
            sb.AppendLine($"            <NARRATION>{challan.Narration}</NARRATION>");
            sb.AppendLine($"            <REFERENCE>{challan.Id}</REFERENCE>");
            sb.AppendLine($"            <BASICSHIPPEDBY>{challan.ShippedBy}</BASICSHIPPEDBY>");

            foreach (var item in challan.Items)
            {
                sb.AppendLine("            <ALLINVENTORYENTRIES.LIST>");
                sb.AppendLine($"              <STOCKITEMNAME>{item.StockItemName}</STOCKITEMNAME>");
                sb.AppendLine($"              <ISDEEMEDPOSITIVE>{item.IsDeemedPositive}</ISDEEMEDPOSITIVE>");
                sb.AppendLine($"              <ACTUALQTY>{item.ActualQty}</ACTUALQTY>");
                sb.AppendLine($"              <BILLEDQTY>{item.BilledQty}</BILLEDQTY>");
                sb.AppendLine("              <BATCHALLOCATIONS.LIST>");
                sb.AppendLine($"                <GODOWNNAME>{item.Batch.GodownName}</GODOWNNAME>");
                sb.AppendLine($"                <DESTINATIONGODOWNNAME>{item.Batch.DestinationGodownName}</DESTINATIONGODOWNNAME>");
                sb.AppendLine($"                <TRACKINGNUMBER>{item.Batch.TrackingNumber}</TRACKINGNUMBER>");
                sb.AppendLine($"                <ACTUALQTY>{item.Batch.ActualQty}</ACTUALQTY>");
                sb.AppendLine($"                <BILLEDQTY>{item.Batch.BilledQty}</BILLEDQTY>");
                sb.AppendLine("              </BATCHALLOCATIONS.LIST>");
                sb.AppendLine("              <ACCOUNTINGALLOCATIONS.LIST>");
                sb.AppendLine($"                <LEDGERNAME>{item.Accounting.LedgerName}</LEDGERNAME>");
                sb.AppendLine($"                <AMOUNT>{item.Accounting.Amount}</AMOUNT>");
                sb.AppendLine("              </ACCOUNTINGALLOCATIONS.LIST>");
                sb.AppendLine("            </ALLINVENTORYENTRIES.LIST>");
            }

            sb.AppendLine("          </VOUCHER>");
            sb.AppendLine("        </TALLYMESSAGE>");
            sb.AppendLine("      </REQUESTDATA>");
            sb.AppendLine("    </IMPORTDATA>");
            sb.AppendLine("  </BODY>");
            sb.AppendLine("</ENVELOPE>");

            return sb.ToString();
        }
    }
}
