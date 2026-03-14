using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Tap_Taste
{
    public partial class Form4 : Form
    {
        private int idProduit = -1;
        private bool isEditMode = false;
        private string imagePath = "";

        
        public Form4()
        {
            InitializeComponent();
            isEditMode = false;
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        public Form4(string id, string nom, string prix, string desc, string idCat, string img)
        {

            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            isEditMode = true;
            idProduit = Convert.ToInt32(id); //  AJOUT de l'id IMPORTANT
            textBoxNom.Text = nom;
            textBoxPrix.Text = prix;
            textBoxDescription.Text = desc;

            // On stocke la catégorie pour la sélectionner dans Form4_Load
            this.Tag = idCat;

            imagePath = img;


            // Charger l'image dans le PictureBox si elle existe
            if (!string.IsNullOrEmpty(img) && File.Exists(img))
            {
                try
                {
                    pictureBoxProduit.Image = Image.FromFile(img);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur de chargement d'image : " + ex.Message);
                }
            }
        }

        // BOUTON SAVE
        private void btnsave_Click(object sender, EventArgs e)
        {
            // Validation de base
            if (string.IsNullOrEmpty(textBoxNom.Text) || string.IsNullOrEmpty(textBoxPrix.Text) || comboBoxCategorie.SelectedValue == null)
            {
                MessageBox.Show("Veuillez remplir au moins le Nom, le Prix et la Catégorie.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!float.TryParse(textBoxPrix.Text, out float prixProduit))
            {
                MessageBox.Show("Veuillez saisir un prix valide.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            string conString = "Data Source=DESKTOP-8GP80EP\\SQLEXPRESS;Initial Catalog=TapAndTaste;User ID=n8n_users;Password=islem123!;TrustServerCertificate=True";

            using (SqlConnection con = new SqlConnection(conString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd;

                    int idCat = Convert.ToInt32(comboBoxCategorie.SelectedValue);

                    if (!isEditMode)
                    {
                        // ➤ AJOUT
              

                        string query = "INSERT INTO produit (nomproduit, prixproduit, descriptionproduit, idcategorie, imagepath) " +
                                       "VALUES (@nom, @prix, @desc, @cat, @img)";

                        cmd = new SqlCommand(query, con);
                  
                        cmd.Parameters.AddWithValue("@nom", textBoxNom.Text);
                        cmd.Parameters.AddWithValue("@prix", prixProduit); 
                        cmd.Parameters.AddWithValue("@desc", textBoxDescription.Text);
                        cmd.Parameters.AddWithValue("@cat", idCat);
                        cmd.Parameters.AddWithValue("@img", imagePath);



                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Produit ajouté avec succès !");
                    }
                    else
                    {
                        // MODIFICATION
                        string query = "UPDATE produit SET nomproduit=@nom, prixproduit=@prix, descriptionproduit=@desc, idcategorie=@cat, imagepath=@img " +
                                       "WHERE idproduit=@idproduit";

                        cmd = new SqlCommand(query, con);
                      
                        cmd.Parameters.AddWithValue("@nom", textBoxNom.Text);
                        cmd.Parameters.AddWithValue("@prix", prixProduit); 
                        cmd.Parameters.AddWithValue("@desc", textBoxDescription.Text);
                        cmd.Parameters.AddWithValue("@cat", idCat);
                        cmd.Parameters.AddWithValue("@img", imagePath);
                        cmd.Parameters.AddWithValue("@idproduit", idProduit);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Produit modifié avec succès !");
                    }

                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur SQL : " + ex.Message);
                }
            }
        }

        // CHARGEMENT DES CATEGORIES
        private void Form4_Load(object sender, EventArgs e)
        {

            string conString = "Data Source=DESKTOP-8GP80EP\\SQLEXPRESS;Initial Catalog=TapAndTaste;User ID=n8n_users;Password=islem123!;TrustServerCertificate=True";

            using (SqlConnection con = new SqlConnection(conString))
            {
                try
                {
                    con.Open();

                    string query = "SELECT idcategorie, nomcategorie FROM categorie";
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    comboBoxCategorie.DataSource = dt;
                    comboBoxCategorie.DisplayMember = "nomcategorie";
                    comboBoxCategorie.ValueMember = "idcategorie";

                    // SÉLECTION de la catégorie si nous sommes en mode modification
                    if (isEditMode && this.Tag != null)
                    {
                        comboBoxCategorie.SelectedValue = this.Tag;
                        this.Tag = null; // Nettoyer le tag après utilisation
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur de chargement des catégories : " + ex.Message);
                }
            }
        }

        // BOUTON BROWSE (IMPORT IMAGE)
        private void buttonBrowseImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Sélectionnez une image pour le produit";
            // Filtres standards pour les images
            ofd.Filter = "Fichiers images|*.jpg;*.jpeg;*.png;*.bmp|Tous les fichiers|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Stocker le chemin du fichier sélectionné (pour l'enregistrement en base de données)
                    imagePath = ofd.FileName;

                    // Utiliser un Stream pour charger l'image
                    // Cela permet de libérer le fichier immédiatement après le chargement, 
                    // évitant ainsi le verrouillage du fichier.
                    using (FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                    {
                        // Crée une copie interne de l'image à partir du flux
                        pictureBoxProduit.Image = Image.FromStream(fs);
                    }

                    // Mettre le PictureBox en mode Zoom ou StretchImage pour bien afficher l'image
                    pictureBoxProduit.SizeMode = PictureBoxSizeMode.Zoom;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors du chargement de l'image : " + ex.Message, "Erreur Image", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    imagePath = ""; // Réinitialiser le chemin en cas d'erreur
                }
            }
        }
        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}