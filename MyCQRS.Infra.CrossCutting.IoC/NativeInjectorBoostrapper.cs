using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using MyCQRS.Application.Interfaces;
using MyCQRS.Application.Services;
using MyCQRS.Domain.Core.Bus;
using MyCQRS.Domain.Core.Notifications;
using MyCQRS.Domain.Photographers.Commands;
using MyCQRS.Domain.Photographers.Events;
using MyCQRS.Domain.Photographers.Interfaces;
using MyCQRS.Infra.CrossCutting.Bus;
using MyCQRS.Infra.Data.Data;
using MyCQRS.Infra.Data.Repositories;

namespace MyCQRS.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBoostrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext Dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Domain Bus/MediatR
            services.AddScoped<IBus, InMemoryBus>();

            // Application
            services.AddScoped<IPhotographerAppService, PhotographerAppService>();

            // Domain Events
            services.AddScoped<INotificationHandler<PhotographerAddedEvent>, PhotographerEventHandler>();
            services.AddScoped<INotificationHandler<PhotographerUpdatedEvent>, PhotographerEventHandler>();
            services.AddScoped<INotificationHandler<PhotographerRemovedEvent>, PhotographerEventHandler>();
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            // Domain Commands
            services.AddScoped<IRequestHandler<AddPhotographerCommand, Unit>, PhotographerCommandHandler>();
            services.AddScoped<IRequestHandler<UpdatePhotographerCommand, Unit>, PhotographerCommandHandler>();
            services.AddScoped<IRequestHandler<RemovePhotographerCommand, Unit>, PhotographerCommandHandler>();

            // Infra Data
            //services.AddScoped<IPhotographerRepository, FakePhotographerRepository>();

            services.AddScoped<MongoDatabase>();
            services.AddScoped<IPhotographerRepository, PhotographerRepository>();
        }
    }
}