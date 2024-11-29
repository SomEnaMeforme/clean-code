namespace Markdown.Tags;

public class Escape(string markdownText, int tagStart) : Tag(markdownText, tagStart)
{
    protected override string MdTag => "\\";
    protected override string HtmlTag => "";

    public override string RenderToHtml() => $"{Context}";

    public override bool AcceptIfContextEnd(int currentPosition)
    {
        throw new NotImplementedException();
    }
    public override bool AcceptIfContextCorrect(int currentPosition)
    {
        throw new NotImplementedException();
    }
    public override Token UpdateContext(int tagEnd, string sourceMdText)
    {
        throw new NotImplementedException();
    }
}