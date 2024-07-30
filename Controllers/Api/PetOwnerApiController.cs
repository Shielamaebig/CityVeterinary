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
    public class PetOwnerApiController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ApplicationDataContext _db;
        private readonly IMapper _mapper;
        public IWebHostEnvironment env { get;}
        public IConfiguration Config {get;}

        public PetOwnerApiController(ApplicationDataContext db, IMapper mapper, IWebHostEnvironment webHostEnvironment, IWebHostEnvironment _env, IConfiguration _Config)
        {
            this._db = db;
            this._mapper = mapper;
            this._webHostEnvironment = webHostEnvironment;
            this.env = _env;
            this.Config = _Config;
        }

        [HttpPost]
        [Route("PostPetOwner")] 
        public async Task<ActionResult> PostPetOwner(
            [FromForm] string firstName,
            [FromForm] string middleName,
            [FromForm] string lastName,
            [FromForm] string contactNumber,
            [FromForm] int baranggayId,
            [FromForm] IFormFile? imagePath)
        {
            
            var newOwner = new Models.PetOwner() {
                DateAdded = DateTime.Now.ToString("MMMM dd yyyy hh:mm tt"),
                FirstName = firstName,
                MiddleName = middleName,
                LastName = lastName,
                ContactNumber = contactNumber,
                BaranggayId = baranggayId,
                BaranggayName =  _db.Baranggays.SingleOrDefault(x=>x.Id == baranggayId)?.BaranggayName

                
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

                    newOwner.ImagePath = "/" + subPath + "/" + fileName;
                    newOwner.FileExtension = Path.GetExtension(fileName);
                    
                    
                   
                }
                
                catch (Exception ex)
                {
                    errors.Add(ex.Message);
                    var inner = ex.InnerException?.Message ?? "";
                    if (!string.IsNullOrEmpty(inner))
                        errors.Add(inner);
                }
            }
            _db.PetOwners.Add(newOwner);
            await _db.SaveChangesAsync();
            return Ok("200");
        }
    
    
        [HttpGet]
        [Route("getPetOwners")]
        public async Task<ActionResult<List<PetOwner>>> GetPetOwners()
        {
            var petsOwn = await _db.PetOwners.Include(x=>x.Baranggay).ToListAsync(); 
            return Ok(petsOwn.OrderBy(x=>x.LastName));
        }
        
        [HttpGet]
        [Route("getPetOwnersbyId/{id}")]
        public async Task<ActionResult> GetOwnerbyId(int id)
        {
            var ownerbyId = await _db.PetOwners.FirstOrDefaultAsync(x => x.Id == id);
            if (ownerbyId == null)
            {
                return NotFound();
            }
            return Ok(ownerbyId);           
        }
        [HttpPut]
        [Route("putPetOwners/{id}")]
        public async Task<ActionResult> PutPetOwners(
            [FromForm] string firstName,
            [FromForm] string? middleName,
            [FromForm] string lastName,
            [FromForm] string contactNumber,
            [FromForm] int baranggayId,
            [FromForm] IFormFile? imagePath,
            int id
        )
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var petO = await _db.PetOwners.SingleOrDefaultAsync(x=>x.Id == id);

            if (petO == null)
            {
                return NotFound();
            }
            petO.FirstName = firstName;
            petO.MiddleName = middleName;
            petO.LastName = lastName;
            petO.ContactNumber = contactNumber;
            petO.BaranggayId = baranggayId;
            petO.BaranggayName =  _db.Baranggays.SingleOrDefault(x=>x.Id == baranggayId)?.BaranggayName;

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

                    petO.ImagePath = "/" + subPath + "/" + fileName;
                    petO.FileExtension = Path.GetExtension(fileName);
                   
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
        [Route("deletedata/{id}")]
        public async Task<ActionResult> DeleteBgy(int id)
        {
            var deleteOwner = await _db.PetOwners.SingleOrDefaultAsync(x => x.Id == id);
            if (deleteOwner == null)
            {
                return NotFound();
            }
            _db.PetOwners.Remove(deleteOwner);
            await _db.SaveChangesAsync();
            return Ok("200");
        }

        [HttpPost]
        [Route("postPetInfoAdd")]
        public async Task<ActionResult> PostPetInfoAdd([FromBody] PetInfoDto petInfoDto)
        {
            
            var petInfos = _mapper.Map<PetInfoDto, PetOwner>(petInfoDto);
                
                petInfos.Id = petInfoDto.Id;
                petInfos.DateAdded = DateTime.Now.ToString("MMMM dd yyyy hh:mm tt");
                petInfos.AddedBy = petInfoDto.AddedBy;
                petInfos.FirstName = petInfoDto.FirstName;
                petInfos.MiddleName = petInfoDto.MiddleName;
                petInfos.LastName = petInfoDto.LastName;
                petInfos.ContactNumber = petInfoDto.ContactNumber;
                petInfos.BaranggayId = petInfoDto.BaranggayId;
             
            _db.PetInformations.Add(new PetInformation()
            {
               PetOwnerId = petInfoDto.Id,
               PetTypeId = petInfoDto.PetTypeId,
               BreedTypeId = petInfoDto.BreedTypeId,
               BreedTypeName = _db.BreedTypes.SingleOrDefault(x => x.Id == petInfoDto.BreedTypeId)?.BreedName,
               PetName = petInfoDto.PetName,
               Markings = petInfoDto.Markings,
               Species = petInfoDto.Species,
               Gender = petInfoDto.Gender,
               DateOfBirth = petInfoDto.DateOfBirth,
            });

             _db.PetOwners.Add(petInfos);
            await _db.SaveChangesAsync();
            return Ok("200");
        }

        [HttpGet]
        [Route("getByOwnerId/{id}")]
        public async Task<ActionResult> OwnerAndPetbyId(int id)
        {
            var OP = await _db.PetInformations.Include(x=>x.PetOwner).Include(x=>x.PetType).Include(x=>x.BreedType).FirstOrDefaultAsync(x=>x.Id == id);
            if(OP == null)
            {
                return NotFound();
            }
            return Ok(OP);
        }


        [HttpGet]
        [Route("getByVax/{id}")]
        public async Task<ActionResult> OwnerPetVax(int id)
        {
            var vax = await _db.Vaccines.FirstOrDefaultAsync(x=>x.Id == id);
            if(vax == null)
            {
                return NotFound();
            }
            return Ok(vax);
        }
        
    }
    
}