namespace RainbowDashBoard
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.product = new System.Windows.Forms.Label();
            this.version = new System.Windows.Forms.Label();
            this.Author = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // product
            // 
            this.product.AutoSize = true;
            this.product.BackColor = System.Drawing.Color.Transparent;
            this.product.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.product.ForeColor = System.Drawing.Color.Aqua;
            this.product.Location = new System.Drawing.Point(24, 23);
            this.product.Name = "product";
            this.product.Size = new System.Drawing.Size(81, 33);
            this.product.TabIndex = 0;
            this.product.Text = "label1";
            // 
            // version
            // 
            this.version.AutoSize = true;
            this.version.BackColor = System.Drawing.Color.Transparent;
            this.version.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.version.ForeColor = System.Drawing.Color.Aqua;
            this.version.Location = new System.Drawing.Point(24, 76);
            this.version.Name = "version";
            this.version.Size = new System.Drawing.Size(81, 33);
            this.version.TabIndex = 1;
            this.version.Text = "label1";
            // 
            // Author
            // 
            this.Author.AutoSize = true;
            this.Author.BackColor = System.Drawing.Color.Transparent;
            this.Author.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Author.ForeColor = System.Drawing.Color.Aqua;
            this.Author.Location = new System.Drawing.Point(24, 131);
            this.Author.Name = "Author";
            this.Author.Size = new System.Drawing.Size(81, 33);
            this.Author.TabIndex = 2;
            this.Author.Text = "label1";
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::RainbowDashBoard.Properties.Resources.miku_wallpaper;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(525, 295);
            this.Controls.Add(this.Author);
            this.Controls.Add(this.version);
            this.Controls.Add(this.product);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "About";
            this.Text = "About";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label product;
        private System.Windows.Forms.Label version;
        private System.Windows.Forms.Label Author;
    }
}