<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PočetnaStranica.aspx.cs" Inherits="Forme_PočetnaStranica" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSS/PocetnaStyle.css" rel="stylesheet" type="text/css" />

    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css"/>

</head>
<body>
    <form id="form1" runat="server">
        <div id="glavniDiv">
            <div id="lineDiv">
                <hr id="hr1ID"/>
                <hr id="hr2ID"/>
                <hr id="hr3ID"/>
            </div>
            <header>
                
                
                <div id="infoLinija">
                <p id="infoID"><span class="span1Class">BESPLATNA</span> <span class="span2Class">INFO</span> <span><span class="span3Class">LINIJA</span>:</span> 0800 202 53</p>
                 
                    <div id="slikeID">
                        <a id="prviID" href="https://www.facebook.com/Sa05Kn12Kat95/"><img  id="fbID" src="~/ikone2/facebook.png" runat="server" /></a>

                        <a id="drugiID" href="https://www.instagram.com/samir.katanic/"><img  id="instaID" src="~/ikone2/instagram.png" runat="server"/></a>

                        <a id="treciID" href="https://www.linkedin.com/in/samir-katani%C4%87-8740b3256/"><img  id="ytID" src="~/ikone2/in.png" runat="server"/></a>

                        <a id="cetvrtiID" href="https://github.com/SamirK95"><img  id="gitID" src="~/ikone2/git.png" runat="server"/></a>
                        

                    </div>
                </div>

                <div class="navClass">
                    <ul>
                        <li><a href="#">Home</a></li>
                        <li><a href="NoviKomitent.aspx">Novi komitent</a></li>
                        <li><a href="DefinisanjeKredita.aspx">Novi kredit</a></li>
                        <li><a href="IzvjestajOisplatama.aspx">Izvjestaj o kreditima</a></li>
                        <li><a href="IsplateZaPeriodGrupisanPo.aspx">Isplate za period</a></li>
                        
                    </ul>
                </div>

                <div id="logoId">
                    <img id="logoIkonaID" src="~/ikone2/mibanking.png" runat="server" alt="slika nije učitana" />
                    <h2 id="natpisLogo">We belive in your success. Trust is our power! <br /> <br/>     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;     Mi-Banking is always there for you!</h2>
                    <div id="sloganID">

                </div>

                </div>
                <div>
                </div>

                  

            </header>
            
            <br />
            <section>
                <div>
                    <img id="mibospoID" runat="server" src="~/ikone2/BlogHeader.png" alt="Slika nije učitana"/>
                </div>
                
            </section>

            <footer>
                
                <div id="footerID">
                    <p id="prviP">Sva prava pridržana © 2023 by&nbsp; <a href="https://www.linkedin.com/in/samir-katanić-8740b3256/" class="aClass1"><span class="span4Class"><strong>Samir Katanić</strong></span></a></p>
                    <p id="drugiP">Kontakt informacije:<span class="span5Class"> </span><span class="span6class"> &nbsp;</span><strong><span class="span4Class">katanicsamir@gmail.com</span></strong></p>
                </div>
               
            </footer>

        </div>
    </form>
</body>
</html>
