using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC360DemoDesignPatterns.Iterator;
public class ConcreteCollection<T> : IEnumeratorator<T>{

  private readonly T[] items;

  public ConcreteCollection(T[] items) {
    this.items = items;
  }

  public IIterator<T> CreateIterator() {
    return new ConcreteIterator<T>(items);
  }


}
