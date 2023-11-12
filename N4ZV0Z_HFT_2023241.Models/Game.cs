using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.IO;
using System.Numerics;

namespace N4ZV0Z_HFT_2023241.Models
{
    public class Game
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GameID { get; set; }

        [StringLength(240)]
        public string Title { get; set; }

        [Range(0, 10)]
        public double Rating { get; set; }

        [Range(0, 10000)]
        public double Income { get; set; }

        public DateTime Release { get; set; }

        public int PublisherId { get; set; }

        public virtual Publisher Publisher { get; set; }

        public Game()
        {

        }

        public Game(string line)
        {
            string[] split = line.Split('#');
            GameID = int.Parse(split[0]);
            Title = split[1];
            Rating = double.Parse(split[2]);
            Income = double.Parse(split[3]);
            Release = DateTime.Parse(split[4].Replace('*', '.'));
            PublisherId = int.Parse(split[5]);
        }

    }
}
