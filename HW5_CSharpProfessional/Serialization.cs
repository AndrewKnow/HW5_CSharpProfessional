using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HW5_CSharpProfessional
{
    public class Serialization
    {
        public static string SerializeToString (object obj)
        {
            var stringBuilder = new StringBuilder ();
            stringBuilder.Append (obj.GetType().Name + "{");

            foreach (var fildes in obj.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
            { 
                stringBuilder.Append ("{");
                stringBuilder.Append (fildes.Name + ", ");

                switch (fildes.FieldType.Namespace)
                {
                    case "System":
                        stringBuilder.Append(fildes.GetValue(obj) + "}");
                        break;
                    default:
                        stringBuilder.Append(fildes.GetValue(obj) + "}");
                        break;
                }

            }

            stringBuilder.Append ("}");
            return stringBuilder.ToString ();
        }
    }
}
