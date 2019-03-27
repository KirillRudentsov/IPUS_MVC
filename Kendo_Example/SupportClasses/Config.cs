using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kendo_Example.SupportClasses
{
    public static class Config
    {
        public static string MatchlistRequest
        {
            get {
                return System.Configuration.ConfigurationManager.AppSettings["MatchlistReq"];
            }
        }

        public static string sDbType
        {
            get {
                return System.Configuration.ConfigurationManager.AppSettings["DBType"];
            }
        }

        public static string sConnSTR
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["sConnSTR"];
            }
        }

        public static string sLoginSTR {
            get {
               return System.Configuration.ConfigurationManager.AppSettings["sLoginSTR"];
            }
        }

        public static string sPasswordSTR {
            get {
                return System.Configuration.ConfigurationManager.AppSettings["sPasswordSTR"];
            }
        }

    }
}