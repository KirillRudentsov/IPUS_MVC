using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kendo_Example.SQL_Helper
{
    public class SQL_Grid_Query
    {
        public string SQL_Select;
        public string SQL_Total;

        public SQL_Grid_Query(string ss, string st)
        {
            SQL_Select = ss;
            SQL_Total = st;
        }
    }
}