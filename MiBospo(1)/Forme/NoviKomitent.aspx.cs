using System;
//using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
//using System.Linq;
//using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forme_NoviKomitent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    
    }

    protected void napustiImg_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("http://localhost:57215/Forme/PočetnaStranica.aspx");
    }

    protected void unesiImg_Click(object sender, ImageClickEventArgs e)
    {
        //Dodjeljivanje unesenih korisnickih vrijednosti u varijable 
        string jmbg = txtJMBG.Text.ToString();
        string ime = txtImeKomitenta.Text.ToString();
        string prezime = txtPrezime.Text.ToString();
        string adresa = txtAdresa.Text.ToString();

        /* Ovo je kod za unos datuma komitenta ali to smo ipak iskljucili 
        string datumString = txtDatumKomitent.Text;

        DateTime datum = DateTime.Parse(datumString);

        if (!DateTime.TryParse(datumString, out datum))
        {
            lblIspis.Text = "Unijeli ste neispravan format datuma. Molimo unesite datum u formatu dd.MM.yyyy.";
            return;
        }
        */

        //Konekcija sa serverom
        string konekcija = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        SqlConnection sqlKonekcija = new SqlConnection(konekcija);
        //Otvaranje konekcije
        sqlKonekcija.Open();

        //Provjera da li vec postoji osoba sa istim JMBG u bazi podataka ako postoji nece se izvrsiti unos
        string sqlProvjera = "SELECT COUNT(1) FROM Komitent WHERE JMBG=@JMBG";
        //Komanda za izvrsavanje upita za provjeru da li postoji osoba sa istim JMBG 
        SqlCommand sqlProvjeraJMBG = new SqlCommand(sqlProvjera, sqlKonekcija);

        /*Prva linija definiše SQL upit koji će biti izvršen, a koristi parametar @JMBG 
         koji se očekuje da će biti postavljen na određenu vrijednost prije izvršavanja upita*/
        sqlProvjeraJMBG.Parameters.AddWithValue("@JMBG", jmbg);
        //konvertujem jmbg u objekat a objekat u integer
        object countObj = sqlProvjeraJMBG.ExecuteScalar();
        //Execute scalar u idućoj liniji koda vraća prvi red prvog stupca dobijenog iz upita kao rezultat.
        int count = Convert.ToInt32(countObj);

        //Provjera da li postoji osoba sa unesenim JMBG u bazi podataka
        if (count > 0)
        {
            lblIspis.Text = "Osoba sa unešenim JMBG već postoji. Pokušajte sa UPDATE ukoliko želite ažurirati komitenta.";
            return;
        }
        if(jmbg.Length != 13)
        {
            lblIspis.Text = "Unijeli ste manje ili više brojeva kao JMBG. Svaki JMBG ima 13 brojeva. Provjerite Vaš unos!";
            return;
        }
        //ukoliko smo prosli sve gore navedene uslove pravimo upit za unos novog korisnika
        string sqlUpit = "INSERT INTO Komitent (JMBG, Ime, Prezime, GradID, Adresa) VALUES (@JMBG, @Ime, @Prezime, @GradID, @Adresa)";
        //Komanda za izvršavanje upita
        SqlCommand sqlKomanda = new SqlCommand(sqlUpit, sqlKonekcija);
        //upis JMBG 
        sqlKomanda.Parameters.AddWithValue("@JMBG", jmbg);
        //upisujemo ime komitenta
        sqlKomanda.Parameters.AddWithValue("@Ime", ime);
        //upisujemo prezime komitenta
        sqlKomanda.Parameters.AddWithValue("@Prezime", prezime);

        //Upisujemo datum rodjenja komitenta - ovo smo ipak iskljucili
        //sqlKomanda.Parameters.Add("@DatumRodjenja", SqlDbType.Date).Value = datum.Date;
        
        
        
        //Ovaj kod ispod je probni 
    int gradID;
    if (int.TryParse(ddlGrad.Text, out gradID))
    {
        //ukoliko je uspjesno parsiran upisujemo gradID u bazu
        sqlKomanda.Parameters.AddWithValue("@GradID", gradID);
    }
    else
    {
        //ukoliko nije uspjesno parsiran dobijamo gradID iz baze prema imenu grada
        string grad = ddlGrad.Text.ToString();
        string sqlGrad = "SELECT GradID FROM Grad WHERE Naziv=@Naziv";
        SqlCommand sqlProvjeraGrada = new SqlCommand(sqlGrad, sqlKonekcija);
        sqlProvjeraGrada.Parameters.AddWithValue("@Naziv", grad);
        object gradObj = sqlProvjeraGrada.ExecuteScalar();
        int.TryParse(gradObj.ToString(), out gradID);
        sqlKomanda.Parameters.AddWithValue("@GradID", gradID);
    }
        // Ovaj kod iznad je probni 

        //upisujemo adresu komitenta
        sqlKomanda.Parameters.AddWithValue("@Adresa", adresa);
        //Izvrsavanje upita 
        sqlKomanda.ExecuteNonQuery();
        //zatvaranje konekcije
        sqlKonekcija.Close();

        //Ispis u uspješnom pohranjivanju komitenta u bazu podataka
        lblIspis.Text = "Uspješno ste pohranili komitenta u bazu podataka!";


    }

    protected void obrisiImg_Click(object sender, ImageClickEventArgs e)
    {
        //Dodjeljivanje unesenih korisnickih vrijednosti u varijable
        string jmbg = txtJMBG.Text.ToString();
        

        //Konekcija sa serverom
        string konekcija = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        SqlConnection sqlKonekcija = new SqlConnection(konekcija);
        //Otvaranje konekcije
        sqlKonekcija.Open();

        //Provjera da li vec postoji osoba sa istim JMBG u bazi podataka ako postoji nece se izvrsiti unos
        string sqlProvjera = "SELECT COUNT(1) FROM Komitent WHERE JMBG=@JMBG";
        //Komanda za izvrsavanje upita za provjeru da li postoji osoba sa istim JMBG 
        SqlCommand sqlProvjeraJMBG = new SqlCommand(sqlProvjera, sqlKonekcija);

        /*Prva linija definiše SQL upit koji će biti izvršen, a koristi parametar @JMBG 
         koji se očekuje da će biti postavljen na određenu vrijednost prije izvršavanja upita*/
        sqlProvjeraJMBG.Parameters.AddWithValue("@JMBG", jmbg);
        //konvertujem jmbg u objekat a objekat u integer
        object countObj = sqlProvjeraJMBG.ExecuteScalar();
        //Execute scalar u idućoj liniji koda vraća prvi red prvog stupca dobijenog iz upita kao rezultat.
        int count = Convert.ToInt32(countObj);


        //Ovo je kod prije promjena
        /*if (count > 0)
        {
            //ukoliko smo prosli sve gore navedene uslove pravimo upit za brisanje korisnika
            string sqlUpit = "DELETE FROM Komitent WHERE JMBG=@JMBG";
            //Komanda za izvršavanje upita
            SqlCommand sqlKomanda = new SqlCommand(sqlUpit, sqlKonekcija);
            //upis JMBG 
            sqlKomanda.Parameters.AddWithValue("@JMBG", jmbg);
            //Izvrsavanje upita 
            sqlKomanda.ExecuteNonQuery();
            //Ispis u uspješnom brisanju komitenta iz baze podataka
            lblIspis.Text = "Uspješno ste obrisali komitenta iz baze podataka!";
        }
        else
        {
            //Ispis u slucaju kada osoba sa unesenim JMBG ne postoji u bazi podataka
            lblIspis.Text = "Osoba sa unesenim JMBG ne postoji u bazi podataka!";
        }*/
        //Ovo je kod prije promjena


        //Odavdje se nastavlja kod za brisanje komitenta
        if (count > 0)
        {
            // Provjera da li komitent ima otvoren kredit
            string sqlProvjeraKredita = "SELECT COUNT(1) FROM Krediti WHERE KomitentJMBG=@KomitentJMBG";
            SqlCommand sqlProvjeraKreditaKomanda = new SqlCommand(sqlProvjeraKredita, sqlKonekcija);
            sqlProvjeraKreditaKomanda.Parameters.AddWithValue("@KomitentJMBG", jmbg);
            object countKredaObj = sqlProvjeraKreditaKomanda.ExecuteScalar();
            int countKreda = Convert.ToInt32(countKredaObj);

            if (countKreda > 0)
            {
                // Ako komitent ima otvoren kredit, ispiši poruku da ga ne možete obrisati
                lblIspis.Text = "Ne možete obrisati komitenta koji ima otvoren kredit!";
            }
            else
            {
                //ukoliko smo prosli sve gore navedene uslove pravimo upit za brisanje korisnika
                string sqlUpit = "DELETE FROM Komitent WHERE JMBG=@JMBG";
                //Komanda za izvršavanje upita
                SqlCommand sqlKomanda = new SqlCommand(sqlUpit, sqlKonekcija);
                //upis JMBG 
                sqlKomanda.Parameters.AddWithValue("@JMBG", jmbg);
                //Izvrsavanje upita 
                sqlKomanda.ExecuteNonQuery();
                //Ispis u uspješnom brisanju komitenta iz baze podataka
                lblIspis.Text = "Uspješno ste obrisali komitenta iz baze podataka!";
            }
            //zatvaranje konekcije
            sqlKonekcija.Close();
        }
    }

    protected void ispravi1_Click(object sender, ImageClickEventArgs e)
    {
        //Dodjeljivanje unesenih korisnickih vrijednosti u varijable 
        string jmbg = txtJMBG.Text.ToString();
        string ime = txtImeKomitenta.Text.ToString();
        string prezime = txtPrezime.Text.ToString();
        string adresa = txtAdresa.Text.ToString();

        //Konekcija sa serverom
        string konekcija = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        SqlConnection sqlKonekcija = new SqlConnection(konekcija);
        //Otvaranje konekcije
        sqlKonekcija.Open();

        //Provjera da li vec postoji osoba sa istim JMBG u bazi podataka ako postoji nece se izvrsiti unos
        string sqlProvjera = "SELECT COUNT(1) FROM Komitent WHERE JMBG=@JMBG";
        //Komanda za izvrsavanje upita za provjeru da li postoji osoba sa istim JMBG 
        SqlCommand sqlProvjeraJMBG = new SqlCommand(sqlProvjera, sqlKonekcija);

        /*Prva linija definiše SQL upit koji će biti izvršen, a koristi parametar @JMBG 
         koji se očekuje da će biti postavljen na određenu vrijednost prije izvršavanja upita*/
        sqlProvjeraJMBG.Parameters.AddWithValue("@JMBG", jmbg);
        //konvertujem jmbg u objekat a objekat u integer
        object countObj = sqlProvjeraJMBG.ExecuteScalar();
        //Execute scalar u idućoj liniji koda vraća prvi red prvog stupca dobijenog iz upita kao rezultat.
        int count = Convert.ToInt32(countObj);

        //Provjera da li postoji osoba sa unesenim JMBG u bazi podataka
        if (count > 0)
        {
            // Osoba sa unesenim JMBG postoji, izvršavamo UPDATE 
            //string sqlUpdate = "UPDATE Komitent SET Ime=@Ime, Prezime=@Prezime, GradID=@GradID, Adresa=@Adresa WHERE JMBG=@JMBG";
            string sqlUpdate = "UPDATE Komitent SET Ime=@Ime, Prezime=@Prezime, GradID=@GradID, Adresa=@Adresa WHERE JMBG=@JMBG";
            SqlCommand sqlUpdateKomanda = new SqlCommand(sqlUpdate, sqlKonekcija);
            sqlUpdateKomanda.Parameters.AddWithValue("@JMBG", jmbg);
            sqlUpdateKomanda.Parameters.AddWithValue("@Ime", ime);
            sqlUpdateKomanda.Parameters.AddWithValue("@Prezime", prezime);
            //sqlUpdateKomanda.Parameters.AddWithValue("@GradID", ddlGrad.SelectedIndex);

            //Ovaj kod ispod je probni 
            int gradID;
            if (int.TryParse(ddlGrad.Text, out gradID))
            {
                //ukoliko je uspjesno parsiran upisujemo gradID u bazu
                sqlUpdateKomanda.Parameters.AddWithValue("@GradID", gradID);
            }
            else
            {
                //ukoliko nije uspjesno parsiran dobijamo gradID iz baze prema imenu grada
                string grad = ddlGrad.Text.ToString();
                string sqlGrad = "SELECT GradID FROM Grad WHERE Naziv=@Naziv";
                SqlCommand sqlProvjeraGrada = new SqlCommand(sqlGrad, sqlKonekcija);
                sqlProvjeraGrada.Parameters.AddWithValue("@Naziv", grad);
                object gradObj = sqlProvjeraGrada.ExecuteScalar();
                int.TryParse(gradObj.ToString(), out gradID);
                sqlUpdateKomanda.Parameters.AddWithValue("@GradID", gradID);
            }
            // Ovaj kod iznad je probni 

            sqlUpdateKomanda.Parameters.AddWithValue("@Adresa", adresa);
            sqlUpdateKomanda.ExecuteNonQuery();

            lblIspis.Text = "Uspješno ste ažurirali podatke o komitentu u bazi podataka!";
        }
        else
        {
            lblIspis.Text = "Osoba sa unešenim JMBG ne postoji u bazi podataka. Provjerite unos još jednom.";
        }
        
    }
}