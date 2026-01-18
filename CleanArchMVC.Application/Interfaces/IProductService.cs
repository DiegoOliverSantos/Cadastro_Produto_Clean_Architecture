using CleanArchMVC.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMVC.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetAll();

        Task<ProductDTO> GetById(Guid id);
        //Task<ProductDTO> GetProductCategory(Guid id);

        Task Add(ProductDTO productDTO);

        Task Update(ProductDTO productDTO);

        Task Delete(Guid id);
    }
}
