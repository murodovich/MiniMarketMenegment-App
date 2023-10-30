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
  
    public partial class Selling_Forms : Window
    {

        DateTime datetime = DateTime.Now;


        NpgsqlConnection sqlConnection = new NpgsqlConnection("Server = localhost; Port=5432; User Id = postgres; Password=7788;Database=Project1;");
        public Selling_Forms()
        {
            InitializeComponent();
            LoadGrid();
            GetTable();
            LoadGrid_selling();
            Date_time.Content = $"Date: {datetime}";
        }

        public void ClearData()
        {
            ID_text.Clear();
            Price_text.Clear();

        }
        public void LoadGrid()
        {
            ProjectDB db = new ProjectDB();
            List<Product> Products = db.products.Select(p => new Product
            {
                ProdId = p.ProdId,
                Name = p.Name,
                Price = p.Price,
                Quantity = p.Quantity,
                ProdCat = p.ProdCat



            }).ToList();
            datagrid_selling.ItemsSource = Products;
            ClearData();






        }

        public void LoadGrid_selling()
        {
            ProjectDB db = new ProjectDB();
            List<Sellings_product> Sellings = db.selings_products.Select(s => new Sellings_product
            {
                prodID = s.prodID,
                ProdName = s.ProdName,
                ProdPrice = s.ProdPrice,
                ProdQty = s.ProdQty,
                Total = s.Total,

            }).ToList();
            datagrid.ItemsSource = Sellings;
            ClearData();
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
                    category_Combobox.Items.Add(name);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Xatolik yuz berdi: " + ex.Message);
            }
        }

        private void Update_btn_Copy_Click(object sender, RoutedEventArgs e)
        {
            ProjectDB db = new ProjectDB();
            var AllProducts = db.selings_products.ToList();
            db.selings_products.RemoveRange(AllProducts);

        }

        private void category_Combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetTable();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow product_Window = new MainWindow();
            product_Window.Show();
            Hide();
        }

        private void Add_btn_Click(object sender, RoutedEventArgs e)
        {


            try
            {
                if (string.IsNullOrEmpty(Price_text.Text))
                {
                    MessageBox.Show("Malumotlar to'liq kiritilmagan tekshirib\n qaytadan kiriting !");
                    ClearData();
                }
                else
                {
                    ProjectDB db = new ProjectDB();

                    Sellings_product product = new Sellings_product();
                    var product1 = db.products.FirstOrDefault(p => p.ProdId == int.Parse(ID_text.Text));
                    if (product1 != null)
                    {
                        product.ProdPrice = int.Parse(Price_text.Text);
                        product.ProdQty = product1.Quantity;
                        product.ProdName = product1.Name;
                        product.Total = (int.Parse(Price_text.Text) * product1.Quantity);


                    }


                    db.Add(product);
                    db.SaveChanges();
                    List<Sellings_product> Products = db.selings_products.Select(p => new Sellings_product
                    {
                        prodID = p.prodID,
                        ProdName = p.ProdName,
                        ProdPrice = p.ProdPrice,
                        ProdQty = p.ProdQty,
                        Total = p.Total
                    }).ToList();
                    datagrid.ItemsSource = Products;
                    LoadGrid_selling();
                    ClearData();




                    var sums = db.selings_products.Select(x => x.Total).ToList();
                    int jami = 0;
                    foreach (var s in sums)
                    {
                        jami = jami + s;

                    }
                    Sum_label.Content = $"{jami} SUM";



                    MessageBox.Show("Selling Product Added Successfully");

                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }





        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ProjectDB db = new ProjectDB();
            var cat = db.products.Where(x => x.ProdCat == category_Combobox.Text).ToList();
            datagrid_selling.ItemsSource = cat;

            Product product = new Product();


            


        }

        private void ID_text_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
