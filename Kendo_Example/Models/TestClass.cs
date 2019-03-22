using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Kendo_Example.Models
{
    public class TestClass
    {
        public int TestId;
        public string TestName;
        public string TestDescription;
        public string TestDate;
        public bool TestBoolean;

        public TestClass(int ti,string tn, string td, string tdt, bool tbool)
        {
            TestId = ti;
            TestName = tn;
            TestDescription = td;
            TestDate = tdt;
            TestBoolean = tbool;
        }

        public static List<TestClass> GetTestClasses()
        {
            //from db select will return date like this : Friday, March 15, 2019 12:00:00 AM
            List<TestClass> testClasses = new List<TestClass>();

            testClasses.Add(new TestClass(1, "Kirill", "Kirill descripstion", string.Format(CultureInfo.GetCultureInfo("en-US"), "{0:F}", DateTime.Now), false));
            testClasses.Add(new TestClass(2, "Ivan", "Ivan descripstion", string.Format(CultureInfo.GetCultureInfo("en-US"), "{0:F}", DateTime.Now), false));
            testClasses.Add(new TestClass(10, "Sergey", "Sergey descripstion", string.Format(CultureInfo.GetCultureInfo("en-US"), "{0:F}", DateTime.Now), false));
            testClasses.Add(new TestClass(11, "Polyni", "Polyni descripstion", string.Format(CultureInfo.GetCultureInfo("en-US"), "{0:F}", DateTime.Now), true));
            testClasses.Add(new TestClass(12, "Anastasia", "Anastasia descripstion", string.Format(CultureInfo.GetCultureInfo("en-US"), "{0:F}", DateTime.Now), false));

            testClasses.Add(new TestClass(13, "Alina", "Alina descripstion", string.Format(CultureInfo.GetCultureInfo("en-US"), "{0:F}", DateTime.Now), false));
            testClasses.Add(new TestClass(14, "Ylia", "Ylia descripstion", string.Format(CultureInfo.GetCultureInfo("en-US"), "{0:F}", DateTime.Now), false));
            testClasses.Add(new TestClass(15, "Andrey", "Andrey descripstion", string.Format(CultureInfo.GetCultureInfo("en-US"), "{0:F}", DateTime.Now), false));
            testClasses.Add(new TestClass(16, "Ser", "Ser descripstion", string.Format(CultureInfo.GetCultureInfo("en-US"), "{0:F}", DateTime.Now), false));
            testClasses.Add(new TestClass(17, "Slava", "Slava descripstion", string.Format(CultureInfo.GetCultureInfo("en-US"), "{0:F}", DateTime.Now), false));
            testClasses.Add(new TestClass(18, "Vlad", "Vlad descripstion", string.Format(CultureInfo.GetCultureInfo("en-US"), "{0:F}", DateTime.Now), false));


            testClasses.Add(new TestClass(19, "Anatoliy", "Anatoliy descripstion", string.Format(CultureInfo.GetCultureInfo("en-US"), "{0:F}", DateTime.Now), false));
            testClasses.Add(new TestClass(20, "Yula", "Yula descripstion", string.Format(CultureInfo.GetCultureInfo("en-US"), "{0:F}", DateTime.Now), false));
            testClasses.Add(new TestClass(21, "Tan9", "Tan9 descripstion", string.Format(CultureInfo.GetCultureInfo("en-US"), "{0:F}", DateTime.Now), false));
            testClasses.Add(new TestClass(22, "Nikita", "Nikita descripstion", string.Format(CultureInfo.GetCultureInfo("en-US"), "{0:F}", DateTime.Now), false));
            testClasses.Add(new TestClass(23, "Vika", "Vika descripstion", string.Format(CultureInfo.GetCultureInfo("en-US"), "{0:F}", DateTime.Now), false));
            testClasses.Add(new TestClass(24, "Olga", "Olga descripstion", string.Format(CultureInfo.GetCultureInfo("en-US"), "{0:F}", DateTime.Now), false));

            testClasses.Add(new TestClass(25, "Nadya", "Nadya descripstion", string.Format(CultureInfo.GetCultureInfo("en-US"), "{0:F}", DateTime.Now), false));
            testClasses.Add(new TestClass(26, "Oksana", "Oksana descripstion", string.Format(CultureInfo.GetCultureInfo("en-US"), "{0:F}", DateTime.Now), false));
            testClasses.Add(new TestClass(27, "Oleg", "Oleg descripstion", string.Format(CultureInfo.GetCultureInfo("en-US"), "{0:F}", DateTime.Now), false));
            testClasses.Add(new TestClass(28, "Sofa", "Sofa descripstion", string.Format(CultureInfo.GetCultureInfo("en-US"), "{0:F}", DateTime.Now), false));
            testClasses.Add(new TestClass(29, "Kek", "Kek descripstion", string.Format(CultureInfo.GetCultureInfo("en-US"), "{0:F}", DateTime.Now), false));
            testClasses.Add(new TestClass(30, "Rer", "Rer descripstion", string.Format(CultureInfo.GetCultureInfo("en-US"), "{0:F}", DateTime.Now), false));

            testClasses.Add(new TestClass(31, "Lol", "Lol descripstion", string.Format(CultureInfo.GetCultureInfo("en-US"), "{0:F}", DateTime.Now), false));
            testClasses.Add(new TestClass(32, "Cheburek", "Cheburek descripstion", string.Format(CultureInfo.GetCultureInfo("en-US"), "{0:F}", DateTime.Now), false));
            testClasses.Add(new TestClass(33, "Galina", "Galina descripstion", string.Format(CultureInfo.GetCultureInfo("en-US"), "{0:F}", DateTime.Now), false));
            testClasses.Add(new TestClass(34, "Elena", "Elena descripstion", string.Format(CultureInfo.GetCultureInfo("en-US"), "{0:F}", DateTime.Now), false));
            testClasses.Add(new TestClass(35, "Sveta", "Sveta descripstion", string.Format(CultureInfo.GetCultureInfo("en-US"), "{0:F}", DateTime.Now), false));
            testClasses.Add(new TestClass(36, "Anna", "Anna descripstion", string.Format(CultureInfo.GetCultureInfo("en-US"), "{0:F}", DateTime.Now), false));

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