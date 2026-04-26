using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenCoinChallan
{
    internal class ChallanService : IChallanService
    {
        private readonly IChallanRepository _challanRepository;
        private readonly IChallanTallyXMLGenerator _challanTallyXMLGenerator;

        public ChallanService(IChallanRepository challanRepository, IChallanTallyXMLGenerator challanTallyXMLGenerator)
        {
            _challanRepository = challanRepository;
            _challanTallyXMLGenerator = challanTallyXMLGenerator;
        }

        public async Task<string> GenerateTallyXMLAsync(string challanNo)
        {
            var challan = _challanRepository.GetChallanById(challanNo);
            if (challan == null)
            {
                throw new ArgumentException($"No challan found with ID {challanNo}");
            }
            return _challanTallyXMLGenerator.Generate(challan);
        }
    }

    /// POCO Classes as suggested by Copilot

    public class Challan
    {
        public string Id { get; set; }          // e.g. challanNo
        public DateTime Date { get; set; }      // <DATE>
        public string VoucherType { get; set; } // Delivery Note
        public string PartyLedgerName { get; set; }
        public string Narration { get; set; }
        public string ShippedBy { get; set; }
        public List<InventoryEntry> Items { get; set; } = new List<InventoryEntry>();
    }

    public class InventoryEntry
    {
        public string StockItemName { get; set; }
        public bool IsDeemedPositive { get; set; }
        public int ActualQty { get; set; }
        public int BilledQty { get; set; }
        public BatchAllocation Batch { get; set; }
        public AccountingAllocation Accounting { get; set; }
    }

    public class BatchAllocation
    {
        public string GodownName { get; set; }
        public string DestinationGodownName { get; set; }
        public string TrackingNumber { get; set; }
        public int ActualQty { get; set; }
        public int BilledQty { get; set; }
    }

    public class AccountingAllocation
    {
        public string LedgerName { get; set; }
        public decimal Amount { get; set; }
    }

}
