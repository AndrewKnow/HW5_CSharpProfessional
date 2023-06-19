using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HW5_CSharpProfessional
{
    public static class CsvFileSerialization
    {
        /// <summary>
        /// Сериализация для записи в файл 
        /// </summary>
        /// <typeparam name="T">тип</typeparam>
        /// <param name="obj">объект</param>
        /// <param name="separator">разделитель</param>
        /// <returns>сериализованные значения свойств obj</returns>
        public static string? Serialize<T>(T obj, char separator = '\t')
        {
            if (obj != null)
            {
                var properties = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.NonPublic);
                return new StringBuilder()
                    .AppendJoin(separator, properties.Select(x => x.GetValue(obj)))
                    .ToString();
            }
            return null;
        }

        /// <summary>
        /// Десериализация из файла
        /// </summary>
        /// <typeparam name="T">тип</typeparam>
        /// <param name="obj">объект</param>
        /// <param name="separator">разделитель</param>
        /// <returns></returns>
        public static T? Deserialize<T>(string obj, char separator = '\t') where T : class, new()
        {
            var propertiesValues = obj.Split(separator);
            var properties = typeof(T).GetProperties();

            if (propertiesValues.Length != properties.Length)
            {
                var objT = new T();

                int i = 0;
                foreach (var p in properties)
                {
                    var pValue = Convert.ChangeType(propertiesValues[i++], p.PropertyType);
                    p.SetValue(obj, pValue);
                }

                return objT;
            }

            return null;

        }
    }
}
