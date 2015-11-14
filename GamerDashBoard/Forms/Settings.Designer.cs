using RainbowDashBoard.Models.Configuration;

namespace RainbowDashBoard.Forms
{
    partial class Settings
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.networkDropdown = new System.Windows.Forms.ComboBox();
            this.module_teamspeak_enable = new System.Windows.Forms.CheckBox();
            this.module_memory_enable = new System.Windows.Forms.CheckBox();
            this.module_cpu_enable = new System.Windows.Forms.CheckBox();
            this.module_clock_enable = new System.Windows.Forms.CheckBox();
            this.module_network_enable = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.style_wallpapers = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.style_Preview = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ChangeColorButton = new System.Windows.Forms.Button();
            this.style_color = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.style_Preview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.style_color)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.networkDropdown);
            this.groupBox1.Controls.Add(this.module_teamspeak_enable);
            this.groupBox1.Controls.Add(this.module_memory_enable);
            this.groupBox1.Controls.Add(this.module_cpu_enable);
            this.groupBox1.Controls.Add(this.module_clock_enable);
            this.groupBox1.Controls.Add(this.module_network_enable);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 141);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Modules";
            // 
            // networkDropdown
            // 
            this.networkDropdown.FormattingEnabled = true;
            this.networkDropdown.Location = new System.Drawing.Point(97, 20);
            this.networkDropdown.Name = "networkDropdown";
            this.networkDropdown.Size = new System.Drawing.Size(152, 21);
            this.networkDropdown.TabIndex = 5;
            this.networkDropdown.SelectedIndexChanged += new System.EventHandler(this.networkDropdown_SelectedIndexChanged);
            // 
            // module_teamspeak_enable
            // 
            this.module_teamspeak_enable.AutoSize = true;
            this.module_teamspeak_enable.Location = new System.Drawing.Point(7, 116);
            this.module_teamspeak_enable.Name = "module_teamspeak_enable";
            this.module_teamspeak_enable.Size = new System.Drawing.Size(82, 17);
            this.module_teamspeak_enable.TabIndex = 4;
            this.module_teamspeak_enable.Text = "Teamspeak";
            this.module_teamspeak_enable.UseVisualStyleBackColor = true;
            this.module_teamspeak_enable.CheckedChanged += new System.EventHandler(this.module_teamspeak_enable_CheckedChanged);
            // 
            // module_memory_enable
            // 
            this.module_memory_enable.AutoSize = true;
            this.module_memory_enable.Location = new System.Drawing.Point(7, 92);
            this.module_memory_enable.Name = "module_memory_enable";
            this.module_memory_enable.Size = new System.Drawing.Size(63, 17);
            this.module_memory_enable.TabIndex = 3;
            this.module_memory_enable.Text = "Memory";
            this.module_memory_enable.UseVisualStyleBackColor = true;
            this.module_memory_enable.CheckedChanged += new System.EventHandler(this.module_memory_enable_CheckedChanged);
            // 
            // module_cpu_enable
            // 
            this.module_cpu_enable.AutoSize = true;
            this.module_cpu_enable.Location = new System.Drawing.Point(7, 68);
            this.module_cpu_enable.Name = "module_cpu_enable";
            this.module_cpu_enable.Size = new System.Drawing.Size(48, 17);
            this.module_cpu_enable.TabIndex = 2;
            this.module_cpu_enable.Text = "CPU";
            this.module_cpu_enable.UseVisualStyleBackColor = true;
            this.module_cpu_enable.CheckedChanged += new System.EventHandler(this.module_cpu_enable_CheckedChanged);
            // 
            // module_clock_enable
            // 
            this.module_clock_enable.AutoSize = true;
            this.module_clock_enable.Location = new System.Drawing.Point(7, 44);
            this.module_clock_enable.Name = "module_clock_enable";
            this.module_clock_enable.Size = new System.Drawing.Size(84, 17);
            this.module_clock_enable.TabIndex = 1;
            this.module_clock_enable.Text = "Clock/Timer";
            this.module_clock_enable.UseVisualStyleBackColor = true;
            this.module_clock_enable.CheckedChanged += new System.EventHandler(this.module_clock_enable_CheckedChanged);
            // 
            // module_network_enable
            // 
            this.module_network_enable.AutoSize = true;
            this.module_network_enable.Location = new System.Drawing.Point(7, 20);
            this.module_network_enable.Name = "module_network_enable";
            this.module_network_enable.Size = new System.Drawing.Size(66, 17);
            this.module_network_enable.TabIndex = 0;
            this.module_network_enable.Text = "Network";
            this.module_network_enable.UseVisualStyleBackColor = true;
            this.module_network_enable.CheckedChanged += new System.EventHandler(this.module_network_enable_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.style_color);
            this.groupBox2.Controls.Add(this.ChangeColorButton);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.style_Preview);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.style_wallpapers);
            this.groupBox2.Location = new System.Drawing.Point(12, 160);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(260, 179);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Style";
            // 
            // style_wallpapers
            // 
            this.style_wallpapers.FormattingEnabled = true;
            this.style_wallpapers.Location = new System.Drawing.Point(97, 20);
            this.style_wallpapers.Name = "style_wallpapers";
            this.style_wallpapers.Size = new System.Drawing.Size(152, 21);
            this.style_wallpapers.TabIndex = 0;
            this.style_wallpapers.SelectedIndexChanged += new System.EventHandler(this.style_wallpapers_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Background";
            // 
            // style_Preview
            // 
            this.style_Preview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.style_Preview.Location = new System.Drawing.Point(97, 56);
            this.style_Preview.Name = "style_Preview";
            this.style_Preview.Size = new System.Drawing.Size(152, 78);
            this.style_Preview.TabIndex = 4;
            this.style_Preview.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Preview";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Color";
            // 
            // ChangeColorButton
            // 
            this.ChangeColorButton.Location = new System.Drawing.Point(178, 140);
            this.ChangeColorButton.Name = "ChangeColorButton";
            this.ChangeColorButton.Size = new System.Drawing.Size(71, 23);
            this.ChangeColorButton.TabIndex = 8;
            this.ChangeColorButton.Text = "Change";
            this.ChangeColorButton.UseVisualStyleBackColor = true;
            this.ChangeColorButton.Click += new System.EventHandler(this.ChangeColorButton_Click);
            // 
            // style_color
            // 
            this.style_color.Cursor = System.Windows.Forms.Cursors.Default;
            this.style_color.Location = new System.Drawing.Point(97, 142);
            this.style_color.Name = "style_color";
            this.style_color.Size = new System.Drawing.Size(75, 21);
            this.style_color.TabIndex = 9;
            this.style_color.TabStop = false;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::RainbowDashBoard.Properties.Resources.miku_right;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(581, 346);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.Name = "Settings";
            this.Text = "Settings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.style_Preview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.style_color)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox module_teamspeak_enable;
        private System.Windows.Forms.CheckBox module_memory_enable;
        private System.Windows.Forms.CheckBox module_cpu_enable;
        private System.Windows.Forms.CheckBox module_clock_enable;
        private System.Windows.Forms.CheckBox module_network_enable;
        private System.Windows.Forms.ComboBox networkDropdown;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox style_wallpapers;
        private System.Windows.Forms.Button ChangeColorButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox style_Preview;
        private System.Windows.Forms.PictureBox style_color;
    }
}