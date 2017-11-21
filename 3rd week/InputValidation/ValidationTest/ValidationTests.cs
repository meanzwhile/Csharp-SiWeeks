using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InputValidation;

namespace ValidationTest
{
    [TestClass]
    public class ValidationTests
    {
        [TestMethod]
        public void TestValidNameWithNotValidCharacters()
        {
            bool expected = false;
            bool actual = Validation.ValidName("Nem jó név mert van benne ékezet");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestValidNameWithValidCharacters()
        {
            bool expected = true;
            bool actual = Validation.ValidName("Jo nev mert nincs benne ekezet");
            Assert.AreEqual(expected, actual);

        }
    }
}