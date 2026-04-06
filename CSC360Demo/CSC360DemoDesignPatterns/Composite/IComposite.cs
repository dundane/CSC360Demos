using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC360DemoDesignPatterns.Composite {
    public interface IComposite : IGameUnit {
     public void Add(IGameUnit unit);
        public void Remove(IGameUnit unit);
        public IGameUnit GetChild(int index);
    }
}
