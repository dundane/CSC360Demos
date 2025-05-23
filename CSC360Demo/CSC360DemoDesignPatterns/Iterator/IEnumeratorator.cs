﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC360DemoDesignPatterns.Iterator;
public interface IEnumeratorator<T> {
  IIterator<T> CreateIterator();
}
