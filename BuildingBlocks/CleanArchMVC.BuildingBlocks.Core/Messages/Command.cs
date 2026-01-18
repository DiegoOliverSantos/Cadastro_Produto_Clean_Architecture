using MediatR;
using System;

namespace CleanArchMVC.Application.Commands
{
    public abstract class  Command : IRequest<bool>
    {
        public DateTime TimeSpan { get; set; }

        protected Command()
        {
            TimeSpan = DateTime.Now;
        }
    }
}
