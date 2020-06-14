using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_12
{
    class TreeNode
    {
        public int data;                                                                                                        //Информационное поле
        public TreeNode left;                                                                                                   //Ссылка на левого потомка
        public TreeNode right;                                                                                                  //Ссылка на правого потомка
        public int Data { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }


        public TreeNode(int data)                                                                                               //Конструктор 
        {
            this.Data = data;
        }
        public static TreeNode CreateSearchTree(TreeNode root, int[] array, ref int comparisons, ref int permutations)         //Метод для построения дерева поиска
        {
            int j = 0;
            int size = array.Length;
            root = new TreeNode(array[0]);
            for (j = 1; j < size; j++)
            {
                Add(ref root, array[j], ref comparisons, ref permutations);                                                     //Добавление элемента в дерево поиска
            }

            return root;
        }
        public static void Add(ref TreeNode root, int d, ref int comparisons, ref int permutations)                             //добавление элемента в дерево поиска
        {
            TreeNode p = root;                                                                                                  //корень дерева
            TreeNode r = null;
            //флаг для проверки существования элемента d в дереве
            bool ok = false;
            if (root == null)
            {

                r = new TreeNode(d);
                //return root;
                return;
            }

            while (p != null && !ok)
            {
                r = p;
                //элемент уже существует
                if (d == p.Data)
                {
                    comparisons++;
                    ok = true;
                }
                else
            if (d < p.Data)
                {
                    comparisons++;
                    p = p.Left;                                                                                                 //пойти в левое поддерево

                }
                else
                {
                    p = p.Right;                                                                                                //пойти в правое поддерево
                    comparisons++;
                }
            }
            if (ok) return /*p*/;                                                                                               //найдено, не добавляем
                                                                                                                                //создаем узел
            TreeNode NewPoint = new TreeNode(d);                                                                                //выделили память
                                                                                                                                // если d<r.key, то добавляем его в левое поддерево
            if (d < r.Data)
            {
                comparisons++;
                r.Left = NewPoint;
            }
            // если d>r.key, то добавляем его в правое поддерево
            else
            {
                comparisons++;
                r.Right = NewPoint;
            }
            //return root;
        }
        public void ShowTree(TreeNode p, int l)                                                                                 //Вывод дерева на экран
        {
            if (p != null)
            {
                ShowTree(p.Right, l + 3);                                                                                       //переход к правому поддереву
                                                                                                                                //формирование отступа
                for (int i = 0; i < l; i++) Console.Write(" ");
                Console.WriteLine(p.Data.ToString());                                                                           //печать узла
                ShowTree(p.Left, l + 3);                                                                                        //переход к левому поддереву
            }
            else
            {
                Console.WriteLine("Список пуст");
            }
        }
        public static void ShowMinMax(TreeNode p)                                                                               //Вывод содержимого дерева поиска в виде массива
        {
            if (p != null)
            {
                ShowMinMax(p.Left);
                Console.Write($"{p.Data} ");
                ShowMinMax(p.Right);
            }

        }

    }
}
