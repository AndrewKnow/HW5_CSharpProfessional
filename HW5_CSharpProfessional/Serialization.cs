using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CsvHelper;


namespace HW5_CSharpProfessional
{
    /// <summary>
    /// Методы сериализации
    /// </summary>
    public class Serialization
    {

        /// <summary>
        /// Сериализация свойств класса в строку
        /// </summary>
        /// <param name="obj">Объект</param>
        public static string SerializePropertiesToString(object obj)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append(@"{""");

            int propertiesCount = obj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.NonPublic).Length;
            var properties = obj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.NonPublic);

            for (int i = 0; i < propertiesCount; i++ )
            {

                stringBuilder.Append(properties[i].Name + ":");

                if (i < propertiesCount - 1)
                {
                    stringBuilder.Append(properties[i].GetValue(obj) + @""",""");
                }
                else
                {
                    stringBuilder.Append(properties[i].GetValue(obj) + @"""}");
                }
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// JSON
        /// </summary>
        /// <param name="obj">Объект</param>
        public static void JsonSerialization(object obj)
        {
            JsonConvert.SerializeObject(obj);
        }

        public static void CsvSerialization(object obj)
        {

            File.AppendAllText("file.csv", SerializePropertiesToString(obj));

        }

    }
}
