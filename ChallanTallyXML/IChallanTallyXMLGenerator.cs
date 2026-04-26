using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenCoinChallan
{
    public interface IChallanTallyXMLGenerator
    {
        string Generate(Challan challan);  
    }
}
