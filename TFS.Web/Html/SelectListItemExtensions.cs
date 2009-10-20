using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TFS.Web.Html
{
    public static class SelectListItemExtensions
    {
        public static IEnumerable<SelectListItem> GenerateSelectListItems(this Enum enumeration)
        {
            var selectedValue = enumeration.ToString();
            var values = Enum.GetNames(enumeration.GetType());
            return values.Select(x => new SelectListItem { Text = x, Value = x, Selected = x == selectedValue });
        }
    }
}
