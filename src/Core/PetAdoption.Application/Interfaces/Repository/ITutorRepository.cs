using PetAdoption.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetAdoption.Application.Interfaces.Repository
{
    public interface ITutorRepository : IGenericRepository<Tutor>
    {
        Task<IEnumerable<Animal>> GetAnimals(Guid tutorId);
        Task SetInterest(Guid tutorId, Animal animal);
        Task RemoveInterest(Guid tutorId, Animal animal);
    }
}
