using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PersonTest
{
    [TestClass]
    public class PersonTest
    {
        [TestMethod]
        public void PersonConstructorTestWithValidData()
        {
            Person.Person proba = new Person.Person("Zoltan", new DateTime(1970, 2, 3));
            string expected = "Person: Zoltan 47";
            string actual = proba.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PersonConstructorTypeTest()
        {
            Person.Person proba = new Person.Person("Zoltan", new DateTime(1970, 2, 3));
            Assert.IsInstanceOfType(proba, typeof(Person.Person));
        }
    }
}
