using CleanArchMVC.Application.Commands;
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
    public class CategoryCommandHandler : IRequestHandler<CreateCategoryCommand, bool>,
                                          IRequestHandler<UpdateCategoryCommand, bool>,
                                          IRequestHandler<DisableCategoryCommand, bool>,
                                          IRequestHandler<ActiveCategoryCommand, bool>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<bool> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryExist = await _categoryRepository.GetCategoryByName(request.Name);

            if (categoryExist is not null)
                throw new ArgumentException("Categoria já existe com o nome informado");


            var newCategory = new Category(request.Name);

            await _categoryRepository.AddAsync(newCategory);

            await _categoryRepository.UnitOfWork.Commit();

            return true;
        }

        public async Task<bool> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id);

            if (category is null)
                throw new ArgumentException("Categoria com id informada não encontrada");

            var categoryNameExist = await _categoryRepository.GetCategoryByName(request.Name);
            if (categoryNameExist is not null && categoryNameExist.ID != request.Id)
                throw new ArgumentException($"Categoria com o nome {request.Name} já existe.");

            category.Alterar(request.Name);


            _categoryRepository.Update(category);

            await _categoryRepository.UnitOfWork.Commit();

            return true;

        }

        public async Task<bool> Handle(DisableCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id);

            if (category is null)
                throw new ArgumentException("Categoria com id informada não encontrada");

            if (category.Products.Any())
                throw new ArgumentException($"Não é possivel desativar a categoria com produtos vinculados. Produtos: {string.Join(", ", category.Products.Select(p => p.Name))}");

            category.Desativar();
            _categoryRepository.Update(category);

            await _categoryRepository.UnitOfWork.Commit();

            return true;
        }

        public async Task<bool> Handle(ActiveCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id);

            if (category is null)
                throw new ArgumentException("Categoria com id informada não encontrada");

            if (category.Products.Any())
                throw new ArgumentException($"Não é possivel ativar a categoria com produtos vinculados. Produtos: {string.Join(", ", category.Products.Select(p => p.Name))}");

            category.Ativar();
            _categoryRepository.Update(category);

            await _categoryRepository.UnitOfWork.Commit();

            return true;
        }
    }
}
