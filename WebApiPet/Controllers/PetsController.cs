using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiPet.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiPet.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly IConfiguration Configuration;
        public PetsController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // GET: api/<PetsController>
        [HttpGet]
        public ApiResponse Get()
        {
            return new PetModel().GetAll(Configuration.GetConnectionString("MySQL"));
        }

        // GET <PetsController>/5
        [HttpGet("{id}/{nombre}")]
        public ApiResponse Get(int id, string nombre)
        {
            return new PetModel().Get(Configuration.GetConnectionString("MySQL"),id);
        }

        // POST api/<PetsController>
        [HttpPost]
        public ApiResponse Post([FromBody] PetModel pet)
        {
            return pet.Insert(Configuration.GetConnectionString("MySQL"));
        }

        // PUT api/<PetsController>/5
        [HttpPut]
        public ApiResponse Put([FromBody] PetModel pet)
        {
            return pet.Update(Configuration.GetConnectionString("MySQL"));

        }

        // DELETE api/<PetsController>/5
        [HttpDelete("{id}")]
        public ApiResponse Delete(int id)
        {
            return new PetModel().Delete(Configuration.GetConnectionString("MySQL"), id);
        }
    }
}
