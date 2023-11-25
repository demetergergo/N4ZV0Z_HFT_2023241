using ConsoleTools;
using MovieDbApp.Client;
using N4ZV0Z_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace N4ZV0Z_HFT_2023241.Client
{
    internal class Program
    {
        static RestService rest;
        static void Create(string entity)
        {
            if (entity == "Game")
            {
                Console.Write("Enter Game Name: ");
                string name = Console.ReadLine();
                rest.Post(new Game() { Title = name }, "game");
            }
            else if (entity == "Publisher")
            {
                Console.Write("Enter Publisher Name: ");
                string name = Console.ReadLine();
                rest.Post(new Publisher() {  PublisherName = name }, "publisher");
            }
            else if (entity == "Employee")
            {
                Console.Write("Enter Employees first name: ");
                string firstname = Console.ReadLine();
                Console.Write("Enter Employees last name: ");
                string lastname = Console.ReadLine();
                Console.Write("Enter Employees Age: ");
                int age = int.Parse(Console.ReadLine());

                rest.Post(new Employee() { EmployeeFirstName = firstname, EmployeeLastName = lastname, EmployeeAge = age}, "employee");
            }
        }
        static void List(string entity)
        {
            if (entity == "Game")
            {
                List<Game> games = rest.Get<Game>("game");
                foreach (var item in games)
                {
                    Console.WriteLine(item.GameID + ": " + item.Title);
                }
            }
            else if (entity == "Publisher")
            {
                List<Publisher> publishers = rest.Get<Publisher>("Publisher");
                foreach (var item in publishers)
                {
                    Console.WriteLine(item.PublisherId + ": " + item.PublisherName);
                }
            }
            else if (entity == "Employee")
            {
                List<Employee> employees = rest.Get<Employee>("Employee");
                foreach (var item in employees)
                {
                    Console.WriteLine(item.EmployeeId + ": " + item.EmployeeFirstName + " " + item.EmployeeLastName);
                }
            }
            Console.ReadLine();
        }
        static void Update(string entity)
        {
            if (entity == "Game")
            {
                Console.Write("Enter a games id to update: ");
                int id = int.Parse(Console.ReadLine());
                Game one = rest.Get<Game>(id, "game");
                Console.Write($"New name [old: {one.Title}]: ");
                string name = Console.ReadLine();
                one.Title = name;
                rest.Put(one, "game");
            }
            else if (entity == "Publisher")
            {
                Console.Write("Enter a publishers id to update: ");
                int id = int.Parse(Console.ReadLine());
                Publisher one = rest.Get<Publisher>(id, "publisher");
                Console.Write($"New name [old: {one.PublisherName}]: ");
                string name = Console.ReadLine();
                one.PublisherName = name;
                rest.Put(one, "publisher");
            }
            else if (entity == "Employee")
            {
                Console.Write("Enter an Employees id to update: ");
                int id = int.Parse(Console.ReadLine());
                Employee one = rest.Get<Employee>(id, "employee");
                Console.Write($"New firstname [old: {one.EmployeeFirstName}]: ");
                string firstname = Console.ReadLine();
                Console.Write($"New lastname [old: {one.EmployeeLastName}]: ");
                string lastname = Console.ReadLine();
                one.EmployeeFirstName = firstname;
                one.EmployeeLastName = lastname;
                rest.Put(one, "employee");
            }
        }
        static void Delete(string entity)
        {
            if (entity == "Game")
            {
                Console.Write("Enter a games id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "game");
            }
            else if (entity == "Publisher")
            {
                Console.Write("Enter a publishers id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "publisher");
            }
            else if (entity == "Employee")
            {
                Console.Write("Enter an employees id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "employee");
            }
        }

        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:35916/", "game");

            var GameSubMenu = new ConsoleMenu(args, level: 1)
            .Add("List", () => List("Game"))
            .Add("Create", () => Create("Game"))
            .Add("Delete", () => Delete("Game"))
            .Add("Update", () => Update("Game"))
            .Add("Exit", ConsoleMenu.Close);

            var PublisherSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Publisher"))
                .Add("Create", () => Create("Publisher"))
                .Add("Delete", () => Delete("Publisher"))
                .Add("Update", () => Update("Publisher"))
                .Add("Exit", ConsoleMenu.Close);


            var EmployeeSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Employee"))
                .Add("Create", () => Create("Employee"))
                .Add("Delete", () => Delete("Employee"))
                .Add("Update", () => Update("Employee"))
                .Add("Exit", ConsoleMenu.Close);


            var menu = new ConsoleMenu(args, level: 0)
                .Add("Games", () => GameSubMenu.Show())
                .Add("Publishers", () => PublisherSubMenu.Show())
                .Add("Employees", () => EmployeeSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();

        }
    }
}
