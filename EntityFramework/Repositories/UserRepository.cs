using EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Repositories
{


    //выбор объекта из БД по его идентификатору, выбор всех объектов, добавление объекта в БД и его удаление из БД.
    //А также специфичные методы: обновление имени пользователя (по Id)
    public class UserRepository
    {
        public UserEntity SelectUserForId(int id)
        {
                var db = new AppContext();
                var res = db.Users.Where(user => user.Id == id).FirstOrDefault();
            return res;
        }

        public List<UserEntity> SelectAllUsers()
        {
            var db = new AppContext();
            var res = db.Users.ToList();
            return res;

        }

        public string InsertUser(UserEntity newUser)
        {
            var db = new AppContext();
            db.Users.Add(newUser);
            db.SaveChanges();
            string res = $"User {newUser.Name} added success";
            return res;
        }

        public string DeleteUser(UserEntity delUser)
        {
            var db = new AppContext();
            db.Users.Remove(delUser);
            db.SaveChanges();
            string res = $"User {delUser.Name} deleted success";
            return res;
        }


        public UserEntity UpdateUserForId(int id, string newName)
        {
            var db = new AppContext();
            var userUpdate = db.Users.Where(user => user.Id == id).FirstOrDefault();
            userUpdate.Name = newName;
            db.SaveChanges();
            return userUpdate;

        }

    }
}
