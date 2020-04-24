using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using ModelKlasser;

namespace RestCustomer
{
    class MetodeClient
    {
        const string accessString = "https://localhost:44339/";


        //hent alle faciliteter
        public void GetAllFaciliteter()
        {
            HttpClientHandler handler = new HttpClientHandler()
            {
                UseDefaultCredentials = true
            };

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(accessString);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                Console.WriteLine("Du har hentet alle faciliteter\n");

                try
                {
                    var hentFaciliteter = client.GetAsync("api/faciliteter").Result;
                    if (hentFaciliteter.IsSuccessStatusCode)
                    {
                        var mineFaciliteter = hentFaciliteter.Content.ReadAsAsync<IEnumerable<Faciliteter>>().Result;

                        foreach (var faciliteter in mineFaciliteter)
                        {
                            Console.WriteLine(faciliteter);
                        }
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine("CRITICAL FAILURE");
                }

            }
        }

        //Hent facilitet via ID
        public void GetFacilitetFromId(int Id)
        {
            HttpClientHandler handler = new HttpClientHandler()
            {
                UseDefaultCredentials = true
            };

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(accessString);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("Application/json"));

                Faciliteter mitFacilitet = new Faciliteter();

                Console.WriteLine($"\nDu har hentet en facilitet via ID = {Id}\n");
                try
                {
                    var hentFaciliteter = client.GetAsync($"api/faciliteter/{Id}").Result;
                    if (hentFaciliteter.IsSuccessStatusCode)
                    {
                        var mineFaciliteter = hentFaciliteter.Content.ReadAsAsync<Faciliteter>().Result;

                        mitFacilitet.Facilitet_Nr = mineFaciliteter.Facilitet_Nr;
                        mitFacilitet.Navn = mineFaciliteter.Navn;
                        mitFacilitet.Åbningstid = mineFaciliteter.Åbningstid;
                        mitFacilitet.Lukketid = mineFaciliteter.Lukketid;
                        mitFacilitet.Hotel_Nr = mineFaciliteter.Hotel_Nr;

                        Console.WriteLine($"{mitFacilitet}");
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine("CRITICAL FAILURE");
                }

            }
        }

        //Opretter en facilitet
        public void CreateFaciliteter(Faciliteter postFacilitet)
        {
            HttpClientHandler handler = new HttpClientHandler()
            {
                UseDefaultCredentials = true
            };

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(accessString);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var createFacilitet = client.PostAsJsonAsync("api/faciliteter", postFacilitet).Result;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Another Critical Failure");
                }

                Console.WriteLine($"\nDu har oprettet en ny facilitet\n");
                Console.WriteLine(postFacilitet);
            }

        }

        //redigere en facilitet
        public void UpdateFacilitet(int Id, Faciliteter updateFacilitet)
        {
            HttpClientHandler handler = new HttpClientHandler()
            {
                UseDefaultCredentials = true
            };

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(accessString);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("Application/json"));
                
                Console.WriteLine($"\nDu har redigeret en facilitet = {Id}\n");
                try
                {
                    var createFacilitet = client.PutAsJsonAsync($"api/faciliteter/{Id}", updateFacilitet).Result;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Another Critical Failure");
                }

                
            }
        }

        //sletter en facilitet
        public void DeleteFacilitet(int Id)
        {
            HttpClientHandler handler = new HttpClientHandler()
            {
                UseDefaultCredentials = true
            };

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(accessString);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("Application/json"));

                try
                {
                    var createFacilitet = client.DeleteAsync($"api/faciliteter/{Id}").Result;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Another Critical Failure");
                }

                Console.WriteLine($"\nDu har slettet en facilitet via ID = {Id}\n");
            }
        }

        //Henter alle hoteller
        public void GetAllHotels()
        {
            HttpClientHandler handler = new HttpClientHandler()
            {
                UseDefaultCredentials = true
            };

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(accessString);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                Console.WriteLine("Du har hentet alle hoteller\n");

                try
                {
                    var hentHoteller = client.GetAsync("api/hotel").Result;
                    if (hentHoteller.IsSuccessStatusCode)
                    {
                        var mineHoteller = hentHoteller.Content.ReadAsAsync<IEnumerable<Hotel>>().Result;

                        foreach (var hotel in mineHoteller)
                        {
                            Console.WriteLine(hotel);
                        }
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine("CRITICAL FAILURE");
                }

            }
        }

        //Hent Hotel via ID
        public void GetHotelFromId(int Id)
        {
            HttpClientHandler handler = new HttpClientHandler()
            {
                UseDefaultCredentials = true
            };

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(accessString);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("Application/json"));

                Hotel mitHotel = new Hotel();

                Console.WriteLine($"\nDu har hentet et hotel via ID = {Id}\n");
                try
                {
                    var hentHoteller = client.GetAsync($"api/hotel/{Id}").Result;
                    if (hentHoteller.IsSuccessStatusCode)
                    {
                        var mineHoteller = hentHoteller.Content.ReadAsAsync<Hotel>().Result;

                        mitHotel.Hotel_Nr = mineHoteller.Hotel_Nr;
                        mitHotel.Navn = mineHoteller.Navn;
                        mitHotel.Adresse = mineHoteller.Adresse;

                        Console.WriteLine($"{mitHotel}");
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine("CRITICAL FAILURE");
                }

            }
        }

        //opretter et hotel
        public void CreateHotel(Hotel postHotel)
        {
            HttpClientHandler handler = new HttpClientHandler()
            {
                UseDefaultCredentials = true
            };

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(accessString);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var createHotel = client.PostAsJsonAsync("api/hotel", postHotel).Result;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Another Critical Failure");
                }

                Console.WriteLine($"\nDu har oprettet et nyt hotel\n");
                Console.WriteLine(postHotel);
            }

        }

        //redigere et hotel
        public void UpdateHotel(int Id, Hotel updateHotel)
        {
            HttpClientHandler handler = new HttpClientHandler()
            {
                UseDefaultCredentials = true
            };

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(accessString);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                Console.WriteLine($"\nDu har redigeret et hotel = {Id}\n");
                try
                {
                    var createHotel = client.PutAsJsonAsync($"api/hotel/{Id}", updateHotel).Result;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Another Critical Failure");
                }


            }
        }

        //sletter et hotel
        public void DeleteHotel(int Id)
        {
            HttpClientHandler handler = new HttpClientHandler()
            {
                UseDefaultCredentials = true
            };

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(accessString);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("Application/json"));

                try
                {
                    var createHotel = client.DeleteAsync($"api/hotel/{Id}").Result;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Another Critical Failure");
                }

                Console.WriteLine($"\nDu har slettet et hotel via ID = {Id}\n");
            }
        }
    }
}
