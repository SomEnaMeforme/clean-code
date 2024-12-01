namespace Markdown.Tags
{
    internal class BoldSelectFewWords(string markdownText, int tagStart) : Bold(markdownText, tagStart)
    {
        protected string MdTagClose => "__ ";

        public override bool AcceptIfContextEnd(int currentPosition)
        {
            isCloseByFindCloseTag = base.AcceptIfContextEnd(currentPosition) && (IsCloseTagPositionedInWordEnd(currentPosition)
                                                                                 || IsStringEndByCloseTag(currentPosition))
                                                                             && MarkdownText[currentPosition - 1] != ' ';
            return isCloseByFindCloseTag;
        }

        private bool IsStringEndByCloseTag(int currentPosition)
        {
            return MarkdownText.Substring(currentPosition, MdTag.Length) == MdTag &&
                   currentPosition + MdTag.Length == MarkdownText.Length;
        }

        private bool IsCloseTagPositionedInWordEnd(int currentPosition)
        {
            return currentPosition + MdTagClose.Length < MarkdownText.Length
                   && (MarkdownText.Substring(currentPosition, MdTagClose.Length) == MdTagClose);
        }

        public override Type GetType() => typeof(Bold);
    }
}
