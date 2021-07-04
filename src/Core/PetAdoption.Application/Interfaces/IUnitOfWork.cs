using PetAdoption.Application.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetAdoption.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IShelterRepository Shelters { get; }
        IAnimalRepository Animals { get; }
        ITutorRepository Tutors { get; }
        Task<int> CommitAsync();
    }
}
