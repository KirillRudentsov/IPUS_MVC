﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kendo_Example.Models;

namespace Kendo_Example.SupportClasses
{
    public static class CustomTypeWrapper
    {
        public static Type getType(Edittype edittype)
        {
            if (edittype == Edittype.Boolean)
                return typeof(bool);
            if (edittype == Edittype.Date)
                return typeof(DateTime);
            if (edittype == Edittype.Integer)
                return typeof(Int32);
            if (edittype == Edittype.String)
                return typeof(string);

            return typeof(string);
        }
    }
}