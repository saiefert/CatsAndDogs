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
    public class OwnerController : ControllerBase
    {
        [HttpGet]
        public List<OwnerStruct> Get()
        {
            return ReturnOwners();
        }

        [HttpGet]
        [Route("/owner/{name}")]
        public List<OwnerStruct> Get(string name)
        {
            return ReturnOwners(name);
        }

        private List<OwnerStruct> ReturnOwners(string name = null)
        {
            var repo = new GetDataRepository();
            var ownersBd = repo.GetOwners();
            var owners = new List<OwnerStruct>();

            foreach (var owner in ownersBd)
            {
                var pets = new List<Pet>();

                foreach (var pet in owner.Cats)
                {
                    var newCat = new Pet() { Name = pet.Name, Age = pet.Age, Race = "cats" };
                    pets.Add(newCat);
                }

                foreach (var pet in owner.Dogs)
                {
                    var newDog = new Pet() { Id = pet.Id, Name = pet.Name, Age = pet.Age, Race = "dog" };
                    pets.Add(newDog);
                }

                var newOwner = new OwnerStruct()
                {
                    Id = owner.Id,
                    Name = owner.Name,
                    PetStruct = pets
                };

                owners.Add(newOwner);
            }

            if (name is null)
                return owners;

            return owners.Where(x => x.Name.Contains(name)).ToList();
        }
    }
}
