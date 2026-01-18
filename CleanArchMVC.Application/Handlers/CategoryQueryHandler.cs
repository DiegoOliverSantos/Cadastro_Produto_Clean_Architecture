using CleanArchMVC.Application.Queries;
using CleanArchMVC.Domain.Entities;
using CleanArchMVC.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchMVC.Application.Handlers
{
    public class CategoryQueryHandler : IRequestHandler<GetAllCategoriesQuery, IEnumerable<Category>>,
                                        IRequestHandler<GetCategoryByIdQuery, Category>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<Category>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetAllAsync();

            if (categories is null)
                throw new ArgumentNullException("Nenhuma categoria encontrada");

            return categories;
        }

        public async Task<Category> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id);

            if (category is null)
                throw new ArgumentNullException("Nenhuma categoria encontrada");

            return category;
        }
    }
}
