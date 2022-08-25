namespace BASSCOMPORT
{
    partial class FormScaling
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
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.maxScaleTextBox = new System.Windows.Forms.TextBox();
            this.minScaleTextBox = new System.Windows.Forms.TextBox();
            this.minScaleSetTextBox = new System.Windows.Forms.TextBox();
            this.maxScaleSetTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.setButton = new MetroSet_UI.Controls.MetroSetBadge();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.scaleButton = new MetroSet_UI.Controls.MetroSetBadge();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.progressBar1 = new MetroSet_UI.Controls.MetroSetProgressBar();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(52, 113);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 16);
            this.label10.TabIndex = 70;
            this.label10.Text = "maxScale";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(52, 56);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 16);
            this.label11.TabIndex = 69;
            this.label11.Text = "minScale";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.Black;
            this.label18.Location = new System.Drawing.Point(68, 109);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(67, 16);
            this.label18.TabIndex = 65;
            this.label18.Text = "maxScale";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(68, 56);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(63, 16);
            this.label16.TabIndex = 64;
            this.label16.Text = "minScale";
            // 
            // maxScaleTextBox
            // 
            this.maxScaleTextBox.BackColor = System.Drawing.Color.White;
            this.maxScaleTextBox.ForeColor = System.Drawing.Color.Black;
            this.maxScaleTextBox.Location = new System.Drawing.Point(358, 103);
            this.maxScaleTextBox.Name = "maxScaleTextBox";
            this.maxScaleTextBox.Size = new System.Drawing.Size(84, 22);
            this.maxScaleTextBox.TabIndex = 66;
            // 
            // minScaleTextBox
            // 
            this.minScaleTextBox.BackColor = System.Drawing.Color.White;
            this.minScaleTextBox.ForeColor = System.Drawing.Color.Black;
            this.minScaleTextBox.Location = new System.Drawing.Point(358, 53);
            this.minScaleTextBox.Name = "minScaleTextBox";
            this.minScaleTextBox.Size = new System.Drawing.Size(84, 22);
            this.minScaleTextBox.TabIndex = 67;
            // 
            // minScaleSetTextBox
            // 
            this.minScaleSetTextBox.BackColor = System.Drawing.Color.White;
            this.minScaleSetTextBox.ForeColor = System.Drawing.Color.Black;
            this.minScaleSetTextBox.Location = new System.Drawing.Point(358, 53);
            this.minScaleSetTextBox.Name = "minScaleSetTextBox";
            this.minScaleSetTextBox.Size = new System.Drawing.Size(84, 22);
            this.minScaleSetTextBox.TabIndex = 72;
            this.minScaleSetTextBox.TextChanged += new System.EventHandler(this.minScaleSetTextBox_TextChanged_1);
            // 
            // maxScaleSetTextBox
            // 
            this.maxScaleSetTextBox.BackColor = System.Drawing.Color.White;
            this.maxScaleSetTextBox.ForeColor = System.Drawing.Color.Black;
            this.maxScaleSetTextBox.Location = new System.Drawing.Point(358, 110);
            this.maxScaleSetTextBox.Name = "maxScaleSetTextBox";
            this.maxScaleSetTextBox.Size = new System.Drawing.Size(84, 22);
            this.maxScaleSetTextBox.TabIndex = 71;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.groupBox1.Controls.Add(this.setButton);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.maxScaleSetTextBox);
            this.groupBox1.Controls.Add(this.minScaleSetTextBox);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(159, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(605, 272);
            this.groupBox1.TabIndex = 74;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // setButton
            // 
            this.setButton.BackColor = System.Drawing.Color.Transparent;
            this.setButton.BadgeAlignment = MetroSet_UI.Enums.BadgeAlign.TopRight;
            this.setButton.BadgeText = "1";
            this.setButton.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.setButton.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.setButton.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.setButton.Font = new System.Drawing.Font("Impact", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setButton.HoverBadgeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(187)))), ((int)(((byte)(245)))));
            this.setButton.HoverBadgeTextColor = System.Drawing.Color.White;
            this.setButton.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.setButton.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.setButton.HoverTextColor = System.Drawing.Color.White;
            this.setButton.IsDerivedStyle = true;
            this.setButton.Location = new System.Drawing.Point(55, 147);
            this.setButton.Name = "setButton";
            this.setButton.NormalBadgeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.setButton.NormalBadgeTextColor = System.Drawing.Color.White;
            this.setButton.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.setButton.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.setButton.NormalTextColor = System.Drawing.Color.Black;
            this.setButton.PressBadgeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(147)))), ((int)(((byte)(205)))));
            this.setButton.PressBadgeTextColor = System.Drawing.Color.White;
            this.setButton.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.setButton.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.setButton.PressTextColor = System.Drawing.Color.White;
            this.setButton.Size = new System.Drawing.Size(501, 74);
            this.setButton.Style = MetroSet_UI.Enums.Style.Light;
            this.setButton.StyleManager = null;
            this.setButton.TabIndex = 78;
            this.setButton.Text = "SET";
            this.setButton.ThemeAuthor = "Narwin";
            this.setButton.ThemeName = "MetroLite";
            this.setButton.Click += new System.EventHandler(this.setButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(489, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.TabIndex = 75;
            this.label1.Text = "maxScale";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(489, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 16);
            this.label2.TabIndex = 74;
            this.label2.Text = "minScale";
            // 
            // scaleButton
            // 
            this.scaleButton.BackColor = System.Drawing.Color.Transparent;
            this.scaleButton.BadgeAlignment = MetroSet_UI.Enums.BadgeAlign.TopRight;
            this.scaleButton.BadgeText = "2";
            this.scaleButton.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.scaleButton.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.scaleButton.DisabledForeColor = System.Drawing.Color.Black;
            this.scaleButton.Font = new System.Drawing.Font("Impact", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scaleButton.HoverBadgeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(187)))), ((int)(((byte)(245)))));
            this.scaleButton.HoverBadgeTextColor = System.Drawing.Color.White;
            this.scaleButton.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.scaleButton.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.scaleButton.HoverTextColor = System.Drawing.Color.White;
            this.scaleButton.IsDerivedStyle = true;
            this.scaleButton.Location = new System.Drawing.Point(71, 154);
            this.scaleButton.Name = "scaleButton";
            this.scaleButton.NormalBadgeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.scaleButton.NormalBadgeTextColor = System.Drawing.Color.White;
            this.scaleButton.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(86)))), ((int)(((byte)(149)))));
            this.scaleButton.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(86)))), ((int)(((byte)(149)))));
            this.scaleButton.NormalTextColor = System.Drawing.SystemColors.ButtonFace;
            this.scaleButton.PressBadgeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(147)))), ((int)(((byte)(205)))));
            this.scaleButton.PressBadgeTextColor = System.Drawing.Color.White;
            this.scaleButton.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.scaleButton.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.scaleButton.PressTextColor = System.Drawing.Color.White;
            this.scaleButton.Size = new System.Drawing.Size(501, 74);
            this.scaleButton.Style = MetroSet_UI.Enums.Style.Custom;
            this.scaleButton.StyleManager = null;
            this.scaleButton.TabIndex = 79;
            this.scaleButton.Text = "CHANGE";
            this.scaleButton.ThemeAuthor = "Narwin";
            this.scaleButton.ThemeName = "MetroLite";
            this.scaleButton.Click += new System.EventHandler(this.scaleButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(489, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 16);
            this.label3.TabIndex = 77;
            this.label3.Text = "maxScale";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(489, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 16);
            this.label4.TabIndex = 76;
            this.label4.Text = "minScale";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(1123, 597);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(131, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 77;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Location = new System.Drawing.Point(248, 606);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(131, 64);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 79;
            this.pictureBox2.TabStop = false;
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.progressBar1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.progressBar1.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.progressBar1.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.progressBar1.DisabledProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.progressBar1.IsDerivedStyle = true;
            this.progressBar1.Location = new System.Drawing.Point(568, 619);
            this.progressBar1.Maximum = 100;
            this.progressBar1.Minimum = 0;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Orientation = MetroSet_UI.Enums.ProgressOrientation.Horizontal;
            this.progressBar1.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.progressBar1.Size = new System.Drawing.Size(369, 64);
            this.progressBar1.Style = MetroSet_UI.Enums.Style.Light;
            this.progressBar1.StyleManager = null;
            this.progressBar1.TabIndex = 80;
            this.progressBar1.Text = "asdasds";
            this.progressBar1.ThemeAuthor = "Narwin";
            this.progressBar1.ThemeName = "MetroLite";
            this.progressBar1.Value = 0;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::BASSCOMPORT.Properties.Resources.AÇIKLAMA;
            this.pictureBox3.Location = new System.Drawing.Point(922, 39);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(381, 536);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 81;
            this.pictureBox3.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.groupBox2.Controls.Add(this.maxScaleTextBox);
            this.groupBox2.Controls.Add(this.scaleButton);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.minScaleTextBox);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(159, 341);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(605, 272);
            this.groupBox2.TabIndex = 82;
            this.groupBox2.TabStop = false;
            // 
            // FormScaling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.BackgroundImage = global::BASSCOMPORT.Properties.Resources.Artboard_12;
            this.ClientSize = new System.Drawing.Size(1428, 719);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "FormScaling";
            this.Text = "FormScaling";
            this.Load += new System.EventHandler(this.FormScaling_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox maxScaleTextBox;
        private System.Windows.Forms.TextBox minScaleTextBox;
        private System.Windows.Forms.TextBox minScaleSetTextBox;
        private System.Windows.Forms.TextBox maxScaleSetTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Timer timer2;
        private MetroSet_UI.Controls.MetroSetBadge scaleButton;
        private MetroSet_UI.Controls.MetroSetBadge setButton;
        private MetroSet_UI.Controls.MetroSetProgressBar progressBar1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}