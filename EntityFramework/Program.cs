using System;
using Microsoft.EntityFrameworkCore;
using EntityFramework.Entities;
using System.ComponentModel.DataAnnotations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EntityFramework
{
    class Program
    {
        public static void Main(string[] args)
        {
            
                // Создаем контекст для добавления данных
                using (var db = new AppContext())
                {
                    // Пересоздаем базу
                    db.Database.EnsureDeleted();
                    db.Database.EnsureCreated();

                    // Заполняем данными
                    var company1 = new CompanyEntity { Name = "SF" };
                    var company2 = new CompanyEntity { Name = "VK" };
                    var company3 = new CompanyEntity { Name = "FB" };
                    db.Companies.AddRange(company1, company2, company3);

                    var user1 = new UserEntity { Name = "Arthur", Role = "Admin", Company = company1 };
                    var user2 = new UserEntity { Name = "Bob", Role = "Admin", Company = company2 };
                    var user3 = new UserEntity { Name = "Clark", Role = "User", Company = company2 };
                    var user4 = new UserEntity { Name = "Dan", Role = "User", Company = company3 };

                    db.Users.AddRange(user1, user2, user3, user4);

                    db.SaveChanges();
                }

                // Создаем контекст для выбора данных
                using (var db = new AppContext())
                {
                var usersQuery =
                    from user in db.Users.Include(u => u.Company)
                    where user.CompanyId == 2
                    select user;

                var users = usersQuery.ToList();

                    foreach (var user in users)
                    {
                        // Вывод Id пользователей
                        Console.WriteLine(user.Id);
                    }
                }
            

        }
    }
}