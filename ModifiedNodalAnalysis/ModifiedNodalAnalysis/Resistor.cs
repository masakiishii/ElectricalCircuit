using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModifiedNodalAnalysis
{
    class Resistor : Element
    {
        private string[] rawline;

        public Resistor(string[] rawline) : base(rawline) {}

        public override void getType() {
            Console.WriteLine("Element: Resistor");
        }
    }
}
