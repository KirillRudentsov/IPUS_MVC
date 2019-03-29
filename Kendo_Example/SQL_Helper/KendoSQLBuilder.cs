using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using MainServer;
using System.Text;
using Kendo.Mvc;

namespace Kendo_Example.SQL_Helper
{
    public class KendoSQLBuilder
    {
        public static string BuildFilterableAndSortableSQLQuery(DataSourceRequest request, string sql_select, string sql_preffix)
        {
            if (sql_select == null && sql_preffix == null)
                throw new ArgumentNullException();

            string filter = (ApplyFilters(request.Filters as IList<FilterDescriptor>, sql_preffix) );
            string sorting = (ApplySorting(request.Sorts, sql_preffix));
            string groups = (ApplyGrouping(request.Groups, sql_preffix));

            return sql_select.Replace("##filters##", filter).Replace("##sorting##", sorting)
                .Replace("##group##", groups);
        }

        private static string ApplyFilters(IList<FilterDescriptor> fds,string pref)
        {
            if (fds == null)
                return " ";

            StringBuilder filtered_sql_req = new StringBuilder();

            //apply filters
            foreach (var f in fds)
            {
                switch (f.Operator)
                {
                    case FilterOperator.IsLessThan:
                        filtered_sql_req.Append(" and " + pref + "." + f.Member + " < " + " '" + ParseSQLValue(f.Value) + "' "); break;
                    case FilterOperator.IsLessThanOrEqualTo:
                        filtered_sql_req.Append(" and " + pref + "." + f.Member + "" + " <= " + " '" + ParseSQLValue(f.Value) + "' "); break;
                    case FilterOperator.IsEqualTo:
                        filtered_sql_req.Append(" and " + pref + "." + f.Member + " = " + " '" + ParseSQLValue(f.Value) + "' "); break;
                    case FilterOperator.IsNotEqualTo:
                        filtered_sql_req.Append(" and " + pref + "." + f.Member + " <> " + " '" + ParseSQLValue(f.Value) + "' "); break;
                    case FilterOperator.IsGreaterThanOrEqualTo:
                        filtered_sql_req.Append(" and " + pref + "." + f.Member + " >= " + " '" + ParseSQLValue(f.Value) + "' "); break;
                    case FilterOperator.IsGreaterThan:
                        filtered_sql_req.Append(" and " + pref + "." + f.Member + " > " + " '" + ParseSQLValue(f.Value) + "' "); break;
                    case FilterOperator.StartsWith:
                        filtered_sql_req.Append(" and " + pref + "." + f.Member + " like '%" + ParseSQLValue(f.Value) + "' "); break;
                    case FilterOperator.EndsWith:
                        filtered_sql_req.Append(" and " + pref + "." + f.Member + " like " + ParseSQLValue(f.Value) + "' "); break;
                    case FilterOperator.Contains:
                        filtered_sql_req.Append( " and " + pref + "." + f.Member + " like '%" + ParseSQLValue(f.Value) + "%' "); break;
                    case FilterOperator.IsContainedIn:
                        throw new Exception("There is no translator for [" + f.Member + "]" + " " + f.Operator + " " + f.Value.ToString());
                    case FilterOperator.DoesNotContain:
                        filtered_sql_req.Append( " and " + pref + "." + f.Member + " not like '%" + ParseSQLValue(f.Value) + "' "); break;
                    case FilterOperator.IsNull:
                        filtered_sql_req.Append( " and " + pref + "." + f.Member + " IS NULL "); break;
                    case FilterOperator.IsNotNull:
                        filtered_sql_req.Append(  " and " + pref + "." + f.Member + " IS NOT NULL "); break;
                    case FilterOperator.IsEmpty:
                        filtered_sql_req.Append( " and " + pref + "." + f.Member + " = ''"); break;
                    case FilterOperator.IsNotEmpty:
                        filtered_sql_req.Append( " and " + pref + "." + f.Member + " <> ''"); break;
                }
            }
            return filtered_sql_req.ToString();
        }

        private static string ApplySorting(IList<SortDescriptor> sd, string preffix)
        {
            if (sd.Count == 0)
                return " ";

            StringBuilder sorted_sql_req = new StringBuilder();

            string sort = (sd[0].SortDirection == System.ComponentModel.ListSortDirection.Ascending) ? "Ask" : "Desc" ;

            // apply sorting
            sorted_sql_req.Append( " order by " + preffix + "." + sd[0].Member + " " + sort + " ");


            return sorted_sql_req.ToString();
        }

        private static string ApplyGrouping(IList<GroupDescriptor> gd, string preffix)
        {
            if (gd.Count == 0)
                return " ";

            StringBuilder grouped_sql_req = new StringBuilder();

            // apply grouping



            return "";
        }

        private static string ParseSQLValue(object value)
        {
            switch (value.GetType().Name)
            {
                case "Double":
                case "Float":
                case "Int32":
                case "Int64":
                case "Boolean":
                case "String":
                case "DateTime":
                    return value.ToString();
            }

            return "";
        }
    }
}