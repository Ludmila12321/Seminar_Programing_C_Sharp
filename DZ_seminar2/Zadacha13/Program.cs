// Задача 13: Напишите программу, которая выводит третью цифру заданного числа или сообщает, что третьей цифры нет.
// 645 -> 5
// 78 -> третьей цифры нет
// 32679 -> 6
Console.WriteLine("Введите число");
string? num = Console.ReadLine();
if (num?.Length >= 3)
{
    if (num.Substring(0, 1) == "-")
    {
        num = num.Substring(3, 1);
        Console.WriteLine(num);
    }
    else
    {
        num = num.Substring(2, 1);
        Console.WriteLine(num);
    }
}
else Console.WriteLine("Третьей цифры нет");
