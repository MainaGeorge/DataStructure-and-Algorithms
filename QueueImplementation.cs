namespace dojo
{
    public class QueueImplementation
    {
        private readonly LinkedListImplementation _underlyingLinkedList;
        public QueueImplementation()
        {
           _underlyingLinkedList = new LinkedListImplementation(); 
        }

        public void Enqueue(int value)
        {
            _underlyingLinkedList.AddLast(value);
        }

        public Node Dequeue => _underlyingLinkedList.DeleteTheFirstElement();

        public Node Peek => _underlyingLinkedList.GetAt(0);

        public int Count => _underlyingLinkedList.Size;
    }
}
