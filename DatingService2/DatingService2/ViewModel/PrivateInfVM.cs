using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using DatingService2.Model;
using DatingService2.Model.Entities;
using DatingService2.Model.Tables;
using Microsoft.Build.Utilities;
using Microsoft.Win32;

namespace DatingService2.ViewModel
{
    class PrivateInfVM
    {

/*Добавление в табоицу PrivateInf*/
        public static void AddPrivateInf(UserPrivateInf upi, int id)
        {
            using (var context = new DatingServiceModel())
            {
                    var privateInf = new PrivateInf
                    {
                        Id = id,
                        Height = upi.Height,
                        Weight = upi.Weight,
                        phone = upi.Phone
                    };


            
                context.PrivateInfs.Add(privateInf);
                context.SaveChanges();

            }
            
        }


        /*Проверка записи в таблице PrivateInf пользователя с id */
        public static Boolean CheckPrivateInf(int id)
        {
            var checkIdList = (from t in new DatingServiceModel().PrivateInfs
                select t.Id);
            return checkIdList.Contains(id);
        }

        public static Boolean CheckPhone(string phone)
        {
            return Regex.IsMatch(phone, @"[6-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]");
        }
    }
}
