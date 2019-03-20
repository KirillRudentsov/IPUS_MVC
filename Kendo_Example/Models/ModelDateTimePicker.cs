using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Kendo_Example.Models
{
    public class ModelDateTimePicker
    {
    }

    [XmlRoot(ElementName = "DateTimePicker")]
    public class DateTimePicker
    {
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "format")]
        public string Format { get; set; }
    }
}