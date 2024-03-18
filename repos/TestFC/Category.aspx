<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="TestFC._Category" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1 id="aspnetTitle">Category&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="lblInfo" runat="server" Font-Size="Medium"></asp:Label>
            </h1>
            <div id="divInfo"  runat="server" >
    &nbsp;</div>
            <p>Insert/Edit</p>
            <p>Name:<asp:TextBox ID="txtName" runat="server"></asp:TextBox>
&nbsp;Initial Value:<asp:TextBox ID="txtIniValue" runat="server"></asp:TextBox>
&nbsp;Final Value:<asp:TextBox ID="txtFinValue" runat="server"></asp:TextBox>
&nbsp;
                <asp:Button ID="btnSave" class="btn btn-success" runat="server" OnClick="btnSave_Click" Text="Save" />
&nbsp;&nbsp;
                <asp:Button ID="btnClear" class="btn btn-secondary" runat="server" OnClick="btnClear_Click" Text="Clear" />
                <asp:TextBox ID="txtIdCategory" runat="server" ReadOnly="True" Visible="False"></asp:TextBox>
                <asp:TextBox ID="txtdtInsert" runat="server" ReadOnly="True" Visible="False"></asp:TextBox>
            </p>
            <p class="lead">Categories&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </p>
            <p class="lead">
                <asp:GridView ID="gvCategory" CssClass="table table-bordered table-condensed table-responsive table-hover" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnRowCommand="gvCategory_OnRowCommand" >
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                    <Columns>
                        <asp:BoundField DataField="idCategory" HeaderText="Id" />
                        <asp:BoundField DataField="strName" HeaderText="Name" />
                        <asp:BoundField DataField="iniValue" HeaderText="Initial Value" DataFormatString="{0:c}" />
                        <asp:BoundField DataField="finValue" DataFormatString="{0:c}" HeaderText="Final Value" />
                        <asp:ButtonField Text="Edit" />
                        <asp:ButtonField CommandName="Deleting" Text="Delete" />
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#808080" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />
                </asp:GridView>
            </p>
        </section>

        <div class="row">
        </div>
    </main>

</asp:Content>
