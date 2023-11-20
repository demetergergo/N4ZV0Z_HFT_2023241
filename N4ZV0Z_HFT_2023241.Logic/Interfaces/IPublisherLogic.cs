using N4ZV0Z_HFT_2023241.Models;
using System.Linq;

namespace N4ZV0Z_HFT_2023241.Logic
{
    public interface IPublisherLogic
    {
        void Create(Publisher item);
        void Delete(int id);
        Publisher Read(int id);
        IQueryable<Publisher> ReadAll();
        void Update(Publisher item);
    }
}