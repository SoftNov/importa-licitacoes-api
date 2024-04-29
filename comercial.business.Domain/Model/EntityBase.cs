using comercial.business.Domain.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace comercial.business.Domain.Model
{
    public class EntityBase : IEntityBase
    {
        public long? Id { get; set; }
    }
}
