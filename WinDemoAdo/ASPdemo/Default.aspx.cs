using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataLayer;


namespace ASPdemo
{
    public partial class Site1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string connString = DataLayer.DB.ConnectionString;
            DataLayer.DB.ApplicationName = "ASP Application";
            DataLayer.DB.ConnectionTimeout = 25;
            SqlConnection conn = DataLayer.DB.GetSqlConnection();
        }

        protected void LinkButtonGetEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                DataLayer.Employees es = new DataLayer.Employees();
                DataLayer.Employee employee = es.GetEmployee(int.Parse(EmployeeID.Text));

                TextBoxFName.Text = employee.FirstName;
                TextBoxLName.Text = employee.LastName;
                TextBoxJobTitle.Text = employee.JobTitle;
            }
            catch { }
        }
    }
}