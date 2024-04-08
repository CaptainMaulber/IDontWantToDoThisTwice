namespace IDontWantToDoThisTwice.DataStructures {

public class BinaryHeap<T> where T : IHeapItem {
    private readonly T[] _items;
    private readonly int _size;
    public int Count { get; private set; }

    private BinaryHeap(){}
    
    public BinaryHeap(int size) {
        _items = new T[size];
        _size = size;
        Count = 0;
    }

    public bool Add(T item) {
        if (Count == _size) {
            return false;
        }

        _items[Count] = item;
        Count++;
        BubbleDown();
        return true;
    }

    public T RemoveMin() {
        if (Count == 0) {
            return default;
        }

        T min = _items[0];
        _items[0] = _items[Count - 1];
        _items[Count - 1] = default;
        Count--;

        BubbleUp();
        
        return min;
    }

    public T Peek() {
        return _items[0];
    }

    private void BubbleDown() {
        if (Count == 1) {
            return;
        }

        int current = Count - 1;
        while (current > 0 && _items[current].Priority < _items[current >> 1].Priority) {
            (_items[current], _items[current >> 1]) = (_items[current >> 1], _items[current]);
            current >>= 1;
        }
    }

    private void BubbleUp() {
        if (Count == 0) {
            return;
        }

        int current = 0;
        while (Count > current * 2 + 1) {
            int smallerChild = current * 2 + 1;
            if (Count > current * 2 + 2) {
                // 2 children
                smallerChild = _items[current * 2 + 1].Priority < _items[current * 2 + 2].Priority
                    ? current * 2 + 1
                    : current * 2 + 2;
            }

            if (_items[smallerChild].Priority > _items[current].Priority) {
                break;
            }

            (_items[current], _items[smallerChild]) = (_items[smallerChild], _items[current]);
            current = smallerChild;
        }
    }
}
}