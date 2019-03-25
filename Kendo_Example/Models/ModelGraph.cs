using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Kendo_Example.Models
{
    public class ModelGraph
    {
    }

    [XmlRoot(ElementName = "Graph")]
    public class Graph
    {
        [XmlElement(ElementName = "DataSource")]
        public DataSource DataSource { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
    }
}