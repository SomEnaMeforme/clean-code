﻿namespace Markdown;

public record Token
{
    private readonly string source;

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
        return new string(source.Substring(Position, Length));
    }
}