// Написать программу, которая в двумерном массиве заменяет строки на столбцы или сообщить, что это невозможно (в случае, если матрица не квадратная)

int[,] CreateMatrix(int row, int col, int min, int max)
{
    int[,] array = new int[row, col];
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = new Random().Next(min, max);
        }
    }
    return array;
}

void TransposeMatrix(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            int tmp = array[i, j];
            array[i, j] = array[j, i];
            array[j, i] = tmp;
        }
    }
}

void PrintMatrix(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j]}  ");
        }
        Console.WriteLine("");
    }
}

int row = new Random().Next(3, 7);
int col = new Random().Next(3, 7);
int min = 10;
int max = 100;

int[,] matrix = CreateMatrix(row, col, min, max);
PrintMatrix(matrix);
Console.WriteLine("---");
if (matrix.GetLength(0) == matrix.GetLength(1))
{
    TransposeMatrix(matrix);
    PrintMatrix(matrix);
}
else Console.WriteLine("Данную матрицу транспонировать невозможно!" + "\n");
