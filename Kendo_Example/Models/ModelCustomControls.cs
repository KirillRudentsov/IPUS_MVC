using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Kendo_Example.Models
{
    public class ModelCustomControls
    {
    }

    public enum ControlType
    {
        [XmlEnum(Name = "button")]
        button = 0,
        [XmlEnum(Name = "checkbox")]
        checkbox = 1,
        [XmlEnum(Name = "dropdownlist")]
        Date = 2
    }
    
    [XmlRoot(ElementName = "control")]
    public class Control
    {
        [XmlAttribute(AttributeName = "type")]
        public ControlType ControlType { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "imageClass")]
        public string ImageClass { get; set; }
        [XmlAttribute(AttributeName = "title")]
        public string Title { get; set; }
        
        [XmlElement(ElementName = "DataSource")]
        public DataSource DataSource { get; set; }

        [XmlElement(ElementName = "jsData")]
        public JsData JsData { get; set; }

    }

    [XmlRoot(ElementName = "jsData")]
    public class JsData
    {
        [XmlText]
        public string Text { get; set; }
    }


    [XmlRoot(ElementName = "CustomControls")]
    public class CustomControls
    {
        [XmlElement(ElementName = "control")]
        public List<Control> Control { get; set; }
    }
}