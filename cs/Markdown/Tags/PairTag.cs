using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markdown.Tags
{
    public abstract class PairTag(string markdownText, int tagStart) : Tag(markdownText, tagStart)
    {
        protected bool isCloseByFindCloseTag = false;

        public override void TryCloseTag(int contextEnd, string sourceMdText, out int tagEnd, List<Tag>? nested = null)
        {
            base.TryCloseTag(contextEnd, sourceMdText, out tagEnd, nested);
            if (!isCloseByFindCloseTag)
            {
                IsTagClosed = false;
            }
        }
    }
}
