using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api_Crud_EF.Application.Domain
{
    public abstract class Entity
    {
        public virtual Int32 Id { get; set; }
    }
}
