using AutoMapper;
using CleanArchMVC.Application.Commands;
using CleanArchMVC.Application.DTOs;
using CleanArchMVC.Application.Interfaces;
using CleanArchMVC.Application.Queries;
using CleanArchMVC.Domain.Entities;
using CleanArchMVC.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMVC.Application.Services
{
    public class CategoryService : ICategoryService
    {

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task Add(CategoryDTO categoryDTO)
        {
            var categoryCommand = _mapper.Map<CreateCategoryCommand>(categoryDTO);
            await _mediator.Send(categoryCommand);
        }

        public async Task Disable(Guid id)
        {
            await _mediator.Send(new DisableCategoryCommand(id));
        }

        public async Task Active(Guid id)
        {
            await _mediator.Send(new ActiveCategoryCommand(id));
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            var categories = await _mediator.Send(new GetAllCategoriesQuery());

            return _mapper.Map<IEnumerable<CategoryDTO>>(categories);
        }

        public async Task<CategoryDTO> GetCategoryById(Guid id)
        {
            var category =await _mediator.Send(new GetCategoryByIdQuery(id));

            return _mapper.Map<CategoryDTO>(category);
        }

        public async Task Update(CategoryDTO categoryDTO)
        {
            var categoryCommand = _mapper.Map<UpdateCategoryCommand>(categoryDTO);

            await _mediator.Send(categoryCommand);
        }
    }
}
