using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_12
{
    class Program
    {
        public static int Natural(out int a)                                                                                //Ввод натурального числа и проверка на корректность ввода
        {
            a = 0;
            bool ok = true;
            do
            {
                try
                {
                    a = int.Parse((Console.ReadLine()));
                    if (a < 0)
                    {
                        ok = false;
                        Console.WriteLine("Введите натуральное число");
                    }
                    else
                    {
                        ok = true;
                    }
                }
                catch
                {
                    Console.WriteLine("Ошибка ввода");
                }
            } while (!ok);
            return a;
        }
        public static void MakeRandom(ref int[] array)                                                                     //Заполнение массива с помощью датчика случайных чисел
        {
            Random rnd = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(-50, 50);
            }
        }
        public static void WriteArray(int[] array)                                                                         //Вывод массива на экран
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]} ");
            }
        }
        public static void Sheiker_sort(ref int[] a, int n, ref int comparisons, ref int permutations)                     //Шейкер сортировка
        {
            int left = 0;
            int right = n - 1;
            int index_last_swap = -1;
            do
            {
                for (int i = left; i < right; i++)
                {
                    if (a[i] > a[i + 1])
                    {
                        Swap(ref a[i], ref a[i + 1]);
                        permutations++;
                        index_last_swap = i;
                    }
                    comparisons++;
                }
                right = index_last_swap;
                for (int i = right; i > left; i--)
                {
                    if (a[i - 1] > a[i])
                    {
                        Swap(ref a[i - 1], ref a[i]);
                        permutations++;
                        index_last_swap = i;
                    }
                    comparisons++;
                }
                left = index_last_swap;
            }
            while (left != right);
        }
        public static void Swap(ref int a, ref int b)                                                                       //Метод для обмена двух переменных
        {
            int temp = a;
            a = b;
            b = temp;
        }
        static void Main(string[] args)
        {
            int n = 0;                                                                                                        //Кол-во элементов массивов
            int i = 0;                                                                                                      //Счётчик
            int comparisonsNo = 0;                                                                                          //Кол-во сравнений при сортировке неотсортированного массива
            int permutationsNo = 0;                                                                                         //Кол-во пересылок при сортировке неотсортированного массива
            int comparisonsMiMa = 0;                                                                                        //Кол-во сравнений при сортировке отсортированного по возрастанию массива
            int permutationsMiMa = 0;                                                                                       //Кол-во пересылок при сортировке отсортированного по возрастанию массива
            int comparisonsMaMi = 0;                                                                                        //Кол-во сравнений при сортировке отсортированного по убыванию массива
            int permutationsMaMi = 0;                                                                                       //Кол-во пересылок при сортировке отсортированного по убыванию массива

            TreeNode root1 = null;
            TreeNode root2 = null;
            TreeNode root3 = null;

            Console.WriteLine("Введите число элементов последовательности");
            n = Natural(out n);                                                                                             //Ввод числа элементов последовательности и проверка на корректность ввода

            int[] arrayNoSort = new int[n];                                                                                //Хранение неотсортированного массива
            int[] arraySortMinMax = new int[n];                                                                            //Хранение остортированного по возрастанию массива
            int[] arraySortMaxMin = new int[n];                                                                             //Хранение отсортрованного по убыванию массива

            MakeRandom(ref arrayNoSort);
            Console.WriteLine("\nНеотсортированный массив:");
            WriteArray(arrayNoSort);                                                                                        //Вывод на экран

            Array.Copy(arrayNoSort, arraySortMinMax, arrayNoSort.Length);
            Array.Sort(arraySortMinMax);
            Console.WriteLine("\n\nОтсортированный массив (меньшее=>большее):");
            WriteArray(arraySortMinMax);                                                                                    //Вывод на экран

            Array.Copy(arrayNoSort, arraySortMaxMin, arrayNoSort.Length);
            Array.Sort(arraySortMaxMin);
            Array.Reverse(arraySortMaxMin);
            Console.WriteLine("\n\nОтсортированный массив (большее=>меньшее:");
            WriteArray(arraySortMaxMin);                                                                                    //Вывод на экран
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nПрограмма сортирует массивы по возрастанию\n");
            Console.ResetColor();

            //reeNode.ShowMinMax(root1);
            //Сортировка с помощью бинарного дерева поиска
            root1 = TreeNode.CreateSearchTree(root1, arrayNoSort, ref comparisonsNo, ref permutationsNo);                   //Сортировка неотсортированного массива
            root2 = TreeNode.CreateSearchTree(root2, arraySortMinMax, ref comparisonsMiMa, ref permutationsMiMa);            //Сортировка отсортированного по возрастанию массива
            root3 = TreeNode.CreateSearchTree(root3, arraySortMaxMin, ref comparisonsMaMi, ref permutationsMaMi);           //Сортировка отсортированного по убыванию массива

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Сортировка с помощью бинарного дерева");
            Console.WriteLine("-----------------------------------------------");
            Console.ResetColor();

            Console.WriteLine("Неотсортированный массив");
            Console.WriteLine($"Сравнений {comparisonsNo} Пересылок {permutationsNo}");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("-----------------------------------------------");
            Console.ResetColor();

            Console.WriteLine("Oтсортированный массив от меньшего к большему");
            Console.WriteLine($"Сравнений {comparisonsMiMa} Пересылок {permutationsMiMa}");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("-----------------------------------------------");
            Console.ResetColor();

            Console.WriteLine("Oтсортированный массив от большего к меньшему");
            Console.WriteLine($"Сравнений {comparisonsMaMi} Пересылок {permutationsMaMi}");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("-----------------------------------------------");
            Console.ResetColor();

            //Обнуление переменных количества сравнений и пересылок 
            comparisonsNo = 0;
            comparisonsMiMa = 0;
            comparisonsMaMi = 0;
            permutationsNo = 0;
            permutationsMiMa = 0;
            permutationsMaMi = 0;

            //Шейкер сортировка
            Sheiker_sort(ref arrayNoSort, arrayNoSort.Length, ref comparisonsNo, ref permutationsNo);                       //Сортировка неотсортированного массива
            Sheiker_sort(ref arraySortMinMax, arraySortMinMax.Length, ref comparisonsMiMa, ref comparisonsMiMa);            //Сортировка отсортированного по возрастанию массива
            Sheiker_sort(ref arraySortMaxMin, arraySortMaxMin.Length, ref comparisonsMaMi, ref permutationsMaMi);           //Сортировка отсортированного по убыванию массива

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Сортировка перемешиванием (Шейкер сортировка)");
            Console.WriteLine("-----------------------------------------------");
            Console.ResetColor();

            Console.WriteLine("Неотсортированный массив");
            WriteArray(arrayNoSort);
            Console.WriteLine("");
            Console.WriteLine($"Сравнений {comparisonsNo} Пересылок {permutationsNo}");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("-----------------------------------------------");
            Console.ResetColor();

            Console.WriteLine("Oтсортированный массив от меньшего к большему");
            Console.WriteLine($"Сравнений {comparisonsMiMa} Пересылок {permutationsMiMa}");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("-----------------------------------------------");
            Console.ResetColor();

            Console.WriteLine("Oтсортированный массив от большего к меньшему");
            Console.WriteLine($"Сравнений {comparisonsMaMi} Пересылок {permutationsMaMi}");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("-----------------------------------------------");
            Console.ResetColor();

            Console.WriteLine("");

            Console.ReadKey();

        }
    }
}
