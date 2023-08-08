using Npgsql;
using ProjectTWO.ServiceLayer.Model;
using sinup;
using sinup.ServiceLayer.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
    /// Interaction logic for Seller_Form.xaml
    /// </summary>
    public partial class Seller_Form : Window
    {
        NpgsqlConnection sqlConnection = new NpgsqlConnection("Server = localhost; Port=5432; User Id = postgres; Password=7788;Database=Project1;");
        public Seller_Form()
        {
            InitializeComponent();
            LoadGrid();
        }   

        public void ClearData()
        {
            ID_text.Clear();
            Name1_textbox.Clear();
            Age_text.Clear();
            Phone_text.Clear();
            Password_Box.Clear();
        }

        public void LoadGrid()
        {
            NpgsqlCommand cmd = new NpgsqlCommand("Select * from sellers", sqlConnection);
            DataTable dt = new DataTable();
            sqlConnection.Open();
            NpgsqlDataReader npgsqlDataReader = cmd.ExecuteReader();
            dt.Load(npgsqlDataReader);
            sqlConnection.Close();
            datagrid.ItemsSource = dt.DefaultView;
            ClearData();
        }
        private void Logout_btn_Click(object sender, RoutedEventArgs e)
        {
            Logout_btn.Background = Brushes.Red;
            Product_Window product_Window = new Product_Window();
            product_Window.Show();
            Hide();
        }

        

        private void Product_btn_Click(object sender, RoutedEventArgs e)
        {
            Product_Window product_Window
                = new Product_Window();
            product_Window.Show();
            Hide();
        }

        private void Category_btn_Click(object sender, RoutedEventArgs e)
        {
            Category category = new Category();
            category.Show();
            Hide();
        }

        private void Add_btn_Click(object sender, RoutedEventArgs e)
        {
            ProjectDB projectDB = new ProjectDB();

            try
            {
                if (string.IsNullOrEmpty(Name1_textbox.Text) || string.IsNullOrEmpty(Age_text.Text) || string.IsNullOrEmpty(Phone_text.Text) || string.IsNullOrEmpty(Password_Box.Password))
                {
                    MessageBox.Show("Malumotlar to'liq kiritilmagan tekshirib\n qaytadan kiriting !");
                    ClearData();
                }
                else
                {
                    ProjectDB db = new ProjectDB();
                    Sellers seller = new Sellers();
                    seller.Name = Name1_textbox.Text;
                    seller.Age =  int.Parse(Age_text.Text);
                    seller.Phone = Phone_text.Text;
                    seller.Password = Password_Box.Password;
                    db.Add(seller);
                    db.SaveChanges();
                    LoadGrid();
                    MessageBox.Show("Seller Added Successfully");



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Update_btn_Click(object sender, RoutedEventArgs e)
        {
            ProjectDB db = new ProjectDB();
            try
            {
                if (string.IsNullOrEmpty(ID_text.Text) || string.IsNullOrEmpty(Name1_textbox.Text) || string.IsNullOrEmpty(Age_text.Text) || string.IsNullOrEmpty(Phone_text.Text) || string.IsNullOrEmpty(Password_Box.Password))
                {
                    MessageBox.Show("You have not entered enough information to update!\r\n");


                }
                else
                {

                    Sellers sellers = new Sellers();
                    var updates = db.sellers.FirstOrDefault(x => x.SellerId == int.Parse(ID_text.Text));

                    if (updates != null)
                    {
                        updates.Name = Name1_textbox.Text;
                        updates.Age = int.Parse(Age_text.Text);
                        updates.Phone = Phone_text.Text;
                        updates.Password = Password_Box.Password;
                        db.SaveChanges();
                    }



                    MessageBox.Show("Record has been Update Successfully", "Update", MessageBoxButton.OK, MessageBoxImage.Information);
                    ClearData();
                    LoadGrid();
                }






            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {

                ClearData();
                LoadGrid();
            }
        }

        private void Delete_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(ID_text.Text))
                {

                    MessageBox.Show("\r\nNo reference was found matching the entered Id");
                }
                else
                {
                    ProjectDB db = new ProjectDB();
                    Sellers sellers = new Sellers();
                    var objForRemove = db.sellers.FirstOrDefault(x => x.SellerId == int.Parse(ID_text.Text));
                    db.sellers.Remove(objForRemove);
                    db.SaveChanges();
                    MessageBox.Show("Record has been deleted !", "Deleted", MessageBoxButton.OK, MessageBoxImage.Information);
                    ClearData();
                    LoadGrid();
                }



            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show("Not Deleted!" + ex.Message);
            }
        }

        private void Clear_data_btn_Click(object sender, RoutedEventArgs e)
        {
            ClearData();
            LoadGrid();
        }

        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
             
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Selling_Forms selling_Forms = new Selling_Forms();
            selling_Forms.Show();
            Hide();
        }
    }
}
