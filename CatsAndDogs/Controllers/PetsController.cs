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
        private readonly IChangeDataRepository _setData;
        private readonly IGetDataRepository _getData;
        public PetsController(IChangeDataRepository dataRepository, IGetDataRepository getDataRepository)
        {
            _setData = dataRepository;
            _getData = getDataRepository;
        }

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
            return _getData.GetDogs();
        }

        [HttpGet]
        [Route("Cat")]
        public List<Cats> Cats()
        {
            return _getData.GetCats();
        }

        [HttpGet]
        [Route("OwnerPets/{ownerName}")]
        public List<Dogs> Dogs(string ownerName)
        {
            return _getData.GetDogs(ownerName);
        }

        [HttpDelete]
        [Route("Dog/{petId}")]
        public IActionResult Dogs(int petId)
        {
            var dog = new Dogs() { Id = petId };
            _setData.DeletePet(dog);

            return Ok();
        }

        [HttpDelete]
        [Route("Cat/{petId}")]
        public IActionResult Cats(int petId)
        {
            var cat = new Cats() { Id = petId };
            _setData.DeletePet(cat);

            return Ok();
        }

        [HttpPut]
        [Route("Dog")]
        public IActionResult Cats(Dogs dog)
        {
            _setData.InsertPet(dog);
            return StatusCode(201, "Created");
        }

        [HttpPut]
        [Route("Cat")]
        public IActionResult Dogs(Cats cat)
        {
            _setData.InsertPet(cat);
            return StatusCode(201, "Created");
        }

        [HttpPost]
        [Route("Cat")]
        public IActionResult DogsUpdate(Cats cat)
        {
            _setData.UpdatePet(cat);
            return Ok();
        }

        [HttpPost]
        [Route("Dog")]
        public IActionResult CatsUpdate(Dogs dog)
        {
            _setData.UpdatePet(dog);
            return Ok();
        }
    }
}
