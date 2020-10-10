using CrudPerson.WebUI.Models;
using CrudPerson.WebUI.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Threading.Tasks;

namespace CrudPerson.WebUI.Controllers
{
    public class PersonController : Controller
    {
        #region Constructor
        public PersonController(IPersonModel personModel, IStringLocalizer<PersonController> localizer)
        {
            this._personModel = personModel;
            this._localizer = localizer;
        }
        #endregion

        #region Private properties
        private IPersonModel _personModel { get; }
        private IStringLocalizer<PersonController> _localizer { get; }
        #endregion

        #region Private Methods
        private async Task<IActionResult> ViewPersonByIdentifierWithGuardsAsync(string viewName, Guid? identifier)
        {
            if (identifier == null || identifier == Guid.Empty)
            {
                return this.NotFound();
            }

            PersonViewModel person = await this._personModel.ReadAsync(identifier.Value).ConfigureAwait(false);
            if (person == null)
            {
                return this.NotFound();
            }
            return this.View(viewName, person);
        }

        private async Task<IActionResult> EditPersonWithGuardsAsync(PersonViewModel personModel, Func<PersonViewModel, Task<PersonViewModel>> editionFunctionAsync, string viewName)
        {
            if (personModel == null)
            {
                return this.NotFound();
            }
            if (this.ModelState.IsValid)
            {
                PersonViewModel editedPerson = await editionFunctionAsync(personModel)
                                                        .ConfigureAwait(false);
                return this.RedirectToAction(nameof(Details), new { identifier = editedPerson.Identifier });
            }
            return this.View(viewName, personModel);

        }
        #endregion

        #region Public Methods
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return this.View(await this._personModel.ListAllPersonBasicAsync().ConfigureAwait(false));
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid? identifier)
        {
            return await this.ViewPersonByIdentifierWithGuardsAsync(nameof(Details), identifier).ConfigureAwait(false);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PersonViewModel personViewModel)
        {
            return await this.EditPersonWithGuardsAsync(personViewModel, this._personModel.CreateAsync, nameof(Edit)).ConfigureAwait(false);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid? identifier)
        {
            return await this.ViewPersonByIdentifierWithGuardsAsync(nameof(Edit), identifier).ConfigureAwait(false);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PersonViewModel personViewModel)
        {
            return await this.EditPersonWithGuardsAsync(personViewModel, this._personModel.UpdateAsync, nameof(Edit)).ConfigureAwait(false);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid? identifier)
        {
            return await this.ViewPersonByIdentifierWithGuardsAsync(nameof(Delete), identifier).ConfigureAwait(false);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName(nameof(Delete))]
        public async Task<IActionResult> DeleteConfirmed(Guid identifier)
        {
            if (identifier == Guid.Empty)
            {
                return this.NotFound();
            }

            PersonViewModel person = await this._personModel.DeteleAsync(identifier).ConfigureAwait(false);

            if (person == null)
            {
                return this.NotFound();
            }
            return this.RedirectToAction(nameof(Index));
        }
        #endregion


    }
}
