using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mountains_Code_First.Migrations;

namespace Mountains_Code_First
{
    class MountainsCodeFirst
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new MountainsMigrationStrategy());
            
            //Country c = new Country() {Code = "AB" , Name = "Absurdistan"};
            //Mountain m = new Mountain() {Name = "Absurditan Hills" };
            //m.Peaks.Add(new Peak() {Name = "Great Peak", Mountain = m});
            //m.Peaks.Add(new Peak() {Name = "Small Peak", Mountain = m});
            //c.Mountains.Add(m);

            //var context = new MountainsContext();
            //context.Countries.Add(c);
            //context.SaveChanges();

            var context = new MountainsContext();
            var countriesQuery = context.Countries.Select(c => new
            {
                CountryName = c.Name,
                Mountains = c.Mountains.Select(m => new
                {
                    m.Name,
                    m.Peaks
                })
            });

            foreach (var country in countriesQuery)
            {
                Console.WriteLine("Country: " + country.CountryName);
                foreach (var mountain in country.Mountains)
                {
                    Console.WriteLine("  Mountain: " + mountain.Name);
                    foreach (var peak in mountain.Peaks)
                    {
                        Console.WriteLine("\t{0} ({1})", peak.Name, peak.Elevation);
                    }
                }
            }
        }
    }
}
