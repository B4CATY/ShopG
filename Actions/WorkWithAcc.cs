using ShopG.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Actions
{
    public static class WorkWithAcc
    {
        private static bool _isLogin = false;
        private static int? _accId;
        public static bool IsLogin { get => _isLogin; }
        public static int? AccId { get=>_accId; }


        public static string LoginAcc()
        {
            Console.Clear();
            Console.WriteLine("Login");
            using (var context = new ShopContext())
            {
                Console.Write("Enter your login: ");
                string Login = Console.ReadLine();
                Account account;

                account = context.Accounts.Where(s => s.Login.Contains(Login)).Single(); // check login

                Console.Clear();
                string Password = string.Empty;

                while (true)
                {
                    Console.Write("Enter your password:");
                    Password = Console.ReadLine();
                    if (Password == account.Password) break;
                    Console.WriteLine("The password is incorrect");
                }
                Console.Clear();
                Console.WriteLine($"Welcome to your account {account.Name}");
                _accId = account.Id;
                _isLogin = true;
                return account.Name;
            }
        }

        public static void RegistrationAcc()
        {
            Console.Clear();
            Console.WriteLine("Registration");
            using (var context = new ShopContext())
            {
                Console.Write("Enter your login: ");
                string Login = Console.ReadLine();
                while (true)
                {
                    var accountChek = context.Accounts.Select(s => s).Where(s => s.Login.Contains(Login)).ToList().Count;
                    if (accountChek == 0) break;
                    Console.Write("Enter your login again: ");
                    Login = Console.ReadLine();
                }


                Console.Write("Enter your password, it must be more than 7 characters long: ");
                string Password = Console.ReadLine();
                while (true)
                {
                    if (Password.Length >= 8) break;

                    Console.Write("Enter your password again, it must be more than 8 characters long: ");
                    Password = Console.ReadLine();
                }

                Console.Write("Enter your Name, If you do not enter a name, the field will be David: ");
                string Name = Console.ReadLine();
                if (Name.Length == 0) 
                    Name = "David";

                var account = new Account { Name = Name, Password = Password, Login = Login };
                context.Accounts.Add(account);
                context.SaveChanges();
            }
        }

        public static string EditAcc()
        {
            if (_isLogin == false)
            {
                Console.WriteLine("You are not logged in to the account");
                return string.Empty;
            }
            else
            {
                ModificationAccount.EditAcc();
                using (var context = new ShopContext())
                {
                    var account = context.Accounts.Find(_accId);
                    return account.Name;
                }
            }
        }
    }
}
