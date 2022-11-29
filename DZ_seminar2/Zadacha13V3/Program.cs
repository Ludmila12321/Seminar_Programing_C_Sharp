// Задача 13: Напишите программу, которая выводит третью цифру заданного числа или сообщает, что третьей цифры нет.
// 645 -> 5
// 78 -> третьей цифры нет
// 32679 -> 6
Console.WriteLine("Введите число");
int num = Math.Abs(Convert.ToInt32(Console.ReadLine()));
if (num > 99) {   int r = 1; int c = num / 10;
    while (c != 0)
    {  r++; c = c / 10;  } 
    num = num / Convert.ToInt32(Math.Pow(10, r - 3));
    Console.WriteLine($"Третья цифра: {num % 10}"); }
else Console.WriteLine("Третьей цифры нет");
