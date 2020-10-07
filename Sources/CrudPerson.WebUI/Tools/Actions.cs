using Microsoft.AspNetCore.Mvc;
using System;

namespace CrudPerson.WebUI.Tools
{
    public static class Actions
    {
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
