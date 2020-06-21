using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_11
{
    class CircularList
    {
        Node head;                                                       //ССылка на первый элемент списка
        Node tail;
        int count;

        public void Add(char data)                                      //Добавление элемнта в конец списка
        {
            Node node = new Node(data);
            // если список пуст
            if (head == null)
            {
                head = node;
                tail = node;
                tail.Next = head;
            }
            else
            {
                node.Next = head;
                head.Prev = node;
                tail.Next = node;
                node.Prev = tail;
                tail = node;
            }
            count++;
        }
        public bool Contains(char data)                                 //Проверка на входимость элемента в список
        {
            Node current = head;
            if (current == null) return false;
            do
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            while (current != head);
            return false;
        }

        public void Ecrypt(int n, char temp, ref string result)         //Метод для замены некоторого символа алфавита на символ того же алфавита с двигом на n позиций
        {

            Node current = this.head;

            for (int j = 0; j < this.count; j++)                        //Поиск в списке символа, который нужно зашифровать
            {
                if (current.Data == temp)
                    j = this.count;

                else
                {
                    current = current.Next;
                }
            }
            for (int j = 0; j < n; j++)                                 //Сдвиг в списке на n элеементов
            {
                current = current.Next;
            }
            result = result + current.Data;                             //Шифрование символа
        }
        public void EcryptBack(int n, char temp, ref string result)         //Метод для замены некоторого символа алфавита на символ того же алфавита с двигом на n позиций
        {

            Node current = this.head;

            for (int j = 0; j < this.count; j++)                        //Поиск в списке символа, который нужно расшифровать
            {
                if (current.Data == temp)
                    j = this.count;

                else
                {
                    current = current.Next;
                }
            }
            for (int j = 0; j < n; j++)                                 //Сдвиг в списке на n элеементов
            {
                current = current.Prev;
            }
            result = result + current.Data;                             //Шифрование символа
        }

    }
}
