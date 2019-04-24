using Kendo_Example.SupportClasses;
using MainServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading;
using MainServer.Extension;
using System.Net;

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
            try
            {
                ConnectDB();

                List<ProcedureParameter> ls_proc_params = new List<ProcedureParameter>() {
                    new ProcedureParameter("sUser",Session["user_name"].ToString(), "VARCHAR", "IN")
                };

                _db.ProcCall("recalc_switch", ls_proc_params);

            }
            catch (Exception ex) { Response.StatusCode = 500; return ex.Message; }

            return "OK";
        }
    }
}