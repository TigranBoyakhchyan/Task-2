using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = 20, i;
            int[] arr = new int[N];
            Random r = new Random();

            for (i = 0; i < N; i++)
            {
                arr[i] = r.Next(1, 100);
            }

            Sorting_Algorithms s = new Sorter();
            Output(arr);

            //Sorting with bubble sort algorithm
            //s.DoSortBubble(arr);


            //Sorting with selection sort algorithm
            //s.DoSortSelection(arr);


            //Sorting with insertion sort algorithm
            //s.DoSortInsertion(arr);

            Output(arr);
        }

        public static void Output(int[] a)
        {
            int len = a.Length;
            for (int i = 0; i < len; i++)
            {
                Console.Write($"{a[i]} ");
            }
            Console.WriteLine();
        }
    }

    abstract class Sorting_Algorithms
    {
        public void DoSortBubble(int[] a)
        {
            int i, j, len = a.Length;
            for (i = 0; i < len; i++)
            {
                for (j = 0; j < len - 1; j++)
                {
                    if (!Order(a[j], a[j + 1]))
                    {
                        Swap(a, j, j + 1);
                    }
                }
            }
        }

        public void DoSortSelection(int[] a)
        {
            int i, j, len = a.Length, min;
            for (i = 0; i < len - 1; i++)
            {
                min = i;
                for (j = i + 1; j < len; j++)
                {
                    if (!Order(a[min], a[j]))
                    {
                        min = j;
                    }
                }
                if(min != i)
                {
                    Swap(a, i, min);
                }
            }
        }

        public void DoSortInsertion(int[] a)
        {
            int i, j, len = a.Length, key;

            for(i = 1; i<len; i++)
            {
                key = a[i];
                j = i - 1;

                while (j >= 0 && !Order(a[j], key))
                {
                    a[j + 1] = a[j];
                    j--;
                }
                a[j + 1] = key;
            }
        }

        protected abstract bool Order(int a, int b);
        protected abstract void Swap(int[] a, int i, int j);
    }

    class Sorter : Sorting_Algorithms
    {
        protected override bool Order(int a, int b)
        {
            return a <= b;
        }
        protected override void Swap(int[] a, int i, int j)
        {
            int temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }
    }

}
