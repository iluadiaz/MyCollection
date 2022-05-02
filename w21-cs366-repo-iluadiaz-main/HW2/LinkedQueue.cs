using QueuedInterface;
using Node;

namespace LinkedQueue
{
    public class LinkedQueue<T> : QueueInterface<T>
    {
        private Node<T> front;
        private Node<T> rear;
    public LinkedQueue()
    {
        front = null;
        rear = null;
    }
    public bool isEmpty()
    {
        if(front == null && rear == null)
        {
            return true;
        }
        else return false;       
    }
    public T peek()
    {
        if(isEmpty())
        {
            throw new System.NotImplementedException("The queue was empty when peek was invoked.");
        }
        return front.data;
    }

    public T pop()
    {
        Node<T> temp = null;
        if(isEmpty())
        {
            throw new System.NotImplementedException("The queue was empty.");
        }
        else if(front == rear)
        {
            temp = front;
            front = null;
            rear = null;
        }
        else
        {
            temp = front;
            front = front.next;
        }
            return temp.data;
        }

        public T push(T element)
            {
            if(element == null)
            {
            throw new System.NotImplementedException("Null pointer!");
        }
            if(isEmpty())
            {
            Node<T> temp = new Node<T>(element, null);
            rear = front = temp;
            }
            else
            {
            Node<T> temp = new Node<T>(element, null);
            rear.next = temp;
		    rear = temp;
        }
            return element;
        }
    }
}