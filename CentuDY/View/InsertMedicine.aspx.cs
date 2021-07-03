﻿using CentuDY.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CentuDY.View
{
    public partial class InsertMedicine : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnHomePage_Click(object sender, EventArgs e)
        {
            Response.Redirect("/View/HomePage.aspx");
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string desc = txtDescription.Text;
            string stock = txtStock.Text;
            string price = txtPrice.Text;
            string message = MedicineController.InsertMedicine(name, desc, stock, price);

            if(message != "")
            {
                lblError.Text = message;
            }
            else
            {
                Response.Redirect("/View/HomePage.aspx");
            }
        }

    }
}