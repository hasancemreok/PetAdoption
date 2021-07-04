using PetAdoption.Application.Interfaces;
using PetAdoption.Application.Interfaces.Repository;
using PetAdoption.Persistence.Context;
using PetAdoption.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetAdoption.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private ShelterRepository _shelterRepository;
        private AnimalRepository _animalRepository;
        private TutorRepository _tutorRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            this._context = context;
        }

        public IShelterRepository Shelters => _shelterRepository = _shelterRepository ?? new ShelterRepository(_context);
        public IAnimalRepository Animals => _animalRepository = _animalRepository ?? new AnimalRepository(_context);
        public ITutorRepository Tutors => _tutorRepository = _tutorRepository ?? new TutorRepository(_context);
        
        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
