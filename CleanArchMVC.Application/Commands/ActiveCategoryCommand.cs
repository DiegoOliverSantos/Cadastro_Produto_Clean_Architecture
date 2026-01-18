using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMVC.Application.Commands
{
    public class ActiveCategoryCommand : Command
    {
        public Guid Id { get; set; }

        public ActiveCategoryCommand(Guid id)
        {
            Id = id;
        }
    }
}
