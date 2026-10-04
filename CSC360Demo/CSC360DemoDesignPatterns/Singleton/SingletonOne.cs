using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC360DemoDesignPatterns.Singleton {
    public class SingletonOne {
        private static readonly Lazy<SingletonOne> instance = new Lazy<SingletonOne>(() => new SingletonOne());

        private SingletonOne() {
            InstanceGuid = Guid.NewGuid().ToString();
        }
        public static SingletonOne GetInstance() {
            return instance.Value;
        }

        public String InstanceGuid { get; private set; }
    }
}
