namespace TextFilterApp.Services
{
    public class BaseTextFilter : ITextFilter
    {
        protected readonly ITextFilter? NextFilter;

        public BaseTextFilter(ITextFilter? nextFilter)
        {
            this.NextFilter = nextFilter;
        }

        public virtual string Filter(string text)
        {
            return NextFilter?.Filter(text) ?? text;
        }
    }
}
