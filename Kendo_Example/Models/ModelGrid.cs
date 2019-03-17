﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Kendo_Example.Models
{
    public class ModelGrid
    {
    }

    [XmlRoot(ElementName = "Export_Excel")]
    public class Export_Excel
    {
        [XmlAttribute(AttributeName = "file_name")]
        public string File_name { get; set; }
        [XmlAttribute(AttributeName = "caption")]
        public string Caption { get; set; }
        [XmlElement(ElementName = "DataSource")]
        public DataSource DataSource { get; set; }
    }

    [XmlRoot(ElementName = "Export_Pdf")]
    public class Export_Pdf
    {
        [XmlAttribute(AttributeName = "file_name")]
        public string File_name { get; set; }
        [XmlAttribute(AttributeName = "caption")]
        public string Caption { get; set; }
        [XmlElement(ElementName = "DataSource")]
        public DataSource DataSource { get; set; }
    }

    [XmlRoot(ElementName = "column")]
    public class Column
    {
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "label")]
        public string Label { get; set; }
        [XmlAttribute(AttributeName = "width")]
        public string Width { get; set; }
    }

    [XmlRoot(ElementName = "COLUMNS")]
    public class COLUMNS
    {
        [XmlElement(ElementName = "column")]
        public List<Column> Column { get; set; }
    }

    [XmlRoot(ElementName = "Grid")]
    public class Grid
    {
        [XmlElement(ElementName = "DataSource")]
        public DataSource DataSource { get; set; }
        [XmlElement(ElementName = "COLUMNS")]
        public COLUMNS COLUMNS { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "width")]
        public string Width { get; set; }
        [XmlAttribute(AttributeName = "height")]
        public string Height { get; set; }
        [XmlAttribute(AttributeName = "tableId")]
        public string TableId { get; set; }
        [XmlAttribute(AttributeName = "caption")]
        public string Caption { get; set; }
        [XmlAttribute(AttributeName = "selectCountRows")]
        public int SelectCountRows { get; set; }
        [XmlElement(ElementName = "Export_Pdf")]
        public Export_Pdf Export_Pdf { get; set; }
        [XmlElement(ElementName = "Export_Excel")]
        public Export_Excel Export_Excel { get; set; }
    }
}