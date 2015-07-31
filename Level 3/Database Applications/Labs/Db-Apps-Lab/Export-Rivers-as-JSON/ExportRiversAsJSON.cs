using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using EF_Mappings;

namespace Export_Rivers_as_JSON
{
    class ExportRiversAsJSON
    {
        static void Main(string[] args)
        {
            var context = new GeographyEntities();
            var rivers = context.Rivers
                .OrderByDescending(r => r.Length)
                .Select(r => new
            {
                r.RiverName,
                r.Length,
                Countries = r.Countries
                .OrderBy(c => c.CountryName)
                .Select(c => c.CountryName)
            });

            var jsSerializer = new JavaScriptSerializer();
            var riversJSON = jsSerializer.Serialize(rivers.ToList());
            Console.WriteLine(riversJSON);
            
            System.IO.File.WriteAllText(@"../../riversJSON.txt", riversJSON);
        }
    }
}
