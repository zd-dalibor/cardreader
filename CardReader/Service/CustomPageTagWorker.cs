using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iText.Html2pdf.Attach;
using iText.Html2pdf.Attach.Impl.Tags;
using iText.Html2pdf.Html;
using iText.StyledXmlParser.Node;


namespace CardReader.Service
{
    public class CustomPageTagWorker : DivTagWorker
    {
        public const int PageDivProperty = -10;

        public CustomPageTagWorker(IElementNode element, ProcessorContext context) : base(element, context)
        {
        }

        public override void ProcessEnd(IElementNode element, ProcessorContext context)
        {
            base.ProcessEnd(element, context);
            var elementResult = GetElementResult();
            if (elementResult != null
                && string.IsNullOrEmpty(element.GetAttribute(AttributeConstants.CLASS))
                && element.GetAttribute(AttributeConstants.CLASS).StartsWith("frpage"))
            {
                elementResult.SetProperty(PageDivProperty, element.GetAttribute(AttributeConstants.CLASS));
            }
        }
    }
}
