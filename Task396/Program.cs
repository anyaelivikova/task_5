using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task396
{
    class Program
    {
        static void FillMatrix(double[,] matrix)
        {
            Random rand = new Random();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = Math.Round(rand.NextDouble() * rand.Next(-100, 100), 2);
                }
            }
        }

        static void PrintMatrix(double[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i,j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void PrintSequence(double[] sequence)
        {
            for (int i = 0; i < sequence.Length; i++)
            {
                Console.Write(sequence[i] + " ");
            }
            Console.WriteLine();
        }

        static double[] FormSequence(double[,] matrix)
        {
            double[] mas = new double[matrix.GetLength(0)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                double sum = 0;

                if (matrix[i,i] < 0)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i, j] < 0)
                            break;

                        sum += matrix[i, j];
                    }
                }
                else
                {
                    //ищем позицию первого неотрицательного элемента в строке
                    int pos = 0;
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i,j] >= 0)
                        {
                            pos = j;
                            break;
                        }
                    }
                    for (int j = pos; j < matrix.GetLength(1); j++)
                    {
                        sum += matrix[i, j];
                    }
                }

                mas[i] = sum;
            }

            return mas;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("<<< ЗАДАЧА 5 >>>");

            bool ok;
            int n = 0;
            do
            {
                Console.Write(" Введите порядок матрицы , равный n = ");
                string buf = Console.ReadLine();
                ok = int.TryParse(buf, out n);
                ok = (n > 0);

                if (!ok) Console.WriteLine("Ошибка ввода, введите натуральное число");

            } while (!ok);

            double[,] matrix = new double[n, n];
            FillMatrix(matrix);
            PrintMatrix(matrix);

            double[] mas = FormSequence(matrix);
            PrintSequence(mas);

            Console.ReadLine();
        }
    }
}
