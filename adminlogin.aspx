<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminlogin.aspx.cs" Inherits="Library_Management_System.adminlogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-6 mx-auto">
                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                <img width="150" src="images/imgs/adminuser.png"/>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>Admin Login</h3>
                                
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                               <hr />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                               <div class="form-group">
                                   <label for="TextBox1">Admin ID</label>
                                   <asp:TextBox class="form-control" placeholder="Enter Admin ID" ID="TextBox1" runat="server"></asp:TextBox>
                                   
                               </div>
                                <%-- for every form-control use form-group separately --%>
                                <div class="form-group">
                                   <label for="TextBox2">Password</label>
                                   <asp:TextBox class="form-control" placeholder="Enter Password" ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
                                   
                               </div>
                                <div class="form-group">
                                    <asp:Button class="btn btn-success btn-block btn-lg" ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" />
                                   
                               </div>
                                
                            </div>
                        </div>
                    </div>
                </div>
                <a href="home.aspx"><< Back to Home</a><br /><br />
            </div>
        </div>
        

    </div>
</asp:Content>
