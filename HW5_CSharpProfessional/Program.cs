using System;
using System.Diagnostics;

namespace HW5_CSharpProfessional
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите количество итераций:");

            var cycleString = Console.ReadLine();

            bool tryParse = int.TryParse(cycleString, out int _);

            Console.WriteLine();

            if (tryParse)
            {
                int cycle = int.Parse(cycleString);

                var sw = new Stopwatch();

                Console.WriteLine($"Сериализация свойств в строку, {cycleString} итераций:");
                var f = new F();

                Serialization serialization = new();

                for (int i = 0; i < cycle; i++)
                {
                    sw.Start();
                    serialization.SerializePropertiesToString(f.Get());
                }
                sw.Stop();

                Console.WriteLine($"Продолжительность: {sw.ElapsedMilliseconds} мс.\n{serialization.SerializePropertiesToString(f.Get())}");

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