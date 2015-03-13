<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormResult.aspx.cs" Inherits="Simhopp_WebApplication.FormResult" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:db_teambConnectionString %>" ProviderName="<%$ ConnectionStrings:db_teambConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [diver] WHERE ([id] = ?)" OnSelecting="SqlDataSource3_Selecting">
            <SelectParameters>
                <asp:QueryStringParameter DefaultValue="1" Name="id" QueryStringField="id" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource3">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                <asp:BoundField DataField="country" HeaderText="country" SortExpression="country" />
                <asp:BoundField DataField="sex" HeaderText="sex" SortExpression="sex" />
                <asp:BoundField DataField="age" HeaderText="age" SortExpression="age" />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
