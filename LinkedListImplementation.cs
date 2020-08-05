using System;
using System.Collections.Generic;

namespace dojo
{
    public class LinkedListImplementation
    {
        public Node HeadNode;

        public void AddNode(int value)
        {
            if (HeadNode == null)
            {
                HeadNode = new Node(value);
            }
            else
            {
                var node = HeadNode;
                while (node.NextNode != null)
                {
                    node = node.NextNode;
                }

                node.NextNode = new Node(value);
            }
        }

        public void PrintNodeValues()
        {
            if (HeadNode == null)
            {
                Console.WriteLine("empty linked list");
            }
            else if (HeadNode.NextNode == null)
            {
                Console.WriteLine(HeadNode.Value);
            }
            else
            {
                var node = HeadNode;
                var values = new List<int>();
                while (node.NextNode != null)
                {
                    values.Add(node.Value);
                    node = node.NextNode;
                }

                values.Add(node.Value);
                Console.WriteLine(string.Join(' ', values));
            }
        }

        public int Size
        {
            get
            {
                if (HeadNode == null)
                {
                    return -1;
                }
                else
                {
                    var node = HeadNode;
                    var count = 0;
                    while (node != null)
                    {
                        count++;
                        node = node.NextNode;
                    }
                    return count;
                }
            }
        }

        public void AddFirst(int value)
        {
            if (HeadNode == null)
            {
                HeadNode = new Node(value);
                return;
            }
            else
            {
                var node = new Node(value, HeadNode);
                HeadNode = node;
            }

        }

        public void AddLast(int value)
        {
            if (HeadNode == null)
            {
                HeadNode = new Node(value);
                return;
            }
            else
            {
                var node = HeadNode;
                while (node.NextNode != null)
                {
                    node = node.NextNode;
                }

                node.NextNode = new Node(value);
            }
        }

        public void DeleteTheFirstElement()
        {
            HeadNode = HeadNode.NextNode;
        }
        public void DeleteNode(int value)
        {
            if (HeadNode == null)
                return;

            else
            {
                if (value == HeadNode.Value)
                {
                    DeleteTheFirstElement();
                }
                else
                {
                    var currentNode = HeadNode;

                    while (currentNode != null)
                    {
                        if (currentNode.NextNode != null
                            && currentNode.NextNode.Value == value)
                        {
                            currentNode.NextNode = currentNode.NextNode.NextNode;
                            break;
                        }
                        currentNode = currentNode.NextNode;
                    }
                }
            }

        }
        public void AddAt(int indexToInsertAt, int valueToInsert)
        {
            if (indexToInsertAt > Size)
            {
                AddLast(valueToInsert);
            }
            else if (indexToInsertAt == 0)
            {
                AddFirst(valueToInsert);
            }
            else
            {
                var currentNodeIndex = 0;
                var node = HeadNode;

                while (currentNodeIndex < indexToInsertAt - 1)
                {
                    node = node.NextNode;
                    currentNodeIndex++;
                }

                var nodeToAdd = new Node(valueToInsert, node.NextNode);
                node.NextNode = nodeToAdd;

            }
        }

        public void DeleteAt(int indexToDeleteAt)
        {
            if (indexToDeleteAt > Size)
                return;

            else if (indexToDeleteAt == 0)
            {
                HeadNode = HeadNode.NextNode;
            }
            else
            {
                var countVar = 0;
                var node = HeadNode;

                while (countVar < indexToDeleteAt - 1)
                {
                    node = node.NextNode;
                    countVar++;
                }

                node.NextNode = node.NextNode.NextNode;
            }
        }

    }


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
