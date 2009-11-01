using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.XPath;
using System.Xml.Xsl;
using Fop.Net;

namespace TFS.Models.Reports
{
    public class ReportGenerator
    {
        private IReport report;
        private XslCompiledTransform xslt;

        public ReportGenerator(IReport report)
        {
            this.report = report;
            xslt = new XslCompiledTransform();
            using (var stream = typeof(ReportGenerator).Assembly.GetManifestResourceStream(this.report.StylesheetResourceName))
            {
                xslt.Load(new XmlTextReader(stream));
            }
        }

        public string GenerateXml()
        {
            var serializer = new XmlSerializer(report.GetType());
            var resultString = new StringBuilder();
            using (var writer = XmlWriter.Create(resultString))
            {
                serializer.Serialize(writer, report);
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
