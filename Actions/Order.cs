using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopG.Entities;

namespace Shop.Actions
{
    public static class Order
    {
        private static int GetCountCart()
        {
            using (var context = new ShopContext())
            {
                return context.Carts.Select(s => s).Max(s => s.Id);
            }
        }
        public static void CreateNewOrder()
        {
            if (WorkWithAcc.IsLogin == true)
            {
                int id = GetCountCart()+1;
                List<int> list_ProdId = new List<int>();
                WorkWithProducts.ShowProducts();
                

                
                using (var context = new ShopContext())
                {
                    

                    context.Carts.Add(new Cart { Accountid = WorkWithAcc.AccId });
                    context.SaveChanges();
                    Console.WriteLine("Choise by id u want to order, id must be more then 0.\nIf u press 0, u will end the procces");

                    int choise;
                    bool isEnd = true;
                    while (isEnd)
                    {
                        choise = Convert.ToInt32(Console.ReadLine());
                        switch (choise)
                        {
                            case 0:
                                isEnd = false;
                                break;

                            default:
                                if (choise > 0 && choise <= WorkWithProducts.GetCountProduct())
                                {
                                    context.CardProducts.Add(new CardProduct { Cardid = id, Productid = choise });
                                    context.SaveChanges();
                                }
                                break;
                        }
                    }
                    


                    //context.Carts.Add(cart1);

                }
            }
            else
                Console.WriteLine("You are not logged in to the account");
        }
        public static void ShowOrders()
        {
            
            if (WorkWithAcc.IsLogin == true)
            {
                using (var context = new ShopContext())
                {
                    /*var orders = context.Carts
                        .Include(nameof(CardProduct))
                        .Include(nameof(Product)).Where(a => a.Accountid == WorkWithAcc.AccId);*/
                    var orders = (from ac in context.Accounts
                                 join c in context.Carts on ac.Id equals c.Accountid
                                 join cp in context.CardProducts on c.Id equals cp.Cardid
                                 join p in context.Products on cp.Productid equals p.Id
                                 where ac.Id == WorkWithAcc.AccId
                                 select new
                                 {
                                     CartId = c.Id,
                                     Product = p.NameProduct
                                 }).OrderBy(s=>s.CartId).ToList();


                    /*var orders = context.Products
                        .Include(nameof(CardProduct))
                        .Include(nameof(Cart))
                         .Include(nameof(Account))
                          .Where(a => a.Id == WorkWithAcc.AccId)

                          ;*/

                    if (orders.Count == 0)
                        Console.WriteLine("U haven`t any orders");
                    else
                    {
                        foreach (var item in orders)
                        {
                            Console.WriteLine($"Id of order: {item.CartId,3}, Product: {item.Product,15}");
                        }
                    }
                    
                }
            }
            else if(WorkWithAcc.IsLogin == false)
                Console.WriteLine("You are not logged in to the account");
            else if (GetCountCart() == 0)
                Console.WriteLine("U haven`t any orders");
        }
    }
}
