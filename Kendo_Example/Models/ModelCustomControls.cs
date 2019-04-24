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
        [XmlAttribute(AttributeName = "procedure")]
        public string Procedure { get; set; }
        [XmlAttribute(AttributeName = "refresh")]
        public bool Refresh { get; set; }
        [XmlAttribute(AttributeName = "xml")]
        public string Xml { get; set; }
        [XmlAttribute(AttributeName = "question")]
        public bool Question { get; set; }
        [XmlAttribute(AttributeName = "question_text")]
        public string Question_text { get; set; }
        [XmlAttribute(AttributeName = "process_text")]
        public string Process_text { get; set; }

        [XmlElement(ElementName = "DataSource")]
        public DataSource DataSource { get; set; }
    }

    [XmlRoot(ElementName = "CustomControls")]
    public class CustomControls
    {
        [XmlElement(ElementName = "control")]
        public List<Control> Control { get; set; }
    }
}