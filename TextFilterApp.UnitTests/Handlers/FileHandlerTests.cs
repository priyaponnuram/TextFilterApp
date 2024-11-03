using TextFilterApp.Handlers;

namespace TextFilterApp.UnitTests.Handlers
{
    public class FileHandlerTests
    {
        [Fact]
        public void GetTextFromFileThrowsArgumentNullExceptionWhenFileNameIsNull()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                FileHandler.GetTextFromFile(null);
            });
        }

        [Fact]
        public void GetTextFromFileThrowsArgumentExceptionWhenFileNameIsEmpty()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                FileHandler.GetTextFromFile("");
            });
        }

        [Fact]
        public void IsValidFileNameReturnsFalseWhenFileNameIsNullOrEmpty()
        {
            const string emptyFileName = "";

            var (isValid, errorMessage) = FileHandler.IsValidFileName(null);
            Assert.False(isValid);
            Assert.Equal("cannot be null or empty.", errorMessage);

            (isValid, errorMessage) = FileHandler.IsValidFileName(emptyFileName);
            Assert.False(isValid);
            Assert.Equal("cannot be null or empty.", errorMessage);
        }
    }
}
