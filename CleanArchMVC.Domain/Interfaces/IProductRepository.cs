using CleanArchMVC.BuildingBlocks.Core.Data;
using CleanArchMVC.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace CleanArchMVC.Domain.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> GerProductCategoryAsync(Guid id);
    }
}
