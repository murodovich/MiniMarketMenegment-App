using sinup;
using sinup.ServiceLayer.Data;
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

namespace ProjectTWO.Windowss
{
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void Registr_btn_Click(object sender, RoutedEventArgs e)
        {
            ProjectDB projectDB = new ProjectDB();
                if (!projectDB.serviceModels.Any(x => x.UserName.Equals(username_text1.Text) && x.Password.Equals(password_text1.Password)))
                {
                    MessageBox.Show("Username yoki Password noto'g'ri kitildi !");
                }
                else
                {
                    Hide();
                    Login window = new Login();
                    window.Show();
                }
            
        }

        private void Login_btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Hide();
        }
    }
}
