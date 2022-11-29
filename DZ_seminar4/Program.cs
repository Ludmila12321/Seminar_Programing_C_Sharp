// Семинар 4 ДЗ
Console.Clear();
Console.WriteLine("Здравствуйте, Алексей!");
link1:
Console.WriteLine("Введите номер задачи, функциональность которой вы хотели бы проверить");
Console.WriteLine("Или нажмите 0 для выхода из программы");
int n = Convert.ToInt32(Console.ReadLine());
switch (n)
{
    case 0:
        Console.WriteLine("До свидания, Алексей!");
        break;
    case 25:
        Console.Clear();
        Zadacha25();
        PauseAndClear();
        goto link1;
    case 27:
    Console.Clear();
        Zadacha27();
        PauseAndClear();
        goto link1;
    case 29:
    Console.Clear();
        Zadacha29();
        PauseAndClear();
        goto link1;
    default:
    Console.Clear();
        Console.WriteLine("Увы, такой задачи нет(");
        PauseAndClear();
        goto link1;
}
void PauseAndClear()
{
    Console.WriteLine("Нажмите любую кнопку для продолжения");
    Console.ReadKey();
    Console.Clear();
}
void Zadacha25()
{
    Console.WriteLine("Задача 25: Напишите цикл, который принимает на вход два числа (A и B)");
    Console.WriteLine("и возводит число A в натуральную степень B.");
    // 3, 5 -> 243 (3⁵)
    // 2, 4 -> 16
    int EnterNumber(string number) //Проверка является ли введённое значение числом
    {
        int num;
    Link1: //Метка возвращения в случае ошибочного ввода
        Console.WriteLine($"Введите число {number}");
        string? n = Console.ReadLine();
        if (int.TryParse(n, out num) == false)
        {
            Console.WriteLine($"Значение не является числом, начните заново");
            goto Link1;
        }
        return num;
    }
    int A = EnterNumber("A");
    int B = EnterNumber("B");
    int result = A;
    for (int i = 1; i < B; i++)
    {
        result *= A;
    }
    if (B < 1)
        Console.WriteLine($"{B} не является натуральной степенью, это противоречит условию задачи");
    else Console.WriteLine($"Число {A} возведённое в степень {B} равно: {result}");
}
void Zadacha27()
{
    Console.WriteLine("Задача 27: Напишите программу, которая принимает на вход число и выдаёт сумму цифр в числе.");
    // 452 -> 11
    // 82 -> 10
    // 9012 -> 12
    string EnterNumber() //Проверка является ли введённое значение числом
    {
        int num;
    Link1: //Метка возвращения в случае ошибочного ввода
        Console.WriteLine("Введите число");
        string? n = Console.ReadLine();
        if (int.TryParse(n, out num) == false)
        {
            Console.WriteLine("Значение не является числом, начните заново");
            goto Link1;
        }
        return n;
    }
    string A = EnterNumber(); // Вызов метода введения и проверки числа
    int Sum = 0;
    if (A[0] == '-') // Сумма цифр в случае отрицательного числа
    {
        for (int i = 2; i < A.Length; i++)
            Sum = Sum + Convert.ToInt32(A[i].ToString());
        Sum = Sum - Convert.ToInt32(A[1].ToString());
    }
    else // Сумма цифр в случае положительного числа
        for (int i = 0; i < A.Length; i++)
            Sum = Sum + Convert.ToInt32(A[i].ToString());
    Console.WriteLine($"Сумма цифр в числе равна {Sum}");
}
void Zadacha29()
{
    Console.WriteLine("Задача 29: Напишите программу, которая задаёт массив и выводит их на экран.");
    // 1, 2, 5, 7, 19 -> [1, 2, 5, 7, 19]
    // 6, 1, 33 -> [6, 1, 33]
    int EnterNumber(string text) //Проверка является ли введённое значение числом
    {
        int num;
    Link1: //Метка возвращения в случае ошибочного ввода
        Console.WriteLine(text);
        string? n = Console.ReadLine();
        if (int.TryParse(n, out num) == false)
        {
            Console.WriteLine("Значение не является числом, начните заново");
            goto Link1;
        }
        return num;
    }
    int SizeMass = EnterNumber("Введите размер массива");
    Console.WriteLine("Каким образом заполнять массив?");
    int Vybor = EnterNumber("Нажмите 1 для заполнения массива вручную или 2 для заполнения случайными числами");
    if (Vybor != 1 && Vybor != 2)
        do
        {

            Console.WriteLine("Выбор не понятен");
            Vybor = EnterNumber("Нажмите 1 для заполнения массива вручную или 2 для заполнения случайными числами");
        }
        while (Vybor != 1 && Vybor != 2);
    int[] mass = new int[SizeMass];
    if (Vybor == 1)
        for (int i = 0; i < SizeMass; i++)
            mass[i] = EnterNumber($"Введите {i + 1}-й элемент массива");
    else
        for (int i = 0; i < SizeMass; i++)
            mass[i] = new Random().Next(0, 100);
    Console.Write("Полученный массив: ");
    Console.Write("[");
    for (int i = 0; i < SizeMass - 1; i++)
        Console.Write(" " + mass[i] + ",");
    Console.WriteLine(" " + mass[SizeMass - 1] + " ]");
}
