using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetAdoption.Application.Interfaces;
using PetAdoption.Core.Entities;
using PetAdoption.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetAdoption.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        public AnimalController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Animal>>> GetAll()
        {
            var animals = await unitOfWork.Animals.GetAllAsync();
            return Ok(animals);
        }

        [HttpGet]
        [Route("{animalId}")]
        public async Task<ActionResult<Animal>> GetById(Guid animalId)
        {
            var animal = await unitOfWork.Animals.GetByIdAsync(animalId);
            return Ok(animal);
        }

        [HttpGet]
        [Route("{animalId}/shelter")]
        public async Task<ActionResult<Shelter>> GetAnimalShelter(Guid animalId)
        {
            var shelter = await unitOfWork.Animals.GetShelter(animalId);
            return Ok(shelter);
        }

        [HttpGet]
        [Route("{animalId}/tutors")]
        public async Task<ActionResult<IEnumerable<Tutor>>> GetTutors(Guid animalId)
        {
            var tutors = await unitOfWork.Animals.GetTutotrs(animalId);
            return Ok(tutors);
        }

        [HttpPost]
        public async Task<ActionResult<Animal>> CreteAnimal(Animal animal)
        {
            var newAnimal = await unitOfWork.Animals.CreateAsync(animal);
            await unitOfWork.CommitAsync();
            return Ok(newAnimal);
        }

        [HttpPut]
        [Route("{animalId}")]
        public async Task<ActionResult<Animal>> UpdateAnimal(Guid animalId, Animal animal)
        {
            var updatedAnimal = await unitOfWork.Animals.UpdateAsync(animalId, animal);
            await unitOfWork.CommitAsync();
            return Ok(updatedAnimal);
        }

        [HttpDelete]
        [Route("{animalId}")]
        public async Task<ActionResult<Animal>> DeleteAnimal(Guid animalId)
        {
            await unitOfWork.Animals.DeleteAsync(animalId);
            await unitOfWork.CommitAsync();
            return Ok();
        }
    }
}
