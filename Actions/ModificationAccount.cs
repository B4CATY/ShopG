using ShopG.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Actions
{
    public static class ModificationAccount
    {
        public static string EditAcc()
        {
            string newName = string.Empty;
            using (var context = new ShopContext())
            {
                var accountEdit = context.Accounts.Find(WorkWithAcc.AccId);
                Console.WriteLine($"Your old name {accountEdit.Name}");
                Console.Write("Enter your new Name,the name must not be empty: ");
                newName = Console.ReadLine();
                if(newName == "")
                    Console.WriteLine("The name you want to change must not be empty");
                else
                {
                    accountEdit.Name = newName;
                    context.SaveChanges();
                    
                }
                return accountEdit.Name;
            }
        }
        
    }
}
