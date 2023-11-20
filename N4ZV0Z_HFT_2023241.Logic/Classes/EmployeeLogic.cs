using N4ZV0Z_HFT_2023241.Models;
using N4ZV0Z_HFT_2023241.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N4ZV0Z_HFT_2023241.Logic
{
    public class EmployeeLogic : IEmployeeLogic
    {
        IRepository<Employee> repo;

        public EmployeeLogic(IRepository<Employee> repo)
        {
            this.repo = repo;
        }

        public void Create(Employee item)
        {
            if (item.EmployeeFirstName.Length < 3)
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
        //non-CRUD
        #region YoungestEmployeeAtPublishers
        public IEnumerable<MostIncomeGamePerPublisherInfo> YoungestEmployeeAtPublishers()
        {
            return this.repo.ReadAll().ToList().GroupBy(a => a.Publisher.PublisherCountry).Select(grouped => new
            {
                id = grouped.Key,
                young = grouped.OrderBy(b => b.EmployeeAge).First()
            })
                .Select(result => new MostIncomeGamePerPublisherInfo()
                {
                    PublisherCountry = result.young.Publisher.PublisherCountry,
                    FistName = result.young.EmployeeFirstName,
                    LastName = result.young.EmployeeLastName,
                    Age = result.young.EmployeeAge
                }).ToArray();
        }
        public class MostIncomeGamePerPublisherInfo
        {
            public string PublisherCountry { get; set; }
            public string FistName { get; set; }
            public string LastName { get; set; }
            public double Age { get; set; }
            public override bool Equals(object obj)
            {
                MostIncomeGamePerPublisherInfo b = obj as MostIncomeGamePerPublisherInfo;
                if (b == null) return false;
                else
                {
                    return this.PublisherCountry == b.PublisherCountry &&
                            this.FistName == b.FistName &&
                            this.LastName == b.LastName &&
                            this.Age == b.Age;
                }
            }
            public override int GetHashCode()
            {
                return HashCode.Combine(this.PublisherCountry, this.FistName, this.LastName, this.Age);
            }
        }
        #endregion
    }
}
