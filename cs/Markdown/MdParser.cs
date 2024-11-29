using Markdown.Tags;

namespace Markdown;

public class MdParser
{
    public readonly MdTagsInteractionRules Rules = new ();

    public static readonly IReadOnlyDictionary<char, Dictionary<string, Func<string, int, Tag>>> MdTags = new Dictionary<char, Dictionary<string, Func<string, int, Tag>>>()
    {
        {
            '_', new Dictionary<string, Func<string, int, Tag>>
            {
                { "_", (markdown, tagStart) => new Italic(markdown, tagStart) },
                { "__", (markdown, tagStart) => new Bold(markdown, tagStart) }
            }
        },
        {
            '#', new Dictionary<string, Func<string, int, Tag>>
            {
                { "#", (markdown, tagStart) => new Header(markdown, tagStart) }
            }
        },
        {
            '\\',
            new Dictionary<string, Func<string, int, Tag>>
            {
                { "\\", (markdown, tagStart) => new Escape(markdown, tagStart) }
            }
        }
    };
    
    public Tag[] GetTags(string markdownText)
    {
        throw new NotImplementedException();
    }
}