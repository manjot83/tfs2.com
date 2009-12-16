﻿using TFS.Web.AssetCaching;

namespace TFS.Web
{
    public class Tags
    {
        public static void ConfigureTags()
        {
            AssetCache.OutputDirectory = "~/Static/Cached/";
#if DEBUG
            AssetCache.CompressAssets = false;
            AssetCache.DebugMode = true;
#else
            AssetCache.CompressAssets = true;
#endif
            AssetCache.AddCss(CSS_INTERNAL_BASE, "~/Static/css/yui_reset.css",
                                                 "~/Static/css/yui_fonts.css",                                 
                                                 "~/Static/css/yui_base.css",
                                                 "~/Static/css/internal_base_style.css",
                                                 "~/Static/css/internal_base_layout.less",
                                                 "~/Static/css/internal_list-table.less",
                                                 "~/Static/css/internal_forms.less");

            AssetCache.AddCssProcessor(new DotLessResourceProcessor());
            AssetCache.AddCssProcessor(new ResourceEmbeddedUrlProcessor());

            AssetCache.AssertConfigurationIsValid();
#if DEBUG
            StaticResourceAssetId.AutoGenerated = true;
#else
            StaticResourceAssetId.AutoGenerated = false;
            StaticResourceAssetId.Key = ApplicationVersion.GetVersion().Replace(".", "");;
#endif
        }

        public const string CSS_INTERNAL_BASE = "internalbase";
    }
}

