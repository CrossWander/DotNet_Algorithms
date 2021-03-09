using System;
using System.Linq;

namespace SpiralMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;
            while (!endApp)
            {

                int columns, rows;
                string col = "", row = "";

                Console.Write("Введите ширину матрицы: ");
                col = Console.ReadLine();


                while (!int.TryParse(col, out columns) || Convert.ToInt32(col) == 0 || col.Contains("-") )
                {
                    Console.Write("Ошибка ввода. Повторите ввод ширины матрицы: ");
                    col = Console.ReadLine();
                }

                Console.Write("Введите высоту матрицы: ");
                row = Console.ReadLine();

                while (!int.TryParse(row, out rows) || Convert.ToInt32(row) == 0 || row.Contains("-"))
                {

                        Console.Write("Ошибка ввода. Повторите ввод высоты матрицы: ");
                        row = Console.ReadLine();
                }

                var spiralMatrix = new int[rows][];
                for (int i = 0; i < rows; i++)
                {
                    spiralMatrix[i] = new int[columns];
                }

                MakeSpiralMatrix(columns, rows, spiralMatrix);

                Console.Write("\nРезультирующая матрица \n");
                PrintMatrix(spiralMatrix);

                
                Console.Write("\nНажмите 'n' и Enter чтобы закрыть приложение или нажмите любую клавишу для повторного запуска: ");
                if (Console.ReadLine() == "n") endApp = true;

                Console.WriteLine("\n"); 
            }

        }

        private static void MakeSpiralMatrix(int columns, int rows, int[][] matrix)
        {
            int startRow = 0, startCol = 0;
            int endRow = rows - 1;
            int endCol = columns - 1;
            int element = 1;


            while (element <= columns*rows)
            {
                // fill row from left to right and then incrementing start row number
                for (int i = startCol; i <= endCol; i++)
                {
                    if (matrix[startRow][i] == 0)
                    {
                        matrix[startRow][i] = element;
                        element++;
                    }
                }
                startRow++;
                if (rows == 1) break;


                // fill column from top to bottom and then decrease last column number
                for (int j = startRow; j <= endRow; j++)
                {
                    if (matrix[j][endCol] == 0)
                    {
                        matrix[j][endCol] = element;
                        element++;
                    }
                }
                endCol--;
                if (columns == 1) break;

                // fill row from right to left and then decrease last row number    /// в конце идет сюда и снова  меняет
                for (int i = endCol; i >= startCol; i--)
                {
                    if (matrix[endRow][i] == 0)
                    {
                        matrix[endRow][i] = element;
                        element++;
                    }
                }
                endRow--;


                // fill column from bottom to top and then incrementing start columnt number
                for (int j = endRow; j >= startRow; j--)
                {
                    if (matrix[j][startCol] == 0)
                    {
                        matrix[j][startCol] = element;
                        element++;
                    }
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
