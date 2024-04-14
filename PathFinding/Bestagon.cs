using System.Collections.Generic;
using UnityEngine;

namespace IDontWantToDoThisTwice.PathFinding {
public class Bestagon: IPathNode<Bestagon> {

   public IEnumerable<Bestagon> Neighbors { get; set; }
   public Vector2 WorldPos { get; set; }
   public double GetCostToNeighbor(Bestagon neighbour)
   {
      return 10;
   }

   public double CalculateHCost(Bestagon target)
   {
      return (target.WorldPos - WorldPos).magnitude*10;
   }

   public double FCost { get; set; }
   public double GCost { get; set; }

   public Bestagon(Vector2 worldPos)
   {
      WorldPos = worldPos;
   }
}
}