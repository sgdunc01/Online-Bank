using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Assignment_2.MyClasses;

namespace Assignment_2.AccountPages
{
    public partial class AccountDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Account> acctList = (List<Account>)Session["AllAccountsList"];
            Customer cust = (Customer)Session["customer"];
            if (PreviousPage != null)
            {
                int selectionIndex;
                if (Request.UrlReferrer.AbsolutePath == "/AccountSummary.aspx")
                {
                    selectionIndex = ((ListBox)PreviousPage.FindControl("AccountListbox")).SelectedIndex;
                    Session["selectedIndex"] = selectionIndex;
                }
                else
                {
                    selectionIndex = (int)Session["selectedIndex"];
                }
                
                Account selectedAcct = acctList[selectionIndex];
                AccountNameLabel.Text = selectedAcct.Nickname;
                AcctTypeLabel.Text = selectedAcct.Type;
                BalanceLabel.Text = selectedAcct.Balance.ToString("c");
                LoanLabel.Text = selectedAcct.hasLoanOffer().ToString();
                AddressLabel.Text = cust.FullAddress;
            }
        }

        protected void WithdrawlButton_Click(object sender, EventArgs e)
        {
            List<Account> acctList = (List<Account>)Session["AllAccountsList"];
            Customer cust = (Customer)Session["customer"];
            int selectionIndex = (int)Session["selectedIndex"];
            Account selectedAcct = acctList[selectionIndex];
            double withdrawlRequest = double.Parse(WithdrawlTextbox.Text);
            if (withdrawlRequest <= selectedAcct.Balance)
            {
                acctList[selectionIndex].Balance = selectedAcct.Balance - withdrawlRequest;
                LoanLabel.Text = selectedAcct.hasLoanOffer().ToString();
                BalanceLabel.Text = selectedAcct.Balance.ToString("c");
                Session["AllAccountsList"] = acctList;
            }
            else
            {
                WithdrawlErrorLabel.Text = "Withdrawal Amount is greater than Balance.";
                WithdrawlTextbox.Text = "";
            }
        }
    }
}