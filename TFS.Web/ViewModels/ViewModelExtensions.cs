using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using TFS.Models.Validation;

namespace TFS.Web.ViewModels
{
    public static class ViewModelExtensions
    {
        public static void Validate(this IValidatable viewModel, ModelStateDictionary modelState, string prefix)
        {
            var fixedPrefix = prefix ?? string.Empty;
            if (!string.IsNullOrEmpty(fixedPrefix) && !fixedPrefix.EndsWith("."))
                fixedPrefix += ".";
            foreach (var error in viewModel.ValidationErrors())
            {
                var key = fixedPrefix + error.PropertyName;
                modelState.AddModelError(key, error.ErrorMessage);
            }
        }
    }
}
