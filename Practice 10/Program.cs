using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_10
{
    class Program
    {
        public static Random rnd = new Random();
        public static void InputInteger(string str, ref int a)                                                          //Ввод и проверка ввода для значения размера последовательности
        {
            while ((!int.TryParse(str, out a)) || a < 1)                                                                //Пока введено не натуральное число
            {
                Console.WriteLine("Введено не натуральное число. Введите заново.");
                str = Console.ReadLine();
            }
        }
        public static double InputDouble(string str)                                                                    //Ввод и проверка ввода для элементов последовательности
        {
            double a;
            while (!double.TryParse(str, out a))                                                                        //Пока введено невещественное число
            {
                Console.WriteLine("Введено не вещественное число. Введите заново.");
                str = Console.ReadLine();
            }
            return a;
        }
        public static double DoubleRamdom()                                                                             //Ввод одного из элемента последовательности с помощью датчика случайных чисел
        {
            double a;
            a = rnd.NextDouble() * rnd.Next(-10, 10);
            return a;
        }
        static int Input(out int a, int down, int up)                                                                   //Ввод натурального числа в пределах от down до up
        {
            a = 0;
            bool ok = true;
            do
            {
                try
                {
                    a = int.Parse((Console.ReadLine()));
                    if (a < 0)
                    {
                        ok = false;
                    }
                }
                catch
                {
                    Console.WriteLine("Введите натуральное число от 1 до 2");
                }
            } while (!ok || a < down || a > up);
            return a;
        }
        static void Main(string[] args)
        {
            int n = 0;
            double[] x = new double[0];
            double temp = 0;
            int choice = 0, i = 0;
            string exit = "";

            while (exit != "exit")
            {

                Console.WriteLine("Программа выполняет вычисление выражения " +
                    "(x_1 + x_2 + 2x_n)(x_2 + x_3 + 2x_n)*…* (x_n-1 + x_n + 2x_n) ");
                Console.WriteLine("Сначала введите количество элементов списка- n");
                InputInteger(Console.ReadLine(), ref n);                                                                //Ввод элементов списка
                Console.WriteLine("Создание списка.\n1. Вручную 2. С помощью датчика случайных чисел");
                Input(out choice, 1, 3);                                                                                //Выбор: ввести список вручную или датчиком случайных чисел
                switch (choice)
                {
                    case 1:                                                                                             //Ввод вещественных чисел вручную
                        {
                            Console.WriteLine("Введите элементы списка");
                            x = new double[n];

                            for (i = 0; i < n; i++)                                                                     //Ввод чисел
                            {
                                Console.WriteLine($"x{i + 1}=");
                                x[i] = InputDouble(Console.ReadLine());                                                 //Проверка на корректность ввода
                            }
                            Console.WriteLine("Вещественные числа x1, x2, x3, ..., xn:");
                            for (i = 0; i < n; i++)
                            {
                                Console.Write($"{x[i]} ");                                                              //Вывод полученного массива на экран
                            }
                        }
                        break;
                    case 2:                                                                                             //Ввод вещественных чисел с помощью ДСЧ
                        {
                            x = new double[n];

                            for (i = 0; i < n; i++)
                            {
                                x[i] = DoubleRamdom();                                                                  //Ввод случайных вещественных  чисел
                            }

                            Console.WriteLine($"Список размера {n} создан");

                            Console.WriteLine("Вещественные числа x1, x2, x3, ..., xn:");
                            for (i = 0; i < n; i++)
                            {
                                Console.Write($"{x[i]} ");                                                              //Вывод на экран
                            }
                        }

                        break;
                }

                biList item = new biList();                                                                             //создание двунаправленного линейного списка
                item.Create(n, x);
                //item.WriteList();
                item.Сalculation(n);                                                                                     //Вычисление заданного выражения

                Console.WriteLine("Для завершения работы приложения введите exit." +
                    " Чтобы продлжить, введите любую цифру.");
                exit = Console.ReadLine();
            }

        }
    }
}
