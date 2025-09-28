using AutoMapper;
using CleanArchMVC.Application.DTOs;
using CleanArchMVC.Application.Interfaces;
using CleanArchMVC.Domain.Entities;
using CleanArchMVC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMVC.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, 
                              IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task Add(ProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);

            await _productRepository.AddAsync(product);
        }

        public async Task Delete(Guid id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            _productRepository.Remove(product);
        }

        public async Task<IEnumerable<ProductDTO>> GetAll()
        {
            var products = await _productRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public async Task<ProductDTO> GetById(Guid id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<ProductDTO> GetProductCategory(Guid id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            return _mapper.Map<ProductDTO>(product);
        }

        public void Update(ProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);

            _productRepository.Update(product);
        }
    }
}
