using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;
using Kendo.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Kendo_Example.Models;
using Kendo_Example.SupportClasses;
using MainServer;
using MainServer.Extension;
using Kendo_Example.SQL_Helper;
using Newtonsoft.Json;
using Kendo_Example.Extensions;
using System.Data.SQLite;
using SqlKata.Compilers;
using SqlKata;

namespace Kendo_Example.Controllers
{
    public class ComponentDataController : Controller
    {
        // GET: AutoComplete
        public ActionResult Index()
        {
            return View();
        }

        DBAccess _db;
        private string SQL_Matchlist_query;

        public void ConnectDB()
        {
            SQL_Matchlist_query = Config.MatchlistRequest;

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

        public JsonResult GetAuData([DataSourceRequest] DataSourceRequest request, string link)
        {
            //get data from db by link and return DataSet back
            DataSourceResult res = new DataSourceResult();
            IDbConnection DBConnection = new SQLiteConnection(@"Data Source=F:\DB\DataBase;Version=3;");
            DBConnection.Open();

            Query q = new Query().From(link);

            KendoSQLBuilder.ApplyFilters(request.Filters, ref q);

            var sql_select_command = new SQLiteCommand(new SqliteCompiler().Compile(q).ToString(), DBConnection as SQLiteConnection);

            DataTable dt = new DataTable("Data");

            dt.Load(sql_select_command.ExecuteReader());

            res.Errors = null;
            res.AggregateResults = null;
            res.Data = dt.ToDictionary();
            res.Total = dt.Rows.Count;

            return Json(res);
        }

        private static List<TestClass> testClasses = TestClass.GetTestClasses();

        public JsonResult GetGridData([DataSourceRequest] DataSourceRequest request, string link)
        {
            //get data from db by link and return DataSet back
            DataSourceResult res = new DataSourceResult();
            IDbConnection DBConnection = new SQLiteConnection(@"Data Source=F:\DB\DataBase;Version=3;");

            try
            {
                //ConnectDB();

                //SQL_Grid_Query sql_select = KendoSQLBuilder.BuildSQLQuery(request, link, _db.DbType);
                DBConnection.Open();

                SQL_Grid_Query sql_select = KendoSQLBuilder.BuildSQLQuery(request, link);

                //var sql_select = new SqliteCompiler().Compile(new SqlKata.Query().From(link));
                //var sql_total = new SqliteCompiler().Compile(new SqlKata.Query().From(link).Clone().AsCount());


                var sql_select_command = new SQLiteCommand(sql_select.SQL_Select.ToString(), DBConnection as SQLiteConnection);
                var sql_select_total = new SQLiteCommand(sql_select.SQL_Total.ToString(), DBConnection as SQLiteConnection);

                DataTable dt = new DataTable();
                //var total = Convert.ToInt32( _db.Execute2Str(sql_total.ToString()) );
                //var ds = _db.Execute2DataSet(sql_select.ToString(), "Data");
                dt.Load(sql_select_command.ExecuteReader());

                res.Data = dt.ToDictionary();
                res.AggregateResults = null;
                res.Errors = null;
                res.Total = Convert.ToInt32( sql_select_total.ExecuteScalar().ToString() );
            } 
            catch (Exception ex) { res.Errors = ex.Message; }
            finally { DBConnection.Close(); }

            return new System.Web.Mvc.JsonResult()
            {
                MaxJsonLength = Int32.MaxValue,
                Data = res
            };
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult GridProcedure_Update([DataSourceRequest] DataSourceRequest request, string link)
        {
            // full example post body 

            // sort=&group=&filter=&TestId=560&TestName=Test1&TestDescription=Description1

            //merge post params with xml by link

            var param = Request.Form;

            //test local creating
            int maxId = testClasses.Max( el => el.TestId );
            testClasses.Add(new TestClass(++maxId, param["TestName"], param["TestDescription"],
               param["TestDate"], bool.Parse(param["TestBoolean"]) ));

            return Json("OK");
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult GridProcedure_Edite([DataSourceRequest] DataSourceRequest request, string link)
        {
            // full example post body 

            // sort=&group=&filter=&TestId=1&TestName=Kirill123&TestDescription=Kirill+descripstion123

            //merge post params with xml by link

            var param = Request.Form;

            //test local creating
            testClasses.Where(el => el.TestId == Convert.ToInt32(param["TestId"]))
                .Each(e => { e.TestDescription = param["TestDescription"];
                    e.TestName = param["TestName"]; e.TestDate = param["TestDate"] ;
                    e.TestBoolean = bool.Parse(param["TestBoolean"]); });

            return Json("OK");
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult GridProcedure_Delete([DataSourceRequest] DataSourceRequest request, string link)
        {
            // full example post body 

            // sort=&group=&filter=&TestId=1&TestName=Kirill123&TestDescription=Kirill+descripstion123

            //merge post params with xml by link

            var param = Request.Form;

            //test local creating
            testClasses.RemoveAll( el => el.TestId == Convert.ToInt32(param["TestId"]) );

            return Json("OK");
        }

        public JsonResult GetGraphNodes([DataSourceRequest] DataSourceRequest request, string link)
        {
            //get data from db by link and return DataSet back

            //string jsonGraphData = "[{\"week\": \"W1\",\"value\": 3000 },{\"week\": \"W2\",\"value\": 4000},{\"week\": \"W3\",\"value\": 2500}]";

            var jsonGraphNodes = System.IO.File.ReadAllText(Server.MapPath(@"~/App_Data/Nodes.json"));

            Nodes n = new Nodes();

            n = Newtonsoft.Json.JsonConvert.DeserializeObject<Nodes>(jsonGraphNodes);

            var res = n.nodes.ToDataSourceResult(request);

            return Json(res);
        }
        
        public JsonResult GetGraphEdges([DataSourceRequest] DataSourceRequest request, string link)
        {
            //get data from db by link and return DataSet back

            //string jsonGraphData = "[{\"week\": \"W1\",\"value\": 3000 },{\"week\": \"W2\",\"value\": 4000},{\"week\": \"W3\",\"value\": 2500}]";

            var jsonGraphEdges = System.IO.File.ReadAllText(Server.MapPath(@"~/App_Data/Edges.json"));

            Edges edge = new Edges();

            edge = Newtonsoft.Json.JsonConvert.DeserializeObject<Edges>(jsonGraphEdges);

            var res = edge.edges.ToDataSourceResult(request);

            return Json(res);
        }
    }
}