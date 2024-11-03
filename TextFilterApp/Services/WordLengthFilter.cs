using System.Text.RegularExpressions;

namespace TextFilterApp.Services
{
    public partial class WordLengthFilter : BaseTextFilter
    {

        public WordLengthFilter(ITextFilter? nextFilter) : base(nextFilter) { }
        private const int WordLength = 3;

        [GeneratedRegex(@"\w+")]
        private static partial Regex WordRegex();

        public override string Filter(string textInput)
        {
            ArgumentNullException.ThrowIfNull(textInput);

            var words = WordRegex().Matches(textInput).Select(m => m.Value);
            var wordsToRemove = words.Where(word => word.Length <= WordLength);

            // Regular expression pattern to match words and their surrounding punctuation
            var pattern = "\\b(" + string.Join("|", wordsToRemove) + ")\\b";
            return Regex.Replace(textInput, pattern, string.Empty);
        }
    }
}
