using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N4ZV0Z_HFT_2023241.Models
{
    public class Publisher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PublisherId { get; set; }

        [Required]
        [StringLength(240)]
        public string PublisherName { get; set; }

        public string PublisherCountry { get; set; }

        public virtual ICollection<Game> Games { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }

        public Publisher()
        {
            Games = new HashSet<Game>();
            Employees = new HashSet<Employee>();
        }

        public Publisher(string line)
        {
            string[] split = line.Split('#');
            PublisherId = int.Parse(split[0]);
            PublisherName = split[1];
            PublisherCountry = split[2];
            Games = new HashSet<Game>();
            Employees = new HashSet<Employee>();
        }
    }
}
