using N4ZV0Z_HFT_2023241.Models;
using N4ZV0Z_HFT_2023241.Repository;
using System;
using System.Linq;

namespace N4ZV0Z_HFT_2023241.Logic
{
    public class GameLogic
    {
        //interfacek hianyoznak
        IRepository<Game> repo;
        public void Create(Game item)
        {
            if (item.Title.Length < 3)
            {
                throw new ArgumentException("Tite too short");
            }
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Game Read(int id)
        {
            var game = this.repo.Read(id);
            if (game == null)
            {
                throw new ArgumentException("Game does not exist");
            }
            return this.repo.Read(id);
        }

        public IQueryable<Game> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Game item)
        {
            this.repo.Update(item);
        }
        //non CRUD
    }
}
