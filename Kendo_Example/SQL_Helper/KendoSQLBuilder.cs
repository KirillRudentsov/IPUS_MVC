using System;
using System.Collections.Generic;
using Kendo.Mvc.UI;
using MainServer;
using Kendo.Mvc;
using SqlKata.Compilers;
using SqlKata;
using Kendo.Mvc.Infrastructure.Implementation;

namespace Kendo_Example.SQL_Helper
{
    public class KendoSQLBuilder
    {
        public static SQL_Grid_Query BuildSQLQuery(DataSourceRequest request, string view_name, eType dbType)
        {
            if (view_name == null)
                throw new ArgumentNullException();

            Compiler SQLCompiler;

            if (dbType == eType.Oracle)
                SQLCompiler = new OracleCompiler();
            else
                SQLCompiler = new SqlServerCompiler();

            // build select
            Query QselectBody = new Query().From(view_name);

            ApplyFilters(request.Filters, ref QselectBody);

            // build select with sorting
            ApplySorting(request.Sorts, ref QselectBody);


            //ApplyGrouping(request.Groups, ref QselectBody);

            // build select with paging
            QselectBody.ForPage(request.Page, request.PageSize);


            //in the end compile full SQLQuery result
            SqlResult SQLQuery_Result = SQLCompiler.Compile( QselectBody );

            SqlResult totalQuery_Result = SQLCompiler.Compile( QselectBody.Clone().AsCount() );

            return new SQL_Grid_Query(SQLQuery_Result.ToString(), totalQuery_Result.ToString());
        }

        public static void ApplyFilters(IList<IFilterDescriptor> fds, ref Query query)
        {
            if (fds.Count == 0)
                return;

            FilterDescriptorCollection fd = new FilterDescriptorCollection();
            FilterCompositionLogicalOperator filterComposition = FilterCompositionLogicalOperator.Or;

            if (fds[0] is FilterDescriptor) {
                fd.Add(fds[0] as FilterDescriptor);
                filterComposition = FilterCompositionLogicalOperator.And;
            }
            if (fds[0] is CompositeFilterDescriptor) {
                fd = ((fds[0] as IFilterDescriptor) as CompositeFilterDescriptor).FilterDescriptors;
                filterComposition = ((fds[0] as IFilterDescriptor) as CompositeFilterDescriptor).LogicalOperator;
            }

            //apply filters
            foreach (FilterDescriptor f in fd)
            {
                Type memberType = f.Value.GetType();
                bool isDate = false;
                string db_dateFormat = "dd.MM.yyyy HH24:mi:ss";
                string csharp_dateFormat = "{0:dd.MM.yyyy HH:mm:ss}";
                if (memberType == typeof(DateTime))
                    isDate = true;
                
                switch (f.Operator)
                {
                    case FilterOperator.IsLessThan:
                        if (filterComposition == FilterCompositionLogicalOperator.And) {
                            if (isDate)
                                query.WhereDate(f.Member, "<", string.Format(csharp_dateFormat, f.Value), db_dateFormat);
                            else
                                query.Where(f.Member, "<", f.Value);
                        }
                        else {
                            if (isDate)
                                query.OrWhereDate(f.Member, "<", string.Format(csharp_dateFormat, f.Value), db_dateFormat);
                            else
                                query.OrWhere(f.Member, "<", f.Value);
                        }
                        break;
                    case FilterOperator.IsLessThanOrEqualTo:
                        if (filterComposition == FilterCompositionLogicalOperator.And) {
                            if (isDate)
                                query.WhereDate(f.Member, "<=", string.Format(csharp_dateFormat, f.Value), db_dateFormat);
                            else
                                query.Where(f.Member, "<=", f.Value);
                        }
                        else {
                            if (isDate)
                                query.OrWhereDate(f.Member, "<=", string.Format(csharp_dateFormat, f.Value), db_dateFormat);
                            else
                                query.OrWhere(f.Member, "<=", f.Value);
                        }
                        break;
                    case FilterOperator.IsEqualTo:
                        if (filterComposition == FilterCompositionLogicalOperator.And) {
                            if (isDate)
                                query.WhereDate(f.Member, "=", string.Format(csharp_dateFormat, f.Value), db_dateFormat);
                            else
                                query.Where(f.Member, "=", f.Value);
                        }
                        else {
                            if (isDate)
                                query.OrWhereDate(f.Member, "=", string.Format(csharp_dateFormat, f.Value), db_dateFormat);
                            else
                                query.OrWhere(f.Member, "=", f.Value);
                        }
                        break;
                    case FilterOperator.IsNotEqualTo:
                        if (filterComposition == FilterCompositionLogicalOperator.And) {
                            if (isDate)
                                query.WhereDate(f.Member, "!=", string.Format(csharp_dateFormat, f.Value), db_dateFormat);
                            else
                                query.Where(f.Member, "!=", f.Value);
                        }
                        else {
                            if (isDate)
                                query.OrWhereDate(f.Member, "!=", string.Format(csharp_dateFormat, f.Value), db_dateFormat);
                            else
                                query.OrWhere(f.Member, "!=", f.Value);
                        }
                        break;
                    case FilterOperator.IsGreaterThanOrEqualTo:
                        if (filterComposition == FilterCompositionLogicalOperator.And) {
                            if (isDate)
                                query.WhereDate(f.Member, ">=", string.Format(csharp_dateFormat, f.Value), db_dateFormat);
                            else
                                query.Where(f.Member, ">=", f.Value);
                        }
                        else {
                            if (isDate)
                                query.OrWhereDate(f.Member, ">=", string.Format(csharp_dateFormat, f.Value), db_dateFormat);
                            else
                                query.OrWhere(f.Member, ">=", f.Value);
                        }
                        break;
                    case FilterOperator.IsGreaterThan:
                        if (filterComposition == FilterCompositionLogicalOperator.And) {
                            if (isDate)
                                query.WhereDate(f.Member, ">", string.Format(csharp_dateFormat, f.Value), db_dateFormat);
                            else
                                query.Where(f.Member, ">", f.Value);
                        }
                        else {
                            if (isDate)
                                query.OrWhereDate(f.Member, ">", string.Format(csharp_dateFormat, f.Value), db_dateFormat);
                            else
                                query.OrWhere(f.Member, ">", f.Value);
                        }
                        break;
                    case FilterOperator.StartsWith:
                        if (filterComposition == FilterCompositionLogicalOperator.And)
                            query.WhereStarts(f.Member, f.Value.ToString());
                        else
                            query.OrWhereStarts(f.Member, f.Value.ToString());
                        break;
                    case FilterOperator.EndsWith:
                        if (filterComposition == FilterCompositionLogicalOperator.And)
                            query.WhereEnds(f.Member, f.Value.ToString());
                        else
                            query.OrWhereEnds(f.Member, f.Value.ToString());
                        break;
                    case FilterOperator.Contains:
                        if (filterComposition == FilterCompositionLogicalOperator.And)
                            query.WhereContains(f.Member, f.Value.ToString());
                        else
                            query.WhereContains(f.Member, f.Value.ToString());
                        break;
                    case FilterOperator.IsContainedIn:
                        if (filterComposition == FilterCompositionLogicalOperator.And)
                            query.WhereIn(f.Member, f.Value.ToString());
                        else
                            query.OrWhereIn(f.Member, f.Value.ToString());
                        break;
                    case FilterOperator.DoesNotContain:
                        if (filterComposition == FilterCompositionLogicalOperator.And)
                            query.WhereNotContains(f.Member, f.Value.ToString());
                        else
                            query.OrWhereNotContains(f.Member, f.Value.ToString());
                        break;
                    case FilterOperator.IsNull:
                        if (filterComposition == FilterCompositionLogicalOperator.And)
                            query.WhereNull(f.Member);
                        else
                            query.OrWhereNull(f.Member);
                        break;
                    case FilterOperator.IsNotNull:
                        if (filterComposition == FilterCompositionLogicalOperator.And)
                            query.WhereNotNull(f.Member);
                        else
                            query.OrWhereNotNull(f.Member);
                        break;
                    case FilterOperator.IsEmpty:
                        if (filterComposition == FilterCompositionLogicalOperator.And)
                            query.Where(f.Member, "=", "");
                        else
                            query.OrWhere(f.Member, "=", "");
                        break;
                    case FilterOperator.IsNotEmpty:
                        if (filterComposition == FilterCompositionLogicalOperator.And)
                            query.Where(f.Member, "!=", "");
                        else
                            query.OrWhere(f.Member, "!=", "");
                        break;
                }
            }

        }

        public static void ApplySorting(IList<SortDescriptor> sd,ref Query sqlRes)
        {
            if (sd.Count != 0) {
                if (sd[0].SortDirection == System.ComponentModel.ListSortDirection.Ascending)
                    sqlRes.OrderBy(sd[0].Member);
                else
                    sqlRes.OrderByDesc(sd[0].Member);
            }
            else
                sqlRes.OrderBy("ID"); // by default
        }

        private static void ApplyGrouping(IList<GroupDescriptor> gd, ref Query query)
        {
            if (gd.Count == 0)
                return;

            // apply grouping

            foreach (var item in gd) {
                if (item.SortDirection == System.ComponentModel.ListSortDirection.Ascending)
                    query.Select(item.Member).GroupBy(item.Member).OrderBy(item.Member);
                else
                    query.Select(item.Member).GroupBy(item.Member).OrderByDesc(item.Member);
            }

        }

        private static Type GetType(object value)
        {
            switch (value.GetType().Name)
            {
                case "Double":
                    return typeof(double);
                case "Float":
                    return typeof(float);
                case "Int32":
                    return typeof(int);
                case "Int64":
                    return typeof(long);
                case "Boolean":
                    return typeof(bool);
                case "String":
                    return typeof(string);
                case "DateTime":
                    return typeof(DateTime);
            }

            return typeof(string);
        }
    }
}