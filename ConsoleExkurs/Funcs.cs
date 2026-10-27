using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleExkurs;

internal class Funcs
{
    //1. Version
    //delegate string ConvertMethod(string meinInput);
    //public Funcs()
    //{
    //    ConvertMethod convert = MakeUppercase;
    //    string name = "ali";
    //    Console.WriteLine(convert(name));
    //    Console.ReadLine();
    //}

    //2. Funcs
    //public Funcs()
    //{
    //    Func<string, string> convert = MakeUppercase;
    //    string name = "ali";
    //    Console.WriteLine(convert(name));
    //    Console.ReadLine();
    //}
    
    //3. Anonyme Function
    //public Funcs()
    //{
    //    Func<string, string> convert = delegate (string input)
    //    {
    //        return input.ToUpper();
    //    };
    //    string name = "ali";
    //    Console.WriteLine(convert(name));
    //    Console.ReadLine();
    //} 
    
    
    //3. Lambda Expression
    public Funcs()
    {
        Func<string, string> convert = (input) => input.ToUpper(); //Mit Rückgabe (letzter Parameter)
        Action<string> act = (input) => Console.WriteLine(input);  // Ohne Rückgabe
        
        string name = "ali";
        Console.WriteLine(convert(name));
        Console.ReadLine();
    }


    private static string MakeUppercase(string input)
    {
        return input.ToUpper();
    }
}
