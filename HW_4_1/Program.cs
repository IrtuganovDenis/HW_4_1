using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace HW_4_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

            

            Console.WriteLine("Введите количество элементов числового массива");
            int n = int.Parse(Console.ReadLine());

            OneArray<int> int_array = new(n);

            for (int i = 0; i < n; ++i)
            {
                int_array.Add(rnd.Next(1, 100));
            }

            Console.WriteLine("Массив чисел:");
            int_array.Print();

            Console.WriteLine("Первый элемента массива: ");
            Console.WriteLine(int_array.Get_element(0) + "\n");

            Console.WriteLine("Перевернутый массив:");
            int_array.Reverse();
            int_array.Print();

            Console.WriteLine("Отсортированный массив:");
            int_array.Sort();
            int_array.Print();

            

            Console.WriteLine("Количество четных элементов: ");
            Console.WriteLine(int_array.Count(x => x % 2 == 0) + "\n");
            Console.WriteLine("Нечетные элементы: ");
            int_array.All_elements(x => x % 2 != 0);

            Console.WriteLine("Минимальный элементы в массиве " + int_array.Min() + "\n");



            OneArray<string> array_str = new(5);
            array_str.Add("Akimbo");
            array_str.Add("Levan");
            array_str.Add("Larrat");
            array_str.Add("Blud");
            array_str.Add("Schoolboy");

            Console.WriteLine("Массив строк: ");
            array_str.Print();

            array_str.Delete("Blud");
            Console.WriteLine("Массив после удаления элемента «Blud»: ");
            array_str.Print();

            Console.WriteLine("Количество элементов массива: " + array_str.Count() + "\n");

            string s = "Akimbo";
            if (array_str.Include(s))
            {
                Console.WriteLine("Массив содержит элемент " + s);
            }
            else
            {
                Console.WriteLine("Массив не содержит элемент " + s);
            }

            string max = array_str.Max();
            Console.WriteLine("Мкасимальный элемент массива - " + max);

        }
    }
}
