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

        }
        public Form12(string id, string date, string heure, string client, string nb, string tel)
        {
            idReservation = Convert.ToInt32(id); // <<< AJOUT IMPORTANT

            InitializeComponent();
            isEditMode = true;
            dateTimePicker1.Value = DateTime.Parse(date);
            textBoxHeure.Text = heure;
            textBoxNom.Text = client;
            numericUpDown1.Value = int.Parse(nb);
            textBoxTel.Text = tel;

            this.StartPosition = FormStartPosition.CenterScreen;

        }

        // ==========================================================
        // 🔵 SAVE (ajout ou modification)
        // ==========================================================
        private void btnsave_Click(object sender, EventArgs e)
        {

        }
        private void btnsave_Click_1(object sender, EventArgs e)
        {
            if (textBoxNom.Text.Trim() == "" || textBoxHeure.Text.Trim() == "" || textBoxTel.Text.Trim() == "")
            {
                MessageBox.Show("Tous les champs sont obligatoires.");
                return;
            }

            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                SqlCommand cmd;

                if (!isEditMode)
                {
                    // AJOUT
                    string query = "INSERT INTO reservation VALUES ( @date, @heure, @nom, @nb, @tel)";
                    cmd = new SqlCommand(query, con);

                    
                    cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value.Date);
                    cmd.Parameters.AddWithValue("@heure", textBoxHeure.Text);
                    cmd.Parameters.AddWithValue("@nom", textBoxNom.Text);
                    cmd.Parameters.AddWithValue("@nb", (int)numericUpDown1.Value);
                    cmd.Parameters.AddWithValue("@tel", textBoxTel.Text);


                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Réservation ajoutée !");
                }
                else
                {
                    // MODIFICATION
                    string query = "UPDATE reservation SET dateReservation=@date, heure=@heure, nomClient=@nom, " +
                                   "nombrePersonnes=@nb, telephone=@tel WHERE idReservation=@idReservation";

                    cmd = new SqlCommand(query, con);

              
                    cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value.Date);
                    cmd.Parameters.AddWithValue("@heure", textBoxHeure.Text);
                    cmd.Parameters.AddWithValue("@nom", textBoxNom.Text);
                    cmd.Parameters.AddWithValue("@nb", (int)numericUpDown1.Value);
                    cmd.Parameters.AddWithValue("@tel", textBoxTel.Text);

                    // ►► AJOUT OBLIGATOIRE !!!
                    cmd.Parameters.AddWithValue("@idReservation", idReservation);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Réservation modifiée !");
                }

                this.Close();
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
