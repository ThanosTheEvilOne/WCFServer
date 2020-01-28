
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace WcfT6autoserver.model
{
    public class DatabaseHallinta
    {

        SqlConnection dbYhteys = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Autokauppa;" +
        "Integrated Security=True;Connect Timeout=5;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        public DatabaseHallinta()
        {

        }

        public bool connectDatabase()
        {
            try
            {
                dbYhteys.Open();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Virheilmoitukset:" + e);
                //dbYhteys.Close();
                return false;
            }
        }

        public void disconnectDatabase()
        {
            dbYhteys.Close();
        }

        public bool saveAutoIntoDatabase(Auto newAuto)
        {
            bool palaute = false;
            return palaute;
        }

      
        public List<autonMerkit> getAllAutoMakersFromDatabase()  // Lisää Automerkit listaan tietokannasta
        {
            dbYhteys.Open();
            SqlCommand query1 = new SqlCommand("SELECT * FROM  AutonMerkki", dbYhteys);
            SqlDataReader merkki = query1.ExecuteReader();
            List<autonMerkit> merkkilista = new List<autonMerkit>();

            while (merkki.Read())
            {
                autonMerkit merkit = new autonMerkit();
                merkit.Id = (int)merkki["ID"];
                merkit.MerkkiNimi = (string)merkki["Merkki"];
                merkkilista.Add(merkit);
            }
            dbYhteys.Close();
            return merkkilista;
        }

       
        public List<autonMallit> getAutoModelsByMakerId(int MerkkiId) // Lisää valitun automerkin mallit listaan merkkiId:n kautta tietokannasta
        {
            dbYhteys.Open();
            SqlCommand query2 = new SqlCommand("SELECT * FROM AutonMallit WHERE AutonMerkkiID = " + MerkkiId + "", dbYhteys);
            SqlDataReader malli = query2.ExecuteReader();
            List<autonMallit> mallilista = new List<autonMallit>();

            while (malli.Read())
            {
                autonMallit mallit = new autonMallit();
                mallit.Id = (int)malli["ID"];
                mallit.MalliNimi = (string)malli["Auton_mallin_nimi"];
                mallit.MerkkiId = (int)malli["AutonMerkkiID"];
                mallilista.Add(mallit);
            }
            dbYhteys.Close();
            return mallilista;
        }

       
        public List<Varit> GetAutoColors() // Lisää värit listaan tietokannasta
        {
            dbYhteys.Open();
            SqlCommand query3 = new SqlCommand("SELECT * FROM  Varit", dbYhteys);
            SqlDataReader vari = query3.ExecuteReader();
            List<Varit> varilista = new List<Varit>();

            while (vari.Read())
            {
                Varit varit = new Varit();
                varit.Id = (int)vari["ID"];
                varit.Varin_nimi = (string)vari["Varin_nimi"];
                varilista.Add(varit);
            }
            dbYhteys.Close();
            return varilista;
        }

       
        public List<Polttoaine> GetAutoFuels() // Lisää polttoaineet listaan tietokannasta
        {
            dbYhteys.Open();
            SqlCommand query4 = new SqlCommand("SELECT * FROM  Polttoaine", dbYhteys);
            SqlDataReader polttoaine = query4.ExecuteReader();
            List<Polttoaine> polttoainelista = new List<Polttoaine>();

            while (polttoaine.Read())
            {
                Polttoaine polttoaineet = new Polttoaine();
                polttoaineet.Id = (int)polttoaine["ID"];
                polttoaineet.Polttoaineen_nimi = (string)polttoaine["Polttoaineen_nimi"];
                polttoainelista.Add(polttoaineet);
            }
            dbYhteys.Close();
            return polttoainelista;
        }

        
        public bool SaveCar(Auto kultainenhaikala)// Tallenna auto tietokantaan
        {
            dbYhteys.Open();
            SqlCommand query5 = new SqlCommand("INSERT INTO Auto(Hinta, Rekisteri_paivamaara, Moottorin_tilavuus, Mittarilukema, AutonMerkkiID, AutonMalliID, VaritID, PolttoaineID)" +
            "VALUES(@Hinta, @Rekisteri_pvm, @Moottorin_Tilavuus,@Mittarilukema,@AutonMerkkiID,@AutonMalliID,@VaritID,@PolttoaineID)", dbYhteys);
            SqlParameter Hinta = new SqlParameter("@Hinta", kultainenhaikala.Hinta);
            query5.Parameters.Add(Hinta);
            SqlParameter Rekisteri_paivamaara = new SqlParameter("@Rekisteri_pvm", kultainenhaikala.Rekisteri_paivamaara);
            query5.Parameters.Add(Rekisteri_paivamaara);
            SqlParameter Moottorin_tilavuus = new SqlParameter("@Moottorin_tilavuus", kultainenhaikala.Moottorin_Tilavuus);
            query5.Parameters.Add(Moottorin_tilavuus);
            SqlParameter Mittarilukema = new SqlParameter("@Mittarilukema", kultainenhaikala.Mittarilukema);
            query5.Parameters.Add(Mittarilukema);
            SqlParameter AutonMerkkiID = new SqlParameter("@AutonMerkkiID", kultainenhaikala.AutonMerkkiID);
            query5.Parameters.Add(AutonMerkkiID);
            SqlParameter AutonMalliID = new SqlParameter("@AutonMalliID", kultainenhaikala.AutonMalliID);
            query5.Parameters.Add(AutonMalliID);
            SqlParameter VaritID = new SqlParameter("@VaritID", kultainenhaikala.VaritID);
            query5.Parameters.Add(VaritID);
            SqlParameter PolttoaineID = new SqlParameter("@PolttoaineID", kultainenhaikala.PolttoaineID);
            query5.Parameters.Add(PolttoaineID);


            query5.ExecuteNonQuery();

            dbYhteys.Close();
            return true;
        }

        
        public Auto NextCar(int ID)//Näytää Seuraavan auton
        {
            Auto kosla = new Auto();
            dbYhteys.Open();
            SqlCommand query6 = new SqlCommand("SELECT TOP 1 * FROM auto WHERE ID > " + ID + " ORDER BY ID ASC", dbYhteys);

            SqlDataReader seurAuto = query6.ExecuteReader();

            while (seurAuto.Read())
            {
                kosla.Id = (int)seurAuto["ID"];
                kosla.Hinta = (decimal)seurAuto["Hinta"];
                kosla.Rekisteri_paivamaara = (DateTime)seurAuto["Rekisteri_paivamaara"];
                kosla.Moottorin_Tilavuus = (decimal)seurAuto["Moottorin_tilavuus"];
                kosla.Mittarilukema = (int)seurAuto["Mittarilukema"];
                kosla.AutonMerkkiID = (int)seurAuto["AutonMerkkiID"];
                kosla.AutonMalliID = (int)seurAuto["AutonMalliID"];
                kosla.VaritID = (int)seurAuto["VaritID"];
                kosla.PolttoaineID = (int)seurAuto["PolttoaineID"];
            }

            dbYhteys.Close();
            return kosla;
        }

        
        public Auto PreviousCar(int ID)// Näyttää edellisen auton
        {
            Auto biili = new Auto();
            dbYhteys.Open();
            SqlCommand query7 = new SqlCommand("SELECT TOP 1 * FROM auto WHERE ID < " + ID + " ORDER BY ID DESC", dbYhteys);

            SqlDataReader prevAuto = query7.ExecuteReader();

            while (prevAuto.Read())
            {
                biili.Id = (int)prevAuto["ID"];
                biili.Hinta = (decimal)prevAuto["Hinta"];
                biili.Rekisteri_paivamaara = (DateTime)prevAuto["Rekisteri_paivamaara"];
                biili.Moottorin_Tilavuus = (decimal)prevAuto["Moottorin_tilavuus"];
                biili.Mittarilukema = (int)prevAuto["Mittarilukema"];
                biili.AutonMerkkiID = (int)prevAuto["AutonMerkkiID"];
                biili.AutonMalliID = (int)prevAuto["AutonMalliID"];
                biili.VaritID = (int)prevAuto["VaritID"];
                biili.PolttoaineID = (int)prevAuto["PolttoaineID"];
            }

            dbYhteys.Close();
            return biili;
        }

        
        public Auto ViimeinenAuto(int ID)// Näyttää Viimeinen auto
        {
            Auto haikala = new Auto();
            dbYhteys.Open();
            SqlCommand query8 = new SqlCommand("SELECT TOP 1 * FROM auto ORDER BY ID DESC", dbYhteys);

            SqlDataReader viimeinenAuto = query8.ExecuteReader();

            while (viimeinenAuto.Read())
            {
                haikala.Id = (int)viimeinenAuto["ID"];
                haikala.Hinta = (decimal)viimeinenAuto["Hinta"];
                haikala.Rekisteri_paivamaara = (DateTime)viimeinenAuto["Rekisteri_paivamaara"];
                haikala.Moottorin_Tilavuus = (decimal)viimeinenAuto["Moottorin_tilavuus"];
                haikala.Mittarilukema = (int)viimeinenAuto["Mittarilukema"];
                haikala.AutonMerkkiID = (int)viimeinenAuto["AutonMerkkiID"];
                haikala.AutonMalliID = (int)viimeinenAuto["AutonMalliID"];
                haikala.VaritID = (int)viimeinenAuto["VaritID"];
                haikala.PolttoaineID = (int)viimeinenAuto["PolttoaineID"];
            }

            dbYhteys.Close();
            return haikala;

        }

      
        public Auto EnsimmainenAuto(int ID)  // Näyttää Ensimmäisen auton
        {
            Auto Kultanen = new Auto();
            dbYhteys.Open();
            SqlCommand query9 = new SqlCommand("SELECT TOP 1 * FROM auto ORDER BY ID ASC", dbYhteys);

            SqlDataReader ensimmainenAuto = query9.ExecuteReader();

            while (ensimmainenAuto.Read())
            {
                Kultanen.Id = (int)ensimmainenAuto["ID"];
                Kultanen.Hinta = (decimal)ensimmainenAuto["Hinta"];
                Kultanen.Rekisteri_paivamaara = (DateTime)ensimmainenAuto["Rekisteri_paivamaara"];
                Kultanen.Moottorin_Tilavuus = (decimal)ensimmainenAuto["Moottorin_tilavuus"];
                Kultanen.Mittarilukema = (int)ensimmainenAuto["Mittarilukema"];
                Kultanen.AutonMerkkiID = (int)ensimmainenAuto["AutonMerkkiID"];
                Kultanen.AutonMalliID = (int)ensimmainenAuto["AutonMalliID"];
                Kultanen.VaritID = (int)ensimmainenAuto["VaritID"];
                Kultanen.PolttoaineID = (int)ensimmainenAuto["PolttoaineID"];
            }

            dbYhteys.Close();
            return Kultanen;
        }

    }
}
