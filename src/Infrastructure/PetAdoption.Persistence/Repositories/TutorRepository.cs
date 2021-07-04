using PetAdoption.Application.Interfaces.Repository;
using PetAdoption.Core.Entities;
using PetAdoption.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetAdoption.Persistence.Repositories
{
    public class TutorRepository : GenericRepository<Tutor>, ITutorRepository
    {
        public TutorRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        public async Task<IEnumerable<Animal>> GetAnimals(Guid tutorId)
        {
            var tutor = await dbContext.Tutors.FindAsync(tutorId);
            return tutor.Animals;
        }

        public async Task RemoveInterest(Guid tutorId, Animal animal)
        {
            var tutor = await dbContext.Tutors.FindAsync(tutorId);
            tutor.Animals.Remove(animal);
        }

        public async Task SetInterest(Guid tutorId, Animal animal)
        {
            var tutor = await dbContext.Tutors.FindAsync(tutorId);
            tutor.Animals.Add(animal);
        }
    }
}
