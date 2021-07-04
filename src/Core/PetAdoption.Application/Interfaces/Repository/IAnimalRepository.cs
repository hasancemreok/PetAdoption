using PetAdoption.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetAdoption.Application.Interfaces.Repository
{
    public interface IAnimalRepository : IGenericRepository<Animal>
    {
        Task<Shelter> GetShelter(Guid animalId);

        Task<IEnumerable<Tutor>> GetTutotrs(Guid animalId);
    }
}
