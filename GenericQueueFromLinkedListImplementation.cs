using System.Collections;
using System.Collections.Generic;

namespace dojo
{
    public class GenericQueueFromLinkedListImplementation<T> : IEnumerable<T>
    {
        private readonly GenericLinkedListImplementation<T> _underlyingGenericLinkedList;

        public GenericQueueFromLinkedListImplementation(Node<T> linkedListHeadNode=null)
        {
            _underlyingGenericLinkedList = linkedListHeadNode == null ? new GenericLinkedListImplementation<T>()
                                                                      : new GenericLinkedListImplementation<T>(linkedListHeadNode);
        }
        public IEnumerator<T> GetEnumerator()
        {
            return _underlyingGenericLinkedList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Enqueue(Node<T> node)
        {
            _underlyingGenericLinkedList.AddLast(node);
        }
        public void Enqueue(T value)
        {
            _underlyingGenericLinkedList.AddLast(value);
        }

        public Node<T> Peek => _underlyingGenericLinkedList.GetFirst;

        public int Count => _underlyingGenericLinkedList.Length;

        public Node<T> Dequeue()
        {
            return _underlyingGenericLinkedList.RemoveFirst();

        }

        public void ShowMembers()
        {
            _underlyingGenericLinkedList.ShowMembers();
        }

    }
}
