namespace dojo
{
    public class BinaryTree
    {
        public BinaryNode RootNode;

        public void Add(int value)
        {
            BinaryTreeFunctions.AddNode(ref RootNode, value);
        }

        public void PrintInOrder()
        {
            BinaryTreeFunctions.PrintInOrder(ref RootNode);
        }

        public void PrintPreOrder()
        {
            BinaryTreeFunctions.PrintPreOrder(ref RootNode);
        }

        public void PrintPostOrder()
        {
            BinaryTreeFunctions.PrintPostOrder(ref RootNode);
        }
    }
}