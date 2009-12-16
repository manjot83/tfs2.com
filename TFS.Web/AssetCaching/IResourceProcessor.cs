﻿namespace TFS.Web.AssetCaching
{
    public interface IResourceProcessor
    {
        string ProcessFile(string content, AssetType assetType, string physicalFilePath, string contentPath);
    }
}
