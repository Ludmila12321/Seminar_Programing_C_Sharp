// Семинар 9 ДЗ
Console.Clear();
Console.SetCursorPosition(Console.WindowWidth / 2, 0);
OutTextZadaniya("Здравствуйте, Алексей!", 'g', 1);
OutTextZadaniya("В данной домашней работе представлены задачи 64, 66, 68.", 'w', 1);
RepeatTask:
int NumberTask = Convert.ToInt32(EnterNumber
(@"Введите номер задачи для проверки: [ 64 ], [ 66 ], [ 68 ]. 
Или нажмите [ 0 ] для выхода из программы.
Ваш выбор = ", -1, 100, 'w', 0));
Console.Clear();
switch (NumberTask)
{
    case 0:
        OutTextZadaniya(@"Вы точно уверены?
Нажмите [ 0 ] еще раз если все же решили закончить проверку домашнего задания.", 'r', 1);
        OutTextZadaniya(@"Нажмите любую другую цифру если передумали.", 'g', 1);
        NumberTask = Convert.ToInt32(EnterNumber("Ваш выбор = ", -1, 999, 'y', 0));
        if (NumberTask == 0)
        {
            OutTextZadaniya("Очень жаль, что вы так быстро уходите(", 'y', 1);
            OutTextZadaniya("До свидания, Алексей!", 'g', 1);
            break;
        }
        else
        {
            OutTextZadaniya(@"Хорошо, что вы передумали.
Давайте продолжим проверять задания.", 'g', 1);
            PauseAndClear();
            goto RepeatTask;
        }
    case 64:
        Zadacha64();
        PauseAndClear();
        goto RepeatTask;
    case 66:
        Zadacha66();
        PauseAndClear();
        goto RepeatTask;
    case 68:
        Zadacha68();
        PauseAndClear();
        goto RepeatTask;
    default:
        OutTextZadaniya("Увы, такой задачи нет =(", 'r', 1);
        PauseAndClear();
        goto RepeatTask;
}
void PauseAndClear()
{
    Console.WriteLine();
    OutTextZadaniya("Нажмите любую кнопку для продолжения", 'c', 0);
    Console.ReadKey();
    Console.Clear();
}
void OutTextZadaniya(string TaskText, char color, int perevodstroki) // Передаётся текст, идентификатор цвета
{                                                                   // и идентификатор перевода строки
    if (color == 'r') Console.ForegroundColor = ConsoleColor.Red;
    if (color == 'y') Console.ForegroundColor = ConsoleColor.Yellow;
    if (color == 'w') Console.ForegroundColor = ConsoleColor.White;
    if (color == 'c') Console.ForegroundColor = ConsoleColor.Cyan;
    if (color == 'g') Console.ForegroundColor = ConsoleColor.Green;
    if (perevodstroki == 1) Console.WriteLine(TaskText);
    else Console.Write(TaskText);
    Console.ResetColor();
}
int EnterNumber(string name, int Home, int End, char color, int perstr) // Проверка, что число является числом, а не текстом
{                                               // Также проверяется, что число в определенном диапазоне
    int num;                                    // идентификатор цвета и идентификатор перевода строки
    string? number;
    do
    {
        OutTextZadaniya(name, color, perstr);
        number = Console.ReadLine();
        if (!int.TryParse(number, out num) || num < Home || num > End) // Число должно лежать в диапазоне от Home до End
            OutTextZadaniya("Ошибка! Введено некорректное значение. Повторите ввод!", 'r', 1);

    }
    while (!int.TryParse(number, out num) || num < Home || num > End);
    return num;
}
void Zadacha64()
{
    OutTextZadaniya(@"Задайте значение N. Напишите программу,
которая выведет все натуральные числа в промежутке от N до 1.
Выполнить с помощью рекурсии.", 'g', 1);
    // N = 5 -> "5, 4, 3, 2, 1"
    // N = 8 -> "8, 7, 6, 5, 4, 3, 2, 1"
    Console.WriteLine();
    Console.WriteLine("Введите значение N");
    void NaturChisla(int n, int N)
    {
        if (n == N) Console.Write("N = {0} -> [ {1}, ", N, n); // Сначала вывод введённого значения N и первого числа с открытием скобки
        else if (n == 1) Console.WriteLine("{0} ]", n); // Вывод последнего числа, без запятой с закрытием скобки
        else Console.Write("{0}, ", n); // Вывод чисел кроме первого и последнего
        if (n == 1) return;
        else NaturChisla(n - 1, N);
    }
    int N = EnterNumber("N(не более 20) = ", 2, 20, 'w', 0);
    NaturChisla(N, N);
}
void Zadacha66()
{
    OutTextZadaniya(@"Задайте значения M и N. Напишите программу, 
которая найдёт сумму натуральных элементов в промежутке от M до N.", 'g', 1);
    // M = 1; N = 15 -> 120
    // M = 4; N = 8. -> 30
    int SummaNaturChisel(int n, int m)
    {
        if (n == m) return n;
        return n + SummaNaturChisel(n - 1, m);
    }
    Console.WriteLine();
    Console.WriteLine("Введите значение M в диапазоне от [-100] до [100]");
    int M = EnterNumber("M = ", -100, 100, 'w', 0);
    Console.WriteLine("Введите значение N в диапазоне от [-100] до [100]");
    int N = EnterNumber("N = ", -100, 100, 'w', 0);
    if (M > N) OutTextZadaniya($"Сумма натуральных элементов в промежутке от {N} до {M} равна {SummaNaturChisel(M, N)}", 'g', 1);
    else // Проверка какое из введённых чисел меньше и выводим сумму элементов от меньшего к большему
    if (M < N) OutTextZadaniya($"Сумма натуральных элементов в промежутке от {M} до {N} равна {SummaNaturChisel(N, M)}", 'g', 1);
    else OutTextZadaniya("Числа одинаковы", 'r', 1);
}
void Zadacha68()
{
    OutTextZadaniya(@"Напишите программу вычисления функции Аккермана с помощью рекурсии. 
Даны два неотрицательных числа m и n.", 'g', 1);
    // m = 2, n = 3 -> A(m,n) = 9
    // m = 3, n = 2 -> A(m,n) = 29
    int Akkerman(int m, int n)
    {
        if (m == 0) return n + 1;
        if (m > 0 && n == 0) return Akkerman(m - 1, 1);
        if (m > 0 && n > 0) return Akkerman(m - 1, Akkerman(m, n - 1));
        return 1;
    }
    Console.WriteLine();
    Console.WriteLine("Введите значение m в диапазоне от [0] до [3]");
    int M = EnterNumber("m = ", -1, 4, 'w', 0);
    Console.WriteLine("Введите значение n в диапазоне от [0] до [6]");
    int N = EnterNumber("n = ", -1, 7, 'w', 0);
    OutTextZadaniya($"Функция Аккермана для m={M}, n={N} равна {Akkerman(M, N)}", 'g', 1);
}