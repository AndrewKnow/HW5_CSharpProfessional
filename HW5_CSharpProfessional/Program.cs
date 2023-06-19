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

            string path = "file.csv";

            Console.WriteLine();

            if (tryParse)
            {
                var f = new F();

                int cycle = int.Parse(cycleString);

                var serializObj = Recearces.MySerializationResearch(cycle, f);
                var serializObjInConsole = Recearces.MyCWSerializationResearch(cycle, f);
                var jsonSerializer = Recearces.JsonSerializationResearch(cycle, f);
                var CsvSerializer = Recearces.CsvSerializationResearch(cycle, path);

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

                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Сравнение скорости сериализации JSON и сериализации свойств в строку:\n");
                Console.ForegroundColor = ConsoleColor.White;
                if (ForComparison.JSONSerializationMillisecond > ForComparison.MySerializationMillisecond)
                {
                    Console.WriteLine($"Json бысрее на {ForComparison.JSONSerializationMillisecond - ForComparison.MySerializationMillisecond} мс");
                }    
                else
                {
                    Console.WriteLine($"Сериализация свойств в строку бысрее на {ForComparison.MySerializationMillisecond - ForComparison.JSONSerializationMillisecond} мс");
                }
                if (ForComparison.JSONSerializationMillisecond == ForComparison.MySerializationMillisecond)
                {
                    Console.WriteLine("Результаты равны");
                }
     
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Запись в csv, {cycle} итераций");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(CsvSerializer);

            }
            Console.ReadKey();
        }
    }
}