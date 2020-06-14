using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_4
{
    class Program
    {
            static string Degree(string x, int y)
            {
                //объявление переменных
                int thatElem;
                int share = 0;                                                                                                      //Частное от деления на 2

                string result = "";
                for (int i = 0; i < x.Length; i++)                                                                                   //Цикл по текущему числу, записанному без передних нулей
                {
                    thatElem = Convert.ToInt32(share.ToString()) * 10 + Convert.ToInt32(x[i].ToString());                            //идём с начала текущей строки, делим на 2 каждое число
                                                                                                                                     //добавляя целую часть к результату, остаток оставляем для след цикла
                    if (thatElem / 2 == 0)                                                                                               //Если текущее число равно 0
                    {
                        if (i != x.Length)                                                                                             //Если цифры в строке еще не закончились, то 
                        {
                            result += '0';                                                                                          //Фиксируем 0 в результате
                            i++;                                                                                                   //Переходим к следующей цифре строки
                            thatElem = thatElem * 10 + Convert.ToInt32(x[i].ToString());                                            //Увеличиваем элемент на разряд и переходим к следующему
                        }
                        else                                                                                                        //Иначе
                        {
                            thatElem = thatElem * 10;                                                                               //Увеличиваем число на разряд
                        }
                    }
                    share = thatElem % 2;                                                                                           //Остаток от деления на 2
                    result = result + Convert.ToString(thatElem / 2);                                                               //К результату прибавляем результат целочисленного деления на 2 текущего числа
                }

                if (share != 0) result = result + Convert.ToString((share * 10) / 2);                                                  //если остаток != 0, то добавляем остаток в следующую итерацию цикла

                return result;                                                                                                      //возвращаем результат
            }

            static void Main(string[] args)
            {
                const int degree = 200;                                                                                             //константа для 2^(-200)
                int minesSize = 0;                                                                                                  //Разница между нужным кол-вом цифр в числе и текущим
                string str = "5";                                                                                                   //работающая строка. 2 в степени -1 в десятичной форме. берем знаки только после запятой
                for (int i = 2; i <= degree; i++)                                                                                   //цикл для подсчета значения выражения
                    str = Degree(str, 2);

                minesSize = degree - str.Length;                                                                                    //Высчитываем, сколько значимых нулей слева нужно еще добавить
                for (int i = 1; i <= minesSize; i++)                                                                                //Добавление нулей
                    str = '0' + str;
                str = "0." + str;
                int count = str.Length;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("2^(-200) равен");
                Console.ResetColor();
                Console.WriteLine($"{str}");                                                                                        //вывод результата
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nd1*10^(-1)+d2*10^(-2)+...+dn*10^(-n),d1,d2...d9=2^(-200), где d- это цифры от 0 до 9");

                Console.ReadKey();
            }
        }
}
