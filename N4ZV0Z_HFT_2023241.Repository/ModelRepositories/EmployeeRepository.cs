using N4ZV0Z_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N4ZV0Z_HFT_2023241.Repository
{
    public class EmployeeRepository : Repository<Employee>, IRepository<Employee>
    {
        public EmployeeRepository(GameDbContext ctx) : base(ctx)
        {
        }

        public override Employee Read(int id)
        {
            return ctx.employees.FirstOrDefault(t => t.EmployeeId == id);
        }


        public override void Update(Employee item)
        {
            var old = Read(item.EmployeeId);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
