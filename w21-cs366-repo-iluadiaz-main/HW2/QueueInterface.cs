namespace QueuedInterface
{
public interface QueueInterface<T>
{
    T push(T element);

    T peek();

    T pop();

    bool isEmpty();
}
}