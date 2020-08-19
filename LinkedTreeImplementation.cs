using System;

namespace dojo
{
    public class LinkedTreeImplementation<T>
    {
        public Node<T> HeadNode;

        public LinkedTreeImplementation()
        {
        }
        public LinkedTreeImplementation(Node<T> node)
        {
            HeadNode = node;
        }
        public void AddFirst(Node<T> node)
        {
            if (HeadNode == null)
            {
                HeadNode = node;
            }
            else
            {
                node.NextNode = HeadNode;
                HeadNode = node;
            }
        }
        public void AddFirst(T value)
        {
            var node = new Node<T>(value);
            AddFirst(node);
        }
        public void AddNode(T value)
        {
            AddLast(value);
        }
        public void AddNode(Node<T> node)
        {
            AddLast(node);
        }
        public void AddLast(T value)
        {
            if (HeadNode == null)
            {
                HeadNode = new Node<T>(value);
            }
            else
            {
                var lastNode = GetLast;
                lastNode.NextNode = new Node<T>(value);
            }
        }
        public void AddLast(Node<T> node)
        {
            if (HeadNode == null)
            {
                HeadNode = node;
            }
            else
            {
                var lastNode = GetLast;
                lastNode.NextNode = node;
            }
        }
        public Node<T> GetFirst => HeadNode;
        public Node<T> GetLast
        {
            get
            {
                var currentNode = HeadNode;
                while (currentNode.NextNode != null)
                {
                    currentNode = currentNode.NextNode;
                }

                return currentNode;
            }

        }
        public int Length
        {
            get
            {
                if (HeadNode == null)
                {
                    return 0;
                }
                else
                {
                    var count = 0;
                    var currentNode = HeadNode;

                    while (currentNode != null)
                    {
                        count++;
                        currentNode = currentNode.NextNode;

                    }

                    return count;
                }
            }
        }
        public Node<T> GetAtIndex(int searchIndex)
        {
            if (HeadNode == null)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                var currentIndex = 0;
                var currentNode = HeadNode;

                while (currentNode != null)
                {
                    if (currentIndex == searchIndex)
                    {
                        return currentNode;
                    }
                    currentNode = currentNode.NextNode;
                    currentIndex++;
                }

                throw new IndexOutOfRangeException($"the list has fewer elements than {searchIndex}");
            }
        }
        public void RemoveFirst()
        {
            HeadNode = HeadNode?.NextNode;
        }
        public void RemoveLast()
        {
            if (HeadNode == null)
            {
                return;
            }

            var currentNode = HeadNode;
            var previousNode = HeadNode;
            while (currentNode.NextNode != null)
            {
                previousNode = currentNode;
                currentNode = currentNode.NextNode;
            }

            previousNode.NextNode = null;
        }
        public void ShowNumbers()
        {
            if (HeadNode == null)
            {
                Console.WriteLine("empty list");
            }
            else
            {
                var currentNode = HeadNode;
                while (currentNode != null)
                {
                    Console.Write($"{currentNode.Value} ");
                    currentNode = currentNode.NextNode;
                }

                Console.WriteLine();
            }
        }
        public void AddAt(int index, Node<T> node)
        {
            if (index == 0)
            {
                AddFirst(node);
            }
            else
            {
                var currentNode = HeadNode;
                var indexCounter = 0;

                while (currentNode != null)
                {
                    if (indexCounter == index - 1)
                    {
                        Console.WriteLine(currentNode.Value);
                        node.NextNode = currentNode.NextNode;
                        currentNode.NextNode = node;
                        return;
                    }

                    currentNode = currentNode.NextNode;
                    indexCounter++;
                }

                throw new IndexOutOfRangeException("the index is out of bound");
            }
        }
        public void AddAt(int index, T value)
        {
            var node = new Node<T>(value);
            AddAt(index, node);
        }
        public void RemoveAt(int index)
        {
            if (HeadNode == null)
            {
                return;
            }
            else
            {
                const int indexCounter = 0;
                var currentNode = HeadNode;
                var previousNode = HeadNode;

                if (index == 0)
                {
                    RemoveFirst();
                }
                else
                {
                    while (currentNode != null)
                    {
                        if (indexCounter == index - 1)
                        {
                            previousNode.NextNode = currentNode.NextNode;
                            return;
                        }
                        previousNode = currentNode;
                        currentNode = currentNode.NextNode;
                    }

                    throw new IndexOutOfRangeException("index is out of range");
                }

            }
        }
    }
}

