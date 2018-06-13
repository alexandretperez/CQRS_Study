using MyCQRS.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyCQRS.Application.Interfaces
{
    public interface IPhotographerAppService
    {
        Task Add(PhotographerViewModel model);

        void Update(PhotographerViewModel model);

        void Remove(Guid id);

        List<PhotographerViewModel> GetAll();

        PhotographerViewModel FindById(Guid id);
    }
}