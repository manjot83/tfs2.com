using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TFS.Web
{
    public interface ICanResolveDependencies
    {
        object Resolve(Type type);
        TObject Resolve<TObject>();
    }
}
