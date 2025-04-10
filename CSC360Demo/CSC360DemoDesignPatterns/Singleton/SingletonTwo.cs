using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC360DemoDesignPatterns.Singleton {
    public class SingletonTwo {
        public SingletonTwo() {
            InstanceGuid = Guid.NewGuid().ToString();
        }

        public String InstanceGuid { get; private set; }
        private static readonly Lazy<SingletonTwo> instance = new Lazy<SingletonTwo>(() => new SingletonTwo());
        public static SingletonTwo Instance => instance.Value;
    }
}
