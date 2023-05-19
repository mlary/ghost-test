using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GhostProject.App.Web.Exceptions
{
    public class ModelValidationFailedException : Exception
    {
        public ModelStateDictionary ModelState { get; }

        public override string Message { get; }

        public ModelValidationFailedException(string message, ModelStateDictionary modelState)
        {
            ModelState = modelState;
            Message = message;
        }
    }
}
