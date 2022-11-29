// Семинар 5 ДЗ
Console.Clear();
Console.WriteLine("Здравствуйте, Алексей!");
RepeatTask:
Console.WriteLine("Введите номер задачи, функциональность которой вы хотели бы проверить");
Console.WriteLine("В данной домашней работе представлены задачи 34, 35, 36, 38");
Console.WriteLine("Нажмите [ 0 ] для выхода из программы");
int n = Convert.ToInt32(Console.ReadLine());
Console.Clear();
switch (n)
{
    case 0:
        Console.WriteLine("До свидания, Алексей!");
        break;
    case 34:
        Zadacha34();
        PauseAndClear();
        goto RepeatTask;
    case 35:
        Zadacha35();
        PauseAndClear();
        goto RepeatTask;
    case 36:
        Zadacha36();
        PauseAndClear();
        goto RepeatTask;
    case 38:
        Zadacha38();
        PauseAndClear();
        goto RepeatTask;
    default:
        Console.WriteLine("Увы, такой задачи нет(");
        PauseAndClear();
        goto RepeatTask;
}
void PauseAndClear()
{
    Console.WriteLine("Нажмите любую кнопку для продолжения");
    Console.ReadKey();
    Console.Clear();
}
int[] FillingArray(int size, int a, int b)
{
    int[] array = new int[size];
    for (int i = 0; i < size; i++)
        array[i] = new Random().Next(a, b);
    return array;
}
int EnterSizeAndRange(string TaskStr1, string TaskStr2, ref int a, ref int b)
{
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine(TaskStr1);
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine(TaskStr2);
    Console.ForegroundColor = ConsoleColor.Red;
    int num, range;
EnterSize: //Метка возвращения в случае ошибочного ввода
    Console.WriteLine("Введите размер массива");
    Console.ResetColor();
    string? n = Console.ReadLine();
    if (int.TryParse(n, out num) == false)
    {
        Console.WriteLine("Значение не является числом, начните заново");
        goto EnterSize;
    }
EnterRange: //Метка возвращения в случае ошибочного ввода
    Console.WriteLine("Нажмите [ 1 ] если хотите ввести пределы диапазoна вручную");
    Console.WriteLine("Нажмите [ 2 ] для использования значений по умолчанию");
    n = Console.ReadLine();
    if (int.TryParse(n, out range) == false)
    {
        Console.WriteLine("Значение не является числом, начните заново");
        goto EnterRange;
    }
    if (range == 1)
    {
    EnterHomePoz: //Метка возвращения в случае ошибочного ввода
        Console.WriteLine("Введите начало диапазона случайных чисел");
        n = Console.ReadLine();
        if (int.TryParse(n, out a) == false)
        {
            Console.WriteLine($"Значение не является числом, начните заново");
            goto EnterHomePoz;
        }
    EnterEndPoz: //Метка возвращения в случае ошибочного ввода
        Console.WriteLine("Введите конец диапазона случайных чисел");
        n = Console.ReadLine();
        if (int.TryParse(n, out b) == false)
        {
            Console.WriteLine($"Значение не является числом, начните заново");
            goto EnterEndPoz;
        }
    }
    return num;
}
void Zadacha34()
{
    string TaskText1 = "Задача 34: Задайте массив заполненный случайными положительными трёхзначными числами.";
    string TaskText2 = "Напишите программу, которая покажет количество чётных чисел в массиве.";
    // [345, 897, 568, 234] -> 2
    int a = 100; // Начало диапазона по умолчанию
    int b = 1000; // Конец диапазона по умолчанию
    int num = EnterSizeAndRange(TaskText1, TaskText2, ref a, ref b);
    int[] arr = FillingArray(num, a, b);
    int count = 0;
    for (int i = 0; i < num; i++)
        if (arr[i] % 2 == 0) count += 1;
    Console.WriteLine("[ {0} ] -> {1}", string.Join(", ", arr), count);
}
void Zadacha35()
{
    string TaskText1 = "Задача 35: Задайте одномерный массив из 123 случайных чисел.";
    string TaskText2 = "Найдите количество элементов массива,значения которых лежат в отрезке [10,99].";
    // Пример для массива из 5, а не 123 элементов. В своём решении сделайте для 123
    // [5, 18, 123, 6, 2] -> 1
    // [1, 2, 3, 6, 2] -> 0
    // [ 10, 11, 12, 13, 14 ] -> 5
    int a = -1000; // Начало диапазона по умолчанию
    int b = 1000; // Конец диапазона по умолчанию
    int num = EnterSizeAndRange(TaskText1, TaskText2, ref a, ref b);
    int[] arr = FillingArray(num, a, b);
    int count = 0;
    for (int i = 0; i < num; i++)
        if (arr[i] >= 10 && arr[i] <= 99) count += 1;
    Console.WriteLine("[ {0} ] -> {1}", string.Join(", ", arr), count);
}
void Zadacha36()
{
    string TaskText1 = "Задача 36: Задайте одномерный массив, заполненный случайными числами.";
    string TaskText2 = "Найдите сумму элементов, стоящих на нечётных позициях(индексах).";
    // [3, 7, 23, 12] -> 19
    // [-4, -6, 89, 6] -> 0
    int a = -10; // Начало диапазона по умолчанию
    int b = 100; // Конец диапазона по умолчанию
    int num = EnterSizeAndRange(TaskText1, TaskText2, ref a, ref b);
    int[] arr = FillingArray(num, a, b);
    int sum = 0;
    for (int i = 0; i < num; i++)
        if (i % 2 != 0) sum += arr[i];
    Console.WriteLine("[ {0} ] -> {1}", string.Join(", ", arr), sum);
}
void Zadacha38()
{
    string TaskText1 = "Задача 38: Задайте массив вещественных(тип double) чисел.";
    string TaskText2 = "Найдите разницу между максимальным и минимальным элементами массива.";
    // [3 7 22 2 78] -> 76
    int a = 0; // Начало диапазона по умолчанию
    int b = 20; // Конец диапазона по умолчанию
    int num = EnterSizeAndRange(TaskText1, TaskText2, ref a, ref b);
    int[] mass = FillingArray(num, a, b);
    double[] arr = new Double[num];
    for (int i = 0; i < num; i++)
        arr[i] = Math.Round(mass[i] + new Random().NextDouble(), 2);
    double max = arr[0];
    double min = arr[0];
    for (int i = 0; i < num; i++)
    {
        if (arr[i] > max) max = arr[i];
        if (arr[i] < min) min = arr[i];
    }
    Console.WriteLine("[ {0} ] -> {1}", string.Join("; ", arr), Math.Round(max - min, 2));
}