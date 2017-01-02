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
    /// Логика взаимодействия для OtherInformationWindow.xaml
    /// </summary>
    public partial class OtherInformationWindow : Window
    {
        public OtherInformationWindow()
        {
            InitializeComponent();
        }

        private void otherInfButton_Click(object sender, RoutedEventArgs e)
        {

            int id = Convert.ToInt32(Application.Current.Properties["Id"]);

            PCity pc = new PCity(id, citytextBox.Text);
            PEducation pEducation = new PEducation(id, educationtextBox.Text);

            var context = new DatingServiceModel();

            if (CityVM.CheckCity(id) && EducationVM.CheckEducation(id))
            {
                SqlParameter idParameterCity = new SqlParameter("@id", pc.Id);
                SqlParameter personCityParameter = new SqlParameter("@personcity", pc.PersonCity);

                /*Это хранимая процедура dbo.City_Update*/
                context.Database.ExecuteSqlCommand("EXEC dbo.City_Update @id, @personcity", idParameterCity, personCityParameter);

                SqlParameter idParameterEd = new SqlParameter("@id", pEducation.Id);
                SqlParameter personEducationParameter = new SqlParameter("@personeducation", pEducation.PersonEducation);



                MessageBox.Show("Changed.");
            }
            else if(!CityVM.CheckCity(id) && EducationVM.CheckEducation(id))
            {
                CityVM.AddPersonCity(new PCity(id, citytextBox.Text));

                SqlParameter idParameterEd = new SqlParameter("@id", pEducation.Id);
                SqlParameter personEducationParameter = new SqlParameter("@personeducation", pEducation.PersonEducation);

                /*Это хранимая процедура dbo.Education_Update*/
                context.Database.ExecuteSqlCommand("EXEC dbo.Education_Update @id, @personeducation", idParameterEd, personEducationParameter);

                MessageBox.Show("City added. Education changed.");
            }else if (CityVM.CheckCity(id) && !EducationVM.CheckEducation(id))
            {
                SqlParameter idParameterCity = new SqlParameter("@id", pc.Id);
                SqlParameter personCityParameter = new SqlParameter("@personcity", pc.PersonCity);

                /*Это хранимая процедура dbo.City_Update*/
                context.Database.ExecuteSqlCommand("EXEC dbo.City_Update @id, @personcity", idParameterCity, personCityParameter);

                EducationVM.AddPersonEducation(new PEducation(id, educationtextBox.Text));
                MessageBox.Show("Education added. City changed");
            }
            else
            {
                CityVM.AddPersonCity(new PCity(id, citytextBox.Text));
                EducationVM.AddPersonEducation(new PEducation(id, educationtextBox.Text));
                MessageBox.Show("Added");
            }
        }
    }
}
