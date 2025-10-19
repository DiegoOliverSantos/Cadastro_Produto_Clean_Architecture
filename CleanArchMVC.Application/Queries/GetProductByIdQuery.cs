using CleanArchMVC.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMVC.Application.Queries
{
    public class GetProductByIdQuery :IRequest<Product>
    {
        public Guid Id { get; set; }
    }
}
