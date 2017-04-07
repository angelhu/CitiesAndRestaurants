using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitiesAndRestaurants
{
    class Program
    {
        static void Main(string[] args)
        {
            City dallas = new City();
            dallas.Name = "Dallas";
            dallas.State = "TX";

            LatLng dallasCoords = new LatLng();
            dallasCoords.Lat = -75.295064;
            dallasCoords.Lng = 39.883318;
            dallas.Coords = dallasCoords;

            dallas.Neighborhoods = new List<Neighborhood>();
            Neighborhood deepEllum = new Neighborhood();
            deepEllum.City = dallas;
            deepEllum.Name = "Deep Ellum";
            deepEllum.Restaurants = new List<Restaurant>();
            Neighborhood uptown = new Neighborhood();
            uptown.City = dallas;
            uptown.Name = "Uptown";
            uptown.Restaurants = new List<Restaurant>();
            dallas.Neighborhoods.Add(deepEllum);
            dallas.Neighborhoods.Add(uptown);

            Restaurant pecanLodge = new Restaurant();
            pecanLodge.Name = "Pecan Lodge";
            pecanLodge.Type = Category.American;
            pecanLodge.WebsiteUrl = "http://pecanlodge.com/";

            Address address = new Address();
            address.StreetAddress = "2702 Main St";
            address.City = dallas;
            address.Zip = 75226;
            address.LatLng = new LatLng();
            address.LatLng.Lat = 32.784065;
            address.LatLng.Lng = -96.783745;

            //or pecanLodge.Address = new Address();
            //   pecanLodge.Address.StreetAddress = "2702 Main St";
            //   pecanLodge.Address.City = dallas;
            //   pecanLodge.Address.Zip = 75226;

            Restaurant monkeyKing = new Restaurant();
            monkeyKing.Name = "Monkey King Noodle Company";
            monkeyKing.Type = Category.Chinese;
            monkeyKing.WebsiteUrl = "http://monkeykingnoddlecompany.com/";

            Address address1 = new Address();
            address1.StreetAddress = "2933 Main St";
            address1.City = dallas;
            address1.Zip = 75226;
            address1.LatLng = new LatLng();
            address1.LatLng.Lat = 32.786744;
            address1.LatLng.Lng = -96.780905;

            deepEllum.Restaurants.Add(pecanLodge);
            deepEllum.Restaurants.Add(monkeyKing);

            List<Restaurant> restaurants = dallas.FindRestaurantByType(Category.Chinese);
                foreach (Restaurant restaurant in restaurants)
                {
                Console.WriteLine(restaurant.Name);
               }
        }
    }


    
    public class City
    {
        public string Name { get; set; }
        public string State { get; set; }
        public LatLng Coords { get; set; }
        public List<Neighborhood> Neighborhoods { get; set; }
        public List<Restaurant> Restaurants { get; set; }
        public List<City> NeighboringCities { get; set; }

        public List<Restaurant> FindRestaurantByType(Category type)
        {
            List<Restaurant> results = new List<Restaurant>();
            foreach (Neighborhood neighborhood in Neighborhoods)
            {
                results.AddRange(neighborhood.FindRestaurantByType(type));
            }
            return results;
        }
    }

    public class Neighborhood
    {
        public string Name { get; set; }
        public City City { get; set; }
        public List<Restaurant> Restaurants{ get; set; }

        public List<Restaurant> FindRestaurantByType(Category type)
        {
            List<Restaurant> results = new List<Restaurant>();

            foreach (Restaurant restaurant in Restaurants)
            {
                if (restaurant.Type == type)
                {
                    results.Add(restaurant);
                }
            }
            return results;
        }
    }

    public class Restaurant
    {
        public Address Address { get; set; }
        public string Name { get; set; }
        public Category Type { get; set; }
        public string WebsiteUrl { get; set; }
    }

    public class LatLng
    {
        public double Lat { get; set; }
        public double Lng { get; set; }
    }

    public class Address
    {
        public LatLng LatLng { get; set; }
        public string StreetAddress { get; set; }
        public int Zip { get; set; }
        public string State { get; set; }
        public City City { get; set; }
    }

    public enum Category
    {
        Italian,
        American,
        Thai,
        German,
        French,
        English,
        Mexican,
        Spanish,
        Chinese,
        Korean,
        Japanese,
        Other
    }
}
