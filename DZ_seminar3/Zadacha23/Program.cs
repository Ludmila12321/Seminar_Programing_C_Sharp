// Напишите программу, которая принимает на вход число (N) и выдаёт таблицу кубов чисел от 1 до N.
// 3 -> 1, 8, 27
// 5 -> 1, 8, 27, 64, 125
Console.Clear();
Console.WriteLine("Введите N: ");
int N = Convert.ToInt32(Console.ReadLine());
if (N >= 1)
{
    int i = 1;
    while (i <= N)
    {
        if (i < N)
            Console.Write($"{Math.Pow(i, 3)}, ");
        else
            Console.WriteLine($"{Math.Pow(i, 3)}.");
        i++;
    }
}
else Console.WriteLine("Вы ввели неверное число. Повторите заново, число должно быть больше 1");