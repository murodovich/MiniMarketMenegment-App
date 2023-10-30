using sinup;
using sinup.ServiceLayer.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

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

        private void username_text1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
