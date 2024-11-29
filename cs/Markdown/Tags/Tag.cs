using System.Security.Cryptography;

namespace Markdown.Tags;

public abstract class Tag(string markdownText, int tagStart)
{
    protected Token Context { get; set; }
    protected abstract string MdTag { get; }
    protected abstract string HtmlTag { get; }
    public virtual string RenderToHtml()
    {
        throw new NotImplementedException();
    }
    public abstract Token UpdateContext(int tagEnd, string sourceMdText);
    public abstract bool AcceptIfContextEnd(int currentPosition);
    public abstract bool AcceptIfContextCorrect(int currentPosition);
}