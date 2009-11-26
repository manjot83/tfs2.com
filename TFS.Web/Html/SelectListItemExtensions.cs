using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TFS.Models;

namespace TFS.Web.Html
{
    public static class SelectListItemExtensions
    {
        public static IEnumerable<SelectListItem> GenerateSelectListItems<TModel>(this IEnumerable<TModel> items, TModel selectedItem)
            where TModel : IKeyedModel
        {
            return items.Select(x => new SelectListItem
            {
                Text = x.DisplayText,
                Value = x.Id,
                Selected = selectedItem != null ? x.Id == selectedItem.Id : false
            });
        }

        public static IEnumerable<SelectListItem> GenerateSelectListItems<TModel>(this IEnumerable<TModel> items, string id)
            where TModel : IKeyedModel
        {
            return items.Select(x => new SelectListItem
            {
                Text = x.DisplayText,
                Value = x.Id,
                Selected = x.Id == id,
            });
        }

        public static IEnumerable<SelectListItem> GenerateSelectListItems(this Enum enumeration)
        {
            var selectedValue = enumeration.ToString();
            var values = Enum.GetNames(enumeration.GetType());
            return values.Select(x => new SelectListItem { Text = x.Replace("_", " ").Trim(), Value = x, Selected = x == selectedValue });
        }
    }
}
