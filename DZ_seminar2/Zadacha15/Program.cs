// Задача 15: Напишите программу, которая принимает на вход цифру, обозначающую день недели, и проверяет, является ли этот день выходным.
// 6 -> да
// 7 -> да
// 1 -> нет
link1:
Console.WriteLine("Введите номер дня недели");
int num = Convert.ToInt32(Console.ReadLine());
if (1 <= num && num <= 7)
    if (num == 6 || num == 7)
        Console.WriteLine("Отдыхай, выходной!");
    else
        Console.WriteLine("Работай, солнце ещё высоко!");
else
{
    Console.WriteLine("Такого номера дня недели не существует");
    goto link1;
}