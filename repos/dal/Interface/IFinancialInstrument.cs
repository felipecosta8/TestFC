using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dal.Interface
{
    public interface IFinancialInstrument
    {
        double vlMarketValue { get; }
        string strCategory { get; }
        int intType { get; }
        String strType { get; }
    }
}
