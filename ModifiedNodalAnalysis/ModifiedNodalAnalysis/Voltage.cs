using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModifiedNodalAnalysis
{
    class Voltage : Element
    {
        public Voltage(string[] rawline) : base(rawline) { }
        
        public override void getType() {
            Console.WriteLine("Element: Voltage");
        }

        public override void setElementData(float[,] matrix, int matrixgsize)
        {

        }
    }
}
