namespace Markdown.Tags;

public class Italic(string markdownText, int tagStart) : Tag(markdownText, tagStart)
{
    protected override string MdTag => "_";
    protected override string HtmlTag => "em";

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