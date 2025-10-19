using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMVC.Application.Commands
{
    public class RemoveProductCommand : Command
    {
        public Guid Id { get; set; }

        public RemoveProductCommand(Guid id)
        {
            Id = id;
        }
    }
}
