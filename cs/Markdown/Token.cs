namespace Markdown;

public record Token
{
    private string source;

    public Token(int position, string source, int length)
    {
        Position = position;
        Length = length;
        this.source = source;
    }

    public int Position { get; }
    public int Length { get; }

    public string GetValue()
    {
        throw new NotImplementedException();
    }
}