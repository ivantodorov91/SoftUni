using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductsShop.Models.Migrations;
using Newtonsoft.Json;
namespace ProductsShop.Models
{
    public class MainMethod
    {
        static void Main()
        {

            //Database.SetInitializer(new ProductsMigrationStrategy());
            DatabaseQueries.fourthQuery();

        }
    }
}
