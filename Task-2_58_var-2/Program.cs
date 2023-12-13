// Написать программу упорядочивания по убыванию элементов каждой строки двумерного массива

void FillMatrix(int[,] matrix, int min, int max)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = new Random().Next(min, max);
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

void SortRows(int[,] someMatrix)
{
    for (int i = 0; i < someMatrix.GetLength(0); i++)
    {
        for (int j = 0; j < someMatrix.GetLength(1); j++)
        {
            for (int k = 1; k < someMatrix.GetLength(1); k++)
            {
                if (someMatrix[i, k] > someMatrix[i, k - 1])
                {
                    int number = someMatrix[i, k];
                    someMatrix[i, k] = someMatrix[i, k - 1];
                    someMatrix[i, k - 1] = number;
                }
            }
        }
    }
}

int[,] matrix = new int[4, 5];
FillMatrix(matrix, 1, 10);
PrintMatrix(matrix);
Console.WriteLine();
SortRows(matrix);
PrintMatrix(matrix);
