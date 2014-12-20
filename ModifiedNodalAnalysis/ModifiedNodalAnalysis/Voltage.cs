using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModifiedNodalAnalysis
{
    class Voltage : Element
    {
        public Voltage(int value, int prenode, int postnode) : base(value, prenode, postnode) { }
        
        public override void getType() {
            Console.WriteLine("Element: Voltage");
        }

    }
}
