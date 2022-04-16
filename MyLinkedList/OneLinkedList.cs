using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLinkedList
{
    public class OneLinkedList<T> : IEnumerable
    {
        public Node<T> Head { get; set; } = null;
        public Node<T> Tail { get; set; } = null;
        public int Count { get; private set; } = 0;
        public T Current { get => Head.NData; }
        private IEnumerable<T> _col;

        public OneLinkedList() { }

        public OneLinkedList(IEnumerable<T> collection) 
        {
            _col  = collection.ToList();
        }
        public List<T> ToList()
        {
            List<T> listOfNodes = new();
            Node<T> current = Head;

            while (current != null)
            {
                listOfNodes.Add(current.NData);
                current = current.NextNode;
            }
            return listOfNodes;
        }
        public void Reset()
        {
            Head = null;
            Count = 0;
        }
        public bool MoveNext()
        {
            Node<T> cur = Head;
            return cur.NextNode != null;

        }
        public IEnumerator GetEnumerator()
        {
            Node<T> cur = Head;
            while (cur != null)
            {
                yield return cur.NData;
                cur = cur.NextNode;
            }
        }
        public void AddBefore(T nodeData, T value)
        {
            Node<T> newNode = new Node<T>(value);
            Node<T> marker = GetByData(nodeData);
            Node<T> current = Head;

            while (current.NextNode != null)
            {
                if (current.NextNode == marker)
                {
                    newNode.NextNode = marker;
                    current.NextNode = newNode;

                    Count++;
                    break;
                }
                else
                    current = current.NextNode;
            }
        }
        public void AddLast(T data)
        {
            Node<T> node = new Node<T>(data);
            Node<T> current = Head;

            if (Count == 0) Head = node;
            else
            {
                while (current.NextNode != null)
                {
                    current = current.NextNode;
                    Tail = current;
                }
                Tail.NextNode = node;
                Tail = node;
            }
            Count++;
        }
        public void AddFirst(T data)
        {
            Node<T> node = new Node<T>(data);

            if (Count == 0) Head = node;
            else
            {
                node.NextNode = Head;
                Head = node;
            }
            Count++;
        }
        private Node<T> GetByData(T data)
        {
            Node<T> templ = new Node<T>(data);
            Node<T> cur = Head;
            int cnt = 0;

            if (Contains(data) == true)
            {
                while (cnt != Count)
                {
                    if (cur == templ) return cur;
                    cur = cur.NextNode;
                    cnt++;
                }
            }
            else
                throw new Exception($"{templ.NData} is absence in the collection");
                return templ;

        }
        public void Remove(T data)
        {
            Node<T> node = GetByData(data);
            Node<T> current = Head;

            if (Head == node)
            {
                Head = current.NextNode;
                Count--;
            }

            while(current != null)
            {
                if (current.NextNode == node)
                {
                    current.NextNode = current.NextNode.NextNode;
                    Count--;
                }
                current = current.NextNode;
            }

        }
        public bool Contains(T data) 
        {
            Node<T> templ = new Node<T>(data);
            Node<T> cur = Head;
            int cnt = 0;

            while (cnt != Count)
            {
                if (cur == templ) return true;
                cur = cur.NextNode;
                cnt++;
            }
            return false;
        }
        public void Invert()
        {
            Node<T> cur = Head;
            Node<T> next = Head.NextNode;
            Node<T>? prev = null;

            while (cur.NextNode != null)
            {
                cur.NextNode = prev;
                prev = cur;
                cur = next;
                next = cur.NextNode;
            }
            Head = cur;
            Head.NextNode = prev ?? throw new NullReferenceException($"The {Head}.NextNode reference returned null");
        }
    }
}
