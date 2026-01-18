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
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IProductRepository _productRepository ;
        private readonly ICategoryRepository _categoryRepository ;

        public UpdateProductCommandHandler(IProductRepository productRepository,
                                           ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<bool> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            Product product = await _productRepository.GetByIdAsync(command.Id);
            Category category = await _categoryRepository.GetByIdAsync(command.CategoryId);

            if (category is null)
                throw new ArgumentException("categoria não encontrada.");

            if (product is null)
                throw new ArgumentException("Produto não localizado");

            product.Alterar(command.Name,
                            command.Description,
                            command.Price,
                            command.Stock,
                            command.Image,
                            category);

            _productRepository.Update(product);

            await _productRepository.UnitOfWork.Commit();

            return true;
        }
    }
}
