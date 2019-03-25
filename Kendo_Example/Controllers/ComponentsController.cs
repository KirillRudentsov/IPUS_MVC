﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;
using Kendo_Example.Models;
using System.Data;

namespace Kendo_Example.Controllers
{
    public class ComponentsController : Controller
    {
        // GET: Component
        public PartialViewResult LoadMenuComponent(string filename)
        {
            Menu menu = new Menu();

            var fileContents = System.IO.File.ReadAllText(Server.MapPath(@"~/XmlFiles/" + filename));
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

        public PartialViewResult LoadGridComponent(string filename)
        {
            Grid grid = new Models.Grid();

            var fileContents = System.IO.File.ReadAllText(Server.MapPath(@"~/XmlFiles/" + filename));
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

        public PartialViewResult LoadGraphComponent(string filename)
        {
            Graph g = new Graph();

            var fileContents = System.IO.File.ReadAllText(Server.MapPath(@"~/XmlFiles/" + filename));
            XmlSerializer xmlSerizlizer = new XmlSerializer(typeof(Graph));
            g = (Graph)xmlSerizlizer.Deserialize(new StringReader(fileContents));

            return PartialView("Graph", g);
        }
    }
}