using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Kendo_Example.Models
{
    public class ModelGrid
    {
    }

    [XmlRoot(ElementName = "Model")]
    public class Model
    {
        [XmlElement(ElementName = "default_value")]
        public string Default_value { get; set; }
        [XmlAttribute(AttributeName = "edittype")]
        public string Edittype { get; set; }
        [XmlAttribute(AttributeName = "format")]
        public string Format { get; set; }
        [XmlAttribute(AttributeName = "editable")]
        public bool editable { get; set; }
    }

    [XmlRoot(ElementName = "Update")]
    public class Update
    {
        [XmlElement(ElementName = "DataSource")]
        public DataSource DataSource { get; set; }
    }
    
    [XmlRoot(ElementName = "Delete")]
    public class Delete
    {
        [XmlElement(ElementName = "DataSource")]
        public DataSource DataSource { get; set; }
    }

    [XmlRoot(ElementName = "Edit")]
    public class Edit
    {
        [XmlElement(ElementName = "DataSource")]
        public DataSource DataSource { get; set; }
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
        public int Width { get; set; }
        [XmlAttribute(AttributeName = "hidden")]
        public bool hidden { get; set; }
        [XmlAttribute(AttributeName = "visible")]
        public bool visible { get; set; }
        [XmlElement(ElementName = "Model")]
        public Model Model { get; set; }
        [XmlAttribute(AttributeName = "key")]
        public bool key { get; set; }
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
        public int Height { get; set; }
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
        [XmlElement(ElementName = "Update")]
        public Update Update { get; set; }
        [XmlElement(ElementName = "Edit")]
        public Update Edit { get; set; }
        [XmlElement(ElementName = "Delete")]
        public Delete Delete { get; set; }
    }
}