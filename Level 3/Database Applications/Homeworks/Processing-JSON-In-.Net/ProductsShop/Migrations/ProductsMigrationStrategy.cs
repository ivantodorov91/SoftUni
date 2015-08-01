using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using Newtonsoft.Json;

namespace ProductsShop.Models.Migrations
{
    using System;
    using System.Data.Entity;

    public class ProductsMigrationStrategy : DropCreateDatabaseIfModelChanges<ProductsShopEntities>
    {
        
        protected override void Seed(ProductsShopEntities context)
        {

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(@"..\..\users.xml");

            var users = xmlDoc.DocumentElement;

            foreach (XmlNode user in users.ChildNodes)
            {
                int? userAge = null;
                if (user.Attributes["age"] != null)
                {
                    userAge = int.Parse(user.Attributes["age"].Value);
                }

                context.Users.Add(new User()
                {
                    FirstName = user.Attributes["first-name"] != null ? user.Attributes["first-name"].Value : null,
                    LastName = user.Attributes["last-name"].Value,
                    Age = userAge

                });

                context.SaveChanges();
            }


            var productsJson = File.ReadAllText(@"..\..\products.json");
            var deserializeProducts = JsonConvert.DeserializeObject<IEnumerable<Product>>(productsJson);

            var categoriesJson = File.ReadAllText(@"..\..\categories.json");
            var deserializeCategories = JsonConvert.DeserializeObject<IEnumerable<Category>>(categoriesJson);

            Random rnd = new Random();
            foreach (var product in deserializeProducts)
            {
                int? buyId = rnd.Next(1, 50);
                int sellId = rnd.Next(1, 50);
                int catId = rnd.Next(0, 11);
                context.Products.Add(new Product()
                {

                    Name = product.Name,
                    Price = product.Price,
                    BuyerId = buyId > 40 ? null : buyId,
                    SellerId = sellId,
                    Categories =
                    {
                        deserializeCategories.ElementAt(catId), 
                        deserializeCategories.ElementAt(catId),
                        deserializeCategories.ElementAt(catId),
                        deserializeCategories.ElementAt(catId)
                    }

                });

                context.SaveChanges();
            }

        }
    }
}
