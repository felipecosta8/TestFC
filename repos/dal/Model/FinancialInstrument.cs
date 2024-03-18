using dal.Interface;
using dal.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dal.Model
{
    public class FinancialInstrument: IFinancialInstrument
    {
        public int idFinancialInstrument { get; set; }
        public double vlMarketValue { get;  set; }
        public string strName { get; set; }
        public int intType { get; set; }
        public String strType { get { return getType(); } }
        public string strCategory { get { return getCategory(); } } 
        public DateTime dtInsert { get; set; }
        public DateTime dtUpdate { get; set; }

        public String getCategory()
        {
            CategoryDAL dtDal = new CategoryDAL();
           return dtDal.FindbyMarketValue(vlMarketValue);
        }
        public String getType()
        {
            return (String)Enum.GetName(typeof(strType), intType);
        }
    }
    public enum strType:Int32
    {
        Stok = 1,
        Bond = 2,
        Derivative = 3,
        Other = 4
    }
}
