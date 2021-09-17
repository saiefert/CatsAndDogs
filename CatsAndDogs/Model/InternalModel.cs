using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatsAndDogs.Model
{
    public struct OwnerStruct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Pet> PetStruct { get; set; }
    }

    public struct Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Race { get; set; }
    }
}
