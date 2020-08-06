using System;

namespace dojo
{
    public class StackImplementation
    {
        private readonly LinkedListImplementation _underlyingLinkedList;

        public StackImplementation()
        {
            _underlyingLinkedList = new LinkedListImplementation();
        }

        public void Push(int value)
        {
            _underlyingLinkedList.AddFirst(value);
        }

        public Node Peek => _underlyingLinkedList.GetAt(0);

        public Node Pop
        {
            get
            {
                if (_underlyingLinkedList.HeadNode == null)
                {
                    throw new Exception("can not pop an empty stack");
                }
                else
                {
                    return _underlyingLinkedList.DeleteTheFirstElement();
                }
            }
        }

        public int Count => _underlyingLinkedList.Size;

    }
}
