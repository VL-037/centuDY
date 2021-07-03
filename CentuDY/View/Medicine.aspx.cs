using CentuDY.Controller;
using CentuDY.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CentuDY.View
{
    public partial class Medicine : System.Web.UI.Page
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

        protected void btnHomePage_Click(object sender, EventArgs e)
        {
            Response.Redirect("/View/HomePage.aspx");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string search = txtSearch.Text.Trim();
            
            if(search != null)
            {
                gvAllMedicines.DataSource = MedicineController.GetSearchedMedicines(search);
                gvAllMedicines.DataBind();
            }
        }

        private void fetchData()
        {
            if (Session["RoleId"] != null)
            {
                int roleId = int.Parse(Session["RoleId"].ToString());
                Role role = RoleController.GetRoleById(roleId);

                if (role.RoleName == "Member")
                {
                    gvAllMedicines.Columns[5].Visible = false;
                    gvAllMedicines.Columns[6].Visible = false;

                    btnInsertMedicine.Style["visibility"] = "hidden";
                }
                else if (role.RoleName == "Administrator")
                {
                    gvAllMedicines.Columns[4].Visible = false;
                }

                gvAllMedicines.DataSource = MedicineController.GetAllMedicines();
                gvAllMedicines.DataBind();
            }
        }

        protected void btnAddtoCart_Click(object sender, EventArgs e)
        {
            int medicineId = Int32.Parse((sender as Button).CommandArgument);
            Response.Redirect("/View/AddtoCartPage.aspx?id=" + medicineId);
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int medicineId = Int32.Parse((sender as Button).CommandArgument);
            Response.Redirect("/View/UpdateMedicine.aspx?id=" + medicineId);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int medicineId = Int32.Parse((sender as Button).CommandArgument);
            MedicineController.RemoveMedicine(medicineId);
            fetchData();
        }

        protected void btnInsertMedicine_Click(object sender, EventArgs e)
        {
            Response.Redirect("/View/InsertMedicine.aspx?id=");
        }
    }
}