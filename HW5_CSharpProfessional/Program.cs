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

                var sw = new Stopwatch();

                for (int i = 0; i < cycle; i++)
                {
                    sw.Start();
                    Console.WriteLine(Recearces.MyCWSerializationResearch(f));
                }
                sw.Stop();
                ForComparison.MySerializationMillisecond = sw.ElapsedMilliseconds;

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Сериализация свойств в строку, {cycle} итераций");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"IDE: Visual Studio 2022\nПродолжительность сериализации: {serializObj} мс.\n{Serialization.SerializePropertiesToString(f)}\";");

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Вывод текста в консоль, {cycle} итераций");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Продолжительность записи в консоль: {sw.ElapsedMilliseconds} мс.");

                var jsonSerializer = Recearces.JsonSerializationResearch(cycle, f);

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Cериализация с помощью JSON, {cycle} итераций");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Продолжительность сериализации: {jsonSerializer} мс.");

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Сравнение скорости сериализации JSON и сериализации свойств в строку c выводом в консоль:");
                Console.ForegroundColor = ConsoleColor.White;
                if (ForComparison.JSONSerializationMillisecond < ForComparison.MySerializationMillisecond)
                {
                    Console.WriteLine($"Json бысрее на {ForComparison.MySerializationMillisecond - ForComparison.JSONSerializationMillisecond} мс");
                }    
                else
                {
                    Console.WriteLine($"Сериализация свойств в строку бысрее на {ForComparison.JSONSerializationMillisecond - ForComparison.MySerializationMillisecond} мс");
                }
                if (ForComparison.JSONSerializationMillisecond == ForComparison.MySerializationMillisecond)
                {
                    Console.WriteLine("Результаты равны");
                }

                var csvSerializer = Recearces.CsvSerializationResearch(cycle, path);
                
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Запись в csv, {cycle} итераций");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Продолжительность записи в файл: {csvSerializer} мс.");

                var csvDeserializer = Recearces.CsvDeserializationResearch(path);

                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Продолжительность десериализации из файла, {cycle} итераций");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Продолжительность десериализации из файла: {csvDeserializer} мс.");
            }
            Console.ReadKey();
        }
    }
}