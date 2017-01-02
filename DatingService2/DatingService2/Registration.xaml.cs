using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DatingService2.Model;
using DatingService2.Model.Tables;
using DatingService2.ViewModel;

namespace DatingService2
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

   



        private void button_Click(object sender, RoutedEventArgs e)
        {

            /*Достаем параметр радио*/
            var sex = (Male.IsChecked == true) ? Male.Content.ToString() : Female.Content.ToString();
            /*Проверяем есть ли пользователь с таким именем*/
            if (UserPersonVM.CheckUserName(usernameBox.Text))
                {
                    MessageBox.Show("This user is already exist!");
                } 
/*проверяем пустые поля*/
                else if (((usernameBox!= null)&&!string.IsNullOrWhiteSpace(usernameBox.Text)) 
                        && ((passwordBox.Password != null)&&!string.IsNullOrWhiteSpace(passwordBox.Password))
                        && ((firstNameBox.Text != null)&&!string.IsNullOrWhiteSpace(firstNameBox.Text))
                        && ((lastNameBox.Text != null)&&!string.IsNullOrWhiteSpace(lastNameBox.Text))
                         && ((DatePicker != null) && !string.IsNullOrWhiteSpace(DatePicker.Text)) && !UserPersonVM.CheckBirthday(DateTime.Parse(DatePicker.Text)))
                {
                    try
                    {
                        using (var context = new DatingServiceModel())
                        {
                            var user = new User()
                            {
                                username = usernameBox.Text,
                                userPassword = passwordBox.Password
                            };

                            var person = new Person()
                            {
                                FirstName = firstNameBox.Text,
                                LastName = lastNameBox.Text,
                                Sex = sex,
                                Birthday = DateTime.Parse(DatePicker.Text)
                            };
/*каскадное добавление */
                            user.Person = person;
                            context.Users.Add(user);
                            context.SaveChanges();
                            MessageBox.Show("Yeah!");
                        }
                    }
                    catch (DbEntityValidationException exception)
                    {
                        foreach (var eve in exception.EntityValidationErrors)
                        {
                            Console.WriteLine(
                                "Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
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
            else if (UserPersonVM.CheckBirthday(DateTime.Parse(DatePicker.Text)))
            {
                MessageBox.Show("Birthday is not correct");
            }
                else
                {
                    MessageBox.Show("Please, input full inf!");
                }
            }
           
        }

        
    }
