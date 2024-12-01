using Markdown.Tags;
using System.Text;

namespace Markdown
{
    public class Md
    {
        public static readonly IReadOnlyDictionary<char, Dictionary<string, Func<string, int, Tag>>> MdTags = new Dictionary<char, Dictionary<string, Func<string, int, Tag>>>()
        {
            {
                '_', new Dictionary<string, Func<string, int, Tag>>
                {
                    { "_", Italic.CreateInstance},
                    { "__", Bold.CreateInstance}
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

        internal static Tag GetOpenTag(int tagStart, string markdownText, out int contextStart)
        {
            var tagBegin = markdownText[tagStart];
            var tags = MdTags[tagBegin];
            var tag = tagBegin == '_' && tagStart != markdownText.Length - 1 && markdownText[tagStart + 1] == '_'
                ? "__"  
                : tagBegin.ToString();
            contextStart = tagStart + tag.Length;
            return tags[tag](markdownText, tagStart);
        }

        public string Render(string markdownText)
        {
            var parser = new MdParser(markdownText);
            var tags = parser.GetTags();
            var result = new StringBuilder();
            var tagsStart = tags.ToDictionary(t => t.TagStart);
            for (var i = 0; i < markdownText.Length; )
            {
                if (tagsStart.ContainsKey(i))
                {
                    result.Append(tagsStart[i].RenderToHtml());
                    i = tagsStart[i].TagEnd++;
                }
                else
                {
                    result.Append(markdownText[i]);
                    i++;
                }
            }
            return result.ToString();
        }
    }
}