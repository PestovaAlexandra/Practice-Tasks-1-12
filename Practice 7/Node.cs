using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_7
{
    class Node
    {
        public double periodicity;                                  //Частота 
        public char symbol;                                         //Значение
        public Node left;                                           //Ссылка на левое поддерево
        public Node right;                                          //Ссылка на правое поддерево

        public Node()                                               //Конструктор без параметров
        {
            periodicity = 0;
            symbol = '\0';
            left = null;
            right = null;

        }
        public Node(Node L, Node R)                                //Конструктор с параметрами (для инициализации родительского узла)
        {
            left = L;
            right = R;
            periodicity = L.periodicity + R.periodicity;
        }
    }
}
