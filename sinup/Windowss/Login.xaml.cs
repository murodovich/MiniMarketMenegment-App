using sinup.ServiceLayer.Data;
using sinup.ServiceLayer.User;
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

namespace sinup
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
                
          

            ProjectDB projectDB = new ProjectDB();
            ServiceModel model = new ServiceModel();
            if (string.IsNullOrEmpty(username_text.Text) || string.IsNullOrEmpty(lastname_text.Text) || string.IsNullOrEmpty(username_text.Text) || string.IsNullOrEmpty(password_text.Password) || string.IsNullOrEmpty(phone_text.Text) )
            { 
                Registr_eror_label.Content = "Malumotlar to'liq kiritilmagan tekshirib\n qaytadan kiriting !";
            }
            else        
            {
                model.FirstName = $"{firstname_text.Text}";
                model.LastName = $"{lastname_text.Text}";
                model.UserName = $"{username_text.Text}";
                model.Password = $"{password_text.Password  }";
                model.Phone = $"{phone_text.Text}";
                projectDB.Add(model);   
                projectDB.SaveChanges();

                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Hide();

            }

        }

        private void Firstname_Text(object sender, TextChangedEventArgs e) 
        {
            

        }

        private void Lastname_text(object sender, TextChangedEventArgs e)
        {

        }

        private void Username_text(object sender, TextChangedEventArgs e)
        {

        }

        private void Password_text(object sender, TextChangedEventArgs e)
        {

        }

        private void Phone_text(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Hide();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
