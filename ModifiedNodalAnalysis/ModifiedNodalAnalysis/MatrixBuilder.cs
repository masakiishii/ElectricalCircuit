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

        private void stampData(float[, ] matrix, float[, ] vector, Element[] elementlist, int matrixgsize)
        {
            for (int i = 0; i < elementlist.Length; i++)
            {
                elementlist[i].stampElementData(matrix, vector, matrixgsize);
            }
        }

        private void showMatrixData(float[, ] matrix, float[, ] vector, int matrixsize)
        {
            Console.WriteLine("A x = z");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("show stamping Matrix A: ");
            for (int i = 0; i < matrixsize; i++)
            {
                for (int j = 0; j < matrixsize; j++)
                {
                    Console.Write("{0, 6} ", matrix[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("");
            Console.WriteLine("show stamping source vector z: ");
            for (int i = 0; i < matrixsize; i++)
            {
                Console.WriteLine("{0, 6}", vector[i, 0]);
            }
        }

        public float[,] build(List<string[]> rawlist) /******* Kernel Method *******/
        {
            Element[] elementlist = this.buildElementList(rawlist);

            /* Build Matrix A using Stamp : (A x = z) */
            int matrixgsize = this.getMatrixGSize(elementlist);
            int matrixbsize = this.getMatrixBSize(elementlist);
            int matrixsize  = matrixgsize + matrixbsize;
            float[,] matrix = new float[matrixsize, matrixsize];  /* A (n * n) */
            float[,] vector = new float[matrixsize, 1];           /* z (n * 1) */
            this.stampData(matrix, vector, elementlist, matrixgsize);

            /* LU Decompose */
            LUDecomposer decomposer = new LUDecomposer(matrix, vector, matrixsize);
            decomposer.decompose();

            
            /* for debug */
            this.showMatrixData(matrix, vector, matrixsize);
            return matrix;
        }
    }
}
