using System.Collections.Generic;
using System.Linq;
using IDontWantToDoThisTwice.DataStructures;
using IDontWantToDoThisTwice.PathFinding;
using NUnit.Framework;
using UnityEngine;

namespace Test.Pathfinding
{
    public class AStarTest
    {
        [SetUp]
        public void Setup()
        {
            nodes = new[,]
            {
                {
                    new TestPathNode(new Vector2(0, 0)), new TestPathNode(new Vector2(0, 1)),
                    new TestPathNode(new Vector2(0, 2))
                },
                {
                    new TestPathNode(new Vector2(1, 0)), new TestPathNode(new Vector2(1, 1)),
                    new TestPathNode(new Vector2(1, 2))
                },
                {
                    new TestPathNode(new Vector2(2, 0)), new TestPathNode(new Vector2(2, 1)),
                    new TestPathNode(new Vector2(2, 2))
                }
            };
            nodes[0, 0].Neighbors = new[] { nodes[0, 1], nodes[1, 0] };
            nodes[0, 1].Neighbors = new[] { nodes[0, 0], nodes[1, 1], nodes[0, 2] };
            nodes[0, 2].Neighbors = new[] { nodes[0, 1], nodes[1, 2] };
            nodes[1, 0].Neighbors = new[] { nodes[0, 0], nodes[1, 1], nodes[2, 0] };
            nodes[1, 1].Neighbors = new[] { nodes[0, 1], nodes[1, 0], nodes[1, 2], nodes[2, 1] };
            nodes[1, 2].Neighbors = new[] { nodes[0, 2], nodes[1, 1], nodes[2, 2] };
            nodes[2, 0].Neighbors = new[] { nodes[1, 0], nodes[2, 1] };
            nodes[2, 1].Neighbors = new[] { nodes[2, 0], nodes[1, 1], nodes[2, 2] };
            nodes[2, 2].Neighbors = new[] { nodes[1, 2], nodes[2, 1] };

            aStar = new AStern<TestPathNode>();
        }

        private AStern<TestPathNode> aStar;
        private TestPathNode[,] nodes;

        [Test]
        public void FindPath_ShouldReturnFalseWhenNoPathIsFound()
        {
            // Arrange
            // Act
            var found = aStar.FindPath(nodes[0, 0], nodes[0, 2], out var path);

            // Assert
           Assert.That(found, Is.False); 
        }

        [Test]
        public void FindPath_ShouldFindShortestPath()
        {
            // Arrange
            // Act
            aStar.FindPath(nodes[0, 0], nodes[0, 2], out var path);

            // Assert
            Assert.That(path.ElementAt(0), Is.EqualTo(nodes[0, 0]));
            Assert.That(path.ElementAt(1), Is.EqualTo(nodes[0, 1]));
            Assert.That(path.ElementAt(2), Is.EqualTo(nodes[0, 2]));
        }
    }

    internal class TestPathNode : IPathNode<TestPathNode>, IHeapItem
    {
        public TestPathNode(Vector2 pos)
        {
            WorldPos = pos;
        }

        public double GCost { get; set; }
        public double HCost { get; set; }
        public double FCost { get; set; }
        public IEnumerable<TestPathNode> Neighbors { get; set; }
        public Vector2 WorldPos { get; }

        public double GetCostToNeighbor(TestPathNode neighbour)
        {
            return 1;
        }

        public double CalculateHCost(TestPathNode target)
        {
            return (target.WorldPos - WorldPos).magnitude * 10;
        }

        public double Priority
        {
            get => FCost;
        }
    }
}