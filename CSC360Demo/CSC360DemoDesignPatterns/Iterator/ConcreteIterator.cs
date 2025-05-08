using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC360DemoDesignPatterns.Iterator;
public class ConcreteIterator<T> : IIterator<T> {


  private readonly T[] collection;
  private int currentIndex = -1;

  public ConcreteIterator(T[] collection) {
    this.collection = collection;
  }

  public T Current => collection[currentIndex];

  public bool MoveNext() {
    if (currentIndex + 1 < collection.Length) {
      currentIndex++;
      return true;
    }
    return false;
  }

  public void Reset() {
    currentIndex = -1;
  }

}
