using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CityVeterinary.DataContext;
using CityVeterinary.Dto;
using CityVeterinary.Models;
using Microsoft.AspNetCore.Hosting;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Data;
using System.Net;


namespace CityVeterinary.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetInfoApiController : ControllerBase
    {
              private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ApplicationDataContext _db;
        private readonly IMapper _mapper;
        public IWebHostEnvironment env { get;}
        public IConfiguration Config {get;}
        public PetInfoApiController(ApplicationDataContext db, IMapper mapper, IWebHostEnvironment webHostEnvironment, IWebHostEnvironment _env, IConfiguration _Config)
        {
            this._db = db;
            this._mapper = mapper;
            this._webHostEnvironment = webHostEnvironment;
            this.env = _env;
            this.Config = _Config;
        }

        [HttpPost]
        [Route("postPetInfo")]
        public async Task<ActionResult> PostPetInfo(
            [FromForm] int petTypeId,
            [FromForm] int breedTypeId,
            [FromForm] int petOwnerId,
            [FromForm] string petName,
            [FromForm] string markings,
            [FromForm] string species,
            [FromForm] string gender,
            [FromForm] string dateOfBirth,
            [FromForm] string tagNumber,
            [FromForm] string orNumber,
            [FromForm] IFormFile? imagePath
        )
        {
            var petInfo = new Models.PetInformation() {
                DateAdded = DateTime.Now.ToString("MMMM dd yyyy hh:mm tt"),
                PetOwnerId = petOwnerId,
                PetTypeId = petTypeId,
                BreedTypeId = breedTypeId,
                PetName = petName,
                Markings = markings,
                Species = species,
                Gender = gender,
                DateOfBirth = dateOfBirth,
                TagNumber = tagNumber,
                DateRegister = DateTime.Now.ToString("MMMM dd yyyy hh:mm tt"),
                OrNumber = orNumber,
                PetTypeName =  _db.PetTypes.SingleOrDefault(x=>x.Id == petTypeId)?.PetTypeName,
                PetOwnerName = _db.PetOwners.SingleOrDefault(x=>x.Id == petOwnerId)?.FirstName + _db.PetOwners.SingleOrDefault(x=>x.Id == petOwnerId)?.MiddleName + _db.PetOwners.SingleOrDefault(x=>x.Id == petOwnerId)?.LastName,
                BreedTypeName =  _db.BreedTypes.SingleOrDefault(x=>x.Id == breedTypeId)?.BreedName
            };

              var errors = new List<string>();
                  //upload image here
            if (imagePath != null && imagePath.Length > 0 && UploadImage.IsImage(imagePath) == true)
            {
                 var codeNumber = Guid.NewGuid().ToString();
                var fileName =  codeNumber + Path.GetExtension(imagePath.FileName);
                try
                {
                    string subPath = "PetOwnersImages";
                    string webRootPath = _webHostEnvironment.WebRootPath;
                    string contentRootPath = _webHostEnvironment.ContentRootPath;

                    var pathOnly = Path.Combine(webRootPath, subPath);

                    bool exists = Directory.Exists(pathOnly);

                    if (!exists)
                        Directory.CreateDirectory(pathOnly);

                    var filePath = Path.Combine(pathOnly, fileName);
                    using (var stream = System.IO.File.Create(filePath))
                    {
                        await imagePath.CopyToAsync(stream);
                    }

                    petInfo.ImagePath = "/" + subPath + "/" + fileName;
                    petInfo.FileExtension = Path.GetExtension(fileName);
                    
                    
                   
                }
                
                catch (Exception ex)
                {
                    errors.Add(ex.Message);
                    var inner = ex.InnerException?.Message ?? "";
                    if (!string.IsNullOrEmpty(inner))
                        errors.Add(inner);
                }
            }

             _db.PetInformations.Add(petInfo);
            await _db.SaveChangesAsync();
            return Ok("200");
        }

        [HttpGet]
        [Route("getPetInfo")]
        public async Task<ActionResult<List<PetInformation>>> GetPetInfos()
        {
            var petInfo = await _db.PetInformations.Include(x=>x.PetOwner).Include(x=>x.PetType).Include(x=>x.BreedType).ToListAsync();
            return Ok(petInfo.OrderByDescending(x=>x.Id));
        }
        
                
        [HttpGet]
        [Route("getPetInfobyId/{id}")]
        public async Task<ActionResult> GetOwnerbyId(int id)
        {
            var petById = await _db.PetInformations.Include(x=>x.PetOwner).FirstOrDefaultAsync(x => x.Id == id);
            if (petById == null)
            {
                return NotFound();
            }
            return Ok(petById);           
        }

        [HttpPut]
        [Route("PutPetInfo/{id}")]
        public async Task<ActionResult> PutPetInformation(
            int id,
            [FromForm] int petTypeId,
            [FromForm] int breedTypeId,
            [FromForm] int petOwnerId,
            [FromForm] string petName,
            [FromForm] string markings,
            [FromForm] string species,
            [FromForm] string gender,
            [FromForm] string dateOfBirth,
            [FromForm] string tagNumber,
            [FromForm] string orNumber,
            [FromForm] IFormFile? imagePath
        )
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var petInfos = await _db.PetInformations.SingleOrDefaultAsync(x=>x.Id == id);

            if (petInfos == null)
            {
                return NotFound();
            }
            petInfos.DateAdded = DateTime.Now.ToString("MMMM dd yyyy hh:mm tt");
            petInfos.PetOwnerId = petOwnerId;
            petInfos.PetTypeId = petTypeId;
            petInfos.BreedTypeId = breedTypeId;
            petInfos.PetName = petName;
            petInfos.Markings = markings;
            petInfos.Species = species;
            petInfos.Gender = gender;
            petInfos.DateOfBirth = dateOfBirth;
            petInfos.TagNumber = tagNumber;
            petInfos.DateRegister = DateTime.Now.ToString("MMMM dd yyyy hh:mm tt");
            petInfos.OrNumber = orNumber;
            petInfos.PetTypeName =  _db.PetTypes.SingleOrDefault(x=>x.Id == petTypeId)?.PetTypeName;
            petInfos.PetOwnerName = _db.PetOwners.SingleOrDefault(x=>x.Id == petOwnerId)?.FirstName + _db.PetOwners.SingleOrDefault(x=>x.Id == petOwnerId)?.MiddleName + _db.PetOwners.SingleOrDefault(x=>x.Id == petOwnerId)?.LastName;
            petInfos.BreedTypeName =  _db.BreedTypes.SingleOrDefault(x=>x.Id == breedTypeId)?.BreedName;

              var errors = new List<string>();
                  //upload image here
            if (imagePath != null && imagePath.Length > 0 && UploadImage.IsImage(imagePath) == true)
            {
                 var codeNumber = Guid.NewGuid().ToString();
                var fileName =  codeNumber + Path.GetExtension(imagePath.FileName);
                try
                {
                    string subPath = "PetOwnersImages";
                    string webRootPath = _webHostEnvironment.WebRootPath;
                    string contentRootPath = _webHostEnvironment.ContentRootPath;

                    var pathOnly = Path.Combine(webRootPath, subPath);

                    bool exists = Directory.Exists(pathOnly);

                    if (!exists)
                        Directory.CreateDirectory(pathOnly);

                    var filePath = Path.Combine(pathOnly, fileName);
                    using (var stream = System.IO.File.Create(filePath))
                    {
                        await imagePath.CopyToAsync(stream);
                    }

                    petInfos.ImagePath = "/" + subPath + "/" + fileName;
                    petInfos.FileExtension = Path.GetExtension(fileName);
                    
                    
                   
                }
                
                catch (Exception ex)
                {
                    errors.Add(ex.Message);
                    var inner = ex.InnerException?.Message ?? "";
                    if (!string.IsNullOrEmpty(inner))
                        errors.Add(inner);
                }
            }

               await _db.SaveChangesAsync();
            return Ok("200");

        }
                     [HttpDelete]
        [Route("deleteData/{id}")]
        public async Task<ActionResult> DeleteBgy(int id)
        {
            var removePet = await _db.PetInformations.SingleOrDefaultAsync(x => x.Id == id);
            if (removePet == null)
            {
                return NotFound();
            }
            _db.PetInformations.Remove(removePet);
            await _db.SaveChangesAsync();
            return Ok("200");
        }

    
    }
}