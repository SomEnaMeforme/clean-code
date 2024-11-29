namespace Markdown.Tags;

public class Bold(string markdownText, int tagStart) : Tag(markdownText, tagStart)
{
    protected override string MdTag => "__";
    protected override string HtmlTag => "strong"; 

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