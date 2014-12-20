using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModifiedNodalAnalysis
{
    class MatrixBuilder
    {
        private Element[]      elementlist;
        private List<string[]> rawlist;
        public MatrixBuilder(List<string[]> rawlist)
        {
            this.rawlist = rawlist;
        }

        public void build()
        {
            
        }
    }
}
