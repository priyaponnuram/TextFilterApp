namespace TextFilterApp.Handlers
{
    public static class FileHandler
    {
        public static string? GetTextFromFile(string filename)
        {
            var (isValid, errorMessage) = IsValidFileName(filename);
            if (!isValid)
            {
                throw new ArgumentException(nameof(filename),
                    $"{nameof(filename)} {errorMessage}");
            }

            return File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), filename));
        }

        public static (bool, string?) IsValidFileName(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return (false, "cannot be null or empty.");
            }

            var invalidChars = Path.GetInvalidFileNameChars();
            foreach (var c in invalidChars)
            {
                if (fileName.Contains(c))
                {
                    return (false, $"contains invalid character: {c}");
                }
            }

            return fileName.Length > 255 ? (false, "should be 255 characters or less.") : (true, null);
        }
    }
}