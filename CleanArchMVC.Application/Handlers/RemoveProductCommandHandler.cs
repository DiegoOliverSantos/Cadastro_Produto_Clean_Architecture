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
    public class RemoveProductCommandHandler : IRequestHandler<RemoveProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;

        public RemoveProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> Handle(RemoveProductCommand command, CancellationToken cancellationToken)
        {
            Product product = await _productRepository.GetByIdAsync(command.Id);


            if (product is null)
                throw new ArgumentException("Produto não localizado");

            _productRepository.Remove(product);

            await _productRepository.UnitOfWork.Commit();

            return true;
        }
    }
}
