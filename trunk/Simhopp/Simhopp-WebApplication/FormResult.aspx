<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormResult.aspx.cs" Inherits="Simhopp_WebApplication.FormResult" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource2">
            <Columns>
                <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:db_teambConnectionString %>" OnSelecting="SqlDataSource2_Selecting" ProviderName="<%$ ConnectionStrings:db_teambConnectionString.ProviderName %>" SelectCommand="select name from diver"></asp:SqlDataSource>
    </form>
</body>
</html>
