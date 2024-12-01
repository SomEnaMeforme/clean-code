using Markdown.Tags;

namespace Markdown;

public class MdRulesForNestedTags
{
    private readonly Dictionary<Type, HashSet<Type>> possibleNested = new()
    {
        {typeof(Header), new () { typeof(Bold), typeof(Italic), typeof(Escape)}},
        {typeof(Bold), new () { typeof(Italic), typeof(Escape)}},
        {typeof(Italic), new () { typeof(Escape)}}
    };

    public bool IsNestedTagWorks(Tag external, Tag nested) => possibleNested.ContainsKey(external.GetType()) && possibleNested[external.GetType()].Contains(nested.GetType());
}