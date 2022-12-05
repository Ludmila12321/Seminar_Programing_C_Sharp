// Семинар 7 ДЗ
Console.Clear();
Console.WriteLine("Здравствуйте, Алексей!");
Console.WriteLine("В данной домашней работе представлены задачи 47, 50, 52");
RepeatTask:
int n = Convert.ToInt32(EnterNumber
(@"Введите номер задачи для проверки: [ 47 ], [ 50 ], [ 52 ]. 
Или нажмите [ 0 ] для выхода из программы.
Ваш выбор = ", -1));
Console.Clear();
switch (n)
{
    case 0:
        OutTextZadaniya("До свидания, Алексей!", 'g');
        break;
    case 47:
        Zadacha47();
        PauseAndClear();
        goto RepeatTask;
    case 50:
        Zadacha50();
        PauseAndClear();
        goto RepeatTask;
    case 52:
        Zadacha52();
        PauseAndClear();
        goto RepeatTask;
    default:
        OutTextZadaniya("Увы, такой задачи нет =(", 'r');
        PauseAndClear();
        goto RepeatTask;
}
void PauseAndClear()
{
    Console.WriteLine("Нажмите любую кнопку для продолжения");
    Console.ReadKey();
    Console.Clear();
}
void OutTextZadaniya(string TaskText, char color)
{
    if (color == 'r') Console.ForegroundColor = ConsoleColor.Red;
    else Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(TaskText);
    Console.ResetColor();
}
int EnterNumber(string name, int lim)
{
    int num;
    string? number;
    do
    {
        Console.Write(name);
        number = Console.ReadLine();
        if (!int.TryParse(number, out num) || num <= lim)
            OutTextZadaniya("Ошибка! Введено некорректное значение. Повторите ввод!", 'r');

    }
    while (!int.TryParse(number, out num) || num <= lim);
    return num;
}
void Zadacha47()
{
    OutTextZadaniya(@"Задача 47. Задайте двумерный массив размером m х n, 
заполненный случайными вещественными числами.", 'g');
    Console.WriteLine("Введите размерность массива");
    int m = EnterNumber("m = ", 0);
    int n = EnterNumber("n = ", 0);
    double[,] matrix = new double[m, n];
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            matrix[i, j] = Math.Round((new Random().Next(-10, 10) + new Random().NextDouble()), 2);
            Console.Write(matrix[i, j] + " ");
        }
        Console.WriteLine();
    }
}
void Zadacha50()
{
    OutTextZadaniya(@"Задача 50. Напишите программу, которая на вход принимает позиции элемента в двумерном массиве,
и возвращает значение этого элемента или же указание, что такого элемента нет.", 'g');
    // Например, задан массив:
    // 1 4 7 2
    // 5 9 2 3
    // 8 4 2 4
    // 17 -> такого числа в массиве нет
    Console.WriteLine("Укажите позицию искомого элемента в двумерном массиве, полагая что");
    Console.WriteLine("нумерация строк и столбцов в массиве начинается с 1.");
    int i1 = EnterNumber("i = ", 0);
    int j1 = EnterNumber("j = ", 0);
    Console.WriteLine();
    int m = new Random().Next(3, 7);
    int n = new Random().Next(3, 7);
    int[,] matrix = new int[m, n];
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            matrix[i, j] = new Random().Next(10);
            if (i == i1-1 && j == j1-1)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write(matrix[i, j] + " ");
                Console.ResetColor();
            }
            else Console.Write(matrix[i, j] + " ");

        }
                    Console.WriteLine();
    }
    if (i1-1 >= n || j1-1 >= m) Console.WriteLine($"Элемента с индексами [{i1},{j1}] в массиве нет.");
    else Console.WriteLine($"Искомый элемент с индексами [{i1},{j1}] = " + matrix[i1-1, j1-1]);
}
void Zadacha52()
{
    OutTextZadaniya(@"Задача 52. Задайте двумерный массив из целых чисел. 
Найдите среднее арифметическое элементов в каждом столбце.", 'g');
    // Например, задан массив:
    // 1 4 7 2
    // 5 9 2 3
    // 8 4 2 4
    // Среднее арифметическое каждого столбца: 4,6; 5,6; 3,6; 3.
    Console.WriteLine("Введите размерность массива");
    int m = EnterNumber("m = ", 0);
    int n = EnterNumber("n = ", 0);
    Console.WriteLine();
    int[,] matrix = new int[m, n];
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            matrix[i, j] = new Random().Next(0, 10);
            Console.Write(matrix[i, j] + " ");
        }
        Console.WriteLine();
    }
    Console.Write("Среднее арифметическое каждого столбца:  ");
    double srednee = 0;
    for (int j = 0; j < n; j++)
    {
        double colum = 0;
        srednee = 0;
        for (int i = 0; i < m; i++)
        {
            colum += matrix[i, j];
            srednee = Math.Round(colum / m, 1);
        }

        if (j < n - 1) Console.Write(srednee + "; ");
    }
    Console.Write(srednee + ".");
    Console.WriteLine();
}
