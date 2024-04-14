using System.Collections.Generic;
using IDontWantToDoThisTwice.DataStructures;

namespace IDontWantToDoThisTwice.PathFinding {
public class AStern<T> where T : IPathNode<T>, IHeapItem{
    private BinaryHeap<T> _openSet;
    
    public AStern() {
    }
    
    public bool FindPath(T start, T end, out IEnumerable<T> unknown)
    {
        unknown = null;
        return false;
    }
}
}