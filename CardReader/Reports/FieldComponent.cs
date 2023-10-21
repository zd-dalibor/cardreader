using CardReader.Reports.Helper;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace CardReader.Reports
{
    internal class FieldComponent : IComponent
    {
        public FieldComponent(string label, string text)
        {
            Label = label;
            Text = text;
        }

        private string Label { get; }

        private string Text { get; }

        public void Compose(IContainer container)
        {
            var labelStyle = TextStyle.Default.FontSize(8).SemiBold();
            var textStyle = TextStyle.Default.FontSize(8);

            container.Row(row => row.RelativeItem().Column(column =>
            {
                column.Item().Text(Label ?? "").Style(labelStyle);
                // column.Item().Text(Text ?? "").Style(textStyle);
                column.Item().DefaultTextStyle(textStyle).Text(text => HardWrap.Wrap(text, Text ?? "", new []{','}));
            }));
        }
    }
}
