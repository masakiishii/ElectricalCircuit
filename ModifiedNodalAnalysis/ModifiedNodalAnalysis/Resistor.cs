using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModifiedNodalAnalysis
{
    class Resistor : Element
    {
        public Resistor(int value, int prenode, int postnode) : Element(value, prenode, postnode) {}
        
        public override void getType() {
            Console.WriteLine("Element: Resistor");
        }
    }
}
