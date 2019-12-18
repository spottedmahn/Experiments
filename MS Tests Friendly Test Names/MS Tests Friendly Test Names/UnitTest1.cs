using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MS_Tests_Friendly_Test_Names
{
    [TestClass]
    [TestCategory("Testing Display Names")]
    public class UnitTest1
    {
        [TestMethod("Now I can read my test names like a human not a computer 😜")]
        public void Blah1()
        {
        }

        [TestMethod("Can VS please implement 'proper emojis'? 😜 fdfsdf")]
        public void Blah2()
        {
        }
    }
}
