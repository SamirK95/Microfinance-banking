<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IzvjestajOisplatama.aspx.cs" Inherits="Forme_IzvjestajOisplatama" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSS/izvjestajStyle.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="glavniDiv">

            <div id="naslovIsplate">
                <h3 id="naslovID">Izvještaj o isplaćenim mikrokreditima</h3>
            </div>

            <div id="slikaDiv">
                <img runat="server" src="~/ikone2/mibanking.png" id="mibankingID" style="width:110px;" />
            </div>
            <hr />
            
            <div id="formazaUnos2">
            <div id="isplateOdDatumaID">
                <asp:Label ID="lblIsplateOdDatuma" runat="server" Text="Isplate za period od"></asp:Label>
                <span class="tackice"></span>
                <asp:TextBox ID="txtIsplateOdDatuma" runat="server" Placeholder="  -  -"></asp:TextBox>
            </div>

            <div id="isplateDoDatumaID">
                <asp:Label ID="lblIsplateDoDatuma" runat="server" Text="Isplate za period do"></asp:Label>
                <span class="tackice"></span>
                <asp:TextBox ID="txtIsplateDoDatuma" runat="server" Placeholder="  -  -"></asp:TextBox>
            </div>
                
            <div id="odaberiteRegijuID">
                <asp:Label ID="lblOdaberiteRegiju" runat="server" Text="Odaberite regiju"></asp:Label>
                <span class="tackice"></span>
                <asp:DropDownList ID="ddlRegija" runat="server" style="float:right;height:25px;width:257px;border:2px solid #ccc;margin-top:2px;"></asp:DropDownList>

            </div>

            <div id="odaberitePodruznicuID">
                <asp:Label ID="lblOdaberitePodruznicu" runat="server" Text="Odaberite podružnicu"></asp:Label>
                <span class="tackice"></span>
                <asp:DropDownList ID="ddlOdaberitePodruznicu" runat="server"></asp:DropDownList>
            </div>

            <div id="odaberiteUredID">
                <asp:Label ID="lblOdaberiteUred" runat="server" Text="Odaberite ured"></asp:Label>
                <span class="tackice"></span>
                <asp:DropDownList ID="ddlOdaberiteUred" runat="server"></asp:DropDownList>
            </div>
                <hr />
            </div>

            <div id="dugmiciID">
                <div id="napustiID">
                    <asp:ImageButton ID="imgNapustiID" ImageUrl="~/Ikone/Napusti.png" runat="server" OnClick="imgNapustiID_Click" />
                    <span style="cursor:pointer">Napusti</span>
                </div>

                <div id="uradiIzvjestajID">
                    <span style="cursor:pointer">Uradi izvještaj</span>
                    <asp:ImageButton ID="imgUradiID" ImageUrl="~/Ikone/unesi.png" runat="server" OnClick="imgUradiID_Click" />     
                </div>

            </div>

            <br />

            <div id="ispisID">
            <asp:Label ID="lblIspis3" runat="server" Text=""></asp:Label>
        </div>

            <br />

        <div id="izvjestajDiv">
            <asp:GridView ID="gridViewID" runat="server" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
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
        <%--<div id="ispisID">
            <asp:Label ID="lblIspis3" runat="server" Text=""></asp:Label>
        </div>

        <div id="izvjestajDiv">
            <asp:GridView ID="gridViewID" runat="server" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
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
        </div>--%>
    </form>
</body>
</html>
