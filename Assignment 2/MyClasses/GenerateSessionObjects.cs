using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment_2.MyClasses
{
    public class GenerateSessionObjects
    {
        List<Account> allAccounts = new List<Account>();
        public GenerateSessionObjects()
        {
            Account ac1 = new Account();
            ac1.Type = "Checking";
            ac1.Balance = 30123.45;
            ac1.Nickname = "My Chk1";
            Account ac2 = new Account();
            ac2.Type = "Checking";
            ac2.Balance = 20000.00;
            ac2.Nickname = "My Chk2";
            Account ac3 = new Account();
            ac3.Type = "Saving";
            ac3.Balance = 25000.01;
            ac3.Nickname = "My Sav3";
            allAccounts.Add(ac1);
            allAccounts.Add(ac2);
            allAccounts.Add(ac3);

            Customer cust = new Customer("Daniel Bert", "1234 Bathing Sun Lane, Louisville, 45523");
            HttpContext.Current.Session["customer"] = cust;
            HttpContext.Current.Session["AllAccountsList"] = allAccounts;
        }
    }
}