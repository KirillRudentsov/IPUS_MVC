using Kendo.Mvc.UI;
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

    public enum Edittype
    {
        [XmlEnum(Name = "Integer")]
        Integer = 0,
        [XmlEnum(Name = "String")]
        String = 1,
        [XmlEnum(Name = "Date")]
        Date = 2,
        [XmlEnum(Name = "Boolean")]
        Boolean = 3
    }

    [XmlRoot(ElementName = "Model")]
    public class Model
    {
        [XmlElement(ElementName = "default_value")]
        public string Default_value { get; set; }

        [XmlAttribute(AttributeName = "edittype")]
        public Edittype edittype { get; set; }

        [XmlAttribute(AttributeName = "format")]
        public string Format { get; set; }
        [XmlAttribute(AttributeName = "editable")]
        public bool editable { get; set; }

        [XmlAttribute(AttributeName = "link")]
        public string link { get; set; }
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

    public enum ColumnType
    {
        [XmlEnum(Name = "simple")]
        simple = 0,
        [XmlEnum(Name = "ProcessDesignerLink")]
        ProcessDesignerLink = 1,
        [XmlEnum(Name = "GridLink")]
        GridLink = 2
    }

    [XmlRoot(ElementName = "column")]
    public class Column
    {
        [XmlAttribute(AttributeName = "type")]
        public ColumnType Type { get; set; }
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

        [XmlAttribute(AttributeName = "to_type_link")]
        public string to_type_link { get; set; }

        [XmlElement(ElementName = "Aggregates")]
        public Aggregates Aggregates { get; set; }
    }

    public enum AggregateType
    {
        [XmlEnum(Name = "min")]
        min = 0,
        [XmlEnum(Name = "max")]
        max = 1,
        [XmlEnum(Name = "count")]
        count = 2,
        [XmlEnum(Name = "sum")]
        sum = 3,
        [XmlEnum(Name = "average")]
        average = 4
    }

    [XmlRoot(ElementName = "add")]
    public class Add
    {
        [XmlAttribute(AttributeName = "type")]
        public AggregateType AggregateType { get; set; }
    }

    [XmlRoot(ElementName = "Aggregates")]
    public class Aggregates
    {
        [XmlElement(ElementName = "add")]
        public List<Add> Add { get; set; }
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

        [XmlElement(ElementName = "ContextMenu")]
        public ContextMenu ContextMenu { get; set; }
    }

    [XmlRoot(ElementName = "item")]
    public class Item
    {
        [XmlElement(ElementName = "DataSource")]
        public DataSource DataSource { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public ContextMenuItemType ContextMenuItemType { get; set; }
        [XmlAttribute(AttributeName = "action")]
        public ColumnType Action { get; set; }
        [XmlAttribute(AttributeName = "title")]
        public string Title { get; set; }
    }

    public enum ContextMenuItemType
    {
        [XmlEnum(Name = "Separator")]
        Separator = 0,
        [XmlEnum(Name = "notSeparator")]
        notSeparator = 1
    }

    [XmlRoot(ElementName = "Items")]
    public class Items
    {
        [XmlElement(ElementName = "item")]
        public List<Item> Item { get; set; }
    }

    [XmlRoot(ElementName = "ContextMenu")]
    public class ContextMenu
    {
        [XmlElement(ElementName = "Items")]
        public Items Items { get; set; }
        [XmlAttribute(AttributeName = "ContextMenuOrientation")]
        public ContextMenuOrientation ContextMenuOrientation { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
    }
}