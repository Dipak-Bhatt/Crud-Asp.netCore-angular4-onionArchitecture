using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DBCrud.Ext
{
    public static class ModelStateDictionaryExtensions
    {
        public static IList<string> GetModelErrors(this ModelStateDictionary dict)
        {
            var modelErrors = dict.Keys.SelectMany(k => dict[k].Errors)
                .Select(m => m.ErrorMessage)
                .Where(m => !string.IsNullOrWhiteSpace(m))
                .ToList();
            return modelErrors;
        }
    }
}