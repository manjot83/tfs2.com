using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Xsl;
using System.Xml;
using System.IO;
using System.Xml.XPath;
using Fop.Net;
using System.Runtime.Serialization;

namespace TFS.Models.Reports
{
    public class ReportGenerator
    {
        private IReportSerializable domainObject;
        private XslCompiledTransform xslt;

        public ReportGenerator(IReportSerializable domainObject)
        {
            this.domainObject = domainObject;
            xslt = new XslCompiledTransform();
            using (var stream = typeof(ReportGenerator).Assembly.GetManifestResourceStream(this.domainObject.StylesheetResourceName))
            {
                xslt.Load(new XmlTextReader(stream));
            }
        }

        public string GenerateXml()
        {
            var serializer = new DataContractSerializer(domainObject.GetType());
            var resultString = new StringBuilder();
            using (var writer = XmlWriter.Create(resultString))
            {
                serializer.WriteObject(writer, domainObject);
                writer.Flush();
                return resultString.ToString();
            }
        }

        public string GenerateXslFo()
        {
            var xml = GenerateXml();
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

        public byte[] GenerateReport()
        {
            var xslfo = GenerateXslFo();
            return NFop.CreatePDF(xslfo);
        }
    }
}
