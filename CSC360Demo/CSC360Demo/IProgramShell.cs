using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC360Demo {
    public interface IProgramShell {
        string InvokeTest();
        string ShellIdentity { get; }
    }
}
