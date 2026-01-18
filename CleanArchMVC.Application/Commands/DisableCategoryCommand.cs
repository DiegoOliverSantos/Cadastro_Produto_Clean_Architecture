using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMVC.Application.Commands
{
    public class DisableCategoryCommand : Command
    {
        public Guid Id { get; private set; }

        public DisableCategoryCommand(Guid id)
        {
            Id = id;
        }
    }
}
