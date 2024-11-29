namespace Markdown.Tags;

public class Header(string markdownText, int tagStart) : Tag(markdownText, tagStart)
{
    protected override string MdTag => "#";
    protected override string HtmlTag => "h1";

    protected override Token SelectContext(string markdownText, int tagStart)
    {
        throw new NotImplementedException();
    }

    protected override bool AcceptWhileContextCorrect(char current)
    {
        throw new NotImplementedException();
    }
}