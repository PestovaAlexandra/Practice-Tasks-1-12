using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_5
{
    class Program
    {
        public static void MakeArray(ref int[] array)
        {
            for (int i = 1; i < 65; i++)
            {
                array[i - 1] = i;
            }
        }
        static void Main(string[] args)
        {
            int n = 8;
            int[] array = new int[64];                                                  //Массив элементов для заполнения матрицы
            int[,] result = new int[8, 8];                                              //Результрующая матрица
            int i = 0, p = 0, e = 0;
            int diagonal = 0;                                                           //Хранит информацию о том, сколько элементов диагональной линии
            int k = 0, j = 0;
            MakeArray(ref array);                                                       //Заполнения массива числами от 1 до 64

            for (j = 0; j < n; j++)                                                     //заполнение пространства до диагонали и диагональ
            {
                if (j % 2 == 0)
                {
                    if (diagonal == 0)                                                  /*первый элемент*/
                    {
                        result[i, 0 + diagonal] = array[k];
                        diagonal++;
                        k++;
                    }
                    else
                    {
                        for (p = 0; p <= diagonal; p++)                                 //заполнение вниз
                        {
                            result[0 + p, j - p] = array[k];
                            k++;
                        }
                        diagonal++;
                    }

                }
                else
                {
                    for (e = 0; e <= diagonal; e++)                                 /*заполнение вверх*/
                    {
                        result[diagonal - e, 0 + e] = array[k];
                        k++;
                    }
                    diagonal++;
                }
            }
            diagonal--;                                                                 //Заполнили диагональ матрицы - самое большое кол-во элементов, теперь количество уменьшается
            for (i = 1; i < n; i++)                                                            //Заполнение второй половины матрицы
            {
                if (i % 2 == 0)
                {
                    if (diagonal == 0)                                                     //конец
                    {
                        result[n, n] = array[k];
                        return;
                    }
                    for (e = 0; e < diagonal; e++)                                             /*заполнение вверх*/
                    {
                        result[i + diagonal - 1 - e, i + e] = array[k];
                        k++;
                    }
                    diagonal--;
                }
                else
                {

                    for (p = 0; p < diagonal; p++)                                       /*заполнение вниз*/
                    {
                        result[i + p, n - 1 - p] = array[k];
                        k++;
                    }
                    diagonal--;
                }

            }
            Console.WriteLine("Матрица, записанная змейкой. Числа от 1 до 64:\n");
            for (i = 0; i < n; i++)                                                     //Вывод матрицы на экран
            {
                for (j = 0; j < n; j++)
                {
                    Console.Write($"{result[i, j]} ");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
