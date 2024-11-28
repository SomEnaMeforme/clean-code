namespace Markdown.Tags
{
    public abstract class Tag
    {
        protected Token context;
        protected abstract string MdTag { get; }
        protected abstract string HtmlTag { get; }
        protected abstract Token SelectContext(TokenReader reader);
        public virtual string RenderToHtml(TokenReader reader)
        {
            throw new NotImplementedException();
        }
        protected abstract bool AcceptWhileContextCorrect(char current);
    }
}
