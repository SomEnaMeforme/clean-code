using Markdown.Tags;

namespace Markdown
{
    public class Md
    {
        private static Dictionary<char, Dictionary<string, Tag>> mdTags = new()
            {
                {'_', new () {{"_", new Italic()}, {"__", new Bold()}}},
                {'#', new () {{"#", new Header()}}},
                {'\\', new () {{"\\", new Escape()}}},
            };
        public string Render(string markdownText)
        {
            throw new NotImplementedException();
        }
    }
}

