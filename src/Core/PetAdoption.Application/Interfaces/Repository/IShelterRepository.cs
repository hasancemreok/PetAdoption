using PetAdoption.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetAdoption.Application.Interfaces.Repository
{
    public interface IShelterRepository : IGenericRepository<Shelter>
    {
        Task<IEnumerable<Animal>> GetAnimals(Guid shelterId);
    }
}
