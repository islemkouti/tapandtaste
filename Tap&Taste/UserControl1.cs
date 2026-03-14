using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tap_Taste
{
    public partial class UserControl1 : UserControl
    {
        // Evénement levé quand l'utilisateur clique sur la carte
        // signature : idProduit, nom, prix
        public event Action<int, string, double> ProductClicked;

        public UserControl1()
        {
            InitializeComponent();

            // Lier le click sur la carte et ses sous-contrôles
            this.Click += Card_Click;
            pictureBox1.Click += Card_Click;
            labelNom.Click += Card_Click;
            labelPrix.Click += Card_Click;
            labelDesc.Click += Card_Click;
        }

        private void Card_Click(object sender, EventArgs e)
        {
            ProductClicked?.Invoke(IdProduit, NomProduit, PrixProduit);
        }

        private int _idProduit;
        public int IdProduit
        {
            get => _idProduit;
            set => _idProduit = value;
        }

        private string _nomProduit;
        public string NomProduit
        {
            get => _nomProduit;
            set
            {
                _nomProduit = value;
                if (labelNom != null) labelNom.Text = value;
            }
        }

        private double _prixProduit;
        public double PrixProduit
        {
            get => _prixProduit;
            set
            {
                _prixProduit = value;
                if (labelPrix != null) labelPrix.Text = value.ToString("0.00") + " DT";
            }
        }

        private string _descriptionProduit;
        public string DescriptionProduit
        {
            get => _descriptionProduit;
            set
            {
                _descriptionProduit = value;
                if (labelDesc != null) labelDesc.Text = value;
            }
        }

        public Image ImageProduit
        {
            get => pictureBox1?.Image;
            set
            {
                if (pictureBox1 != null) pictureBox1.Image = value;
            }
        }
    }
}
