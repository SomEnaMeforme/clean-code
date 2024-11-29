namespace Markdown.Tags;

public class Escape(string markdownText, int tagStart) : Tag(markdownText, tagStart)
{
    protected override string MdTag => "\\";
    protected override string HtmlTag => "";

    public override string RenderToHtml() => $"{Context}";

    protected override Token SelectContext(string markdownText, int tagStart)
    {
        throw new NotImplementedException();
    }

    protected override bool AcceptWhileContextCorrect(char current)
    {
        throw new NotImplementedException();
    }
}