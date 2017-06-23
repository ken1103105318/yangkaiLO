using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ykl1103105318.Repository
{
    public class LocationRepository
    {
        private const string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Desktop\yangkaiLO-master\ykl1103105318-2\yk1103105318-2\App_Data\LocationDB.mdf;Integrated Security=True";
        public void Create(List<Models.Location> locations)
        {
            var connection = new System.Data.SqlClient.SqlConnection();
            connection.ConnectionString = _connectionString;
            connection.Open();
            foreach (var location in locations)
            {
                var command = new System.Data.SqlClient.SqlCommand("", connection);
                command.CommandText = string.Format(@"
INSERT          INTO    Location(欄位1, 欄位2, 欄位3)
VALUES          (N'{0}',N'{1}',N'{2}')
", location.欄位1, location.欄位2, location.欄位3);
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
        public List<Models.Location> FindAllStations()
        {
            var result = new List<Models.Location>();
            var connection = new System.Data.SqlClient.SqlConnection(_connectionString);
            connection.ConnectionString = _connectionString;
            connection.Open();
            var command = new System.Data.SqlClient.SqlCommand("", connection);
            command.CommandText = @"
Select * from Location";
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Models.Location item = new Models.Location();
                item.欄位1 = reader["欄位1"].ToString();
                item.欄位2 = reader["欄位2"].ToString();
                item.欄位3 = reader["欄位3"].ToString();               
                result.Add(item);
            }
            connection.Close();
            return result;
        }
    }
}
