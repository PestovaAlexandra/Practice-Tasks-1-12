using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_9
{
    class Node
    {
        public int data; //Информационное поле
        public Node next;  //Ссылка на следующий объект в списке

        public Node()  //Конструктор без параметров
        {
            data = 0;
            next = null;
        }
        public Node(int data1)  //Конструктор с параметрами
        {
            data = data1;
            next = null;
        }
        public override string ToString()  //Метод, возвращающий информационное поле в виде строки
        {
            return data + " ";
        }

    }
}
