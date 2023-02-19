using System;
using System.Collections.Generic;

class Program
{
    delegate int StringLengthDelegate(string str);

    static void Main(string[] args)
    {
        List<string> strings = new List<string>() { "apple", "banana", "cherry", "date", "elderberry" };

        StringLengthDelegate lengthDelegate = s => s.Length;

        foreach (string str in strings)
        {
            int length = lengthDelegate(str);
            Console.WriteLine("{0} - {1}", str, length);
            Console.ReadKey();
        }
    }


}
