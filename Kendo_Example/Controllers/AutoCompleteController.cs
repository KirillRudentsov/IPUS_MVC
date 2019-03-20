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
            DataTable dt = new DataTable("Table");

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
            dt.Columns.Add(TestId);
            dt.Columns.Add(TestNameCol);
            dt.Columns.Add(TestDescriptionCol);
            //var testClasses = TestClass.GetTestClasses();
            foreach (var test in testClasses)
            {
                dt.Rows.Add(new object[] { test.TestId, test.TestName, test.TestDescription });
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
            testClasses.Add(new TestClass(++maxId, param["TestName"], param["TestDescription"]));

            return Json("OK");
        }
    }
}