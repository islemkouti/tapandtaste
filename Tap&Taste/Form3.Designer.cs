namespace Tap_Taste
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnhist = new System.Windows.Forms.Button();
            this.btnreservation = new System.Windows.Forms.Button();
            this.btndeconexion = new System.Windows.Forms.Button();
            this.btnorder = new System.Windows.Forms.Button();
            this.btnsale = new System.Windows.Forms.Button();
            this.btncategorie = new System.Windows.Forms.Button();
            this.btnProduct = new System.Windows.Forms.Button();
            this.btnhome = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnRafraichir = new System.Windows.Forms.Button();
            this.btnsearch = new System.Windows.Forms.Button();
            this.btnsupp = new System.Windows.Forms.Button();
            this.btnmodifier = new System.Windows.Forms.Button();
            this.btnadd = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.textBoxRech = new System.Windows.Forms.TextBox();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Indigo;
            this.panel1.Controls.Add(this.btnhist);
            this.panel1.Controls.Add(this.btnreservation);
            this.panel1.Controls.Add(this.btndeconexion);
            this.panel1.Controls.Add(this.btnorder);
            this.panel1.Controls.Add(this.btnsale);
            this.panel1.Controls.Add(this.btncategorie);
            this.panel1.Controls.Add(this.btnProduct);
            this.panel1.Controls.Add(this.btnhome);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(173, 650);
            this.panel1.TabIndex = 0;
            // 
            // btnhist
            // 
            this.btnhist.BackColor = System.Drawing.Color.Indigo;
            this.btnhist.FlatAppearance.BorderSize = 0;
            this.btnhist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnhist.ForeColor = System.Drawing.Color.White;
            this.btnhist.Image = ((System.Drawing.Image)(resources.GetObject("btnhist.Image")));
            this.btnhist.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnhist.Location = new System.Drawing.Point(12, 296);
            this.btnhist.Name = "btnhist";
            this.btnhist.Size = new System.Drawing.Size(189, 40);
            this.btnhist.TabIndex = 10;
            this.btnhist.Text = "Orders History";
            this.btnhist.UseVisualStyleBackColor = false;
            this.btnhist.Click += new System.EventHandler(this.btnhist_Click);
            // 
            // btnreservation
            // 
            this.btnreservation.BackColor = System.Drawing.Color.Indigo;
            this.btnreservation.FlatAppearance.BorderSize = 0;
            this.btnreservation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnreservation.ForeColor = System.Drawing.Color.White;
            this.btnreservation.Image = ((System.Drawing.Image)(resources.GetObject("btnreservation.Image")));
            this.btnreservation.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnreservation.Location = new System.Drawing.Point(12, 342);
            this.btnreservation.Name = "btnreservation";
            this.btnreservation.Size = new System.Drawing.Size(161, 40);
            this.btnreservation.TabIndex = 15;
            this.btnreservation.Text = "Reservation";
            this.btnreservation.UseVisualStyleBackColor = false;
            this.btnreservation.Click += new System.EventHandler(this.btnreservation_Click);
            // 
            // btndeconexion
            // 
            this.btndeconexion.BackColor = System.Drawing.Color.Indigo;
            this.btndeconexion.FlatAppearance.BorderSize = 0;
            this.btndeconexion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndeconexion.ForeColor = System.Drawing.Color.White;
            this.btndeconexion.Image = ((System.Drawing.Image)(resources.GetObject("btndeconexion.Image")));
            this.btndeconexion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btndeconexion.Location = new System.Drawing.Point(12, 526);
            this.btndeconexion.Name = "btndeconexion";
            this.btndeconexion.Size = new System.Drawing.Size(161, 40);
            this.btndeconexion.TabIndex = 14;
            this.btndeconexion.Text = "Deconexion";
            this.btndeconexion.UseVisualStyleBackColor = false;
            this.btndeconexion.Click += new System.EventHandler(this.btndeconexion_Click);
            // 
            // btnorder
            // 
            this.btnorder.BackColor = System.Drawing.Color.Indigo;
            this.btnorder.FlatAppearance.BorderSize = 0;
            this.btnorder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnorder.ForeColor = System.Drawing.Color.White;
            this.btnorder.Image = ((System.Drawing.Image)(resources.GetObject("btnorder.Image")));
            this.btnorder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnorder.Location = new System.Drawing.Point(12, 250);
            this.btnorder.Name = "btnorder";
            this.btnorder.Size = new System.Drawing.Size(161, 40);
            this.btnorder.TabIndex = 12;
            this.btnorder.Text = "Order";
            this.btnorder.UseVisualStyleBackColor = false;
            this.btnorder.Click += new System.EventHandler(this.btnorder_Click);
            // 
            // btnsale
            // 
            this.btnsale.BackColor = System.Drawing.Color.Indigo;
            this.btnsale.FlatAppearance.BorderSize = 0;
            this.btnsale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsale.ForeColor = System.Drawing.Color.White;
            this.btnsale.Image = ((System.Drawing.Image)(resources.GetObject("btnsale.Image")));
            this.btnsale.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsale.Location = new System.Drawing.Point(12, 480);
            this.btnsale.Name = "btnsale";
            this.btnsale.Size = new System.Drawing.Size(161, 40);
            this.btnsale.TabIndex = 13;
            this.btnsale.Text = "Sales Report";
            this.btnsale.UseVisualStyleBackColor = false;
            this.btnsale.Click += new System.EventHandler(this.btnsale_Click);
            // 
            // btncategorie
            // 
            this.btncategorie.BackColor = System.Drawing.Color.Indigo;
            this.btncategorie.FlatAppearance.BorderSize = 0;
            this.btncategorie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncategorie.ForeColor = System.Drawing.Color.White;
            this.btncategorie.Image = ((System.Drawing.Image)(resources.GetObject("btncategorie.Image")));
            this.btncategorie.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btncategorie.Location = new System.Drawing.Point(12, 388);
            this.btncategorie.Name = "btncategorie";
            this.btncategorie.Size = new System.Drawing.Size(161, 40);
            this.btncategorie.TabIndex = 11;
            this.btncategorie.Text = "Category";
            this.btncategorie.UseVisualStyleBackColor = false;
            this.btncategorie.Click += new System.EventHandler(this.btncategorie_Click);
            // 
            // btnProduct
            // 
            this.btnProduct.BackColor = System.Drawing.Color.Indigo;
            this.btnProduct.FlatAppearance.BorderSize = 0;
            this.btnProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProduct.ForeColor = System.Drawing.Color.White;
            this.btnProduct.Image = ((System.Drawing.Image)(resources.GetObject("btnProduct.Image")));
            this.btnProduct.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProduct.Location = new System.Drawing.Point(12, 434);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Size = new System.Drawing.Size(161, 40);
            this.btnProduct.TabIndex = 10;
            this.btnProduct.Text = "Products";
            this.btnProduct.UseVisualStyleBackColor = false;
            // 
            // btnhome
            // 
            this.btnhome.BackColor = System.Drawing.Color.Indigo;
            this.btnhome.FlatAppearance.BorderSize = 0;
            this.btnhome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnhome.ForeColor = System.Drawing.Color.White;
            this.btnhome.Image = ((System.Drawing.Image)(resources.GetObject("btnhome.Image")));
            this.btnhome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnhome.Location = new System.Drawing.Point(12, 204);
            this.btnhome.Name = "btnhome";
            this.btnhome.Size = new System.Drawing.Size(161, 40);
            this.btnhome.TabIndex = 9;
            this.btnhome.Text = "Home";
            this.btnhome.UseVisualStyleBackColor = false;
            this.btnhome.Click += new System.EventHandler(this.btnhome_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(173, 130);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(173, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(927, 40);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnRafraichir);
            this.panel3.Controls.Add(this.btnsearch);
            this.panel3.Controls.Add(this.btnsupp);
            this.panel3.Controls.Add(this.btnmodifier);
            this.panel3.Controls.Add(this.btnadd);
            this.panel3.Controls.Add(this.pictureBox2);
            this.panel3.Controls.Add(this.textBoxRech);
            this.panel3.Controls.Add(this.dgvProducts);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Font = new System.Drawing.Font("Yu Gothic UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(173, 40);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(927, 610);
            this.panel3.TabIndex = 2;
            // 
            // btnRafraichir
            // 
            this.btnRafraichir.BackColor = System.Drawing.Color.Indigo;
            this.btnRafraichir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRafraichir.ForeColor = System.Drawing.Color.White;
            this.btnRafraichir.Location = new System.Drawing.Point(341, 571);
            this.btnRafraichir.Name = "btnRafraichir";
            this.btnRafraichir.Size = new System.Drawing.Size(139, 36);
            this.btnRafraichir.TabIndex = 7;
            this.btnRafraichir.Text = "Refresh";
            this.btnRafraichir.UseVisualStyleBackColor = false;
            this.btnRafraichir.Click += new System.EventHandler(this.btnRafraichir_Click);
            // 
            // btnsearch
            // 
            this.btnsearch.BackColor = System.Drawing.Color.Indigo;
            this.btnsearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsearch.ForeColor = System.Drawing.Color.White;
            this.btnsearch.Location = new System.Drawing.Point(311, 12);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(94, 33);
            this.btnsearch.TabIndex = 6;
            this.btnsearch.Text = "Search";
            this.btnsearch.UseVisualStyleBackColor = false;
            this.btnsearch.Click += new System.EventHandler(this.btnsearch_Click);
            // 
            // btnsupp
            // 
            this.btnsupp.BackColor = System.Drawing.Color.Indigo;
            this.btnsupp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsupp.ForeColor = System.Drawing.Color.White;
            this.btnsupp.Location = new System.Drawing.Point(776, 571);
            this.btnsupp.Name = "btnsupp";
            this.btnsupp.Size = new System.Drawing.Size(139, 36);
            this.btnsupp.TabIndex = 5;
            this.btnsupp.Text = "Delete product";
            this.btnsupp.UseVisualStyleBackColor = false;
            this.btnsupp.Click += new System.EventHandler(this.btnsupp_Click);
            // 
            // btnmodifier
            // 
            this.btnmodifier.BackColor = System.Drawing.Color.Indigo;
            this.btnmodifier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnmodifier.ForeColor = System.Drawing.Color.White;
            this.btnmodifier.Location = new System.Drawing.Point(631, 571);
            this.btnmodifier.Name = "btnmodifier";
            this.btnmodifier.Size = new System.Drawing.Size(139, 36);
            this.btnmodifier.TabIndex = 4;
            this.btnmodifier.Text = "Modify product";
            this.btnmodifier.UseVisualStyleBackColor = false;
            this.btnmodifier.Click += new System.EventHandler(this.btnmodifier_Click);
            // 
            // btnadd
            // 
            this.btnadd.BackColor = System.Drawing.Color.Indigo;
            this.btnadd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnadd.ForeColor = System.Drawing.Color.White;
            this.btnadd.Location = new System.Drawing.Point(486, 571);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(139, 36);
            this.btnadd.TabIndex = 3;
            this.btnadd.Text = "Add product";
            this.btnadd.UseVisualStyleBackColor = false;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 8);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(37, 43);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // textBoxRech
            // 
            this.textBoxRech.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRech.Location = new System.Drawing.Point(33, 12);
            this.textBoxRech.Multiline = true;
            this.textBoxRech.Name = "textBoxRech";
            this.textBoxRech.Size = new System.Drawing.Size(272, 32);
            this.textBoxRech.TabIndex = 1;
            // 
            // dgvProducts
            // 
            this.dgvProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProducts.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Location = new System.Drawing.Point(6, 66);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.RowHeadersWidth = 51;
            this.dgvProducts.RowTemplate.Height = 24;
            this.dgvProducts.Size = new System.Drawing.Size(909, 485);
            this.dgvProducts.TabIndex = 0;
            this.dgvProducts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProducts_CellClick);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form3";
            this.Text = " ";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox textBoxRech;
        private System.Windows.Forms.Button btnsupp;
        private System.Windows.Forms.Button btnmodifier;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.Button btnreservation;
        private System.Windows.Forms.Button btndeconexion;
        private System.Windows.Forms.Button btnorder;
        private System.Windows.Forms.Button btnsale;
        private System.Windows.Forms.Button btncategorie;
        private System.Windows.Forms.Button btnProduct;
        private System.Windows.Forms.Button btnhome;
        private System.Windows.Forms.Button btnsearch;
        private System.Windows.Forms.Button btnhist;
        private System.Windows.Forms.Button btnRafraichir;
    }
}