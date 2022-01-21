using ShopG.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Actions
{
    public class WorkWithCategory
    {
        public static void ShowCategory()
        {
            using (var context = new ShopContext())
            {
                var category = context.Categories;
                foreach (var cat in category)
                {
                    Console.WriteLine($"Name: {cat.Name}");
                }
            }
        }
    }
}
