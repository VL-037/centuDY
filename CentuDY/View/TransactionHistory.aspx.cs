using CentuDY.Controller;
using CentuDY.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CentuDY.View
{
    public partial class TransactionHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["User"] == null)
                {
                    Response.Redirect("/View/LoginPage.aspx");
                }
                else
                {
                    fetchData();
                }
            }
        }

        private void fetchData()
        {
            if (Session["RoleId"] != null)
            {
                int roleId = int.Parse(Session["RoleId"].ToString());
                Role role = RoleController.GetRoleById(roleId);

                User user = (User)(Session["User"]);

                if (role.RoleName == "Member")
                {
                    gvTransHistory.DataSource = TransactionController.GetTransactionHistory(user.UserId);
                    gvTransHistory.DataBind();
                    int grandTotal = 0;

                    foreach (GridViewRow gvRow in gvTransHistory.Rows)
                    {
                        grandTotal += Int32.Parse(gvRow.Cells[3].Text);
                    }

                    lblGrandTotal.Text = grandTotal.ToString();
                }
            }
        }

        protected void btnHomePage_Click(object sender, EventArgs e)
        {
            Response.Redirect("/View/HomePage.aspx");
        }
    }
}