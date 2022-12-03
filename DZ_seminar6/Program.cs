// Семинар 6 ДЗ
Console.Clear();
Console.WriteLine("Здравствуйте, Алексей!");
Console.WriteLine("В данной домашней работе представлены задачи 41, 43 и дополнительная на рекурсию (44)");
RepeatTask:
int n = Convert.ToInt32(EnterNumber
(@"Введите номер задачи для проверки: [ 41 ], [ 43 ], [ 44 ]. 
Или нажмите [ 0 ] для выхода из программы.
Ваш выбор = "));
Console.Clear();
switch (n)
{
    case 0:
        Console.WriteLine("До свидания, Алексей!");
        break;
    case 41:
        Zadacha41();
        PauseAndClear();
        goto RepeatTask;
    case 43:
        Zadacha43();
        PauseAndClear();
        goto RepeatTask;
    case 44:
        Zadacha44();
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
void OutTextZadaniya(string TaskText)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(TaskText);
    Console.ResetColor();
}
double EnterNumber(string name)
{
    double num;
    string? number;
    do
    {
        Console.Write(name);
        number = Console.ReadLine();
        if (!double.TryParse(number, out num))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Ошибка! Введено не число. Повторите ввод!");
            Console.ResetColor();
        }
    }
    while (!double.TryParse(number, out num));
    return num;
}
int ProverkaVybora(int check, int checkhome, int checkend, string text)
{
    if (check < checkhome || check > checkend)
        do
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Ошибка! Ввод не распознан. Повторите ввод!");
            Console.ResetColor();
            check = Convert.ToInt32(EnterNumber(text));
        }
        while (check < checkhome || check > checkend);
    return check;
}
void Zadacha41()
{
    OutTextZadaniya(@"Задача 41: Пользователь вводит с клавиатуры M чисел.
Посчитайте, сколько чисел больше 0 ввёл пользователь.");
    // 0, 7, 8, -2, -2 -> 2
    // 1, -7, 567, 89, 223-> 3
    string TextEnterCount = "Сколько чисел вы хотите ввести? M = ";
    string TextEnterVybor1 = @"Нажмите [1] для ввода чисел вручную.
Нажмите [2] для использования случайных чисел.
Ваш выбор:  ";
    string TextEnterVybor2 = @"Нажмите [0] для генерации целых чисел.
Введите необходимую точность для дробных чисел от [1] до [5].
Ваш выбор:  ";
    int SizeMass = Convert.ToInt32(EnterNumber(TextEnterCount));
    SizeMass = ProverkaVybora(SizeMass, 1, 10000, TextEnterCount);
    int Vybor = Convert.ToInt32(EnterNumber(TextEnterVybor1));
    Vybor = ProverkaVybora(Vybor, 1, 2, TextEnterVybor1);
    double[] mass = new double[SizeMass];
    int count = 0;
    int Vybor1 = 0;
    if (Vybor == 2)
    {
        Vybor1 = Convert.ToInt32(EnterNumber(TextEnterVybor2));
        Vybor1 = ProverkaVybora(Vybor1, 0, 5, TextEnterVybor2);
    }
    if (Vybor == 1)
        for (int i = 0; i < SizeMass; i++)
        {
            mass[i] = EnterNumber($"Введите {i + 1}-е число:  ");
            if (mass[i] > 0) count++;
        }
    else
        for (int i = 0; i < SizeMass; i++)
        {
            mass[i] = Math.Round(new Random().Next(-10, 10) + new Random().NextDouble(), Vybor1);
            if (mass[i] > 0) count++;
        }
    if (Vybor == 1) Console.WriteLine("Введёные вами числа:");
    else Console.WriteLine("Сгенерированные числа:");
    for (int i = 0; i < SizeMass - 1; i++)
        Console.Write(" " + mass[i] + ",");
    Console.WriteLine(" " + mass[SizeMass - 1]);
    Console.WriteLine($"Чисел больше нуля: {count}");
}
void Zadacha43()
{
    OutTextZadaniya(@"Задача 43: Напишите программу, которая найдёт точку пересечения двух прямых,
заданных уравнениями: y = k1 * x + b1, y = k2 * x + b2. Значения b1, k1, b2 и k2 задаются пользователем.");
    // b1 = 2, k1 = 5, b2 = 4, k2 = 9 -> (-0,5; -0,5)
    Console.WriteLine("Введите значения коэффициентов");
    double b1 = EnterNumber("b1 = ");
    double k1 = EnterNumber("k1 = ");
    double b2 = EnterNumber("b2 = ");
    double k2 = EnterNumber("k2 = ");
    if (k1 == k2)
        if (b1 == b2) Console.Write("Прямые совпадают");
        else Console.Write("Прямые параллельны, точки пересечения нет");
    else
    {
        double x = Math.Round(((b2 - b1) / (k1 - k2)), 1);
        double y = Math.Round(k1 * x + b1, 1);
        if (k1 * k2 == -1) Console.Write($"Прямые перпендикулярны, точка пересечения прямых ({x}; {y})");
        else Console.Write($"Точка пересечения прямых ({x}; {y})");
    }
}
void Zadacha44()
{
    OutTextZadaniya(@"Дополнительная задача на рекурсию (необязательная).
Напишите программу для подсчета количества цифр в числе с помощью рекурсии.");
    // 12345 -> 5
    long N = Convert.ToInt64(EnterNumber("Введите число: "));
    int c = 1;
    int CountNumber(long n)
    {
        if (n / 10 == 0) return 1;
        CountNumber(n / 10);
        c++;
        return c;
    }
    int с = CountNumber(N);
    switch (с)
    {
        case 1:
            Console.WriteLine("В числе {0} -> {1} цифра", N, с);
            break;
        case 2 or 3 or 4:
            Console.WriteLine("В числе {0} -> {1} цифры", N, с);
            break;
        default:
            Console.WriteLine("В числе {0} -> {1} цифр", N, с);
            break;
    }
}