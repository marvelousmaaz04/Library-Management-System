<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminmembermanagement.aspx.cs" Inherits="Library_Management_System.adminmembermanagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        })
    </script>
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
                                    <h4>Member Details</h4>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="150" src="images/imgs/generaluser.png" />
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>
                         <div class="row">
                            <div class="col-md-3">
                                <label>Member ID</label>
                                <div class="form-group">
                                    <div class="form-group">
                                        <div class="input-group">
                                        <asp:TextBox CssClass="form-control mr-1" placeholder="Member ID" ID="TextBox1" runat="server"></asp:TextBox>
                                            <asp:Button class="btn btn-primary" ID="Button1" runat="server" Text="GO" OnClick="Button1_Click" />
                                            </div>
                                    </div>
                                </div>
                            </div>
                             <div class="col-md-4">
                                <label>Full Name</label>
                                <div class="form-group">
                                    
                                        
                                        <asp:TextBox CssClass="form-control" placeholder="Full Name" ID="TextBox2" runat="server" ReadOnly="True"></asp:TextBox>
                                            
                                            
                                    
                                </div>
                            </div>
                             <div class="col-md-5">
                                <label>Account Status</label>
                                <div class="form-group">
                                    
                                        <div class="input-group">
                                        <asp:TextBox CssClass="form-control mr-1" placeholder="Account Status" ID="TextBox3" runat="server" ReadOnly="True"></asp:TextBox>
                                            <%-- fontawesome icons do not work with normal asp:button --%>
                                            <asp:LinkButton class="btn btn-success mr-1" ID="LinkButton1" runat="server" OnClick="LinkButton1_Click"><i class="fa-regular fa-circle-check"></i></asp:LinkButton>
                                            <asp:LinkButton class="btn btn-warning mr-1" ID="LinkButton3" runat="server" OnClick="LinkButton3_Click"><i class="fa-regular fa-circle-pause"></i></asp:LinkButton>
                                            
                                            <asp:LinkButton class="btn btn-danger" ID="LinkButton2" runat="server" OnClick="LinkButton2_Click"><i class="fa-regular fa-circle-xmark"></i></asp:LinkButton>
                                            </div>
                                    
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                                <label>DOB</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" placeholder="DOB" ID="TextBox4" runat="server" ReadOnly="True" TextMode="Date"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Contact No.</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" placeholder="Contact No." ID="TextBox5" runat="server" ReadOnly="True" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-5">
                                <label>Email ID</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" placeholder="Email ID" ID="TextBox6" runat="server" ReadOnly="True" TextMode="Email"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <label>State</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" placeholder="State" ID="TextBox7" runat="server" ReadOnly="True" TextMode="SingleLine"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>City</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" placeholder="City" ID="TextBox8" runat="server" ReadOnly="True" ></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Pincode</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" placeholder="Pincode" ID="TextBox9" runat="server" ReadOnly="True" TextMode="Email"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <label>Full Postal Address</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" placeholder="Address" ID="TextBox10" runat="server" TextMode="MultiLine" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-8 mx-auto">
                                <asp:Button class="btn btn-danger btn-block btn-lg" ID="Button2" runat="server" Text="Delete User Permanently" OnClick="Button2_Click" />
                            </div>
                        </div>
                    </div>
                </div>
                <a href="home.aspx"><< Back to Home</a>
            </div>
            
            <div class="col-md-7">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                            <center>
                                <h4>Member List</h4>
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
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString %>" SelectCommand="SELECT * FROM [member_master_tbl]"></asp:SqlDataSource>
                                <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="member_id" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="member_id" HeaderText="ID" ReadOnly="True" SortExpression="member_id" />
                                        <asp:BoundField DataField="account_status" HeaderText="Status" SortExpression="account_status" />
                                        <asp:BoundField DataField="full_name" HeaderText="Name" SortExpression="full_name" />
                                        <asp:BoundField DataField="contact_no" HeaderText="Contact No" SortExpression="contact_no" />
                                        <asp:BoundField DataField="email" HeaderText="Email" SortExpression="email" />
                                        <asp:BoundField DataField="state" HeaderText="State" SortExpression="state" />
                                        <asp:BoundField DataField="city" HeaderText="City" SortExpression="city" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
