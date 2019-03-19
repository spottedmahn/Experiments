using System;

namespace Named_Tuple_Null_Reference
{
    class Program
    {
        static void Main(string[] args)
        {
            var someResult = GetANamedTuple();

            Console.WriteLine(someResult.SomeProperty);

            Console.WriteLine(someResult.AnotherProperty.Length);
        }

        private static (string SomeProperty, string AnotherProperty) GetANamedTuple()
        {
            return ("Hello World", null);
        }
    }
}