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
    public partial class dashBoard : Form
    {

        private string role;
        private string conString = "Data Source=DESKTOP-8GP80EP\\SQLEXPRESS;Initial Catalog=TapAndTaste;User ID=n8n_users;Password=islem123!;TrustServerCertificate=True";
        public dashBoard()
        {
            InitializeComponent();
        }

        public dashBoard(string userRole)
        {
            InitializeComponent();
            this.role = userRole;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public void LoadBestSellingProductsDoughnut()
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();

                // Requête des produits pour les 2 derniers mois
                string query = @"SELECT TOP 5 p.nomproduit, SUM(lc.quantite) AS TotalVentes 
                 FROM lignecommande lc 
                 JOIN produit p ON lc.idproduit = p.idproduit 
                 JOIN commande c ON lc.idcommande = c.idcommande 
                 WHERE c.datecommande >= DATEADD(MONTH, -2, GETDATE()) 
                   AND c.datecommande <= GETDATE()
                 GROUP BY p.nomproduit 
                 ORDER BY TotalVentes DESC;";

                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();

                chart1.BackColor = Color.Transparent;
                
                
                // Reset the chart
                chart1.Series.Clear();
                chart1.ChartAreas.Clear();
                chart1.Legends.Clear();
                // Add chart area
                ChartArea ca = new ChartArea();
                chart1.ChartAreas.Add(ca);
                ca.BackColor = Color.Transparent;
                // Add legend
                Legend lg = new Legend();
                chart1.Legends.Add(lg);
                lg.BackColor = Color.Transparent;
                // Add series
                Series serie = new Series("TopProducts");
                serie.ChartType = SeriesChartType.Doughnut;
                serie.IsValueShownAsLabel = true;
                chart1.Series.Add(serie);
                
                // Fill data
                int totalSales = 0;
                while (dr.Read())
                {
                    string name = dr["nomproduit"].ToString();
                    int qty = Convert.ToInt32(dr["TotalVentes"]);
                    totalSales += qty;

                    serie.Points.AddXY(name, qty);
                }

                dr.Close();

                // Si pas de données pour les 2 derniers mois
                if (serie.Points.Count == 0)
                {
                    serie.Points.AddXY("Aucune vente\n(2 derniers mois)", 1);
                    serie.Points[0].Color = Color.LightGray;
                    serie.Label = "Aucune donnée";
                }
            }
        }



        public void LoadDashboardStats()
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();

                
                //  Nombre de commandes du jour
                SqlCommand cmdOrders = new SqlCommand(
                    "SELECT COUNT(*) FROM commande WHERE CONVERT(date, datecommande) = CONVERT(date, GETDATE())",
                    con);
                int ordersToday = (int)cmdOrders.ExecuteScalar();
                lblorders.Text = ordersToday.ToString();

                
                // Somme des revenues du jour
               
                SqlCommand cmdRevenue = new SqlCommand(
                    "SELECT ISNULL(SUM(montanttotal), 0) FROM commande WHERE CONVERT(date, datecommande) = CONVERT(date, GETDATE())",
        
                    con);
                double revenueToday = Convert.ToDouble(cmdRevenue.ExecuteScalar());
                lblrevenue.Text = revenueToday.ToString("0.00") + " DT";

       
                // Nombre des réservations du jour
               
                SqlCommand cmdReservation = new SqlCommand(
                    "SELECT COUNT(*) FROM reservation WHERE dateReservation = CONVERT(date, GETDATE())",
                    con);
                int reservationsToday = (int)cmdReservation.ExecuteScalar();
                lblreservation.Text = reservationsToday.ToString();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            LoadDashboardStats();
            LoadBestSellingProductsDoughnut();
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
        private void btnProduct_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3(role);
            f.Show();    
            this.Close(); 
        }

        private void btncategorie_Click(object sender, EventArgs e)
        {
            Form5 f = new Form5(role);
            f.Show();     
            this.Close(); 
        }
        private void btnsale_Click(object sender, EventArgs e)
        {
            Form10 f = new Form10(role);
            f.Show();     
            this.Close(); 
        }
    }
}
