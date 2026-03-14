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
    public partial class Form6 : Form
    {
        private int idcategorie = -1;
        private bool isEditMode = false;

        public Form6()
        {
            InitializeComponent();
            isEditMode = false;

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public Form6(string id, string nom) // Mode modification
        {
            InitializeComponent();
            isEditMode = true;
            this.StartPosition = FormStartPosition.CenterScreen;


            textBoxnom.Text = nom;
            idcategorie = Convert.ToInt32(id); 

        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            string conString = "Data Source=DESKTOP-8GP80EP\\SQLEXPRESS;Initial Catalog=TapAndTaste;User ID=n8n_users;Password=islem123!;TrustServerCertificate=True";

            using (SqlConnection con = new SqlConnection(conString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd;

                    if (isEditMode == false)
                    {
                        //  Mode AJOUT
                        string query = "INSERT INTO categorie (nomcategorie) " +"VALUES (@nom)";

                        cmd = new SqlCommand(query, con);
                       
                        cmd.Parameters.AddWithValue("@nom", textBoxnom.Text);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Catégorie ajoutée avec succès !");
                    }
                    else
                    {
                        //  Mode MODIFICATION
                        string query = "UPDATE categorie SET nomcategorie=@nom WHERE idcategorie=@idcategorie";

                        cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@nom", textBoxnom.Text);
                        cmd.Parameters.AddWithValue("@idcategorie", idcategorie);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Catégorie modifiée avec succès !");
                    }

                    this.Close(); // Ferme Form6 
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
