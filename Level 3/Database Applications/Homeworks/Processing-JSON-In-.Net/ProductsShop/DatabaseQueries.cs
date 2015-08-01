using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;

namespace ProductsShop.Models
{
    public static class DatabaseQueries
    {
        public static void firstQuery()
        {
            var context = new ProductsShopEntities();

            var products = context.Products
                .Where(p => p.Price >= 500 &&
                            p.Price <= 1000 &&
                            p.BuyerId == null)
                .OrderBy(p => p.Price)
                .Select(p => new
                {
                    p.Name,
                    p.Price,
                    Seller = (p.Seller.FirstName + " " + p.Seller.LastName).TrimStart()
                });

            var serProducts = JsonConvert.SerializeObject(products, Formatting.Indented);
            System.IO.File.WriteAllText(@"..\..\firstQueryExport.json", serProducts);
        }

        public static void secondQuery()
        {
            var context = new ProductsShopEntities();

            var users = context.Users
                .Where(u => u.SoldProducts.Count > 0 && u.SoldProducts.All(sp => sp.BuyerId != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    soldProducts = u.SoldProducts
                    .Select(sp => new
                    {
                        name = sp.Name,
                        price = sp.Price,
                        buyerFirstName = sp.Buyer.FirstName,
                        buyerLastName = sp.Buyer.LastName
                    })
                });
            var serUsers = JsonConvert.SerializeObject(users, Formatting.Indented);
            System.IO.File.WriteAllText(@"..\..\secondQueryExport.json", serUsers);
        }

        public static void thirdQuery()
        {
            var context = new ProductsShopEntities();

            var categories = context.Categories
                .OrderBy(c => c.Products.Count)
                .Select(c => new
                {
                    category = c.Name,
                    productsCount = c.Products.Count,
                    averagePrice = c.Products.Average(p => p.Price),
                    totalRevenue = c.Products.Sum(p => p.Price)
                });

            var serCategories = JsonConvert.SerializeObject(categories, Formatting.Indented);
            System.IO.File.WriteAllText(@"..\..\thirdQueryExport.json", serCategories);
        }

        internal static void fourthQuery()
        {
            var context = new ProductsShopEntities();

            var users = context.Users
                .Where(u => u.SoldProducts.Count > 0)
                .OrderByDescending(u => u.SoldProducts.Count)
                .ThenBy(u => u.LastName)
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    u.Age,
                    ProductsSold = u.SoldProducts.Select(sp => new
                    {
                        sp.Price,
                        sp.Name
                    })
                });

            XmlDocument userDoc = new XmlDocument();
            XmlDeclaration xmlDeclaration = userDoc.CreateXmlDeclaration("1.0", "UTF-8", null);

            XmlElement rootNode = userDoc.CreateElement("users");
            rootNode.SetAttribute("count", users.Count().ToString());
            userDoc.InsertBefore(xmlDeclaration, userDoc.DocumentElement);
            userDoc.AppendChild(rootNode);

            foreach (var user in users)
            {
                XmlElement userNode = userDoc.CreateElement("user");
                if (user.FirstName != null)
                {
                    userNode.SetAttribute("first-name", user.FirstName);
                }

                userNode.SetAttribute("last-name", user.LastName);

                if (user.Age != null)
                {
                    userNode.SetAttribute("age", user.Age.ToString());
                }

                XmlElement productsNode = userDoc.CreateElement("sold-products");
                productsNode.SetAttribute("count", user.ProductsSold.Count().ToString());

                foreach (var products in user.ProductsSold)
                {
                    XmlElement proNode = userDoc.CreateElement("product");
                    proNode.SetAttribute("name", products.Name);
                    proNode.SetAttribute("price", products.Price.ToString("F"));
                    productsNode.AppendChild(proNode);
                }
                userNode.AppendChild(productsNode);
                rootNode.AppendChild(userNode);
            }

            userDoc.Save(@"..\..\fourthQuery.xml");
        }
    }
}
