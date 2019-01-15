using DotNetFullComVfpLibrary;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var blah = new Class1();
            Console.WriteLine(blah.HelloWorld());
            Console.WriteLine(blah.ParameterTest("some random string"));
            Console.ReadLine();
        }
    }
}