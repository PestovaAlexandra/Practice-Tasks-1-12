using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_9
{
    class Program
    {
        public static void InputInteger(string str, ref int a) //Ввод и проверка ввода для значения размера последовательности
        {
            while ((!int.TryParse(str, out a)) || a < 1)
            {
                Console.WriteLine("Введено не натуральное число. Введите заново.");
                str = Console.ReadLine();
            }
        }
        public static void CountPlusAndMines(NodeList item) //Процедура подсчёта двух сумм:все положительные и все отрицательные значения информационных полей
        {
            int sumPlus = 0, sumMines = 0;
            NodeList temp;
            temp = item;

            while (temp.head.next != null) //Передвигаемся по списку
            {
                if (temp.head.data < 0)  //Если информационное поле отрицательное, 
                    sumMines += temp.head.data; //то прибавляем к сумме отрицательных
                if (temp.head.data >= 0) //Если информационное поле положительное, 
                    sumPlus += temp.head.data; //то прибавляем к сумме положительных
                temp.head = temp.head.next; //Переход к следующему элементу
            }
            Console.WriteLine($"Сумма положительных значений информационных полей списка: {sumPlus}, сумма отрицательных информационных полей: {sumMines}.");
        }
        static void Main(string[] args)
        {
            int n = 0;
            string temp = "";
            string choice = "";
            bool keepOn;
            Console.WriteLine("Программа выполняет подсчет двух сумм в линейном списке: всех положительных и всех отрицательных значений,\nзаписанных в информационные поля элементов списка.");
            while (choice != "exit")
            {
                NodeList item = new NodeList();
                keepOn = true;

                Console.WriteLine("\nСоздание списка. Введите его длину.");
                temp = Console.ReadLine();
                InputInteger(temp, ref n); //Ввод длины списка

                item.MakeListToEnd(n, keepOn); //Автоматическое заполнение списка

                if (keepOn)
                {
                    item.Show(); //Вывод списка на экран

                    CountPlusAndMines(item);
                }

                Console.WriteLine("\nДля выхода из программы введите \"exit\". Чтобы продолжить программу, введите любую букву или цифру.");
                choice = Console.ReadLine();
            }
        }
    }
}
