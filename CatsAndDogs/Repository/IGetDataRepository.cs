using CatsAndDogs.Model;
using System.Collections.Generic;

namespace CatsAndDogs.Repository
{
    public interface IGetDataRepository
    {
        List<Cats> GetCats();
        List<Cats> GetCats(string ownerName);
        List<Dogs> GetDogs();
        List<Dogs> GetDogs(string ownerName);
        List<Owner> GetOwners();
    }
}