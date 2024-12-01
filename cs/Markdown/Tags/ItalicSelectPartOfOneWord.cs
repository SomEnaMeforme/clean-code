namespace Markdown.Tags
{
    internal class ItalicSelectPartOfOneWord(string markdownText, int tagStart) : Italic(markdownText, tagStart)
    {
        public override bool AcceptIfContextEnd(int currentPosition)
        {
            return base.AcceptIfContextEnd(currentPosition)
                   && currentPosition + MdTag.Length < MarkdownText.Length
                   && MarkdownText.Substring(currentPosition, MdTag.Length) == MdTag;
        }

        public override bool AcceptIfContextCorrect(int currentPosition)
        {
            return MarkdownText[currentPosition] == ' ' && base.AcceptIfContextCorrect(currentPosition);
        }
        public override Type GetType() => typeof(Italic);
    }
}
