﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC360DemoDesignPatterns.Flyweight;
public interface IFlyweightSoldier {
  Int32 OffensiveStrength { get; set; }
  Int32 DefensiveStrength { get; set; }
}
