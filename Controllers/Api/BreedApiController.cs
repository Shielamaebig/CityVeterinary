using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CityVeterinary.DataContext;
using CityVeterinary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CityVeterinary.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class BreedApiController : ControllerBase
    {
        private readonly ApplicationDataContext _db;
        private readonly IMapper _mapper;


        public BreedApiController(ApplicationDataContext db, IMapper mapper)
        {
            this._db = db;
            this._mapper = mapper;
        }

        [HttpPost]
        [Route("PostBreed")]
        public async Task<ActionResult> PostBreedType(
            string dateAdded,
            int petTypeId,
            string breedName)
        {
            if (_db.BreedTypes.Any(x => x.BreedName == null || x.BreedName == breedName))
            {
                return BadRequest("Breed Name Type Already Exist");
            }

            _db.BreedTypes.Add(new Models.BreedType()
            {
                BreedName = breedName,
                DateAdded = DateTime.Now.ToString("MMMM dd yyyy hh:mm tt"),
                PetTypeId = petTypeId,
                PetTypeName = _db.PetTypes.SingleOrDefault(x=>x.Id == petTypeId)?.PetTypeName
            });

            await _db.SaveChangesAsync();
            return Ok("200");
        }

        [HttpGet]
        [Route("getBreedName")]
        public async Task<ActionResult<List<BreedType>>> GetBreeds()
        {
            var breed = await _db.BreedTypes.Include(x=>x.PetType).ToListAsync();
            return Ok(breed.OrderBy(x => x.BreedName));
        }

        [HttpGet]
        [Route("getBreedId/{id}")]
        public async Task<ActionResult> GetbyBreed(int id)
        {
            var breedId = await _db.BreedTypes.Include(x => x.PetType).FirstOrDefaultAsync(x => x.Id == id);
            if (breedId == null)
            {
                return NotFound();
            }
            return Ok(breedId);
        }
        [HttpPut]
        [Route("putBreed/{id}")]
        public async Task<ActionResult> PutBreedType(
            string? breedName,
            int petTypeId,
            int id
        )

        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var breed = await _db.BreedTypes.SingleOrDefaultAsync(x => x.Id == id);

            if (breed == null)
            {
                return NotFound();
            }

            breed.BreedName = breedName;
            breed.DateAdded = DateTime.Now.ToString("MMMM dd yyyy hh:mm tt");
            breed.PetTypeId = petTypeId;
            breed.PetTypeName = _db.PetTypes.SingleOrDefault(x=>x.Id == petTypeId)?.PetTypeName;


            await _db.SaveChangesAsync();
            return Ok("200");
        }

        [HttpGet]
        [Route("getBreedbyType/{id}")]
        public async Task<ActionResult<List<BreedType>>> GetLabel(int id)
        {
            var bTypes = await _db.BreedTypes
                .Include(x => x.PetType)
                .Where(x => x.PetTypeId == id)
                .ToListAsync();
            return Ok(bTypes);
        }
                
        [HttpDelete]
        [Route("deleteBreed/{id}")]
        public async Task<ActionResult> DeleteType(int id)
        {
            var deletebreed = await _db.BreedTypes.SingleOrDefaultAsync(x => x.Id == id);
            if (deletebreed == null)
            {
                return NotFound();
            }
            _db.BreedTypes.Remove(deletebreed);
            await _db.SaveChangesAsync();
            return Ok("200");
        }
    }
}