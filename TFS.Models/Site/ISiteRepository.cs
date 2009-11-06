using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Centro.DomainModel;

namespace TFS.Models.Site
{
    public interface ISiteRepository
    {
        Page GetPage(string uri);
    }
}
