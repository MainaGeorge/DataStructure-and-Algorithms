using System;

namespace dojo
{
    public static class BinaryTreeFunctions
    {
        public static void AddNode(ref BinaryNode rootNode, int value)
        {
            if (rootNode == null)
            {
                rootNode = new BinaryNode(value);
                return;
            }

            if (value < rootNode.Value)
            {
                AddNode(ref rootNode.LeftNode, value);
            }

            if (value > rootNode.Value)
            {
                AddNode(ref rootNode.RightNode, value);
            }
        }

        public static void PrintInOrder(ref BinaryNode rootNode)
        {
            if (rootNode == null)
            {
                return;
            }

            PrintInOrder(ref rootNode.LeftNode);
            Console.WriteLine(rootNode.Value);
            PrintInOrder(ref rootNode.RightNode);
        }

        public static void PrintPreOrder(ref BinaryNode rootNode)
        {
            if (rootNode == null)
            {
                return;
            }

            Console.WriteLine(rootNode.Value);
            PrintPreOrder(ref rootNode.LeftNode);
            PrintPreOrder(ref rootNode.RightNode);
        }

        public static void PrintPostOrder(ref BinaryNode rootNode)
        {
            if (rootNode == null)
            {
                return;
            }

            PrintPostOrder(ref rootNode.LeftNode);
            PrintPostOrder(ref rootNode.RightNode);
            Console.WriteLine(rootNode.Value);
        }
    }
}
