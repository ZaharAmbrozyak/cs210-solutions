namespace AlgorithmsSamplesh1;

public class Heap<T> where T: IComparable<T>
{
    private readonly List<T> _elements = new List<T>();

    public int Count => _elements.Count;

    public void Add(T item)
    {
        _elements.Add(item);

        HeapifyUp(_elements.Count - 1);
    }

    public T ExtractMin()
    {
        if (_elements.Count == 0)
        {
            throw new InvalidOperationException("The heap is empty.");
        }

        T min = _elements[0];

        _elements[0] = _elements[_elements.Count - 1];
        _elements.RemoveAt(_elements.Count - 1);

        if (_elements.Count > 0)
        {
            HeapifyDown(0);
        }

        return min;
    }

    public T Peek()
    {
        if (_elements.Count == 0)
        {
            throw new InvalidOperationException("The heap is empty");
        }

        return _elements[0];
    }

    private void HeapifyUp(int index)
    {
        int parentIndex = GetParentIndex(index);

        while (index > 0 && _elements[index].CompareTo(_elements[parentIndex]) < 0)
        {
            Swap(index, parentIndex);
            index = parentIndex;
            parentIndex = GetParentIndex(index);
        }
    }

    private void HeapifyDown(int index)
    {
        int smallest = index;
        int leftChild = GetLeftChildIndex(index);
        int rightChild = GetRightChildIndex(index);

        if (leftChild < _elements.Count && _elements[leftChild].CompareTo(_elements[smallest]) < 0)
        {
            smallest = leftChild;
        }

        if (rightChild < _elements.Count && _elements[rightChild].CompareTo(_elements[smallest]) < 0)
        {
            smallest = rightChild;
        }

        if (smallest != index)
        {
            Swap(index, smallest);
            HeapifyDown(smallest);
        }
    }

    private void Swap(int i, int j)
    {
        T temp = _elements[i];
        _elements[i] = _elements[j];
        _elements[j] = temp;
    }

    private int GetParentIndex(int index) => (index - 1) / 2;
    private int GetLeftChildIndex(int index) => 2 * index + 1;
    private int GetRightChildIndex(int index) => 2 * index + 2;
}