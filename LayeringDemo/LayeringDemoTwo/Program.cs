using BusinessDemo;
using DataLayerDemo;
using UILayer;

internal class Program {
    private static void Main(string[] args) {
        ProcessText business = new ProcessText();
        DisplayResults ui = new DisplayResults();
        AccessData data = new AccessData();

        String fileText = data.FetchData("ReadThis.txt");
        String newText = business.Process(fileText);
        ui.Display(newText);
    }
}