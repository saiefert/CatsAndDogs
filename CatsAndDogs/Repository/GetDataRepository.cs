using CatsAndDogs.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatsAndDogs.Repository
{
    public class GetDataRepository : IGetDataRepository
    {

        public List<Dogs> GetDogs()
        {
            using (var db = new ApiContext())
                return db.DogsTable.ToList();
        }

        public List<Owner> GetOwners()
        {
            using (var db = new ApiContext())
            {
                var owners = new List<Owner>();

                var query = db.OwnerTable
                    .Select(owner => new { owner, owner.Dogs, owner.Cats });

                foreach (var item in query)
                {
                    var owner = new Owner()
                    {
                        Id = item.owner.Id,
                        Name = item.owner.Name,
                        Cats = item.Cats,
                        Dogs = item.Dogs
                    };

                    owners.Add(owner);
                }

                return owners;
            }
        }

        public List<Dogs> GetDogs(string ownerName)
        {
            using (var db = new ApiContext())
                return db.DogsTable.Where(x => x.Owner.Name == ownerName).ToList();
        }

        public List<Cats> GetCats(string ownerName)
        {
            using (var db = new ApiContext())
                return db.CatsTable.Where(x => x.Owner.Name == ownerName).ToList();
        }

        public List<Cats> GetCats()
        {
            using (var db = new ApiContext())
                return db.CatsTable.ToList();
        }
    }
}
