using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenCoinChallan
{
    internal interface IChallanRepository
    {
        string GetChallanById(string challanNo);
    }
}
