namespace TFS.Web.AssetCaching
{
    public class ResourceEmbeddedUrlProcessor : IResourceProcessor
    {
        public string ProcessFile(string content, AssetType assetType, string physicalFilePath, string contentPath)
        {
            return content.Replace("?r=0", "?r=" + StaticResourceAssetId.Key);
        }
    }
}
