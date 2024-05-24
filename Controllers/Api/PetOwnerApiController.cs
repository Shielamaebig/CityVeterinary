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
    }
    
}