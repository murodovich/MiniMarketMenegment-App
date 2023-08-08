using Npgsql;
using ProjectTWO.ServiceLayer.Model;
using sinup.ServiceLayer.Data;
using System;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ProjectTWO.Windowss
{
    /// <summary>
    /// Interaction logic for Category.xaml
    /// </summary>
    public partial class Category : Window
    {

        NpgsqlConnection sqlConnection = new NpgsqlConnection("Server = localhost; Port=5432; User Id = postgres; Password=7788;Database=Project1;");

        public Category()
        {
            InitializeComponent();
            LoadGrid();
        }

        public void clearData()
        {
            Id_text.Clear();
            CatName_textbox.Clear();
            Des_textbox.Clear();

        }
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ProjectDB db = new ProjectDB();
            Categoryes category = new Categoryes();
            try
            {
                if (string.IsNullOrEmpty(CatName_textbox.Text) || string.IsNullOrEmpty(Des_textbox.Text))
                {
                    Category_Label.Content = "Malumotlar to'liq kiritilmagan tekshirib\n qaytadan kiriting !";
                }
                else
                {

                    category.Name = $"{CatName_textbox.Text}";
                    category.Description = $"{Des_textbox.Text}";
                    db.Add(category);
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
        ProjectDB db = new ProjectDB();
        public void LoadGrid()
        {

            NpgsqlCommand cmd = new NpgsqlCommand("Select * from categories", sqlConnection);
            DataTable dt = new DataTable();
            sqlConnection.Open();
            NpgsqlDataReader npgsqlDataReader = cmd.ExecuteReader();
            dt.Load(npgsqlDataReader);
            sqlConnection.Close();
            datagrid1.ItemsSource = dt.DefaultView;
            clearData();





        }

        private void CatID_text_TextChanged(object sender, TextChangedEventArgs e)
        {


        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Hide();
            Product_Window product_Window = new Product_Window();
            product_Window.Show();

        }

        private void Id_text_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Update_btn_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(CatName_textbox.Text) || string.IsNullOrEmpty(Des_textbox.Text) || string.IsNullOrEmpty(Id_text.Text))
                {
                    MessageBox.Show("The information is incomplete, please recheck and enter the information");
                    clearData();

                }
                else
                {

                    ProjectDB db = new ProjectDB();
                    var updates = db.categories.FirstOrDefault(x => x.CategoryId == int.Parse(Id_text.Text));

                    if (updates != null)
                    {
                        updates.Name = CatName_textbox.Text;
                        updates.Description = Des_textbox.Text;
                        db.SaveChanges();
                    }



                    MessageBox.Show("Record has been Update Successfully", "Update", MessageBoxButton.OK, MessageBoxImage.Information);
                    clearData();
                    LoadGrid();

                }



            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {

                clearData();
                LoadGrid();
            }

        }

        private void Delete_btn_Click_1(object sender, RoutedEventArgs e)
        {
            ProjectDB projectDB = new ProjectDB();


            try
            {
                if (string.IsNullOrEmpty(Id_text.Text)) 
                {
                    MessageBox.Show("\r\nPlease enter another id that corresponds to the entered id");
                }
                else
                {
                    ProjectDB db = new ProjectDB();
                    var objForRemove = db.categories.FirstOrDefault(x => x.CategoryId == int.Parse(Id_text.Text));
                    db.categories.Remove(objForRemove);
                    db.SaveChanges();
                    MessageBox.Show("Record has been deleted !", "Deleted", MessageBoxButton.OK, MessageBoxImage.Information);
                    clearData();
                    LoadGrid();


                }




            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show("Not Deleted!" + ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Product_Window product_Window = new Product_Window();
            product_Window.Show();
            Hide();

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Selling_Forms selling_Forms = new Selling_Forms();
            selling_Forms.Show();
            Hide();
        }
    }
}
