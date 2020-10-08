using CrudPerson.CommonLibrary.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace CrudPerson.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            this._logger = logger;
        }

        public IActionResult Index()
        {
            this._logger.LogInformation($"Enter Action {nameof(HomeController)}.{nameof(Index)}");
            return this.View();
        }

        public IActionResult TestError()
        {
            throw new FailedActionException(nameof(TestError), DateTime.Now.ToLongDateString(), Resources.SharedResources.TestErrorMessage);
        }
    }
}
