using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Tap_Taste
{
    public partial class loginForm : Form
    {
        SqlConnection cnx;

        public loginForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            try
            {
                cnx = new SqlConnection("Data Source=DESKTOP-8GP80EP\\SQLEXPRESS;Initial Catalog=TapAndTaste;User ID=n8n_users;Password=islem123!;TrustServerCertificate=True;");

                cnx.Open();

                // Vérifier si l'utilisateur existe
                string checkUserQuery = "SELECT COUNT(1) FROM utilisateur WHERE email = @user";

                using (SqlCommand cmdCheckUser = new SqlCommand(checkUserQuery, cnx))
                {
                    cmdCheckUser.Parameters.AddWithValue("@user", userName.Text);
                    int userCount = (int)cmdCheckUser.ExecuteScalar();

                    if (userCount == 0)
                    {
                        MessageBox.Show("Adresse email incorrecte ou inexistante.",
                            "Erreur de Connexion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Vérifier mot de passe + récupérer le rôle
                string fullCheckQuery = "SELECT role FROM utilisateur WHERE email = @user AND motdepasse = @pass";

                using (SqlCommand cmdFullCheck = new SqlCommand(fullCheckQuery, cnx))
                {
                    cmdFullCheck.Parameters.AddWithValue("@user", userName.Text);
                    cmdFullCheck.Parameters.AddWithValue("@pass", password.Text);

                    object result = cmdFullCheck.ExecuteScalar();

                    if (result != null)
                    {
                        string role = result.ToString(); // récupéré le role (admin ou employe)

                        // Ouvrir le dashboard avec le rôle
                        dashBoard main = new dashBoard(role);
                        main.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Mot de passe incorrect.",
                            "Erreur de Connexion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message, "Erreur Critique", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
