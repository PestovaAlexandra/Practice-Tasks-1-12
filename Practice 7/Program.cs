using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_7
{
    class Program
    {
        public static void InputDouble(string str, ref double a)                                                                //Ввод и проверка ввода для частот элементов последовательности
        {
            while (!double.TryParse(str, out a))
            {
                Console.WriteLine("Введено не вещественное число. Введите частоту заново.");
                str = Console.ReadLine();
            }
        }
        public static void InputInteger(string str, ref int a)                                                                  //Ввод и проверка ввода для значения размера последовательности
        {
            while ((!int.TryParse(str, out a)) || a < 1)
            {
                Console.WriteLine("Введено не натуральное число. Введите заново.");
                str = Console.ReadLine();
            }
        }
        public static void InputChar(string str, ref char a)                                                                    //Ввод и проверка ввода для элементов последовательности
        {
            while (!char.TryParse(str, out a))
            {
                Console.WriteLine("Введен не символ. Введите символ заново.");
                str = Console.ReadLine();
            }
        }
        public static void print(Node root, int l = 0)                                                                            //Метод для печати на экран дерева для построяния кодов Хаффмана
        {
            if (root != null)
            {
                print(root.right, l + 3);                                                                                       //переход к правому поддереву
                                                                                                                                //формирование отступа
                for (int i = 0; i < l; i++) Console.Write("  ");
                if (root.symbol != '\0') Console.WriteLine($"{root.periodicity.ToString()} ({root.symbol})");                   //печать узла
                else Console.WriteLine(root.periodicity);
                print(root.left, l + 3);                                                                                          //переход к левому поддереву
            }
        }
        static string code = "";                                                                                                //Строка для записи кода очередного символа
        static Dictionary<char, string> table = new Dictionary<char, string>();                                                  //Колеекция для хранения символов и их кодировок
        public static void BuildTable(Node root)                                                                                //Метод для построения двоичных кодировок для алфавита символов
        {
            if (root.left != null)
            {
                code += '0';                                                                                                      //При спуске в левое поддеверо прибавляем 0
                BuildTable(root.left);                                                                                          //Спуск в левое поддерево
            }
            if (root.right != null)
            {
                code += '1';                                                                                                      //При спуске в правое поддерево прибавляем 1
                BuildTable(root.right);                                                                                         //Спуск в правое поддерево
            }
            if (root.symbol != '\0') table[root.symbol] = code;                                                                 //Если дошли до листа, у которого в информационном поле записан символ, запоминаем полученный код

            if (code.Length > 0) code = code.Remove(code.Length - 1);                                                              //Условие для продолжения работы метода
        }
        static void Main(string[] args)
        {
            int n = 0;                                                                                                          //Длина входного алфавита
            string str;                                                                                                         //Строка для ввода n
            string strChar;                                                                                                     //Строка для ввода символа алфавита
            string strDouble;                                                                                                   //Строка для ввода частоты

            Console.WriteLine("Программа для постоения суффиксного кода Хаффмана при заданных частотах входного алфавита.");

            Console.WriteLine("Введите количество символов алфавита");
            str = Console.ReadLine();
            InputInteger(str, ref n); //Проверка на корректность ввода
            //Ввод алфавита и вероятности ввода символов
            //Создание массивов для хранения
            double[] array = new double[n];
            char[] arrayChar = new char[n];
            Console.WriteLine("Введите символ и его вероятность");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Пара {i + 1}:");
                strChar = Console.ReadLine();
                InputChar(strChar, ref arrayChar[i]);
                strDouble = Console.ReadLine();
                InputDouble(strDouble, ref array[i]);
            }

            Dictionary<char, double> m = new Dictionary<char, double>();                                                        //Записываю элементы и частоту их встречи в словарь

            Console.ForegroundColor = ConsoleColor.Green;
            Console.ResetColor();

            for (int i = 0; i < array.Length; i++)                                                                              //Заполнение Коллекции m
            {
                char c = arrayChar[i];
                m[c] = array[i];
            }
            Console.WriteLine("Частота символов входного алфавита");
            foreach (KeyValuePair<char, double> item in m)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }

            List<Node> list = new List<Node>();                                                                                 //Лист указателей для Node
            foreach (KeyValuePair<char, double> item in m)                                                                      //Заполнение коллекции list элементами из m
            {
                Node p = new Node();
                p.symbol = item.Key;
                p.periodicity = item.Value;
                list.Add(p);                                                                                                    //Добавляем в лист
            }

            while (list.Count() != 1)                                                                                              //Строится дерево. В конце останется один элемент-корень со значением 1
            {
                list = list.OrderBy(x => x.periodicity).ToList();                                                               //Сортировка по возрастанию по полю с частотой использования
                Node SonL = new Node();
                SonL = list[0];                                                                                                 //Добавляем первый элемент списка (самая маленькая встречаемость символа)
                list.RemoveAt(0);
                Node SonR = new Node();
                SonR = list[0];                                                                                                 //Проделываем тоже самое
                list.RemoveAt(0);

                Node parent = new Node(SonL, SonR);                                                                             //Создание нового эелмента дерева, у которого потомки SonL и SonR, их информационное поле periodically складывается

                list.Add(parent);
            }

            Node root = new Node();                                                                                             //Запоминаем корень дерева
            root = list[0];
            //print(root, 3);                                                                                                   //Распечатаем что получилось

            BuildTable(root);                                                                                                   //Создание двоичных кодировок для символов входного алфавита

            table = table.OrderBy(p => p.Value.Length).ToDictionary(p => p.Key, p => p.Value);                                       //Сортирвка по ключу для вывода в лексикографическом порядке

            Console.WriteLine("\nКодовые слова для символов входного алфавита");
            foreach (KeyValuePair<char, string> item in table)                                                                  //Вывод символов алфавита и их кодировки
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
            Console.ReadKey();
        }
    }
}
