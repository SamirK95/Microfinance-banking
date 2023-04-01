<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DefinisanjeKredita.aspx.cs" Inherits="Forme_DefinisanjeKredita" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSS/DefinisanjeKreditaStil.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style1 {
            font-weight: normal;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="glavniDiv">

            <div id="naslovDiv">
                <h3 id="naslovID" class="auto-style1">Definisanje kredita</h3>
            </div>
            
            <div id="slikaDiv">
                <img runat="server" src="~/ikone2/mibanking.png" id="mibankingID" style="width:110px;" />
            </div>

            <hr />

            <div id="formaZaUnos1">
                <br />
            <div id="brojKreditaDiv">
                <asp:Label ID="lblBrojKredita" runat="server" Text="Unesite broj kredita"></asp:Label>
                <span class="tackice"></span>
                <asp:TextBox ID="txtBrojKredita" runat="server"></asp:TextBox>
            </div>

            <div id="korisnikKreditaDiv">
                <asp:Label ID="lblKorisnikKredita" runat="server" Text="Unesite JMBG korisnika kredita"></asp:Label>
                <span class="tackice"></span>
                <asp:TextBox ID="txtKorisnikKredita" runat="server"></asp:TextBox>
            </div>
            <hr />

            <div id="datumIsplateDiv">
                <asp:Label ID="lblDatumIsplate" runat="server" Text="Unesite datum isplate kredita"></asp:Label>
                <span class="tackice"></span>
                <asp:TextBox ID="txtDatumIsplate" Placeholder=" -  -" runat="server"></asp:TextBox>
            </div>


            <div id="iznosKreditaDiv">
                <asp:Label ID="lblIznosKredita" runat="server" Text="Unesite iznos kredita"></asp:Label>
                <span class="tackice"></span>
                <asp:TextBox ID="txtIznosKredita" Placeholder="0,00" runat="server"></asp:TextBox>
            </div>


            <div id="rokOtplateKreditaDiv">
                <asp:Label ID="lblRokOtplate" runat="server" Text="Unesite rok otplate kredita"></asp:Label>
                <span class="tackice"></span>
                <asp:TextBox ID="txtRokOtplate" Placeholder="0" runat="server"></asp:TextBox>
                <span class="desnoPoravnanje">(mjeseci)</span>
                
            </div>


            <div id="iznosKamatneStopeDiv">
                <asp:Label ID="lblIznosKamatneStope" runat="server" Text="Unesite iznos kamatne stope"></asp:Label>
                <span class="tackice"></span>
                <asp:TextBox ID="txtIznosKamatneStope" Placeholder="0" runat="server"></asp:TextBox>
                <span class="desnoPoravnanje">(%)</span>
            </div>
            <hr />
            <div id="regijaDiv">
                <asp:Label ID="lblRegija" runat="server" Text="Unesite regiju"></asp:Label>
                <span class="tackice"></span>
                <asp:DropDownList id="ddlRegija" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlRegija_SelectedIndexChanged" ></asp:DropDownList>
                
            </div>
            <div id="podruznicaDiv">
                <asp:Label ID="lblPodruznica" runat="server" Text="Unesite podruznicu"></asp:Label>
                <span class="tackice"></span>
                <asp:DropDownList id="ddlPodruznica" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPodruznica_SelectedIndexChanged"></asp:DropDownList>
                
            </div>
            <div id="uredDiv">
                <asp:Label ID="lblUred" runat="server" Text="Unesite ured"></asp:Label>
                <span class="tackice"></span>
                <asp:DropDownList id="ddlUred" runat="server" AutoPostBack="True" ></asp:DropDownList>
                
            </div>

                <hr />    


                <div id="dugmiciID">
                <div id="napustiID">
                    <asp:ImageButton ID="napusti2ID" ImageUrl="~/Ikone/Napusti.png" runat="server" OnClick="napusti2ID_Click" />
                    <span class="dugmiciSpan">Napusti</span>
                   </div>

                <div id="obrisiID">
                    <span class="dugmiciSpan">Obriši</span>
                    <asp:ImageButton ID="Obrisi2ID" ImageUrl="~/Ikone/obrisi.png" runat="server" OnClick="Obrisi2ID_Click" />
                </div>

                <div id="ispraviID">
                    <span class="dugmiciSpan">Ispravi</span>
                    <asp:ImageButton id="ispravi1" ImageUrl="~/Ikone/ispravi.png" runat="server" OnClick="ispravi1_Click" />
                </div>

                <div id="unesiID">
                    <span class="dugmiciSpan">Unesi</span>
                    <asp:ImageButton ID="unesi2ID" ImageUrl="~/Ikone/unesi.png" runat="server" OnClick="unesi2ID_Click" />
                </div>
           

                </div>

                <hr />

            </div>
            <br />
            <div id="divLblID">
            <asp:Label ID="lblIspis2" runat="server"></asp:Label>
        </div>
        </div>
        
    </form>
</body>
</html>
