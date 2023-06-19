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
                var f = new F().Get();

                int cycle = int.Parse(cycleString);

                var serializObj = Recearces.MySerializationResearch(cycle, f);
                var serializObjInConsole = Recearces.MyCWSerializationResearch(cycle, f);
                var jsonSerializer = Recearces.MyCWSerializationResearch(cycle, f);

                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Сериализация свойств в строку, {cycle} итераций");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(serializObj);

                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Вывод текста в консоль, {cycle} итераций");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(serializObjInConsole);

                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Cериализация с помощью JSON, {cycle} итераций");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(jsonSerializer);

            }
            Console.ReadKey();
        }
    }
}