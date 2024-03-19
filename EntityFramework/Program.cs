using System;
using Microsoft.EntityFrameworkCore;
using EntityFramework.Entities;
using System.ComponentModel.DataAnnotations;

namespace EntityFramework
{
    class Program
    {
        public static void Main(string[] args)
        {

            using (var db = new AppContext())
            {
                var user1 = new UserEntity { Name = "Arthur", Role = "Admin", Email = "" };
                var user2 = new UserEntity { Name = "Klim", Role = "User", Email = "" };
                var user3 = new UserEntity { Name = "Alice", Role = "User", Email = "" };
                var user4 = new UserEntity { Name = "Bob", Role = "User", Email = "" };
                var user5 = new UserEntity { Name = "Bruce", Role = "User" , Email = "" };

                /*
                db.Users.Add(user1);
                db.Users.Add(user2);
                db.Users.Add(user3);
                db.Users.Add(user4);
                db.SaveChanges();
                */


                // Выбор всех пользователей
                var allUsersd = db.Users.ToList();
                

                // Выбор пользователей с ролью "Admin"
                var admins = db.Users.Where(user => user.Role == "Admin").ToList();

                // Выбор первого пользователя в таблице
                var firstUser = db.Users.FirstOrDefault();
                
                firstUser.Email = "simpleemail@gmail.com";
                db.SaveChanges();


                Console.Read();
            }

        }
    }
}