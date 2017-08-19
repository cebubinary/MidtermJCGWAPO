using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication2.Models
{
    public class Information
    {
        public List<Account> Accounts;
        private static Information _information;
        public static Information Context
        {
            get
            {
                if (_information == null)
                {
                    _information = new Information();
                }
                return _information;
            }
        }

        private Information()
        {
            
            Accounts = new List<Account>();
            Accounts.Add(new Account {Username="1", Password="1", Id=1, Age=1, Name="1", Address="1"  });
        }
        public int NextId()
        {
            return Accounts.Any() ? Accounts.Select(x => x.Id).Max() + 1 : 1;
        }
    }
}