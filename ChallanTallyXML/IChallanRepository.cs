namespace GoldenCoinChallan
{
    public interface IChallanRepository
    {
        Challan GetChallanById(string challanNo);
    }
}
