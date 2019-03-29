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

        public JsonResult GetData([DataSourceRequest] DataSourceRequest request, string link)
        {
            //get data from db by link and return DataSet back
            DataTable dt = new DataTable("Data");

            DataColumn CityNameCol = new DataColumn("CityName");
            DataColumn CityDescriptionCol = new DataColumn("CityDescription");

            dt.Columns.Add(CityNameCol);
            dt.Columns.Add(CityDescriptionCol);

            var cities = City.GetCities();

            foreach (var city in cities)
            {
                dt.Rows.Add(new object[] { city.CityName, city.CityDescription });
            }

            var res = dt.ToDataSourceResult(request);

            return Json(res);
        }

        private static List<TestClass> testClasses = TestClass.GetTestClasses();

        public JsonResult GetGridData([DataSourceRequest] DataSourceRequest request, string link)
        {
            //get data from db by link and return DataSet back

            ConnectDB();

            List<ProcedureParameter> paramList = new List<ProcedureParameter>();
            paramList.Add(new ProcedureParameter("KEY_NAME",link,"VARCHAR","IN"));
            paramList.Add(new ProcedureParameter("MATCHLIST_SELECT", "", "VARCHAR", "OUT"));
            paramList.Add(new ProcedureParameter("MATCHLIST_TOTAL", "", "VARCHAR", "OUT"));
            paramList.Add(new ProcedureParameter("MATCHLIST_PREFFIX", "", "VARCHAR", "OUT"));
            Dictionary<string, string> dic = _db.ProcCallOutParam("GET_MATCHLIST_INFO", paramList);
            int total_table_records = _db.Execute2Int( dic["MATCHLIST_TOTAL"] );
            int start = 0, end = 0;
            if (request.Page == 1) { start = start + 1; end = request.PageSize; }
            if (request.Page == 2) { start = request.PageSize + 1; end = request.PageSize * 2; }
            if(request.Page != 1 && request.Page !=2 )
            { start = request.PageSize * request.Page + 1; end = (request.Page * request.PageSize) + request.PageSize; }

            string sql_select = KendoSQLBuilder.BuildFilterableAndSortableSQLQuery( request,
                dic["MATCHLIST_SELECT"], dic["MATCHLIST_PREFFIX"] ).Replace("##start##", start.ToString())
                .Replace("##end##", end.ToString());
            
            var ds = _db.Execute2DataSet(sql_select, "Data" );
            var dt = ds.Tables["Data"];

            DataSourceResult res = new DataSourceResult();

            DataSourceRequest serializeDataTable = new DataSourceRequest(); //for serialize data table

            serializeDataTable.Aggregates = null;
            serializeDataTable.Filters = null;
            serializeDataTable.Groups = null;
            serializeDataTable.Sorts = null;
            serializeDataTable.Page = 1;
            serializeDataTable.PageSize = request.PageSize;

            res.Data = dt.ToDataSourceResult(serializeDataTable).Data;

            res.AggregateResults = null;
            res.Errors = null;
            res.Total = total_table_records; 

            return Json(res);
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