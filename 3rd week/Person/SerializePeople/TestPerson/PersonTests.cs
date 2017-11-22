using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Serializeable_Person;

namespace PersonTest
{
    [TestClass]
    public class PersonTest
    {
        [TestMethod]
        public void PersonConstructorTestWithValidData()
        {
            Person proba = new Person("Zoltan", new DateTime(1970, 2, 3));
            string expected = "Person: Zoltan 47";
            string actual = proba.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PersonConstructorTypeTest()
        {
            Person proba = new Person("Zoltan", new DateTime(1970, 2, 3));
            Assert.IsInstanceOfType(proba, typeof(Person));
        }
    }
}
