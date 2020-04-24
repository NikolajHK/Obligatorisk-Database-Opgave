using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ModelKlasser;

namespace RestCustomer
{
    class Program
    {
        static void Main(string[] args)
        {
            MetodeClient testMetoder = new MetodeClient();
            testMetoder.GetAllHotels();
            testMetoder.GetHotelFromId(1);
            Hotel testCreateHotel = new Hotel() { Hotel_Nr = 6, Navn = "New Hotel 2", Adresse = "Really New Road" };
            testMetoder.CreateHotel(testCreateHotel);
            Hotel testCreateHotel2 = new Hotel() { Hotel_Nr = 5, Navn = "Really New Hotel", Adresse = "Really New Road 3" };
            testMetoder.UpdateHotel(5, testCreateHotel2);
            testMetoder.DeleteHotel(6);

            testMetoder.GetAllFaciliteter();
            testMetoder.GetFacilitetFromId(1);
            Faciliteter testCreateFacilitet = new Faciliteter() { Facilitet_Nr = 6, Navn = "Poolbord ", Åbningstid = new TimeSpan(10, 00, 00), Lukketid = new TimeSpan(23, 00, 00) };
            testMetoder.CreateFaciliteter(testCreateFacilitet);
            Faciliteter test2 = new Faciliteter() { Facilitet_Nr = 4, Navn = "Poolbord 4 ", Åbningstid = new TimeSpan(10, 00, 00), Lukketid = new TimeSpan(23, 00, 00)};
            testMetoder.UpdateFacilitet(4, test2);
            testMetoder.DeleteFacilitet(Id: 6);
            Console.ReadKey();
        }
    }
}
