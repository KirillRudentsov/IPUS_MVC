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
                dt.Rows.Add( new object[] { city.CityName, city.CityDescription } );
            }

            var res = dt.ToDataSourceResult(request);

            return Json(res);
        }
    }
}