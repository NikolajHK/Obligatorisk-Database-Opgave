using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelKlasser;

namespace DBContext
{
    public class ManageFaciliteter : iManageFaciliteter
    {
        public const string DBAccess =
            "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog = DatabaseTest; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<Faciliteter> FaciliterList = new List<Faciliteter>();

        public bool CreateFacilitetet(Faciliteter facilitet)
        {
            using (SqlConnection connection = new SqlConnection(DBAccess))
            {
                var Test = GetAllFaciliteter().Contains(facilitet);
                if (!Test)
                {
                    var Query =
                    $"Insert into Faciliteter Values ({facilitet.Facilitet_Nr},'{facilitet.Navn}','{facilitet.Åbningstid}','{facilitet.Lukketid}')";
                    SqlCommand command = new SqlCommand(Query, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }

                return Test;
            }
        }

        public Faciliteter DeleteFacilitet(int FacilitetID)
        {
            using (SqlConnection connection = new SqlConnection(DBAccess))
            {
                var Test = GetFaciliteterFromId(FacilitetID);
                if (Test != null)
                {
                    var Query =
                        $"Delete from Faciliteter where Facilitet_Nr = {FacilitetID}";
                    SqlCommand command = new SqlCommand(Query, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }

                return Test;
            }
        }

        public List<Faciliteter> GetAllFaciliteter()
        {
            using (SqlConnection connection = new SqlConnection(DBAccess))
            {
                var Query = "Select * from Faciliteter";
                SqlCommand command = new SqlCommand(Query, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int Facilitet_Nr = reader.GetInt32(0);
                    string Navn = reader.GetString(1);
                    TimeSpan Åbningstid = reader.GetTimeSpan(2);
                    TimeSpan Lukketid = reader.GetTimeSpan(3);

                    ModelKlasser.Faciliteter facilitet1 = new ModelKlasser.Faciliteter()
                    {
                        Facilitet_Nr = Facilitet_Nr,
                        Navn = Navn,
                        Åbningstid = Åbningstid,
                        Lukketid = Lukketid,

                    };
                    FaciliterList.Add(facilitet1);
                }
                connection.Close();
                return FaciliterList;
            }
        }

        public Faciliteter GetFaciliteterFromId(int facilitetID)
        {
            using (SqlConnection connection = new SqlConnection(DBAccess))
            {
                var Query = $"Select * from Faciliteter Where Facilitet_Nr = {facilitetID}";
                SqlCommand command = new SqlCommand(Query, connection);
                connection.Open();
                Faciliteter Facilitet2 = new ModelKlasser.Faciliteter();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int Facilitet_Nr = reader.GetInt32(0);
                    string Navn = reader.GetString(1);
                    TimeSpan Åbningstid = reader.GetTimeSpan(2);
                    TimeSpan Lukketid = reader.GetTimeSpan(3);

                    Facilitet2.Facilitet_Nr = Facilitet_Nr;
                    Facilitet2.Navn = Navn;
                    Facilitet2.Åbningstid = Åbningstid;
                    Facilitet2.Lukketid = Lukketid;
                }
                connection.Close();
                return Facilitet2;
            }
        }

        public bool UpdateFacilitet(int facilitetID, Faciliteter facilitet)
        {
            using (SqlConnection connection = new SqlConnection(DBAccess))
            {
                var Test = GetAllFaciliteter().Contains(facilitet);
                if (!Test)
                {
                    var Query =
                        $"UPDATE Faciliteter set Facilitet_Nr= {facilitet.Facilitet_Nr}, Navn = '{facilitet.Navn}', Åbningstid = '{facilitet.Åbningstid}', Lukketid = '{facilitet.Lukketid}' where facilitet_Nr = {facilitetID}";
                    SqlCommand command = new SqlCommand(Query, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }

                return Test;
            }
        }
    }
}
