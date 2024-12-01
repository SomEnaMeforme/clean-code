using FluentAssertions;
using Markdown;
using Markdown.Tags;

namespace MarkdownTests
{
    public class MdRulesForNestedTagsTests
    {
        [Test]
        public void InsideBold_ItalicShouldWork()
        {
            var rules = new MdRulesForNestedTags();

            var result = rules.IsNestedTagWorks(Bold.CreateInstance("", 0), Italic.CreateInstance("", 0));

            result.Should().BeTrue();
        }
        [Test]
        public void InsideItalic_BoldShouldNotWork()
        {
            var rules = new MdRulesForNestedTags();

            var result = rules.IsNestedTagWorks(Italic.CreateInstance("", 0), Bold.CreateInstance("", 0));

            result.Should().BeFalse();
        }

        [Test]
        public void InsideHeader_AllTagWorks()
        {
            var rules = new MdRulesForNestedTags();

            var result = new [] {
                rules.IsNestedTagWorks(new Header("", 0), Bold.CreateInstance("", 0)),
                rules.IsNestedTagWorks(new Header("", 0), Italic.CreateInstance("", 0)),
                rules.IsNestedTagWorks(new Header("", 0), new Escape("", 0))};

            result.Should().AllBeEquivalentTo(true);
        }
    }
}
