<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NoviKomitent.aspx.cs" Inherits="Forme_NoviKomitent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Novi Komitent</title>
    <link href="../CSS/KomitentStil.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="glavniDiv">

            
            <div id="naslovDiv">
                <h3 id="naslovID">Definisanje novog komitenta</h3>
            </div>
            
            <div id="slikaDiv">
                <img runat="server" src="~/ikone2/mibanking.png" id="mibankingID" style="width:110px;" />
            </div>

            <hr />

            <div id="formaZaUnos1">
                <br />
            <div id="JMBGDiv">
                <asp:Label ID="lblJMBG" runat="server" Text="Unesite JMBG komitenta"></asp:Label>
                <span class="tackice"></span>
                <asp:TextBox ID="txtJMBG" runat="server"></asp:TextBox>
            </div>


            <div id="imeDiv">
                <asp:Label ID="lblIme" runat="server" Text="Unesite ime komitenta"></asp:Label>
                <span class="tackice"></span>
                <asp:TextBox ID="txtImeKomitenta" runat="server"></asp:TextBox>
            </div>


            <div id="prezimeDiv">
                <asp:Label ID="lblPrezime" runat="server" Text="Unesite prezime komitenta"></asp:Label>
                <span class="tackice"></span>
                <asp:TextBox ID="txtPrezime" runat="server"></asp:TextBox>
            </div>

            <div id="gradDiv">
                <asp:Label ID="lblGrad" runat="server" Text="Unesite grad komitenta"></asp:Label>
                <span class="tackice"></span>
                <asp:DropDownList ID="ddlGrad" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="Naziv" DataValueField="Naziv" >
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:myConnectionString %>" SelectCommand="SELECT [Naziv] FROM [Grad]"></asp:SqlDataSource>
            </div>


            <div id="adresaDiv">
                <asp:Label ID="lblAdresa" runat="server" Text="Unesite adresu komitenta"></asp:Label>
                <span class="tackice"></span>
                <asp:TextBox ID="txtAdresa" runat="server"></asp:TextBox>
            </div>

            
                <br />
                <hr />

            <div id="dugmiciID">
                <div id="napustiID">
                    <asp:ImageButton id="napustiImg" ImageUrl="~/Ikone/Napusti.png" runat="server" OnClick="napustiImg_Click" />
                    <span>Napusti</span>
                   </div>

                <div id="obrisiID">
                    <span>Obriši</span>
                    <asp:ImageButton ID="obrisiImg" ImageUrl="~/Ikone/obrisi.png" runat="server" OnClick="obrisiImg_Click" />
                </div>

                <div id="ispraviID">
                    <span>Ispravi</span>
                    <asp:ImageButton id="ispravi1" ImageUrl="~/Ikone/ispravi.png" runat="server" OnClick="ispravi1_Click" />
                </div>

                <div id="unesiID">
                    <span>Unesi</span>
                    <asp:ImageButton ID="unesiImg" ImageUrl="~/Ikone/unesi.png" runat="server" OnClick="unesiImg_Click" />
                </div>
            </div>
                

            </div>

           
            
        
        </div>
        <div id="labelZaGreskeID">
            <asp:Label ID="lblIspis" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
