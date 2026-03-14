using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;


namespace Tap_Taste
{
    public partial class Form11 : Form
    {
        private string role;
        private string conString = "Data Source=DESKTOP-8GP80EP\\SQLEXPRESS;Initial Catalog=TapAndTaste;User ID=n8n_users;Password=islem123!;TrustServerCertificate=True";
        public Form11()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        public Form11(string userRole)
        {
            InitializeComponent();
            this.role = userRole;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form11_Load(object sender, EventArgs e)
        {
            
            LoadReservations();
            if (role.ToLower() == "employe")
            {
                btncategorie.Enabled = false;
                btnProduct.Enabled = false;
                btnsale.Enabled = false;

                // btncategorie.Visible = false;
                // btnProduct.Visible = false;
                // btnsale.Visible = false;
            }
        }

      
      //Charger toutes les réservations
        public void LoadReservations()
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                try
                {
                    con.Open();
                    string query = @"SELECT idReservation AS ID,dateReservation AS Date,heure AS Heure,nomClient AS Client,nombrePersonnes AS Personnes,telephone AS Telephone FROM reservation
                   WHERE (dateReservation > CAST(GETDATE() AS DATE) OR (dateReservation = CAST(GETDATE() AS DATE) AND heure >= CONVERT(time, GETDATE())))";

                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvReservation.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur chargement réservations : " + ex.Message);
                }
            }
        }

        // Ajouter une réservation
      
        private void btnadd_Click(object sender, EventArgs e)
        {

        }
        private void btnadd_Click_1(object sender, EventArgs e)
        {
            Form12 f = new Form12(); // mode ajout
            f.ShowDialog();
            LoadReservations();
        }

      
        //  Modifier une réservation
       
        private void btnmodifier_Click(object sender, EventArgs e)
        {

        }
        private void btnmodifier_Click_1(object sender, EventArgs e)
        {
            if (dgvReservation.SelectedRows.Count == 0)
            {
                MessageBox.Show("Sélectionnez une réservation !");
                return;
            }

            string id = dgvReservation.SelectedRows[0].Cells["ID"].Value.ToString();
            string date = dgvReservation.SelectedRows[0].Cells["Date"].Value.ToString();
            string heure = dgvReservation.SelectedRows[0].Cells["Heure"].Value.ToString();
            string client = dgvReservation.SelectedRows[0].Cells["Client"].Value.ToString();
            string nb = dgvReservation.SelectedRows[0].Cells["Personnes"].Value.ToString();
            string tel = dgvReservation.SelectedRows[0].Cells["Telephone"].Value.ToString();

            Form12 f = new Form12(id, date, heure, client, nb, tel); // mode modification
            f.ShowDialog();
            LoadReservations();
        }
       
        //  Supprimer une réservation
      
        private void btnsupp_Click(object sender, EventArgs e)
        {

        }
        private void btnsupp_Click_1(object sender, EventArgs e)
        {
            if (dgvReservation.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner une réservation !");
                return;
            }

            if (MessageBox.Show("Confirmer la suppression ?", "Suppression",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            string id = dgvReservation.SelectedRows[0].Cells["ID"].Value.ToString();

            using (SqlConnection con = new SqlConnection(conString))
            {
                try
                {
                    con.Open();
                    string query = "DELETE FROM reservation WHERE idReservation = @id";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Réservation supprimée !");
                    LoadReservations();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors de la suppression : " + ex.Message);
                }
            }
        }
       
        //  Recherche
        
        private void btnsearch_Click(object sender, EventArgs e)
        {

        }

        private void btnsearch_Click_1(object sender, EventArgs e)
        {
            string search = textBoxRech.Text.Trim();
            if (search == "")
            {
                MessageBox.Show("Entrez un terme de recherche.");
                return;
            }

            string query;

            if (int.TryParse(search, out int num))
            {
                query = "SELECT * FROM reservation WHERE idReservation = @s OR nombrePersonnes = @s";
            }
            else
            {
                query = "SELECT * FROM reservation WHERE nomClient LIKE @sTxt OR telephone LIKE @sTxt";
            }

            using (SqlConnection con = new SqlConnection(conString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);

                    if (int.TryParse(search, out num))
                        cmd.Parameters.AddWithValue("@s", num);
                    else
                        cmd.Parameters.AddWithValue("@sTxt", "%" + search + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvReservation.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur recherche : " + ex.Message);
                }
            }
        }

        private void btnhome_Click(object sender, EventArgs e)
        {
            dashBoard f = new dashBoard(role);
            f.Show();
            this.Close();
        }

        private void btnorder_Click(object sender, EventArgs e)
        {
            Form7 f = new Form7(role);
            f.Show();     
            this.Close(); 
        }

        private void btnhist_Click(object sender, EventArgs e)
        {
            Form8 f = new Form8(role);
            f.Show();     
            this.Close(); 
        }

        private void btnreservation_Click(object sender, EventArgs e)
        {
            Form11 f = new Form11(role);
            f.Show();     
            this.Close(); 
        }

        private void btncategorie_Click(object sender, EventArgs e)
        {
            Form5 formulairecategorie = new Form5(role);
            formulairecategorie.Show();
            this.Close();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3(role);
            f.Show();     
            this.Close(); 
        }

        private void btnsale_Click(object sender, EventArgs e)
        {
            Form10 f = new Form10(role);
            f.Show();     
            this.Close(); 
        }

        private void btndeconexion_Click(object sender, EventArgs e)
        {
            // Demander confirmation
            if (MessageBox.Show("Voulez-vous vraiment vous déconnecter ?",
                "Déconnexion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            // Ouvrir la page de connexion
            loginForm login = new loginForm();
            login.Show();

            // Fermer l'interface actuelle
            this.Close();
        }
        public void FECHANDSTORE()
        {
            string url = "https://docs.google.com/spreadsheets/d/e/2PACX-1vQc3LeR8O-ZjxB4KwqH9lsIjNjZbbCkC2keprT4qH1DTEDpbOi4848gDrPWXeIfuJQPZu60K5MMnrZZ/pub?output=csv";

            int inserted = 0;
            int skipped = 0;

            using (HttpClient client = new HttpClient())
            {
                string csv = client.GetStringAsync(url).Result;

                //  détecter séparateur
                char separator = csv.Contains(";") ? ';' : ',';

                string[] lines = csv.Split('\n');

                using (SqlConnection conn = new SqlConnection(conString))
                {
                    conn.Open();

                    for (int i = 0; i < lines.Length; i++)
                    {
                        if (string.IsNullOrWhiteSpace(lines[i])) continue;

                        string line = lines[i].Replace("\"", "").Trim();

                        // ignorer l’en-tête
                        if (line.ToLower().Contains("date")) continue;

                        string[] cols = line.Split(separator);
                        if (cols.Length < 5)
                        {
                            skipped++;
                            continue;
                        }

                        if (!DateTime.TryParse(cols[0], new CultureInfo("fr-FR"),
                            DateTimeStyles.None, out DateTime dateReservation))
                        {
                            skipped++;
                            continue;
                        }

                        if (!TimeSpan.TryParse(cols[1], out TimeSpan heure))
                        {
                            skipped++;
                            continue;
                        }

                        if (!int.TryParse(cols[3], out int nombrePersonnes))
                        {
                            skipped++;
                            continue;
                        }

                        string nomClient = cols[2].Trim();
                        string telephone = cols[4].Trim();

                        if (telephone.Length != 8)
                        {
                            skipped++;
                            continue;
                        }

                        // anti-duplication
                        string checkSql = @"
                    SELECT COUNT(*) FROM reservation
                    WHERE dateReservation=@date AND heure=@heure AND telephone=@tel";

                        using (SqlCommand check = new SqlCommand(checkSql, conn))
                        {
                            check.Parameters.AddWithValue("@date", dateReservation);
                            check.Parameters.AddWithValue("@heure", heure);
                            check.Parameters.AddWithValue("@tel", telephone);

                            if ((int)check.ExecuteScalar() > 0)
                            {
                                skipped++;
                                continue;
                            }
                        }

                        string insertSql = @"
                    INSERT INTO reservation
                    (dateReservation, heure, nomClient, nombrePersonnes, telephone)
                    VALUES
                    (@date, @heure, @client, @nb, @tel)";

                        using (SqlCommand cmd = new SqlCommand(insertSql, conn))
                        {
                            cmd.Parameters.AddWithValue("@date", dateReservation);
                            cmd.Parameters.AddWithValue("@heure", heure);
                            cmd.Parameters.AddWithValue("@client", nomClient);
                            cmd.Parameters.AddWithValue("@nb", nombrePersonnes);
                            cmd.Parameters.AddWithValue("@tel", telephone);

                            cmd.ExecuteNonQuery();
                            inserted++;
                        }
                    }
                }
            }

            MessageBox.Show(
                $"Import terminé\n\n" +
                $"Ajoutées : {inserted}\n" +
                $"Ignorées : {skipped}",
                "Synchronisation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void btnRafraichir_Click(object sender, EventArgs e)
        {
            FECHANDSTORE();
            textBoxRech.Clear();
            LoadReservations();
        }
    }
}
