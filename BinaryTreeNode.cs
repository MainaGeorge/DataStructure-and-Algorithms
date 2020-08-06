namespace dojo
{
    public class BinaryTreeNode
    {
        public int Value;

        public BinaryTreeNode LeftNode;
        public BinaryTreeNode RightNode;
        public BinaryTreeNode( int value, BinaryTreeNode right = null, BinaryTreeNode left = null)
        {
            Value = value;
            RightNode = right;
            LeftNode = left;
        }
    }
}
