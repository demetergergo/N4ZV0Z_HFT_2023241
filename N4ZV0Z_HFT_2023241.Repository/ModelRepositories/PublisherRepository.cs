using N4ZV0Z_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N4ZV0Z_HFT_2023241.Repository
{
    public class PublisherRepository : Repository<Publisher>, IRepository<Publisher>
    {
        public PublisherRepository(GameDbContext ctx) : base(ctx)
        {
        }

        public override Publisher Read(int id)
        {
            return ctx.publishers.FirstOrDefault(t => t.PublisherId == id);
        }

        public override void Update(Publisher item)
        {
            var old = Read(item.PublisherId);
            foreach (var prop in old.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(item));
                }
            }
            ctx.SaveChanges();
        }
    }
}
