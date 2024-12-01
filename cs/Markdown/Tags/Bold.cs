namespace Markdown.Tags;

public class Bold : PairTag
{
    protected Bold(string mdText, int tagStart) : base(mdText, tagStart)
    {
        MarkdownText = mdText;
        TagStart = tagStart;
    }

    public static Bold CreateInstance(string markdownText, int tagStart)
    {
        if (tagStart > 0 && char.IsLetter(markdownText[tagStart - 1]))
            return new BoldSelectPartWord(markdownText, tagStart);

        return new BoldSelectFewWords(markdownText, tagStart);
    }

    protected string MarkdownText;
    protected override string MdTag => "__";
    protected override string HtmlTag => "strong";

    public override bool AcceptIfContextEnd(int currentPosition)
    {
        return currentPosition != MarkdownText.Length - 1;
    }

    public override bool AcceptIfContextCorrect(int currentPosition)
    {
        return !((MarkdownText[currentPosition] == '_' && MarkdownText[currentPosition + 1] == '_')
                 || char.IsDigit(MarkdownText[currentPosition])
                 || (currentPosition == TagStart + MdTag.Length && MarkdownText[currentPosition] == ' '));
    }
}