using System;
//using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
//using System.Linq;
//using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forme_IzvjestajOisplatama : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
            //Dodavanje stavke "Sve regije na prvu poziciju u ddlRegija i postavljanje boje na plavo."
            ddlRegija.Items.Insert(0, new ListItem("Sve regije", ""));
            ddlRegija.ForeColor = System.Drawing.Color.Blue; //
        if (!IsPostBack)
        {
            // Dodavanje stavke "Sve regije" na prvu poziciju u ddlRegija i postavljanje boje na plavo 
            //ddlRegija.Items.Insert(0, new ListItem("Sve regije", ""));
            //ddlRegija.ForeColor = System.Drawing.Color.Blue; //
        }
    }

    protected void imgNapustiID_Click(object sender, ImageClickEventArgs e)
    {
        //Kada se pritisne dugmic napusti vraca nas na pocetnu stranicu 
        Response.Redirect("http://localhost:57215/Forme/PočetnaStranica.aspx");
    }

    protected void imgUradiID_Click(object sender, ImageClickEventArgs e)
    {
        //Postavljanje unesenih datuma u textboxove u varijable
        string datumOd = txtIsplateOdDatuma.Text.ToString();
        string datumDo = txtIsplateDoDatuma.Text.ToString();
        string regija = ddlRegija.Text.ToString();

        //Konekcija sa serverom
        string konekcija = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        SqlConnection sqlKonekcija = new SqlConnection(konekcija);
        //Otvaranje konekcije
        sqlKonekcija.Open();

        //Provjera da li postoji isplacen kredit u odredjenom periodu
        string sqlProvjera = "SELECT COUNT(1) FROM Krediti WHERE DatumIsplate BETWEEN @DatumOd AND @DatumDo";
        //Komanda za izvrsavanje upita za provjeru da li postoji isplacen kredit
        SqlCommand sqlProvjeraDatum = new SqlCommand(sqlProvjera, sqlKonekcija);

        /*funkcija za pravljenje propusta ukoliko se unese razlicita sintaksa od sql sintakse
         da se uneseni datum konvertuje u sql sintaksu ukoliko ne ispunjava ni jedan uslov ispisat ce se 
        poruka u label pogresan format datuma.*/
        DateTime datumOdSQL, datumDoSQL;
        string[] formati = { "dd-MM-yyyy", "MM-dd-yyyy", "yyyy-MM-dd", "yyyy-dd-MM" };
        if (!DateTime.TryParseExact(datumOd, formati, CultureInfo.InvariantCulture, DateTimeStyles.None, out datumOdSQL) ||
            !DateTime.TryParseExact(datumDo, formati, CultureInfo.InvariantCulture, DateTimeStyles.None, out datumDoSQL))
        {
            lblIspis3.Text = "Pogrešan format datuma.";
            return;
        }


        /*Prva linija definiše SQL upit koji će biti izvršen, a koristi parametar @DatumIsplate
         koji se očekuje da će biti postavljen na određenu vrijednost prije izvršavanja upita tako isto i za drugu liniju koda*/
        sqlProvjeraDatum.Parameters.AddWithValue("@DatumOd", datumOdSQL);
        sqlProvjeraDatum.Parameters.AddWithValue("@DatumDo", datumDoSQL);

        //konvertujem Datum u objekat a objekat u integer
        object countObj = sqlProvjeraDatum.ExecuteScalar();
        //Execute scalar u idućoj liniji koda vraća prvi red prvog stupca dobijenog iz upita kao rezultat.
        int count = Convert.ToInt32(countObj);

        //Provjera da li postoji isplacen kredit sa unesenim datumom u bazi podataka
        if (count == 0)
        {
            lblIspis3.Text = "Ne postoji kredit isplacen u tom periodu.";
            return;
        }
        //ukoliko smo prosli sve gore navedene uslove izvrsit ce se query koji ce prikazati izvjestaj o kreditima
        string sqlUpit = "SELECT KomitentJMBG, BrojKredita, DatumIsplate, IznosIsplacenogKredita, KamatnaStopa, RokOtplateKredita, " +
        "UredID FROM Krediti WHERE DatumIsplate BETWEEN @DatumOd AND @DatumDo";
        //Komanda za izvršavanje upita
        SqlCommand sqlKomanda = new SqlCommand(sqlUpit, sqlKonekcija);
        //Postavljamo vrijednost @DatumOd na vrijednost datumOdSQL u kojem smo izvrsili provjeru formata.
        sqlKomanda.Parameters.AddWithValue("@DatumOd", datumOdSQL);
        //Postavljamo vrijednost @DatumDo na vrijednost datumDoSQL u kojem smo izvrsili provjeru formata.
        sqlKomanda.Parameters.AddWithValue("@DatumDo", datumDoSQL);

        //Dohvaćanje podataka o kreditima u određenom periodu
        SqlDataAdapter da = new SqlDataAdapter(sqlKomanda);
        DataTable dt = new DataTable();
        da.Fill(dt);

        //Prikaz podataka u GridView kontroli
        gridViewID.DataSource = dt;
        gridViewID.DataBind();

        //Zatvaranje konekcije
        sqlKonekcija.Close();

        //Ispis u uspješnom pohranjivanju komitenta u bazu podataka
        lblIspis3.Text = "Podaci su prikazani u izvještaju koji se nalazi ispod ove forme.";



    }
    
}