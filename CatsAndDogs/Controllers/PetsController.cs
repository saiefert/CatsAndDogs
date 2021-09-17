using CatsAndDogs.Model;
using CatsAndDogs.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatsAndDogs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PetsController : ControllerBase
    {
        [HttpGet]
        public List<Pet> Get()
        {
            return Pets();
        }

        [HttpGet]
        [Route("/pets/{name}")]
        public List<Pet> Get(string name)
        {
            return Pets(name);
        }

        private List<Pet> Pets(string name = null)
        {
            var repo = new GetDataRepository();
            var pets = new List<Pet>();
            var dogs = repo.GetDogs();
            var cats = repo.GetCats();

            foreach (var item in dogs)
            {
                var dog = new Pet()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Age = item.Age,
                    Race = "dogs"
                };

                pets.Add(dog);
            }

            foreach (var item in cats)
            {
                var cat = new Pet()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Age = item.Age,
                    Race = "dogs"
                };

                pets.Add(cat);
            }

            if (name is null)
                return pets;

            return pets.Where(x => x.Name.ToLower().Contains(name.ToLower())).ToList();
        }

        [HttpGet]
        [Route("Dog")]
        public List<Dogs> Dogs()
        {
            var repo = new GetDataRepository();
            return repo.GetDogs();
        }

        [HttpGet]
        [Route("Cat")]
        public List<Cats> Cats()
        {
            var repo = new GetDataRepository();
            return repo.GetCats();
        }

        [HttpGet]
        [Route("OwnerPets/{ownerName}")]
        public List<Dogs> Dogs(string ownerName)
        {
            var repo = new GetDataRepository();
            return repo.GetDogs(ownerName);
        }

        [HttpDelete]
        [Route("Dog/{petId}")]
        public IActionResult Dogs(int petId)
        {
            var repo = new ChangeDataRepository();
            var dog = new Dogs() { Id = petId };
            repo.DeletePet(dog);

            return Ok();
        }

        [HttpDelete]
        [Route("Cat/{petId}")]
        public IActionResult Cats(int petId)
        {
            var repo = new ChangeDataRepository();
            var cat = new Cats() { Id = petId };
            repo.DeletePet(cat);

            return Ok();
        }

        [HttpPut]
        [Route("Dog")]
        public IActionResult Cats(Dogs dog)
        {
            var repo = new ChangeDataRepository();
            repo.InsertPet(dog);

            return StatusCode(201, "Created");
        }

        [HttpPut]
        [Route("Cat")]
        public IActionResult Dogs(Cats cat)
        {
            var repo = new ChangeDataRepository();
            repo.InsertPet(cat);

            return StatusCode(201, "Created");
        }

        [HttpPost]
        [Route("Cat")]
        public IActionResult DogsUpdate(Cats cat)
        {
            var repo = new ChangeDataRepository();
            repo.UpdatePet(cat);

            return Ok();
        }

        [HttpPost]
        [Route("Dog")]
        public IActionResult CatsUpdate(Dogs dog)
        {
            var repo = new ChangeDataRepository();
            repo.UpdatePet(dog);

            return Ok();
        }
    }
}
