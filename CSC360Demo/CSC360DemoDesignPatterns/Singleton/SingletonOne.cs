using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC360DemoDesignPatterns.Singleton {
    public class SingletonOne {
        private static SingletonOne instance;

        private SingletonOne() {
            InstanceGuid = Guid.NewGuid().ToString();
        }
        public static SingletonOne GetInstance() {
            if (instance == null)
            {
                instance = new SingletonOne();
            }
            return instance;
        }

        public String InstanceGuid { get; private set; }
    }
}
