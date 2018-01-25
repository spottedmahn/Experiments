using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassLibrary.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetString_ReturnsHelloWorld()
        {
            //arrange
            var expected = "Hello World";

            //act
            var actual = Class1.GetString();

            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
