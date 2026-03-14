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
    public partial class Form9 : Form
    {
        private string conString = "Data Source=DESKTOP-8GP80EP\\SQLEXPRESS;Initial Catalog=TapAndTaste;User ID=n8n_users;Password=islem123!;TrustServerCertificate=True";
        private int idCommande;

        public Form9(int commandeId)
        {
            InitializeComponent();
            idCommande = commandeId;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            ConfigureDataGridView();
            LoadDetailsCommande();
            LoadLignesCommande();
            dgvOrder.CellEndEdit += dgvOrder_CellEndEdit;
        
        }
        private void dgvOrder_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvOrder.Columns["quantite"].Index)
            {
                RecalculateRowAmount(e.RowIndex);
                CalculateTotal();
            }
        }


        private void ConfigureDataGridView()
        {
            dgvOrder.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrder.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrder.AllowUserToAddRows = false;
            dgvOrder.AllowUserToDeleteRows = true;

            if (dgvOrder.Columns.Count == 0)
            {
                dgvOrder.Columns.Add("idlignecommande", "ID Ligne");
                dgvOrder.Columns.Add("idproduit", "ID Produit");
                dgvOrder.Columns.Add("produit", "Produit");
                dgvOrder.Columns.Add("quantite", "Quantité");
                dgvOrder.Columns.Add("prix", "Prix");
                dgvOrder.Columns.Add("montant", "Montant");

                dgvOrder.Columns["idlignecommande"].Visible = false;
                dgvOrder.Columns["idproduit"].Visible = false;

                dgvOrder.Columns["quantite"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvOrder.Columns["prix"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvOrder.Columns["montant"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                dgvOrder.Columns["prix"].DefaultCellStyle.Format = "0.00";
                dgvOrder.Columns["montant"].DefaultCellStyle.Format = "0.00";
            }
        }

        private void LoadDetailsCommande()
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                try
                {
                    con.Open();
                    string query = @"
                        SELECT c.idcommande, c.montanttotal
                        FROM commande c
                        WHERE c.idcommande = @idCommande";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@idCommande", idCommande);

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        this.Text = $"Modification - Commande #{dr["idcommande"]}";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur de chargement des détails : " + ex.Message);
                }
            }
        }

        private void LoadLignesCommande()
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                try
                {
                    con.Open();
                    string query = @"
                        SELECT 
                            lc.idlignecommande,
                            lc.idproduit,
                            p.nomproduit,
                            lc.quantite,
                            lc.prixunitaire,
                            (lc.quantite * lc.prixunitaire) as montant
                        FROM lignecommande lc
                        INNER JOIN produit p ON lc.idproduit = p.idproduit
                        WHERE lc.idcommande = @idCommande";

                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    da.SelectCommand.Parameters.AddWithValue("@idCommande", idCommande);

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvOrder.Rows.Clear();

                    foreach (DataRow row in dt.Rows)
                    {
                        dgvOrder.Rows.Add(
                            row["idlignecommande"],
                            row["idproduit"],
                            row["nomproduit"],
                            row["quantite"],
                            row["prixunitaire"],
                            row["montant"]
                        );
                    }

                    CalculateTotal();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur de chargement des lignes : " + ex.Message);
                }
            }
        }

        private void CalculateTotal()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in dgvOrder.Rows)
            {
                if (!row.IsNewRow && row.Cells["montant"].Value != null)
                {
                    total += Convert.ToDecimal(row.Cells["montant"].Value);
                }
            }

            labelprix.Text = total.ToString("0.00") + " DT";
        }

        private void dgvOrder_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Recalculer le montant si la quantité change
                if (e.ColumnIndex == dgvOrder.Columns["quantite"].Index)
                {
                    RecalculateRowAmount(e.RowIndex);
                    CalculateTotal();
                }
            }
        }

        private void RecalculateRowAmount(int rowIndex)
        {
            DataGridViewRow row = dgvOrder.Rows[rowIndex];

            if (row.Cells["quantite"].Value != null && row.Cells["prix"].Value != null)
            {
                int quantite = Convert.ToInt32(row.Cells["quantite"].Value);
                decimal prix = Convert.ToDecimal(row.Cells["prix"].Value);
                decimal montant = quantite * prix;

                row.Cells["montant"].Value = montant;
            }
        }

        private void btnsave_Click_1(object sender, EventArgs e)
        {
            if (dgvOrder.Rows.Count == 0 || (dgvOrder.Rows.Count == 1 && dgvOrder.Rows[0].IsNewRow))
            {
                MessageBox.Show("La commande ne contient aucun produit !");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Êtes-vous sûr de vouloir sauvegarder les modifications ?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                SauvegarderModifications();
            }
        }

        private void SauvegarderModifications()
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                SqlTransaction transaction = con.BeginTransaction();

                try
                {
                    // Supprimer les anciennes lignes de commande
                    string deleteQuery = "DELETE FROM lignecommande WHERE idcommande = @idCommande";
                    SqlCommand deleteCmd = new SqlCommand(deleteQuery, con, transaction);
                    deleteCmd.Parameters.AddWithValue("@idCommande", idCommande);
                    deleteCmd.ExecuteNonQuery();

                    // Insérer les nouvelles lignes
                    string insertQuery = @"
                        INSERT INTO lignecommande (idcommande, idproduit, quantite, prixunitaire)
                        VALUES (@idcommande, @idproduit, @quantite, @prix)";

                    foreach (DataGridViewRow row in dgvOrder.Rows)
                    {
                        if (row.IsNewRow) continue;

                        SqlCommand insertCmd = new SqlCommand(insertQuery, con, transaction);
                        insertCmd.Parameters.AddWithValue("@idcommande", idCommande);
                        insertCmd.Parameters.AddWithValue("@idproduit", Convert.ToInt32(row.Cells["idproduit"].Value));
                        insertCmd.Parameters.AddWithValue("@quantite", Convert.ToInt32(row.Cells["quantite"].Value));
                        insertCmd.Parameters.AddWithValue("@prix", Convert.ToDecimal(row.Cells["prix"].Value));

                        insertCmd.ExecuteNonQuery();
                    }

                    // Mettre à jour le montant total de la commande
                    string updateCommandeQuery = @"
                        UPDATE commande 
                        SET montanttotal = @montant 
                        WHERE idcommande = @idCommande";

                    SqlCommand updateCmd = new SqlCommand(updateCommandeQuery, con, transaction);
                    updateCmd.Parameters.AddWithValue("@montant", GetTotalSansDT());
                    updateCmd.Parameters.AddWithValue("@idCommande", idCommande);
                    updateCmd.ExecuteNonQuery();

                    transaction.Commit();
                    MessageBox.Show("Modifications sauvegardées avec succès !");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Erreur lors de la sauvegarde : " + ex.Message);
                }
            }
        }

        private decimal GetTotalSansDT()
        {
            string totalText = labelprix.Text.Replace(" DT", "").Trim();
            return Convert.ToDecimal(totalText);
        }

        private void btnclose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvOrder_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvOrder.CurrentCell.ColumnIndex == dgvOrder.Columns["quantite"].Index)
            {
                TextBox textBox = e.Control as TextBox;
                if (textBox != null)
                {
                    textBox.KeyPress -= ValidateNumericInput;
                    textBox.KeyPress += ValidateNumericInput;
                }
            }
        }

        private void ValidateNumericInput(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dgvOrder_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (dgvOrder.Rows.Count == 1)
            {
                MessageBox.Show("Une commande doit contenir au moins un produit !");
                e.Cancel = true;
            }
        }

        private void btnsupp_Click(object sender, EventArgs e)
        {
            if (dgvOrder.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner un produit à supprimer !");
                return;
            }

            // Empêcher de supprimer la dernière ligne
            if (dgvOrder.Rows.Count == 1)
            {
                MessageBox.Show("Une commande doit contenir au moins un produit !");
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Voulez-vous vraiment supprimer ce produit de la commande ?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm == DialogResult.Yes)
            {
                dgvOrder.Rows.RemoveAt(dgvOrder.SelectedRows[0].Index);

                // Recalculer total après suppression
                CalculateTotal();
            }
        }
    }
}
