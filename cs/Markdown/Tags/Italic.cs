namespace Markdown.Tags;

public class Italic(string markdownText, int tagStart) : Tag(markdownText, tagStart)
{
    protected override string MdTag => "_";
    protected override string HtmlTag => "em";

    protected override Token SelectContext(string markdownText, int tagStart)
    {
        throw new NotImplementedException();
    }

    protected override bool AcceptWhileContextCorrect(char current)
    {
        throw new NotImplementedException();
    }
}