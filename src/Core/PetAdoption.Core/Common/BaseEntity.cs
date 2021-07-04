using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PetAdoption.Core.Common
{
    public class BaseEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
