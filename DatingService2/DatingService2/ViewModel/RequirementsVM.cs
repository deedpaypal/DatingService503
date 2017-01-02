using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatingService2.Model;
using DatingService2.Model.Tables;
using DatingService2.Model.Entities;

namespace DatingService2.ViewModel
{
    class RequirementsVM
    {
        /*Добавление записи в базу данных*/
        public static void AddRequirments(PRequirement requirement, int id)
        {
           /* Контекст нашей базы*/
            using (var context = new DatingServiceModel())
            {
               var req = new Requirement
               {
                    Id = id,
                    AgeFrom = requirement.AgeFrom,
                    AgeAbove = requirement.AgeAbove,
                    PartnerCity = requirement.City,
                    PartnerEducation = requirement.Education,
                    PartnerSex = requirement.Sex
               };
                    context.Requirements.Add(req);
                    context.SaveChanges();
                
                
            }
        }

       /* Метод для проверки существования записи с определенным id*/
        public static Boolean CheckRequirements(int id)
        {
            var checkIdList = (from t in new DatingServiceModel().Requirements
                               select t.Id);
            return checkIdList.Contains(id);
        }
    }
}
