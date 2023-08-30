<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="usersignup.aspx.cs" Inherits="Library_Management_System.usersignup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-10 mx-auto">
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
                            <div class="col-md-6">
                                <label>User Name</label>
                                <div class="form-group">
                                <asp:TextBox class="form-control" ID="TextBox8" placeholder="Enter User Name" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Password</label>
                                <div class="form-group">
                                <asp:TextBox class="form-control" ID="TextBox9" placeholder="Enter Password" runat="server" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <%-- for every form-control use form-group separately --%>
                                <div class="form-group">
                                    <asp:Button class="btn btn-success btn-block btn-lg" ID="Button1" runat="server" Text="Sign Up" OnClick="Button1_Click" />
                                   
                               </div>
                            </div>
                        </div>
                    </div>
                </div>
                <a href="home.aspx"><< Back to Home</a><br /><br />
            </div>
        </div>
        

    </div></asp:Content>
