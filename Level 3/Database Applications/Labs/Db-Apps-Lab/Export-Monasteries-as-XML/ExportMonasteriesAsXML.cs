using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using EF_Mappings;

namespace Export_Monasteries_as_XML
{
    class ExportMonasteriesAsXML
    {
        static void Main(string[] args)
        {
            var context = new GeographyEntities();

            var countriesQuery = context.Countries
                .OrderBy(c => c.CountryName)
                .Where(c => c.Monasteries.Any())
                .Select(c => new
                {
                    c.CountryName,
                    Monsteries = c.Monasteries
                    .OrderBy(m => m.Name)
                    .Select(m => m.Name)
                });

            var xmlMonsteries = new XElement("monasteries");

            foreach (var country in countriesQuery)
            {
                var xmlCountry = new XElement("country");
                xmlCountry.Add(new XAttribute("name", country.CountryName));
                xmlMonsteries.Add(xmlCountry);

                foreach (var mon in country.Monsteries)
                {
                    xmlCountry.Add(new XElement("monastery", mon));
                }
            }

            var xmlDoc = new XDocument(xmlMonsteries);
            xmlDoc.Save("../../monasteries.xml");
        }
    }
}
