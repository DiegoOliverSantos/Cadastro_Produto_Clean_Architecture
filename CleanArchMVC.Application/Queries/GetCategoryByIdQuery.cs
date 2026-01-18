using CleanArchMVC.Domain.Entities;
using MediatR;
using System;

namespace CleanArchMVC.Application.Queries
{
    public class GetCategoryByIdQuery : IRequest<Category>
    {
        public Guid Id { get; private set; }

        public GetCategoryByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
