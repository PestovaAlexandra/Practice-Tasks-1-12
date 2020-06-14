using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_10
{
    class biList
    {
        biNode head;
        biNode tail;
        int count;

        public void Create(int n, double[] x)                                                  // Создаём двунаправленный список
        {
            for (int i = 0; i < n; i++)                                                         //сколько элементов добавить
            {
                biNode node = new biNode(x[i]);
                if (head == null)
                {
                    head = node;
                }
                else
                {
                    tail.Next = node;
                    node.Prev = tail;
                }
                tail = node;
                count++;
            }
        }
        // Печать списка
        public void WriteList()
        {
            Console.WriteLine();
            if (head == null)
                Console.WriteLine("Пусто");
            else
            {
                biNode tmp = head;
                while (tmp != null)
                {
                    Console.Write(tmp.Data.ToString());
                    tmp = tmp.Next;
                }
            }
        }
        public void Сalculation(int size)                                                        //Вычисление заданного в варианте выражения
        {
            double result = 1;
            biNode tempHead = head;                                                             //Переменная для передвижения по списку с начала
            biNode tempTail = tail;                                                             //Переменная для передвижения по списку с конца
            if (tempHead == null || size < 3)                                                       //Если список пуст
                Console.WriteLine("\nСписок недостаточной длины. Вычисления невозможны.");      //Вычисление невозможно
            else
            {
                while (tempHead.Next.Next != null)
                {
                    result = result * (tempHead.Data + tempHead.Next.Data + 2 * tempTail.Data); // вычисление одного из множителей выражения
                    tempHead = tempHead.Next;                                                   //переход к следующим элементам списка вперед
                    tempTail = tempTail.Prev;                                                   //переход к следующим элементам списка назад
                }
                Console.WriteLine($"\nЗначение выражения равно: {result}");
            }

        }
    }
}
