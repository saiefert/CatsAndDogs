using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatsAndDogs.Model
{
    public class Owner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Dogs> Dogs { get; set; }
        public virtual ICollection<Cats> Cats { get; set; }     
    }

    public class Cats
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int OwnerId { get; set; }
        public virtual Owner Owner { get; }
    }
    public class Dogs
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int OwnerId { get; set; }
        public virtual Owner Owner { get; }
    }

}
