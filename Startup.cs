using Shop.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class Startup
    {
        private readonly string _name;
        private string _nameUser;

        private bool _isEnd = true;
        public bool IsEnd { get => _isEnd; }

        public Startup()
        {
            _name = "Graphic Card Shop";
            _nameUser = string.Empty;
        }
        public void UserInteraction()
        {
            
            string choice;

            while (_isEnd)
            {
                Console.WriteLine("Press any key");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine($"Welcome to the {_name} {_nameUser}");
                Console.WriteLine("1 - Show products");
                Console.WriteLine("2 - Show ordered products");
                Console.WriteLine("3 - Show catagories");
                Console.WriteLine("4 - Login");
                Console.WriteLine("5 - Registration");
                Console.WriteLine("6 - Edit Profile Name");
                Console.WriteLine("7 - Order your product");
                Console.WriteLine("8 - Show your order history");
                Console.WriteLine("9 - Exit");

                Console.Write("Select an action: ");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        WorkWithProducts.ShowProducts();
                        break;
                    case "2":
                        WorkWithProducts.ShowOrderedProducts();
                        break;

                    case "3":
                        WorkWithCategory.ShowCategory();
                        break;

                    case "4":
                        _nameUser = WorkWithAcc.LoginAcc();
                        break;

                    case "5":
                        WorkWithAcc.RegistrationAcc();
                        break;
                    case "6":
                        _nameUser = WorkWithAcc.EditAcc();
                        break;

                    case "7":
                        Order.CreateNewOrder();
                        break;

                    case "8":
                        Order.ShowOrders();
                        break;

                    case "9":
                        _isEnd = false;
                        break;
                    
                    default:
                        Console.WriteLine("Not correct input");
                        break;


                }
                
            }





        }
    }
}
