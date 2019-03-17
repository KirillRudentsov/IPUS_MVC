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

            testClasses.Add(new TestClass("Ura", "Ura descripstion"));
            testClasses.Add(new TestClass("Anton", "Anton descripstion"));
            testClasses.Add(new TestClass("Alyxey", "Alyxey descripstion"));
            testClasses.Add(new TestClass("Sergey", "Sergey descripstion"));
            testClasses.Add(new TestClass("Polyni", "Polyni descripstion"));
            testClasses.Add(new TestClass("Anastasia", "Anastasia descripstion"));

            testClasses.Add(new TestClass("Alina", "Alina descripstion"));
            testClasses.Add(new TestClass("Ylia", "Ylia descripstion"));
            testClasses.Add(new TestClass("Andrey", "Andrey descripstion"));
            testClasses.Add(new TestClass("Ser", "Ser descripstion"));
            testClasses.Add(new TestClass("Slava", "Slava descripstion"));
            testClasses.Add(new TestClass("Vlad", "Vlad descripstion"));


            testClasses.Add(new TestClass("Anatoliy", "Anatoliy descripstion"));
            testClasses.Add(new TestClass("Yula", "Yula descripstion"));
            testClasses.Add(new TestClass("Tan9", "Tan9 descripstion"));
            testClasses.Add(new TestClass("Nikita", "Nikita descripstion"));
            testClasses.Add(new TestClass("Vika", "Vika descripstion"));
            testClasses.Add(new TestClass("Olga", "Olga descripstion"));

            testClasses.Add(new TestClass("Nadya", "Nadya descripstion"));
            testClasses.Add(new TestClass("Oksana", "Oksana descripstion"));
            testClasses.Add(new TestClass("Oleg", "Oleg descripstion"));
            testClasses.Add(new TestClass("Sofa", "Sofa descripstion"));
            testClasses.Add(new TestClass("Kek", "Kek descripstion"));
            testClasses.Add(new TestClass("Rer", "Rer descripstion"));

            testClasses.Add(new TestClass("Lol", "Lol descripstion"));
            testClasses.Add(new TestClass("Cheburek", "Cheburek descripstion"));
            testClasses.Add(new TestClass("Galina", "Galina descripstion"));
            testClasses.Add(new TestClass("Elena", "Elena descripstion"));
            testClasses.Add(new TestClass("Sveta", "Sveta descripstion"));
            testClasses.Add(new TestClass("Anna", "Anna descripstion"));

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