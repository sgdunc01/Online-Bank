using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Assignment_2.MyClasses;

namespace Assignment_2.AccountPages
{
    public partial class LoanApplicationPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Account> acctList = (List<Account>)Session["AllAccountsList"];
            Customer cust = (Customer)Session["customer"];
            if (PreviousPage != null)
            {
                NameLabel.Text = cust.FullName;
            }
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            List<Account> acctList = (List<Account>)Session["AllAccountsList"];
            int age = int.Parse(AgeTextbox.Text);
            double loan = double.Parse(LoanTextbox.Text);
            double salary = double.Parse(SalaryTextbox.Text);
            double maxLoan = salary * .5;
            double currentBalance = acctList[(int)Session["selectedIndex"]].Balance;

            if (age > 18 && loan < maxLoan && loan < currentBalance)
            {
                LoanApprovalLabel.Text = "Congratulations!!Your loan is approved!";
            }
            else
            {
                LoanApprovalLabel.Text = "Your loan is not approved. Sorry!";
            }
        }
    }
}