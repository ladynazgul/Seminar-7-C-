// В матрице чисел найти сумму элементов главной диагонали

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

int FindSum(int[,] matr)
{
    int sum = 0;
    for (int i = 0; i < matr.GetLength(0); i++)
    {
        sum += matr[i, i];
    }
    return sum;
}

void PrintMatrix(int[,] matr)
{
    System.Console.WriteLine();
    System.Console.WriteLine("Матрица:");
    for (int i = 0; i < matr.GetLength(0); i++)
    {
        for (int j = 0; j < matr.GetLength(1); j++)
        {
            if (matr[i, j] >= 100) System.Console.Write($"{matr[i, j]}   ");
            else if (matr[i, j] >= 10) System.Console.Write($" {matr[i, j]}   ");
            else if (matr[i, j] >= 0) System.Console.Write($"  {matr[i, j]}   ");
        }
        System.Console.WriteLine();
    }
}

void PrintDiagonal(int[,] matrix)
{
    System.Console.WriteLine();
    System.Console.WriteLine("Главная диагональ:");
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (i == j) System.Console.Write(matrix[i, j]);
            else System.Console.Write("      ");
        }
        System.Console.WriteLine();
    }
}

int row = 10;
int col = 10;
int min = 1;
int max = 1000;

int[,] matrix = CreateMatrix(row, col, min, max);
PrintMatrix(matrix);
PrintDiagonal(matrix);
int sumD = FindSum(matrix);
System.Console.WriteLine();
System.Console.WriteLine($"Сумма элементов главной диагонали данной матрицы составляет: {sumD}");
System.Console.WriteLine();