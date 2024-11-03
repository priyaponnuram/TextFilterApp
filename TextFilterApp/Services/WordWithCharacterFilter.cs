using System.Text.RegularExpressions;

namespace TextFilterApp.Services
{
    public partial class WordWithCharacterFilter : BaseTextFilter
    {
        public WordWithCharacterFilter(ITextFilter? nextFilter) : base(nextFilter) { }
        private const char Character = 't';

        [GeneratedRegex(@"\w+")]
        private static partial Regex WordRegex();

        public override string Filter(string textInput)
        {
            ArgumentNullException.ThrowIfNull(textInput);

            var words = WordRegex().Matches(textInput).Select(m => m.Value);
            var wordsToRemove = words.Where(word => word.Contains(Character));

            // Regular expression pattern to match words and their surrounding punctuation
            var pattern = "\\b(" + string.Join("|", wordsToRemove) + ")\\b";
            return Regex.Replace(textInput, pattern, string.Empty);
        }
    }
}
