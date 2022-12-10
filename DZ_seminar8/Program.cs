// Семинар 8 ДЗ
Console.Clear();
Console.WriteLine("Здравствуйте, Алексей!");
Console.WriteLine("В данной домашней работе представлены задачи 54, 56, 58, 59, 60, 61, 62");
RepeatTask:
int NumberTask = Convert.ToInt32(EnterNumber
(@"Введите номер задачи для проверки: [ 54 ], [ 56 ], [ 58 ], [ 59 ], [ 60 ], [ 61 ], [ 62 ]. 
Или нажмите [ 0 ] для выхода из программы.
Ваш выбор = ", -1, 100));
Console.Clear();
switch (NumberTask)
{
    case 0:
        OutTextZadaniya("До свидания, Алексей!", 'g');
        break;
    case 54:
        Zadacha54();
        PauseAndClear();
        goto RepeatTask;
    case 56:
        Zadacha56();
        PauseAndClear();
        goto RepeatTask;
    case 58:
        Zadacha58();
        PauseAndClear();
        goto RepeatTask;
    case 59:
        Zadacha59();
        PauseAndClear();
        goto RepeatTask;
    case 60:
        Zadacha60();
        PauseAndClear();
        goto RepeatTask;
    case 61:
        Zadacha61();
        PauseAndClear();
        goto RepeatTask;
    case 62:
        Zadacha62();
        PauseAndClear();
        goto RepeatTask;
    default:
        OutTextZadaniya("Увы, такой задачи нет =(", 'r');
        PauseAndClear();
        goto RepeatTask;
}
void PauseAndClear()
{
    Console.WriteLine();
    Console.WriteLine("Нажмите любую кнопку для продолжения");
    Console.ReadKey();
    Console.Clear();
}
void OutTextZadaniya(string TaskText, char color)
{
    if (color == 'r') Console.ForegroundColor = ConsoleColor.Red;
    else Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(TaskText);
    Console.ResetColor();
}
int EnterNumber(string name, int Home, int End) // Проверка, что число является числом, а не текстом
{                                      // Также проверяется, что число не меньше определённого предела
    int num;
    string? number;
    do
    {
        Console.Write(name);
        number = Console.ReadLine();
        if (!int.TryParse(number, out num) || num <= Home || num >= End) // Число не должно быть меньше или равно lim
            OutTextZadaniya("Ошибка! Введено некорректное значение. Повторите ввод!", 'r');

    }
    while (!int.TryParse(number, out num) || num <= Home || num >= End);
    return num;
}
void FillMass(int[,] matrix, int k)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
        for (int j = 0; j < matrix.GetLength(1); j++)
            if (k == 0) matrix[i, j] = 0;
            else matrix[i, j] = new Random().Next(k);
}
void PrintMass(int[,] matrix, int cellwidth)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
            if (NumberTask == 61 && matrix[i, j] == 0) Console.Write("".PadLeft(cellwidth)); // Выравнивание по правому краю 
            else Console.Write($"{matrix[i, j]}".PadLeft(cellwidth));                          // с заданной шириной поля
        Console.WriteLine();
    }
}
void Zadacha54()
{
    OutTextZadaniya(@"Задача 54: Задайте двумерный массив. Напишите программу, которая 
упорядочит по убыванию элементы каждой строки двумерного массива.", 'g');
    Console.WriteLine();
    Console.WriteLine("Введите размерность массива");
    int m = EnterNumber("m(не более 20) = ", 0, 21);
    int n = EnterNumber("n(не более 30) = ", 0, 31);
    int[,] matrix = new int[m, n];
    FillMass(matrix, 100); // Заполняем массив
    Console.WriteLine("Заданный массив:");
    PrintMass(matrix, 3); // Выводим начальный массив на консоль
    for (int i = 0; i < m; i++)
        for (int j = 0; j < n - 1; j++)
            for (int k = j + 1; k < n; k++)
                if (matrix[i, k] > matrix[i, j])
                {
                    int temp = matrix[i, j];
                    matrix[i, j] = matrix[i, k]; // Перестановка элементов по убыванию
                    matrix[i, k] = temp;
                }
    Console.WriteLine("Полученный массив:  ");
    PrintMass(matrix, 3); // Выводим полученный массив
}
void Zadacha56()
{
    OutTextZadaniya(@"Задача 56: Задайте прямоугольный двумерный массив. 
Напишите программу, которая будет находить строку с наименьшей суммой элементов.", 'g');
    Console.WriteLine();
    Console.WriteLine("Введите размерность массива");
    int m = EnterNumber("m(не более 20) = ", 0, 21);
    int n = EnterNumber("n(не более 30) = ", 0, 31);
    int[,] matrix = new int[m, n];
    FillMass(matrix, 10); // Заполняем массив
    Console.WriteLine("Заданный массив:");
    PrintMass(matrix, 2); // Выводим заданный массив
    int index = 0; // Переменная для запоминания номера строки
    int min = 100000; // Минимальное значение заранее задаём очень большим
    for (int i = 0; i < m; i++)
    {                          // цикл проходит каждую строку и каждый столбец
        int sum = 0;
        for (int j = 0; j < n; j++)
            sum += matrix[i, j]; // Сумма элементов текущей строки
        if (sum < min) // Сравниваем текущую сумму с минимальной
        {              // и если она меньше
            min = sum; // Запоминаем минимальную сумму
            index = i; // Запоминаем номер строки с минимальной суммой
        }
    }
    Console.WriteLine($"С наименьшей суммой строка {index + 1}"); // Выводим строку, считаем с 1
}
void Zadacha58()
{
    OutTextZadaniya(@"Задача 58: Задайте две матрицы. 
Напишите программу, которая будет находить произведение двух матриц.", 'g');
    Console.WriteLine();
    Console.WriteLine("Введите размерность первой матрицы");
    int m = EnterNumber("m(не более 20) = ", 0, 21);
    int n = EnterNumber("n(не более 30) = ", 0, 31);
    Console.WriteLine("Введите размерность второй матрицы");
    int m1 = EnterNumber("m1(не более 20) = ", 0, 21);
    int n1 = EnterNumber("n1(не более 30) = ", 0, 31);
    int[,] matrix = new int[m, n];
    FillMass(matrix, 5);
    Console.WriteLine("Первая матрица:");
    PrintMass(matrix, 2);
    int[,] matrix1 = new int[m1, n1];
    FillMass(matrix1, 5);
    Console.WriteLine("Вторая матрица:");
    PrintMass(matrix1, 2);
    if (n != m1) OutTextZadaniya("Произведение матриц не может быть найдено", 'r'); // Проверка того, что произведение
    else
    {
        int[,] Rezultmatrix = new int[m, n1]; // Результирующая матрица            //   матриц существует n=m1
        for (int i = 0; i < m; i++)
            for (int j = 0; j < n1; j++)
                for (int k = 0; k < m1; k++)
                {
                    Rezultmatrix[i, j] += matrix[i, k] * matrix1[k, j];
                }
        Console.WriteLine("Результирующая матрица:  ");
        PrintMass(Rezultmatrix, 3);
    }
}
void Zadacha59()
{
    OutTextZadaniya(@"Задача 59. Задайте двумерный массив из целых чисел. 
Напишите программу, которая удалит строку и столбец, на пересечении 
которых расположен наименьший элемент массива.", 'g');
    Console.WriteLine();
    Console.WriteLine("Введите размерность массива");
    int m = EnterNumber("m(не более 20) = ", 0, 21);
    int n = EnterNumber("n(не более 30) = ", 0, 31);
    int[,] matrix = new int[m, n];
    FillMass(matrix, 10);
    Console.WriteLine("Заданный массив:");
    PrintMass(matrix, 2);
    int index1 = 0; // Переменная для запоминания строки с наименьшим элементом
    int index2 = 0; // Переменная для запоминания столбца с наименьшим элементом
    int min = 100000; // Минимальное значение заранее делаем очень большим
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
            if (matrix[i, j] < min) // Сравниваем текущий элемент массива с минимумом
            {
                min = matrix[i, j]; // Если меньше записываем в min
                index1 = i; // Запоминаем строку с наименьшим элементом
                index2 = j; // Запоминаем столбец с наименьшим элементом
            }
    }
    Console.WriteLine($"Минимальный элемент равный {min} находится в {index1 + 1}-й строке, {index2 + 1}-м столбце");
    Console.WriteLine("Вариант частичного вывода заданного массива");
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
            if ((i < index1 || i > index1) && (j < index2 || j > index2)) Console.Write($"{matrix[i, j]}".PadLeft(2));
        if (i != index1) Console.WriteLine();
    }
    Console.WriteLine("Вариант с формированием нового массива");
    int[,] Obrezanniymassiv = new int[m - 1, n - 1];
    for (int i = 0; i < m - 1; i++)
    {
        for (int j = 0; j < n - 1; j++)
        {
            Obrezanniymassiv[i, j] = matrix[i, j];
            if (i >= index1) Obrezanniymassiv[i, j] = matrix[i + 1, j];
            if (j >= index2) Obrezanniymassiv[i, j] = matrix[i, j + 1];
            if ((j >= index2) && (i >= index1)) Obrezanniymassiv[i, j] = matrix[i + 1, j + 1];
        }
    }
    PrintMass(Obrezanniymassiv, 2);
}
void Zadacha60()
{
    OutTextZadaniya(@"Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. 
Напишите программу, которая будет построчно выводить массив, 
добавляя индексы каждого элемента.", 'g');
    Console.WriteLine();
    Console.WriteLine("Введите размерность массива");
    int m = EnterNumber("m(не более 5) = ", 0, 6);
    int n = EnterNumber("n(не более 5) = ", 0, 6);
    int l = EnterNumber("l(не более 5) = ", 0, 6);
    int[,,] matrix = new int[m, n, l];
    int[] arr = new int[100]; // В этот массив записываем числа, которые потом сверяем с вновь записываемыми в массив
    for (int i = 0; i < matrix.GetLength(0); i++)
        for (int j = 0; j < matrix.GetLength(1); j++)
            for (int k = 0; k < matrix.GetLength(2); k++)
            {
                int temp;
                do temp = new Random().Next(10, 100);
                while (arr[temp] != 0); // Проверка, чтобы не использовать число повторно
                matrix[i, j, k] = temp;
                arr[temp] = temp;
            }
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            for (int k = 0; k < matrix.GetLength(2); k++)
                Console.Write($"{matrix[i, j, k]} ({i},{j},{k}) ");
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}
void Zadacha61()
{
    OutTextZadaniya(@"Задача 61. Вывести первые N строк треугольника Паскаля. 
Сделать вывод в виде равнобедренного треугольника.", 'g');
    Console.WriteLine();
    Console.WriteLine("Введите N для треугольника Паскаля");
    int N = EnterNumber("N(не более 20) = ", 1, 21);
    int m = N + 1;
    int n = N * 2 + 1;
    int[,] matrix = new int[m, n];
    FillMass(matrix, 0);
    matrix[0, N] = 1; // Верхушка треугольника 1
    for (int i = 1; i < m; i++)
        for (int j = 0; j < n; j++)
            if (j - 1 < 0) matrix[i, j] = matrix[i - 1, j + 1]; // Условие, если выходит за массив слева
            else if (j + 1 >= n) matrix[i, j] = matrix[i - 1, j - 1]; // Условие, если выходит за массив справа
                 else matrix[i, j] = matrix[i - 1, j - 1] + matrix[i - 1, j + 1]; // Расчёт: сумма двух верхних чисел
    if (N<5) PrintMass(matrix, 1);
    else if (N<9) PrintMass(matrix, 2);
    else if (N<13) PrintMass(matrix, 3);
    else PrintMass(matrix, 4);
}
void Zadacha62()
{
    OutTextZadaniya(@"Задача 62. Напишите программу, 
которая заполнит спирально массив 4 на 4.", 'g');
    Console.WriteLine();
    void FillMassiveSnake(int[,] mass, int i, int j, int n, int m)
    {
        int count = 0;
        Snake(i, j);
        void Snake(int i, int j)
        {
            if (i < n && i >= 0 && j < m && j >= 0 && mass[i, j] == 0)
            {
                count++;
                mass[i, j] = count;
                if (i - 1 < 0 || mass[i - 1, j] != 0) Snake(i, j + 1);
                Snake(i + 1, j);
                Snake(i, j - 1);
                Snake(i - 1, j);
            }
        }
    }
    string TextChoiceRow = "Введите количество строчек массива от [2] до [20]. n = ";
    string TextChoiceCol = "Введите количество столбцов массива от [2] до [30]. m = ";
    int n = EnterNumber(TextChoiceRow, 2, 21);
    int m = EnterNumber(TextChoiceCol, 2, 31);
    int[,] array = new int[n, m];
    FillMassiveSnake(array, 0, 0, n, m);
    Console.WriteLine("Заполненный змейкой массив:");
    PrintMass(array, 3);
}