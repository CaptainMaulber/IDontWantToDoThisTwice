using IDontWantToDoThisTwice.DataStructures;
using NUnit.Framework;

namespace Test.DataStructuresTests {
[TestFixture]
public class BinaryHeapTest {
   [SetUp]
   public void SetUp() {
      
      _toTest = new BinaryHeap<TestHeapItem>(7);
   }
   
   private BinaryHeap<TestHeapItem> _toTest;

   [Test]
   public void Heap_ShouldAddCorrectly() {
      TestHeapItem first = new TestHeapItem(5);
      _toTest.Add( first);
      Assert.That(_toTest.Count, Is.EqualTo(1));
      Assert.That(_toTest.Peek(), Is.EqualTo(first));
      
      TestHeapItem second = new TestHeapItem(4);
      _toTest.Add(second);
      Assert.That(_toTest.Count, Is.EqualTo(2));
      Assert.That(_toTest.Peek(), Is.EqualTo(second));

      TestHeapItem third = new TestHeapItem(8);
      _toTest.Add(third);
      Assert.That(_toTest.Count, Is.EqualTo(3));
      Assert.That(_toTest.Peek(), Is.EqualTo(second));
   }

   [Test]
   public void Heap_ShouldRemoveCorrectly() {
      TestHeapItem first = new TestHeapItem(7);
      TestHeapItem second = new TestHeapItem(5);
      TestHeapItem third = new TestHeapItem(3);
      TestHeapItem fourth = new TestHeapItem(1);

      _toTest.Add(first);
      _toTest.Add(second);
      _toTest.Add(third);
      _toTest.Add(fourth);
      
      Assert.That(_toTest.Count, Is.EqualTo(4));
      Assert.That(_toTest.RemoveMin(), Is.EqualTo(fourth));
      Assert.That(_toTest.Count, Is.EqualTo(3));
      
      Assert.That(_toTest.RemoveMin(), Is.EqualTo(third));
      Assert.That(_toTest.Count, Is.EqualTo(2));
      
      Assert.That(_toTest.RemoveMin(), Is.EqualTo(second));
      Assert.That(_toTest.Count, Is.EqualTo(1));
      
      Assert.That(_toTest.RemoveMin(), Is.EqualTo(first));
      Assert.That(_toTest.Count, Is.EqualTo(0));
   }

   [Test]
   public void EmptyHeap_ShouldReturnDefault() {
      Assert.That(_toTest.RemoveMin(), Is.Null);
      Assert.That(_toTest.Count, Is.EqualTo(0));
   }

   [Test]
   public void Heap_ShouldReturnFalseIfFull() {
      BinaryHeap<TestHeapItem> smallHeap = new BinaryHeap<TestHeapItem>(1);
      Assert.That(smallHeap.Add(new TestHeapItem(4)), Is.True);
      Assert.That(smallHeap.Add(new TestHeapItem(9)), Is.False);
   }
}

internal class TestHeapItem : IHeapItem {
   public TestHeapItem(float priority) {
      Priority = priority;
   }
   public double Priority { get; }
   
}
}