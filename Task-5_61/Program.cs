// В прямоугольной матрице найти строку с наименьшей суммой элементов.

void FillArray(int[,] array, int start, int end)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array [i, j] = new Random().Next(start, end);
        }
    }
}

void PrintMatrix(int[,] Array)
{
    for (int i = 0; i < Array.GetLength(0); i++)
    {
        for (int j = 0; j < Array.GetLength(1); j++)
        {
            Console.Write($"{Array[i, j]} ");
        }
        Console.WriteLine();
    }
}

int[] FindSum(int[,] someMatrix)
{
    int[] amount = new int[someMatrix.GetLength(0)];
    for (int i = 0; i < someMatrix.GetLength(0); i++)
    {
        int Sum = 0;
        for (int j = 0; j < someMatrix.GetLength(1); j++)
        {
            Sum = Sum + someMatrix[i, j];
        }
    amount[i] = Sum;
    }
    return amount;
}

void PrintArray(int[] array)
{
   for (int i = 0; i < array.Length; i++)
   {
        Console.WriteLine($"# {i + 1} = {array[i]}  ");
   }
}

int FindMinRow(int[] Array)
{
    int min = 0;
    for (int i = 1; i < Array.Length; i++)
    {
        if (Array[i] < Array[min])
            min = i;
    }
    return min;
}

Console.Write(" Введите количество строк массива ");
int m = int.Parse(Console.ReadLine() ?? "0");
Console.Write(" Введите количество столбцов массива ");
int n = int.Parse(Console.ReadLine() ?? "0");
int[,] matrix = new int [m, n];
FillArray(matrix, 0, 10);
PrintMatrix(matrix);
Console.WriteLine();
int[] rowsAmount = FindSum(matrix);
PrintArray(rowsAmount);
int minAmountIndex = FindMinRow(rowsAmount);
Console.WriteLine($" Строка {minAmountIndex + 1} имеет наименьшую сумму элементов ");
