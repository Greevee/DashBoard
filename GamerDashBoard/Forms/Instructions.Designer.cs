namespace GamerDashBoard.Forms
{
    partial class Instructions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Instructions));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.settingsButton = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.ipBox = new System.Windows.Forms.TextBox();
            this.product = new System.Windows.Forms.Label();
            this.Author = new System.Windows.Forms.Label();
            this.version = new System.Windows.Forms.Label();
            this.preview = new System.Windows.Forms.Button();
            this.b_wallpaper = new System.Windows.Forms.Button();
            this.b_homepage = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.b_homepage);
            this.groupBox2.Controls.Add(this.b_wallpaper);
            this.groupBox2.Controls.Add(this.preview);
            this.groupBox2.Controls.Add(this.ipBox);
            this.groupBox2.Controls.Add(this.settingsButton);
            this.groupBox2.Controls.Add(this.richTextBox1);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(449, 228);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Instructions";
            // 
            // settingsButton
            // 
            this.settingsButton.Location = new System.Drawing.Point(267, 44);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(162, 23);
            this.settingsButton.TabIndex = 1;
            this.settingsButton.Text = "Settings";
            this.settingsButton.UseVisualStyleBackColor = true;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(6, 19);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(437, 203);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // ipBox
            // 
            this.ipBox.Location = new System.Drawing.Point(267, 73);
            this.ipBox.Name = "ipBox";
            this.ipBox.Size = new System.Drawing.Size(162, 20);
            this.ipBox.TabIndex = 3;
            // 
            // product
            // 
            this.product.AutoSize = true;
            this.product.BackColor = System.Drawing.Color.Transparent;
            this.product.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.product.ForeColor = System.Drawing.Color.Black;
            this.product.Location = new System.Drawing.Point(6, 379);
            this.product.Name = "product";
            this.product.Size = new System.Drawing.Size(81, 33);
            this.product.TabIndex = 2;
            this.product.Text = "label1";
            // 
            // Author
            // 
            this.Author.AutoSize = true;
            this.Author.BackColor = System.Drawing.Color.Transparent;
            this.Author.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Author.ForeColor = System.Drawing.Color.Black;
            this.Author.Location = new System.Drawing.Point(6, 425);
            this.Author.Name = "Author";
            this.Author.Size = new System.Drawing.Size(81, 33);
            this.Author.TabIndex = 3;
            this.Author.Text = "label1";
            // 
            // version
            // 
            this.version.AutoSize = true;
            this.version.BackColor = System.Drawing.Color.Transparent;
            this.version.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.version.ForeColor = System.Drawing.Color.Black;
            this.version.Location = new System.Drawing.Point(6, 467);
            this.version.Name = "version";
            this.version.Size = new System.Drawing.Size(81, 33);
            this.version.TabIndex = 4;
            this.version.Text = "label1";
            // 
            // preview
            // 
            this.preview.Location = new System.Drawing.Point(327, 100);
            this.preview.Name = "preview";
            this.preview.Size = new System.Drawing.Size(102, 23);
            this.preview.TabIndex = 4;
            this.preview.Text = "Browser Preview";
            this.preview.UseVisualStyleBackColor = true;
            this.preview.Click += new System.EventHandler(this.preview_Click);
            // 
            // b_wallpaper
            // 
            this.b_wallpaper.Location = new System.Drawing.Point(327, 129);
            this.b_wallpaper.Name = "b_wallpaper";
            this.b_wallpaper.Size = new System.Drawing.Size(102, 23);
            this.b_wallpaper.TabIndex = 5;
            this.b_wallpaper.Text = "Wallpaper Folder";
            this.b_wallpaper.UseVisualStyleBackColor = true;
            this.b_wallpaper.Click += new System.EventHandler(this.b_wallpaper_Click);
            // 
            // b_homepage
            // 
            this.b_homepage.Location = new System.Drawing.Point(327, 158);
            this.b_homepage.Name = "b_homepage";
            this.b_homepage.Size = new System.Drawing.Size(102, 23);
            this.b_homepage.TabIndex = 6;
            this.b_homepage.Text = "Homepage";
            this.b_homepage.UseVisualStyleBackColor = true;
            this.b_homepage.Click += new System.EventHandler(this.b_homepage_Click);
            // 
            // Instructions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GamerDashBoard.Properties.Resources.miku_right;
            this.ClientSize = new System.Drawing.Size(982, 527);
            this.Controls.Add(this.version);
            this.Controls.Add(this.Author);
            this.Controls.Add(this.product);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Instructions";
            this.Text = "Instructions";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox ipBox;
        private System.Windows.Forms.Label product;
        private System.Windows.Forms.Label Author;
        private System.Windows.Forms.Label version;
        private System.Windows.Forms.Button preview;
        private System.Windows.Forms.Button b_homepage;
        private System.Windows.Forms.Button b_wallpaper;
    }
}