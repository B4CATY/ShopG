using ShopG.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Actions
{
    public static class WorkWithProducts
    {
       /* private static int _countProducts;*/
        public static void ShowProducts()
        {
            using(var context = new ShopContext())
            {
                var product = context.Products;
                foreach (var prod in product)
                {
                    Console.WriteLine($"Id:{prod.Id,3} Name: {prod.NameProduct, 25},  Decription: {prod.Description,25},  Price: {prod.Price,10}");
                }


                /*Console.WriteLine("Do u want to sort by Price?\nPress num");
                Console.WriteLine("1 - Yes");
                Console.WriteLine("2 - No");

                int choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 1)
                {
                    OrderedProducts();
                }*/
            }
        }
        public static int GetCountProduct()
        {
            using (var context = new ShopContext()) {
                return context.Products.ToList().Count;
            }
        } 
        public static void ShowOrderedProducts()
        {
            using (var context = new ShopContext())
            {
                var productSorted = context.Products.OrderBy(s => s.Price);
                foreach (var prod in productSorted)
                {
                    Console.WriteLine($"Id:{prod.Id,3} Name: {prod.NameProduct,25},  Decription: {prod.Description,25},  Price: {prod.Price,10}");
                }
            }
        }
    }
}
