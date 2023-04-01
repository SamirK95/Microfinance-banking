using System;
//using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
//using System.Linq;
//using System.Web;
using System.Web.UI;
//using System.Web.UI.WebControls;

public partial class Forme_IsplateZaPeriodGrupisanPo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void napustiImg_Click(object sender, ImageClickEventArgs e)
    {
        //Ukoliko kliknemo dugmic napusti vraca nas na pocetnu stranicu 
        Response.Redirect("http://localhost:57215/Forme/PočetnaStranica.aspx");
    }

    protected void uradiImg_Click(object sender, ImageClickEventArgs e)
    {
        //Ubacivanje unesenih vrijednosti u textboxove i dll-ove u varijable
        string odDatuma = txtPocetniDatum.Text.ToString();
        string doDatuma = txtZavrsniDatum.Text.ToString();
        string grupa1 = ddlGrupisiPo1.Text.ToString();
        string grupa2 = ddlGrupisiPo2.Text.ToString();

        //Konekcija sa serverom
        string konekcija = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        SqlConnection sqlKonekcija = new SqlConnection(konekcija);
        //Otvaranje konekcije
        sqlKonekcija.Open();

        /*funkcija za pravljenje propusta ukoliko se unese razlicita sintaksa od sql sintakse
          da se uneseni datum konvertuje u sql sintaksu ukoliko ne ispunjava ni jedan uslov ispisat ce se 
         poruka u label pogresan format datuma.*/
        DateTime datumOdSQL, datumDoSQL;
        string[] formati = { "dd-MM-yyyy", "MM-dd-yyyy", "yyyy-MM-dd", "yyyy-dd-MM" };
        if (!DateTime.TryParseExact(odDatuma, formati, CultureInfo.InvariantCulture, DateTimeStyles.None, out datumOdSQL) ||
            !DateTime.TryParseExact(doDatuma, formati, CultureInfo.InvariantCulture, DateTimeStyles.None, out datumDoSQL))
        {
            lblIspis4.Text = "Pogrešan format datuma.";
            return;
        }
        //Ukoliko se odaberu iste vrijednosti u oba dropDown-a ispisat ce se poruka u label da se odaberu razlicite vrijednosti
        if(ddlGrupisiPo1.SelectedValue == ddlGrupisiPo2.SelectedValue)
        {
            lblIspis4.Text = "Odaberite dvije različite vrijednosti!";
            return;
        }
        //Ukoliko je nesto odabrano u prvom dropdownu izvrsit ce se upit 
        if (ddlGrupisiPo1.SelectedIndex != -1)
        {
            //definisanje upita koji treba da se izvrsi 
            string sqlUpit = "SELECT Podruznica.RegijaID, Regija.Naziv AS 'Regija', Podruznica.Naziv AS 'Podružnica'," +
                "COUNT(*) AS 'COUNT', SUM(Krediti.IznosIsplacenogKredita) AS 'SUM', MIN(Krediti.IznosIsplacenogKredita) AS 'MIN'," +
                " MAX(Krediti.IznosIsplacenogKredita) AS 'MAX', AVG(Krediti.IznosIsplacenogKredita) AS 'AVG' " +
                "FROM Krediti JOIN Ured ON Krediti.UredID = Ured.ID JOIN Podruznica ON Ured.PodruznicaID = Podruznica.ID " +
                "JOIN Regija ON Podruznica.RegijaID = Regija.ID " +
                "WHERE Regija.Naziv = @grupa1 OR Podruznica.Naziv=@grupa1 OR Ured.Naziv=@grupa1 " +
                "GROUP BY Podruznica.RegijaID, Regija.Naziv, Podruznica.Naziv " +
                "ORDER BY Regija.Naziv DESC, Podruznica.Naziv DESC";
            //Komanda za izvršavanje upita
            SqlCommand sqlKomanda = new SqlCommand(sqlUpit, sqlKonekcija);

            sqlKomanda.Parameters.AddWithValue("@grupa1", grupa1);;

            //popunjavanje gridview kontrole podacima iz baze podataka
            SqlDataAdapter da = new SqlDataAdapter(sqlKomanda);
            DataTable dt = new DataTable();
            da.Fill(dt);

            //Prikaz podataka u GridView kontroli
            izvjestajID.DataSource = dt;
            izvjestajID.DataBind();

            //Zatvaranje konekcije
            sqlKonekcija.Close();

            //Ispis u uspješnom pohranjivanju komitenta u bazu podataka
            lblIspis4.Text = "Podaci su prikazani u izvještaju koji se nalazi ispod ove forme.";
        }
        //Ukoliko je nesto odabrano u dropdown-u dva izvrsit ce se ovaj kod 
        if(ddlGrupisiPo2.SelectedIndex != -1)
        {
            //Definisanje upita koji treba da se izvrsi ukoliko korisnik odabere neku vrijednost iz drop down-a
            string sqlUpit2 = "SELECT Ured.PodruznicaID, Podruznica.Naziv AS 'Podružnica', Ured.Naziv AS 'Ured', COUNT(*) AS 'COUNT'," +
                              "SUM(Krediti.IznosIsplacenogKredita) AS 'SUM',MIN(Krediti.IznosIsplacenogKredita) AS 'MIN'," +
                              "MAX(Krediti.IznosIsplacenogKredita) AS 'MAX',AVG(Krediti.IznosIsplacenogKredita) AS 'AVG'" +
                              "FROM Krediti JOIN Ured ON Krediti.UredID = Ured.ID JOIN Podruznica ON Ured.PodruznicaID = Podruznica.ID " +
                              "WHERE Podruznica.Naziv=@grupa2 OR Ured.Naziv=@grupa2 "+
                              "GROUP BY Ured.PodruznicaID, Podruznica.Naziv, Ured.Naziv ORDER BY Podruznica.Naziv DESC, Ured.Naziv DESC";

            //Komanda za izvršavanje upita
            SqlCommand sqlKomanda = new SqlCommand(sqlUpit2, sqlKonekcija);

            sqlKomanda.Parameters.AddWithValue("@grupa2", grupa2); ;

            //Popunjavanje gridview kontrole podacima iz baze podataka
            SqlDataAdapter da2 = new SqlDataAdapter(sqlKomanda);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);

            //Prikaz podataka u GridView kontroli
            izvjestaj2ID.DataSource = dt2;
            izvjestaj2ID.DataBind();

            //Zatvaranje konekcije
            sqlKonekcija.Close();
        }
        
        



    }

}
