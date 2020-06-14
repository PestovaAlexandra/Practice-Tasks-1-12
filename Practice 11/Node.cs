using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_11
{
    class Node                              //Класс объектов циклического однонаправленного списка
    {
        public Node Next { get; set; }      //Ссылка на следующий элемент списка
        public char Data { get; set; }      //Информационное поле объекта

        public Node(char data)             //Конструктор класса
        {
            Data = data;
            Next = null;
        }
    }
}
