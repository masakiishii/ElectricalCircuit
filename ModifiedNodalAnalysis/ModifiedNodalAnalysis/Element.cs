using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModifiedNodalAnalysis
{
    abstract class Element
    {
        protected int prenode;
        protected int postnode;
        protected int value;

        public Element(string[] rawline)
        {
            this.prenode  = int.Parse(rawline[1]);
            this.postnode = int.Parse(rawline[2]);
            this.value    = int.Parse(rawline[3]);
        }

        public int getValue() {
            return this.value;
        }

        public int getPreNode()
        {
            return this.prenode;
        }

        public int getPostNode()
        {
            return this.postnode;
        }

        public abstract void getType();
    }
}
