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

namespace Kendo_Example.Controllers
{
    public class AutoCompleteController : Controller
    {
        // GET: AutoComplete
        public ActionResult Index()
        {
            return View();
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

            DataTable dt = new DataTable("Data");

            DataColumn TestId = new DataColumn("TestId");
            DataColumn TestNameCol = new DataColumn("TestName");
            DataColumn TestDescriptionCol = new DataColumn("TestDescription");
            DataColumn TestDateCol = new DataColumn("TestDate");
            DataColumn TestBooleanCol = new DataColumn("TestBoolean");
            dt.Columns.Add(TestId);
            dt.Columns.Add(TestNameCol);
            dt.Columns.Add(TestDescriptionCol);
            dt.Columns.Add(TestDateCol);
            dt.Columns.Add(TestBooleanCol);
            //var testClasses = TestClass.GetTestClasses();
            foreach (var test in testClasses)
            {
                dt.Rows.Add(new object[] { test.TestId, test.TestName, test.TestDescription, test.TestDate, test.TestBoolean });
            }
            
            var res = dt.ToDataSourceResult(request);
            
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

            return Json(jsonGraphEdges);
        }
    }
}