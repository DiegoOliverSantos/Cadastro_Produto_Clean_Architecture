using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMVC.Application.Commands
{
    public class CreateCategoryCommand : Command
    {
        public string Name { get; private set; }

        public CreateCategoryCommand(string name)
        {
            Name = name;
        }
    }
}
