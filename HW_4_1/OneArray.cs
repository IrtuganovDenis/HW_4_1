using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HW_4_1
{
    sealed class OneArray<T> : IOneArray<T>
    {
        Random rnd = new Random();
        private const  int default_size = 5;
        private T[] array;
        private int len;
        private int size;

        public OneArray(int size)
        {
            if (size < 0)
            {
                throw new ArgumentOutOfRangeException("Длина меньше нуля");
            }
            this.size = size;
            array = new T[size];
        }
        public OneArray()
        {
            array = new T[default_size];
        }


        public void Print()
        {
            for (int i = 0; i < len; ++i)
            {
                Console.WriteLine(array[i] + " ");
            }
            Console.WriteLine();
        }
        public void Add(T el)
        {

            if (len + 1 > size)
            {
                size = size * 2 + 1;
                T[] a = new T[len];
                array.CopyTo(a, 0);
                array = new T[size];
                a.CopyTo(array, 0);
            }
            array[len] = el;
            ++len;
        }
        public int Get_index(T el)
        {
            for (int i = 0; i < len; ++i)
            {
                if (array[i].Equals(el))
                {
                    return i;
                }
            }
            throw new Exception("В массиве не существует такого элемента");
        }
        
        public void Delete(T el)
        {
            int index = Get_index(el);
            --len;
            Array.Copy(array, index + 1, array, index, len - index);
        }
        public void Sort()
        {
            Comparer<T> comp = Comparer<T>.Default;

            for (int i = 0; i < len; ++i)
            {
                for (int j = 0; j < len - 1; ++j)
                {
                    if (comp.Compare(array[j], array[j + 1])  == 1)
                    {
                        T t = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = t;
                    }
                }
            }
        }

        public void Foreach(Action<T> act)
        {
            for (int i = 0; i < len; ++i)
            {
                act(array[i]);
            }
        }
        
        public void Reverse()
        {
            T[] a = new T[len];
            for (int i = len - 1; i >= 0; --i)
            {
                a[i] = array[len - i - 1];
            }
            a.CopyTo(array, 0);
        }

        public T Min()
        {
            Comparer<T> comp = Comparer<T>.Default;
            T min = array[0];
            for (int i = 0; i < len; ++i)
            {
                if (comp.Compare(array[i], min) < 0)
                {
                    min = array[i];
                }
            }
            return min;
        }

        public T Max()
        {
            Comparer<T> comp = Comparer<T>.Default;
            T max = array[0];
            for (int i = 0; i < len; ++i)
            {
                if (comp.Compare(array[i], max) > 0)
                {
                    max = array[i];
                }
            }
            return max;
        }

        public int Count()
        {
            return len;
        }
        public int Count(Func<T, bool> f)
        {
            int count = 0;
            for (int i = 0; i < len; ++i)
            {
                if (f(array[i]))
                {
                    ++count;
                }
            }
            return count;
        }


        public void All_elements<TResult>()
        {
            OneArray<T> elements = new(0);

            for (int i = 0; i < len; ++i)
            {
                if (array[i] is TResult)
                {
                    elements.Add(array[i]);
                }
            }

            elements.Print();
        }
        public void All_elements(Func<T, bool> f)
        {
            OneArray<T> elements = new(0);

            for (int i = 0; i < len; ++i)
            {
                if (f(array[i])){
                    elements.Add(array[i]);
                }
            }

            elements.Print();
        }

        public bool Include(T el)
        {
            for (int i = 0; i < len; ++i)
            {
                if (array[i].Equals(el))
                {
                    return true;
                }
            }
            return false;
        }

        public T Get_element(int index)
        {
            for (int i = 0; i < len; ++i)
            {
                if (Get_index(array[i]) == index)
                {
                    return array[i];
                }
            }

            throw new ArgumentOutOfRangeException("Элемента с таким индексом не существует");
        }

    }
}
