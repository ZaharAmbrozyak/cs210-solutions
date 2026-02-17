namespace AlgorithmsSamplesh1;

public class Queue
{
    private int[] _array;
    private int _pointer = 0;

    public bool Empty
    {
        get => _pointer == 0;
    }
    
    public void Push(int element)
    {
        if (_pointer == _array.Length)
        {
            throw new Exception("Queue overflowed!");
        }
        _array[_pointer] = element;
        _pointer++;
            
    }

    public int Pop()
    {
        if (_pointer == 0)
        {
            return -1;
        }

        int element = _array[0];
        for(var i = 1; i < _array.Length; i++)
        {
            _array[i - 1] = _array[i];
        }

        _pointer -= 1;
        return element;
    }

    public Queue(int n)
    {
        _array = new int[n];
    }
}