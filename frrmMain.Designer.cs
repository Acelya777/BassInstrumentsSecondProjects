using System.Windows.Media;

namespace BASSCOMPORT
{
    partial class frrmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frrmMain));
            this.label6 = new System.Windows.Forms.Label();
            this.lblDataOutLength = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblDataInLength = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblStatusCom = new System.Windows.Forms.Label();
            this.closeSerialButton = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.panelDesktopPanel = new System.Windows.Forms.Panel();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.flowButton = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.settingButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panelLogo.SuspendLayout();
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(16, 12);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 18);
            this.label6.TabIndex = 10;
            this.label6.Text = "Data OUT Length :";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // lblDataOutLength
            // 
            this.lblDataOutLength.AutoSize = true;
            this.lblDataOutLength.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblDataOutLength.Location = new System.Drawing.Point(155, 11);
            this.lblDataOutLength.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDataOutLength.Name = "lblDataOutLength";
            this.lblDataOutLength.Size = new System.Drawing.Size(27, 20);
            this.lblDataOutLength.TabIndex = 11;
            this.lblDataOutLength.Text = "00";
            this.lblDataOutLength.Click += new System.EventHandler(this.label7_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(48, 12);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 18);
            this.label7.TabIndex = 10;
            this.label7.Text = "Data IN Length :";
            this.label7.Click += new System.EventHandler(this.label7_Click_1);
            // 
            // lblDataInLength
            // 
            this.lblDataInLength.AutoSize = true;
            this.lblDataInLength.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblDataInLength.Location = new System.Drawing.Point(173, 11);
            this.lblDataInLength.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDataInLength.Name = "lblDataInLength";
            this.lblDataInLength.Size = new System.Drawing.Size(27, 20);
            this.lblDataInLength.TabIndex = 11;
            this.lblDataInLength.Text = "00";
            this.lblDataInLength.Click += new System.EventHandler(this.lblDataInLength_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(87)))), ((int)(((byte)(149)))));
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.lblStatusCom);
            this.panel2.Controls.Add(this.closeSerialButton);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.panel2.ForeColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(183, 747);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1741, 70);
            this.panel2.TabIndex = 13;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(31, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 18);
            this.label1.TabIndex = 18;
            this.label1.Text = "status:";
            // 
            // lblStatusCom
            // 
            this.lblStatusCom.AutoSize = true;
            this.lblStatusCom.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 13F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblStatusCom.ForeColor = System.Drawing.Color.Red;
            this.lblStatusCom.Location = new System.Drawing.Point(119, 13);
            this.lblStatusCom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatusCom.Name = "lblStatusCom";
            this.lblStatusCom.Size = new System.Drawing.Size(56, 30);
            this.lblStatusCom.TabIndex = 0;
            this.lblStatusCom.Text = "OFF";
            this.lblStatusCom.Click += new System.EventHandler(this.lblStatusCom_Click);
            // 
            // closeSerialButton
            // 
            this.closeSerialButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeSerialButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(86)))), ((int)(((byte)(149)))));
            this.closeSerialButton.Font = new System.Drawing.Font("Impact", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeSerialButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.closeSerialButton.Location = new System.Drawing.Point(1059, 13);
            this.closeSerialButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.closeSerialButton.Name = "closeSerialButton";
            this.closeSerialButton.Size = new System.Drawing.Size(305, 46);
            this.closeSerialButton.TabIndex = 17;
            this.closeSerialButton.Text = "New Scaling";
            this.closeSerialButton.UseVisualStyleBackColor = false;
            this.closeSerialButton.Click += new System.EventHandler(this.closeSerialButton_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(1749, 30);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(38, 20);
            this.label17.TabIndex = 15;
            this.label17.Text = "v1.0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(1514, 16);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 24);
            this.label12.TabIndex = 15;
            this.label12.Text = "Version";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(622, 20);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 20);
            this.label9.TabIndex = 15;
            this.label9.Text = "Date :";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(328, 20);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 20);
            this.label8.TabIndex = 14;
            this.label8.Text = "Time :";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.White;
            this.panelLogo.Controls.Add(this.panelDesktopPanel);
            this.panelLogo.Controls.Add(this.panel2);
            this.panelLogo.Controls.Add(this.panelMenu);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLogo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Margin = new System.Windows.Forms.Padding(4);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(1924, 817);
            this.panelLogo.TabIndex = 13;
            this.panelLogo.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panelDesktopPanel
            // 
            this.panelDesktopPanel.BackColor = System.Drawing.Color.White;
            this.panelDesktopPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panelDesktopPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelDesktopPanel.Location = new System.Drawing.Point(183, 0);
            this.panelDesktopPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelDesktopPanel.Name = "panelDesktopPanel";
            this.panelDesktopPanel.Padding = new System.Windows.Forms.Padding(3);
            this.panelDesktopPanel.Size = new System.Drawing.Size(1741, 747);
            this.panelDesktopPanel.TabIndex = 53;
            this.panelDesktopPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDesktopPanel_Paint);
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(87)))), ((int)(((byte)(149)))));
            this.panelMenu.Controls.Add(this.button5);
            this.panelMenu.Controls.Add(this.pictureBox1);
            this.panelMenu.Controls.Add(this.flowButton);
            this.panelMenu.Controls.Add(this.button4);
            this.panelMenu.Controls.Add(this.settingButton);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(183, 817);
            this.panelMenu.TabIndex = 54;
            // 
            // button5
            // 
            this.button5.Image = global::BASSCOMPORT.Properties.Resources.Asset_91;
            this.button5.Location = new System.Drawing.Point(9, 661);
            this.button5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(165, 146);
            this.button5.TabIndex = 4;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::BASSCOMPORT.Properties.Resources.PNG;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(183, 185);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // flowButton
            // 
            this.flowButton.Image = global::BASSCOMPORT.Properties.Resources.Asset_81;
            this.flowButton.Location = new System.Drawing.Point(9, 511);
            this.flowButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowButton.Name = "flowButton";
            this.flowButton.Size = new System.Drawing.Size(165, 146);
            this.flowButton.TabIndex = 3;
            this.flowButton.UseVisualStyleBackColor = true;
            this.flowButton.Click += new System.EventHandler(this.flowButton_Click);
            // 
            // button4
            // 
            this.button4.Image = global::BASSCOMPORT.Properties.Resources.Asset_72;
            this.button4.Location = new System.Drawing.Point(9, 361);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(165, 146);
            this.button4.TabIndex = 2;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // settingButton
            // 
            this.settingButton.Image = global::BASSCOMPORT.Properties.Resources.Asset_61;
            this.settingButton.Location = new System.Drawing.Point(9, 197);
            this.settingButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.settingButton.Name = "settingButton";
            this.settingButton.Size = new System.Drawing.Size(165, 160);
            this.settingButton.TabIndex = 1;
            this.settingButton.UseVisualStyleBackColor = true;
            this.settingButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(1633, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 22);
            this.label2.TabIndex = 19;
            this.label2.Text = "3.1v";
            // 
            // frrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(1924, 817);
            this.Controls.Add(this.panelLogo);
            this.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(1954, 867);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1270, 573);
            this.Name = "frrmMain";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SERIAL CONTROLLER";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frrmMain_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelLogo.ResumeLayout(false);
            this.panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblDataOutLength;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblDataInLength;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panelDesktopPanel;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Button closeSerialButton;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button flowButton;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button settingButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Label lblStatusCom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

