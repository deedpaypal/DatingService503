using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
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
using DatingService2.Model.Entities;
using DatingService2.Model.Tables;
using DatingService2.ViewModel;

namespace DatingService2
{
    /// <summary>
    /// Логика взаимодействия для Profile.xaml
    /// </summary>
    public partial class Profile : Window
    {
        public Profile()
        {
            
            InitializeComponent();
            

        }

        /*Добавление в таблицу PrivateInf*/
        private void otherInformationButton_Click(object sender, RoutedEventArgs e)
        {
            /*Достаем id пользователя*/
            int id = Convert.ToInt32(Application.Current.Properties["Id"]);

            var context = new DatingServiceModel();
            /*создаем объект, содержащий информацию с полей*/
            UserPrivateInf upi = new UserPrivateInf(Convert.ToDecimal(height.Text), Convert.ToDecimal(weight.Text), phone.Text);
            /*Проверяем, существует ли запись в таблице PrivateInf с таким id*/
            if (PrivateInfVM.CheckPrivateInf(id))
            {
                if (PrivateInfVM.CheckPhone(phone.Text))
                {
                    SqlParameter idParameter = new SqlParameter("@id", id);
                    SqlParameter heigtParameter = new SqlParameter("@height", upi.Height);
                    SqlParameter weightParameter = new SqlParameter("@weight", upi.Weight);
                    SqlParameter phoneParameter = new SqlParameter("@phone", upi.Phone);

                    /*Это хранимая процедура dbo.PrivateInf_Update*/
                    context.Database.ExecuteSqlCommand("EXEC dbo.PrivateInf_Update @id, @height, @weight, @phone",
                        idParameter,
                        heigtParameter,
                        weightParameter,
                        phoneParameter
                    );
                    context.SaveChanges();
                    MessageBox.Show("Information changed.");
                }
                else
                {
                    MessageBox.Show("Phone is not correct");
                }

            }
            else
            {
                if (PrivateInfVM.CheckPhone(phone.Text))
                {

                    PrivateInfVM.AddPrivateInf(upi, id);
                    MessageBox.Show("Added.");
                }
                else
                {
                    MessageBox.Show("Phone is not correct");
                }
            }
          }

        private void personRequirements_Click(object sender, RoutedEventArgs e)
        {
          
            new RequirementsWindow().Show();

        }

        private void personOtherInformation_Click(object sender, RoutedEventArgs e)
        {
        
            new OtherInformationWindow().Show();
        }

        private void editOtherInformation_Click(object sender, RoutedEventArgs e)
        {
            new EditInformation().Show();
        }
    }
}
