using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;
using Kendo_Example.Models;
using System.Data;
using Kendo_Example.SupportClasses;
using System.Web.Script.Serialization;

namespace Kendo_Example.Controllers
{
    public class PartialComponentsController : Controller
    {
        // GET: Component
        public PartialViewResult LoadMenuComponent(/*string filename*/)
        {
            Menu menu = new Menu();

            var fileContents = Session["user_role"].ToString(); // System.IO.File.ReadAllText(Server.MapPath(@"~/XmlFiles/" + filename));
            XmlSerializer xmlSerizlizer = new XmlSerializer(typeof(Menu));
            menu = (Menu)xmlSerizlizer.Deserialize(new StringReader(fileContents));

            return PartialView("Menu",menu);
        }
        
        public PartialViewResult LoadAuComponent(string filename)
        {
            AutoComplete au = new Models.AutoComplete();

            var fileContents = System.IO.File.ReadAllText(Server.MapPath(@"~/XmlFiles/" + filename));
            XmlSerializer xmlSerizlizer = new XmlSerializer(typeof(AutoComplete));
            au = (AutoComplete)xmlSerizlizer.Deserialize(new StringReader(fileContents));

            return PartialView("AutoComplete", au);
        }

        public PartialViewResult LoadGridComponent(GridUrlParam param)
        {
            Grid grid = new Grid();

            if (param.field_name != null && param.field_value != null) {
                ViewData["field_name"] = param.field_name;
                ViewData["field_value"] = param.field_value;
            }
            
            var fileContents = System.IO.File.ReadAllText(Server.MapPath(@"~/XmlFiles/" + param.filename));
            XmlSerializer xmlSerizlizer = new XmlSerializer(typeof(Grid));
            grid = (Grid)xmlSerizlizer.Deserialize(new StringReader(fileContents));

            return PartialView("Grid", grid);
        }

        public PartialViewResult LoadDateTimePickerComponent(string filename)
        {
            DateTimePicker dateTimePicker = new DateTimePicker();

            var fileContents = System.IO.File.ReadAllText(Server.MapPath(@"~/XmlFiles/CustomComponents/Date/" + filename));
            XmlSerializer xmlSerizlizer = new XmlSerializer(typeof(DateTimePicker));
            dateTimePicker = (DateTimePicker)xmlSerizlizer.Deserialize(new StringReader(fileContents));

            return PartialView("DateTimePicker", dateTimePicker);
        }

        public PartialViewResult LoadGraphComponent(string link)
        {
            return PartialView("Graph", link);
        }
    }
}