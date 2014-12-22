using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModifiedNodalAnalysis
{
    class Voltage : Element
    {
        private static int count = 0;
        private int id;
        public Voltage(string[] rawline) : base(rawline) {
            count++;
            this.id = count;
        }
        
        public override void getType() {
            Console.WriteLine("Element: Voltage");
        }

        public int getVoltageId()
        {
            return this.id;
        }

        public override void stampElementData(double[,] matrix, double[,] vector, int matrixgsize)
        {
            if(this.prenode > 0) {
                matrix[this.prenode - 1, matrixgsize + this.id - 1] = this.prenode > 0 ?  1 : 0;
                matrix[matrixgsize + this.id - 1, this.prenode - 1] = this.prenode > 0 ?  1 : 0;
            }
            if(this.posnode > 0) {
                matrix[this.posnode - 1, matrixgsize + this.id - 1] = this.posnode > 0 ? -1 : 0;
                matrix[matrixgsize + this.id - 1, this.posnode - 1] = this.posnode > 0 ? -1 : 0;
            }
            vector[matrixgsize + this.id - 1, 0] = this.value;
        }
    }
}
