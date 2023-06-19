using System;
using System.Diagnostics;

namespace HW5_CSharpProfessional
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var f = new F();

            Serialization serialization = new();
            
            Console.WriteLine($" Сериализация свойств в строку: {serialization.SerializePropertiesToString(f.Get())}");

            int cycle = 50000;

            var timer = new Stopwatch();
            timer.Start();
            for (var i = 0; i < cycle; i++)
            {

            }
            timer.Stop();



            Console.ReadKey();
        }
    }
}