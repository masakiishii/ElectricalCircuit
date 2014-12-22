using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModifiedNodalAnalysis
{
    class CurrentSource : Element
    {
        private static int count = 0;
        private int id;

        public CurrentSource(string[] rawline) : base(rawline) {
            count++;
            this.id = count;
        }

        public override void getType() {
            Console.WriteLine("Element: Current Source");
        }

        public int getCurrentSourceId()
        {
            return this.id;
        }

        public override void stampElementData(double[,] matrix, double[,] vector, int matrixgsize)
        {
            vector[this.id - 1, 0] = this.value;
        }
    }
}
