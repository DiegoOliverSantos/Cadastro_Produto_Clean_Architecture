using CleanArchMVC.Application;
using CleanArchMVC.Application.Commands;
using CleanArchMVC.Application.Handlers;
using CleanArchMVC.Application.Interfaces;
using CleanArchMVC.Application.Mappings;
using CleanArchMVC.Application.Services;
using CleanArchMVC.Domain.Interfaces;
using CleanArchMVC.Infra.Data.Context;
using CleanArchMVC.Infra.Data.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CleanArchMVC.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraStructure( this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CatalogoContext>(op =>
                op.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(CatalogoContext).Assembly.FullName)));


            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();

            services.AddAutoMapper(typeof(DomainToDTOMappProfile));
            services.AddAutoMapper(typeof(DTOToCommandMappingProfile));

            
            services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(CleanArchMVCApplicationAssembly).Assembly));

            //services.AddScoped<IRequestHandler<CreateCategoryCommand, bool>, CategoryCommandHandler>();
            //services.AddScoped<IRequestHandler<RemoveCategoryCommand, bool>, CategoryCommandHandler>();
            //services.AddScoped<IRequestHandler<UpdateCategoryCommand, bool>, CategoryCommandHandler>();

            return services;
        }
    }
}
