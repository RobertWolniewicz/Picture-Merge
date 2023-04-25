namespace Picture_App
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbPicture = new System.Windows.Forms.PictureBox();
            this.pbMark = new System.Windows.Forms.PictureBox();
            this.btnAddPicture = new System.Windows.Forms.Button();
            this.btnDeletePicture = new System.Windows.Forms.Button();
            this.btnAddMark = new System.Windows.Forms.Button();
            this.btnSafe = new System.Windows.Forms.Button();
            this.btnDeleteMark = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMark)).BeginInit();
            this.SuspendLayout();
            // 
            // pbPicture
            // 
            this.pbPicture.Location = new System.Drawing.Point(12, 12);
            this.pbPicture.Name = "pbPicture";
            this.pbPicture.Size = new System.Drawing.Size(353, 252);
            this.pbPicture.TabIndex = 0;
            this.pbPicture.TabStop = false;
            // 
            // pbMark
            // 
            this.pbMark.Location = new System.Drawing.Point(371, 12);
            this.pbMark.Name = "pbMark";
            this.pbMark.Size = new System.Drawing.Size(353, 252);
            this.pbMark.TabIndex = 1;
            this.pbMark.TabStop = false;
            // 
            // btnAddPicture
            // 
            this.btnAddPicture.Location = new System.Drawing.Point(12, 270);
            this.btnAddPicture.Name = "btnAddPicture";
            this.btnAddPicture.Size = new System.Drawing.Size(94, 43);
            this.btnAddPicture.TabIndex = 2;
            this.btnAddPicture.Text = "Dodaj obraz";
            this.btnAddPicture.UseVisualStyleBackColor = true;
            this.btnAddPicture.Click += new System.EventHandler(this.btnAddPicture_Click);
            // 
            // btnDeletePicture
            // 
            this.btnDeletePicture.Location = new System.Drawing.Point(112, 270);
            this.btnDeletePicture.Name = "btnDeletePicture";
            this.btnDeletePicture.Size = new System.Drawing.Size(94, 43);
            this.btnDeletePicture.TabIndex = 3;
            this.btnDeletePicture.Text = "Usuń Obraz";
            this.btnDeletePicture.UseVisualStyleBackColor = true;
            this.btnDeletePicture.Visible = false;
            this.btnDeletePicture.Click += new System.EventHandler(this.btnDeletePicture_Click);
            // 
            // btnAddMark
            // 
            this.btnAddMark.Location = new System.Drawing.Point(533, 270);
            this.btnAddMark.Name = "btnAddMark";
            this.btnAddMark.Size = new System.Drawing.Size(94, 43);
            this.btnAddMark.TabIndex = 4;
            this.btnAddMark.Text = "Dodaj znak";
            this.btnAddMark.UseVisualStyleBackColor = true;
            this.btnAddMark.Click += new System.EventHandler(this.btnAddMark_Click);
            // 
            // btnSafe
            // 
            this.btnSafe.Location = new System.Drawing.Point(319, 270);
            this.btnSafe.Name = "btnSafe";
            this.btnSafe.Size = new System.Drawing.Size(94, 43);
            this.btnSafe.TabIndex = 5;
            this.btnSafe.TabStop = false;
            this.btnSafe.Text = "Scal i zapisz";
            this.btnSafe.UseVisualStyleBackColor = true;
            this.btnSafe.Visible = false;
            this.btnSafe.Click += new System.EventHandler(this.btnSafe_Click);
            // 
            // btnDeleteMark
            // 
            this.btnDeleteMark.Location = new System.Drawing.Point(633, 270);
            this.btnDeleteMark.Name = "btnDeleteMark";
            this.btnDeleteMark.Size = new System.Drawing.Size(94, 43);
            this.btnDeleteMark.TabIndex = 6;
            this.btnDeleteMark.Text = "Usuń znak";
            this.btnDeleteMark.UseVisualStyleBackColor = true;
            this.btnDeleteMark.Visible = false;
            this.btnDeleteMark.Click += new System.EventHandler(this.btnDeleteMark_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 332);
            this.Controls.Add(this.btnDeleteMark);
            this.Controls.Add(this.btnSafe);
            this.Controls.Add(this.btnAddMark);
            this.Controls.Add(this.btnDeletePicture);
            this.Controls.Add(this.btnAddPicture);
            this.Controls.Add(this.pbMark);
            this.Controls.Add(this.pbPicture);
            this.Name = "Main";
            this.Text = "Main";
            ((System.ComponentModel.ISupportInitialize)(this.pbPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMark)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox pbPicture;
        private PictureBox pbMark;
        private Button btnAddPicture;
        private Button btnDeletePicture;
        private Button btnAddMark;
        private Button btnSafe;
        private Button btnDeleteMark;
    }
}