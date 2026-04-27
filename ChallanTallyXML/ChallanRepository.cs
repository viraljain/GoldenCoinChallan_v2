using GoldenCoinChallan.AA_2023_2024DataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenCoinChallan
{
    internal class ChallanRepository : IChallanRepository
    {
        public Challan GetChallanById(string challanNo)
        {
            //return new Challan
            //{
            //    Id = challanNo,
            //    Date = DateTime.Now,
            //    VoucherType = "Delivery Note",
            //    PartyLedgerName = "Saraswati Trading",
            //    Narration = "Goods dispatched as per SO-789",
            //    ShippedBy = "JARIA TPT. 07FGYPS3827J1ZE",
            //    Items = new List<InventoryEntry>
            //    {
            //        new InventoryEntry
            //        {
            //            StockItemName = "Divya Golddy Mini O/E 2Pc 080",
            //            IsDeemedPositive = false,
            //            ActualQty = 200,
            //            BilledQty = 200,
            //            Batch = new BatchAllocation
            //            {
            //                GodownName = "SHASTRI NAGAR",
            //                DestinationGodownName = "SHASTRI NAGAR",
            //                TrackingNumber = challanNo,
            //                ActualQty = 20,
            //                BilledQty = 20
            //            },
            //            Accounting = new AccountingAllocation
            //            {
            //                LedgerName = "CENTRAL SALES@5%",
            //                Amount = 1
            //            }
            //        }
            //    }
            //};

            using (var tempViewChallanPrintTableAdapter = new ViewChallanPrintTableAdapter())
            {
                //Below code is used to populate the report viewer
                //DataTable resTable = await Task.Run(() => this.viewChallanPrintTableAdapter.GetDataBy(challanNo));
                DataTable resTable = tempViewChallanPrintTableAdapter.GetDataBy(challanNo);

                List<InventoryEntry> challanItems = new List<InventoryEntry>();
                foreach (DataRow row in resTable.Select("ItemDesc IS NOT NULL").OrderBy(r => r["Srno"]))
                {
                    var entry = new InventoryEntry
                    {
                        StockItemName = row["ItemDesc"].ToString(),
                        IsDeemedPositive = false, // or map from DB if you have a flag
                        ActualQty = Convert.ToInt32(row["Qty"]),
                        BilledQty = Convert.ToInt32(row["Qty"]),
                        Batch = new BatchAllocation
                        {
                            GodownName = "SHASTRI NAGAR",
                            DestinationGodownName = "SHASTRI NAGAR",
                            TrackingNumber = challanNo,
                            ActualQty = Convert.ToInt32(row["Qty"]),
                            BilledQty = Convert.ToInt32(row["Qty"])
                        },
                        Accounting = new AccountingAllocation
                        {
                            //LedgerName = "CENTRAL SALES@5%",
                            LedgerName = (row["StateCode"].ToString() == "7") ? "Local Sales @ 5%" : "CENTRAL SALES@5%",
                            Amount = 1
                        }
                    };

                    challanItems.Add(entry);
                }



                Challan challan = new Challan
                {
                    Id = challanNo,
                    Date = resTable.Rows[0]["Date"].ToString() != string.Empty ? Convert.ToDateTime(resTable.Rows[0]["Date"]) : DateTime.MinValue,
                    VoucherType = "Delivery Note",
                    PartyLedgerName = resTable.Rows[0]["Name"].ToString().Replace("&", "&amp;").Replace("<D>", "(D)"),
                    Narration = resTable.Rows[0]["Remark"].ToString(),
                    ShippedBy = "SELF", //To be modified & fetched in SP_GetChallanData //resTable.Rows[0]["ShippedBy"].ToString(),
                    Items = challanItems
                };

                return challan;
            }
        }
    }
}
