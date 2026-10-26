using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleExkurs;

internal class EinfacherDelegate
{
    //Definition Delegate
    delegate int CalculationDelegate(int a, int b);

    public EinfacherDelegate()
    {
        //Variable vom Typ des Delegation
        CalculationDelegate? calc = null;

        Console.Write("Geben Sie erste Zahl ein: ");
        int zahl1 = Convert.ToInt32(Console.ReadLine());
        
        Console.Write("Geben Sie zweite Zahl ein: ");
        int zahl2 = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Welche Operation möchtest du? 1: Addieren 2. Subtrahieren");
        string input = Console.ReadLine();

        int ergebnis = 0;
        if(int.TryParse(input, out var number))
        {
            switch (number)
            {
                //case 1: ergebnis = zahl1 + zahl2; break;
                //case 2: ergebnis = zahl1 - zahl2; break;
                case 1: calc = new CalculationDelegate(Addition); break;
                case 2: calc = Substraction; break;
                default: Console.WriteLine("Wat???");break;
            }
        }

        ergebnis = calc(zahl1, zahl2);

        Console.WriteLine($"Berechnung: {ergebnis}");
    }

    private static int Addition(int x , int y)
    {
        return x + y;
    } 
    
    private static int Substraction(int x , int y)
    {
        return x - y;
    }
}
