using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kendo_Example.Models
{
    public class TestClass
    {
        public int TestId;
        public string TestName;
        public string TestDescription;

        public TestClass(int ti,string tn, string td)
        {
            TestId = ti;
            TestName = tn;
            TestDescription = td;
        }

        public static List<TestClass> GetTestClasses()
        {
            List<TestClass> testClasses = new List<TestClass>();
            testClasses.Add(new TestClass(1,"Kirill", "Kirill descripstion"));
            testClasses.Add(new TestClass(2,"Ivan", "Ivan descripstion"));
            testClasses.Add(new TestClass(3,"Kirov", "Kirov descripstion"));
            testClasses.Add(new TestClass(4,"Ibragim", "Ibragim descripstion"));
            testClasses.Add(new TestClass(5,"Konstantin", "Konstantin descripstion"));
            testClasses.Add(new TestClass(6,"Irina", "Irina descripstion"));

            testClasses.Add(new TestClass(7,"Ura", "Ura descripstion"));
            testClasses.Add(new TestClass(8,"Anton", "Anton descripstion"));
            testClasses.Add(new TestClass(9,"Alyxey", "Alyxey descripstion"));
            testClasses.Add(new TestClass(10,"Sergey", "Sergey descripstion"));
            testClasses.Add(new TestClass(11,"Polyni", "Polyni descripstion"));
            testClasses.Add(new TestClass(12,"Anastasia", "Anastasia descripstion"));

            testClasses.Add(new TestClass(13,"Alina", "Alina descripstion"));
            testClasses.Add(new TestClass(14,"Ylia", "Ylia descripstion"));
            testClasses.Add(new TestClass(15,"Andrey", "Andrey descripstion"));
            testClasses.Add(new TestClass(16,"Ser", "Ser descripstion"));
            testClasses.Add(new TestClass(17,"Slava", "Slava descripstion"));
            testClasses.Add(new TestClass(18,"Vlad", "Vlad descripstion"));


            testClasses.Add(new TestClass(19,"Anatoliy", "Anatoliy descripstion"));
            testClasses.Add(new TestClass(20,"Yula", "Yula descripstion"));
            testClasses.Add(new TestClass(21,"Tan9", "Tan9 descripstion"));
            testClasses.Add(new TestClass(22,"Nikita", "Nikita descripstion"));
            testClasses.Add(new TestClass(23,"Vika", "Vika descripstion"));
            testClasses.Add(new TestClass(24,"Olga", "Olga descripstion"));

            testClasses.Add(new TestClass(25,"Nadya", "Nadya descripstion"));
            testClasses.Add(new TestClass(26,"Oksana", "Oksana descripstion"));
            testClasses.Add(new TestClass(27,"Oleg", "Oleg descripstion"));
            testClasses.Add(new TestClass(28,"Sofa", "Sofa descripstion"));
            testClasses.Add(new TestClass(29,"Kek", "Kek descripstion"));
            testClasses.Add(new TestClass(30,"Rer", "Rer descripstion"));

            testClasses.Add(new TestClass(31,"Lol", "Lol descripstion"));
            testClasses.Add(new TestClass(32,"Cheburek", "Cheburek descripstion"));
            testClasses.Add(new TestClass(33,"Galina", "Galina descripstion"));
            testClasses.Add(new TestClass(34,"Elena", "Elena descripstion"));
            testClasses.Add(new TestClass(35,"Sveta", "Sveta descripstion"));
            testClasses.Add(new TestClass(36,"Anna", "Anna descripstion"));

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