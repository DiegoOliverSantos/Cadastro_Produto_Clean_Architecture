using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
