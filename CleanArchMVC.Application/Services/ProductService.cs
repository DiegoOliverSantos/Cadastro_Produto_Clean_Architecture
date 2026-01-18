using AutoMapper;
using CleanArchMVC.Application.Commands;
using CleanArchMVC.Application.DTOs;
using CleanArchMVC.Application.Interfaces;
using CleanArchMVC.Application.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMVC.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ProductService(IMapper mapper,
                              IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task Add(ProductDTO productDTO)
        {
            var productCreateCommand = _mapper.Map<CreateProductCommand>(productDTO);

            await _mediator.Send(productCreateCommand);
        }

        public async Task Delete(Guid id)
        {
            await  _mediator.Send(new RemoveProductCommand(id));
        }

        public async Task<IEnumerable<ProductDTO>> GetAll()
        {
            var result = await _mediator.Send(new GetAllProductsQuery());

            return _mapper.Map<IEnumerable<ProductDTO>>(result);


        }

        public async Task<ProductDTO> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetProductByIdQuery(id));

            return _mapper.Map<ProductDTO>(result);
        }

        //public async Task<ProductDTO> GetProductCategory(Guid id)
        //{
        //    var result = await _mediator.Send(new GetProductByIdQuery(id));
        //    return _mapper.Map<ProductDTO>(result);
        //}

        public async Task Update(ProductDTO productDTO)
        {
            var productUpdateCommand = _mapper.Map<UpdateProductCommand>(productDTO);

            await _mediator.Send(productUpdateCommand);
        }
    }
}
