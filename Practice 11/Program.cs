using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_11
{
    class Program
    {
        public static int Input(out int a, int down, int up)                                                            //Проверка ввода натурального числа
        {
            a = 0;
            bool ok = true;
            do
            {
                if (!ok)
                    Console.WriteLine($"Ошибка. Введите натуральное число от 1 до бесконечности");

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
                    Console.WriteLine($"Ошибка. Введите натуральное число от 1 до бесконечности");
                }
            } while (!ok || a < down || a > up);
            return a;
        }
        public static string Solution(int n, string RusString, char[] alphabetSmall,
            char[] alphabetBig, CircularList circularListSmall, CircularList circularListBig)                           //Метод для замены символов входной строки на символы того же алфавита со сдвигом n
        {
            string result = "";                                                                                         //Переменная для хранения зашифрованной строки
            char temp;                                                                                                  //Переменная для хранения текущего символа строки

            for (int i = 0; i < RusString.Length; i++)                                                                  //Перебор символов входной строки
            {
                temp = RusString[i];                                                                                    //Фиксация текущего символа
                if (alphabetBig.Contains(temp))                                                                         //Если символ входит в множество заглавных букв
                {
                    circularListBig.Ecrypt(n, temp, ref result);                                                         //Замена символа происходит с помощью списка с заглавными буквами
                }
                else
                    if (alphabetSmall.Contains(temp))                                                                   //Если символ входит в множество прописных букв
                {
                    circularListSmall.Ecrypt(n, temp, ref result);                                                      //Замена символа происходит с помощью списка с прописными буквами
                }
                else                                                                                                    //Если символ является не буквой
                {
                    result += temp;                                                                                     //Замена не происходит
                }
            }
            return result;
        }
        public static string SolutionBack(int n, string RusString, char[] alphabetSmall,
            char[] alphabetBig, CircularList circularListSmall, CircularList circularListBig)                           //Метод для замены символов входной строки на символы того же алфавита со сдвигом n
        {
            string result = "";                                                                                         //Переменная для хранения зашифрованной строки
            char temp;                                                                                                  //Переменная для хранения текущего символа строки

            for (int i = 0; i < RusString.Length; i++)                                                                  //Перебор символов входной строки
            {
                temp = RusString[i];                                                                                    //Фиксация текущего символа
                if (alphabetBig.Contains(temp))                                                                         //Если символ входит в множество заглавных букв
                {
                    circularListBig.EcryptBack(n, temp, ref result);                                                         //Замена символа происходит с помощью списка с заглавными буквами
                }
                else
                    if (alphabetSmall.Contains(temp))                                                                   //Если символ входит в множество прописных букв
                {
                    circularListSmall.EcryptBack(n, temp, ref result);                                                      //Замена символа происходит с помощью списка с прописными буквами
                }
                else                                                                                                    //Если символ является не буквой
                {
                    result += temp;                                                                                     //Замена не происходит
                }
            }
            return result;
        }

        static void Main(string[] args)
        {
            char[] alphabetSmall = {'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л',
                'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я' };   //Массив символов для букв русского алфавита
            char[] alphabetBig = { 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И', 'Й', 'К', 'Л',
                'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ', 'Ы', 'Ь', 'Э', 'Ю', 'Я' };   //Массив символов для букв русского алфавита
            string RusString = "";                                                                                      //Входная строка
            int n = 0;                                                                                                  //Сдвиг
            int i, j;
            string result = "", choice = "";                                                                              //Зашифрованная выходная строка, выбор пользователя о продолжении программы

            CircularList circularListSmall = new CircularList();                                                        //Создание кругового списка для хранения прописных букв русского алфавита 

            for (i = 0; i < alphabetSmall.Length; i++)
            {
                circularListSmall.Add(alphabetSmall[i]);                                                                //Заполнение списка
            }

            CircularList circularListBig = new CircularList();                                                          //Создание кругового списка для хранения заглавных букв русского алфавита 

            for (i = 0; i < alphabetBig.Length; i++)
            {
                circularListBig.Add(alphabetBig[i]);                                                                    //Заполнение списка
            }

            while (choice != "exit")                                                                                    //Пока не введена команда для завершения работы программы
            {
                Console.WriteLine("Добро пожаловать. Приложение зашифровывает текст, записанный с помощью русских букв, знаков препинания и других символов.\n" +
                    "Заменяются буквы, символы остаются без изменений");

                Console.WriteLine("Введите длину сдвига");
                Input(out n, 1, 10000);                                                                                 //Ввод размера сдвига по алфавиту

                Console.WriteLine("Введите текст для шифрования");
                RusString = Console.ReadLine();                                                                         //Ввод строки, которую нужно зашифровать


                result = Solution(n, RusString, alphabetSmall, alphabetBig, circularListSmall, circularListBig);        //Вызов функции для начала процесса шифрования
                Console.WriteLine("Зашифрованный текст");
                Console.WriteLine(result);
                Console.WriteLine("Расшифрованный текст");
                result = SolutionBack(n, result, alphabetSmall, alphabetBig, circularListSmall, circularListBig);        //Вызов функции для начала процесса шифрования
                Console.WriteLine(result);

                Console.WriteLine
                    ("Для выхода из программы введите \"exit\". Для продолжения программы введите любую букву.");

                choice = Console.ReadLine();                                                                            //Ввод решения пользователя о продолжении работы в прогамме

            }
            //Завершение работы программы
        }
    }
}
