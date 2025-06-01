namespace List;

internal class ListNode<T>(T value, ListNode<T>? next)
{
    public T Value { get; set; } = value;

    public ListNode<T>? Next { get; set; } = next;

    public ListNode(T value) : this(value, null)
    {
    }
}
