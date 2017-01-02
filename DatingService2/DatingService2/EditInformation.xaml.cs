using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DatingService2.Model;
using DatingService2.Model.Tables;
using DatingService2.ViewModel;

namespace DatingService2
{
    /// <summary>
    /// Логика взаимодействия для EditInformation.xaml
    /// </summary>
    public partial class EditInformation : Window
    {
        public  static int id = Convert.ToInt32(Application.Current.Properties["Id"]);
        public EditInformation()
        {
            InitializeComponent();
        }

/*Кнопка delete requirements*/
        private void deleteRequirement_Click(object sender, RoutedEventArgs e)
        {
/*Проверяем есть ли в таблице запись*/
            if (RequirementsVM.CheckRequirements(id))
            {
                var item = new Requirement
                {
                    Id = id
                };
/*Создаем контекст базы данных*/
                var context = new DatingServiceModel();
                context.Requirements.Attach(item);
/*Удаляем*/
                context.Requirements.Remove(item);
                context.SaveChanges();

                MessageBox.Show("Req deleted");
            }
            else
            {
                MessageBox.Show("Req is empty!");

            }
        }


        /*Кнопка delete private inf*/
        private void deletePrivateInf_Click(object sender, RoutedEventArgs e)
        {
            /*Проверяем есть ли в таблице запись*/
            if (PrivateInfVM.CheckPrivateInf(id))
            {
                var item = new PrivateInf
                {
                    Id = id
                };
                var context = new DatingServiceModel();
                context.PrivateInfs.Attach(item);
                context.PrivateInfs.Remove(item);
                context.SaveChanges();

                MessageBox.Show("Private inf. deleted");
            }
            else
            {
                MessageBox.Show("Private inf. is empty!");
            }
        }

        /*Кнопка delete account*/
        private void deleteAccount_Click(object sender, RoutedEventArgs e)
        {

            var user = new User()
            {
                id = id
            };
            var person = new Person()
            {
                Id = id
            };
            /*Проверяем есть ли в таблице запись*/
            if (PrivateInfVM.CheckPrivateInf(id))
            {
                var pf = new PrivateInf
                {
                    Id = id
                };
                person.PrivateInf = pf;
            }
            /*Проверяем есть ли в таблице запись*/
            if (RequirementsVM.CheckRequirements(id))
            {
                var req = new Requirement
                {
                    Id = id
                };
                person.Requirement = req;
            }

            var context = new DatingServiceModel();

            context.Users.Attach(user);
            context.Users.Remove(user);

            context.People.Attach(person);
            context.People.Remove(person);

            context.SaveChanges();

            Hide();
            MessageBox.Show("Account deleted.");
            Hide();
            new MainWindow().Show();

        }

        /*Кнопка delete city*/
        private void deleteCity_Click(object sender, RoutedEventArgs e)
        {
            /*Проверяем есть ли в таблице запись*/
            if (CityVM.CheckCity(id))
            {
                var item = new City
                {
                    Id = id
                };
                var context = new DatingServiceModel();
                context.Cities.Attach(item);
                context.Cities.Remove(item);
                context.SaveChanges();

                MessageBox.Show("City deleted");
            }
            else
            {
                MessageBox.Show("City is empty");
            }
          
            
        }

        /*Кнопка delete education*/
        private void deleteEducation_Click(object sender, RoutedEventArgs e)
        {
            /*Проверяем есть ли в таблице запись*/
            if (EducationVM.CheckEducation(id))
            {
                var item = new Education
                {
                    Id = id
                };
                var context = new DatingServiceModel();
                context.Educations.Attach(item);
                context.Educations.Remove(item);
                context.SaveChanges();

                MessageBox.Show("Education deleted");
            }
            else
            {
                MessageBox.Show("Education is empty!");
            }
        }
    }
}
