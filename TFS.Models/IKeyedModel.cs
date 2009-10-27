using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TFS.Models
{
    public interface IKeyedModel
    {
        string Id { get; }
        string DisplayText { get; }
    }
}
