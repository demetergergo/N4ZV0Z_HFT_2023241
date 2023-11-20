using N4ZV0Z_HFT_2023241.Models;
using N4ZV0Z_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N4ZV0Z_HFT_2023241.Logic
{
    public class PublisherLogic : IPublisherLogic
    {
        //interfacek hianyoznak
        IRepository<Publisher> repo;

        public PublisherLogic(IRepository<Publisher> repo)
        {
            this.repo = repo;
        }

        public void Create(Publisher item)
        {
            if (item.PublisherName.Length < 3)
            {
                throw new ArgumentException("Name is too short");
            }
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Publisher Read(int id)
        {
            var game = this.repo.Read(id);
            if (game == null)
            {
                throw new ArgumentException("Publisher does not exist");
            }
            return this.repo.Read(id);
        }

        public IQueryable<Publisher> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Publisher item)
        {
            this.repo.Update(item);
        }
        //non CRUD
    }
}
