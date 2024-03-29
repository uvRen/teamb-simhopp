﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormContests.aspx.cs" Inherits="Simhopp_WebApplication.FormContests" %>

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
    <div >
    
        <asp:Label ID="Label1" runat="server" style="text-align: center; font-size: x-large; color: #FFFFFF; background-color: #5D7B9D" Text="Events" Width="100%"></asp:Label>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1" Height="277px" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" HorizontalAlign="Center">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                <asp:BoundField DataField="date" HeaderText="date" SortExpression="date" />
                <asp:HyperLinkField DataNavigateUrlFields="id" DataNavigateUrlFormatString="FormResults.aspx?id={0}" Text="Results" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
 
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:db_teambConnectionString %>" ProviderName="<%$ ConnectionStrings:db_teambConnectionString.ProviderName %>"
             SelectCommand="SELECT id, name, DATE_FORMAT(date, '%Y-%m-%d') AS date FROM event"></asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
