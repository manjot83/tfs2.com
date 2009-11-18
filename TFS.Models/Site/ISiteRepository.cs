using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TFS.Models;

namespace TFS.Models.Site
{
    public interface ISiteRepository
    {
        Page GetPage(string uri);
    }
}
