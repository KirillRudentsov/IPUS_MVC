using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo_Example.Models;
using SqlKata;
using SqlKata.Compilers;

namespace Kendo_Example.Controllers
{
    public class HomeController : Controller
    {
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

                IDbConnection DBConnection = new SQLiteConnection(@"Data Source=F:\DB\DataBase;Version=3;");
                DBConnection.Open();

                var sql_select_command = new SQLiteCommand(new SqliteCompiler().Compile(new Query().From("v_user_role")
                    .Where("user_name", "=", login).Where("user_password", "=", password)).ToString(), DBConnection as SQLiteConnection);

                DataTable dt = new DataTable("Data");
                dt.Load(sql_select_command.ExecuteReader());

                if (dt.Rows.Count > 0)
                {
                    Session["user_role"] = dt.Rows[0]["user_role"].ToString();
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
