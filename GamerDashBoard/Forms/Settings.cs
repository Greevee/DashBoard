﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GamerDashBoard.Models.Configuration;
using System.IO;
using GamerDashBoard.Util;
using System.Reflection;

namespace GamerDashBoard.Forms
{
    public partial class Settings : Form
    {
        Server server;
        Configuration config;
        FirewallHelper fwh = FirewallHelper.Instance;
        int port = 13337;

        string wallpaperpath = @"Style/Wallpapers";

        public Settings(Server server)
        {
            
            this.server = server;
            config = server.getConfiguration();
            InitializeComponent();

            module_network_enable.Checked = config.networkConfig.enabled;
            module_cpu_enable.Checked = config.cpuConfig.enabled;
            module_memory_enable.Checked = config.memoryConfig.enabled;
            module_teamspeak_enable.Checked = config.tsconfig.enabled;
            module_clock_enable.Checked = config.clockConfig.enabled;


            foreach (string networkInterface in server.systemInfoService.getNetworkInterfaces())
            {
                networkDropdown.Items.Add(networkInterface);
            }
            if (config.networkConfig.interfaceName == "")
            {
                config.networkConfig.interfaceName = networkDropdown.Items[0].ToString();
            }
            networkDropdown.SelectedIndex = networkDropdown.FindString(config.networkConfig.interfaceName);


            foreach (string s in Directory.GetFiles(wallpaperpath, "*").Select(Path.GetFileName))
            {
                style_wallpapers.Items.Add(s);
            }

            style_wallpapers.SelectedIndex = style_wallpapers.FindString(config.styleconig.wallpaper);
            style_Preview.Image = Image.FromFile("Style/Wallpapers/" + config.styleconig.wallpaper);

            Color color = Color.FromArgb(config.styleconig.color_r, config.styleconig.color_g, config.styleconig.color_b);
            style_color.BackColor = color;

            Color bcolor = Color.FromArgb(config.styleconig.b_color_r, config.styleconig.b_color_g, config.styleconig.b_color_b);
            style_back_color.BackColor = bcolor;

            style_opacity.Value = (int)(config.styleconig.b_opacity * 100);

            if (!fwh.IsFirewallEnabled)
            {
                fw_addRule.Enabled = false;
                fw_removeRule.Enabled = false;
            }
            else
            {
                if (fwh.IsPortOpen(port)) 
                {
                    fw_addRule.Enabled = false;
                    fw_removeRule.Enabled = true;
                }
                else
                {
                    fw_addRule.Enabled = true;
                    fw_removeRule.Enabled = false;
                }
            }
            
        }

        private void networkDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            server.systemInfoService.changeNetworkInterface(networkDropdown.SelectedItem.ToString());
            config.networkConfig.interfaceName = networkDropdown.SelectedItem.ToString();
            server.settingsService.save();
        }

        private void module_network_enable_CheckedChanged(object sender, EventArgs e)
        {
            config.networkConfig.enabled = module_network_enable.Checked;
            server.settingsService.save();
        }

        private void module_clock_enable_CheckedChanged(object sender, EventArgs e)
        {
            config.clockConfig.enabled = module_clock_enable.Checked;
            server.settingsService.save();
        }

        private void module_cpu_enable_CheckedChanged(object sender, EventArgs e)
        {
            config.cpuConfig.enabled = module_cpu_enable.Checked;
            server.settingsService.save();
        }

        private void module_memory_enable_CheckedChanged(object sender, EventArgs e)
        {
            config.memoryConfig.enabled = module_memory_enable.Checked;
            server.settingsService.save();
        }

        private void module_teamspeak_enable_CheckedChanged(object sender, EventArgs e)
        {
            config.tsconfig.enabled = module_teamspeak_enable.Checked;
            server.settingsService.save();
        }

        private void style_wallpapers_SelectedIndexChanged(object sender, EventArgs e)
        {
            config.styleconig.wallpaper = style_wallpapers.SelectedItem.ToString();
            server.settingsService.save();
            style_Preview.Image = Image.FromFile("Style/Wallpapers/" + config.styleconig.wallpaper);
            style_Preview.BackgroundImageLayout = ImageLayout.Stretch;
            style_Preview.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void ChangeColorButton_Click(object sender, EventArgs e)
        {

            Color color = new Color();

            ColorDialog colorDiag = new ColorDialog();
            DialogResult result = colorDiag.ShowDialog();
            // See if user pressed ok.
            if (result == DialogResult.OK)
            {
                // Set form background to the selected color.
                color = colorDiag.Color;
            }
            else
            {
                return;
            }
            style_color.BackColor = color;

            config.styleconig.color_r = color.R;
            config.styleconig.color_g = color.G;
            config.styleconig.color_b = color.B;
            server.settingsService.save();



        }

        private void ChangeBackColorButton_Click(object sender, EventArgs e)
        {
            Color color = new Color();

            ColorDialog colorDiag = new ColorDialog();
            DialogResult result = colorDiag.ShowDialog();
            // See if user pressed ok.
            if (result == DialogResult.OK)
            {
                // Set form background to the selected color.
                color = colorDiag.Color;
            }
            else
            {
                return;
            }
            style_back_color.BackColor = color;

            config.styleconig.b_color_r = color.R;
            config.styleconig.b_color_g = color.G;
            config.styleconig.b_color_b = color.B;
            server.settingsService.save();


        }

        private void style_opacity_Scroll(object sender, EventArgs e)
        {
            config.styleconig.b_opacity = Math.Round(((double)style_opacity.Value / 100),2);
            server.settingsService.save();
        }

        private void fw_addRule_Click(object sender, EventArgs e)
        {

            if (fwh.IsFirewallEnabled)
            {
                if (fwh.IsPortOpen(port))
                {
                    GDBLogger.logger.Info("Firewall Entry already exists - do nothing");


                }
                else
                {
                    fwh.OpenPort(port, getAssemblyProduct);
                }

                fw_addRule.Enabled = false;
                fw_removeRule.Enabled = true;
            }
        }

        private void fw_removeRule_Click(object sender, EventArgs e)
        {
            if (fwh.IsFirewallEnabled)
            {
                if (fwh.IsPortOpen(port))
                {
                    GDBLogger.logger.Info("Firewall Entry already exists - remove it");
                    fwh.ClosePort(port);

                }

                fw_addRule.Enabled = true;
                fw_removeRule.Enabled = false;
            }
        }

        private string getAssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }
    }
}
