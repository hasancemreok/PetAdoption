using PetAdoption.Core.Common;
using PetAdoption.Core.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PetAdoption.Core.Entities
{
    public class Animal : BaseEntity
    {
        public AnimalType Type { get; set; }
        public AnimalStatus Status { get; set; }
        public string Description { get; set; }
        public Guid ShelterId { get; set; }
        public Shelter Shelter { get; set; }
        public virtual ICollection<Tutor> Tutors { get; set; }
    }
}
