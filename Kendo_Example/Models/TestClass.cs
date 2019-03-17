using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kendo_Example.Models
{
    public class TestClass
    {
        public string TestName;
        public string TestDescription;

        public TestClass(string tn, string td)
        {
            TestName = tn;
            TestDescription = td;
        }

        public static List<TestClass> GetTestClasses()
        {
            List<TestClass> testClasses = new List<TestClass>();
            testClasses.Add(new TestClass("Kirill", "Kirill descripstion"));
            testClasses.Add(new TestClass("Ivan", "Ivan descripstion"));
            testClasses.Add(new TestClass("Kirov", "Kirov descripstion"));
            testClasses.Add(new TestClass("Ibragim", "Ibragim descripstion"));
            testClasses.Add(new TestClass("Konstantin", "Konstantin descripstion"));
            testClasses.Add(new TestClass("Irina", "Irina descripstion"));

            return testClasses;
        }
    }

    public class City
    {
        public string CityName;
        public string CityDescription;

        public City(string cn, string cd)
        {
            CityName = cn;
            CityDescription = cd;
        }
        
        public static List<City> GetCities()
        {
            List<City> cityClasses = new List<City>();
            cityClasses.Add(new City("London", "London descripstion"));
            cityClasses.Add(new City("Liverpool", "Liverpool descripstion"));
            cityClasses.Add(new City("Lipetsk", "Lipetsk descripstion"));
            cityClasses.Add(new City("Moskow", "Moskow descripstion"));
            cityClasses.Add(new City("Bryanks", "Bryanks descripstion"));
            cityClasses.Add(new City("Kirow", "Kirow descripstion"));

            return cityClasses;
        }
    }
}