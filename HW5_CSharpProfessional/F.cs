using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5_CSharpProfessional
{
    public class F
    {
        int i1 { get; set; }
        int i2 { get; set; }
        int i3 { get; set; }
        int i4 { get; set; }
        int i5 { get; set; }

        public F Get() => new F() { i1 = 1, i2 = 2, i3 = 3, i4 = 4, i5 = 5 };     
    }
}
