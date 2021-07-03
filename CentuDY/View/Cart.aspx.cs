using CentuDY.Controller;
using CentuDY.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CentuDY.View
{
    public partial class Cart : System.Web.UI.Page
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

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            User user = (User)Session["User"];
            int medicineId = Int32.Parse((sender as Button).CommandArgument);

            CartController.RemoveCartItem(user.UserId, medicineId);
            fetchData();
        }

        protected void btnCheckOut_Click(object sender, EventArgs e)
        {
            User user = (User)Session["User"];
            var cartItems = CartController.GetItemsByUserId(user.UserId);
            DateTime date = DateTime.Now;

            foreach(var item in cartItems)
            {
                int medicineId = item.MedicineId;
                int quantity = (int)item.Quantity;
                TransactionController.InsertTransaction(user.UserId, date, medicineId, quantity);
            }

            CartController.CheckoutAllItems(user.UserId);
            fetchData();
        }

        protected void btnMedicinePage_Click(object sender, EventArgs e)
        {
            Response.Redirect("/View/Medicine.aspx");
        }

        protected void btnHomePage_Click(object sender, EventArgs e)
        {
            Response.Redirect("/View/HomePage.aspx");
        }

        private void fetchData()
        {
            User user = (User)Session["User"];
            var allCartItems = CartController.GetAllCartItemsByUserId(user.UserId);
            int grandTotal = 0;

            gvAllCartItems.DataSource = allCartItems;
            gvAllCartItems.DataBind();

            foreach (GridViewRow gvRow in gvAllCartItems.Rows)
            {
                grandTotal += Int32.Parse(gvRow.Cells[5].Text);
            }

            lblGrandTotal.Text = grandTotal.ToString();
        }
    }
}