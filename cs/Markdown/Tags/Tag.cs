using System.Security.Cryptography;

namespace Markdown.Tags;

public abstract class Tag
{
    protected Tag(string markdownText, int tagStart)
    {
        Context = SelectContext(markdownText, tagStart);
        nestedTags = [];
    }

    private List<Tag> nestedTags;
    public Token Context { get; init; }
    protected abstract string MdTag { get; }
    protected abstract string HtmlTag { get; }
    protected abstract Token SelectContext(string markdownText, int tagStart);
    public virtual string RenderToHtml()
    {
        throw new NotImplementedException();
    }
    protected abstract bool AcceptWhileContextCorrect(char current);
}