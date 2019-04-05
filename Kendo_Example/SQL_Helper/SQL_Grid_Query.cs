using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SqlKata;
using SqlKata.Compilers;
using MainServer;

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

    public static class CompilerQueryHelper
    {
        public static string GetCompilerResult(eType dbType, Query q)
        {
            return (dbType == eType.Oracle) ? new OracleCompiler().Compile(q).ToString() : new SqlServerCompiler().Compile(q).ToString();
        }
    }
}