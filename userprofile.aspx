<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userprofile.aspx.cs" Inherits="Library_Management_System.userprofile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-5">
                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                <img width="100" src="images/imgs/generaluser.png"/>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>User Registration</h4>
                                    <%-- we are using span for inline and asp label for dynamic content --%>
                                    <span>Account Status - <asp:Label class="badge badge-pill badge-info" ID="Label1" runat="server" Text="Your status info"></asp:Label></span>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                               <hr />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label for="TextBox1">Full Name</label>
                                <%-- wrap form-controls in form-group --%>
                                <div class="form-group">
                                   <asp:TextBox class="form-control" placeholder="Enter Full Name" ID="TextBox3" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label for="TextBox1">Date of Birth</label>
                                <div class="form-group">
                                   <asp:TextBox class="form-control" placeholder="Enter Date of Birth" ID="TextBox4" runat="server" TextMode="Date"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label for="TextBox1">Contact Number</label>
                                <div class="form-group">
                                   <asp:TextBox class="form-control" placeholder="Enter Contact Number" ID="TextBox1" runat="server" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label for="TextBox1">Email</label>
                                <div class="form-group">
                                   <asp:TextBox class="form-control" placeholder="Enter Email" ID="TextBox2" runat="server" TextMode="Email"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <label for="TextBox1">State</label>
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" ID="DropDownList1" runat="server">
                                        <asp:ListItem>Select</asp:ListItem>
                                        <asp:ListItem>Andhra Pradesh</asp:ListItem>
                                        <asp:ListItem>Maharasthra</asp:ListItem>
                                        <asp:ListItem>Bengal</asp:ListItem>
                                        <asp:ListItem>Odisha</asp:ListItem>
                                        <asp:ListItem>Uttar Pradesh</asp:ListItem>
                                        <asp:ListItem>Delhi</asp:ListItem>
                                        <asp:ListItem>Bihar</asp:ListItem>
                                        <asp:ListItem>Karnataka</asp:ListItem>
                                        <asp:ListItem>Kerala</asp:ListItem>
                                        <asp:ListItem></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label for="TextBox1">City</label>
                                <div class="form-group">
                                   <asp:TextBox class="form-control" placeholder="Enter City" ID="TextBox6" runat="server" ></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label for="TextBox1">Pincode</label>
                                <div class="form-group">
                                   <asp:TextBox class="form-control" placeholder="Enter Pincode" ID="TextBox7" runat="server" TextMode="Number" ></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <label>Full Address</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox5" placeholder="Enter Full Address" runat="server" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col text-center">
                                <h4><span class="badge badge-pill badge-info">Login Credentials</span></h4>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <label>User Name</label>
                                <div class="form-group">
                                <asp:TextBox class="form-control" ID="TextBox8" placeholder="Enter User Name" runat="server" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Old Password</label>
                                <div class="form-group">
                                    <%-- dont keep the text mode as password otherwise it will not be viisble in user profile --%>
                                <asp:TextBox class="form-control" ID="TextBox9" placeholder="Enter Old Password" runat="server" TextMode="SingleLine" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>New Password</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox10" placeholder="Enter New Password" runat="server" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-8 mx-auto">
                                <%-- use mx-auto to guve uniform space inside a col or how many cols to that div specified --%>
                                <%-- for every form-control use form-group separately --%>
                                <div class="form-group text-center">
                                    <asp:Button class="btn btn-primary btn-lg btn-block" ID="Button1" runat="server" Text="Update" OnClick="Button1_Click" />
                                   
                               </div>
                            </div>
                        </div>
                    </div>

                </div>
                <a href="home.aspx"><< Back to Home</a><br /><br />
            </div>
            <div class="col-md-7">
                    <div class="card">
                        <div class="card-body">
                            <div class="row">
                            <div class="col">
                                <center>
                                <img width="100" src="images/imgs/books1.png"/>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Your Issued Books</h4>
                                    <%-- we are using span for inline and asp label for dynamic content --%>
                                    <span><asp:Label class="badge badge-pill badge-info" ID="Label2" runat="server" Text="Your books status info"></asp:Label></span>
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
                                <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" OnRowDataBound="GridView1_RowDataBound"></asp:GridView>
                            </div>
                        </div>
                        </div>
                    </div>
        </div>
        </div>
    </div>
</asp:Content>
