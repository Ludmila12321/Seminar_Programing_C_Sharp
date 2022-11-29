// Задача 10: Напишите программу, которая принимает на вход трёхзначное число и на выходе показывает вторую цифру этого числа.
// 456 -> 5
// 782 -> 8
// 918 -> 1
Console.WriteLine("Введите трёхзначное число");
int num = Math.Abs(Convert.ToInt32(Console.ReadLine()));
while (num < 100 || num > 1000)
{
    Console.WriteLine("Число не трехзначное, повторите ввод");
    num = Math.Abs(Convert.ToInt32(Console.ReadLine()));
}
int d1 = num / 100;
int result = (num - d1 * 100) / 10;
Console.WriteLine($"Вторая цифра числа: {result}");