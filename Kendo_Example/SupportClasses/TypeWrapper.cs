using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kendo_Example.Models;

namespace Kendo_Example.SupportClasses
{
    public static class TypeWrapper
    {
        public static Type GetGridColumnType(Edittype edittype)
        {
            if (edittype == Edittype.Boolean)
                return typeof(bool);
            if (edittype == Edittype.Date)
                return typeof(DateTime);
            if (edittype == Edittype.Integer)
                return typeof(int);
            if (edittype == Edittype.String)
                return typeof(string);

            return typeof(string); // by default
        }

    }
}