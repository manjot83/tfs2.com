using System.Xml.Serialization;

namespace TFS.Models.Reports
{
    public interface IXmlReport : IXmlSerializable
    {
        string XmlStylesheetResourceName { get; }
    }
}
