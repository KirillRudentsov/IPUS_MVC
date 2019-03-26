﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kendo_Example.SupportClasses
{
    public class Smooth
    {
        public string type { get; set; }
    }

    public class Edge
    {
        public string from { get; set; }
        public string to { get; set; }
        public string title { get; set; }
        public string arrows { get; set; }
        public bool physics { get; set; }
        public string label { get; set; }
        public Smooth smooth { get; set; }
    }
    
    public class Edges
    {
        public List<Edge> edges { get; set; }
    }
}