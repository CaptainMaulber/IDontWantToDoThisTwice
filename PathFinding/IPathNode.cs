using System.Collections.Generic;
using UnityEngine;

namespace IDontWantToDoThisTwice.PathFinding
{
    public interface IPathNode<T>
    {
        double GCost { get; set; }
        double FCost { get; set; }

        IEnumerable<T> Neighbors { get; set; }

        Vector2 WorldPos { get; }

        double GetCostToNeighbor(T neighbour);
        double CalculateHCost(T target);
    }
}