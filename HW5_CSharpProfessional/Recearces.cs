using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

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

            return $"IDE: Visual Studio 2022\nПродолжительность: {sw.ElapsedMilliseconds} мс.\n{Serialization.SerializePropertiesToString(f)}";
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

            return $"Продолжительность: {sw.ElapsedMilliseconds} мс.";
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

            return $"Продолжительность: {sw.ElapsedMilliseconds} мс.";
        }

    }
}
