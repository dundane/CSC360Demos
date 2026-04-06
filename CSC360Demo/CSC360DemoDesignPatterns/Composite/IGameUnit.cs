using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC360DemoDesignPatterns.Composite {
    public interface IGameUnit {
        public void Attack();
        public String UnitName { get; set; }
    }
}
