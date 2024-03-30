// Написать программу, которая в двумерном массиве заменяет строки на столбцы или сообщить, что это невозможно (в случае, если матрица не квадратная)

internal class Program
{
    private static void Main(string[] args)
    {
        if (args is null)
        {
            throw new ArgumentNullException(nameof(args));
        }

        int[,] FillArray(int m, int n, int start, int end)
        {
            int[,] newMatrix = new int[m, n];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    newMatrix[i, j] = new Random().Next(start, end);
                }
            }
            return newMatrix;
        }

        void PrintArray(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write($"{array[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        int[,] ChangeRowsToColumns(int[,] someMatrix)
        {
            int[,] changedArray = new int[someMatrix.GetLength(0), someMatrix.GetLength(1)];
            for (int i = 0; i < someMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < someMatrix.GetLength(0); j++)
                {
                    changedArray[i, j] = someMatrix[j, i];
                }
            }
            return changedArray;
        }

        Console.Write(" Введите количество строк массива ");
        int m = int.Parse(Console.ReadLine() ?? "0");
        Console.Write(" Введите количество столбцов массива ");
        int n = int.Parse(Console.ReadLine() ?? "0");
        int[,] matrix = FillArray(m, n, 0, 10);
        PrintArray(matrix);
        Console.WriteLine();
        if (m == n)
        {
            int[,] changedMatrix = ChangeRowsToColumns(matrix);
            PrintArray(changedMatrix);
        }
        else Console.WriteLine("Выполнить задачу невозможно - матрица не квадратная ");
    }
}