using System;
using System.Collections.Generic;

namespace dojo
{
    public class LinkedListImplementation
    {
        public Node HeadNode;
        public void Add(int value)
        {
            if (HeadNode == null)
            {
                HeadNode = new Node(value);
            }
            else
            {
                AddLast(value);
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
        public Node DeleteTheFirstElement()
        {
            var currentHeadNode = HeadNode;
            HeadNode = HeadNode.NextNode;

            return currentHeadNode;
        }

        public Node DeleteNode(int value)
        {
            if (HeadNode == null)
                throw new Exception("can not delete from an empty list");

            else
            {
                if (value == HeadNode.Value)
                {
                    return DeleteTheFirstElement();
                }
                else
                {
                    var currentNode = HeadNode;
                    Node nodeToBeRemoved = null;

                    while (currentNode != null)
                    {
                        if (currentNode.NextNode != null
                            && currentNode.NextNode.Value == value)
                        {
                            nodeToBeRemoved = currentNode.NextNode;

                            currentNode.NextNode = currentNode.NextNode.NextNode;
                            break;
                        }
                        currentNode = currentNode.NextNode;
                    }

                    return nodeToBeRemoved;
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
        public int DeleteAt(int indexToDeleteAt)
        {
            if (indexToDeleteAt > Size)
                return -1;

            else if (indexToDeleteAt == 0)
            {
                var toReturn = HeadNode;
                HeadNode = HeadNode.NextNode;
                return toReturn.Value;
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

                var nodeToReturn = node.NextNode;

                node.NextNode = node.NextNode.NextNode;

                return nodeToReturn.Value;
            }
        }
        public Node GetAt(int index)
        {
            if (Size < index || HeadNode == null)
            {
                throw new ArgumentException("the list is empty or index out of bounds");
            }
            else if (index == 0)
            {
                return HeadNode;
            }
            else
            {
                var node = HeadNode;
                var counter = 0;

                while (counter < index)
                {
                    node = node.NextNode;
                    counter++;
                }

                return node;
            }
        }
        public void AddNode(Node node)
        {
            if (HeadNode == null)
            {
                HeadNode = node;
            }
            else
            {
                var currentNode = HeadNode;
                while (currentNode.NextNode != null)
                {
                    currentNode = currentNode.NextNode;
                }

                currentNode.NextNode = node;
            }
        }
        public static LinkedListImplementation JoinTwoSortedLinkedLists(LinkedListImplementation first,
            LinkedListImplementation second)
        {
            var resultLinkedList = new LinkedListImplementation();

            while (first.Size > 0 && second.Size > 0)
            {
                resultLinkedList.Add(first.GetAt(0).Value < second.GetAt(0).Value ? first.DeleteAt(0) : second.DeleteAt(0));
            }

            AddElementsFromOneLinkedToAnother(resultLinkedList, first);

            AddElementsFromOneLinkedToAnother(resultLinkedList, second);

            return resultLinkedList;
        }
        private static void AddElementsFromOneLinkedToAnother(LinkedListImplementation destination,
            LinkedListImplementation source)
        {
            while (source.Size > 0)
            {
                destination.AddLast(source.DeleteAt(0));
            }
        }
        public bool IsLinkedListCyclic()
        {
            if (HeadNode == null)
                return false;

            var result = false;
            var hare = HeadNode;
            var tortoise = HeadNode;

            while (hare.NextNode.NextNode != null)
            {
                hare = hare.NextNode.NextNode;
                tortoise = tortoise.NextNode;

                if (hare != tortoise) continue;

                result = true;
                break;
            }

            return result;
        }
        public static LinkedListImplementation ReverseLinkedList(LinkedListImplementation linkedList)
        {
            var newLinked = new LinkedListImplementation();

            Node previousNode = null;
            var currentNode = linkedList.HeadNode;

            while (currentNode != null)
            {
                var nextNode = currentNode.NextNode;
                currentNode.NextNode = previousNode;
                previousNode = currentNode;
                currentNode = nextNode;
            }

            newLinked.HeadNode = previousNode;

            return newLinked;
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
