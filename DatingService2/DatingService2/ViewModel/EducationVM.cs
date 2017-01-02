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
    class EducationVM
    {

/*Добавление записи в таблицу Education*/
        public static void AddPersonEducation(PEducation pEducation)
        {
            using (var context = new DatingServiceModel())
            {
                var education = new Education
                {
                    Id = pEducation.Id,
                    PersonEducation = pEducation.PersonEducation

                };

                context.Educations.Add(education);
                context.SaveChanges();

            }
        }

/*Проверка записи в таблице Education пользователя с id */
        public static Boolean CheckEducation(int id)
        {
            var checkIdList = (from t in new DatingServiceModel().Educations
                               select t.Id);
            return checkIdList.Contains(id);
        }
    }
}
