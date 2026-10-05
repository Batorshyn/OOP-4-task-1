using System;
using System.IO;

Console.OutputEncoding = System.Text.Encoding.UTF8;

int choice = -1;
while (choice != 0)
{
    Console.WriteLine("1. Ввести масив з клавіатури");
    Console.WriteLine("2. Зчитати з файлу (D:\\Нова папка\\ООП\\Приклади\\dat.txt)");
    Console.WriteLine("3. Випадкові числа");
    Console.WriteLine("0. Вийти");
    Console.Write("Ваш вибір: ");

    choice = Convert.ToInt32(Console.ReadLine());

    if (choice == 0)
    {
        break;
    }

    int n = 0;
    double[] a = null;

    switch (choice)
    {
        case 1:
            Console.Write("Введіть розмір масиву N: ");
            n = Convert.ToInt32(Console.ReadLine());
            a = new double[n];
            Console.WriteLine("Введіть " + n + " елементів:");
            for (int i = 0; i < n; i++)
            {
                a[i] = Convert.ToDouble(Console.ReadLine());
            }
            break;

        case 2:
            string[] lines = File.ReadAllLines("D:\\Нова папка\\ООП\\Приклади\\dat.txt");
            n = lines.Length;
            a = new double[n];
            for (int i = 0; i < n; i++)
            {
                a[i] = Convert.ToDouble(lines[i]);
            }
            Console.WriteLine("Масив зчитано з файлу.");
            break;

        case 3:
            Console.Write("Введіть розмір масиву N: ");
            n = Convert.ToInt32(Console.ReadLine());
            a = new double[n];
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
            {
                a[i] = 50 - rnd.Next(1, 101);
            }
            Console.WriteLine("Масив згенеровано випадковими числами.");
            break;

        default:
            Console.WriteLine("\nСпробуйте ще раз.\n");
            continue;
    }

    Console.WriteLine("\nВаш масив:");
    for (int i = 0; i < n; i++)
    {
        Console.Write(a[i] + "  ");
    }
    Console.WriteLine();

    int pos = CountPositive(a, 0);
    int neg = CountNegative(a, 0);
    double sum = CalculateSum(a, 0);
    double avg = n > 0 ? sum / n : 0;

    Console.WriteLine("\n--- Результати ---");
    Console.WriteLine("Кількість додатних чисел: " + pos);
    Console.WriteLine("Кількість від'ємних чисел: " + neg);
    Console.WriteLine("Середнє арифметичне: " + avg);
    Console.WriteLine();
}

static int CountPositive(double[] a, int index)
{
    if (index >= a.Length) return 0;
    return (a[index] > 0 ? 1 : 0) + CountPositive(a, index + 1);
}

static int CountNegative(double[] a, int index)
{
    if (index >= a.Length) return 0;
    return (a[index] < 0 ? 1 : 0) + CountNegative(a, index + 1);
}

static double CalculateSum(double[] a, int index)
{
    if (index >= a.Length) return 0;
    return a[index] + CalculateSum(a, index + 1);
}