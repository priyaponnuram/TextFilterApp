using TextFilterApp.Services;
using static System.Net.Mime.MediaTypeNames;

namespace TextFilterApp.UnitTests.Services
{
    public class WordLengthFilterTests
    {
        [Fact]
        public void NullValueThrowsArgumentNullException()
        {
            var textFilter = new WordLengthFilter(null);
            Assert.Throws<ArgumentNullException>(() =>
            {
                textFilter.Filter(null);
            });
        }

        [Theory]
        [InlineData("clean what currently the rather", "clean what currently  rather")]
        [InlineData("unit tests that will be able to take multiple text filters", "unit tests that will  able  take multiple text filters")]
        [InlineData("a", "")]
        [InlineData(",* &", ",* &")]
        [InlineData("", "")]
        [InlineData("12 3 4,", "  ,")]
        public void TextReturnsFilteredTextRemovingWordsLessThanOrEqualTo3Characters(string? textInput, string expectedFilteredText)
        {
            var textFilter = new WordLengthFilter(null);
            var actualResult = textFilter.Filter(textInput);
            Assert.Equal(expectedFilteredText, actualResult);
        }
    }
}