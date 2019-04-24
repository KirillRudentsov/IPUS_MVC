using Kendo_Example.SupportClasses;
using MainServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading;

namespace Kendo_Example.Controllers
{
    public class ProcedureCallController : Controller
    {

        DBAccess _db;

        public void ConnectDB()
        {
            _db = (DBAccess)Session["db_conn"];
        }

        // GET: ProcedureCall
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public string CallRecalcProcedure(string procname)
        {
            Thread.Sleep(5000); // emulate load time

            return "OK";
        }
    }
}