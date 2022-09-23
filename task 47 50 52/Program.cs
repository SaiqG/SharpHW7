
System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

string[] EnterAndSplitString()
{
    Console.Write("Введите числа через пробел, запятую или / : ");
    return Console.ReadLine()!.Split(' ', ',', '/');
}

//Задайте двумерный массив размером m×n, заполненный случайными вещественными числами.

bool SelectFillType()
{
    Console.WriteLine("Добавить дроби в массив?");
    Console.WriteLine("1.Да | 2.Нет");
    ConsoleKeyInfo choose = Console.ReadKey();
    Console.WriteLine();

    if (choose.KeyChar == '1')
    { return true; }
    else if (choose.KeyChar == '2')
    { return false; }
    else
    { Console.WriteLine($"Такого варианта нет, значит добавлю дроби."); }
    return true;
}

void Fill2DArray(double[,] numbers, bool type)
{
    for (int i = 0; i < numbers.GetLength(0); i++)
    {
        for (int j = 0; j < numbers.GetLength(1); j++)
        {
            if (type)
            { numbers[i, j] = Math.Round(new Random().NextDouble() + new Random().Next(-10, 11), 1); }
            else
            { numbers[i, j] = new Random().Next(-100, 101); }
        }
    }
}

void Print2DArray(double[,] numbers)
{
    for (int i = 0; i < numbers.GetLength(0); i++)
    {
        for (int j = 0; j < numbers.GetLength(1); j++)
        {
            Console.Write($"{numbers[i, j],5} ");
        }
        Console.WriteLine();
    }
}

//Напишите программу, которая на вход принимает позиции элемента в двумерном массиве, и возвращает значение этого элемента или же указание, что такого элемента нет.

string[] FindElement(double[,] numbers)
{
    Console.WriteLine("Элемент на какой позиции найти? Строка Столбец ");
    string[] position = EnterAndSplitString();
    Console.Clear();
    try
    {
        Console.WriteLine();
        Console.WriteLine($"Элемент на позиции [{int.Parse(position[0])} , {int.Parse(position[1])}] это {numbers[int.Parse(position[0]) - 1, int.Parse(position[1]) - 1]}");
    }
    catch (Exception)
    {
        Console.WriteLine($"В массиве нет ничего на [{int.Parse(position[0])} , {int.Parse(position[1])}]");
    }
    return position;
}

void PrintArrayWithColoredElement(double[,] numbers, string[] position)
{
    for (int i = 0; i < numbers.GetLength(0); i++)
    {
        for (int j = 0; j < numbers.GetLength(1); j++)
        {
            if (i == int.Parse(position[0]) - 1 && j == int.Parse(position[1]) - 1)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write($"{numbers[i, j],5} ");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.Write($"{numbers[i, j],5} ");
            }
        }
        Console.WriteLine();
    }
}


//Найдите среднее арифметическое элементов в каждом столбце.

double[] FindAverage(double[,] numbers)
{
    Console.WriteLine($"Среднее арифметическое каждого столбца :");

    double[] average = new double[numbers.GetLength(1)];

    for (int i = 0; i < numbers.GetLength(1); i++)
    {
        for (int j = 0; j < numbers.GetLength(0); j++)
        {
            average[i] = average[i] + numbers[j, i];
        }

    }
    int k = 0;
    foreach (double a in average)
    {
        average[k] = Math.Round(average[k] / numbers.GetLength(0), 2);
        k++;
    }
    return average;
}


while (true)
{
    try
    {
        Console.WriteLine("Укажите размер двумерного массива.");

        string[] scale = EnterAndSplitString();
        double[,] numbers = new double[int.Parse(scale[0]), int.Parse(scale[1])];

        Fill2DArray(numbers, SelectFillType());
        Print2DArray(numbers);
        Console.WriteLine();

        PrintArrayWithColoredElement(numbers, FindElement(numbers));
        Console.WriteLine();

        Console.WriteLine(string.Join("  ", FindAverage(numbers)), 5);
        Console.WriteLine();

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
