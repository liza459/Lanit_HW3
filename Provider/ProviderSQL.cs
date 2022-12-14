using Provider.dto;
using System.Data.SqlClient;
using Color;

namespace Provider
{
    public class ProviderSQL
    {
        readonly ColorCw color = new();
        private const string _conectionString = "Server=localhost\\sqlexpress;Database=lanit_HW3DB;Trusted_Connection=True";
        SqlConnection connection1 = new SqlConnection(_conectionString);
        public void Create(Workers worker)
        {
            SqlConnection connection = new SqlConnection(_conectionString);
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand($"INSERT INTO [lanit_HW3DB].[dbo].[Workers] ( ID,Name,Last_Name,Number_branch) " +
                $"VALUES ('{worker.ID}', '{worker.Name}', '{worker.Last_name}', '{worker.Number_Branch}')", connection);
            sqlCommand.ExecuteNonQuery();
            sqlCommand.Dispose();
            connection.Close();
        }

        public void Read1N(int number)
        {
            SqlConnection connection = new SqlConnection(_conectionString);
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand($"SELECT Workers.ID, Workers.Name, Workers.Last_Name,Workers.Number_branch,Branchs.Name_branch,Branchs.Addres " +
                $"FROM[lanit_HW3DB].[dbo].[Workers] JOIN Branchs ON Workers.Number_branch = Branchs.Number  Where Workers.Number_branch = '{number}'", connection);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            bool control = false;
            color.Green("ID\t\tName\t\tLast Name\t\tNumber branch\t\tName branch\t\tAddres\n");
            while (reader.Read())
            {
                color.Green($"{reader.GetValue(0)}\t\t{reader.GetValue(1)}\t\t{reader.GetValue(2)}\t\t\t{reader.GetValue(3)}\t\t\t{reader.GetValue(4)}\t\t{reader.GetValue(5)}\n");
                control = true;
            }
            if (control == false)
            {
                color.Red("Данные не найдены\n");
            }
            sqlCommand.Dispose();
            connection.Close();
        }

        public void ReadNN()
        {
            SqlConnection connection = new SqlConnection(_conectionString);
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand($"SELECT Workers.ID, Workers.Name, Workers.Last_Name, Achivements.Name_achivements " +
                $"FROM[lanit_HW3DB].[dbo].[Workers] JOIN Workers_achivements ON Workers.ID = Workers_achivements.ID_workers JOIN  Achivements " +
                $"ON Workers_achivements.ID_achivements = Achivements.ID_achivements ORDER BY ID", connection);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            bool control = false;
            color.Green("ID\t\tName\t\tLast Name\t\tName achievements\n");
            object workersID = 0;
            while (reader.Read())
            {
                //object workersID1 = reader.GetValue(0);
                if (Equals(workersID, reader.GetValue(0))) 
                {
                    color.Green($"\t\t\t\t\t\t\t{reader.GetValue(3)}\n");
                }
                else
                {
                    color.Green($"{reader.GetValue(0)}\t\t{reader.GetValue(1)}\t\t{reader.GetValue(2)}\t\t\t{reader.GetValue(3)}\n");
                }

                workersID = reader.GetValue(0);
                control = true;
            }
            if (control == false)
            {
                color.Red("Данные не найдены\n");
            }
            sqlCommand.Dispose();
            connection.Close();
        }
        public void Update(int ID,int Number_Branch)
        {
            SqlConnection connection = new SqlConnection(_conectionString);
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand($"UPDATE [lanit_HW3DB].[dbo].[Workers] SET Number_Branch = '{Number_Branch}'" +
                $"Where ID = '{ID}'", connection);
            sqlCommand.ExecuteNonQuery();
            sqlCommand.Dispose();
            connection.Close();
        }
        public void Delete(int id)
        {
            SqlConnection connection = new SqlConnection(_conectionString);
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand($"DELETE FROM[lanit_HW3DB].[dbo].[Workers] Where ID = {id}", connection);
            sqlCommand.ExecuteNonQuery();
            sqlCommand.Dispose();
            connection.Close();
        }
    }
}