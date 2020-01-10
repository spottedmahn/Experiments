using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MS_Tests_Friendly_Test_Names
{
    [TestClass]
    [TestCategory("Testing Display Names")]
    public class UnitTest1
    {
        [TestMethod("1) Now I can read my test names like a human not a computer 😜")]
        public void Blah1()
        {
        }

        [TestMethod("2) Can VS please implement 'proper emojis'? 😜")]
        public void Blah2()
        {
            //vs git squash fake commit 1
        }
    }
}
