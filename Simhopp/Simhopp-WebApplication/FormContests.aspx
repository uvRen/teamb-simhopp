<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormContests.aspx.cs" Inherits="Simhopp_WebApplication.FormContests" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 {
            height: 425px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 665px; height: 191px;">
    
        -<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1" Height="277px">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                <asp:BoundField DataField="date" HeaderText="date" SortExpression="date" />
                <asp:HyperLinkField DataNavigateUrlFields="id" DataNavigateUrlFormatString="FormResults.aspx?id={0}" Text="Results" />
            </Columns>
        </asp:GridView>
        <br />
        <br />
        <br />
        <br />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:db_teambConnectionString %>" ProviderName="<%$ ConnectionStrings:db_teambConnectionString.ProviderName %>" SelectCommand="select id, name, date from event"></asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
