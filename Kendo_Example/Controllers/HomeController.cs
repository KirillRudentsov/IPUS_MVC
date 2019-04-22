using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo_Example.Models;
using System.Data;
using MainServer;
using Kendo_Example.SupportClasses;
using Kendo_Example.SQL_Helper;
using SqlKata;
using MainServer.Extension;

namespace Kendo_Example.Controllers
{
    public class HomeController : Controller
    {
        DBAccess _db;

        public void ConnectDB()
        {
            if (_db == null)
            {
                var dbType = DBAccess.GetDbTypeByName(Config.sDbType);
                _db = new DBAccess(dbType);
                //_log.Debug("Db Type : " + _db.DbType.ToString());

                //_log.Debug("Matchlist Request : " + selectAction);

                string status = _db.Login2SQL(Config.sConnSTR, Config.sLoginSTR, Config.sPasswordSTR);
                if (status != "OK")
                {
                    throw new Exception("Couldn't connect to DB");
                }
            }
        }

        public ActionResult Index()
        {
            //ViewBag.Message = "Welcome to ASP.NET MVC!";

            Session.Abandon();
            Session.Clear();

            var c = new HttpCookie("hstr");
            c.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(c);


            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult DynamicGrid(GridUrlParam param)
        {
            if (Request.Cookies.Get("hstr") == null)
                return View("Index");

            return View("DynamicGrid", param);
        }

        [HttpPost]
        public ActionResult Login(string login, string password)
        {
            if (ModelState.IsValid)
            {

                ConnectDB();

                Query q = new Query().From("M_OPERATOR_V".ToUpper()).Where("LOGIN_NAME".ToUpper(), "=", login)
                    .Where("PASSWORD".ToUpper(), "=", password);

                string select = CompilerQueryHelper.GetCompilerResult(_db.DbType, q);

                var dt = _db.Execute2DataSet(select, "Data").Tables[0];

                if (dt.Rows.Count > 0)
                {
                    var ls_param = new List<ProcedureParameter>() {
                        new ProcedureParameter("sUserName", login, "VARCHAR", "IN")
                    };

                    _db.ProcCall("CreateFilialAccess", ls_param);
                    Session["user_role"] = dt.Rows[0]["USER_ROLE_XML".ToUpper()].ToString();
                    Session["db_conn"] = _db;
                    Session["user_name"] = login;
                    HttpCookie httpCookie = new HttpCookie("hstr", Guid.NewGuid().ToString());
                    httpCookie.Expires = DateTime.Now.AddMinutes(30);
                    Response.SetCookie(httpCookie);

                    return RedirectToAction("Default");
                }
            }
            return View("Error");
        }

        public ActionResult Default()
        {
            if (Request.Cookies["hstr"] == null)
            {
                Session.Abandon();

                return View("Index");
            }


            return View("Default");
        }

        public ActionResult DynamicGraph(GraphUrlParam param)
        {
            if (Request.Cookies.Get("hstr") == null)
                return View("Index");

            return View("DynamicGraph", param);
        }

    }
}
