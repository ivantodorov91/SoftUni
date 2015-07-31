using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Mappings
{
    class ListContitents
    {
        static void Main(string[] args)
        {
            var context = new GeographyEntities();
            var continets = context.Continents.Select(c => c.ContinentName);

            foreach (var continet in continets)
            {
                Console.WriteLine(continet);
            }
        }
    }
}
