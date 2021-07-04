using Microsoft.EntityFrameworkCore;
using PetAdoption.Application.Interfaces.Repository;
using PetAdoption.Core.Entities;
using PetAdoption.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetAdoption.Persistence.Repositories
{
    public class ShelterRepository : GenericRepository<Shelter>, IShelterRepository
    {
        public ShelterRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        public async Task<IEnumerable<Animal>> GetAnimals(Guid shelterId)
        {
            var shelter = 
                await dbContext.Shelters
                .Include(m => m.Animals)
                .FirstOrDefaultAsync(m => m.Id == shelterId);

            return shelter.Animals;
        }
    }
}
