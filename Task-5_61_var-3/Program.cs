// Задача про частотный словарь, решение препода


using System.Text.Json.Serialization.Metadata;

void PrintArray(int[] array)
{
    foreach(var element in array)
        Console.Write($"{element} ");
    Console.WriteLine();
}

void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
            Console.Write($"{matrix[i, j]} ");
        Console.WriteLine();
    }
}

int CountElementMatrix(int[,] matrix, int element)
{
    int count = 0;
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if(matrix[i, j] == element)
                count++;
        }
    }
    return count;
}

bool ContainsBeforeIndexes(int[,] matrix, int row, int column, int element)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (i == row && j == column)
                return false;
            if (matrix[i, j] == element)
                return true;
        }
    }
    return false;
}

int[] UniqueElements(int[,] matrix)
{
    int[] uniqueElements = new int[AmountUniques(matrix)];
    int position = 0;
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if(ContainsBeforeIndexes(matrix, i, j, matrix[i, j]) == false)
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
            if(ContainsBeforeIndexes(matrix, i, j, matrix[i, j]) == false)
                uniques++;
        }
    }
    return uniques;
}

int[,] Frequencies(int[,] matrix)
{
    int[,] frequencies = new int[AmountUniques(matrix), 2];
    int[] uniqueElements = UniqueElements(matrix);
    PrintArray(uniqueElements);
    for (int i = 0; i < matrix.GetLength(0); i++)
        for (int j = 0; j < matrix.GetLength(1); j++)
            if(ContainsBeforeIndexes(matrix, i, j, matrix[i, j]) == false)
            {
                frequencies[i, 0] = uniqueElements[i];
                frequencies[i, 1] = CountElementMatrix(matrix, uniqueElements[i]);
            }
    return frequencies;
}

Console.Write("Enter amount of rows: ");
int rows = int.Parse(Console.ReadLine() ?? "0");
Console.Write("Enter amount of columns: ");
int columns = int.Parse(Console.ReadLine() ?? "0");
int[,] matrix = new int[rows, columns];
for (int i = 0; i < rows; i++)
{
    for (int j = 0; j < columns; j++)
    {
        Console.Write($"Enter ({i + 1}, {j + 1}) element of matrix: ");
        matrix[i, j] = int.Parse(Console.ReadLine() ?? "0");
    }
 }

 Console.WriteLine("Your matrix: ");
 PrintMatrix(matrix);
 Console.WriteLine();
 int[,] frequencies = Frequencies(matrix);
 for (int i = 0; i < frequencies.GetLength(0); i++)
    Console.WriteLine($"{matrix[i, 0]} встречается {matrix[i, 1]} раз");




// Console.Write("Enter your array: ");
// int[] array = Console.ReadLine()?.Split(' ')?.Select(int.Parse).ToArray() ?? new int[0];
// Console.Write("Your array: ");
// PrintArray(array); - это магичесая формула для считывания одномерного массива, оставлю тут, вдруг пригодится.