using CSC360DemoDesignPatterns.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC360Demo
{
    public class SingletonProgramShell : IProgramShell {
        ISingletonForIoc singletonInstance;
        public SingletonProgramShell(ISingletonForIoc singleton) { 
            singletonInstance = singleton;
            ShellIdentity = Guid.NewGuid().ToString();
        }

        public string ShellIdentity { get; private set; }

        public string InvokeTest() {
            return $"The Singleton Guid is {singletonInstance.InstanceGuid}";
;        }
    }
}
