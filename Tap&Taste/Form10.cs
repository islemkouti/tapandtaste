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
        private bool isGenerateClicked = false;

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

        // BOUTON GENERATE
        private void btngenerat_Click(object sender, EventArgs e)
        {
            isGenerateClicked = true;
            DateTime startDate = dateTimePicker1.Value.Date;
            DateTime endDate = dateTimePicker2.Value.Date.AddDays(1).AddSeconds(-1);

            LoadChart(startDate, endDate);
        }

        // CHARGEMENT DU GRAPHE 
        private void LoadChart(DateTime start, DateTime end)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    con.Open();

                    string query = @"
                        SELECT 
                            CAST(datecommande AS DATE) AS Jour,
                            SUM(montanttotal) AS TotalJour
                        FROM commande
                        WHERE datecommande BETWEEN @start AND @end
                        GROUP BY CAST(datecommande AS DATE)
                        ORDER BY Jour ASC";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@start", start);
                    cmd.Parameters.AddWithValue("@end", end);

                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                 
                    // CONFIGURATION DU CHART
                    chart1.Series.Clear();

                    Series series = new Series("Series1");
                    series.ChartType = SeriesChartType.SplineArea; 
                    series.BorderWidth = 4;
                    series.BackGradientStyle = GradientStyle.LeftRight;
                    series.BackSecondaryColor = Color.DeepPink;
                    series.Color = Color.Indigo;
                    series.XValueType = ChartValueType.DateTime;
                    series.YValueType = ChartValueType.Double;
                    series.IsVisibleInLegend = true;

                    chart1.Series.Add(series);

                    ChartArea area = chart1.ChartAreas[0];
                    area.AxisX.LabelStyle.Format = "dd/MM";
                    area.AxisX.IntervalType = DateTimeIntervalType.Days;
                    area.AxisX.MajorGrid.Enabled = false;

                    area.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
                    area.AxisY.Title = "Montant (DT)";
                    area.AxisX.Title = "Date";

                    // AJOUT DES DONNÉES
                    foreach (DataRow row in dt.Rows)
                    {
                        DateTime date = Convert.ToDateTime(row["Jour"]);
                        double montant = Convert.ToDouble(row["TotalJour"]);

                        chart1.Series["Series1"].Points.AddXY(date, montant);
                    }

                    if (dt.Rows.Count == 0 && isGenerateClicked)
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

        // LOAD FORM
        private void Form10_Load(object sender, EventArgs e)
        {
            DateTime start = DateTime.Today.AddDays(-7);
            DateTime end = DateTime.Today.AddDays(1).AddSeconds(-1);

            LoadChart(start, end);

            if (!string.IsNullOrEmpty(role) && role.ToLower() == "employe")
            {
                btncat.Enabled = false;
                btnpro.Enabled = false;
                btnsale.Enabled = false;
            }
        }

       
        private void btnres_Click(object sender, EventArgs e)
        {
            new Form11(role).Show();
            this.Close();
        }

        private void btnhome_Click(object sender, EventArgs e)
        {
            new dashBoard(role).Show();
            this.Close();
        }

        private void btnorder_Click(object sender, EventArgs e)
        {
            new Form7(role).Show();
            this.Close();
        }

        private void btnhist_Click(object sender, EventArgs e)
        {
            new Form8(role).Show();
            this.Close();
        }

        private void btncat_Click(object sender, EventArgs e)
        {
            new Form5(role).Show();
            this.Close();
        }

        private void btnpro_Click(object sender, EventArgs e)
        {
            new Form3(role).Show();
            this.Close();
        }

        private void btndec_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Voulez-vous vraiment vous déconnecter ?",
                "Déconnexion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.No)
                return;

            new loginForm().Show();
            this.Close();
        }

        private void btnsale_Click(object sender, EventArgs e)
        {
            new Form10(role).Show();
            this.Close();
        }
    }
}
