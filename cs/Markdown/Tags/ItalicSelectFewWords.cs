namespace Markdown.Tags
{
    internal class ItalicSelectFewWords(string markdownText, int tagStart) : Italic(markdownText, tagStart)
    {
        protected string MdTagClose => "_ ";

        public override bool AcceptIfContextEnd(int currentPosition)
        {
            return base.AcceptIfContextEnd(currentPosition) && (IsCloseTagPositionedInWordEnd(currentPosition)
                                                                || IsStringEndByCloseTag(currentPosition))
                                                            && MarkdownText[currentPosition - 1] != ' ';
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
        public override Type GetType() => typeof(Italic);
    }
}
