using Microsoft.EntityFrameworkCore;
using ProjectTWO.Windowss;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace sinup
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Login_btn_Click(object sender, RoutedEventArgs e)
        {
            ProjectDB projectDB = new ProjectDB();
            if(Combobox_login.Text == "Admin") 
            {
                if (!projectDB.serviceModels.Any(x => x.UserName.Equals(username_text1.Text) && x.Password.Equals(password_text1.Password)))
                {
                    MessageBox.Show("Username yoki Password noto'g'ri kitildi !");
                }
                else
                {
                    Hide();
                    Product_Window window = new Product_Window();
                    window.Show();
                }
            }else if(Combobox_login.Text == "Sellar")
            {
                if (!projectDB.sellers.Any(x => x.Name.Equals(username_text1.Text) && x.Password.Equals(password_text1.Password)))
                {
                   MessageBox.Show("Username yoki Password noto'g'ri kitildi !");
                }
                else
                {
                    Hide();
                    Selling_Forms form = new Selling_Forms();
                    form.Seller_name.Content = $"Seller Name {username_text1.Text} ";
                    form.Show();
                }

            }
            else if(Combobox_login.Text == null)
            {
                MessageBox.Show("There is no such seller or admin in the database");
            }
            
            
        }

        private void Registr_btn_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            Admin login = new Admin();
            login.Show();
        }

        private void Username_text(object sender, TextChangedEventArgs e)
        {
            


        }

        private void Password_text(object sender, TextChangedEventArgs e)
        {

        }

        private void TabControl_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
