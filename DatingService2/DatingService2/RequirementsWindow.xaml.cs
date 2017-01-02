using System;
using System.Collections.Generic;
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
using DatingService2.ViewModel;

namespace DatingService2
{
    /// <summary>
    /// Логика взаимодействия для Requirements.xaml
    /// </summary>
    public partial class RequirementsWindow : Window
    {
        public RequirementsWindow()
        {
            InitializeComponent();
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void doneReq_Click(object sender, RoutedEventArgs e)
        {
            /*Достаем айдишник пользователя*/
            int id = Convert.ToInt32(Application.Current.Properties["Id"]);

            /*Достаем параметр радио*/
            var sex = (Male.IsChecked == true) ? Male.Content.ToString() : Female.Content.ToString();
            /*Создаем объект prequierement, куда заисываем всю инфу*/
            PRequirement preq = new PRequirement(sex, Convert.ToInt32(ageFrom.Text)
                , Convert.ToInt32(ageAbove.Text), requirementsCity.Text, requirementsEduc.Text);

            /*Если запись требований уже существует в базе данных, обновляем и пишем новую*/
            if (RequirementsVM.CheckRequirements(id))
            {
                SqlParameter idParameter = new SqlParameter("@id", id);
                SqlParameter partnerSexParameter = new SqlParameter("@partnersex", preq.Sex);
                SqlParameter partnerCityParameter = new SqlParameter("@partnercity", preq.City);
                SqlParameter ageFromParameter = new SqlParameter("@agefrom", preq.AgeFrom);
                SqlParameter ageAboveParameter = new SqlParameter("@ageabove", preq.AgeAbove);
                SqlParameter partnerEducationParameter = new SqlParameter("@partnereducation", preq.Education);

                var context = new DatingServiceModel();
                /*Это хранимая процедура dbo.Requirements_Update*/
                context.Database.ExecuteSqlCommand("EXEC dbo.Requirements_Update @id, @agefrom, @ageabove, @partnercity,  @partnereducation, @partnersex",
                
                    idParameter,
                    ageFromParameter,
                    ageAboveParameter,
                    partnerCityParameter,
                    partnerEducationParameter,
                    partnerSexParameter
                    );

                context.SaveChanges();
                MessageBox.Show("Information changed.");
            }
            else
            {
                /*Добавление записи требований*/
                RequirementsVM.AddRequirments(preq, id);
                MessageBox.Show("Added.");
            }

        }
    }
}
