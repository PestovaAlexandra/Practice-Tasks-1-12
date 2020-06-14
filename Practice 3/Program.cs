using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_3
{
        class Point
        {
            public double x;
            public double y;
            public double X { get; set; }
            public double Y { get; set; }
        }
        class Program
        {
            public static void Point(double x, double y, double x1, double y1, double x2, double y2)
            {
                if (x >= x1 && x <= x2 && y >= y1 && y <= y2)
                    Console.WriteLine($"Точка ({x};{y}) принадлежит заштрихованной области");
                else
                    Console.WriteLine($"Точка ({x};{y}) не принадлежит заштрихованной области");
            }
            static void Main(string[] args)
            {
                Point point = new Point(); /*Объект для координат точки*/

                double x1, x2, y1, y2; /*Переменные для граничных значений области*/
                string str = "";
                string choice = "";

                x1 = -1; x2 = 1; y1 = -1; y2 = 1;
                while (choice != "exit")
                {
                    try
                    {
                        Console.WriteLine("Введите координаты точки");
                        Console.WriteLine("X:");
                        str = Console.ReadLine();
                        while (!(double.TryParse(str, out point.x)))
                        {
                            Console.WriteLine("Введите вещественное число");
                            str = Console.ReadLine();
                        }

                        Console.WriteLine("Y:");
                        str = Console.ReadLine();
                        while (!(double.TryParse(str, out point.y)))
                        {
                            Console.WriteLine("Введите вещественное число");
                            str = Console.ReadLine();
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Ошибка");
                    }
                    Point(point.x, point.y, x1, y1, x2, y2); /*Метод проверяет, входит ли точка в заданную область*/
                    Console.WriteLine("Для завершения программы введите exit. Для продолжения введите любую букву.");
                    choice = Console.ReadLine();
                }

                Console.ReadKey();
            }
        }
    
}
