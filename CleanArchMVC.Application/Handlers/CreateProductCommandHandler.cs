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
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public CreateProductCommandHandler(IProductRepository productRepository, 
                                      ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<bool> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            Category category = null;

            category = await _categoryRepository.GetByIdAsync(command.CategoryId);

            if (category is null)
                throw new ArgumentException("categoria não encontrada.");

            var product = new Product(command.Name,
                                      command.Description,
                                      command.Price,
                                      command.Stock,
                                      command.Image,
                                      category);


            await _productRepository.AddAsync(product);

            await _productRepository.UnitOfWork.Commit();

            return true;
        }
    }
}
