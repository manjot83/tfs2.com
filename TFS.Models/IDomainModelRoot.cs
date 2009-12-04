using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TFS.Models
{
    public interface IDomainModelRoot
    {
        TModel GetDomainObject<TModel>(object id) where TModel : BaseDomainObject;
    }
}
