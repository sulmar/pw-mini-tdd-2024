using System.Collections.Generic;
using System.Text;

namespace TestApp
{
    // Testing Strings

    // Markdown syntax
    // https://www.markdownguide.org/basic-syntax/

    public class MarkdownFormatter
    {
        public string FormatAsBold(string content)
        {
            return $"**{content}**";
        }
    }
}
