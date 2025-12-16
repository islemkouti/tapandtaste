namespace Tap_Taste
{
    partial class Form5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form5));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnhist = new System.Windows.Forms.Button();
            this.btnres = new System.Windows.Forms.Button();
            this.btndec = new System.Windows.Forms.Button();
            this.btnorder = new System.Windows.Forms.Button();
            this.btnsale = new System.Windows.Forms.Button();
            this.btncat = new System.Windows.Forms.Button();
            this.btnpro = new System.Windows.Forms.Button();
            this.btnhome = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnRafraichir = new System.Windows.Forms.Button();
            this.btnsearch = new System.Windows.Forms.Button();
            this.btnsupp = new System.Windows.Forms.Button();
            this.btnmodifier = new System.Windows.Forms.Button();
            this.btnadd = new System.Windows.Forms.Button();
            this.textBoxRech = new System.Windows.Forms.TextBox();
            this.dgvcategorie = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvcategorie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Indigo;
            this.panel1.Controls.Add(this.btnhist);
            this.panel1.Controls.Add(this.btnres);
            this.panel1.Controls.Add(this.btndec);
            this.panel1.Controls.Add(this.btnorder);
            this.panel1.Controls.Add(this.btnsale);
            this.panel1.Controls.Add(this.btncat);
            this.panel1.Controls.Add(this.btnpro);
            this.panel1.Controls.Add(this.btnhome);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(173, 650);
            this.panel1.TabIndex = 25;
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
            // btnres
            // 
            this.btnres.BackColor = System.Drawing.Color.Indigo;
            this.btnres.FlatAppearance.BorderSize = 0;
            this.btnres.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnres.ForeColor = System.Drawing.Color.White;
            this.btnres.Image = ((System.Drawing.Image)(resources.GetObject("btnres.Image")));
            this.btnres.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnres.Location = new System.Drawing.Point(12, 342);
            this.btnres.Name = "btnres";
            this.btnres.Size = new System.Drawing.Size(161, 40);
            this.btnres.TabIndex = 15;
            this.btnres.Text = "Reservation";
            this.btnres.UseVisualStyleBackColor = false;
            this.btnres.Click += new System.EventHandler(this.btnres_Click);
            // 
            // btndec
            // 
            this.btndec.BackColor = System.Drawing.Color.Indigo;
            this.btndec.FlatAppearance.BorderSize = 0;
            this.btndec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndec.ForeColor = System.Drawing.Color.White;
            this.btndec.Image = ((System.Drawing.Image)(resources.GetObject("btndec.Image")));
            this.btndec.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btndec.Location = new System.Drawing.Point(12, 526);
            this.btndec.Name = "btndec";
            this.btndec.Size = new System.Drawing.Size(161, 40);
            this.btndec.TabIndex = 14;
            this.btndec.Text = "Deconexion";
            this.btndec.UseVisualStyleBackColor = false;
            this.btndec.Click += new System.EventHandler(this.btndec_Click);
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
            // btncat
            // 
            this.btncat.BackColor = System.Drawing.Color.Indigo;
            this.btncat.FlatAppearance.BorderSize = 0;
            this.btncat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncat.ForeColor = System.Drawing.Color.White;
            this.btncat.Image = ((System.Drawing.Image)(resources.GetObject("btncat.Image")));
            this.btncat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btncat.Location = new System.Drawing.Point(12, 388);
            this.btncat.Name = "btncat";
            this.btncat.Size = new System.Drawing.Size(161, 40);
            this.btncat.TabIndex = 11;
            this.btncat.Text = "Category";
            this.btncat.UseVisualStyleBackColor = false;
            // 
            // btnpro
            // 
            this.btnpro.BackColor = System.Drawing.Color.Indigo;
            this.btnpro.FlatAppearance.BorderSize = 0;
            this.btnpro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnpro.ForeColor = System.Drawing.Color.White;
            this.btnpro.Image = ((System.Drawing.Image)(resources.GetObject("btnpro.Image")));
            this.btnpro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnpro.Location = new System.Drawing.Point(12, 434);
            this.btnpro.Name = "btnpro";
            this.btnpro.Size = new System.Drawing.Size(161, 40);
            this.btnpro.TabIndex = 10;
            this.btnpro.Text = "Products";
            this.btnpro.UseVisualStyleBackColor = false;
            this.btnpro.Click += new System.EventHandler(this.btnpro_Click);
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
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(173, 130);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(173, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(927, 40);
            this.panel2.TabIndex = 26;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnRafraichir);
            this.panel3.Controls.Add(this.btnsearch);
            this.panel3.Controls.Add(this.btnsupp);
            this.panel3.Controls.Add(this.btnmodifier);
            this.panel3.Controls.Add(this.btnadd);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Controls.Add(this.textBoxRech);
            this.panel3.Controls.Add(this.dgvcategorie);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Font = new System.Drawing.Font("Yu Gothic UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(173, 40);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(927, 610);
            this.panel3.TabIndex = 27;
            // 
            // btnRafraichir
            // 
            this.btnRafraichir.BackColor = System.Drawing.Color.Indigo;
            this.btnRafraichir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRafraichir.ForeColor = System.Drawing.Color.White;
            this.btnRafraichir.Location = new System.Drawing.Point(299, 562);
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
            this.btnsearch.Location = new System.Drawing.Point(316, 12);
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
            this.btnsupp.Location = new System.Drawing.Point(762, 562);
            this.btnsupp.Name = "btnsupp";
            this.btnsupp.Size = new System.Drawing.Size(153, 36);
            this.btnsupp.TabIndex = 5;
            this.btnsupp.Text = "Delete category";
            this.btnsupp.UseVisualStyleBackColor = false;
            this.btnsupp.Click += new System.EventHandler(this.btnsupp_Click);
            // 
            // btnmodifier
            // 
            this.btnmodifier.BackColor = System.Drawing.Color.Indigo;
            this.btnmodifier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnmodifier.ForeColor = System.Drawing.Color.White;
            this.btnmodifier.Location = new System.Drawing.Point(603, 562);
            this.btnmodifier.Name = "btnmodifier";
            this.btnmodifier.Size = new System.Drawing.Size(153, 36);
            this.btnmodifier.TabIndex = 4;
            this.btnmodifier.Text = "Modify category";
            this.btnmodifier.UseVisualStyleBackColor = false;
            this.btnmodifier.Click += new System.EventHandler(this.btnmodifier_Click);
            // 
            // btnadd
            // 
            this.btnadd.BackColor = System.Drawing.Color.Indigo;
            this.btnadd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnadd.ForeColor = System.Drawing.Color.White;
            this.btnadd.Location = new System.Drawing.Point(444, 562);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(153, 36);
            this.btnadd.TabIndex = 3;
            this.btnadd.Text = "Add category";
            this.btnadd.UseVisualStyleBackColor = false;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // textBoxRech
            // 
            this.textBoxRech.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRech.Location = new System.Drawing.Point(38, 12);
            this.textBoxRech.Multiline = true;
            this.textBoxRech.Name = "textBoxRech";
            this.textBoxRech.Size = new System.Drawing.Size(272, 32);
            this.textBoxRech.TabIndex = 1;
            // 
            // dgvcategorie
            // 
            this.dgvcategorie.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvcategorie.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvcategorie.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvcategorie.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvcategorie.Location = new System.Drawing.Point(6, 58);
            this.dgvcategorie.Name = "dgvcategorie";
            this.dgvcategorie.RowHeadersWidth = 51;
            this.dgvcategorie.RowTemplate.Height = 24;
            this.dgvcategorie.Size = new System.Drawing.Size(909, 493);
            this.dgvcategorie.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 43);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form5";
            this.Text = "Form5";
            this.Load += new System.EventHandler(this.Form5_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvcategorie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnhist;
        private System.Windows.Forms.Button btnres;
        private System.Windows.Forms.Button btndec;
        private System.Windows.Forms.Button btnorder;
        private System.Windows.Forms.Button btnsale;
        private System.Windows.Forms.Button btncat;
        private System.Windows.Forms.Button btnpro;
        private System.Windows.Forms.Button btnhome;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnsearch;
        private System.Windows.Forms.Button btnsupp;
        private System.Windows.Forms.Button btnmodifier;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.TextBox textBoxRech;
        private System.Windows.Forms.DataGridView dgvcategorie;
        private System.Windows.Forms.Button btnRafraichir;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}