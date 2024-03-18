using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dal.Model
{
    public class Category
    {
        public int idCategory { get; set; }
        public string strName { get; set; }

        public double iniValue { get; set; }

        public double finValue { get; set; }
    }
}
