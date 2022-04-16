using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLinkedList
{
    public class Node<T>
    {
        public T NData { get; set; }
        public Node<T> NextNode { get; set; } = null;

        public Node(T Data)
        {
            NData = Data;
        }

        public static bool operator ==(Node<T>? n1, Node<T>? n2)
        {
            switch (n1, n2)
            {
                case (null, null):
                    return true;
                case (not null, null):
                    return false;
                case (null, not null):
                    return false;
                case (not null, not null):
                    return n1.ToString().Equals(n2.ToString());
            }
        }

        public static bool operator !=(Node<T>? n1, Node<T>? n2) => !(n1 == n2);

        public override string ToString() => $"{NData}";

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            throw new NotImplementedException();
        }
    }
}
