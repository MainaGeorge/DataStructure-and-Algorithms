namespace dojo
{
    public class Node<T>
    {
        public Node<T> NextNode;

        public T Value;

        public Node(T value, Node<T> nextNode = null)
        {
            Value = value;
            NextNode = nextNode;
        }

    }

    public class Node
    {
        public Node NextNode;

        public int Value
        {
            get;
            set;
        }

        public Node(int value, Node node = null)
        {
            NextNode = node;
            Value = value;
        }
    }
}