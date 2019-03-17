using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Kendo_Example.Models
{
    public class ModelMenu
    {
    }

    [XmlRoot(ElementName = "thirdlevel")]
    public class Thirdlevel
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "url")]
        public string Url { get; set; }
    }

    [XmlRoot(ElementName = "secondlevel")]
    public class Secondlevel
    {
        [XmlElement(ElementName = "thirdlevel")]
        public List<Thirdlevel> Thirdlevel { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "url")]
        public string Url { get; set; }
    }

    [XmlRoot(ElementName = "firstlevel")]
    public class Firstlevel
    {
        [XmlElement(ElementName = "secondlevel")]
        public List<Secondlevel> Secondlevel { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "url")]
        public string Url { get; set; }
    }

    [XmlRoot(ElementName = "menu")]
    public class Menu
    {
        [XmlElement(ElementName = "firstlevel")]
        public List<Firstlevel> Firstlevel { get; set; }
    }
}