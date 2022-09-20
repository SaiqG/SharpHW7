
System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

// Пользователь вводит с клавиатуры M чисел. Посчитайте, сколько чисел больше 0 ввёл пользователь.

string[] SplitString()
{
    Console.Write("Введите числа через пробел, запятую или / : ");
    return Console.ReadLine()!.Split(' ', ',', '/');
}

bool SelectType()
{
    Console.WriteLine("Добавить дроби в массив?");
    Console.WriteLine("1.Да | 2.Нет");
    ConsoleKeyInfo chouse = Console.ReadKey();
    Console.Clear();

    if (chouse.KeyChar == '1')
    { return true; }
    else if (chouse.KeyChar == '2')
    { return false; }
    else
    { Console.WriteLine($"Такого варианта нет, значит добавлю дроби."); }
    return true;
}

void Fill2DArray(double[,] numbers, int height, int width, bool type)
{
    for (int i = 0; i < height; i++)
    {
        for (int j = 0; j < width; j++)
        {
            if (type)
            { numbers[i, j] = Math.Round(new Random().NextDouble() + new Random().Next(-10, 11), 1); }
            else
            { numbers[i, j] = new Random().Next(-100, 101); }
        }
    }
}

void Print2DArray(double[,] numbers, int height, int width)
{
    for (int i = 0; i < height; i++) 
    {
        for (int j = 0; j < width; j++)  
        {
            Console.Write($"{numbers[i, j],5} ");
        }
        Console.WriteLine();
    }
}

void FindElement(double[,] numbers)
{
    Console.WriteLine("Элемент на какой позиции найти? Строка Столбец ");
    string[] position = SplitString();
    try
    {
        Console.WriteLine($"Элемент на позиции [{position[0]} , {position[1]}] это {numbers[int.Parse(position[0]), int.Parse(position[1])]}");
    }
    catch (Exception)
    {
        Console.WriteLine($"В массиве нет ничего на [{position[0]} , {position[1]}]");
    }
}
double[] FindAverage(double[,] numbers)
{
    double[] average = new double[numbers.GetLength(1)];

    for (int i = 0; i < numbers.GetLength(0); i++)
    {
        for (int j = 0; j < numbers.GetLength(1); j++)
        {
            average[i] = average[i] + numbers[j, i];
        }

    }
    int k = 0;
    foreach (double a in average)
    {
        average[k] =  Math.Round(average[k] / numbers.GetLength(1), 2);
        k++;
    }
    return average;
}

while (true)
{
    try
    {
        Console.WriteLine("Укажите размер двумерного массива.");
        
        string[] scale = SplitString();
        int height = int.Parse(scale[0]);
        int width = int.Parse(scale[1]);

        double[,] numbers = new double[height, width];
        
        Fill2DArray(numbers, height, width, SelectType());
        Print2DArray(numbers, height, width);
        FindElement(numbers);
        Console.WriteLine($"Среднее арифметическое каждого столбца");
        Console.WriteLine(string.Join("  ", FindAverage(numbers)));

    }
    catch (Exception)
    {
        Console.WriteLine("Упс! Что-то пошло не так, попробуйте ввести корректные данные.");
    }

    //Зацикливание программы
    Console.WriteLine("Enter чтобы продолжить / q чтобы выйти");
    ConsoleKeyInfo quite = Console.ReadKey();
    Console.Clear();
    if (quite.KeyChar == 'q' || quite.KeyChar == 'й') break;
}
