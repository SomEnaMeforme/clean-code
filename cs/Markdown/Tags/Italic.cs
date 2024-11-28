namespace Markdown.Tags
{
    public class Italic : Tag
    {
        protected override string MdTag => "_";
        protected override string HtmlTag => "em";
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
