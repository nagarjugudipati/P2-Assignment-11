using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace WebAppAssignment11
{
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ContentDbConnectionString"].ToString());
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = con;

                cmd.CommandText = "insert into Articles values (@id, @title, @content, @publishdate)";

                cmd.Parameters.AddWithValue("@id", int.Parse(TxtId.Text));

                cmd.Parameters.AddWithValue("@title", TxtTitle.Text);

                cmd.Parameters.AddWithValue("@content", TxtContent.Text);

                cmd.Parameters.AddWithValue("@publishdate", DateTime.Parse(TxtPDate.Text));

                con.Open();

                cmd.ExecuteNonQuery();

                lblMsg.Text = "Registration Success";
            }


            catch (Exception ex)

            {

                lblMsg.Text = "Error" + ex.Message;

            }
        }
    }
}