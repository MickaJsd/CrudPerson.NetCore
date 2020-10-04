using CrudPerson.BusinessLibrary.BusinessModel;
using CrudPerson.BusinessLibrary.Managers;
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
        private IPersonManager _personManager { get; }
        #endregion

        #region Private Methods
        private async Task<IActionResult> ViewPersonByIdentifierWithGuardsAsync(string viewName, Guid? identifier)
        {
            if (identifier == null || identifier == Guid.Empty)
            {
                return this.NotFound();
            }

            Person person = await this._personManager.ReadAsync(identifier.Value)
                                               .ConfigureAwait(false);
            if (person == null)
            {
                return this.NotFound();
            }
            return this.View(viewName, person);
        }

        private async Task<IActionResult> EditPersonWithGuardsAsync(Person personModel, Func<Person, Task<Person>> editionFunctionAsync, string viewName)
        {
            if (personModel == null)
            {
                return this.NotFound();
            }
            if (this.ModelState.IsValid)
            {
                Person editedPerson = await editionFunctionAsync(personModel)
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
        public async Task<IActionResult> Create(Person personViewModel)
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
        public async Task<IActionResult> Edit(Person personViewModel)
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
            if (identifier == Guid.Empty)
            {
                return this.NotFound();
            }

            Person person = await this._personManager.DeteleAsync(identifier)
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
