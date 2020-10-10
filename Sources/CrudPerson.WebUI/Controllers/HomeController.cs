using CrudPerson.CommonLibrary.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CrudPerson.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult TestError()
        {
            throw new FailedActionException(nameof(TestError), DateTime.Now.ToLongDateString(), Resources.SharedResources.TestErrorMessage);
        }
    }
}
