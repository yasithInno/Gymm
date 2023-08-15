using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using GYMM.Application.CustomServices;
using GYMM.Core.Interfaces;
using GYMM.Errors;
using GYMM.Infrastracture.Data;
using GYMM.Infrastracture.Repositories;
using GYMM.Infrastracture.SeedData;
using System.Linq;

namespace GYMM.Controllers.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<StoreContext, StoreContext>();
            services.AddScoped<StoreContextSeed, StoreContextSeed>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICustomerBasket, BasketRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.Configure<ApiBehaviorOptions>(options =>
              options.InvalidModelStateResponseFactory = ActionContext =>
              {
                  var error = ActionContext.ModelState
                              .Where(e => e.Value.Errors.Count > 0)
                              .SelectMany(e => e.Value.Errors)
                              .Select(e => e.ErrorMessage).ToArray();
                  var errorresponce = new APIValidationErrorResponce
                  {
                      Errors = error
                  };
                  return new BadRequestObjectResult(error);
              }
            );
            return services;
        }
    }
}
