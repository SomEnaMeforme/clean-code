namespace Markdown.Tags
{
    public class Escape : Tag
    {
        protected override string MdTag => "\\";
        protected override string HtmlTag => "";
        protected override Token SelectContext(TokenReader reader)
        {
            throw new NotImplementedException();
        }
        protected override bool AcceptWhileContextCorrect(char current)
        {
            throw new NotImplementedException();
        }
    }
}
