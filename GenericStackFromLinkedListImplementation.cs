using System.Collections;
using System.Collections.Generic;

namespace dojo
{
    public class GenericStackFromLinkedListImplementation<T> : IEnumerable<T>
    {
        private readonly GenericLinkedListImplementation<T> _underlyingLinkedList;

        public GenericStackFromLinkedListImplementation(Node<T> headNode = null)
        {
            _underlyingLinkedList = headNode != null ? new GenericLinkedListImplementation<T>(headNode)
                                                     : new GenericLinkedListImplementation<T>();
        }

        public void Push(Node<T> node)
        {
            _underlyingLinkedList.AddFirst(node);
        }

        public void Push(T value)
        {
            _underlyingLinkedList.AddFirst(value);
        }

        public Node<T> Peek => _underlyingLinkedList.GetFirst;

        public void ShowMembers()
        {
            _underlyingLinkedList.ShowMembers();
        }

        public Node<T> Pop => _underlyingLinkedList.RemoveFirst();

        public int Count => _underlyingLinkedList.Length;
        public IEnumerator<T> GetEnumerator()
        {
            return (IEnumerator<T>)_underlyingLinkedList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
