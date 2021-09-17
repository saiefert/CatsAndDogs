using CatsAndDogs.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatsAndDogs.Repository
{
    public class ChangeDataRepository : IChangeDataRepository
    {
        #region Metodos para update
        // os metodos abaixo (com sobrecarga) realizam o update)
        public void UpdatePet(Dogs dogs)
        {
            using (var db = new ApiContext())
            {
                db.DogsTable.Update(dogs);
                db.SaveChanges();
            }
        }

        #endregion

        public void UpdatePet(Cats cats)
        {
            using (var db = new ApiContext())
            {
                db.CatsTable.Update(cats);
                db.SaveChanges();
            }
        }

        #region Metodos para inserir

        // os metodos abaixo (com sobrecarga) inserem nas respectivas tabelas)
        public void InsertPet(Dogs dogs)
        {
            using (var db = new ApiContext())
            {
                db.DogsTable.Add(dogs);
                db.SaveChanges();
            }
        }

        public void InsertPet(List<Dogs> dogs)
        {
            using (var db = new ApiContext())
            {
                db.DogsTable.AddRange(dogs);
                db.SaveChanges();
            }
        }

        public void InsertPet(List<Cats> cats)
        {
            using (var db = new ApiContext())
            {
                db.CatsTable.AddRange(cats);
                db.SaveChanges();
            }
        }

        public void InsertPet(Cats cats)
        {
            using (var db = new ApiContext())
            {
                db.CatsTable.Add(cats);
                db.SaveChanges();
            }
        }

        #endregion

        #region Metodos para Deletar

        // os metodos abaixo (com sobrecarga) deletam nas respectivas tabelas)
        public void DeletePet(Dogs dogs)
        {
            using (var db = new ApiContext())
            {
                db.DogsTable.Remove(dogs);
                db.SaveChanges();
            }
        }

        public void DeletePet(Cats cats)
        {
            using (var db = new ApiContext())
            {
                db.CatsTable.Remove(cats);
                db.SaveChanges();
            }
        }
        #endregion

    }
}
