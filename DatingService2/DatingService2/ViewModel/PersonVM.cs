using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatingService2.Model;
using DatingService2.Model.Tables;

namespace DatingService2.ViewModel
{
    class PersonVM
    {

        /*Информация о пользователе*/
        public static Person CreatePerson(int id)
        {
            
            var firstname = (from t in new DatingServiceModel().People
                            where id == t.Id
                            select t.FirstName);
            var lastname = (from t in new DatingServiceModel().People
                            where id == t.Id
                            select t.FirstName);
            var birthday = (from t in new DatingServiceModel().People
                            where id == t.Id
                            select t.Birthday);
            var sex = (from t in new DatingServiceModel().People
                       where id == t.Id
                       select t.Sex);
            Person person = new Person
            {
                FirstName = firstname.FirstOrDefault(),
                LastName = lastname.FirstOrDefault(),
                Birthday = birthday.FirstOrDefault(),
                Sex = sex.FirstOrDefault()
            };
            return person;

        }
    }
}
