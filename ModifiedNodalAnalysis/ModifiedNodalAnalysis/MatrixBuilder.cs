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

        private int getMatrixGSize(Element[] elementlist)
        {
            int maximumnode = 0;
            int nodenum;
            for (int i = 0; i < elementlist.Length; i++)
            {
                nodenum = elementlist[i].getNodeNumber();
                if(nodenum > maximumnode) {
                    maximumnode = nodenum;
                }
            }
            Console.WriteLine("matrix G size: " + maximumnode);
            return maximumnode;
        }

        private int getMatrixBSize(Element[] elementlist)
        {
            int sourcenum = 0;
            for (int i = 0; i < elementlist.Length; i++)
            {
                if(elementlist[i].GetType() == typeof(Voltage)) {
                    sourcenum++;
                }
            }
            Console.WriteLine("matrix B size: " + sourcenum);
            return sourcenum;
        }

        private void stampData(float[, ] matrix, Element[] elementlist, int matrixgsize)
        {
            for (int i = 0; i < elementlist.Length; i++)
            {
                elementlist[i].stampElementData(matrix, matrixgsize);
            }
        }

        private void showMatrixData(float[, ] matrix, int matrixsize)
        {
            for (int i = 0; i < matrixsize; i++)
            {
                for (int j = 0; j < matrixsize; j++)
                {
                    Console.Write(matrix[i, j] + "     ");
                }
                Console.WriteLine();
            }
        }

        public float[,] build(List<string[]> rawlist)
        {
            Element[] elementlist = this.buildElementList(rawlist);
            int matrixgsize = this.getMatrixGSize(elementlist);
            int matrixbsize = this.getMatrixBSize(elementlist);
            int matrixsize  = matrixgsize + matrixbsize;
            float[,] matrix = new float[matrixsize, matrixsize];
            this.stampData(matrix, elementlist, matrixgsize);

            /* for debug */
            this.showMatrixData(matrix, matrixsize);
            return matrix;
        }
    }
}
