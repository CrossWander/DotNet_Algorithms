using System;

namespace SpiralMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите ширину матрицы: ");
            int columns = Convert.ToInt32(Console.ReadLine());
            
            Console.Write("Введите высоту матрицы: ");
            int rows = Convert.ToInt32(Console.ReadLine());

            var spiralMatrix = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                spiralMatrix[i] = new int[columns];
            }

            MakeSpiralMatrix(columns,rows,spiralMatrix);

            Console.Write("\nРезультирующая матрица \n");
            PrintMatrix(spiralMatrix);

            Console.ReadKey();

        }

        private static void MakeSpiralMatrix(int columns, int rows, int[][] matrix)
        {
            int startRow = 0, startCol = 0;
            int endRow = rows - 1;
            int endCol = columns - 1;

            int element = 1;

            while (element <= columns * rows)
            {
                // fill row from left to right and then incrementing start row number
                for (int i = startCol; i <= endCol; i++)
                {
                    matrix[startRow][i] = element;
                    element++;
                }
                startRow++;

                // fill column from top to bottom and then decrease last column number
                for (int j = startRow; j <= endRow; j++)
                {
                    matrix[j][endCol] = element;
                    element++;
                }
                endCol--;

                // fill row from right to left and then decrease last row number
                for (int i = endCol; i >= startCol; i--)
                {
                    matrix[endRow][i] = element;
                    element++;
                }
                endRow--;

                // fill column from bottom to top and then incrementing start columnt number
                for (int j = endRow; j >= startRow; j--)
                {
                    matrix[j][startCol] = element;
                    element++;
                }
                startCol++;
            }
        }

        static void PrintMatrix(int[][] matrix)
        {
            foreach (var row in matrix)
            {
                foreach (var col in row)
                {
                    var toPrint = col + "\t";
                    if (col < 10)
                    {
                        toPrint = "0" + toPrint;
                    }
                    Console.Write(toPrint);
                }

                Console.WriteLine();
            }
        }

    }
}
