<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormResults.aspx.cs" Inherits="Simhopp_WebApplication.FormResults" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label3" runat="server" style="text-align: center; color: #FFFFFF; font-size: x-large; background-color: #5D7B9D" Text="Competition" Width="100%"></asp:Label>
    
        <asp:GridView ID="GridView3" runat="server" CellPadding="4" DataSourceID="SqlDataSource3" ForeColor="#333333" GridLines="None" Width="100%">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
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
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:db_teambConnectionString %>" ProviderName="<%$ ConnectionStrings:db_teambConnectionString.ProviderName %>" SelectCommand="SELECT name, location, DATE_FORMAT(date, '%Y-%m-%d') AS date FROM event WHERE event.id =?">
           <SelectParameters>
           <asp:QueryStringParameter Name="id" QueryStringField="id" />
            </SelectParameters>
        </asp:SqlDataSource>
    
        <asp:Label ID="Label2" runat="server" style="text-align: center; font-size: x-large; color: #FFFFFF; background-color: #5D7B9D" Text="Results" Width="100%"></asp:Label>
        
        
        <asp:ScriptManager ID="ScriptManager1" runat="server">
         </asp:ScriptManager>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
       
       <ContentTemplate>
          
        <asp:Timer ID="Timer1" runat="server" Interval="60" ontick="Timer1_Tick"></asp:Timer>

        <asp:GridView ID="GridView2" runat="server" DataSourceID="SqlDataSource2" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <EditRowStyle BackColor="#999999" HorizontalAlign="Center" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" HorizontalAlign="Center" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
           </ContentTemplate>

        </asp:UpdatePanel>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:db_teambConnectionString %>" ProviderName="<%$ ConnectionStrings:db_teambConnectionString.ProviderName %>" SelectCommand="SELECT * FROM
	(SELECT diver.name, SUM(dive.totalScore) as tscore FROM diver LEFT JOIN dive ON diver.id = dive.diverId WHERE diver.id IN (SELECT diverId FROM event_diver WHERE eventId = ?) GROUP BY diver.id) AS mekk ORDER BY tscore DESC">
              <SelectParameters>
           <asp:QueryStringParameter Name="id" QueryStringField="id" />
            </SelectParameters>

        </asp:SqlDataSource>
    
        <asp:Label ID="Label1" runat="server" style="text-align: center; color: #FFFFFF; font-size: x-large; background-color: #5D7B9D" Text="Latest Jump" Width="100%"></asp:Label>
    
    </div>
        
            
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <asp:Timer ID="Timer2" runat="server" Interval="60" ontick="Timer1_Tick"></asp:Timer>

        <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" DataKeyNames="id" HorizontalAlign="Left" width="100%" AllowSorting="True" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateColumns="False">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                <asp:BoundField DataField="country" HeaderText="country" SortExpression="country" />
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
        </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
