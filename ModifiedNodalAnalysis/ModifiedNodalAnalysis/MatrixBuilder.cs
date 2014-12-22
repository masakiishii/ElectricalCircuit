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
                    case 'I':
                        element = new CurrentSource(rawline);
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
            return sourcenum;
        }

        private void stampData(double[, ] matrix, double[, ] vector, Element[] elementlist, int matrixgsize)
        {
            for (int i = 0; i < elementlist.Length; i++)
            {
                elementlist[i].stampElementData(matrix, vector, matrixgsize);
            }
        }

        private void showMatrixData(double[, ] matrix, double[, ] vector, int matrixsize)
        {
            Console.WriteLine("A x = z");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine();
            Console.WriteLine("show stamping Matrix A: ");
            Console.WriteLine("-----------------------------------------");
            for (int i = 0; i < matrixsize; i++)
            {
                for (int j = 0; j < matrixsize; j++)
                {
                    Console.Write("{0, 6} ", Math.Round(matrix[i, j], 3, MidpointRounding.AwayFromZero));
                }
                Console.WriteLine();
            }
            Console.WriteLine("");
            Console.WriteLine("show stamping source vector z: ");
            Console.WriteLine("-----------------------------------------");
            for (int i = 0; i < matrixsize; i++)
            {
                Console.WriteLine("{0, 6}", vector[i, 0]);
            }
            Console.WriteLine();
        }

        private void showAnswerVector(double[,] ansvector, int matrixsize)
        {
            Console.WriteLine("show answer vector x: ");
            Console.WriteLine("-----------------------------------------");
            for (int i = 0; i < matrixsize; i++)
            {
                Console.WriteLine("{0, 6}", ansvector[i, 0]);
            }
        }

        private void sparsePreProcess(double[,] matrix, bool[,] sparsematrix, int matrixsize)
        {
            double epsiron = Math.Pow(2, -50);
            for (int i = 0; i < matrixsize; i++ )
            {
                for (int j = 0; j < matrixsize; j++ )
                {
                    sparsematrix[i, j] = Math.Abs(matrix[i, j]) < epsiron ? true : false;
                }
            }
        }

        private void sparseProcessing(double[,] matrix, bool[,] sparsematrix, int matrixsize)
        {
            for (int i = 0; i < matrixsize; i++ )
            {
                for (int j = 0; j < matrixsize; j++ )
                {
                    if (sparsematrix[i, j] && Math.Abs(matrix[i, j]) < 0.1)
                    {
                        matrix[i, j] = 0;
                    }
                }
            }

        }

        public double[,] build(List<string[]> rawlist, bool sparsemode) /******* Kernel Method *******/
        {
            Element[] elementlist = this.buildElementList(rawlist);

            /* Build Matrix A using Stamp : (A x = z) */
            int matrixgsize = this.getMatrixGSize(elementlist);
            int matrixbsize = this.getMatrixBSize(elementlist);
            int matrixsize  = matrixgsize + matrixbsize;
            double[,] matrix = new double[matrixsize, matrixsize];  /* A (n * n) */
            double[,] vector = new double[matrixsize, 1];           /* z (n * 1) */
            this.stampData(matrix, vector, elementlist, matrixgsize);

            /* for debug */
            this.showMatrixData(matrix, vector, matrixsize);
            //Console.ReadLine();


            if(sparsemode) { /* sparse processing */
                bool[,] sparsematrix = new bool[matrixsize, matrixsize];  /* A (n * n) */
                this.sparsePreProcess(matrix, sparsematrix, matrixsize);

                LUDecomposer decomposer = new LUDecomposer(matrix, vector, matrixsize);
                decomposer.decompose();
                
                this.showMatrixData(matrix, vector, matrixsize);
                this.sparseProcessing(matrix, sparsematrix, matrixsize);


            /* for debug */
                this.showMatrixData(matrix, vector, matrixsize);


                double[,] ansvector = decomposer.solve();
                this.showAnswerVector(vector, matrixsize);                
            }
            else
            {
            /* LU Decompose */
                LUDecomposer decomposer = new LUDecomposer(matrix, vector, matrixsize);
                decomposer.decompose();
                double[,] ansvector = decomposer.solve();

            /* for debug */
                this.showAnswerVector(vector, matrixsize);
            }
            return matrix;
        }
    }
}
