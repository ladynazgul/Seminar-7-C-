// Составить частотный словарь элементов одномерного массива

int[] array = { 1, 2, 3, 4, 4, 5, 6, 7 };
for (int i = 0; i < array.Length; i++)
{
    if (array[i] != -1)
    {
        int n = array[i];
        int count = 1;
        for (int j = i + 1; j < array.Length; j++)
        {
            if (array[j] == n)
            {
                count = count + 1;
                array[j] = -1;
            }
        }
       Console.WriteLine($"{array[i]} встречается {count} раз");
    }
}