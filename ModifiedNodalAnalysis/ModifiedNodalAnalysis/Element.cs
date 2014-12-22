using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModifiedNodalAnalysis
{
    abstract class Element
    {
        protected int   prenode;
        protected int   posnode;
        protected float value;

        public Element(string[] rawline)
        {
            this.prenode  = int.Parse(rawline[1]);
            this.posnode  = int.Parse(rawline[2]);
            this.value    = float.Parse(rawline[3]);
        }

        public float getValue() {
            return this.value;
        }

        public int getPreNode()
        {
            return this.prenode;
        }

        public int getPostNode()
        {
            return this.posnode;
        }

        public abstract void getType();

        public int getNodeNumber()
        {
            return this.prenode > this.posnode ? this.prenode : this.posnode;
        }

        public abstract void stampElementData(float[,] matrix, float[,] vector, int matrixgsize);
    }
}
