using Npgsql;
using ProjectTWO.Windowss;
using System;
using System.Collections.Generic;
using System.Windows;

namespace ProjectTWO.Iservice_Func
{
    public class GetComboBox : Product_Window
    {


        // Bazadan ma'lumotlarni olish va ComboBoxga joylash funksiyasi
        private void PopulateComboBoxFromDatabase()
        {
            string connectionString = "Host=YOUR_HOST;Username=YOUR_USERNAME;Password=YOUR_PASSWORD;Database=YOUR_DATABASE"; // PostgreSQL ulanish uchun ConnectionString
            string query = "SELECT YourColumnName FROM YourTableName"; // Malumotlarni olish uchun so'rov

            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            List<string> data = new List<string>();

                            while (reader.Read())
                            {
                                // "YourColumnName" - o'rniga sizning ustun nomingizni yozing, malumotni o'qish uchun shu ustun nomi bilan almashtiring
                                string item = reader.GetString(0); // 0 - "YourColumnName" ustun indeksi
                                data.Add(item);
                            }

                            Category_text.Items.Clear(); // ComboBoxni tozalash
                            Category_text.Items.Add(data.ToArray()); // ComboBoxga ma'lumotlarni qo'shish
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xatolik yuz berdi: " + ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PopulateComboBoxFromDatabase();
        }
    }

}

