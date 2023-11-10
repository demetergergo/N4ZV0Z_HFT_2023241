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



        public Publisher()
        {
        }

        public Publisher(string line)
        {
            string[] split = line.Split('#');
            PublisherId = int.Parse(split[0]);
            PublisherName = split[1];
        }
    }
}
