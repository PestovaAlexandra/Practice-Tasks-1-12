using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_10
{
    class biNode
    {
        public biNode Next { get; set; }                                                //Ссылка на следующий элемент списка
        public biNode Prev { get; set; }                                                //Ссылка на предыдущий элемент списка
        public double Data { get; set; }                                                //Информационное поле

        public biNode()                                                                 //Конструктор без параметров
        {
            Data = 0;
            Next = null;
            Prev = null;
        }
        public biNode(double data)                                                      //Конструктор с параметрами
        {
            Data = data;
            Next = null;
            Prev = null;
        }
        public override string ToString()                                               //Метод, возвращающий информационное поле в виде строки
        {
            return Data + "  ";
        }
    }
}
