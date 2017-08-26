using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcApplication2.Models;

namespace MvcApplication2.Utils
{
    public class AccountsUtils
    {
        public static List<Account> GetAccounts(int id=0)
        {
            return (id == 0) ?
               Information.Context.Accounts :
               Information.Context.Accounts.Where(x => x.Id == id).ToList();
        }
        public static Account Save(Account acc)
        {
            var selected = Information.Context.Accounts.FirstOrDefault(x => x.Id == acc.Id);
            if (selected != null)
            {
                selected.Name = acc.Name;
                selected.Age = acc.Age;
                selected.Username = acc.Username;
                selected.Password = acc.Password;
                selected.Address = acc.Address;

            }
            else
            {
                acc.Id = Information.Context.NextId();
                Information.Context.Accounts.Add(acc);
            }
            return acc;
        }

        public static void Delete(int id)
        {
            var selected = Information.Context.Accounts.FirstOrDefault(x => x.Id == id);
            if (selected != null)
            {

                Information.Context.Accounts.Remove(selected);

            }
        }
        public static bool ValidUserNamePassword(string username, string password)
        {
            var selectedUser = AccountsUtils.GetAccounts().FirstOrDefault(x => x.Username == username && x.Password == password);
            return selectedUser != null;
        }
    }
}