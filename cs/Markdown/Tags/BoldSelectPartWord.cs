namespace Markdown.Tags
{
    internal class BoldSelectPartWord(string markdownText, int tagStart) : Bold(markdownText, tagStart)
    {
        public override bool AcceptIfContextEnd(int currentPosition)
        {
            isCloseByFindCloseTag = base.AcceptIfContextEnd(currentPosition)
                                    && currentPosition + MdTag.Length < MarkdownText.Length
                                    && MarkdownText.Substring(currentPosition, MdTag.Length) == MdTag;
            return isCloseByFindCloseTag;
        }

        public override bool AcceptIfContextCorrect(int currentPosition)
        {
            return MarkdownText[currentPosition] == ' ' && base.AcceptIfContextCorrect(currentPosition);
        }
        public override Type GetType() => typeof(Bold);
    }
}
