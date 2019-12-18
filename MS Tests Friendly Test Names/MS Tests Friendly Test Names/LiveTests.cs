using ClassLibrary1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MS_Tests_Friendly_Test_Names
{
    [TestClass]
    [TestCategory("Live Unit Tests")]
    public class LiveTests
    {
        [TestMethod()]
        public void Blah1()
        {
            Assert.AreEqual("Hello World", new Class1().HelloWorld());
        }
    }
}
