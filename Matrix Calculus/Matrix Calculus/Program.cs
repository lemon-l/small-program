using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;
using System.Linq;

namespace Matrix_Calculus
{
    class Program
    {
        /// <summary>
        ///  计算矩阵的行数和列数
        /// </summary>
        /// <param name="matrix1"></param>
        /// <param name="matrix2"></param>
        /// <returns></returns>
        private static int[] CRMatrix(int[][] matrix)
        {
            if (matrix.Length == 0)
                return new int[2] { 0, 0 };
            return new int[2] { matrix.Length, matrix[0].Length };
        }

         /// <summary>
         /// 矩阵相乘
         /// </summary>
         /// <param name="matrix1"></param>
         /// <param name="matrix2"></param>
         /// <returns></returns>
        private static int[][] MatrixMul(int[][] matrix1,int[][] matrix2)
        {
            if (CRMatrix(matrix1)[1] != CRMatrix(matrix2)[0])
                throw new Exception("matrix1的列数和matrix2的行数不相等");
            //matrix1是m*n矩阵，matrix2是n*p矩阵，则result是m*p矩阵
            int a = matrix1.Length, b = matrix2.Length, c = matrix2[0].Length;
            int[][] result = new int[a][];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = new int[c];
            }
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    for (int k = 0; k < b; k++)
                    {
                        result[i][j] += (matrix1[i][k] * matrix2[k][j]);
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 打印矩阵
        /// </summary>
        /// <param name="args"></param>
        private static void PrintMatrix(int[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write(matrix[i][j] + "\t");
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("计算两个矩阵的乘积：");
            //矩阵
            int[][] matrix1 = new int[][]
            {
                new int[]{1,2,3},
                new int[]{4,5,6},
                new int[]{7,8,9}
            };
            int[][] matrix2 = new int[][]
            {
                new int[]{9,8,7},
                new int[]{6,5,4},
                new int[]{3,2,1}
            };
            Stopwatch sw = Stopwatch.StartNew();
            Console.WriteLine("\n非并行结果为：");
            PrintMatrix(MatrixMul(matrix1, matrix2));
            sw.Stop();
            Console.Write("--------------------用时{0}ms", sw.ElapsedMilliseconds);
            Console.WriteLine("\n并行结果为：");
            Action<int> action = (i) =>
            {
                int[][] re = MatrixMul(matrix1, matrix2);
                for (int j = 0; j < matrix2[0].Length; j++)
                {
                    Console.Write(re[i][j] + "\t");
                }
                Console.WriteLine();
            };
            sw.Restart();
            Parallel.For(0, matrix1.Length, action);
            sw.Stop();
            Console.Write("--------------------用时{0}ms", sw.ElapsedMilliseconds);
            Console.ReadLine();
        }
    }
}
