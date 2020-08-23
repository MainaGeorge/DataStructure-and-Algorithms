using System;

namespace dojo
{
    public class GenericQueueImplementationUsingTwoStacks<T>
    {
        private readonly GenericStackFromLinkedListImplementation<T> _originalStack;
        private readonly GenericStackFromLinkedListImplementation<T> _stackAllowingModifications;

        public GenericQueueImplementationUsingTwoStacks(Node<T> node = null)
        {
            _originalStack = new GenericStackFromLinkedListImplementation<T>(node);
            _stackAllowingModifications = new GenericStackFromLinkedListImplementation<T>();
        }

        public void Enqueue(Node<T> node)
        {
            _originalStack.Push(node);
        }

        public void Enqueue(T value)
        {
            _originalStack.Push(value);
        }
        public int Count => _originalStack.Count;
        public Node<T> Peek()
        {
            MoveFromOriginalStackToModification();
            var nodeToReturn = _stackAllowingModifications.Peek;
            MoveFromModificationToOriginal();
            return nodeToReturn;
        }

        public Node<T> Dequeue()
        {
            MoveFromOriginalStackToModification();
            var nodeToReturn = _stackAllowingModifications.Pop;
            MoveFromModificationToOriginal();
            return nodeToReturn;
        }

        public void ShowMembers()
        {
            MoveFromOriginalStackToModification();
            _stackAllowingModifications.ShowMembers();
            MoveFromModificationToOriginal();
        }
        private void MoveFromOriginalStackToModification()
        {
            while (_originalStack.Peek != null)
            {
                var node = _originalStack.Pop;
                node.NextNode = null;
                _stackAllowingModifications.Push(node);
            }
        }

        private void MoveFromModificationToOriginal()
        {
            while (_stackAllowingModifications.Peek != null)
            {
                var node = _stackAllowingModifications.Pop;
                node.NextNode = null;
                _originalStack.Push(node);
            }
        }
       

    }

}
