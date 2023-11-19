using Microsoft.EntityFrameworkCore;
using N4ZV0Z_HFT_2023241.Models;
using System;

namespace N4ZV0Z_HFT_2023241.Repository
{
    public class GameDbContext : DbContext
    {
        public DbSet<Game> games { get; set; }
        public DbSet<Publisher> publishers { get; set; }
        public DbSet<Employee> employees { get; set; }
        public GameDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder
                    .UseLazyLoadingProxies()
                    .UseInMemoryDatabase("game");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>(game => game
                .HasOne(game => game.Publisher)
                .WithMany(Publisher => Publisher.Games)
                .HasForeignKey(game => game.PublisherId)    
                .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Employee>(epmloyee => epmloyee
                .HasOne(employee => employee.Publisher)
                .WithMany(Publisher => Publisher.Employees)
                .HasForeignKey(employee => employee.PublisherId)
                .OnDelete(DeleteBehavior.Cascade));

        modelBuilder.Entity<Game>().HasData(new Game[]
            {
                //id#title#rating#income#release#publisherid
                new Game("1#Realm of Eternity#8#42050#2019*08*15#10"),
                new Game("2#Celestial Odyssey#2#30620#2013*10*10#10"),
                new Game("3#Mystic Enchantments#10#63980#2001*09*22#9"),
                new Game("4#Chronicles of Infinity#5#74820#2001*01*10#1"),
                new Game("5#Epic Legends#9#832920#2003*09*01#2"),
                new Game("6#Whispers of Eldoria#4#98720#2000*03*22#8"),
                new Game("10#Realm of Eternity 2#3#263280#2002*05*30#4"),
                new Game("11#Legends of Mythos#8#36270#2001*03*25#7"),
                new Game("12#Enchanted Realms#7#372890#2002*08*17#3"),
                new Game("13#Lost Kingdoms#2#21710#2014*06*25#5"),
                new Game("14#Astral Ascendance#5#23790#2019*05*15#6"),
                new Game("15#Whirlwind of Sorcery#5#237860#2018*11*23#6"),
                new Game("16#Eternal Odyssey#9#237680#2015*02*20#10"),
                new Game("17#Mythical Realms#3#23780#2019*08*15#8"),
                new Game("18#Chronicles of Destiny#10#12370#2011*07*10#2"),
                new Game("19#Arcane Adventures#7#37620#2009*03*15#3"),
                new Game("20#Legendary Quests#5#236870#2011*09*11#4")
            });

            modelBuilder.Entity<Publisher>().HasData(new Publisher[]
            {
                //id#name#country#
                new Publisher("1#Arcane Realities Entertainment#Hungary"),
                new Publisher("2#Eldritch Tales Publishing#Poland"),
                new Publisher("3#Axis Entertainment#USA"),
                new Publisher("4#Stellar Studios#USA"),
                new Publisher("5#Quantum#Hungary"),
                new Publisher("6#Nexus Games#Cambodia"),
                new Publisher("7#Nexus Games DE#Germany"),
                new Publisher("8#Catalyst#France"),
                new Publisher("9#Vanguard Interactive#Poland"),
                new Publisher("10#Orion Studios#USA")
            });

            modelBuilder.Entity<Employee>().HasData(new Employee[]
            {
                //id#firstname#lastname#age#position#publisherid
                new Employee("1#Demeter#Gergo#20#developer#1"),
                new Employee("2#Siem#Viktoria#22#ceo#1"),
                new Employee("3#Vicc#Elek#45#developer#1"),

                new Employee("4#Aleksander#Kowalski#35#ceo#2"),
                new Employee("5#Magdalena#Nowak#20#hr#2"),
                new Employee("6#Krzysztof#Nowicki#68#developer#2"),

                new Employee("7#Nagy#Bela#60#ceo#3"),
                new Employee("8#Kis#Alma#24#hr#3"),
                new Employee("9#Rizz#Levente#64#developer#3"),

                new Employee("10#david#brown#31#engineer#4"),
                new Employee("11#emily#davis#26#analyst#4"),
                new Employee("12#frank#miller#34#marketing#4"),

                new Employee("13#gina#roberts#39#analyst#5"),
                new Employee("14#henry#thompson#45#developer#5"),
                new Employee("15#isabel#scott#29#designer#5"),

                new Employee("16#jack#harris#36#manager#6"),
                new Employee("17#kelly#king#31#engineer#6"),
                new Employee("18#leo#cooper#27#developer#6"),

                new Employee("19#megan#hill#40#designer#7"),
                new Employee("20#nathan#white#33#analyst#7"),
                new Employee("21#olivia#moore#38#marketing#7"),

                new Employee("22#peter#martinez#28#engineer#8"),
                new Employee("23#quinn#phillips#41#manager#8"),
                new Employee("24#rachel#lee#35#developer#8"),

                new Employee("25#sam#evans#30#designer#9"),
                new Employee("26#tom#ross#32#analyst#9"),
                new Employee("27#umberto#gray#37#marketing#9"),

                new Employee("28#victoria#campbell#39#developer#10"),
                new Employee("29#william#turner#26#designer#10"),
                new Employee("30#xander#cohen#44#engineer#10"),
                new Employee("31#chad#coder#18#developer#10"),
            });

        }
    }
}
