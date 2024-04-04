// Составить частотный словарь элементов двумерного массива

using System.Data;

// void PrintArray1(int[] array)
// {
//     for (int i = 0; i < array.Length; i++)
//     {
//         Console.WriteLine( array[i]);
//     }
// }

int[,] FillArray(int m, int n, int min, int max)
{
    int[,] newMatrix = new int[m, n];
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < m; j++)
        {
            newMatrix[i, j] = new Random().Next(min, max);
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

int CountMatrixElements(int[,] matrix, int element)
{
    int count = 0;
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[i, j] == element)
                count++;
        }
    }
    return count;
}

bool ContainsBeforeIndices(int[,] matrix, int row, int column, int element)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (i == row && j == column)
                return false;
            if (matrix [i, j] == element)
                return true;
        }
    }
    return false;
}

int [] UniqueElements(int[,] matrix)
{
    int [] uniqueElements = new int[AmountUniques(matrix)];
    int position = 0;
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if(ContainsBeforeIndices(matrix, i, j, matrix[i, j]) == false)
            {
                uniqueElements[position] = matrix[i, j];
                position++;
            }
        }
    }
    return uniqueElements;
}

int AmountUniques(int[,] matrix)
{
    int uniques = 0;
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if(ContainsBeforeIndices(matrix, i, j, matrix[i,j]) == false)
                uniques++;
        }
    }
    return uniques;
}

int[,] Frequencies(int[,] matrix)
{
    int[,] frequencies = new int[AmountUniques(matrix), 2];
    int[] uniqueElements = UniqueElements(matrix);
    int row = 0;
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if(ContainsBeforeIndices(matrix, i, j, matrix[i, j]) == false)
            {
                frequencies[row, 0] = uniqueElements[row];
                frequencies[row, 1] = CountMatrixElements(matrix, uniqueElements[row]);
                row++;
            }
        }
    }
    return frequencies;
}

Console.Write(" Введите количество строк массива ");
int m = int.Parse(Console.ReadLine() ?? "0");
Console.Write(" Введите количество столбцов массива ");
int n = int.Parse(Console.ReadLine() ?? "0");
int[,] matrix = FillArray(m, n, 0, 10);
PrintArray(matrix);
Console.WriteLine();
int[,] frequencies = Frequencies(matrix);
for (int i = 0; i < frequencies.GetLength(0); i++)
{
    Console.WriteLine($"{frequencies[i, 0]} встречается {frequencies[i, 1]} раз ");
}
