using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModifiedNodalAnalysis
{
    abstract class Element
    {
        protected int value;
        protected int prenode;
        protected int postnode;

        public Element(int value, int prenode, int postnode)
        {
            this.value    = value;
            this.prenode  = prenode;
            this.postnode = postnode;
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
    }
}
