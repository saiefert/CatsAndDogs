using CatsAndDogs.Model;
using System.Collections.Generic;

namespace CatsAndDogs.Repository
{
    public interface IChangeDataRepository
    {
        void DeletePet(Cats cats);
        void DeletePet(Dogs dogs);
        void InsertPet(Cats cats);
        void InsertPet(Dogs dogs);
        void InsertPet(List<Cats> cats);
        void InsertPet(List<Dogs> dogs);
        void UpdatePet(Cats cats);
        void UpdatePet(Dogs dogs);
    }
}