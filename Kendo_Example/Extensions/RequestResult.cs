using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Kendo_Example.Extensions
{
    public static class DataSourceResultWrapper
    {
        public static IEnumerable<Dictionary<string, object>> ToDictionary(this DataTable table)
        {
            string[] columns = table.Columns.Cast<DataColumn>().Select(c => c.ColumnName).ToArray();
            IEnumerable<Dictionary<string, object>> result = table.Rows.Cast<DataRow>()
                    .Select(dr => columns.ToDictionary(c => c, c => dr[c]));
            return result;
        }
    }


}