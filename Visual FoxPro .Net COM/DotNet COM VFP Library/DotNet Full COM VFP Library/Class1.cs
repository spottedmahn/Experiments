using dotnet_com_learning;

namespace DotNetFullComVfpLibrary
{
    public class Class1
    {
        MikeD MikeD = new MikeD();

        public string HelloWorld()
        {
            return MikeD.HelloWorld();
        }

        public string ParameterTest(string value)
        {
            return MikeD.ParameterTest(value);
        }
    }
}