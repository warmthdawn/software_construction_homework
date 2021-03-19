using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ForEachAction
{
    public static class GenelicListExtension
    {
        public static void ForEachAction<T>(this GenericList<T> list, Action<T> action)
        {
            var curr = list.Head;
            while (curr != null)
            {
                action?.Invoke(curr.Data);
                curr = curr.Next;
            }
        }
    }
    public class GenericList<T>
    {
        private Node<T> head, tail;

        public GenericList()
        {
            head = tail = null;
        }
        public GenericList(T[] array)
        {
            head = tail = null;

            foreach (var arr in array)
            {
                Add(arr);
            }
        }

        public Node<T> Head { get => head; }

        public void Add(T t)
        {
            var n = new Node<T>(t);
            if (head == null)
            {
                head = tail = n;
            }
            else
            {
                tail.Next = n;
                tail = n;
            }
        }
    }
    public class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Data { get; set; }

        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }
}
