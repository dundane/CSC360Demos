namespace SingletonBridgeCommandDemo.Singleton {
    public class RandomSingleton {
        private static Random randomInstance;
        private RandomSingleton() {}

        public static Random Instance {
            get {
                if (randomInstance == null) {
                    randomInstance = new Random();
                }
                return randomInstance;
            }
        }
    }
}
