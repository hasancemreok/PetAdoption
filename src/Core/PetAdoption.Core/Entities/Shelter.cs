using PetAdoption.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PetAdoption.Core.Entities
{
    public class Shelter : BaseEntity
    {
        public string Phone { get; set; }
        public string Manager { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public virtual ICollection<Animal> Animals { get; set; }
    }
}
