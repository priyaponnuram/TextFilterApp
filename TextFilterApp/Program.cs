using TextFilterApp.Handlers;
using TextFilterApp.Services;

const string filePath = "TextInput.txt";

try
{
    var text = FileHandler.GetTextFromFile(filePath);
    var filterChain = new VowelInTheMiddleFilter(new WordWithCharacterFilter(new WordLengthFilter(null)));

    ArgumentNullException.ThrowIfNull(text);

    var fullyFilteredText = filterChain.Filter(text);
    Console.WriteLine(fullyFilteredText);
}
catch (IOException e)
{
    Console.WriteLine("Error reading file: " + e.Message);
}