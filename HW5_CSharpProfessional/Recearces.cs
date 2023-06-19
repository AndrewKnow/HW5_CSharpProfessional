using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using Newtonsoft.Json;

namespace HW5_CSharpProfessional
{
    public static class Recearces
    {
        /// <summary>
        /// Реализация пп.1-4. Написать сериализацию свойств или полей класса в строку. Вывести в консоль полученную строку и разницу времени
        /// </summary>
        /// <param name="cycle">Кол-во и итераций</param>
        /// <param name="f">Класс F</param>
        /// <returns>Результат замера в милисекундах</returns>
        public static string MySerializationResearch(int cycle, object f)
        {
            var sw = new Stopwatch();

            for (int i = 0; i < cycle; i++)
            {
                sw.Start();
                Serialization.SerializePropertiesToString(f);
            }
            sw.Stop();
            
            return $"IDE: Visual Studio 2022\nПродолжительность сериализации: {sw.ElapsedMilliseconds} мс.\n{Serialization.SerializePropertiesToString(f)}";
        }

        /// <summary>
        /// Реализация п.6. Замерить время еще раз и вывести в консоль сколько потребовалось времени на вывод текста в консоль
        /// </summary>
        /// <param name="cycle">Кол-во и итераций</param>
        /// <param name="f">Класс F</param>
        /// <returns>Результат замера в милисекундах</returns>
        public static string MyCWSerializationResearch(int cycle, object f)
        {
            var sw = new Stopwatch();

            for (int i = 0; i < cycle; i++)
            {
                sw.Start();
                Console.WriteLine(Serialization.SerializePropertiesToString(f));
            }
            sw.Stop();

            ForComparison.MySerializationMillisecond = sw.ElapsedMilliseconds;

            return $"Продолжительность записи в консоль: {sw.ElapsedMilliseconds} мс.";
        }

        /// <summary>
        /// п.7 Провести сериализацию с помощью каких-нибудь стандартных механизмов (например в JSON)
        /// </summary>
        /// <param name="cycle">Кол-во и итераций</param>
        /// <param name="f">Класс F</param>
        /// <returns>Результат замера в милисекундах</returns>
        public static string JsonSerializationResearch(int cycle, object f)
        {
            var sw = new Stopwatch();

            for (int i = 0; i < cycle; i++)
            {
                sw.Start();
                Serialization.JsonSerialization(f);
            }
            sw.Stop();

            ForComparison.JSONSerializationMillisecond = sw.ElapsedMilliseconds;

            return $"Продолжительность сериализации: {sw.ElapsedMilliseconds} мс.";
        }

        /// <summary>
        /// Запись в файл csv
        /// </summary>
        /// <param name="cycle">Кол-во и итераций</param>
        /// <param name="path">Путь к файлу</param>
        public static string CsvSerializationResearch(int cycle, string path)
        {
            var sw = new Stopwatch();

            var f = new F();
            var data = new StringBuilder();

            for (int i = 0; i < cycle; i++)
            {
                sw.Start();
                data.AppendLine(CsvFileSerialization.Serialize(f.Get()));
            }
            sw.Stop();

            using var streamWriter = new StreamWriter(path);
            streamWriter.Write(data.ToString());
            streamWriter.Close();

            return $"Продолжительность записи в файл: {sw.ElapsedMilliseconds} мс.";
        }


        public static string CsvDeserializationResearch(int cycle, string path)
        {
            var sw = new Stopwatch();

            string data = new StreamReader(path).ReadToEnd();
            var values = data.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);

            var numberIterations = values.Length;
            var obj = new F[numberIterations];

            for (int i = 1; i < values.Length; i++)
            {
                sw.Start();
                obj[i] = CsvFileSerialization.Deserialize<F>(values[i]);

                Console.WriteLine($"тест { Serialization.SerializePropertiesToString(obj[i])}");
            }
            sw.Stop();

           
            return $"Продолжительность десериализации из файла: {sw.ElapsedMilliseconds} мс.";
        }

    }
}
