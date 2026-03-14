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
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Tap_Taste
{
    public partial class Form3 : Form
    {
        private string role;
        public Form3()
        {
            InitializeComponent();
        }
 
        public Form3(string userRole)
        {
            InitializeComponent();
            this.role = userRole;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            // Utilise le constructeur par défaut de Form4 pour l'ajout
            Form4 ajouterProduit = new Form4();
            ajouterProduit.ShowDialog();
            LoadProducts(); // Rafraîchir après ajout
        }
        
        public void LoadProducts()
        {
            string conString = "Data Source=DESKTOP-8GP80EP\\SQLEXPRESS;Initial Catalog=TapAndTaste;User ID=n8n_users;Password=islem123!;TrustServerCertificate=True";

            using (SqlConnection con = new SqlConnection(conString))
            {
                try
                {
                    con.Open();
                    string query = "SELECT idproduit AS ID, nomproduit AS Name, prixproduit AS Price, descriptionproduit AS Description, idcategorie, imagepath FROM produit";

                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvProducts.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            LoadProducts();
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

        private void btnmodifier_Click(object sender, EventArgs e)
        {
            // VÉRIFICATION DE LA SÉLECTION 
            if (dgvProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner un produit.");
                return;
            }

            // Récupération des données sélectionnées
            string id = dgvProducts.SelectedRows[0].Cells["ID"].Value.ToString();
            string nom = dgvProducts.SelectedRows[0].Cells["Name"].Value.ToString();
            string prix = dgvProducts.SelectedRows[0].Cells["Price"].Value.ToString();
            string desc = dgvProducts.SelectedRows[0].Cells["Description"].Value.ToString();

            // CORRECTION : Récupération des champs supplémentaires
            string idCat = dgvProducts.SelectedRows[0].Cells["idcategorie"].Value.ToString();
            string img = dgvProducts.SelectedRows[0].Cells["imagepath"].Value.ToString();

            //  Ouvrir Form4 en mode édition
            Form4 modifierProduit = new Form4(id, nom, prix, desc, idCat, img);
            modifierProduit.ShowDialog();

            // Rafraîchir
            LoadProducts();
        }

        private void btnsupp_Click(object sender, EventArgs e)
        {
            // Vérifier qu'une ligne est sélectionnée
            if (dgvProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner un produit à supprimer.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Demander confirmation
            if (MessageBox.Show("Êtes-vous sûr de vouloir supprimer ce produit ?", "Confirmer la suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }

            // Récupération de l'ID du produit sélectionné
            string idProduit = dgvProducts.SelectedRows[0].Cells["ID"].Value.ToString();

            string conString = "Data Source=DESKTOP-8GP80EP\\SQLEXPRESS;Initial Catalog=TapAndTaste;User ID=n8n_users;Password=islem123!;TrustServerCertificate=True";

            using (SqlConnection con = new SqlConnection(conString))
            {
                try
                {
                    con.Open();

                    // Requête de suppression 
                    string query = "DELETE FROM produit WHERE idproduit = @idproduit";

                    SqlCommand cmd = new SqlCommand(query, con);
                    // Ajout du paramètre ID
                    cmd.Parameters.AddWithValue("@idproduit", int.Parse(idProduit));

                    // Exécuter la commande de suppression
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Produit supprimé avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //Mettre à jour le DataGridView après la suppression
                        LoadProducts();
                    }
                    else
                    {
                        MessageBox.Show("Aucun produit n'a été supprimé. Vérifiez l'ID.", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors de la suppression du produit : " + ex.Message, "Erreur de base de données", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            string searchValue = textBoxRech.Text.Trim();
            string query = "";

            // Si l’utilisateur ne tape rien
            if (string.IsNullOrEmpty(searchValue))
            {
                MessageBox.Show("Veuillez saisir un terme de recherche !");
                return;
            }

            // Si c'est un nombre id ou prix
            if (int.TryParse(searchValue, out int numericValue))
            {
                query = "SELECT idproduit AS ID, nomproduit AS Name, prixproduit AS Price, descriptionproduit AS Description, idcategorie, imagepath FROM Produit WHERE idproduit = @search OR prixproduit = @search"; // Changement de SELECT * pour avoir les alias
            }
            else
            {
                // Recherche texte nom ou categorie
                query = "SELECT idproduit AS ID, nomproduit AS Name, prixproduit AS Price, descriptionproduit AS Description, idcategorie, imagepath FROM Produit WHERE nomproduit LIKE @searchTxt";
            }


            using (SqlConnection cn = new SqlConnection("Data Source=DESKTOP-8GP80EP\\SQLEXPRESS;Initial Catalog=TapAndTaste;User ID=n8n_users;Password=islem123!;TrustServerCertificate=True"))
            {
                try
                {
                    cn.Open(); 
                    SqlCommand cmd = new SqlCommand(query, cn);

                    if (int.TryParse(searchValue, out numericValue))
                    {
                        cmd.Parameters.AddWithValue("@search", numericValue);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@searchTxt", "%" + searchValue + "%");
                    }

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvProducts.DataSource = dt;

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Aucun produit trouvé !");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors de la recherche : " + ex.Message);
                }
            }
        }

        private void btncategorie_Click(object sender, EventArgs e)
        {
            Form5 formulairecategorie = new Form5(role);
            formulairecategorie.Show(); 
            this.Close();
        }

        private void btnhome_Click(object sender, EventArgs e)
        {
            dashBoard f = new dashBoard(role);
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

        private void btnreservation_Click(object sender, EventArgs e)
        {
            Form11 f = new Form11(role);
            f.Show();     
            this.Close(); 
        }

        private void btnRafraichir_Click(object sender, EventArgs e)
        {
            textBoxRech.Clear();
            LoadProducts();
        }
        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
