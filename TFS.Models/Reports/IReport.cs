using System.Xml.Serialization;

namespace TFS.Models.Reports
{
    public interface IReport : IXmlSerializable
    {
        string StylesheetResourceName { get; }
    }
}
