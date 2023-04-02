using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forme_DefinisanjeKredita : System.Web.UI.Page
{
    //Uspostavljanje veze sa SQL-om
    SqlConnection sqlKonekcija = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
    SqlCommand cmd;
    SqlDataAdapter da;
    DataSet ds = new DataSet();
    string query, query2;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        //Funkcija GetRegija() će se pozvati samo ako stranica nije postBack-ovana.
        if (!IsPostBack)
        {

            GetRegija();

        }

    }
    // Funkcija za dobijanje podataka o regijama iz baze podataka i prikazivanje istih u DropDownList kontroli
    private void GetRegija()
    {
        /*u query varijablu smjestamo upit za dobijanje podataka o regijama
         SqlDataAdapter koristimo za izvršavanje upita i popunjavanje DataSet objekta sa podacima
        da.Fill(ds); Ovom komandom popunjavamo DataSet sa podacima iz baze podataka
        i zatim provjeravamo da li ima podataka u tabeli u DataSet objektu
        */
        query = "SELECT * FROM Regija";
        da = new SqlDataAdapter(query, sqlKonekcija);
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlRegija.DataSource = ds;
            ddlRegija.DataTextField = "Naziv";
            ddlRegija.DataValueField = "ID";
            ddlRegija.DataBind();

        }
    }
    //Ovo je funkcija koja se poziva ukoliko se odabere neka regija iz drop down liste
    private void GetPodruznica()
    {
        query2 = "SELECT * FROM Podruznica";
        da = new SqlDataAdapter(query, sqlKonekcija);
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlPodruznica.DataSource = ds;
            ddlPodruznica.DataTextField = "Naziv";
            ddlPodruznica.DataValueField = "ID";
            ddlPodruznica.DataBind();
        }
    }

    protected void ddlRegija_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Prvo ćemo očistiti DataSet objekat prije novog upita
        ds.Clear();
        // Naziv i vrijednost selektovane regije
        string getRegija, Naziv;
        Naziv = ddlRegija.SelectedItem.Text;
        getRegija = ddlRegija.SelectedValue.ToString();

        if (getRegija != "0")
        {
            query = "Select ID, Naziv from Podruznica where RegijaID='" + getRegija.ToString() + "'";
            da = new SqlDataAdapter(query, sqlKonekcija);
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlPodruznica.DataSource = ds;
                ddlPodruznica.DataTextField = "Naziv";
                ddlPodruznica.DataValueField = "ID";
                ddlPodruznica.DataBind();
            }
        }
        else
        {
            ddlPodruznica.DataBind();
        }

    }
    protected void ddlPodruznica_SelectedIndexChanged(object sender, EventArgs s)
    {
        ds.Clear();
        string getPodruznica, Naziv;
        Naziv = ddlPodruznica.SelectedItem.Text;
        getPodruznica = ddlPodruznica.SelectedValue.ToString();

        if (getPodruznica != "0")
        {
            query = "Select ID, Naziv from Ured where PodruznicaID='" + getPodruznica.ToString() + "'";
            da = new SqlDataAdapter(query, sqlKonekcija);
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlUred.DataSource = ds;
                ddlUred.DataTextField = "Naziv";
                ddlUred.DataValueField = "ID";
                ddlUred.DataBind();
            }
        }
        else
        {
            ddlUred.DataBind();
        }
    }

    protected void napusti2ID_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("http://localhost:57215/Forme/PočetnaStranica.aspx");
    }

    protected void unesi2ID_Click(object sender, ImageClickEventArgs e)
    {
        //Dodjeljivanje unesenih korisnickih vrijednosti u varijable 
        string brKredita = txtBrojKredita.Text.ToString();
        string jmbgKomitenta = txtKorisnikKredita.Text.ToString();
        decimal iznosKreditaC = Convert.ToDecimal(txtIznosKredita.Text.Trim(), CultureInfo.InvariantCulture);
        iznosKreditaC = Math.Round(iznosKreditaC, 2);
        int rokOtplate = int.Parse(txtRokOtplate.Text);
        decimal kamatnaStopa2 = Convert.ToDecimal(txtIznosKamatneStope.Text.Trim(), CultureInfo.InvariantCulture);
        kamatnaStopa2 = Math.Round(kamatnaStopa2, 1);

        // dohvati ID iz odabrane stavke u DropDownList-u
        int uredID = int.Parse(ddlUred.SelectedItem.Value);

        //Konekcija sa serverom
        string konekcija = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        SqlConnection sqlKonekcija = new SqlConnection(konekcija);
        //Otvaranje konekcije
        sqlKonekcija.Open();

        //Provjera da li unesena vrijednost u txtBox broj kredita ima vise od 15 karaktera
        if (brKredita.Length > 15)
        {
            lblIspis2.Text = "Broj kredita ne može imati više od 15 karaktera!";
            return;
        }

        // provjera postojanja broja kredita u bazi podataka ukoliko postoji da se ispise poruka u label
        string sqlProvjeraBrojaKredita = "SELECT COUNT(1) FROM Krediti WHERE BrojKredita=@BrojKredita";
        SqlCommand sqlKomandaProvjeraBrojaKredita = new SqlCommand(sqlProvjeraBrojaKredita, sqlKonekcija);
        sqlKomandaProvjeraBrojaKredita.Parameters.AddWithValue("@BrojKredita", brKredita);
        int brojPostojecihKredita = (int)sqlKomandaProvjeraBrojaKredita.ExecuteScalar();

        if (brojPostojecihKredita > 0)
        {
            lblIspis2.Text = "Broj kredita već postoji u bazi podataka!";
            return;
        }

        // provjera postojanja JMBG-a u bazi podataka ako ne postoji da se ispise poruka
        string sqlProvjeraJMBG = "SELECT COUNT(1) FROM Komitent WHERE JMBG=@JMBG";
        SqlCommand sqlKomandaProvjeraJMBG = new SqlCommand(sqlProvjeraJMBG, sqlKonekcija);
        sqlKomandaProvjeraJMBG.Parameters.AddWithValue("@JMBG", jmbgKomitenta);
        int brojPostojecihJMBG = (int)sqlKomandaProvjeraJMBG.ExecuteScalar();

        if (brojPostojecihJMBG == 0)
        {
            lblIspis2.Text = "Komitent sa unesenim JMBG-om ne postoji u bazi podataka!";
            return;
        }
        /*Unosim provjere ukoliko korisnik unese datum razlicitom syntaxom od sintakse SQL servera
         da se taj datum ipak prihvati i da se zatim konvertuje u sql sintaksu kako bi se pohranio u bazu podataka.*/
        string datumIsplate = txtDatumIsplate.Text.Trim();
        DateTime ispravanDatum = DateTime.MinValue; //postavljena defaultna vrijednost 
        string[] formatiDatuma = new[] { "yyyy-MM-dd", "MM-dd-yyyy" };
        bool ispravanFormat = false;
        foreach (var format in formatiDatuma)
        {
            if (DateTime.TryParseExact(datumIsplate, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out ispravanDatum))
            {
                ispravanFormat = true;
                break;
            }
        }

        if (!ispravanFormat)
        {
            lblIspis2.Text = "Unesite datum tipa sljedeceg formata: 2006-11-11 ili 11-11-2006";
            return;
        }

        // Ukoliko datum prođe validaciju, spremi ga u varijablu tipa DateTime
        DateTime datumZaSpremanje = ispravanDatum;

        // Konvertiraj datum u format koji se može spremiti u bazu podataka
        string datumZaBazu = datumZaSpremanje.ToString("yyyy-MM-dd");

        /*
        //Ovaj upit je probni za datum

        // dohvati datum rođenja komitenta iz baze podataka
        string sqlDohvatiDatumRodjenja = "SELECT DatumRodjenja FROM Komitent WHERE JMBG=@JMBG";
        SqlCommand sqlKomandaDohvatiDatumRodjenja = new SqlCommand(sqlDohvatiDatumRodjenja, sqlKonekcija);
        sqlKomandaDohvatiDatumRodjenja.Parameters.AddWithValue("@JMBG", jmbgKomitenta);
        DateTime datumRodjenja = (DateTime)sqlKomandaDohvatiDatumRodjenja.ExecuteScalar();

        // provjeri da li je komitent mlađi od 2004-01-01
        if (datumRodjenja > new DateTime(2004, 1, 1))
        {
            lblIspis2.Text = "Komitent je mlađi od 2004-01-01 i nije dozvoljen kredit!";
            return;
        }
        */


        //ukoliko smo prosli sve gore navedene uslove pravimo upit za unos novog korisnika
        string sqlUpit = "INSERT INTO Krediti (BrojKredita, KomitentJMBG, DatumIsplate, IznosIsplacenogKredita, " +
                             "RokOtplateKredita, KamatnaStopa, UredID) VALUES (@BrojKredita, @KomitentJMBG, @DatumIsplate, " +
                             "@IznosIsplacenogKredita, @RokOtplateKredita, @KamatnaStopa, @UredID)";
            //Komanda za izvršavanje upita
            SqlCommand sqlKomanda = new SqlCommand(sqlUpit, sqlKonekcija);
            //upis broja kredita
            sqlKomanda.Parameters.AddWithValue("@BrojKredita", brKredita);
            //upisujemo jmbg komitenta
            sqlKomanda.Parameters.AddWithValue("@KomitentJMBG", jmbgKomitenta);
            //upisujemo datum isplate kredita
            sqlKomanda.Parameters.AddWithValue("@DatumIsplate", datumIsplate);
            //upisujemo iznos isplacenog kredita
            sqlKomanda.Parameters.AddWithValue("@IznosIsplacenogKredita", iznosKreditaC);
            //upisujemo rok otplate kredita
            sqlKomanda.Parameters.AddWithValue("@RokOtplateKredita", rokOtplate);
            //upisujemo kamatnu stopu
            sqlKomanda.Parameters.AddWithValue("@KamatnaStopa", kamatnaStopa2);
            //Upisujemo u kojem uredu je obradjivan kredit
            sqlKomanda.Parameters.AddWithValue("@UredID", uredID);


            //Izvrsavanje upita 
            sqlKomanda.ExecuteNonQuery();
            //zatvaranje konekcije
            sqlKonekcija.Close();

            //Ispis u uspješnom pohranjivanju komitenta u bazu podataka
            lblIspis2.Text = "Uspješno ste pohranili podatke o kreditu u bazu podataka!";
            return;
 

    }

    protected void Obrisi2ID_Click(object sender, ImageClickEventArgs e)
    {
        string brKredita = txtBrojKredita.Text.ToString();


        // Konekcija sa serverom
        string konekcija = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        SqlConnection sqlKonekcija = new SqlConnection(konekcija);
        // Otvaranje konekcije
        sqlKonekcija.Open();

        // Provjera da li unesena vrijednost u txtBox broj kredita ima više od 15 karaktera
        if (brKredita.Length > 15)
        {
            lblIspis2.Text = "Broj kredita ne može imati više od 15 karaktera!";
            return;
        }

        // Provjera postojanja broja kredita u bazi podataka ukoliko postoji da se obrise ukoliko pritisnemo dugme
        string sqlProvjeraBrojaKredita = "SELECT COUNT(1) FROM Krediti WHERE BrojKredita=@BrojKredita";
        SqlCommand sqlKomandaProvjeraBrojaKredita = new SqlCommand(sqlProvjeraBrojaKredita, sqlKonekcija);
        sqlKomandaProvjeraBrojaKredita.Parameters.AddWithValue("@BrojKredita", brKredita);
        int brojPostojecihKredita = (int)sqlKomandaProvjeraBrojaKredita.ExecuteScalar();

        if (brojPostojecihKredita > 0)
        {
            // Brišemo podatke pomoću SQL upita ako broj kredita postoji
            string sqlBrisanjeKredita = "DELETE FROM Krediti WHERE BrojKredita=@BrojKredita";
            SqlCommand sqlKomandaBrisanjeKredita = new SqlCommand(sqlBrisanjeKredita, sqlKonekcija);
            sqlKomandaBrisanjeKredita.Parameters.AddWithValue("@BrojKredita", brKredita);
            sqlKomandaBrisanjeKredita.ExecuteNonQuery();

            lblIspis2.Text = "Podaci za broj kredita " + brKredita + " su uspješno izbrisani iz baze podataka!";
            return;
        }
    }

    protected void ispravi1_Click(object sender, ImageClickEventArgs e)
    {
        //Dodjeljivanje unesenih korisnickih vrijednosti u varijable 
        string brKredita = txtBrojKredita.Text.ToString();
        string jmbgKomitenta = txtKorisnikKredita.Text.ToString();
        decimal iznosKreditaC = Convert.ToDecimal(txtIznosKredita.Text.Trim(), CultureInfo.InvariantCulture);
        iznosKreditaC = Math.Round(iznosKreditaC, 2);
        int rokOtplate = int.Parse(txtRokOtplate.Text);
        decimal kamatnaStopa2 = Convert.ToDecimal(txtIznosKamatneStope.Text.Trim(), CultureInfo.InvariantCulture);
        kamatnaStopa2 = Math.Round(kamatnaStopa2, 1);

        // dohvati ID iz odabrane stavke u DropDownList-u
        int uredID = int.Parse(ddlUred.SelectedItem.Value);

        //Konekcija sa serverom
        string konekcija = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        SqlConnection sqlKonekcija = new SqlConnection(konekcija);
        //Otvaranje konekcije
        sqlKonekcija.Open();

        // provjera postojanja broja kredita  u bazi podataka ukoliko postoji izvrsiti update, ako ne ispisati poruku u labeli
        string sqlProvjeraKredita = "SELECT COUNT(1) FROM Krediti WHERE BrojKredita=@BrojKredita" ;
        SqlCommand sqlKomandaProvjeraKredita = new SqlCommand(sqlProvjeraKredita, sqlKonekcija);
        sqlKomandaProvjeraKredita.Parameters.AddWithValue("@BrojKredita", brKredita);
        int brojPostojecihKredita = (int)sqlKomandaProvjeraKredita.ExecuteScalar();
        

        if (brojPostojecihKredita == 0)
        {
            lblIspis2.Text = "Broj kredita koji ste unijeli ne postoji u bazi podataka.";
            return;
        }else if (brKredita.Length > 15)
        {
            lblIspis2.Text = "Unijeli ste u broj kredita više od maximalnih 15 karaktera. Provjerite unos!";
        }
        //provjera postojanja jmbg u bazi podataka ukoliko postoji izvrsiti update, ako ne ispisati poruku u labeli
        string sqlProvjeraJMBG = "SELECT COUNT(1) FROM Krediti WHERE KomitentJMBG=@KomitentJMBG";
        SqlCommand sqlKomandaProvjeraJMBG = new SqlCommand(sqlProvjeraJMBG, sqlKonekcija);
        sqlKomandaProvjeraJMBG.Parameters.AddWithValue("@KomitentJMBG", jmbgKomitenta);
        int brojPostojecihJMBG = (int)sqlKomandaProvjeraJMBG.ExecuteScalar();

        if(brojPostojecihJMBG == 0)
        {
            lblIspis2.Text = "Unešeni JMBG ne postoji u bazi podataka. Provjerite Vaš unos!";
            return;
        }
        if(jmbgKomitenta.Length < 13)
        {
            lblIspis2.Text = "Unijeli ste manje od 13 cifara u polje za JMBG. Svaki JMBG ima tacno 13 cifara. Provjerite Vaš unos.";
            return;
        }
        if(jmbgKomitenta.Length > 13)
        {
            lblIspis2.Text = "Unijeli ste više od 13 cifara u polje za JMBG. Svaki JMBG ima tacno 13 cifara. Provjerite Vaš unos.";
            return;
        }
        /*Unosim provjere ukoliko korisnik unese datum razlicitom syntaxom od sintakse SQL servera
         da se taj datum ipak prihvati i da se zatim konvertuje u sql sintaksu kako bi se pohranio u bazu podataka.*/
        string datumIsplate = txtDatumIsplate.Text.Trim();
        DateTime ispravanDatum = DateTime.MinValue; //postavljena defaultna vrijednost 
        string[] formatiDatuma = new[] { "yyyy-MM-dd", "MM-dd-yyyy" };
        bool ispravanFormat = false;
        foreach (var format in formatiDatuma)
        {
            if (DateTime.TryParseExact(datumIsplate, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out ispravanDatum))
            {
                ispravanFormat = true;
                break;
            }
        }

        if (!ispravanFormat)
        {
            lblIspis2.Text = "Unesite datum tipa sljedeceg formata: 2006-11-11 ili 11-11-2006";
            return;
        }

        // Ukoliko datum prođe validaciju, spremi ga u varijablu tipa DateTime
        DateTime datumZaSpremanje = ispravanDatum;

        // Konvertiraj datum u format koji se može spremiti u bazu podataka
        string datumZaBazu = datumZaSpremanje.ToString("yyyy-MM-dd");

        //ukoliko smo prosli sve gore navedene uslove pravimo upit za azuriranje postojeceg kredita
        string sqlUpit = "UPDATE Krediti SET BrojKredita=@BrojKredita, KomitentJMBG=@KomitentJMBG, DatumIsplate=@DatumIsplate," +
                         "IznosIsplacenogKredita=@IznosIsplacenogKredita, RokOtplateKredita=@RokOtplateKredita, KamatnaStopa=@KamatnaStopa " +
                         "WHERE BrojKredita=@BrojKredita AND KomitentJMBG=@KomitentJMBG";
        //Komanda za izvršavanje upita
        SqlCommand sqlKomanda = new SqlCommand(sqlUpit, sqlKonekcija);
        //upis broja kredita
        sqlKomanda.Parameters.AddWithValue("@BrojKredita", brKredita);
        //upisujemo jmbg komitenta
        sqlKomanda.Parameters.AddWithValue("@KomitentJMBG", jmbgKomitenta);
        //upisujemo datum isplate kredita
        sqlKomanda.Parameters.AddWithValue("@DatumIsplate", datumIsplate);
        //upisujemo iznos isplacenog kredita
        sqlKomanda.Parameters.AddWithValue("@IznosIsplacenogKredita", iznosKreditaC);
        //upisujemo rok otplate kredita
        sqlKomanda.Parameters.AddWithValue("@RokOtplateKredita", rokOtplate);
        //upisujemo kamatnu stopu
        sqlKomanda.Parameters.AddWithValue("@KamatnaStopa", kamatnaStopa2);
        //Upisujemo u kojem uredu je obradjivan kredit
        sqlKomanda.Parameters.AddWithValue("@UredID", uredID);
        //Izvrsavanje upita 
        sqlKomanda.ExecuteNonQuery();
        //zatvaranje konekcije
        sqlKonekcija.Close();

        //Ispis u uspješnom pohranjivanju komitenta u bazu podataka
        lblIspis2.Text = "Uspješno ste ažurirali podatke u bazi podataka.";
        return;
    }
}