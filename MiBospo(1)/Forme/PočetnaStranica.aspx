<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PočetnaStranica.aspx.cs" Inherits="Forme_PočetnaStranica" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSS/PocetnaStyle.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style1 {
            color: #660066;
        }
        .auto-style2 {
            color: #FF6600;
        }
        .auto-style3 {
            color: #FFCC00;
        }
        .auto-style4 {
            text-decoration: none;
        }
        #logoIkonaID {
            height: 247px;
            width: 553px;
        }
        #sloganID {
            margin-left: 738px;
        }
        .newStyle1 {
            font-family: Arial, Helvetica, sans-serif;
            position: absolute;
        }
        .auto-style5 {
            color: blue;
        }
        .auto-style7 {
            font-size: x-large;
            color: #0066FF;
            font-weight: 700;
        }
        .auto-style8 {
            color: #0066FF;
        }
        /*Ovo ispod je probno */
        #logoIkonaID {
            max-width: 100%;
        }

        #sloganID {
            text-align: center;
        }
        .navClass{
            display:flex;
            width:100%;
        }
        .newStyle2{
            text-align:center;
        }

            .navClass {
            background-color: #0099CC;
            height: 46px;
            width: 100%;
            }
            .navClass ul {
            list-style: none;
            margin: 0;
            padding: 0;
            text-align: right; /* postavite na lijevu ili desnu stranu, ovisno o vašim potrebama */
             }

            .navClass ul li {
                display:inline-block;
                margin: 0;
                padding: 0;
                border-right: 1px solid #ccc; /* dodajte granicu ako želite */
                padding: 10px; /* dodajte odgovarajući razmak između elemenata */
                text-align:center;
                margin-left:10rem;
                font-family: 'Open Sans', sans-serif;
                
                
            }

            .navClass ul li:last-child {
                border-right: none; /* uklonite granicu za zadnji element */
            }

            .navClass ul li a {
                text-decoration: none;
                color: #333;
                font-weight: bold;
                display: block;
                padding: 5px;
            }

            /* Media query for small screens */
        @media only screen and (max-width: 600px) {
            #sloganID {
                margin-left: 0;
            }

            .newStyle1 {
                position: static;
                display: block;
                margin-bottom: 10px;
            }

            #prviID, #drugiID, #treciID {
                display: block;
                margin: 0 auto;
            }

            #navID {
                display: none;
            }
            li{
                display: flex;
                margin-top:10px;
                position:relative;
                float:left;
                margin-left:2px;
                font-weight:bolder;
                text-align:left;
                
            }
            #footerID, #prviP, #drugiP{
                display: flex;
                margin-top:10px;
                position:relative;
                float:left;
                margin-left:3px;

            }
            #logoIkonaID{
                visibility:hidden;
            }
            .navClass ul li {
            border-right: none;
            }
            
            
        }

        /* Media query for medium screens */
        @media only screen and (min-width: 601px) and (max-width: 960px) {
            #sloganID {
                margin-left: 0;
            }

            .newStyle1 {
                position: static;
                display: block;
                margin-bottom: 10px;
            }

            #prviID, #drugiID, #treciID {
                display: block;
                margin: 0 auto;
            }

            #navID {
                display: none;
            }
            li{
                display: flex;
                margin-top:10px;
                position:relative;
                float:left;
                margin-left:2px;
                
            }
            #footerID, #prviP, #drugiP{
                display: flex;
                margin-top:10px;
                position:relative;
                float:left;
                margin-left:3px;
            }
        }

        /* Media query for large screens */
        @media only screen and (min-width: 961px) {
            #sloganID {
                margin-left: 738px;
            }

            .newStyle1 {
                position: absolute;
            }

            #prviID, #drugiID, #treciID {
                display: inline-block;
                margin-right: 10px;
            }

            #navID {
                display: block;
            }
            li{
                display: flex;
                margin-top:10px;
                position:relative;
                float:left;
                
            }
            #footerID, #prviP, #drugiP{
                display: flex;
                margin-top:10px;
                position:relative;
                float:left;
            }
        }
        #footerID{
            background-color:
        #0066CC
        }
        

        .auto-style9 {
            font-size: large;
            color: #FFCC00;
        }
        

    </style>
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
                <p id="infoID"><span class="auto-style1">BESPLATNA</span> <span class="auto-style2">INFO</span> <span><span class="auto-style3">LINIJA</span>:</span> 0800 202 53</p>
                 
                    <div id="slikeID">
                        <a id="prviID" href="https://www.facebook.com/Sa05Kn12Kat95/"><img  id="fbID" src="~/ikone2/facebook.png" runat="server" /></a>

                        <a id="drugiID" href="https://www.instagram.com/samir.katanic/"><img  id="instaID" src="~/ikone2/instagram.png" runat="server"/></a>

                        <a id="treciID" href="https://www.linkedin.com/in/samir-katani%C4%87-8740b3256/"><img  id="ytID" src="~/ikone2/in.png" runat="server"/></a>
                    </div>
                </div>

                <div class="navClass">
                    <ul>
                        <li class="newStyle2" ><a href="#">Home</a></li>
                        <li class="newStyle2"><a href="NoviKomitent.aspx">Novi komitent</a></li>
                        <li class="newStyle2"><a href="DefinisanjeKredita.aspx">Novi kredit</a></li>
                        <li class="newStyle2"><a href="IzvjestajOisplatama.aspx">Izvjestaj o kreditima</a></li>
                        <li class="newStyle2"><a href="IsplateZaPeriodGrupisanPo.aspx">Isplate za period</a></li>
                        
                    </ul>
                </div>

                <div id="logoId">
                    <img id="logoIkonaID" src="~/ikone2/mibanking.png" runat="server" alt="slika nije učitana" /><h2 style="width: 591px; z-index: 1; left: 751px; top: 162px; position: absolute; height: 25px; color: #0066FF; font-size: x-large">We belive in your success. Trust is our power! <br /> <br/>     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;     Mi-Banking is always there for you!</h2>
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
                    <p id="prviP">Sva prava pridržana © 2023 by&nbsp; <a href="https://www.linkedin.com/in/samir-katanić-8740b3256/" class="auto-style4"><span class="auto-style9"><strong>Samir Katanić</strong></span></a></p>
                    <p id="drugiP">Kontakt informacije:<span class="auto-style5"> </span><span class="auto-style2"> &nbsp;</span><strong><span class="auto-style9">katanicsamir@gmail.com</span></strong></p>
                </div>
               
            </footer>

        </div>
    </form>
</body>
</html>
