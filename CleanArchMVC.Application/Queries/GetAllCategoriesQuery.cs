using CleanArchMVC.Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace CleanArchMVC.Application.Queries
{
    public class GetAllCategoriesQuery : IRequest<IEnumerable<Category>>
    {
    }
}
