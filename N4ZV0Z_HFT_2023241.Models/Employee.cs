using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N4ZV0Z_HFT_2023241.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }

        [Required]
        [StringLength(240)]
        public string EmployeeFirstName { get; set; }
        
        [Required]
        [StringLength(240)]
        public string EmployeeLastName { get; set; }

        [Range(18, 120)]
        public double EmployeeAge { get; set; }

        [StringLength(240)]
        public string EmployeePosition { get; set; }

        public int PublisherId { get; set; }

        public virtual Publisher Publisher { get; set; }

        public Employee()
        {
        }

        public Employee(string line)
        {
            string[] split = line.Split('#');
            EmployeeId = int.Parse(split[0]);
            EmployeeFirstName = split[1];
            EmployeeLastName = split[2];
            EmployeeAge = int.Parse(split[3]);
            EmployeePosition = split[4];
            PublisherId = int.Parse(split[5]);
        }
    }
}
