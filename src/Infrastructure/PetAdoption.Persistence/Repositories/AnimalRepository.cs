using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PetAdoption.Application.Interfaces.Repository;
using PetAdoption.Core.Entities;
using PetAdoption.Persistence.Context;

namespace PetAdoption.Persistence.Repositories
{
    public class AnimalRepository : GenericRepository<Animal>, IAnimalRepository
    {
        public AnimalRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        public async Task<Shelter> GetShelter(Guid animalId)
        {
            Animal animal = 
                await dbContext.Animals
                    .Include(i => i.Shelter)
                    .FirstOrDefaultAsync(m => m.Id == animalId);

            return animal.Shelter;
        }

        public async Task<IEnumerable<Tutor>> GetTutotrs(Guid animalId)
        {
            Animal animal =
                await dbContext.Animals
                .Include(i => i.Tutors)
                .FirstOrDefaultAsync(m => m.Id == animalId);

            return animal.Tutors;
        }
    }
}
