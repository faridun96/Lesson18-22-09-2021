using System;
using System.Collections;
using System.Collections.Generic;

namespace MyDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            var my = new Mylist<int>();
            my.Add(100);
            my.Add(200);
            my.Add(300);
            my.Add(400);
            my.Add(500);
            my.Add(600);
            Console.WriteLine($"Выводим все элементы массива:\n{my.ToString()}");
            Console.WriteLine($"Количество элементов массива:\n{my.Count.ToString()}");
            Console.WriteLine($"Индекс элемента массива (400):");
            int c = my.IndexOf(400);
            Console.WriteLine(c == -1 ? "нет такого" : c.ToString());
            Console.WriteLine($"Заменяем значение на новое по индекску [2] = 100.");
            my[2] = 100;
            Console.WriteLine($"Выводим все элементы массива после изменения:\n{my.ToString()}");
            my.Clear();
            Console.WriteLine($"Удаляем все элементы массива.");
            Console.WriteLine($"Количество элементов массива после удаления:\n{my.Count.ToString()}");
        }
    }
    interface IMylist<T>
    {
        T this[int index] { get; }
        int IndexOf(T item);
    }
    class Mylist<T> : IMylist<T>
    {
        private T[] arrayT;
        public Mylist()
        {
            arrayT = new T[0];
        }
        public T this[int index]
        {
            get
            {
                return arrayT[index];
            }
            set
            {
                arrayT[index] = value;
            }
        }
        public void Add(T newitem)
        {
            T[] newarrayT = new T[arrayT.Length + 1];
            for (int i = 0; i < arrayT.Length; i++)
            {
                newarrayT[i] = arrayT[i];
            }
            newarrayT[arrayT.Length] = newitem;
            arrayT = newarrayT;
        }
        public int Count
        {
            get { return arrayT.Length; }
        }
        public void Clear()
        {
            arrayT = new T[0];
        }
        public int IndexOf(T item)
        {
            for (var i = 0; i < Count; i++)
            {
                if ((int)(object)arrayT[i] == (int)(object)(item))
                {
                    return i;
                }
            }
            return -1;
        }
        public override string ToString()
        {
            string str = null;
            for (var i = 0; i < arrayT.Length; i++)
            {
                str += " " + arrayT[i].ToString();
            }
            return str;
        }
    }
}    