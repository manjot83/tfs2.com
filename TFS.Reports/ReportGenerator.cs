using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Xsl;
using System.Xml;
using TFS.Models;
using System.IO;
using System.Xml.XPath;
using Fop.Net;

namespace TFS.Reports
{
    public abstract class ReportGenerator
    {
        XslCompiledTransform xslt;

        public ReportGenerator(string stylesheetResourceName)
        {
            xslt = new XslCompiledTransform();
            using (var stream = typeof(ReportGenerator).Assembly.GetManifestResourceStream(stylesheetResourceName))
            {                
                xslt.Load(new XmlTextReader(stream));
            }
        }

        public abstract string GenerateXmlFor(IReportCapable domainObject);

        public string GenerateXslFoFor(IReportCapable domainObject)
        {
            var xml = GenerateXmlFor(domainObject);
            string xslfo = null;
            using (var inputStream = new MemoryStream(Encoding.Default.GetBytes(xml)))
            {
                var inputDoc = new XPathDocument(new StreamReader(inputStream));
                StringBuilder resultString = new StringBuilder();
                var writer = XmlWriter.Create(resultString);
                xslt.Transform(inputDoc, writer);
                xslfo = resultString.ToString();
            }
            return xslfo;
        }

        public byte[] GenerateReportFor(IReportCapable domainObject)
        {
            var xslfo = GenerateXslFoFor(domainObject);
            return NFop.CreatePDF(xslfo);
        }
    }
}
