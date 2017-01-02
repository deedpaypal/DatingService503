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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DatingService2.Model;
using DatingService2.Model.Tables;
using DatingService2.ViewModel;

namespace DatingService2
{

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();
           
        }

        private void regbutton_Click(object sender, RoutedEventArgs e)
        {
     
            Registration reg = new Registration();
            reg.Show();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            /*Аутентификация*/
             if (UserPersonVM.ConfirmUser(loginBox.Text, passwordBox.Password))
             {
                 this.Hide();
                 Profile profile = new Profile();
                 profile.Show();

                /*Записываем айдишник в глобальную переменную*/
                 Application.Current.Properties["Id"] = UserPersonVM.CheckUserId(loginBox.Text).ToString();
                
            

            }
             else
             {
                 MessageBox.Show("Incorrect!!");

             }
            
        }

    }
}
