using Markdown.Tags;

namespace Markdown;

public class MdParser
{
    public readonly MdTagsInteractionRules rules = new ();

    public static IReadOnlyDictionary<char, Dictionary<string, Func<string, int, Tag>>> mdTags = new Dictionary<char, Dictionary<string, Func<string, int, Tag>>>()
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