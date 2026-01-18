using CleanArchMVC.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMVC.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetCategories();
        Task<CategoryDTO> GetCategoryById(Guid id);

        Task Add(CategoryDTO category);

        Task Update(CategoryDTO category);

        Task Disable(Guid id);
        Task Active(Guid id);
    }
}
