using Microsoft.AspNetCore.Mvc;
using System;

namespace CrudPerson.WebUI.Tools
{
    public static class Actions
    {
        /// <summary>
        /// Gets the name of the specified controller, ready to use in a URL building process
        /// </summary>
        /// <typeparam name="TController">Type of the target controller</typeparam>
        /// <returns>The name of the coutroller minus the term "controller"</returns>
        public static string Controller<TController>()
            where TController : Controller
        {
            string controllerName = typeof(TController).Name;
            if (string.IsNullOrWhiteSpace(controllerName))
            {
                return string.Empty;
            }
            return controllerName.Replace("Controller", "", StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
