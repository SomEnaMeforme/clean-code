using FluentAssertions;
using Markdown;

namespace MarkdownTests
{
    public class MdParserTests
    {
        public static IEnumerable<TestCaseData> DifferentTagsParseWithoutNestedAndIntersection
        {
            get
            {
                yield return new TestCaseData("_����������_ � ���� __������__",
                        new []
                        {
                            "<em>����������</em>", "<strong>������</strong>"
                        })
                    .SetName("WhenHasTwoTagsWithoutIntersection");
                yield return new TestCaseData("\\_��� ���\\_",
                        new[]
                        {
                            "_", "_"
                        })
                    .SetName("WhenEscapeTagEscapeItalicTagStartAndEnd");
                yield return new TestCaseData("\\\\_��� ��� ����� �������� �����_",
                        new[]
                        {
                            "\\", "<em>��� ��� ����� �������� �����</em>"
                        })
                    .SetName("WhenEscapeTagEscapeItself");
            }
        }
        [TestCase("# Hello World!\nHi, Mari!", "<h1>Hello World!</h1>", TestName = "HeaderTag")]
        [TestCase("dsf\\_sdf", "_", TestName = "EscapeTag")]
        [TestCase("__���������� ����� ��������� �����__", "<strong>���������� ����� ��������� �����</strong>", TestName = "BoldTag")]
        [TestCase("_���������� � ���� ������_", "<em>���������� � ���� ������</em>", TestName = "ItalicTag")]
        [TestCase("# Hello World!", "<h1>Hello World!</h1>", TestName = "HeaderTagWithoutParagraphEndSymbol")]
        public void MdParser_ShouldCorrectParse(string mdText, string expected)
        {
            var parser = new MdParser(mdText, Md.MdTags);

            var tags = parser.GetTags();
            var toHtml = tags[0].RenderToHtml();

            toHtml.Should().Be(expected);
        }

        [TestCaseSource(nameof(DifferentTagsParseWithoutNestedAndIntersection))]
        public void MdParser_ShouldCorrectParseDifferentTags(string mdText, string[] expectedTagsToHtml)
        {
            var parser = new MdParser(mdText, Md.MdTags);

            var tags = parser.GetTags().Select(t => t.RenderToHtml());

            tags.Should().BeEquivalentTo(expectedTagsToHtml);
        }

    }
}