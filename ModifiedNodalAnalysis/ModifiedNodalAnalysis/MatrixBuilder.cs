using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModifiedNodalAnalysis
{
    class MatrixBuilder
    {
        public MatrixBuilder()
        {
        }

        private Element[] buildElementList(List<string[]> rawlist)
        {
            Element[] elementlist = new Element[rawlist.Count];
            for (int i = 0; i < rawlist.Count; i++)
            {
                string[] rawline = rawlist[i];
                char type = rawline[0][0];
                Element element;
                switch(type) {
                    case 'R':
                        element = new Resistor(rawline);
                        break;
                    case 'V':
                        element = new Voltage(rawline);
                        break;
                    default:
                        element = null;
                        break;
                }
                elementlist[i] = element;
            }
            return elementlist;
        }

        public void build(List<string[]> rawlist)
        {
            Element[] elementlist = this.buildElementList(rawlist);
            for (int i = 0; i < elementlist.Length; i++)
            {
                elementlist[i].getType();
            }
        }
    }
}
