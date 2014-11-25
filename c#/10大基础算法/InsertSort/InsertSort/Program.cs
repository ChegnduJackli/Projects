using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InsertSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 2,1,-2,12,4,-2,-4,-6};
            foreach (int i in array)
            {
                Console.Write(i.ToString() + "  ");
            }
           // InsertSort( array);
            Console.WriteLine();
            //foreach (int i in array)
            //{
            //    Console.Write(i.ToString() + "  ");
            //}
            Console.WriteLine();
            InsertSort1(array);

            Console.ReadKey();
        }
        static void InsertSort( int[] array)
        {
            int index = -1;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > 0 && index == -1)//is first positive number
                {
                    index = i;
                }
                if (index >= 0 && array[i] < 0)//is negative number
                {
                    Swap(ref array[i], ref array[index]);//swap array[i] with the first positive number before array[i]
                    index++;//index pointed to next positive number
                }
            }
        }

        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;

        }

        static void InsertSort1(int[] array)
        {
            StringBuilder sbPosi = new StringBuilder();
            StringBuilder sbNega = new StringBuilder();

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 0)
                {
                    sbNega.Append(array[i] + "  ");
                }
                else
                {
                    sbPosi.Append(array[i] + "  ");
                }
            }

            string result = sbNega.Append(sbPosi.ToString()).ToString();
            Console.WriteLine(result);

        }
    }
}
