using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelKlasser;

namespace DBContext
{
    public class ManageHotel : iManageHotel
    {
        public const string DBAccess =
            "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog = DatabaseTest; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<Hotel> HotelList = new List<Hotel>();

        public bool CreateHotel(Hotel hotel)
        {
            using (SqlConnection connection = new SqlConnection(DBAccess))
            {
                var Test = GetAllHotels().Contains(hotel);
                if (!Test)
                {
                    var Query =
                        $"Insert into Hotel Values ({hotel.Hotel_Nr},'{hotel.Navn}','{hotel.Adresse}')";
                    SqlCommand command = new SqlCommand(Query, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }

                return Test;
            }
        }

        public Hotel DeleteHotel(int HotelId)
        {
            using (SqlConnection connection = new SqlConnection(DBAccess))
            {
                var Test = GetHotelFromId(HotelId);
                if (Test != null)
                {
                    var Query =
                        $"Delete from Hotel where Hotel_Nr = {HotelId}";
                    SqlCommand command = new SqlCommand(Query, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }

                return Test;
            }
        }

        public List<Hotel> GetAllHotels()
        {
            using (SqlConnection connection = new SqlConnection(DBAccess))
            {
                var Query = "Select * from Hotel";
                SqlCommand command = new SqlCommand(Query, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int Hotel_Nr = reader.GetInt32(0);
                    string Navn = reader.GetString(1);
                    string Adresse = reader.GetString(2);

                    Hotel hotel1 = new Hotel()
                    {
                        Hotel_Nr = Hotel_Nr,
                        Navn = Navn,
                        Adresse = Adresse

                    };
                    HotelList.Add(hotel1);
                }

                connection.Close();
                return HotelList;
            }
        }

        public Hotel GetHotelFromId(int HotelId)
        {
            using (SqlConnection connection = new SqlConnection(DBAccess))
            {
                var Query = $"Select * from Hotel Where Hotel_Nr = {HotelId}";
                SqlCommand command = new SqlCommand(Query, connection);
                connection.Open();
                Hotel Hotel2 = new Hotel();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int Hotel_Nr = reader.GetInt32(0);
                    string Navn = reader.GetString(1);
                    string Adresse = reader.GetString(2);

                    Hotel2.Hotel_Nr = Hotel_Nr;
                    Hotel2.Navn = Navn;
                    Hotel2.Adresse = Adresse;
                }

                connection.Close();
                return Hotel2;
            }
        }

        public bool UpdateHotel(int HotelId, Hotel hotel)
        {
            using (SqlConnection connection = new SqlConnection(DBAccess))
            {
                var Test = GetAllHotels().Contains(hotel);
                if (!Test)
                {
                    var Query =
                        $"UPDATE Hotel set Hotel_Nr= {hotel.Hotel_Nr}, Navn = '{hotel.Navn}', Adresse = '{hotel.Adresse}' where Hotel_Nr = {HotelId}";
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