using System;
using System.Diagnostics;

namespace HW5_CSharpProfessional
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество итераций:");

            var cycleString = Console.ReadLine();

            bool tryParse = int.TryParse(cycleString, out int _);

            Console.WriteLine();

            if (tryParse)
            {
                int cycle = int.Parse(cycleString);

                var f = new F();

                Serialization serialization = new();

                Console.WriteLine($"Сериализация свойств в строку, {cycleString} итераций:\n{serialization.SerializePropertiesToString(f.Get())}");

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
}