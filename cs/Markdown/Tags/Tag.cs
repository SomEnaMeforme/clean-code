using System.Text;
using Microsoft.VisualBasic.CompilerServices;

namespace Markdown.Tags;

public abstract class Tag(string markdownText, int tagStart)
{
    public bool IsTagClosed { get; protected set; }
    private Token? context;
    public int TagStart = tagStart;
    protected List<Tag>? NestedTags;
    protected bool IsContextCorrect = true;
    public int TagEnd;
    protected Token Context
    {
        get => context ?? throw new IncompleteInitialization();
        set
        {
            if (!IsTagClosed)
            {
                IsTagClosed = true;
                context = value;
            }
        }
    }
    protected abstract string MdTag { get; }
    protected abstract string HtmlTag { get; }
    public virtual int SkipTag(int position) => position + MdTag.Length;
    public virtual string RenderToHtml()
    {
        var result = new StringBuilder();
        var tags = NestedTags?.ToDictionary(t => t.TagStart) ?? [];
        for (var i = tagStart + MdTag.Length; i < Math.Min(Context.Position + Context.Length, markdownText.Length); )
        {
            if (tags.ContainsKey(i))
            {
                var nested = tags[i];
                result.Append(nested.RenderToHtml());
                i = nested.TagEnd;
            }
            else
            {
                result.Append(markdownText[i]);
                i++;
            }
            
        }
        return $"<{HtmlTag}>{result}</{HtmlTag}>";
    }
    public virtual void TryCloseTag(int contextEnd, string sourceMdText, out int tagEnd, List<Tag>? nested = null)
    {
        var contextStart = tagStart + MdTag.Length;
        tagEnd = contextEnd + MdTag.Length;
        Context = new Token(contextStart, sourceMdText, contextEnd - contextStart);
        TagEnd  = tagEnd;
        NestedTags = nested;
    }

    public abstract bool AcceptIfContextEnd(int currentPosition);
    public virtual bool AcceptIfContextCorrect(int currentPosition) => true;
    public new virtual Type GetType() => base.GetType();
}