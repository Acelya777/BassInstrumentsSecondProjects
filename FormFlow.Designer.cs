using System.Windows.Media;
using System.Windows.Media;

namespace BASSCOMPORT
{
    partial class FormFlow
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.solidGauge1 = new LiveCharts.WinForms.SolidGauge();
            this.solidGauge2 = new LiveCharts.WinForms.SolidGauge();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.gridControl1 = new System.Windows.Forms.DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.intervalNumber = new System.Windows.Forms.ComboBox();
            this.intervalKind = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.intervalGroup = new System.Windows.Forms.GroupBox();
            this.intervalButton = new MetroSet_UI.Controls.MetroSetBadge();
            this.productGroup = new System.Windows.Forms.GroupBox();
            this.productButton = new MetroSet_UI.Controls.MetroSetBadge();
            this.dataGroup = new System.Windows.Forms.GroupBox();
            this.exportButton = new MetroSet_UI.Controls.MetroSetBadge();
            this.saveDataButton = new MetroSet_UI.Controls.MetroSetBadge();
            this.punitLabel = new System.Windows.Forms.Label();
            this.tunitLabel = new System.Windows.Forms.Label();
            this.timer4 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            this.intervalGroup.SuspendLayout();
            this.productGroup.SuspendLayout();
            this.dataGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chart1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.chart1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.Center;
            this.chart1.BorderlineColor = System.Drawing.SystemColors.ActiveBorder;
            chartArea1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            chartArea1.BackSecondaryColor = System.Drawing.SystemColors.ActiveBorder;
            chartArea1.BorderColor = System.Drawing.Color.Gray;
            chartArea1.Name = "ChartArea1";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 94F;
            chartArea1.Position.Width = 94F;
            chartArea1.Position.X = 3F;
            chartArea1.Position.Y = 3F;
            chartArea1.ShadowColor = System.Drawing.SystemColors.ActiveBorder;
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            legend1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.LeftRight;
            legend1.BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.BackwardDiagonal;
            legend1.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Top;
            legend1.BackImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            legend1.BackImageWrapMode = System.Windows.Forms.DataVisualization.Charting.ChartImageWrapMode.TileFlipX;
            legend1.BackSecondaryColor = System.Drawing.SystemColors.ActiveBorder;
            legend1.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            legend1.Enabled = false;
            legend1.HeaderSeparatorColor = System.Drawing.Color.White;
            legend1.ItemColumnSeparatorColor = System.Drawing.Color.White;
            legend1.Name = "Legend1";
            legend1.TitleBackColor = System.Drawing.SystemColors.ActiveBorder;
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(12, 337);
            this.chart1.MinimumSize = new System.Drawing.Size(380, 300);
            this.chart1.Name = "chart1";
            this.chart1.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            this.chart1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            series1.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Color = System.Drawing.Color.Gray;
            series1.CustomProperties = "IsXAxisQuantitative=True";
            series1.LabelBackColor = System.Drawing.SystemColors.ActiveBorder;
            series1.LabelBorderColor = System.Drawing.SystemColors.ActiveBorder;
            series1.LabelForeColor = System.Drawing.Color.DimGray;
            series1.Legend = "Legend1";
            series1.MarkerBorderColor = System.Drawing.SystemColors.ActiveBorder;
            series1.MarkerColor = System.Drawing.SystemColors.ActiveBorder;
            series1.MarkerImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            series1.Name = "Pressure";
            series1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Light;
            series1.YValuesPerPoint = 2;
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(420, 300);
            this.chart1.TabIndex = 45;
            this.chart1.Click += new System.EventHandler(this.chart2_Click);
            // 
            // solidGauge1
            // 
            this.solidGauge1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.solidGauge1.BackColor = System.Drawing.Color.Transparent;
            this.solidGauge1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.solidGauge1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.solidGauge1.Location = new System.Drawing.Point(466, 337);
            this.solidGauge1.MinimumSize = new System.Drawing.Size(400, 215);
            this.solidGauge1.Name = "solidGauge1";
            this.solidGauge1.Padding = new System.Windows.Forms.Padding(75, 0, 0, 0);
            this.solidGauge1.Size = new System.Drawing.Size(420, 300);
            this.solidGauge1.TabIndex = 47;
            this.solidGauge1.Text = "solidGauge1";
            // 
            // solidGauge2
            // 
            this.solidGauge2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.solidGauge2.BackColor = System.Drawing.Color.Transparent;
            this.solidGauge2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.solidGauge2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.solidGauge2.Location = new System.Drawing.Point(466, 31);
            this.solidGauge2.MinimumSize = new System.Drawing.Size(400, 215);
            this.solidGauge2.Name = "solidGauge2";
            this.solidGauge2.Padding = new System.Windows.Forms.Padding(75, 0, 0, 0);
            this.solidGauge2.Size = new System.Drawing.Size(420, 300);
            this.solidGauge2.TabIndex = 46;
            this.solidGauge2.Text = "solidGauge2";
            this.solidGauge2.ChildChanged += new System.EventHandler<System.Windows.Forms.Integration.ChildChangedEventArgs>(this.solidGauge2_ChildChanged);
            // 
            // chart2
            // 
            this.chart2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.chart2.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.Center;
            this.chart2.BorderlineColor = System.Drawing.SystemColors.ActiveBorder;
            chartArea2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            chartArea2.BackSecondaryColor = System.Drawing.SystemColors.ActiveBorder;
            chartArea2.BorderColor = System.Drawing.Color.Gray;
            chartArea2.Name = "ChartArea1";
            chartArea2.Position.Auto = false;
            chartArea2.Position.Height = 94F;
            chartArea2.Position.Width = 94F;
            chartArea2.Position.X = 3F;
            chartArea2.Position.Y = 3F;
            chartArea2.ShadowColor = System.Drawing.SystemColors.ActiveBorder;
            this.chart2.ChartAreas.Add(chartArea2);
            legend2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            legend2.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.LeftRight;
            legend2.BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.BackwardDiagonal;
            legend2.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Top;
            legend2.BackImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            legend2.BackImageWrapMode = System.Windows.Forms.DataVisualization.Charting.ChartImageWrapMode.TileFlipX;
            legend2.BackSecondaryColor = System.Drawing.SystemColors.ActiveBorder;
            legend2.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            legend2.Enabled = false;
            legend2.HeaderSeparatorColor = System.Drawing.Color.White;
            legend2.ItemColumnSeparatorColor = System.Drawing.Color.White;
            legend2.Name = "Legend1";
            legend2.TitleBackColor = System.Drawing.SystemColors.ActiveBorder;
            this.chart2.Legends.Add(legend2);
            this.chart2.Location = new System.Drawing.Point(12, 31);
            this.chart2.MinimumSize = new System.Drawing.Size(380, 250);
            this.chart2.Name = "chart2";
            this.chart2.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.chart2.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Light;
            this.chart2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            series2.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Color = System.Drawing.Color.Gray;
            series2.CustomProperties = "IsXAxisQuantitative=True";
            series2.LabelBackColor = System.Drawing.SystemColors.ActiveBorder;
            series2.LabelBorderColor = System.Drawing.SystemColors.ActiveBorder;
            series2.LabelForeColor = System.Drawing.Color.DimGray;
            series2.Legend = "Legend1";
            series2.MarkerBorderColor = System.Drawing.SystemColors.ActiveBorder;
            series2.MarkerColor = System.Drawing.SystemColors.ActiveBorder;
            series2.MarkerImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            series2.Name = "Pressure";
            series2.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Light;
            series2.YValuesPerPoint = 2;
            this.chart2.Series.Add(series2);
            this.chart2.Size = new System.Drawing.Size(420, 300);
            this.chart2.TabIndex = 48;
            // 
            // gridControl1
            // 
            this.gridControl1.AllowDrop = true;
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridControl1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.gridControl1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.gridControl1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridControl1.Location = new System.Drawing.Point(914, 12);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RowHeadersWidth = 51;
            this.gridControl1.RowTemplate.Height = 24;
            this.gridControl1.RowTemplate.ReadOnly = true;
            this.gridControl1.Size = new System.Drawing.Size(586, 504);
            this.gridControl1.TabIndex = 49;
            this.gridControl1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridControl1_CellContentClick);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 3000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // intervalNumber
            // 
            this.intervalNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.intervalNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.intervalNumber.FormattingEnabled = true;
            this.intervalNumber.Location = new System.Drawing.Point(37, 67);
            this.intervalNumber.Name = "intervalNumber";
            this.intervalNumber.Size = new System.Drawing.Size(121, 24);
            this.intervalNumber.TabIndex = 62;
            // 
            // intervalKind
            // 
            this.intervalKind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.intervalKind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.intervalKind.FormattingEnabled = true;
            this.intervalKind.Location = new System.Drawing.Point(37, 121);
            this.intervalKind.Name = "intervalKind";
            this.intervalKind.Size = new System.Drawing.Size(121, 24);
            this.intervalKind.TabIndex = 63;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(20, 42);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(121, 22);
            this.textBox1.TabIndex = 65;
            // 
            // intervalGroup
            // 
            this.intervalGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.intervalGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.intervalGroup.Controls.Add(this.intervalButton);
            this.intervalGroup.Controls.Add(this.intervalNumber);
            this.intervalGroup.Controls.Add(this.intervalKind);
            this.intervalGroup.ForeColor = System.Drawing.Color.Black;
            this.intervalGroup.Location = new System.Drawing.Point(914, 452);
            this.intervalGroup.Name = "intervalGroup";
            this.intervalGroup.Size = new System.Drawing.Size(290, 199);
            this.intervalGroup.TabIndex = 67;
            this.intervalGroup.TabStop = false;
            this.intervalGroup.Text = "Interval(2)";
            // 
            // intervalButton
            // 
            this.intervalButton.BackColor = System.Drawing.Color.Transparent;
            this.intervalButton.BadgeAlignment = MetroSet_UI.Enums.BadgeAlign.TopRight;
            this.intervalButton.BadgeText = "2";
            this.intervalButton.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.intervalButton.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.intervalButton.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.intervalButton.Font = new System.Drawing.Font("Impact", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.intervalButton.HoverBadgeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(187)))), ((int)(((byte)(245)))));
            this.intervalButton.HoverBadgeTextColor = System.Drawing.Color.White;
            this.intervalButton.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.intervalButton.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.intervalButton.HoverTextColor = System.Drawing.Color.White;
            this.intervalButton.IsDerivedStyle = true;
            this.intervalButton.Location = new System.Drawing.Point(179, 57);
            this.intervalButton.Name = "intervalButton";
            this.intervalButton.NormalBadgeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.intervalButton.NormalBadgeTextColor = System.Drawing.Color.White;
            this.intervalButton.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.intervalButton.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.intervalButton.NormalTextColor = System.Drawing.Color.Black;
            this.intervalButton.PressBadgeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(147)))), ((int)(((byte)(205)))));
            this.intervalButton.PressBadgeTextColor = System.Drawing.Color.White;
            this.intervalButton.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.intervalButton.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.intervalButton.PressTextColor = System.Drawing.Color.White;
            this.intervalButton.Size = new System.Drawing.Size(111, 78);
            this.intervalButton.Style = MetroSet_UI.Enums.Style.Light;
            this.intervalButton.StyleManager = null;
            this.intervalButton.TabIndex = 70;
            this.intervalButton.Text = "Save Interval";
            this.intervalButton.ThemeAuthor = "Narwin";
            this.intervalButton.ThemeName = "MetroLite";
            this.intervalButton.Click += new System.EventHandler(this.intervalButton_Click);
            // 
            // productGroup
            // 
            this.productGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.productGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.productGroup.Controls.Add(this.productButton);
            this.productGroup.Controls.Add(this.textBox1);
            this.productGroup.ForeColor = System.Drawing.Color.Black;
            this.productGroup.Location = new System.Drawing.Point(1210, 452);
            this.productGroup.Name = "productGroup";
            this.productGroup.Size = new System.Drawing.Size(290, 100);
            this.productGroup.TabIndex = 68;
            this.productGroup.TabStop = false;
            this.productGroup.Text = "Product Number(1)";
            // 
            // productButton
            // 
            this.productButton.BackColor = System.Drawing.Color.Transparent;
            this.productButton.BadgeAlignment = MetroSet_UI.Enums.BadgeAlign.TopRight;
            this.productButton.BadgeText = "1";
            this.productButton.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.productButton.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.productButton.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.productButton.Font = new System.Drawing.Font("Impact", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productButton.HoverBadgeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(187)))), ((int)(((byte)(245)))));
            this.productButton.HoverBadgeTextColor = System.Drawing.Color.White;
            this.productButton.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.productButton.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.productButton.HoverTextColor = System.Drawing.Color.White;
            this.productButton.IsDerivedStyle = true;
            this.productButton.Location = new System.Drawing.Point(167, 0);
            this.productButton.Name = "productButton";
            this.productButton.NormalBadgeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.productButton.NormalBadgeTextColor = System.Drawing.Color.White;
            this.productButton.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.productButton.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.productButton.NormalTextColor = System.Drawing.Color.Black;
            this.productButton.PressBadgeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(147)))), ((int)(((byte)(205)))));
            this.productButton.PressBadgeTextColor = System.Drawing.Color.White;
            this.productButton.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.productButton.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.productButton.PressTextColor = System.Drawing.Color.White;
            this.productButton.Size = new System.Drawing.Size(111, 78);
            this.productButton.Style = MetroSet_UI.Enums.Style.Light;
            this.productButton.StyleManager = null;
            this.productButton.TabIndex = 67;
            this.productButton.Text = "Save Product Number";
            this.productButton.ThemeAuthor = "Narwin";
            this.productButton.ThemeName = "MetroLite";
            this.productButton.Click += new System.EventHandler(this.productButton_Click);
            // 
            // dataGroup
            // 
            this.dataGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.dataGroup.Controls.Add(this.exportButton);
            this.dataGroup.Controls.Add(this.saveDataButton);
            this.dataGroup.ForeColor = System.Drawing.Color.Black;
            this.dataGroup.Location = new System.Drawing.Point(1210, 551);
            this.dataGroup.Name = "dataGroup";
            this.dataGroup.Size = new System.Drawing.Size(290, 100);
            this.dataGroup.TabIndex = 69;
            this.dataGroup.TabStop = false;
            this.dataGroup.Text = "Data and Excel(3)";
            // 
            // exportButton
            // 
            this.exportButton.BackColor = System.Drawing.Color.Transparent;
            this.exportButton.BadgeAlignment = MetroSet_UI.Enums.BadgeAlign.TopRight;
            this.exportButton.BadgeText = "3";
            this.exportButton.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.exportButton.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.exportButton.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.exportButton.Font = new System.Drawing.Font("Impact", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportButton.HoverBadgeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(187)))), ((int)(((byte)(245)))));
            this.exportButton.HoverBadgeTextColor = System.Drawing.Color.White;
            this.exportButton.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.exportButton.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.exportButton.HoverTextColor = System.Drawing.Color.White;
            this.exportButton.IsDerivedStyle = true;
            this.exportButton.Location = new System.Drawing.Point(20, 16);
            this.exportButton.Name = "exportButton";
            this.exportButton.NormalBadgeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.exportButton.NormalBadgeTextColor = System.Drawing.Color.White;
            this.exportButton.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.exportButton.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.exportButton.NormalTextColor = System.Drawing.Color.Black;
            this.exportButton.PressBadgeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(147)))), ((int)(((byte)(205)))));
            this.exportButton.PressBadgeTextColor = System.Drawing.Color.White;
            this.exportButton.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.exportButton.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.exportButton.PressTextColor = System.Drawing.Color.White;
            this.exportButton.Size = new System.Drawing.Size(111, 78);
            this.exportButton.Style = MetroSet_UI.Enums.Style.Light;
            this.exportButton.StyleManager = null;
            this.exportButton.TabIndex = 69;
            this.exportButton.Text = "Start Collecting Data";
            this.exportButton.ThemeAuthor = "Narwin";
            this.exportButton.ThemeName = "MetroLite";
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click_1);
            // 
            // saveDataButton
            // 
            this.saveDataButton.BackColor = System.Drawing.Color.Transparent;
            this.saveDataButton.BadgeAlignment = MetroSet_UI.Enums.BadgeAlign.TopRight;
            this.saveDataButton.BadgeText = "4";
            this.saveDataButton.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.saveDataButton.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.saveDataButton.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.saveDataButton.Font = new System.Drawing.Font("Impact", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveDataButton.HoverBadgeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(187)))), ((int)(((byte)(245)))));
            this.saveDataButton.HoverBadgeTextColor = System.Drawing.Color.White;
            this.saveDataButton.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.saveDataButton.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.saveDataButton.HoverTextColor = System.Drawing.Color.White;
            this.saveDataButton.IsDerivedStyle = true;
            this.saveDataButton.Location = new System.Drawing.Point(167, 16);
            this.saveDataButton.Name = "saveDataButton";
            this.saveDataButton.NormalBadgeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.saveDataButton.NormalBadgeTextColor = System.Drawing.Color.White;
            this.saveDataButton.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.saveDataButton.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.saveDataButton.NormalTextColor = System.Drawing.Color.Black;
            this.saveDataButton.PressBadgeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(147)))), ((int)(((byte)(205)))));
            this.saveDataButton.PressBadgeTextColor = System.Drawing.Color.White;
            this.saveDataButton.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.saveDataButton.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.saveDataButton.PressTextColor = System.Drawing.Color.White;
            this.saveDataButton.Size = new System.Drawing.Size(111, 78);
            this.saveDataButton.Style = MetroSet_UI.Enums.Style.Light;
            this.saveDataButton.StyleManager = null;
            this.saveDataButton.TabIndex = 68;
            this.saveDataButton.Text = "Save Data(xsl)";
            this.saveDataButton.ThemeAuthor = "Narwin";
            this.saveDataButton.ThemeName = "MetroLite";
            this.saveDataButton.Click += new System.EventHandler(this.saveDataButton_Click_1);
            // 
            // punitLabel
            // 
            this.punitLabel.AutoSize = true;
            this.punitLabel.BackColor = System.Drawing.Color.Transparent;
            this.punitLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.punitLabel.ForeColor = System.Drawing.Color.Black;
            this.punitLabel.Location = new System.Drawing.Point(438, 43);
            this.punitLabel.Name = "punitLabel";
            this.punitLabel.Size = new System.Drawing.Size(73, 22);
            this.punitLabel.TabIndex = 70;
            this.punitLabel.Text = "mBar(x̄)";
            // 
            // tunitLabel
            // 
            this.tunitLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tunitLabel.AutoSize = true;
            this.tunitLabel.BackColor = System.Drawing.Color.Transparent;
            this.tunitLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tunitLabel.ForeColor = System.Drawing.Color.Black;
            this.tunitLabel.Location = new System.Drawing.Point(438, 349);
            this.tunitLabel.Name = "tunitLabel";
            this.tunitLabel.Size = new System.Drawing.Size(101, 22);
            this.tunitLabel.TabIndex = 71;
            this.tunitLabel.Text = "Celsius(°C)";
            // 
            // timer4
            // 
            this.timer4.Enabled = true;
            this.timer4.Interval = 1000;
            this.timer4.Tick += new System.EventHandler(this.timer4_Tick);
            // 
            // FormFlow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.BackgroundImage = global::BASSCOMPORT.Properties.Resources.Artboard_13;
            this.ClientSize = new System.Drawing.Size(1500, 659);
            this.Controls.Add(this.tunitLabel);
            this.Controls.Add(this.punitLabel);
            this.Controls.Add(this.dataGroup);
            this.Controls.Add(this.productGroup);
            this.Controls.Add(this.intervalGroup);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.solidGauge1);
            this.Controls.Add(this.solidGauge2);
            this.Controls.Add(this.chart1);
            this.Name = "FormFlow";
            this.Text = "FormFlow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormFlow_FormClosing);
            this.Load += new System.EventHandler(this.FormFlow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            this.intervalGroup.ResumeLayout(false);
            this.productGroup.ResumeLayout(false);
            this.productGroup.PerformLayout();
            this.dataGroup.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private LiveCharts.WinForms.SolidGauge solidGauge1;
        private LiveCharts.WinForms.SolidGauge solidGauge2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.DataGridView gridControl1;
        public System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.ComboBox intervalNumber;
        private System.Windows.Forms.ComboBox intervalKind;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox intervalGroup;
        private System.Windows.Forms.GroupBox productGroup;
        private System.Windows.Forms.GroupBox dataGroup;
        private System.Windows.Forms.Label punitLabel;
        private System.Windows.Forms.Label tunitLabel;
        private System.Windows.Forms.Timer timer4;
        private MetroSet_UI.Controls.MetroSetBadge intervalButton;
        private MetroSet_UI.Controls.MetroSetBadge productButton;
        private MetroSet_UI.Controls.MetroSetBadge exportButton;
        private MetroSet_UI.Controls.MetroSetBadge saveDataButton;
    }
}