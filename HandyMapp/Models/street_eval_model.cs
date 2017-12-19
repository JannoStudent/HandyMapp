using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace HandyMapp.Models
{
    public class street_eval_model
    {
        public int Id { get; set; }
        public string lat { get; set; }
        public string lng { get; set; }
        public string streetname { get; set; }
        public string description { get; set; }
        public float stars { get; set; }

        public street_eval_model()
        {

        }

        public street_eval_model(string lat, string lng, string streetname, string description, float stars)
        {

            this.lat = lat;
            this.lng = lng;
            this.description = description;
            this.streetname = streetname;
            this.stars = stars;


            using (SqlConnection connect = new SqlConnection("Server=wytzejelle.nl;Database=HandyMapp;UID=HandyMapp;PWD=Handy123;"))
            {
                string query = "INSERT INTO Obstacles_Eval (lat, lng, streetname, description,stars) Values(@lat, @lng,@streetname, @description, @stars)";

                SqlCommand command = new SqlCommand(query, connect);
                //command.Parameters.AddWithValue("Id", Id);
                command.Parameters.AddWithValue("lat", lat);
                command.Parameters.AddWithValue("lng", lng);
                command.Parameters.AddWithValue("streetname", streetname);
                command.Parameters.AddWithValue("description", description);
                command.Parameters.AddWithValue("stars", stars);
                try
                {
                    connect.Open();
                    command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    DisplaySqlErrors(ex);
                }
            }
        }
        List<string> obstStreetNames;
        public List<string> getObstacles()
        {
            SqlCommand vSQLcommand;
            SqlDataReader vSQLreader;
            try
            {
                using (SqlConnection connect = new SqlConnection("Server=wytzejelle.nl;Database=HandyMapp;UID=HandyMapp;PWD=Handy123;"))
                {
                    string query = "Select DISTINCT streetname from Obstacles_Eval";

                    connect.Open();
                    vSQLcommand = new SqlCommand(query, connect);
                    vSQLreader = vSQLcommand.ExecuteReader();
                    vSQLcommand.Dispose();

                    if (vSQLreader.HasRows)
                    {
                        // read Methode schaltet eins weiter
                        vSQLreader.Read();
                        obstStreetNames.Add((string)vSQLreader["streetname"]);
                    }
                }
                return obstStreetNames;
                }catch (SqlException ex)
                {
                    DisplaySqlErrors(ex);
                    return obstStreetNames;
                }
        }
        private static void DisplaySqlErrors(SqlException exception)
        {
            for (int i = 0; i < exception.Errors.Count; i++)
            {
                Console.WriteLine("Index #" + i + "\n" +
                    "Error: " + exception.Errors[i].ToString() + "\n");
            }
            Console.ReadLine();
        }
    }
}
