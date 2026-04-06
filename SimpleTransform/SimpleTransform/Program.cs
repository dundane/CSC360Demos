// See https://aka.ms/new-console-template for more information
string fileContents = string.Empty;

fileContents = File.ReadAllText("readthis.txt");

string transformedText = fileContents.ToUpper();

Console.WriteLine(transformedText);
