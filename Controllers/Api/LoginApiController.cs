using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using Newtonsoft.Json;


namespace CityVeterinary.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginApiController : ControllerBase
    {
        public IConfiguration Config { get; }
        public IWebHostEnvironment env { get; }

        public LoginApiController(IConfiguration _config, IWebHostEnvironment _env, IWebHostEnvironment webHostEnvironment)
        {
            Config = _config;
            env = _env;
        }

        [HttpPost("login")]
        public IActionResult Login(string username, string password)
        {
            var json = "";


            using (var client = new HttpClient())
            {
                // client.BaseAddress = new Uri("http://172.16.100.9/CGPP-CDS/api/external/");
                client.BaseAddress = new Uri("http://122.53.117.14/CGPP-CDS/api/external/");

                var formContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("username", username),
                    new KeyValuePair<string, string>("password", password),
                    new KeyValuePair<string, string>("systemId", "SYS:B482ADD9-4078-43D5-A9D0-1818FF89D187")
                });

                //HTTP POST
                var responseTask = client.PostAsync("login", formContent);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();//ReadAsAsync<IList<StudentViewModel>>();
                    readTask.Wait();

                    json = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..
                    return BadRequest(result.ToString());
                }

                Dictionary<string, object>? rawData = null;
                try
                {
                    rawData = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
                }
                catch
                {
                    return BadRequest(new List<string> { json });
                }

                if (rawData == null)
                    return BadRequest("Error. Unable to connect to login server.");

                if ((string)rawData["Status"] == "Error")
                {
                    return BadRequest(new List<string> { (string)rawData["ErrorMessage"] });
                }
                else if ((string)rawData["Status"] == "Reset")
                {
                    return Ok(new { reset = true });
                }

                var userDetails = JsonConvert.DeserializeObject<Dictionary<string, string>>(rawData["User"]?.ToString() ?? "{}")!;
                var permissions = JsonConvert.DeserializeObject<List<string>>(rawData["Permissions"]?.ToString() ?? "[]");
                var additionalProps = JsonConvert.DeserializeObject<Dictionary<string, string>>(rawData["AdditionalProps"]?.ToString() ?? "{}");

                var FullName = userDetails["FirstName"] + " " + userDetails["MiddleName"] + " " + userDetails["LastName"] + " " + userDetails["NameExtension"];

                var Username = username;
                var Id = userDetails["Id"];

                var RoleName = userDetails["Role"];

                return Ok(CreateToken(FullName, Id, Username, RoleName, permissions ?? new List<string>()));
            }
        }


        private string CreateToken(string FullName, string Id, string Username, string RoleName, List<string> Perms)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                Config.GetSection("keyjwt").Value!));
            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, Username),
                    new Claim(ClaimTypes.Role, RoleName),
                    new Claim("UID", Id),
                    new Claim("display_name", FullName),
                    new Claim("display_role", RoleName),
                    new Claim("Perms", "ANON_ACCESS")
                };
            //get permissions from role


            foreach (var perm in Perms)
            {
                claims.Add(new Claim("Perms", perm));
            }

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature),
                audience: Config.GetSection("Jwt:Audience").Value!,
                issuer: Config.GetSection("Jwt:Issuer").Value!);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;

        }


    }
}