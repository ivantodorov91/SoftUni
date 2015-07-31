using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;
using EF_Mappings;

namespace Import_Rivers_From_XML
{
    class ImportRiversFromXML
    {
        static void Main(string[] args)
        {
            var context = new GeographyEntities();
            var xmlDoc = XDocument.Load(@"..\..\rivers.xml");
            var riverNodes = xmlDoc.XPathSelectElements("/rivers/river");
            
            foreach (var riverNode in riverNodes)
            {
                string riverName = riverNode.Element("name").Value;
                int riverLength = int.Parse(riverNode.Element("length").Value);
                string riverOutFlow = riverNode.Element("outflow").Value;

                int? drainageArea = null;
                if (riverNode.Element("drainage-area") != null)
                {
                    drainageArea = int.Parse(riverNode.Element("drainage-area").Value);
                }

                int? averageDischarge = null;
                if (riverNode.Element("average-discharge") != null)
                {
                    averageDischarge = int.Parse(riverNode.Element("average-discharge").Value);
                }

                var countryNodes = riverNode.XPathSelectElements("countries/country");
                var countries = countryNodes.Select(c => c.Value);
                
                var river = new River()
                {
                    RiverName = riverName,
                    Length = riverLength,
                    Outflow = riverOutFlow,
                    DrainageArea = drainageArea,
                    AverageDischarge = averageDischarge
                };

                context.Rivers.Add(river);

                foreach (var countryName in countries)
                {
                    var country = context.Countries
                        .FirstOrDefault(c => c.CountryName == countryName);

                    river.Countries.Add(country);
                }

                context.SaveChanges();
            }
        }
    }
}
