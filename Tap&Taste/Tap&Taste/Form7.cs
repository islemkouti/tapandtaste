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
using System.IO;

namespace Tap_Taste
{

    public partial class Form7 : Form
    {
        private string role;

        private string conString = "Data Source=DESKTOP-8GP80EP\\SQLEXPRESS;Initial Catalog=TapAndTaste;User ID=n8n_users;Password=islem123!;TrustServerCertificate=True";

        public Form7(string role = "")
        {
            InitializeComponent();
            this.role = role;

            InitializeDataGridView();

            dgvOrder.CellValueChanged += dgvOrder_CellValueChanged;
            dgvOrder.EditingControlShowing += dgvOrder_EditingControlShowing;
            dgvOrder.CellEndEdit += dgvOrder_CellEndEdit;
            dgvOrder.CurrentCellDirtyStateChanged += dgvOrder_CurrentCellDirtyStateChanged;

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void dgvOrder_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvOrder.IsCurrentCellDirty)
            {
                dgvOrder.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvOrder_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 &&
                dgvOrder.Columns[e.ColumnIndex].Name == "quantite")
            {
                DataGridViewRow row = dgvOrder.Rows[e.RowIndex];

                if (row.Cells["quantite"].Value != null &&
                    row.Cells["prix"].Value != null)
                {
                    int quantite = Convert.ToInt32(row.Cells["quantite"].Value);
                    double prix = Convert.ToDouble(row.Cells["prix"].Value);

                    row.Cells["amount"].Value = quantite * prix;

                    CalculateTotal();
                }
            }
        }

        private void dgvOrder_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvOrder.CurrentCell.ColumnIndex == dgvOrder.Columns["quantite"].Index)
            {
                TextBox txt = e.Control as TextBox;
                if (txt != null)
                {
                    txt.KeyPress -= Quantite_KeyPress;
                    txt.KeyPress += Quantite_KeyPress;
                }
            }
        }

        private void dgvOrder_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 &&
                dgvOrder.Columns[e.ColumnIndex].Name == "quantite")
            {
                DataGridViewRow row = dgvOrder.Rows[e.RowIndex];

                if (row.Cells["quantite"].Value != null &&
                    row.Cells["prix"].Value != null)
                {
                    int quantite = Convert.ToInt32(row.Cells["quantite"].Value);
                    double prix = Convert.ToDouble(row.Cells["prix"].Value);

                    row.Cells["amount"].Value = quantite * prix;

                    CalculateTotal();
                }
            }
        }


        private void Quantite_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }
        private void InitializeDataGridView()
        {
            dgvOrder.Columns["quantite"].ReadOnly = false;
            // Ajouter les colonnes si elles n'existent pas déjà
            if (dgvOrder.Columns.Count == 0)
            {
                dgvOrder.Columns.Add("idproduit", "ID");
                dgvOrder.Columns.Add("produit", "Produit");
                dgvOrder.Columns.Add("quantite", "Quantité");
                dgvOrder.Columns.Add("prix", "Prix");
                dgvOrder.Columns.Add("amount", "Montant");

                // Masquer la colonne ID si nécessaire
                dgvOrder.Columns["idproduit"].Visible = false;


            }
        }

        private void Form7_Load(object sender, EventArgs e)
        {
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
            flowLayoutPanelProducts.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanelProducts.WrapContents = true;
            flowLayoutPanelProducts.AutoScroll = true;
            LoadProducts_Flow(); // Charger tous les produits au départ

            using (SqlConnection con = new SqlConnection(conString))
            {
                try
                {
                    con.Open();

                    string query = "SELECT idcategorie, nomcategorie FROM categorie";
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Ajouter une option "Toutes les catégories"
                    DataRow allRow = dt.NewRow();
                    allRow["idcategorie"] = 0;
                    allRow["nomcategorie"] = "Toutes les catégories";
                    dt.Rows.InsertAt(allRow, 0);

                    comboBox1.DataSource = dt;
                    comboBox1.DisplayMember = "nomcategorie";
                    comboBox1.ValueMember = "idcategorie";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur de chargement des catégories : " + ex.Message);
                }
            }
        }

        public void LoadProducts_Flow(int? idCategorie = null)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                try
                {
                    con.Open();

                    string query = @"
                SELECT 
                    idproduit,
                    nomproduit,
                    prixproduit,
                    descriptionproduit,
                    idcategorie,
                    imagepath
                FROM produit";

                    if (idCategorie.HasValue && idCategorie.Value > 0)
                    {
                        query += " WHERE idcategorie = @idCategorie";
                    }

                    SqlCommand cmd = new SqlCommand(query, con);

                    if (idCategorie.HasValue && idCategorie.Value > 0)
                    {
                        cmd.Parameters.AddWithValue("@idCategorie", idCategorie.Value);
                    }

                    SqlDataReader dr = cmd.ExecuteReader();

                    flowLayoutPanelProducts.Controls.Clear();

                    while (dr.Read())
                    {
                        UserControl1 card = new UserControl1();

                        card.IdProduit = dr.GetInt32(0);
                        card.NomProduit = dr.GetString(1);
                        card.PrixProduit = Convert.ToDouble(dr["prixproduit"]); // Changé en double

                        card.DescriptionProduit = dr.IsDBNull(3)
                            ? "Aucune description"
                            : dr.GetString(3);

                        // Chargement image
                        if (!dr.IsDBNull(5))
                        {
                            string imagePath = dr.GetString(5);
                            if (File.Exists(imagePath))
                            {
                                card.ImageProduit = Image.FromFile(imagePath);
                            }
                        }

                        // ABONNEMENT À L'ÉVÉNEMENT - C'EST LA PARTIE MANQUANTE
                        card.ProductClicked += (id, nom, prix) =>
                        {
                            AddProductToOrder(id, nom, prix);
                        };

                        flowLayoutPanelProducts.Controls.Add(card);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur : " + ex.Message);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Cette méthode peut rester vide ou être utilisée pour d'autres fonctionnalités
        }

        // Méthode pour le bouton Filtrer (à connecter avec votre bouton)
        private void btnfilter_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != null)
            {
                int selectedCategorieId = Convert.ToInt32(comboBox1.SelectedValue);

                if (selectedCategorieId == 0)
                {
                    // Charger tous les produits
                    LoadProducts_Flow();
                }
                else
                {
                    // Charger les produits de la catégorie sélectionnée
                    LoadProducts_Flow(selectedCategorieId);
                }
            }
        }














        public void AddProductToOrder(int idProduit, string nom, double prix)
        {
            bool exists = false;

            foreach (DataGridViewRow row in dgvOrder.Rows)
            {
                if (row.IsNewRow) continue;

                if (row.Cells["idproduit"].Value != null &&
                    Convert.ToInt32(row.Cells["idproduit"].Value) == idProduit)
                {
                    int qte = Convert.ToInt32(row.Cells["quantite"].Value) + 1;

                    row.Cells["quantite"].Value = qte;
                    row.Cells["amount"].Value = qte * prix;

                    exists = true;
                    break;
                }
            }

            if (!exists)
            {
                dgvOrder.Rows.Add(idProduit, nom, 1, prix, prix);
            }

            CalculateTotal();
        }

        private void CalculateTotal()
        {
            double total = 0;

            foreach (DataGridViewRow row in dgvOrder.Rows)
            {
                if (!row.IsNewRow && row.Cells["amount"].Value != null)
                {
                    total += Convert.ToDouble(row.Cells["amount"].Value);
                }
            }

            labelprix.Text = total.ToString("0.00") + " DT";
        }


        private void btnsave_Click(object sender, EventArgs e)
        {
            // Vérifier si DataGridView a des produits réels
            int realRows = dgvOrder.Rows.Cast<DataGridViewRow>()
                .Count(r => !r.IsNewRow);

            if (realRows == 0)
            {
                MessageBox.Show("Aucun produit sélectionné !");
                return;
            }

            string conString = "Data Source=DESKTOP-8GP80EP\\SQLEXPRESS;Initial Catalog=TapAndTaste;User ID=n8n_users;Password=islem123!;TrustServerCertificate=True";

            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                SqlTransaction transaction = con.BeginTransaction();

                try
                {
                    // INSERT COMMANDE
                    string insertCommande = @"
                INSERT INTO commande (datecommande, montanttotal, idutilisateur)
                OUTPUT INSERTED.idcommande
                VALUES (@date, @total, @user)
            ";

                    SqlCommand cmd = new SqlCommand(insertCommande, con, transaction);

                    cmd.Parameters.AddWithValue("@date", DateTime.Now);

                    string totalText = labelprix.Text.Replace(" DT", "").Trim();
                    cmd.Parameters.AddWithValue("@total", Convert.ToDouble(totalText));

                    // ⚠️ Dans ton code tu as oublié l’ID utilisateur !!!
                    cmd.Parameters.AddWithValue("@user", 1); // À remplacer par idUtilisateur réel

                    int idCommande = (int)cmd.ExecuteScalar();

                    // INSERT LIGNES
                    string insertLigne = @"
                INSERT INTO lignecommande (idcommande, idproduit, quantite, prixunitaire)
                VALUES (@idc, @idp, @qte, @prix)
            ";

                    foreach (DataGridViewRow row in dgvOrder.Rows)
                    {
                        if (row.IsNewRow) continue;

                        SqlCommand cmd2 = new SqlCommand(insertLigne, con, transaction);
                        cmd2.Parameters.AddWithValue("@idc", idCommande);
                        cmd2.Parameters.AddWithValue("@idp", Convert.ToInt32(row.Cells["idproduit"].Value));
                        cmd2.Parameters.AddWithValue("@qte", Convert.ToInt32(row.Cells["quantite"].Value));
                        cmd2.Parameters.AddWithValue("@prix", Convert.ToDouble(row.Cells["prix"].Value));

                        cmd2.ExecuteNonQuery();
                    }

                    transaction.Commit();

                    MessageBox.Show("Commande sauvegardée avec succès ! ID: " + idCommande);

                    dgvOrder.Rows.Clear();
                    labelprix.Text = "0.00 DT";
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Erreur lors de l’enregistrement : " + ex.Message);
                }
            }
        }

        private void btnclean_Click(object sender, EventArgs e)
        {
            dgvOrder.Rows.Clear();
            labelprix.Text = "0.00 DT";
        }

        private void btnhome_Click(object sender, EventArgs e)
        {
            dashBoard f = new dashBoard(role);
            f.Show();     // Ouvre la nouvelle interface
            this.Close(); // Ferme l'interface actuelle
        }

        private void btncat_Click(object sender, EventArgs e)
        {
            Form5 formulairecategorie = new Form5(role);
            formulairecategorie.Show();
            this.Close();
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

        private void btnhist_Click(object sender, EventArgs e)
        {
            Form8 f = new Form8(role);
            f.Show();     // Ouvre la nouvelle interface
            this.Close(); // Ferme l'interface actuelle
        }

        private void btnsale_Click(object sender, EventArgs e)
        {
            Form10 f = new Form10(role);
            f.Show();     // Ouvre la nouvelle interface
            this.Close(); // Ferme l'interface actuelle
        }

        private void btnres_Click(object sender, EventArgs e)
        {
            Form11 f = new Form11(role);
            f.Show();     // Ouvre la nouvelle interface
            this.Close(); // Ferme l'interface actuelle
        }
    }
}
