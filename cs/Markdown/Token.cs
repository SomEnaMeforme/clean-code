using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markdown
{
    public record Token
    {
        public int Position { get; }
        public int Length { get; }

        private string source;

        public string GetValue()
        {
            throw new NotImplementedException();
        }
    }
}
