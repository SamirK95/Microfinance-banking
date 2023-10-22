<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IsplateZaPeriodGrupisanPo.aspx.cs" Inherits="Forme_IsplateZaPeriodGrupisanPo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Isplate za period</title>
    <link href="../CSS/IsplateZaPeriodStyle.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="glavniDiv">

            <div id="naslovDiv">
                <h3 id="naslovID">Isplate za period grupisan po</h3>
            </div>
            
            <div id="slikaDiv">
                <img runat="server" src="~/ikone2/mibanking.png" id="mibankingID" style="width:110px;" />
            </div>

            <hr />

            <div id="formaZaUnos1">

            <div id="pocetniDatumDiv">
                <asp:Label ID="lblPocetniDatum" runat="server" Text="Unesite početni datum za izvještaj"></asp:Label>
                <span class="tackice"></span>
                <asp:TextBox ID="txtPocetniDatum" Placeholder="  -  -" runat="server"></asp:TextBox>
            </div>


            <div id="zavrsniDatumDiv">
                <asp:Label ID="lblZavrsniDatum" runat="server" Text="Unesite završni datum za izvještaj"></asp:Label>
                <span class="tackice"></span>
                <asp:TextBox ID="txtZavrsniDatum" Placeholder="  -  -" runat="server"></asp:TextBox>
            </div>

            <div id="grupisiPo1Div">
                <asp:Label ID="lblGrupisiPo1" runat="server" Text="Grupiši po (1)"></asp:Label>
                <span class="tackice"></span>
                <asp:DropDownList ID="ddlGrupisiPo1" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="Naziv" DataValueField="Naziv" ></asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:myConnectionString %>" SelectCommand="SELECT 'MI-BOSPO' AS Naziv
UNION
SELECT Naziv
FROM Podruznica
UNION
SELECT Naziv
FROM Regija"></asp:SqlDataSource>
            </div>

            <div id="grupisiPo2Div">
                <asp:Label ID="lblGrupisiPo2" runat="server" Text="Grupiši po (2)"></asp:Label>
                <span class="tackice"></span>
                <asp:DropDownList ID="ddlGrupisiPo2" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource2" DataTextField="Naziv" DataValueField="Naziv"></asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:myConnectionString %>" SelectCommand="SELECT Naziv
FROM Regija
WHERE Naziv != 'MI-BOSPO'
UNION
SELECT Naziv
FROM Podruznica
UNION
SELECT Naziv
FROM Ured
"></asp:SqlDataSource>
            </div>
                <hr />
             <div id="dugmiciID">

                 <div id="napustiID">
                     <asp:ImageButton ID="napustiImg" ImageUrl="~/Ikone/Napusti.png" runat="server" OnClick="napustiImg_Click"/>
                     <span id="napustiSpan">Napusti</span>
                 </div>
                 
                 <div id="uradiIzvjestajDiv">
                     <span id="uradiSpan">Uradi izvještaj</span>
                     <asp:ImageButton ID="uradiImg" ImageUrl="~/Ikone/unesi.png" runat="server" OnClick="uradiImg_Click" />
                 </div>
             </div>

        </div>
            <br />

        <div id="ispisID">
            <asp:Label ID="lblIspis4" runat="server" Text=""></asp:Label>
        </div>

            <br />

        <div id="izvjestajiID">
            <asp:GridView ID="izvjestajID" runat="server" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#FFF1D4" />
                <SortedAscendingHeaderStyle BackColor="#B95C30" />
                <SortedDescendingCellStyle BackColor="#F1E5CE" />
                <SortedDescendingHeaderStyle BackColor="#93451F" />
            </asp:GridView>

            <br />

            <div id="Izvjestaji2ID">
                <asp:GridView ID="izvjestaj2ID" runat="server" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
                    <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                    <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                    <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#FFF1D4" />
                    <SortedAscendingHeaderStyle BackColor="#B95C30" />
                    <SortedDescendingCellStyle BackColor="#F1E5CE" />
                    <SortedDescendingHeaderStyle BackColor="#93451F" />
                </asp:GridView>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
