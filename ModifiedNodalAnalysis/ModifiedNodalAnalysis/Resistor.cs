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

        private void stampNonEarthElementData(double[,] matrix, int matrixgsize)
        {
            matrix[this.prenode - 1, this.prenode - 1] += 1 / this.value;
            matrix[this.posnode - 1, this.posnode - 1] += 1 / this.value;
            matrix[this.prenode - 1, this.posnode - 1] -= 1 / this.value;
            matrix[this.posnode - 1, this.prenode - 1] -= 1 / this.value;
        }

        private void stampEarthElementtData(double[,] matrix, int matrixgsize)
        {
            if(this.prenode != 0) {
                matrix[this.prenode - 1, this.prenode - 1] += 1 / this.value;
            }
            else
            {
                matrix[this.posnode - 1, this.posnode - 1] += 1 / this.value;
            }
        }

        public override void stampElementData(double[,] matrix, double[,] vector, int matrixgsize)
        {
            if(this.prenode != 0 && this.posnode != 0) {
                this.stampNonEarthElementData(matrix, matrixgsize);
            }
            else
            {
                this.stampEarthElementtData(matrix, matrixgsize);
            }
        }

    }
}
