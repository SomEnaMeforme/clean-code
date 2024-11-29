using Markdown.Tags;

namespace Markdown;

public class MdParser(string markdownText)
{
    private readonly MdTagsInteractionRules rules = new ();
    
    public Tag[] GetTags(string markdownText)
    {
        throw new NotImplementedException();
    }
    private Tag CreateTag<TTag>(int tagStart, List<Tag> external) where TTag : Tag
    {
        throw new NotImplementedException();
    }
}