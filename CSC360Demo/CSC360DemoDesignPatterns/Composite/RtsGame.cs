using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC360DemoDesignPatterns.Composite {
    public class RtsGame {
        public RtsGame() {
            LeafAlone = new UnitLeaf();
            CompositeGroup = new UnitGroup();
            CompositeGroup.Add(new UnitLeaf());
            CompositeGroup.Add(new UnitLeaf());
        }
        public IGameUnit LeafAlone { get; set; }
        public IComposite CompositeGroup { get; set; }
    }
}
