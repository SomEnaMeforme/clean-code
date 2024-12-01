namespace Markdown.Tags;

public class Escape(string markdownText, int tagStart) : Tag(markdownText, tagStart)
{
    protected override string MdTag => "\\";
    protected override string HtmlTag => "";

    public override string RenderToHtml()
    {
        return $"{Context.GetValue()}";
    }

    public override bool AcceptIfContextEnd(int currentPosition)
    {
        return currentPosition > tagStart + 1;
    }

    public override bool AcceptIfContextCorrect(int currentPosition)
    {
        return base.AcceptIfContextCorrect(currentPosition)
               && currentPosition < markdownText.Length && Md.MdTags.ContainsKey(markdownText[currentPosition]);
    }

    public override void TryCloseTag(int contextEnd, string sourceMdText, out int tagEnd, List<Tag>? nested = null)
    {
        Context = Md.MdTags.ContainsKey(markdownText[tagStart + 1])
            ? new Token(tagStart + 1, markdownText, 1)
            : new Token(tagStart, markdownText, 1);
        tagEnd = contextEnd;
        TagEnd = tagEnd;
    }
}