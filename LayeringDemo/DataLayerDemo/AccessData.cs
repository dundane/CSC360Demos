namespace DataLayerDemo {
    public class AccessData {
        public string FetchData(string connectionString) { 
            return File.ReadAllText("ReadThis.txt");
        }
    }
}
