using CrudPerson.BusinessLibrary.Managers;
using CrudPerson.BusinessLibrary.ViewModels;
using CrudPerson.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CrudPerson.WebUI.Controllers
{
    public class PersonController : Controller
    {
        #region Constructor
        public PersonController(IPersonManager personManager)
        {
            this._personManager = personManager;
        }
        #endregion

        #region Private properties
        private IPersonManager _personManager { get; set; }
        #endregion

        #region Private Methods
        private async Task<IActionResult> ViewPersonByIdentifierWithGuardsAsync(string viewName, Guid? identifier)
        {
            if (identifier == null)
            {
                return this.NotFound();
            }

            IPersonViewModel person = await this._personManager.ReadAsync(identifier.Value)
                                               .ConfigureAwait(false);
            if (person == null)
            {
                return this.NotFound();
            }
            return this.View(viewName, person);
        }

        private async Task<IActionResult> EditPersonWithGuardsAsync(IPersonViewModel personViewModel, Func<IPersonViewModel, Task<IPersonViewModel>> editionFunctionAsync, string viewName)
        {
            if (this.ModelState.IsValid)
            {
                IPersonViewModel editedPerson = await editionFunctionAsync(personViewModel)
                                                        .ConfigureAwait(false);
                return this.RedirectToAction(nameof(Details), new { identifier = editedPerson.Identifier });
            }
            return this.View(viewName, personViewModel);

        }
        #endregion

        #region Public Methods
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return this.View(await this._personManager.ListAllAsync()
                        .ConfigureAwait(false));
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid? identifier)
        {
            return await this.ViewPersonByIdentifierWithGuardsAsync(nameof(Details), identifier)
                        .ConfigureAwait(false);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PersonEditModel personViewModel)
        {
            return await this.EditPersonWithGuardsAsync(personViewModel, this._personManager.CreateAsync, nameof(Edit))
                            .ConfigureAwait(false);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid? identifier)
        {
            return await this.ViewPersonByIdentifierWithGuardsAsync(nameof(Edit), identifier)
                        .ConfigureAwait(false);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PersonEditModel personViewModel)
        {
            return await this.EditPersonWithGuardsAsync(personViewModel, this._personManager.UpdateAsync, nameof(Edit))
                            .ConfigureAwait(false);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid? identifier)
        {
            return await this.ViewPersonByIdentifierWithGuardsAsync(nameof(Delete), identifier)
                        .ConfigureAwait(false);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName(nameof(Delete))]
        public async Task<IActionResult> DeleteConfirmed(Guid identifier)
        {
            if (identifier == null)
            {
                return this.NotFound();
            }

            IPersonViewModel person = await this._personManager.DeteleAsync(identifier)
                                               .ConfigureAwait(false);
            if (person == null)
            {
                return this.NotFound();
            }
            return this.RedirectToAction(nameof(Index));
        }
        #endregion


    }
}
