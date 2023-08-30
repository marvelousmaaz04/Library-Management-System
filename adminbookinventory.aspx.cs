using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library_Management_System
{
    public partial class adminbookinventory : System.Web.UI.Page
    {
        static string global_file_path;
        static int global_actual_stock, global_current_stock, global_issued_books;
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // for postback we dont want the ddl to be filled again and select 1st value only
                fillAuthorPublisherValues();
                GridView1.DataBind();
            }
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkIfBookExists())
            {
                Response.Write("<script>alert('Book already exists! Please upload a different book.');</script>");
            }
            else
            {
                addNewBook();
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkIfBookExists())
            {
                updateBook();
            }
            else
            {
                Response.Write("<script>alert('Book does not exist.');</script>");
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkIfBookExists())
            {
                deleteBook();
            }
            else
            {
                Response.Write("<script>alert('Book does not exist.');</script>");
            }
        }
        // go button
        protected void Button1_Click(object sender, EventArgs e)
        {
            getBookByID();
        }

        // udfs

        void deleteBook()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("delete from book_master_tbl where book_id='" + TextBox1.Text.Trim() + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Book deleted successfully!');</script>");
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            }
        void updateBook()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("select * from book_master_tbl where book_id='" + TextBox1.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                global_actual_stock = Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString().Trim());
                global_current_stock = Convert.ToInt32(dt.Rows[0]["current_stock"].ToString().Trim());
                global_issued_books = global_actual_stock - global_current_stock;
                global_file_path = dt.Rows[0]["book_img_link"].ToString();


                int actual_stock = Convert.ToInt32(TextBox7.Text.Trim());
                int current_stock = Convert.ToInt32(TextBox8.Text.Trim());

                if(global_actual_stock == actual_stock)
                {

                }
                else
                {
                    if(actual_stock < global_issued_books)
                    {
                        Response.Write("<script>alert('Actual stock cannot be less than Total Issued Books');</script>");
                    }
                    else
                    {
                        current_stock = actual_stock  - global_issued_books;
                        TextBox8.Text = "" + current_stock;
                    }
                }

                string genres = "";
                foreach (int i in ListBox1.GetSelectedIndices())
                {
                    genres = genres + ListBox1.Items[i].ToString() + ",";
                }
                genres.Remove(genres.Length - 1);

                string filepath = "~/bookinventory/books.png";
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                if(filename == "" || filename == null)
                {
                    filepath = global_file_path;
                }
                else
                {
                    FileUpload1.SaveAs(Server.MapPath("~/bookinventory/" + filename));
                    filepath = "~/bookinventory/" + filename;
                }

                //SqlConnection con = new SqlConnection(strcon);
                //if (con.State == System.Data.ConnectionState.Closed)
                //{
                //    con.Open();
                //}
                SqlCommand cmd1 = new SqlCommand("update book_master_tbl set book_name=@book_name,genre=@genre,author_name=@author_name,publisher_name=@publisher_name,publish_date=@publish_date,language=@language,edition=@edition,book_cost=@book_cost,no_of_pages=@no_of_pages,book_description=@book_description,actual_stock=@current_stock,current_stock=@current_stock,book_img_link=@book_img_link where book_id='"+TextBox1.Text.Trim()+"'", con);

               
                cmd1.Parameters.AddWithValue("@book_name", TextBox2.Text.Trim());
                cmd1.Parameters.AddWithValue("@genre", genres);

                cmd1.Parameters.AddWithValue("@author_name", DropDownList3.SelectedItem.Value);
                cmd1.Parameters.AddWithValue("@publisher_name", DropDownList2.SelectedItem.Value);
                cmd1.Parameters.AddWithValue("@publish_date", TextBox3.Text.Trim());
                cmd1.Parameters.AddWithValue("@language", DropDownList1.SelectedItem.Value);
                cmd1.Parameters.AddWithValue("@edition", TextBox4.Text.Trim());
                cmd1.Parameters.AddWithValue("@book_cost", TextBox5.Text.Trim());
                cmd1.Parameters.AddWithValue("@no_of_pages", TextBox6.Text.Trim());

                cmd1.Parameters.AddWithValue("@book_description", TextBox10.Text.Trim());
                cmd1.Parameters.AddWithValue("@actual_stock", actual_stock.ToString());
                cmd1.Parameters.AddWithValue("@current_stock", current_stock.ToString());
                cmd1.Parameters.AddWithValue("@book_img_link", filepath);

                cmd1.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Book updated successfully!');</script>");
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
        void getBookByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                //dont write query with id and name both because in case of update it return no result and update will not occur
                SqlCommand cmd = new SqlCommand("select * from book_master_tbl where book_id='" + TextBox1.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0]["book_name"].ToString(); // we can refer to col name directly also
                    TextBox3.Text = dt.Rows[0]["publish_date"].ToString();
                    TextBox4.Text = dt.Rows[0]["edition"].ToString();
                    TextBox5.Text = dt.Rows[0]["book_cost"].ToString().Trim(); // use trim() for number text boxes
                    TextBox6.Text = dt.Rows[0]["no_of_pages"].ToString().Trim();
                    TextBox7.Text = dt.Rows[0]["actual_stock"].ToString().Trim();
                    TextBox8.Text = dt.Rows[0]["current_stock"].ToString().Trim();
                    TextBox9.Text = ""+(Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString()) - Convert.ToInt32(dt.Rows[0]["current_stock"].ToString()));
                    TextBox10.Text = dt.Rows[0]["book_description"].ToString();



                    DropDownList1.SelectedValue = dt.Rows[0]["language"].ToString();
                    DropDownList2.SelectedValue = dt.Rows[0]["publisher_name"].ToString();
                    DropDownList3.SelectedValue = dt.Rows[0]["author_name"].ToString();

                    ListBox1.ClearSelection();
                    string[] genres = dt.Rows[0]["genre"].ToString().Split(',');

                    for(int i=0; i<genres.Length; i++)
                    {
                        for(int j=0;j< ListBox1.Items.Count; j++)
                        {
                            if (genres[i] == ListBox1.Items[j].ToString()) // ToString is imp
                            {
                                ListBox1.Items[j].Selected = true;
                            }
                        }
                    }

                    global_actual_stock = Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString().Trim());
                    global_current_stock = Convert.ToInt32(dt.Rows[0]["current_stock"].ToString().Trim());
                    global_issued_books = global_actual_stock - global_current_stock;
                    global_file_path = dt.Rows[0]["book_img_link"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Book does not exist');</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                
            }
        }

        void addNewBook()
        {
            try
            {
                string genres = "";
                foreach(int i in ListBox1.GetSelectedIndices())
                {
                    genres = genres + ListBox1.Items[i].ToString();
                    genres = genres + ",";
                }
                genres = genres.Remove(genres.Length - 1);

                
                // if book img is not chosen the we will get error
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.SaveAs(Server.MapPath("~/bookinventory/" + filename));
                string filepath = "~/bookinventory/" + filename;

                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("insert into book_master_tbl(book_id,book_name,genre,author_name,publisher_name,publish_date,language,edition,book_cost,no_of_pages,book_description,actual_stock,current_stock,book_img_link) values (@book_id,@book_name,@genre,@author_name,@publisher_name,@publish_date,@language,@edition,@book_cost,@no_of_pages,@book_description,@actual_stock,@current_stock,@book_img_link)", con);

                cmd.Parameters.AddWithValue("@book_id",TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@book_name", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@genre", genres);

                cmd.Parameters.AddWithValue("@author_name", DropDownList3.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publisher_name", DropDownList2.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publish_date", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@language", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@edition", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@book_cost", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@no_of_pages", TextBox6.Text.Trim());

                cmd.Parameters.AddWithValue("@book_description", TextBox10.Text.Trim());
                cmd.Parameters.AddWithValue("@actual_stock", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@current_stock", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@book_img_link", filepath);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Book added successfully!');</script>");
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        void fillAuthorPublisherValues()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if(con.State == System.Data.ConnectionState.Closed) {
                con.Open();}
                SqlCommand cmd = new SqlCommand("select author_name from author_master_tbl", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DropDownList3.DataSource = dt;
                // ddl can display only one col so we need to specify the col name
                DropDownList3.DataValueField = "author_name";
                DropDownList3.DataBind();

                cmd = new SqlCommand("select publisher_name from publisher_master_tbl", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                DropDownList2.DataSource = dt;
                // ddl can display only one col so we need to specify the col name
                DropDownList2.DataValueField = "publisher_name";
                DropDownList2.DataBind();
            }
            catch(Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        bool checkIfBookExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                //dont write query with id and name both because in case of update it return no result and update will not occur
                SqlCommand cmd = new SqlCommand("select * from book_master_tbl where book_id='" + TextBox1.Text.Trim() + "' or book_name='"+TextBox2.Text.Trim()+"'", con);
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