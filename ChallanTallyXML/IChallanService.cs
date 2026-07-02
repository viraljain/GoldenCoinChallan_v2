using System.Threading.Tasks;

namespace GoldenCoinChallan
{
    public interface IChallanService
    {
        Task<string> GenerateTallyXMLAsync(string challanNo);
    }
}
