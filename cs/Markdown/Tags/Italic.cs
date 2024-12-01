namespace Markdown.Tags;

public class Italic: PairTag
{
    protected Italic(string mdText, int tagStart) : base(mdText, tagStart)
    {
        MarkdownText = mdText;
        TagStart = tagStart;
    }

    public static Italic CreateInstance(string markdownText, int tagStart)
    {
        if (tagStart > 0 && char.IsLetter(markdownText[tagStart - 1]))
            return new ItalicSelectPartOfOneWord(markdownText, tagStart);

        return new ItalicSelectFewWords(markdownText, tagStart);
    }

    protected string MarkdownText;
    protected override string MdTag => "_";
    protected override string HtmlTag => "em";

    public override bool AcceptIfContextEnd(int currentPosition)
    {
        isCloseByFindCloseTag = MarkdownText[currentPosition] == '_';
        return isCloseByFindCloseTag;
    }
    public override bool AcceptIfContextCorrect(int currentPosition)
    {
        return base.AcceptIfContextCorrect(currentPosition) && !((MarkdownText[currentPosition] == '_' && MarkdownText[currentPosition + 1] == '_')
          || char.IsDigit(MarkdownText[currentPosition])
          || (currentPosition == TagStart + MdTag.Length && MarkdownText[currentPosition] == ' '));
    }
}