using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatingService2.Model;
using DatingService2.Model.Entities;
using DatingService2.Model.Tables;

namespace DatingService2.ViewModel
{
    class CityVM
    {
        /*Добавление записи в таблицу City*/
        public static void AddPersonCity(PCity pCity) 
        {
            using (var context = new DatingServiceModel())
            {
                var city = new City
                {
                    Id = pCity.Id,
                    PersonCity = pCity.PersonCity
                    
                };

                context.Cities.Add(city);
                context.SaveChanges();

            }
        }

        /*Проверка записи в таблице City пользователя с id */
        public static Boolean CheckCity(int id)
        {
            var checkIdList = (from t in new DatingServiceModel().Cities
                               select t.Id);
            return checkIdList.Contains(id);
        }
    }
}
