namespace Markdown.Tags
{
    public class Header : Tag
    {
        protected override string MdTag => "#";
        protected override string HtmlTag => "h1";
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
