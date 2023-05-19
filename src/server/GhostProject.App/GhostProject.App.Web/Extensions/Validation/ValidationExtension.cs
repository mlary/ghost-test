using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GhostProject.App.Web.Extensions.Validation
{
    public static class ValidationExtension
    {
        public static IDictionary<string, IList<string>> ToDictionaryResult(this IEnumerable<ValidationFailure> errors)
        {
            var result = new Dictionary<string, IList<string>>();
            foreach (var failure in errors)
            {
                if (result.TryGetValue(failure.PropertyName, out IList<string> errorMessages))
                {
                    errorMessages.Add(failure.ErrorMessage);
                }
                else
                {
                    result.Add(failure.PropertyName, new List<string> {failure.ErrorMessage});
                }
            }

            return result;
        }
        
        public static IDictionary<string, IList<string>> ToDictionaryResult(this ModelStateDictionary modelState)
        {
            
            var result = new Dictionary<string, IList<string>>();
            foreach (var failure in modelState)
            {
                if (result.TryGetValue(failure.Key, out IList<string> errorMessages))
                {
                    (errorMessages as List<string>)?.AddRange(failure.Value.Errors.Select(x => x.ErrorMessage));
                }
                else
                {
                    result.Add(failure.Key, failure.Value.Errors.Select(x => x.ErrorMessage).ToList());
                }
            }

            return result;
        }
    }
}
