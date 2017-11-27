using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Assignment_2.MyClasses;

namespace Assignment_2.MyClasses
{
    public partial class AccountSummary : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AllAccountsList"] == null)
            {
                GenerateSessionObjects sessionObjs = new GenerateSessionObjects();
            }
            
            List<Account> acctList = (List<Account>)Session["AllAccountsList"];
            Customer cust = (Customer)Session["customer"];
            WelcomeLabel.Text = "Welcome " + cust.FullName;

            foreach (Account acct in acctList)
            {
                AccountListbox.Items.Add(acct.Nickname);
            }
        }

        protected void DetailsButton_Click(object sender, EventArgs e)
        {
            Server.Transfer("AccountPages/AccountDetails.aspx");
        }
    }
}