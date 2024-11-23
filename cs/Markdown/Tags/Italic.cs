using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markdown.Tags
{
    public class Italic : Tag
    {
        private List<Tag> nestedTags = new();
        protected override string mdTag => "_";
        protected override string htmlTag => "<em>";
        protected override Token SelectContext(TokenReader reader)
        {
            throw new NotImplementedException();
        }
        protected override bool AcceptWhileContextCorrect(char current)
        {
            throw new NotImplementedException();
        }
    }
}
