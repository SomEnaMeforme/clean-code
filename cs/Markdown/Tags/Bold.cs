namespace Markdown.Tags;

public class Bold(string markdownText, int tagStart) : Tag(markdownText, tagStart)
{
    protected override string MdTag => "__";
    protected override string HtmlTag => "strong";

    protected override Token SelectContext(string markdownText, int tagStart)
    {
        throw new NotImplementedException();
    }

    protected override bool AcceptWhileContextCorrect(char current)
    {
        throw new NotImplementedException();
    }
}