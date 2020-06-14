using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Practice_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 0, y = 0, a = 0;                                                          //Переменные для хранения размеров рамки и длины плитки

            string str;                                                                 //Строка для считывания строки из файла
            string result = "";                                                           //Строка для вывода результата
            int k;                                                                      //кол-во тестов
            string[] array = new string[3];                                           //Массив для разбиения строки на "X", "Y", "A-размер плитки"
            bool ok = true;
            Console.WriteLine("Задача \"Рамка из клеток\"");
            using (StreamReader fIn = new StreamReader("INPUT.TXT"))                    //Открытие файла
            {
                try
                {
                    k = int.Parse(fIn.ReadLine());                                      //Считывание информации из файла

                    for (int i = 0; i < k; i++)
                    {
                        str = fIn.ReadLine();
                        array = str.Split(' ');

                        x = int.Parse(array[0]);                                        //Считывание информации из файла
                        y = int.Parse(array[1]);
                        a = int.Parse(array[2]);
                        if (a < 1 || y < 1 || x < 3)
                        {
                            ok = false;
                            return;
                        }
                        if (a < 3 || x % a == 1 && y % a == 1 ||                        //Если удовлетворяет условиям
                            x % a == 0 && y % a == 2 || x % a == 2 && y % a == 0)
                            result += '1';                                              //То записывается в результат 1
                        else result += '0';                                             //Если не удовлетворяет условиям, то 0
                    }
                    if (!ok) return;
                }
                catch (FormatException)
                {

                    Console.WriteLine("Некорректный ввод данных.");
                }
            }

            using (StreamWriter fOut = new StreamWriter("OUTPUT.TXT"))                  //Запись в файл
            {
                fOut.WriteLine(result);
            }
            Console.WriteLine("Результат работы программы записан в файл OUTPUT.txt");
            Console.ReadKey();
        }
    }
}
