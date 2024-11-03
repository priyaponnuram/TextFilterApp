using System.Text.RegularExpressions;

namespace TextFilterApp.Services
{
    public partial class VowelInTheMiddleFilter : BaseTextFilter
    {
        private const string Vowels = "aeiouAEIOU";

        public VowelInTheMiddleFilter(ITextFilter? nextFilter) : base(nextFilter) { }

        [GeneratedRegex(@"\w+")]
        private static partial Regex WordRegex();
        
        public override string Filter(string textInput)
        {
            ArgumentNullException.ThrowIfNull(textInput);
            var words = WordRegex().Matches(textInput).Select(m => m.Value);
            var wordsToRemove = words.Where(word =>
            {
                var middle = word.Length / 2;
                if (word.Length % 2 == 0)
                {
                    return Vowels.Contains(word[middle - 1]) || Vowels.Contains(word[middle]);
                }
                return Vowels.Contains(word[middle]);
            });

            // Regular expression pattern to match words and their surrounding punctuation
            var pattern = "\\b(" + string.Join("|", wordsToRemove) + ")\\b";
            return Regex.Replace(textInput, pattern, string.Empty);
        }
    }
}
