using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyCQRS.Application.Interfaces;
using MyCQRS.Application.ViewModels;
using MyCQRS.Domain.Core.Notifications;
using System;
using System.Threading.Tasks;

namespace MyCQRS.Controllers
{
    public class PhotographerController : BaseController
    {
        private readonly IPhotographerAppService _service;

        public PhotographerController(IPhotographerAppService service, INotificationHandler<DomainNotification> notifications) : base(notifications)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var model = _service.GetAll();
            return View(model);
        }

        public IActionResult Add()
        {
            return View("AddOrEdit");
        }

        public IActionResult Edit(Guid id)
        {
            if (id == default(Guid))
                return NotFound();

            var model = _service.FindById(id);
            if (model == null)
                return NotFound();

            return View("AddOrEdit", model);
        }

        public async Task<IActionResult> Save([FromForm] PhotographerViewModel model)
        {
            if (model.Id == null)
                await _service.Add(model);
            else
                _service.Update(model);
            
            if (IsOperationValid())
                return RedirectToAction(nameof(Index));

            return View("AddOrEdit", model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Delete(Guid id)
        {
            _service.Remove(id);

            return RedirectToAction(nameof(Index));
        }
    }
}