using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenCoinChallan
{
    public interface IChallanRepository
    {
        Challan GetChallanById(string challanNo);
    }
}
