using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMVC.BuildingBlocks.Core.DomainObjects
{
    public abstract class Entity
    {
        public Guid ID { get;protected set; }

        public Entity()
        {
            ID = Guid.NewGuid();
        }
    }
}
