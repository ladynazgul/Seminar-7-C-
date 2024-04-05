// Частотный словарь строки

string text = "Частотный анализ - это один из методов криптоанализа, основывающийся на предположении о существовании нетривиального статистического распределения отдельных символов и их последовательностей как в открытом, так и в шифрованном тексте, которое с точностью до замены символов будет сохраняться в процессе шифрования и дешифрования.";
text = text.ToLower();

bool ContainBeforeIndex(string stroke, char element, int index)
{
    for (int i = 0; i <= index; i++)
    {
        if (i == index) return false;
        if (stroke[i] == element) return true;
    }
    return false;
}

string UniqueSymbols(string stroka)
{
    string uniqueSymbols = String.Empty;
    for (int i = 0; i < stroka.Length; i++)
    {
        if (ContainBeforeIndex(stroka, stroka[i], i) == false)
        uniqueSymbols = uniqueSymbols + $"{stroka[i]}";
    }
    return uniqueSymbols;
}

int[] Frequency(string stroka, string str)
{
    int[] frequency = new int[str.Length];
    for (int i = 0; i < str.Length; i++)
    {
        int count = 0;
        for (int j = 0; j < stroka.Length; j++)
        {
            if (str[i] == stroka[j])
                count++;
        }
        frequency[i] = count;
    }
    return frequency;
}

char[] SortArray(int[] array, string str)
{
    char[] newStr = str.ToCharArray();
    for (int i = 0; i < array.Length; i++)
    {
        int iMax = i;
        int maximum = array[iMax];
        for (int j = 1 + i; j < array.Length; j++)
        {
            if (array[j] > maximum)
            {
                maximum = array[i];
                iMax = j;
            }
        }
        int number = array[i];
        array[i] = maximum;
        array[iMax] = number;
        char symbol = newStr[i];
        newStr[i] = newStr[iMax];
        newStr[iMax] = symbol;
    }
    return newStr;
}

string[] ChangeName(char[] symbols)
{
    string[] newSymbols = new string[symbols.Length];
    for (int i = 0; i < symbols.Length; i++)
    {
        if (symbols[i] == ' ')
            newSymbols[i] = "пробел";
        else newSymbols[i] = Char.ToString(symbols[i]);
    }
    return newSymbols;
}

void PrintArray(int[] array, string[] str, string stroka)
{
    for (int i = 0; i < array.Length; i++)
    {
        double a = Convert.ToDouble(array[i])*100/Convert.ToDouble(stroka.Length);
        double frequency = Math.Round(a, 2);
        Console.WriteLine($"символ {str[i]} встречается {array[i]} раз. Частота {frequency} % ");
    }
}

string symbols = UniqueSymbols(text);
Console.WriteLine(symbols);
int[] frequencyArray = Frequency(text, symbols);
char[] arrangedSymbols = SortArray(frequencyArray, symbols);
string[] space = ChangeName(arrangedSymbols);
PrintArray(frequencyArray, space, text);
