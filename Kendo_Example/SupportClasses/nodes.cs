using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kendo_Example.SupportClasses
{
    public class Font
    {
        public string multi { get; set; }
        public string size { get; set; }
        public string align { get; set; }
    }

    public class Attributes
    {
        public string id { get; set; }
        public string type { get; set; }
    }

    public class Node
    {
        public Font font { get; set; }
        public Attributes attributes { get; set; }
        public string id { get; set; }
        public string size { get; set; }
        public string title { get; set; }
        public string label { get; set; }
        public string color { get; set; }
        public string shape { get; set; }
    }
    
    public class Nodes
    {
        public List<Node> nodes { get; set; }
    }
}