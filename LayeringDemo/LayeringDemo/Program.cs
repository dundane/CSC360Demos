// See https://aka.ms/new-console-template for more information

using BusinessDemo;
using DataLayerDemo;
using UILayer;

ProcessText business = new ProcessText();
DisplayResults ui = new DisplayResults();
AccessData data = new AccessData();

String fileText = data.FetchData("ReadThis.txt");
String newText = business.Process(fileText);
ui.Display(newText);