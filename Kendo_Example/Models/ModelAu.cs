using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Kendo_Example.Models
{
    public class ModelAu
    {
    }

    [XmlRoot(ElementName = "DataSource")]
    public class DataSource
    {
        [XmlAttribute(AttributeName = "action")]
        public string Action { get; set; }
        [XmlAttribute(AttributeName = "controller_name")]
        public string Controller_name { get; set; }
        [XmlAttribute(AttributeName = "db_key_link")]
        public string Db_Key_Link { get; set; }
    }

    [XmlRoot(ElementName = "AutoComplete")]
    public class AutoComplete
    {
        [XmlElement(ElementName = "DataSource")]
        public DataSource DataSource { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "data_text_field")]
        public string Data_text_field { get; set; }
    }
}