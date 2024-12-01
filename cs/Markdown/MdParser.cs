using Markdown.Tags;

namespace Markdown;

public class MdParser(string markdownText)
{
    private readonly MdRulesForNestedTags rules = new();

    private class ReaderPosition
    {
        public int Position { get; set; }
    }

    public Tag[] GetTags()
    {
        var result = new List<Tag>();
        var current = new ReaderPosition();
        while (current.Position < markdownText.Length)
        {
            if (Md.MdTags.ContainsKey(markdownText[current.Position]))
            {
                var newTag = CreateTag(current, []);
                if (newTag.IsTagClosed)
                    result.Add(newTag);
            }
            else current.Position++;
        }
        return result.ToArray();
    }

    private Tag CreateTag(ReaderPosition current, List<Tag> external)
    {
        var openTag = Md.GetOpenTag(current.Position, markdownText, out int contextStart);
        current.Position = contextStart;
        var isContextCorrect = true;
        var nested = new List<Tag>();
        while (current.Position < markdownText.Length && !openTag.AcceptIfContextEnd(current.Position))
        {
            if (Md.MdTags.ContainsKey(markdownText[current.Position]) && openTag is not Escape)
            {
                var newTag = CreateTag(current, [openTag]);
                if (newTag.IsTagClosed)
                {
                    nested.Add(newTag);
                }
            }
            else
            {
                isContextCorrect = isContextCorrect && openTag.AcceptIfContextCorrect(current.Position);
                current.Position++;
            }
        }

        if ((external.Count == 0 || rules.IsNestedTagWorks(external[^1], openTag)) && isContextCorrect)
        {
            openTag.TryCloseTag(current.Position, markdownText, out int tagEnd, nested);
            current.Position = tagEnd;
        }
        else
        {
            current.Position = openTag.SkipTag(current.Position);
        }
        
        return openTag;
    }
}