namespace dojo
{
    public class Node
    {
        public Node NextNode;
        public int Value { get; set; }
        public Node(int value, Node node = null)
        {
            NextNode = node;
            Value = value;
        }
    }
}