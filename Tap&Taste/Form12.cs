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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Tap_Taste
{
    public partial class Form12 : Form
    {
        private int idReservation = -1;
        private bool isEditMode = false;
        private string conString = "Data Source=DESKTOP-8GP80EP\\SQLEXPRESS;Initial Catalog=TapAndTaste;User ID=n8n_users;Password=islem123!;TrustServerCertificate=True";


        public Form12()
        {
            InitializeComponent();
            isEditMode = false;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form12_Load(object sender, EventArgs e)
        {
            // Initialiser la date minimum à aujourd'hui
            dateTimePicker1.MinDate = DateTime.Today;
        }
        public Form12(string id, string date, string heure, string client, string nb, string tel)
        {
            idReservation = Convert.ToInt32(id); 

            InitializeComponent();
            isEditMode = true;
            dateTimePicker1.Value = DateTime.Parse(date);
            textBoxHeure.Text = heure;
            textBoxNom.Text = client;
            numericUpDown1.Value = int.Parse(nb);
            textBoxTel.Text = tel;

            this.StartPosition = FormStartPosition.CenterScreen;

        }

       
        // SAVE (ajout ou modification)
      
        private void btnsave_Click(object sender, EventArgs e)
        {

        }
        private void btnsave_Click_1(object sender, EventArgs e)
        {
            // Validation des champs obligatoires
            if (string.IsNullOrWhiteSpace(textBoxNom.Text) ||
                string.IsNullOrWhiteSpace(textBoxHeure.Text) ||
                string.IsNullOrWhiteSpace(textBoxTel.Text))
            {
                MessageBox.Show("Tous les champs sont obligatoires.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validation de la date 
            if (dateTimePicker1.Value.Date < DateTime.Today)
            {
                MessageBox.Show("La date doit être aujourd'hui ou une date future.", "Erreur de date", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateTimePicker1.Focus();
                return;
            }

            // Validation de l'heure 
            if (!TimeSpan.TryParse(textBoxHeure.Text, out TimeSpan heureReservation))
            {
                MessageBox.Show("Format d'heure invalide. Utilisez le format HH:mm.", "Erreur d'heure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxHeure.Focus();
                return;
            }

            if (heureReservation < TimeSpan.FromHours(8) || heureReservation > TimeSpan.FromHours(20))
            {
                MessageBox.Show("L'heure doit être comprise entre 8h et 20h.", "Erreur d'heure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxHeure.Focus();
                return;
            }
            // Si la réservation est pour aujourd'hui, vérifier que l'heure est future
            if (dateTimePicker1.Value.Date == DateTime.Today)
            {
                TimeSpan heureActuelle = DateTime.Now.TimeOfDay;

                if (heureReservation <= heureActuelle)
                {
                    MessageBox.Show(
                        "Pour une réservation aujourd'hui, l'heure doit être supérieure à l'heure actuelle.",
                        "Heure invalide",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    textBoxHeure.Focus();
                    return;
                }
            }

            // Validation du nombre de personnes
            if (numericUpDown1.Value <= 0)
            {
                MessageBox.Show("Le nombre de personnes doit être supérieur à 0.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                numericUpDown1.Focus();
                return;
            }

            //Validation du numéro de téléphone 
            string telNettoye = textBoxTel.Text.Trim();

            // Supprimer tous les caractères non numériques
            string telNumerique = new string(telNettoye.Where(char.IsDigit).ToArray());

            if (telNumerique.Length != 8)
            {
                MessageBox.Show("Le numéro de téléphone doit contenir exactement 8 chiffres.", "Erreur de téléphone", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxTel.Focus();
                return;
            }

            // Formatage du téléphone pour la base de données
            string telFormate = telNumerique;

            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                SqlCommand cmd;

                if (!isEditMode)
                {
                    // AJOUT
                    string query = "INSERT INTO reservation VALUES (@date, @heure, @nom, @nb, @tel)";
                    cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value.Date);
                    cmd.Parameters.AddWithValue("@heure", textBoxHeure.Text);
                    cmd.Parameters.AddWithValue("@nom", textBoxNom.Text.Trim());
                    cmd.Parameters.AddWithValue("@nb", (int)numericUpDown1.Value);
                    cmd.Parameters.AddWithValue("@tel", telFormate);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Réservation ajoutée avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // MODIFICATION
                    string query = "UPDATE reservation SET dateReservation=@date, heure=@heure, nomClient=@nom, " +
                                   "nombrePersonnes=@nb, telephone=@tel WHERE idReservation=@idReservation";

                    cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value.Date);
                    cmd.Parameters.AddWithValue("@heure", textBoxHeure.Text);
                    cmd.Parameters.AddWithValue("@nom", textBoxNom.Text.Trim());
                    cmd.Parameters.AddWithValue("@nb", (int)numericUpDown1.Value);
                    cmd.Parameters.AddWithValue("@tel", telFormate);
                    cmd.Parameters.AddWithValue("@idReservation", idReservation);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Réservation modifiée avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Aucune réservation n'a été modifiée.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                this.Close();
            }
        }

        // Validation en temps réel pour le téléphone
        private void textBoxTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Autoriser uniquement les chiffres, le backspace et le signe + (optionnel)
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != '+')
            {
                e.Handled = true;
            }
        }

        // Validation en temps réel pour l'heure
        private void textBoxHeure_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxHeure.Text))
            {
                if (!TimeSpan.TryParse(textBoxHeure.Text, out TimeSpan heure))
                {
                    MessageBox.Show("Format d'heure invalide. Utilisez HH:mm.", "Format incorrect", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxHeure.Focus();
                }
                else if (heure < TimeSpan.FromHours(8) || heure > TimeSpan.FromHours(20))
                {
                    MessageBox.Show("L'heure doit être entre 8h et 20h.", "Horaire invalide", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxHeure.Focus();
                }
            }
        }

        // Validation en temps réel pour la date
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value.Date < DateTime.Today)
            {
                MessageBox.Show("La date ne peut pas être dans le passé. Elle a été réinitialisée à aujourd'hui.",
                    "Date incorrecte", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dateTimePicker1.Value = DateTime.Today;
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
         
        }

        private void btnclose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
