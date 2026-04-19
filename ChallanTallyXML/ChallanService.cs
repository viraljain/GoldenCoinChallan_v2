using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenCoinChallan
{
    internal class ChallanService: IChallanService
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
}
