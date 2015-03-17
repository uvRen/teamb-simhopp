<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormResults.aspx.cs" Inherits="Simhopp_WebApplication.FormResults" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" DataKeyNames="id" HorizontalAlign="Left" width="100%" AllowSorting="True" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateColumns="False">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" InsertVisible="False" ReadOnly="True" />
                <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                <asp:BoundField DataField="country" HeaderText="country" SortExpression="country" />
                <asp:BoundField DataField="sex" HeaderText="sex" SortExpression="sex" />
                <asp:BoundField DataField="age" HeaderText="age" SortExpression="age" />
                <asp:BoundField DataField="difficulty" HeaderText="difficulty" SortExpression="difficulty" />
                <asp:BoundField DataField="divename" HeaderText="divename" SortExpression="divename" />
                <asp:BoundField DataField="tscore" HeaderText="tscore" SortExpression="tscore" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:db_teambConnectionString %>" ProviderName="<%$ ConnectionStrings:db_teambConnectionString.ProviderName %>" 
            SelectCommand="SELECT diver.*, dive.difficulty, dd.divename, dive.totalScore as tscore FROM diver, dive, divetype, dd WHERE dd.diveno = divetype.type AND diver.id = dive.diverId AND divetype.id = 
            dive.divetypeid AND diver.id IN (SELECT diverId FROM event_diver WHERE eventId = ? AND dive.totalScore &gt; 0) ORDER BY dive.scored DESC">
             <SelectParameters>
           <asp:QueryStringParameter Name="id" QueryStringField="id" />
            </SelectParameters>
        </asp:SqlDataSource>
    </form>
</body>
</html>
