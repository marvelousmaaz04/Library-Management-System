using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library_Management_System
{
    public partial class userprofile : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Write("<script>alert('Session expired! Login Again')</script>");
                Response.Redirect("userlogin.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    // we should call this at first time only at get request it will be called every time the page is loaded or refreshed and updating wont happen properly
                    getUserPersonalDetails();
                }
                getUserBookData();
            }
        }
        // UPDATE
        protected void Button1_Click(object sender, EventArgs e)
        {

            if (Session["username"] == null)
            {
                Response.Write("<script>alert('Session expired! Login Again')</script>");
                Response.Redirect("userlogin.aspx");
            }
            else
            {
                updateUserData();
            }

        }

        void updateUserData()
        {
            try
            {
                string password = "";
                if(TextBox10.Text.Trim() == "")
                {
                    password = TextBox9.Text.Trim();
                }
                else
                {
                    password = TextBox10.Text.Trim();
                }
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("update member_master_tbl set full_name=@full_name,dob=@dob,contact_no=@contact_no,email=@email,state=@state,city=@city,pincode=@pincode,full_address=@full_address,member_id=@member_id,password=@password,account_status=@account_status where member_id='" + Session["username"] +"'", con); // member_id is imp

                cmd.Parameters.AddWithValue("@full_name",TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@dob", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@contact_no", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@email", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@state", DropDownList1.SelectedValue.ToString().Trim());
                cmd.Parameters.AddWithValue("@city", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@pincode", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@full_address", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@member_id", Session["username"]);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@account_status", "pending");

                int result = cmd.ExecuteNonQuery();
                if(result > 0)
                {
                    Response.Write("<script>alert('Details Updated Successfully!');</script>");
                    getUserPersonalDetails();
                    getUserBookData();
                    con.Close();
                }
                else
                {
                    Response.Write("<script>alert('Invalid Entry');</script>");
                }
                
            }
            catch(Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        void getUserPersonalDetails()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from member_master_tbl where member_id='" + Session["username"] + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                TextBox3.Text = dt.Rows[0]["full_name"].ToString();
                TextBox4.Text = dt.Rows[0]["dob"].ToString();
                TextBox1.Text = dt.Rows[0]["contact_no"].ToString();
                TextBox2.Text = dt.Rows[0]["email"].ToString();
                DropDownList1.SelectedValue = dt.Rows[0]["state"].ToString();
                TextBox6.Text = dt.Rows[0]["city"].ToString();
                TextBox7.Text = dt.Rows[0]["pincode"].ToString();
                TextBox5.Text = dt.Rows[0]["full_address"].ToString();
                TextBox8.Text = dt.Rows[0]["member_id"].ToString();
                TextBox9.Text = dt.Rows[0]["password"].ToString();

                Label1.Text = dt.Rows[0]["account_status"].ToString();

                if(Label1.Text == "active")
                {
                    Label1.Attributes.Add("class", "badge badge-pill badge-success");
                }
                if(Label1.Text == "pending")
                {
                    Label1.Attributes.Add("class", "badge badge-pill badge-warning");
                }
                if(Label1.Text == "deactive")
                {
                    Label1.Attributes.Add("class", "badge badge-pill badge-danger");
                }

            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void getUserBookData()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if(con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from book_issue_tbl where member_id='" + Session["username"] + "'",con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                GridView1.DataSource = dt;
                GridView1.DataBind();

            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if(e.Row.RowType == DataControlRowType.DataRow)
                {
                    DateTime dt = Convert.ToDateTime(e.Row.Cells[5].Text);
                    DateTime today = DateTime.Now;
                    if(today > dt)
                    {
                        e.Row.BackColor = System.Drawing.Color.PaleVioletRed;
                    }
                }
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}