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
    public partial class Form8 : Form
    {
        private string role;

        private string conString = "Data Source=DESKTOP-8GP80EP\\SQLEXPRESS;Initial Catalog=TapAndTaste;User ID=n8n_users;Password=islem123!;TrustServerCertificate=True";

        public Form8()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        public Form8(string userRole)
        {
            InitializeComponent();
            this.role = userRole;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            LoadCommandes();
            ConfigureDataGridView();
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

        // Configurer l'apparence du DataGridView
        private void ConfigureDataGridView()
        {
            dgvcommande.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvcommande.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvcommande.ReadOnly = true;
        }

        // Charger toutes les commandes
        private void LoadCommandes(string searchTerm = "")
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                try
                {
                    con.Open();

                    string query = @"
                        SELECT 
                            c.idcommande,
                            c.datecommande,
                            c.montanttotal,
                            u.nom,
                            c.idutilisateur
                        FROM commande c
                        INNER JOIN utilisateur u ON c.idutilisateur = u.idutilisateur
                        WHERE (@searchTerm = '' OR 
                               CAST(c.idcommande AS VARCHAR) LIKE '%' + @searchTerm + '%' OR
                               u.nom LIKE '%' + @searchTerm + '%' OR
                               CAST(c.montanttotal AS VARCHAR) LIKE '%' + @searchTerm + '%')
                        ORDER BY c.datecommande DESC";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@searchTerm", searchTerm);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvcommande.DataSource = dt;

                    // Renommer les colonnes pour l'affichage
                    if (dgvcommande.Columns.Count > 0)
                    {
                        dgvcommande.Columns["idcommande"].HeaderText = "N° Commande";
                        dgvcommande.Columns["datecommande"].HeaderText = "Date";
                        dgvcommande.Columns["montanttotal"].HeaderText = "Montant Total";
                        dgvcommande.Columns["nom"].HeaderText = "Utilisateur";
                        dgvcommande.Columns["idutilisateur"].Visible = false;

                        // Formater les colonnes
                        dgvcommande.Columns["datecommande"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                        dgvcommande.Columns["montanttotal"].DefaultCellStyle.Format = "0.00## DT";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur de chargement des commandes : " + ex.Message);
                }
            }
        }

        // Recherche des commandes
        private void btnsearch_Click(object sender, EventArgs e)
        {

        }
        private void btnsearch_Click_1(object sender, EventArgs e)
        {
            string searchTerm = textBoxRech.Text.Trim();
            LoadCommandes(searchTerm);
        }

        // Appuyer sur Entrée dans la textbox de recherche
        private void textBoxRech_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnsearch_Click(sender, e);
                e.Handled = true;
            }
        }

        // Modifier une commande
        private void btnmodifier_Click(object sender, EventArgs e)
        {
 
        }
        private void btnmodifier_Click_1(object sender, EventArgs e)
        {
            if (dgvcommande.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner une commande à modifier.");
                return;
            }

            DataGridViewRow selectedRow = dgvcommande.SelectedRows[0];
            int idCommande = Convert.ToInt32(selectedRow.Cells["idcommande"].Value);

            // Ouvrir le formulaire de modification
            Form9 formModif = new Form9(idCommande);
            formModif.ShowDialog();

            // Recharger les données après modification
            LoadCommandes(textBoxRech.Text.Trim());
        }

        // Supprimer une commande
        private void btnsupp_Click(object sender, EventArgs e)
        {
 
        }
        private void btnsupp_Click_1(object sender, EventArgs e)
        {
            if (dgvcommande.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner une commande à supprimer.");
                return;
            }

            DataGridViewRow selectedRow = dgvcommande.SelectedRows[0];
            int idCommande = Convert.ToInt32(selectedRow.Cells["idcommande"].Value);
            string dateCommande = Convert.ToDateTime(selectedRow.Cells["datecommande"].Value).ToString("dd/MM/yyyy HH:mm");
            decimal montant = Convert.ToDecimal(selectedRow.Cells["montanttotal"].Value);

            DialogResult result = MessageBox.Show(
                $"Êtes-vous sûr de vouloir supprimer la commande #{idCommande} du {dateCommande} d'un montant de {montant:0.00} DT ?",
                "Confirmation de suppression",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                SupprimerCommande(idCommande);
            }
        }

        private void SupprimerCommande(int idCommande)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                SqlTransaction transaction = con.BeginTransaction();

                try
                {
                    
                    string deleteLignes = "DELETE FROM lignecommande WHERE idcommande = @idCommande";
                    SqlCommand cmd1 = new SqlCommand(deleteLignes, con, transaction);
                    cmd1.Parameters.AddWithValue("@idCommande", idCommande);
                    cmd1.ExecuteNonQuery();

                    
                    string deleteCommande = "DELETE FROM commande WHERE idcommande = @idCommande";
                    SqlCommand cmd2 = new SqlCommand(deleteCommande, con, transaction);
                    cmd2.Parameters.AddWithValue("@idCommande", idCommande);
                    int rowsAffected = cmd2.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        transaction.Commit();
                        MessageBox.Show("Commande supprimée avec succès !");
                        LoadCommandes(textBoxRech.Text.Trim());
                    }
                    else
                    {
                        transaction.Rollback();
                        MessageBox.Show("Erreur lors de la suppression de la commande.");
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Erreur lors de la suppression : " + ex.Message);
                }
            }
        }

        // Double-clic sur une ligne pour la modifier
        private void dgvCommandes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnmodifier_Click(sender, e);
            }
        }

        // Rafraîchir la liste
        private void btnRafraichir_Click(object sender, EventArgs e)
        {

        }

        // Vider le champ de recherche
        private void btnClearSearch_Click(object sender, EventArgs e)
        {

        }
        private void btnRafraichir_Click_1(object sender, EventArgs e)
        {
            textBoxRech.Clear();
            LoadCommandes();
        }
        private void btnhome_Click(object sender, EventArgs e)
        {
            dashBoard f = new dashBoard(role);
            f.Show();     
            this.Close(); 
        }
        private void btnorder_Click_1(object sender, EventArgs e)
        {
            Form7 f = new Form7(role);
            f.Show();     
            this.Close(); 
        }

        private void btncategorie_Click_1(object sender, EventArgs e)
        {
            Form5 f = new Form5(role);
            f.Show();     
            this.Close(); 
        }

        private void btnProduct_Click_1(object sender, EventArgs e)
        {
            Form3 f = new Form3(role);
            f.Show();     
            this.Close(); 
        }

        private void btndeconexion_Click_1(object sender, EventArgs e)
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
            f.Show();     
            this.Close(); 
        }

        private void btnreservation_Click(object sender, EventArgs e)
        {
            Form11 f = new Form11(role);
            f.Show();     
            this.Close(); 
        }
    }
}
