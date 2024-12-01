namespace Markdown.Tags;

public class Header(string markdownText, int tagStart) : Tag(markdownText, tagStart)
{
    protected override string MdTag => "# ";
    protected override string HtmlTag => "h1";

    public override bool AcceptIfContextEnd(int currentPosition)
    {
        return currentPosition > markdownText.Length - 1 || markdownText[currentPosition] == '\n';
    }

    public override bool AcceptIfContextCorrect(int currentPosition)
    {
        return tagStart == 0 || tagStart - 1 == '\n';
    }

    public override void TryCloseTag(int contextEnd, string sourceMdText, out int tagEnd, List<Tag>? nested = null)
    {
        var contextStart = tagStart + MdTag.Length;
        tagEnd = contextEnd == sourceMdText.Length - 1 ? contextEnd : contextEnd + 1;
        Context = new Token(contextStart, sourceMdText, contextEnd - contextStart);
        NestedTags = nested;
        TagEnd = tagEnd;
    }
}