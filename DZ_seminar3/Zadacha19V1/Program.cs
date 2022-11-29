// Напишите программу, которая принимает на вход пятизначное 
// число и проверяет, является ли оно палиндромом.
// 14212 -> нет
// 12821 -> да
// 23432 -> да
Console.WriteLine("Введите пятизначное число для проверки");
string? n = Console.ReadLine();
if (n?.Length == 5)
{
    if (n.Substring(0, 1) == n.Substring(4, 1) && n.Substring(1, 1) == n.Substring(3, 1))
    Console.WriteLine($"Число {n} является палиндромом");
    else
    Console.WriteLine($"Число {n} не является палиндромом");
}
else Console.WriteLine("Вы ввели неверное число");
