// Написать программу упорядочивания по убыванию элементов каждой строки двумерного массива

using System.Globalization;

Console.Clear();
System.Console.WriteLine();

int[,] CreateMatrix(int row, int col, int min, int max)
{
    int[,] matrix = new int[row, col];
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = new Random().Next(min, max);
        }
    }
    return matrix;
}

int[,] SortDesc(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            int minPosition = j;
            for (int k = j + 1; k < matrix.GetLength(1); k++)
            {
                if (matrix[i, k] > matrix[i, minPosition]) minPosition = k;
            }
            (matrix[i, minPosition], matrix[i, j]) = (matrix[i, j], matrix[i, minPosition]);
        }
    }
    return matrix;
}

void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write(matrix[i, j] + "  ");
        }
        Console.WriteLine();
    }
}

int row = new Random().Next(3, 7);
int col = new Random().Next(3, 7);
int min = 10;
int max = 100;

int[,] matr = CreateMatrix(row, col, min, max);
PrintMatrix(matr);

Console.WriteLine();
int[,] rowSort = SortDesc(matr);
PrintMatrix(rowSort);