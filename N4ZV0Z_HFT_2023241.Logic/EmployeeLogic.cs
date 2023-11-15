using N4ZV0Z_HFT_2023241.Models;
using N4ZV0Z_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N4ZV0Z_HFT_2023241.Logic
{
    public class EmployeeLogic
    {
        IRepository<Employee> repo;

        public EmployeeLogic(IRepository<Employee> repo)
        {
            this.repo = repo;
        }

        public void Create(Employee item)
        {
            if(item.EmployeeFirstName.Length < 3)
            {
                throw new ArgumentException("First name too short");
            }
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Employee Read(int id)
        {
            var employee = this.repo.Read(id);
            if (employee == null)
            {
                throw new ArgumentException("Employee does not exist");
            }
            return this.repo.Read(id);
        }

        public IQueryable<Employee> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Employee item)
        {
            this.repo.Update(item);
        }
    }
}
