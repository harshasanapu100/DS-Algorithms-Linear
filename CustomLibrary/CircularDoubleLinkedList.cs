﻿using System;

namespace CustomLibrary
{
    public class CircularDoubleLinkedList
    {
        #region private fields
        private class Node
        {
            public int value;
            public Node prev;
            public Node next;

            public Node(int value)
            {
                this.value = value;
                this.prev = null;
                this.next = null;
            }
        }

        private Node head;
        private Node tail;
        public int length;
        #endregion

        #region public methods
        public void Print()
        {
            if (IsEmpty())
            {
                throw new ArgumentException("List is empty");
            }

            var current = head;

            while (true)
            {
                Console.WriteLine(current.value);
                current = current.next;

                if (current == head)
                {
                    break;
                }
            }
        }

        public void AddFirst(int item)
        {
            Node node = new Node(item);

            if (IsEmpty())
            {
                head = tail = node;
                tail.next = head;
                tail.prev = head;
                head.next = tail;
                head.prev = tail;
            }
            else
            {
                tail.next = node;
                node.prev = tail;
                node.next = head;
                head.prev = node;
                head = node;
            }

            length++;
        }

        public void AddLast(int item)
        {
            Node node = new Node(item);

            if (IsEmpty())
            {
                head = tail = node;
                tail.next = head;
                tail.prev = head;
                head.next = tail;
                head.prev = tail;
            }
            else
            {
                tail.next = node;
                node.prev = tail;
                node.next = head;
                head.prev = node;
                tail = node;
            }

            length++;
        }

        public void AddAt(int item, int position)
        {
            Node node = new Node(item);

            if (IsEmpty())
            {
                head = tail = node;
                tail.next = head;
                tail.prev = head;
                head.next = tail;
                head.prev = tail;
            }
            else
            {
                if (position < 1 || position > length + 1)
                {
                    throw new ArgumentException("Invalid position to add the node.");
                }
                else if (position == 1)
                {
                    tail.next = node;
                    node.prev = tail;
                    node.next = head;
                    head.prev = node;
                    head = node;

                    length++;
                }
                else
                {
                    var current = head;

                    for (int i = 1; i < position - 1; i++)
                    {
                        current = current.next;
                    }

                    node.next = current.next;
                    current.next.prev = node;

                    current.next = node;
                    node.prev = current;

                    if (position == length + 1)
                    {
                        tail = node;
                        tail.next = head;
                        head.prev = tail;
                    }

                    length++;
                }
            }
        }

        public void RemoveFirst()
        {
            if (IsEmpty())
            {
                throw new ArgumentException("List is empty");
            }

            if (head == tail)
            {
                head = tail = null;
                length--;
            }
            else
            {
                var second = head.next;
                head.next = null;
                head = second;
                tail.next = head;
                head.prev = tail;

                length--;
            }
        }

        public void RemoveLast()
        {
            if (IsEmpty())
            {
                throw new ArgumentException("List is empty");
            }

            if (head == tail)
            {
                head = tail = null;
                length--;
            }
            else
            {
                var previous = tail.prev;
                previous.next = null;
                tail = previous;
                tail.next = head;
                head.prev = tail;
                length--;
            }
        }

        public void RemoveAt(int position)
        {
            if (IsEmpty())
            {
                throw new ArgumentException("List is empty");
            }

            if (position < 1 || position > length)
            {
                throw new ArgumentException("Invalid position to remove the node.");
            }
            else if (position == 1)
            {
                var second = head.next;
                head.next = null;
                head = second;
                tail.next = head;
                head.prev = tail;

                length--;
            }
            else
            {
                var current = head;

                for (int i = 1; i < position - 1; i++)
                {
                    current = current.next;
                }

                var nodeToDelete = current.next;
                current.next = current.next.next;
                nodeToDelete = null;
                current.next.prev = current;

                if (position == length)
                {
                    tail = current;
                    tail.next = head;
                    head.prev = tail;
                }

                length--;
            }
        }

        public int GetKthNodeFromEnd(int k)
        {
            if (IsEmpty())
            {
                throw new ArgumentException("List is empty");
            }

            var first = head;
            var second = head;

            for (int i = 0; i < k - 1; i++)
            {
                second = second.next;

                if (second == head)
                {
                    throw new ArgumentException("Node not exists at given position");
                }
            }

            while (second != tail)
            {
                first = first.next;
                second = second.next;
            }

            return first.value;
        }

        public void PrintMiddleNode()
        {
            if (IsEmpty())
            {
                throw new ArgumentException("List is empty");
            }

            var first = head;
            var second = head;

            while (second != tail && second.next != tail)
            {
                first = first.next;
                second = second.next.next;
            }

            if (second == tail)
            {
                Console.WriteLine(first.value);
            }
            else
            {
                Console.WriteLine(first.value + " " + first.next.value);
            }
        }

        public void Reverse()
        {
            if (IsEmpty())
            {
                throw new ArgumentException("List is empty");
            }

            if (head != tail)
            {
                Node temp = null;
                var current = head;

                while (true)
                {
                    temp = current.prev;
                    current.prev = current.next;
                    current.next = temp;
                    current = current.prev;

                    if (current == head)
                    {
                        break;
                    }
                }

                if (temp != null)
                {
                    tail = head;
                    head = tail.next;
                }
            }
        }

        public void RemoveEvenNodes()
        {
            if (IsEmpty())
            {
                throw new ArgumentException("List is empty");
            }

            if (head == tail)
            {
                Console.WriteLine("List should contains ateast 2 nodes");
            }
            else
            {
                var oddNode = head;
                var evenNode = head.next;

                while (oddNode != null && evenNode != null)
                {
                    oddNode.next = evenNode.next;
                    evenNode = null;

                    if (oddNode.next != head)
                    {
                        oddNode.next.prev = oddNode;
                        oddNode = oddNode.next;

                        if (oddNode.next != head)
                        {
                            evenNode = oddNode.next;
                        }
                    }
                    else
                    {
                        tail = oddNode;
                        tail.next = head;
                        head.prev = tail;
                    }

                    length--;
                }
            }
        }

        public void RemoveOddNodes()
        {
            if (IsEmpty())
            {
                throw new ArgumentException("List is empty");
            }

            if (head == tail)
            {
                head = tail = null;
            }
            else
            {
                var nodeToDelte = head;
                head = head.next;
                nodeToDelte = null;
                tail.next = head;
                head.prev = tail;
                length--;

                var evenNode = head;
                var oddNode = head.next;

                while (evenNode != null && oddNode != null)
                {
                    evenNode.next = oddNode.next;
                    oddNode = null;

                    if (evenNode.next != head)
                    {
                        evenNode.next.prev = evenNode;
                        evenNode = evenNode.next;

                        if (evenNode.next != head)
                        {
                            oddNode = evenNode.next;
                        }
                    }
                    else
                    {
                        tail = evenNode;
                        tail.next = head;
                        head.prev = tail;
                    }

                    length--;
                }
            }
        }

        public void RemoveFirstNodeByValue(int value)
        {
            if (IsEmpty())
            {
                throw new ArgumentException("List is empty");
            }

            if (head == tail)
            {
                if (head.value == value)
                {
                    head = tail = null;
                    length--;
                }
            }
            else
            {
                if (head.value == value)
                {
                    var nodeToDelete = head;
                    head = head.next;
                    nodeToDelete = null;
                    tail.next = head;
                    head.prev = tail;
                    length--;
                }
                else
                {
                    var current = head;

                    while (current.next != head)
                    {
                        if (current.next.value == value)
                        {
                            var nodeToDelete = current.next;
                            current.next = current.next.next;
                            current.next.prev = current;
                            if (current.next == head)
                            {
                                tail = current;
                                head.prev = tail;
                            }
                            nodeToDelete = null;
                            length--;
                            break;
                        }
                        current = current.next;
                    }
                }
            }
        }

        public void RemoveLastNodeByValue(int value)
        {
            if (IsEmpty())
            {
                throw new ArgumentException("List is empty");
            }

            if (head == tail)
            {
                if (head.value == value)
                {
                    head = tail = null;
                    length--;
                }
            }
            else
            {
                Node current = head, previousTolast = null, lastNode = null;

                if (current.value == value)
                {
                    lastNode = current;
                }

                while (current.next != head)
                {
                    if (current.next.value == value)
                    {
                        previousTolast = current;
                        lastNode = current.next;
                    }

                    current = current.next;
                }

                if (lastNode != null)
                {
                    if (lastNode == head)
                    {
                        head = head.next;
                        lastNode = null;
                        tail.next = head;
                        head.prev = tail;
                        length--;
                    }
                    else
                    {
                        previousTolast.next = lastNode.next;
                        lastNode.next.prev = previousTolast;
                        lastNode = null;

                        if (previousTolast.next == head)
                        {
                            tail = previousTolast;
                            tail.next = head;
                            head.prev = tail;
                        }

                        length--;
                    }
                }
            }
        }

        public void RemoveAllNodesByValue(int value)
        {
            if (IsEmpty())
            {
                throw new ArgumentException("List is empty");
            }

            if (head == tail)
            {
                if (head.value == value)
                {
                    head = tail = null;
                    length--;
                }
            }
            else
            {
                Node nodeToDelete;

                while (head != null && head.value == value)
                {
                    if (head.next == head)
                    {
                        head = null;
                        tail = null;
                        length--;
                    }
                    else
                    {
                        nodeToDelete = head;
                        head = head.next;
                        nodeToDelete = null;
                        tail.next = head;
                        head.prev = tail;
                        length--;
                    }
                }

                var current = head;

                while (current != null && current.next != head)
                {
                    if (current.next.value == value)
                    {
                        nodeToDelete = current.next;
                        current.next = current.next.next;
                        current.next.prev = current;
                        nodeToDelete = null;
                        length--;

                        if (current.next == head)
                        {
                            tail = current;
                            tail.next = head;
                            head.prev = tail;
                        }
                    }
                    current = current.next;
                }
            }
        }

        public void RemoveAll()
        {
            if (IsEmpty())
            {
                throw new ArgumentException("List is empty");
            }

            var temp = head;
            Node nodeToDelete = null;

            while (head.next != temp)
            {
                nodeToDelete = head;
                head = head.next;
                nodeToDelete = null;
            }

            head.next = null;
            tail.prev = null;
            head = tail = null;
            length = 0;

            Console.WriteLine("All nodes are deleted successfully.");
        }

        public void RemoveMiddleNode()
        {
            if (IsEmpty())
            {
                throw new ArgumentException("List is empty");
            }

            var first = head;
            var second = head;
            Node previous = null;

            while (second != tail && second.next !=tail)
            {
                previous = first;
                first = first.next;
                second = second.next.next;
            }

            if(second == tail)
            {
                previous.next = first.next;
                previous.next.prev = previous;
                length--;
            }
            else
            {
                previous.next = second;
                previous.next.prev = previous;
                length = length - 2;
            }
        }

        #endregion

        #region private methods
        private bool IsEmpty()
        {
            return head == null;
        }
        #endregion
    }
}
