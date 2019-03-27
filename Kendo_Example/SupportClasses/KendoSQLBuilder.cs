using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using MainServer;
using System.Text;

namespace Kendo_Example.SupportClasses
{
    public class KendoSQLBuilder
    {
        public static string BuildFilterableAndSortableSQLQuery(string select_sql, DataSourceRequest request, eType dbType)
        {
            // build sql query by dbtype (oracle, mssql)
            StringBuilder full_sql_req = new StringBuilder();
            



            return "";
        }
    }
}