// Найти сумму элементов главной диагонали в матрице, вариант 2

using System.Globalization;

void FillMatrix(int[,] matr, int min, int max)
{
    for (int i = 0; i < matr.GetLength(0); i++)
    {
        for (int j = 0; j < matr.GetLength(1); j++)
        {
            matr[i, j] = new Random().Next(min, max);
        }
    }
}

void PrintMatrix(int[,] matr)
{
    for (int i = 0; i < matr.GetLength(0); i++)
    {
        for (int j = 0; j < matr.GetLength(1); j++)
        {
            Console.Write($"{matr[i, j]} ");
        }
        Console.WriteLine();
    }
}

int SumDiagonal(int[,] amatrix)
{
    int sum = 0;
    for (int i = 0; i < amatrix.GetLength(0); i++)
    {
        for (int j = 0; j < amatrix.GetLength(1); j++)
        {
            if (i == j)
            {
                sum += amatrix[i, j];
            }
        }
    }
    return sum;
}

Console.Write("Введите количество строк матрицы ");
int m = int.Parse(Console.ReadLine() ?? "0");
Console.Write("Введите количество столбцов матрицы ");
int n = int.Parse(Console.ReadLine() ?? "0");
int[,] matrix = new int[m, n];
FillMatrix(matrix, 0, 100);
PrintMatrix(matrix);
int sumD = SumDiagonal(matrix);
Console.WriteLine($"Сумма элементов главной диагонали равна {sumD}  ");