using System.Linq;
using System.Text;
using QuestPDF.Fluent;

namespace CardReader.Reports.Helper
{
    internal static class HardWrap
    {
        public static void Wrap(TextDescriptor ctl, string text, char[] charsToWrap = null)
        {
            var sb = new StringBuilder();
            foreach(var letter in text)
            {
                if (charsToWrap?.Contains(letter) != false)
                {
                    ctl.Span(sb.ToString());
                    ctl.Span(letter.ToString());
                    sb.Clear();
                }
                else
                {
                    sb.Append(letter);
                }
            }

            ctl.Span(sb.ToString());
        }
    }
}
