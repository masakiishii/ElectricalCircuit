using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModifiedNodalAnalysis
{
    class LUDecomposer
    {
        private double[,] matrix;
        private double[,] vector;
        private int[,] pervector;
        private int matrixsize;

        public LUDecomposer(double[,] matrix, double[,] vector, int matrixsize)
        {
            this.matrix     = matrix;
            this.vector     = vector;
            this.pervector  = new int[1, matrixsize];
            this.matrixsize = matrixsize;
        }

        public double[,] solve()
        {
            double tmp;
            for (int k = 0; k < this.matrixsize; k++ )
            {
                tmp = this.vector[k, 0];
                this.vector[k, 0] = this.vector[this.pervector[0, k], 0];
                this.vector[this.pervector[0, k], 0] = tmp;
                for (int i = k + 1; i < this.matrixsize; i++ )
                {
                    this.vector[i, 0] = this.vector[i, 0] + this.matrix[i, k] * this.vector[k, 0];
                }
            }
            this.vector[this.matrixsize - 1, 0]
                = this.vector[this.matrixsize - 1, 0] / this.matrix[this.matrixsize - 1, this.matrixsize - 1];
            for (int k = this.matrixsize - 2; k >= 0; k-- )
            {
                tmp = this.vector[k, 0];
                for (int j = k + 1; j < this.matrixsize; j++ )
                {
                    tmp = tmp - this.matrix[k, j] * this.vector[j, 0];
                }
                this.vector[k, 0] = tmp / this.matrix[k, k];
            }
            return this.vector;
        }

        public void decompose()
        {
            double pivot;
            double tmp;
            double alpha;
            int ip;
            for (int k = 0; k < this.matrixsize; k++)
            {
                pivot = Math.Abs(this.matrix[k, k]);
                ip = k;
                for (int i = k + 1; i < this.matrixsize; i++)
                {
                    if(Math.Abs(this.matrix[i, k]) > pivot) {
                        pivot = Math.Abs(this.matrix[i, k]);
                        ip = i;
                    }
                }
                this.pervector[0, k] = ip;
                if(ip != k) {
                    for (int j = k; j < this.matrixsize; j++ )
                    {
                        tmp = this.matrix[k, j];
                        this.matrix[k, j]  = this.matrix[ip, j];
                        this.matrix[ip, j] = tmp;
                    }
                }
                for (int i = k + 1; i < this.matrixsize; i++ )
                {
                    alpha = -this.matrix[i, k] / this.matrix[k, k];
                    this.matrix[i, k] = alpha;
                    for (int j = k + 1; j < this.matrixsize; j++ )
                    {
                        this.matrix[i, j] = this.matrix[i, j] + alpha * this.matrix[k, j];
                    }
                }
            }
        }
    }
}
