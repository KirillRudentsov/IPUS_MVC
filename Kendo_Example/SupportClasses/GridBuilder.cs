using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Kendo_Example.SupportClasses
{
    public class GridBuilder
    {
        public static DataTable setGridPaging(string tableName, int? page, int? total, int totalRecords)
        {
            DataTable dt = new DataTable(tableName);
            dt.Columns.Add(new DataColumn("page", typeof(int)));
            dt.Columns.Add(new DataColumn("total", typeof(int)));
            dt.Columns.Add(new DataColumn("records", typeof(int)));

            DataRow dr = dt.NewRow();
            dr["page"] = page;
            dr["total"] = total;
            dr["records"] = totalRecords;
            dt.Rows.Add(dr);

            return dt;
        }


    }
}