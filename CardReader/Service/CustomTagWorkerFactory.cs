using iText.Html2pdf.Attach.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iText.Html2pdf.Attach;
using iText.Html2pdf.Html;
using iText.StyledXmlParser.Node;

namespace CardReader.Service
{
    public class CustomTagWorkerFactory : DefaultTagWorkerFactory
    {
        public override ITagWorker GetCustomTagWorker(IElementNode tag, ProcessorContext context)
        {
            if (TagConstants.DIV.Equals(tag.Name().ToLower()))
            {
                return new CustomPageTagWorker(tag, context);
            }
            return base.GetCustomTagWorker(tag, context);
        }
    }
}
