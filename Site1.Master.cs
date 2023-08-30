using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library_Management_System
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            //when a content page is loaded the master page is also loaded and the page load event is called
            try
            {
                if (Session["role"] != null)
                {
                    if (Session["role"].Equals(""))
                    {
                        LinkButton2.Visible = true;
                        LinkButton3.Visible = true;

                        LinkButton4.Visible = false;
                        LinkButton5.Visible = false;

                        LinkButton6.Visible = true;
                        LinkButton7.Visible = false;
                        LinkButton8.Visible = false;
                        LinkButton9.Visible = false;
                        LinkButton10.Visible = false;
                        LinkButton11.Visible = false;
                    }
                    else if (Session["role"].Equals("user"))
                    {
                        LinkButton2.Visible = false;
                        LinkButton3.Visible = false;

                        LinkButton4.Visible = true;
                        LinkButton5.Visible = true;
                        LinkButton5.Text = "Hello, " + Session["username"].ToString();

                        LinkButton6.Visible = true;
                        LinkButton7.Visible = false;
                        LinkButton8.Visible = false;
                        LinkButton9.Visible = false;
                        LinkButton10.Visible = false;
                        LinkButton11.Visible = false;
                    }
                    else if (Session["role"].Equals("admin"))
                    {
                        LinkButton2.Visible = false;
                        LinkButton3.Visible = false;

                        LinkButton4.Visible = true;
                        LinkButton5.Visible = true;
                        LinkButton5.Text = "Hello, Admin";

                        LinkButton6.Visible = false;
                        LinkButton7.Visible = true;
                        LinkButton8.Visible = true;
                        LinkButton9.Visible = true;
                        LinkButton10.Visible = true;
                        LinkButton11.Visible = true;
                    }
                }
                
            }
            catch(Exception ex) 
            {
                Response.Write("alert('" + ex.Message + "')");
            }

            
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminlogin.aspx");
        }

        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminauthormanagement.aspx");
        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminpublishermanagement.aspx");
        }

        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminbookinventory.aspx");
        }

        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminbookissuing.aspx");
        }

        protected void LinkButton11_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminmembermanagement.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewbooks.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("userlogin.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("usersignup.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Session["username"] = "";
            Session["fullname"] = "";
            Session["role"] = "";
            Session["status"] = "";

            Response.Redirect("home.aspx");
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            Response.Redirect("userprofile.aspx");
        }
    }
}