using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CityVeterinary.DataContext;
using CityVeterinary.Dto;
using CityVeterinary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CityVeterinary.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetTypeApiController : ControllerBase
    {
        private readonly ApplicationDataContext _db;
        private readonly IMapper _mapper;

        public PetTypeApiController(ApplicationDataContext db, IMapper mapper)
        {
            this._db = db;
            this._mapper = mapper;
        }

        [HttpPost]
        [Route("postPetType")]
        public async Task<ActionResult> PostPetType([FromBody] PetTypeDto petTypeDto)
        {
            var pet = _mapper.Map<PetTypeDto, PetType>(petTypeDto);

            if (_db.PetTypes.Any(x => x.PetTypeName == pet.PetTypeName || x.PetTypeName == null))
            {
                return BadRequest("Pet Type Already Exist");
            }

            pet.Id = petTypeDto.Id;
            pet.DateAdded = DateTime.Now.ToString("MMMM dd yyyy hh:mm tt");
            pet.PetTypeName = petTypeDto.PetTypeName;
            _db.PetTypes.Add(pet);
            await _db.SaveChangesAsync();
            return Ok("200");
        }

        [HttpGet]
        [Route("getPetTypes")]
        public async Task<ActionResult<List<PetType>>> GetpetTypes()
        {
            var petsTypes = await _db.PetTypes.ToListAsync();
            return Ok(petsTypes.OrderBy(x => x.PetTypeName));
        }

        [HttpGet]
        [Route("getPetbyId/{id}")]
        public async Task<ActionResult> GetbyId(int id)
        {
            var typesId = await _db.PetTypes.FirstOrDefaultAsync(x => x.Id == id);
            if (typesId == null)
            {
                return NotFound();
            }
            return Ok(typesId);
        }

        [HttpPut]
        [Route("putTypes/{id}")]
        public async Task<ActionResult> PutTypes([FromBody] PetTypeDto petTypeDto, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var type = await _db.PetTypes.SingleOrDefaultAsync(x => x.Id == id);

            if (type == null)
            {
                return NotFound();
            }
            _mapper.Map(petTypeDto, type);
            petTypeDto.PetTypeName = type.PetTypeName;
            type.DateAdded = DateTime.Now.ToString("MMMM dd yyyy hh:mm tt");
            await _db.SaveChangesAsync();
            return Ok("200");
        }

        [HttpDelete]
        [Route("deleteType/{id}")]
        public async Task<ActionResult> DeleteType(int id)
        {
            var deletePet = await _db.PetTypes.SingleOrDefaultAsync(x => x.Id == id);
            if (deletePet == null)
            {
                return NotFound();
            }
            _db.PetTypes.Remove(deletePet);
            await _db.SaveChangesAsync();
            return Ok("200");
        }




    }

}