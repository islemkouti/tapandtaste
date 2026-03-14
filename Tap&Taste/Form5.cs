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

namespace Tap_Taste
{
    public partial class Form5 : Form
    {
        private string role;

        public Form5()
        {
            InitializeComponent();
        }

        public Form5(string userRole)
        {
            InitializeComponent();
            this.role = userRole;
            this.StartPosition = FormStartPosition.CenterScreen;
        }


        private void btnadd_Click(object sender, EventArgs e)
        {
            Form6 ajoutercategorie = new Form6();
            ajoutercategorie.ShowDialog();

            LoadCategorie(); // Rafraîchir après ajout
        }

        public void LoadCategorie()
        {
            string conString = "Data Source=DESKTOP-8GP80EP\\SQLEXPRESS;Initial Catalog=TapAndTaste;User ID=n8n_users;Password=islem123!;TrustServerCertificate=True";

            using (SqlConnection con = new SqlConnection(conString))
            {
                try
                {
                    con.Open();
                    string query = "SELECT idcategorie AS ID, nomcategorie AS Name FROM categorie";
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvcategorie.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            LoadCategorie();
            if (role.ToLower() == "employe")
            {
                btncat.Enabled = false;
                btnpro.Enabled = false;
                btnsale.Enabled = false;
                // btncategorie.Visible = false;
                // btnProduct.Visible = false;
                // btnsale.Visible = false;
            }
        }

        private void btnmodifier_Click(object sender, EventArgs e)
        {
            if (dgvcategorie.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner une categorie.");
                return;
            }

            string id = dgvcategorie.SelectedRows[0].Cells["ID"].Value.ToString();
            string nom = dgvcategorie.SelectedRows[0].Cells["Name"].Value.ToString();

            Form6 modifierCategorie = new Form6(id, nom);
            modifierCategorie.ShowDialog();

            LoadCategorie(); // Rafraîchir après modification
        }

        private void btnsupp_Click(object sender, EventArgs e)
        {
            if (dgvcategorie.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner une categorie à supprimer.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Êtes-vous sûr de vouloir supprimer cette categorie ?",
                "Confirmer la suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }

            string idCategorie = dgvcategorie.SelectedRows[0].Cells["ID"].Value.ToString();

            string conString = "Data Source=DESKTOP-8GP80EP\\SQLEXPRESS;Initial Catalog=TapAndTaste;User ID=n8n_users;Password=islem123!;TrustServerCertificate=True";

            using (SqlConnection con = new SqlConnection(conString))
            {
                try
                {
                    con.Open();

                    string query = "DELETE FROM categorie WHERE idcategorie = @id";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", int.Parse(idCategorie));

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Categorie supprimée avec succès !", "Succès",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadCategorie();
                    }
                    else
                    {
                        MessageBox.Show("Aucune categorie n'a été supprimée. Vérifiez l'ID.",
                            "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors de la suppression : " + ex.Message,
                        "Erreur de base de données", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            string searchValue = textBoxRech.Text.Trim();
            string query = "";

            if (string.IsNullOrEmpty(searchValue))
            {
                MessageBox.Show("Veuillez saisir un terme de recherche !");
                return;
            }

            // Recherche : id ou nom
            if (int.TryParse(searchValue, out int numericValue))
            {
                query = "SELECT idcategorie AS ID, nomcategorie AS Name FROM categorie WHERE idcategorie = @id";
            }
            else
            {
                query = "SELECT idcategorie AS ID, nomcategorie AS Name FROM categorie WHERE nomcategorie LIKE @name";
            }

            using (SqlConnection cn = new SqlConnection("Data Source=DESKTOP-8GP80EP\\SQLEXPRESS;Initial Catalog=TapAndTaste;User ID=n8n_users;Password=islem123!;TrustServerCertificate=True"))
            {
                SqlCommand cmd = new SqlCommand(query, cn);

                if (int.TryParse(searchValue, out numericValue))
                {
                    cmd.Parameters.AddWithValue("@id", numericValue);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@name", "%" + searchValue + "%");
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvcategorie.DataSource = dt;

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Aucune categorie trouvée !");
                }
            }
        }

        private void btnhome_Click(object sender, EventArgs e)
        {
            dashBoard f = new dashBoard(role);
            f.Show();     
            this.Close(); 
        }

        private void btnpro_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3(role);
            f.Show();     
            this.Close(); 
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

        private void btnsale_Click(object sender, EventArgs e)
        {
            Form10 f = new Form10(role);
            f.Show();     
            this.Close(); 
        }

        private void btnres_Click(object sender, EventArgs e)
        {
            Form11 f = new Form11(role);
            f.Show();     
            this.Close(); 
        }

        private void btnRafraichir_Click(object sender, EventArgs e)
        {
            textBoxRech.Clear();
            LoadCategorie();
        }
    }

}
