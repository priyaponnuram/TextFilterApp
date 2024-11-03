using TextFilterApp.Services;

namespace TextFilterApp.UnitTests.Services
{
    public class WordWithCharacterFilterTests
    {
        [Fact]
        public void NullValueThrowsArgumentNullException()
        {
            var textFilter = new WordWithCharacterFilter(null);
            Assert.Throws<ArgumentNullException>(() =>
            {
                textFilter.Filter(null);
            });
        }

        [Theory]
        [InlineData("clean what currently the rather", "clean    ")]
        [InlineData("uniT tests that will be able to take multiple text filters", "uniT   will be able     ")]
        [InlineData("a", "a")]
        [InlineData(",* &", ",* &")]
        [InlineData("", "")]
        [InlineData("12 3 4,", "12 3 4,")]
        public void TextReturnsFilteredTextRemovingWordsLessThanOrEqualTo3Characters(string? textInput, string expectedFilteredText)
        {
            var textFilter = new WordWithCharacterFilter(null);
            var actualResult = textFilter.Filter(textInput);
            Assert.Equal(expectedFilteredText, actualResult);
        }
    }
}