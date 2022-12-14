using Provider.dto;
using System.Data.SqlClient;

namespace Provider
{
    public class ProviderSQL
    {
        private const string _conectionString = "Server=localhost\\sqlexpress;Database=lanit_HW3DB;Trusted_Connection=True";
        public void Create(Farm_Name farm)
        {
            SqlConnection connection = new SqlConnection(_conectionString);
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand($"INSERT INTO [ProductDB].[dbo].[Farm_Name] (ID, Name, Grou, VendorCode) VALUES ({farm.Id}, '{farm.Name}','{farm.Group}', {farm.VendorCode})", connection);
            sqlCommand.ExecuteNonQuery();
            sqlCommand.Dispose();
            connection.Close();
        }

        public void Read(string parametr1, string parametr2)
        {
            SqlConnection connection = new SqlConnection(_conectionString);
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand($"SELECT * FROM[ProductDB].[dbo].[Farm_Name] Where {parametr1} = {parametr2}", connection);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            bool control = false;
            while (reader.Read())
            {
                Console.WriteLine($"ID: {reader.GetValue(0)} \nVendorCode: {reader.GetValue(1)} \nGroup: {reader.GetValue(2)} \nName: {reader.GetValue(3)}");
                control = true;
            }
            if (control == false)
            {
                Console.WriteLine("Данные не найдены");
            }
            sqlCommand.Dispose();
            connection.Close();
        }
        public void Update(string parametr11, string parametr12, string parametr21, string parametr22)
        {
            SqlConnection connection = new SqlConnection(_conectionString);
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand($"UPDATE [ProductDB].[dbo].[Farm_Name] SET {parametr21} = {parametr22} Where {parametr11} = {parametr12}", connection);
            sqlCommand.ExecuteNonQuery();
            sqlCommand.Dispose();
            connection.Close();
        }
        public void Delete(int id)
        {
            SqlConnection connection = new SqlConnection(_conectionString);
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand($"DELETE FROM[ProductDB].[dbo].[Farm_Name] Where ID = {id}", connection);
            sqlCommand.ExecuteNonQuery();
            sqlCommand.Dispose();
            connection.Close();
        }
    }
}