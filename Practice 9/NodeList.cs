using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_9
{
    class NodeList
    {
        public Node head;

        public NodeList()
        {
            head = new Node();
        }

        public void AddToEnd(Node head, int x) //Добавление элемента в конец списка, информационное поле заполняется вручную
        {
            if (head == null) //Если список пуст, он создается
            {
                head.data = x;
                head.next = null;
            }
            else //Иначе элемент добавляется в конец
            {
                //создаем элемент и добавляем в конец списка
                Node p = new Node(x);
                Node temp = head;
                while (temp.next != null)
                {
                    temp = temp.next;
                }
                temp.next = p;
            }
        }
        public void MakeListToEnd(int size, bool keepOn) //Автоматическое заполнение списка размера size, новые элементы вставляются назад
        {
            if (size == 0)
            {
                Console.WriteLine("Длина списка 0. Список не заполнен.");
                keepOn = false;
            }
            else
            {
                Random rnd = new Random();
                int info = rnd.Next(-20, 20);

                head = new Node(info);//первый элемент
                Node r = head;//переменная хранит адрес конца списка 
                for (int i = 0; i < size; i++)
                {
                    info = rnd.Next(-20, 20);

                    //создаем элемент и добавляем в конец списка
                    Node p = new Node(info);
                    r.next = p;
                    r = p;
                }
            }

        }
        public void Show()  //Вывод списка на экран
        {
            if (head == null)
                Console.WriteLine("Список пуст");
            else
            {
                Node p = head;
                while (p.next != null)
                {
                    Console.Write($"{p.data} ");
                    p = p.next;
                }
                Console.WriteLine();
            }
        }
    }
}
