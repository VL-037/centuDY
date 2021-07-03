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
    public partial class Users : System.Web.UI.Page
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

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int userId = Int32.Parse((sender as Button).CommandArgument);
            UserController.RemoveUser(userId);
            fetchData();
        }

        protected void btnHomePage_Click(object sender, EventArgs e)
        {
            Response.Redirect("/View/HomePage.aspx");
        }

        private void fetchData()
        {
            if(Session["RoleId"] != null)
            {
                int roleId = int.Parse(Session["RoleId"].ToString());
                Role role = RoleController.GetRoleById(roleId);

                if(role.RoleName == "Administrator")
                {
                    gvAllUsers.DataSource = UserController.GetAllViewUsers();
                    gvAllUsers.DataBind();
                }
            }
        }
    }
}