namespace Markdown
{
    public class TokenReader
    {
        private string forRead;
        public int Position { get; }

        public Token ReadWhile(Func<char, bool> accept)
        {
            throw new NotImplementedException();
        }
    }
}
