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
    public partial class adminmembermanagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }
        //active
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            updateMemberStatusByID("active");
        }
        // go 
        protected void Button1_Click(object sender, EventArgs e)
        {
            getMemberByID();
        }
        //pending
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            updateMemberStatusByID("pending");
        }
        //deactive
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            updateMemberStatusByID("deactive");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            deleteMemberByID();
        }

        void getMemberByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if(con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from member_master_tbl where member_id='"+TextBox1.Text.Trim()+"'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while(dr.Read())
                    {
                        TextBox2.Text = dr.GetValue(0).ToString();
                        TextBox3.Text = dr.GetValue(10).ToString();
                        TextBox4.Text = dr.GetValue(1).ToString();
                        TextBox5.Text = dr.GetValue(2).ToString();
                        TextBox6.Text = dr.GetValue(3).ToString();
                        TextBox7.Text = dr.GetValue(4).ToString();
                        TextBox8.Text = dr.GetValue(5).ToString().Trim(); // make sure that we have appropriate text mode applied
                        TextBox9.Text = dr.GetValue(6).ToString();
                        TextBox10.Text = dr.GetValue(7).ToString();
                    }
                }
                else
                {
                    Response.Write("<script>alert('No such member exists!');</script>");
                }
            }
            catch(Exception ex)
            {
                Response.Write("alert('"+ ex.ToString() + "')");
            }
        }
        void updateMemberStatusByID(string status)
        {
            if (checkIfMemberExists())
            {


                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == System.Data.ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("update member_master_tbl set account_status='" + status + "' where member_id='" + TextBox1.Text.Trim() + "'", con);
                    cmd.ExecuteNonQuery(); // dont forget to execute the method
                    GridView1.DataBind();
                    Response.Write("<script>alert('Member Status Updated Successfully!');</script>");
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.ToString() + "');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid Member ID!');</script>");
            }
        }

        void deleteMemberByID()
        {
            if (checkIfMemberExists())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == System.Data.ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("delete from member_master_tbl where member_id='" + TextBox1.Text.Trim() + "'", con);
                    cmd.ExecuteNonQuery(); // dont forget to execute the query
                    GridView1.DataBind();
                    Response.Write("<script>alert('Member Deleted Permanently!');</script>");
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.ToString() + "');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid Member ID!');</script>");
            }
            
        }

        bool checkIfMemberExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                //dont write query with id and name both because in case of update it return no result and update will not occur
                SqlCommand cmd = new SqlCommand("select * from member_master_tbl where member_id='" + TextBox1.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }
    }
}