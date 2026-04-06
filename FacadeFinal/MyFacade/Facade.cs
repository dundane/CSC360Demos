using log4net;

namespace MyFacade {
    public class Facade : IFacade {
        public void LogThis(string logText, string logLevel = "") {
            ILog log = LogManager.GetLogger("MyLogger");

            switch (logLevel.ToUpper()) {
                case "DEBUG":
                    log.Debug(logText);
                    break;
                case "FATAL":
                    log.Fatal(logText);
                    break;
                default:
                    log.Info(logText);
                    break;

            }
        }
    }
}
