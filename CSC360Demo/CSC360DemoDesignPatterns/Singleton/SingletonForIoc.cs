using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC360DemoDesignPatterns.Singleton {
    public class SingletonForIoc : ISingletonForIoc {
        public SingletonForIoc() {
            InstanceGuid = Guid.NewGuid().ToString();
        }
        public String InstanceGuid { get; private set; }
    }
}
