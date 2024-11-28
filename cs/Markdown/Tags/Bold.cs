namespace Markdown.Tags
{
    public class Bold : Tag
    {
        protected override string MdTag => "__";
        protected override string HtmlTag => "strong";
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
