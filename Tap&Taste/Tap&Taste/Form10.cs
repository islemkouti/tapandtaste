using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Tap_Taste
{
    public partial class Form10 : Form
    {
        private string role;
        private string conString = "Data Source=DESKTOP-8GP80EP\\SQLEXPRESS;Initial Catalog=TapAndTaste;User ID=n8n_users;Password=islem123!;TrustServerCertificate=True";
        public Form10()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
        }
        public Form10(string userRole)
        {
            InitializeComponent();
            this.role = userRole;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btngenerat_Click(object sender, EventArgs e)
        {
            DateTime startDate = dateTimePicker1.Value.Date;
            DateTime endDate = dateTimePicker2.Value.Date.AddDays(1).AddSeconds(-1);
            // inclure toute la journée fin

            LoadChart(startDate, endDate);
        }
        private void LoadChart(DateTime start, DateTime end)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    con.Open();

                    string query = @"
                SELECT datecommande, montanttotal 
                FROM commande
                WHERE datecommande BETWEEN @start AND @end
                ORDER BY datecommande ASC";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@start", start);
                    cmd.Parameters.AddWithValue("@end", end);

                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                    // -------------------------
                    // AJOUT DES DONNÉES
                    // -------------------------
                    foreach (DataRow row in dt.Rows)
                    {
                        DateTime date = Convert.ToDateTime(row["datecommande"]);
                        double montant = Convert.ToDouble(row["montanttotal"]);

                        chart1.Series["Series1"].Points.AddXY(date, montant);
                    }

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Aucune commande trouvée dans cette période.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur chargement du graphe : " + ex.Message);
            }
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            DateTime start = DateTime.Today.AddDays(-7);
            DateTime end = DateTime.Today.AddDays(1).AddSeconds(-1);
            LoadChart(start, end);
            if (role.ToLower() == "employe")
            {
                btncat.Enabled = false;
                btnpro.Enabled = false;
                btnsale.Enabled = false;

                // Tu peux aussi cacher :
                // btncategorie.Visible = false;
                // btnProduct.Visible = false;
                // btnsale.Visible = false;
            }
        }

        private void btnres_Click(object sender, EventArgs e)
        {
            Form11 f = new Form11(role);
            f.Show();     // Ouvre la nouvelle interface
            this.Close(); // Ferme l'interface actuelle
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
            f.Show();     // Ouvre la nouvelle interface
            this.Close(); // Ferme l'interface actuelle
        }

        private void btnhist_Click(object sender, EventArgs e)
        {
            Form8 f = new Form8(role);
            f.Show();     // Ouvre la nouvelle interface
            this.Close(); // Ferme l'interface actuelle
        }

        private void btncat_Click(object sender, EventArgs e)
        {
            Form5 f = new Form5(role);
            f.Show();     // Ouvre la nouvelle interface
            this.Close(); // Ferme l'interface actuelle
        }

        private void btnpro_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3(role);
            f.Show();     // Ouvre la nouvelle interface
            this.Close(); // Ferme l'interface actuelle
        }

        private void btndec_Click(object sender, EventArgs e)
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

        private void btnsale_Click(object sender, EventArgs e)
        {
            Form10 f = new Form10(role);
            f.Show();     // Ouvre la nouvelle interface
            this.Close(); // Ferme l'interface actuelle
        }
    }
}
