using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNet
{
    internal class Matrix
    {
        double[][] matrix;

        public Matrix(int rows, int cols)
        {
            this.matrix = new double[rows][];
            for (int i = 0; i < rows; i++)
            {
                this.matrix[i] = new double[cols];
            }
        }

        // Function to add two matrices
        public static Matrix Add(Matrix a, Matrix b)
        {
            if (a.matrix.Length != b.matrix.Length || a.matrix[0].Length != b.matrix[0].Length)
            {
                throw new ArgumentException("Matrices must have the same dimensions for addition.");
            }

            int rows = a.matrix.Length;
            int cols = a.matrix[0].Length;
            Matrix result = new Matrix(rows, cols);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result.matrix[i][j] = a.matrix[i][j] + b.matrix[i][j];
                }
            }

            return result;
        }

        // Function to multiply two matrices
        public static Matrix Multiply(Matrix a, Matrix b)
        {
            if (a.matrix[0].Length != b.matrix.Length)
            {
                throw new ArgumentException("Number of columns in the first matrix must be equal to the number of rows in the second matrix for multiplication.");
            }

            int rowsA = a.matrix.Length;
            int colsA = a.matrix[0].Length;
            int colsB = b.matrix[0].Length;
            Matrix result = new Matrix(rowsA, colsB);

            for (int i = 0; i < rowsA; i++)
            {
                for (int j = 0; j < colsB; j++)
                {
                    for (int k = 0; k < colsA; k++)
                    {
                        result.matrix[i][j] += a.matrix[i][k] * b.matrix[k][j];
                    }
                }
            }

            return result;
        }
    }
}
