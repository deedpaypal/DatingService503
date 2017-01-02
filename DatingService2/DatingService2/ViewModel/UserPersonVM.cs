using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatingService2.Model.Tables;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Windows.Controls;
using DatingService2.Model;

namespace DatingService2.ViewModel
{
    class UserPersonVM
    {

/*Добавление в таблицы users и person*/
        public static void addUserAndPerson(User user, Person person)
        {
            using (var context = new DatingServiceModel())
            {
                try
                {
                    var user1 = new User
                    {
                        username = user.username,
                        userPassword = user.userPassword
                    };
                    
                        
                
                var person1 = new Person
                    {
                        FirstName = person.FirstName,
                        LastName = person.LastName,
                        Sex = person.Sex,
                        Birthday = person.Birthday
                    };
                    user1.Person = person1;
                    context.Users.Add(user1);
                    context.SaveChanges();
                }
                catch (DbEntityValidationException exception)
                {
                    foreach (var eve in exception.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }
            }

        }

/*Аутентификация*/
        public static Boolean ConfirmUser(string name, string password)
        {
            var context = new DatingServiceModel();
            /*Проверка пароля*/
            var p = (from t in new DatingServiceModel().Users
                where t.username == name
                select t.userPassword);
            return p.Contains(password);

        }

/*Проверка на уникальность username*/
        public static Boolean CheckUserName(string name)
        {
            var p = (from t in (new DatingServiceModel().Users)
                     select t.username);
            return p.Contains(name);
        }

/*Id уникального пользователя с username*/
        public static int CheckUserId(string name)
        {
            var id = (from t in (new DatingServiceModel().Users)
                where name == t.username
                select t.id).First();
            return id;
        }

/*Проверка существования записи пользователя*/
        public static Boolean CheckUser(int id)
        {
            var checkIdList = (from t in new DatingServiceModel().Users
                               select t.id);
            return checkIdList.Contains(id);
        }

        public static Boolean CheckBirthday(DateTime date)
        {
            return date > DateTime.Now;
        }
    }
}
