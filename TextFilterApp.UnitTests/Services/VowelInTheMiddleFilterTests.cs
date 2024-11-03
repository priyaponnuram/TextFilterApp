using TextFilterApp.Services;

namespace TextFilterApp.UnitTests.Services
{
    public class VowelInTheMiddleFilterTests
    {
        [Fact]
        public void NullValueThrowsArgumentNullException()
        {
            var textFilter = new VowelInTheMiddleFilter(null);
            Assert.Throws<ArgumentNullException>(() =>
            {
                textFilter.Filter(null);
            });
        }

        [Theory]
        [InlineData("clean what currently the rather", "   the rather")]
        [InlineData("unit tests that will be able to take multiple text filters", " tests    able     filters")]    
        [InlineData("a", "")]
        [InlineData(",* &", ",* &")]
        [InlineData("", "")]
        [InlineData("12 3 4,", "12 3 4,")]
        public void TextWithNoPunctuationsReturnsFilteredText(string? textInput, string expectedFilteredText)
        {
            var textFilter = new VowelInTheMiddleFilter(null); 
            var actualResult = textFilter.Filter(textInput); 
            Assert.Equal(expectedFilteredText, actualResult);
        }

        [Theory]
        [InlineData("clean, what? currently the rather!", ", ?  the rather!")]
        [InlineData("unit. tests- that will be able,, to take multiple text filters?", ". tests-    able,,     filters?")]
        [InlineData("a!,", "!,")]
        [InlineData(",* &", ",* &")]
        [InlineData("12 3 4,", "12 3 4,")]
        public void TextWithPunctuationsReturnsFilteredText(string? textInput, string expectedFilteredText)
        {
            var textFilter = new VowelInTheMiddleFilter(null);
            var actualResult = textFilter.Filter(textInput);
            Assert.Equal(expectedFilteredText, actualResult);
        }
    }
}