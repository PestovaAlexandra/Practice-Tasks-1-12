using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_6
{
    class Program
    {
        public static double a1, a2, a3;
        public static void InputDouble(string str, ref double a)                                                //Ввод и проверка ввода для элементов последовательности
        {
            while (!double.TryParse(str, out a))
            {
                Console.WriteLine("Введено не вещественное число. Введите заново.");
                str = Console.ReadLine();
            }
        }
        public static void InputInteger(string str, ref int a)                                                  //Ввод и проверка ввода для значения размера последовательности
        {
            while ((!int.TryParse(str, out a)) || a < 1)
            {
                Console.WriteLine("Введено не натуральное число. Введите заново.");
                str = Console.ReadLine();
            }
        }
        public static double A(int k)                                                                           //Метод, вычисляющий члены последовательности в зависимости от номера
        {
            if (k == 1) return a1;
            if (k == 2) return a2;
            if (k == 3) return a3;
            return ((A(k - 1) + A(k - 2)) / 2 - A(k - 3));
        }
        public static void B(int n, ref double last, ref int count, ref int maxCount, ref double maxLast)
        {                                                                                                       //Основной метод. Находит значения всех членов последовательности, находит возрастающие подпоследовательности,
                                                                                                               //вычисляет длины подпоследовательностей, запоминает последний элемент подпоследовательности,
                                                                                                                //находит длину максмимально длинной возрастающей подпоследовательности
            double member;
            for (int i = 1; i <= n; i++)
            {
                member = A(i);
                Console.Write($"{member} ");
                if (i > 1)
                {
                    if (A(i) > A(i - 1))                                                                            //Определяет, возрастающая ли последователньость
                    {
                        last = A(i);
                        count++;
                        if (maxCount < count)                                                                      //Определяет, максимальная ли по длине последовательность
                        {
                            maxLast = last;
                            maxCount = count;
                        }
                    }
                    else
                    {
                        count = 1;
                    }
                }
            }
            if (maxCount > 1)
                Console.WriteLine($"\nМаксимальная длина возрастающей подпоследовательности {maxCount}." +
                    $" Её последний элемент {maxLast}.");
            else
            {
                Console.WriteLine($"Возрастающих подпоследовательностей нет");
            }
        }
        static void Main(string[] args)
        {
            int n = 0;                                                                                          //кол-во членов последовательности
            int count = 1, maxCount = 0;                                                                          //длина максимальной возрастающей подпоследовательности
            double last = 0, maxLast = 0;
            string choice = "";
            Console.WriteLine("Построение последовательности чисел ак = ( ак–1 + ак-2 ) / 2 –  ак–3.\n" +
                "Приложение строит N элементов последовательности. Определяет длину максимальной возрастающей подпоследовательности.\n" +
                "Печатает последовательность, длину и последний элемент максимальной возрастающей подпоследовательности. ");
            while (choice != "exit")
            {
                count = 1;
                //Ввод первых 3-х членов последовательности
                Console.WriteLine("\nВведите первые 3 члена последовательности");
                Console.WriteLine("a1=");
                InputDouble(Console.ReadLine(), ref a1);

                Console.WriteLine("a2=");
                InputDouble(Console.ReadLine(), ref a2);

                Console.WriteLine("a3=");
                InputDouble(Console.ReadLine(), ref a3);

                //Ввод количества выводимых членов последовательности 
                Console.WriteLine("Введите длину последовательности");
                InputInteger(Console.ReadLine(), ref n);

                Console.WriteLine($"Последовательность из {n} элементов: ");
                B(n, ref last, ref count, ref maxCount, ref maxLast);

                Console.WriteLine("\nДля выхода из программы введите \"exit\". " +
                    "Чтобы продолжить программу, введите любую букву или цифру.");
                choice = Console.ReadLine();
            }


        }
    }
}
