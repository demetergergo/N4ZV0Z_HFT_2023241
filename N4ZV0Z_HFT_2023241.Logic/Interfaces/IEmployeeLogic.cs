using N4ZV0Z_HFT_2023241.Models;
using System.Collections.Generic;
using System.Linq;

namespace N4ZV0Z_HFT_2023241.Logic
{
    public interface IEmployeeLogic
    {
        void Create(Employee item);
        void Delete(int id);
        Employee Read(int id);
        IQueryable<Employee> ReadAll();
        void Update(Employee item);
        IEnumerable<EmployeeLogic.MostIncomeGamePerPublisherInfo> YoungestEmployeeAtPublishers();
    }
}