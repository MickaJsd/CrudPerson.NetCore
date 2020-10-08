using CrudPerson.WebUI.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CrudPerson.WebUI.Controllers
{
    public class ErrorController : Controller
    {
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Index(int? statusCode = null)
        {
            IStatusCodeReExecuteFeature reExecuteFeature = this.HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            ErrorViewModel errorModel = new ErrorViewModel { 
                RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier ,
                StatusCode = statusCode,
                OriginalPath = reExecuteFeature?.OriginalPath,
                OriginalQueryString = reExecuteFeature?.OriginalQueryString
            };
            return this.View("Error", errorModel);
        }
    }
}
