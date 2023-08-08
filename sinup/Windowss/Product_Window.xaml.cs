using Microsoft.EntityFrameworkCore;
using Npgsql;

using ProjectTWO.ServiceLayer.Model;
using sinup;
using sinup.ServiceLayer.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ProjectTWO.Windowss
{
    /// <summary>
    /// Interaction logic for Product_Window.xaml
    /// </summary>
    public partial class Product_Window : Window
    {

        NpgsqlConnection sqlConnection = new NpgsqlConnection("Server = localhost; Port=5432; User Id = postgres; Password=7788;Database=Project1;");
        public Product_Window()
        {
            InitializeComponent();
            LoadGrid();
            GetTable();


        }

        public void LoadGrid()
        {

            NpgsqlCommand cmd = new NpgsqlCommand("Select * from products", sqlConnection);
            DataTable dt = new DataTable();
            sqlConnection.Open();
            NpgsqlDataReader npgsqlDataReader = cmd.ExecuteReader();
            dt.Load(npgsqlDataReader);
            sqlConnection.Close();
            datagrid.ItemsSource = dt.DefaultView;
            ClearData();





        }

        public void ClearData()
        {
            ID_text.Clear();
            Name1_textbox.Clear();
            Price_textbox.Clear();
            Quantity_textbox.Clear();
                

        }

      

        private void GetTable()
        {
            

            try
            {
                var db = new ProjectDB();
                var names = db.categories
                    .Select(c => $"{c.Name}")
                    .ToList();
                foreach (var name in names)
                {
                    Category_text.Items.Add(name);
                    Category_text1 .Items.Add(name);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Xatolik yuz berdi: " + ex.Message);
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Hide();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
       
        private void Add_btn_click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (string.IsNullOrEmpty(Name1_textbox.Text) || string.IsNullOrEmpty(Price_textbox.Text) || string.IsNullOrEmpty(Quantity_textbox.Text))
                { 
                    MessageBox.Show("Malumotlar to'liq kiritilmagan tekshirib\n qaytadan kiriting !");
                    ClearData();
                }
                else
                {
                    ProjectDB db = new ProjectDB();
                    Product product = new Product();
                    var cat = db.categories.FirstOrDefault(c => c.Name == Category_text1.Text);
                 
                    product.Name = Name1_textbox.Text;
                    product.Price = int.Parse(Price_textbox.Text);
                    product.Quantity = int.Parse(Quantity_textbox.Text);
                    product.ProdCat = Category_text.Text;

                    db.Add(product);
                    db.SaveChanges();
                    LoadGrid();
                    MessageBox.Show("Category Added Successfully");



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Hide();
            Category category = new Category();
            category.Show();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            ClearData();


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
                    var objForRemove = db.products.FirstOrDefault(x => x.ProdId == int.Parse(ID_text.Text));
                    db.products.Remove(objForRemove);
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

        private void Id_delete_txt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Update_btn_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                if(string.IsNullOrEmpty(ID_text.Text) || string.IsNullOrEmpty(Name1_textbox.Text)|| string.IsNullOrEmpty(Price_textbox.Text) || string.IsNullOrEmpty(Quantity_textbox.Text))
                {
                    MessageBox.Show("You have not entered enough information to update!\r\n");
                   

                }
                else 
                {

                    ProjectDB db = new ProjectDB();
                    var updates = db.products.FirstOrDefault(x => x.ProdId == int.Parse(ID_text.Text));

                    if (updates != null)
                    {
                        updates.Name = Name1_textbox.Text;
                        updates.Price = int.Parse(Price_textbox.Text);
                        updates.Quantity = int.Parse(Quantity_textbox.Text);

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

        private void Category_text_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetTable();
        }

        private void Category_text1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Seller_Form seller_Form = new Seller_Form();
            seller_Form.Show();
            Hide();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            Hide();
            Selling_Forms selling_Forms = new Selling_Forms();
            selling_Forms.Show();
            selling_Forms.Seller_name.Content = $"Seller Name {mainWindow.username_text1.Text}";
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Selling_Forms selling_Forms  = new Selling_Forms();
            selling_Forms.Show();
            Hide();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            ProjectDB db = new ProjectDB();
            var cat = db.products.Where(x => x.ProdCat == Category_text1.Text).ToList();
            datagrid.ItemsSource = cat;
        }
    }
}
