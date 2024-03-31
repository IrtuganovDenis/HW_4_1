using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_4_1
{
    interface IOneArray<T>
    {
        void Print();
        void Add(T el);
        int Get_index(T el);
        void Delete(T el);
        void Sort();
        void Foreach(Action<T> act);
        void Reverse();
        T Min();
        T Max();
        int Count();
        int Count(Func<T, bool> f);
        void All_elements<TResult>();
        void All_elements(Func<T, bool> f);
        bool Include(T el);
        T Get_element(int index);
    }
}
