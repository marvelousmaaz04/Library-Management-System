<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="Library_Management_System.home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%-- for page specific js and custom css --%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <img src="images/imgs/home-bg.jpg" class="img-fluid"/>
    </section>
    <section>
        <div class="container">
            <div class="row">
                <div class="col-12">
                    <center>
                    <h2>Our Features</h2>
                    <p><b>Our 3 Primary Features :-</b></p>
                    </center>
                </div>
            </div>
            <div class="row">
                <%-- for width >= medium sized devices it take 4 cols else it will take entire row --%>
                <div class="col-md-4">
                    <center>
                    <img src="images/imgs/digital-inventory.png" width="150"/>
                    <h4>Digital Inventory</h4>
                        <%-- text-justify for eq space on l and r sides --%>
                    <p class="text-justify">Particular unaffected projection sentiments no my. Music marry as at cause party worth weeks. Saw how marianne graceful dissuade new outlived prospect followed. Uneasy no settle whence nature narrow in afraid.</p>
                    </center>
                </div>
                <div class="col-md-4">
                    <center>
                    <img src="images/imgs/search-online.png" width="150"/>
                    <h4>Search Books</h4>
                        <%-- text-justify for eq space on l and r sides --%>
                    <p class="text-justify">Particular unaffected projection sentiments no my. Music marry as at cause party worth weeks. Saw how marianne graceful dissuade new outlived prospect followed. Uneasy no settle whence nature narrow in afraid.</p>
                    </center>
                </div>
                <div class="col-md-4">
                    <center>
                    <img src="images/imgs/defaulters-list.png" width="150"/>
                    <h4>Defaulters List</h4>
                        <%-- text-justify for eq space on l and r sides --%>
                    <p class="text-justify">Particular unaffected projection sentiments no my. Music marry as at cause party worth weeks. Saw how marianne graceful dissuade new outlived prospect followed. Uneasy no settle whence nature narrow in afraid.</p>
                    </center>
                </div>
            </div>
        </div>
    </section>
    <section>
        <%-- use imgfluid for responsive images that occupy full width --%>
        <img src="images/imgs/in-homepage-banner.jpg" class="img-fluid" />
    </section>
    <section>
        <div class="container">
            <div class="row">
                <div class="col-12">
                    <center>
                    <h2>Our Process</h2>
                    <p><b>Simple 3 Step Process:-</b></p>
                    </center>
                </div>
            </div>
            <div class="row">
                <%-- for width >= medium sized devices it take 4 cols else it will take entire row --%>
                <div class="col-md-4">
                    <center>
                    <img src="images/imgs/sign-up.png" width="150"/>
                    <h4>Sign Up</h4>
                        <%-- text-justify for eq space on l and r sides --%>
                    <p class="text-justify">Particular unaffected projection sentiments no my. Music marry as at cause party worth weeks. Saw how marianne graceful dissuade new outlived prospect followed. Uneasy no settle whence nature narrow in afraid.</p>
                    </center>
                </div>
                <div class="col-md-4 text-center">
                    
                    <img src="images/imgs/search-online.png" width="150"/>
                    <h4>Search Books</h4>
                        <%-- text-justify for eq space on l and r sides --%>
                    <p class="text-justify">Particular unaffected projection sentiments no my. Music marry as at cause party worth weeks. Saw how marianne graceful dissuade new outlived prospect followed. Uneasy no settle whence nature narrow in afraid.</p>
                    
                </div>
                <div class="col-md-4">
                    <center>
                    <img src="images/imgs/library.png" width="150"/>
                    <h4>Visit Us</h4>
                        <%-- text-justify for eq space on l and r sides --%>
                    <p class="text-justify">Particular unaffected projection sentiments no my. Music marry as at cause party worth weeks. Saw how marianne graceful dissuade new outlived prospect followed. Uneasy no settle whence nature narrow in afraid.</p>
                    </center>
                </div>
            </div>
        </div>
    </section>

</asp:Content>
