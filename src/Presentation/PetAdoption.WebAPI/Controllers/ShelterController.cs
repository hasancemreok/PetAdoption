using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetAdoption.Application.Interfaces;
using PetAdoption.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetAdoption.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShelterController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        public ShelterController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shelter>>> GetAll()
        {
            var shelters = await unitOfWork.Shelters.GetAllAsync();
            return Ok(shelters);
        }

        [HttpGet]
        [Route("{shelterId}")]
        public async Task<ActionResult<Shelter>> GetById(Guid shelterId)
        {
            var shelters = await unitOfWork.Shelters.GetByIdAsync(shelterId);
            return Ok(shelters);
        }

        [HttpGet]
        [Route("{shelterId}/animals")]
        public async Task<ActionResult<IEnumerable<Animal>>> GetAnimals(Guid shelterId)
        {
            var shelterAnimals = await unitOfWork.Shelters.GetAnimals(shelterId);
            return Ok(shelterAnimals);
        }
    }
}
