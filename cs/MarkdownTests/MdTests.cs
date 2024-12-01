using Markdown;
using FluentAssertions;

namespace MarkdownTests
{
    public class MdTests
    {
        public static IEnumerable<TestCaseData> NestedTagsTestCases
        {
            get
            {
                yield return new TestCaseData("Внутри __двойного выделения _одинарное_ тоже__ работает.",
                        "Внутри <strong>двойного выделения <em>одинарное</em> тоже</strong> работает.")
                    .SetName("WhenItalicTagInBold");
                yield return new TestCaseData("внутри _одинарного __двойное__ не_ работает.",
                        "внутри <em>одинарного __двойное__ не</em> работает.")
                    .SetName("NotRenderBold_WhenBoldInItalic");
                yield return new TestCaseData("# Заголовок __с _разными_ символами__",
                        "<h1>Заголовок <strong>с <em>разными</em> символами</strong></h1>")
                    .SetName("WhenManyTagsInHeader");
                yield return new TestCaseData("_этот текст весь будет\\_ выделен тегом_",
                        "<em>этот текст весь будет_ выделен тегом</em>")
                    .SetName("EscapeSymbol_WhenEscapeNestedInItalic");
                yield return new TestCaseData("__этот текст весь _будет\\__ выделен тегом__",
                        "<strong>этот текст весь <em>будет_</em> выделен тегом</strong>")
                    .SetName("EscapeSymbol_WhenEscapeNestedInItalic");
                yield return new TestCaseData(" случае __пересечения _двойных__ и одинарных_ подчерков",
                        " случае __пересечения _двойных__ и одинарных_ подчерков")
                    .SetName("NotRenderTag_WhenTheyHaveIntersection");
            }
        }
        public static IEnumerable<TestCaseData> IncorrectTagsTests
        {
            get
            {
                yield return new TestCaseData("__Непарные_ символы в рамках одного абзаца не считаются выделением.",
                        "__Непарные_ символы в рамках одного абзаца не считаются выделением.")
                    .SetName("UnpairSymbolsNotATags");
                yield return new TestCaseData("эти_ подчерки_ не считаются",
                        "эти_ подчерки_ не считаются")
                    .SetName("ShouldNotRenderTag_WhenUnderscoresHaveSpaceAfterItSelf");
                yield return new TestCaseData("не считается # ",
                        "не считается # ")
                    .SetName("ShouldNotRenderTag_WhenHeaderNotInStartParagraph");
                yield return new TestCaseData("ра_зных сл_овах ра__зных сл___овах не работает",
                        "ра_зных сл_овах ра__зных сл___овах не работает")
                    .SetName("ShouldNotRenderTag_WhenPairTagSelectPartOfDifferentWords");

            }
        }

        [TestCaseSource(nameof(NestedTagsTestCases))]
        [TestCaseSource(nameof(IncorrectTagsTests))]
        public void Render_Should(string mdText, string expectedTagsToHtml)
        {
            var md = new Md();

            var toHtml = md.Render(mdText);

            toHtml.Should().BeEquivalentTo(expectedTagsToHtml);
        }
    }
}
