﻿using System;
using System.Data;
using System.IO;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static BASSCOMPORT.frrmMain;

namespace BASSCOMPORT
{


    public partial class FormFlow : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
      (
          int nLeftRect,     // x-coordinate of upper-left corner
          int nTopRect,      // y-coordinate of upper-left corner
          int nRightRect,    // x-coordinate of lower-right corner
          int nBottomRect,   // y-coordinate of lower-right corner
          int nWidthEllipse, // width of ellipse
          int nHeightEllipse // height of ellipse
      );

        [DllImport("gdi32.dll", EntryPoint = "DeleteObject")]
        private static extern bool DeleteObject(System.IntPtr hObject);

        private string txtname;
        private string path;
        
        double temp = 0, pressure = 0, minScale = 0, maxScale = 0;
        bool updateData = false;
        double duration, durationn;
        
        SerialPort myPort;
        FormSettings formS = new FormSettings();
        private delegate void SetTextDeleg(string text);
        String productNumber = "";






        public FormFlow()
        {


            InitializeComponent();
            productGroup.Font = new System.Drawing.Font("Arial", 8F);
            dataGroup.Font = new System.Drawing.Font("Arial", 8F);
            intervalGroup.Font = new System.Drawing.Font("Arial", 8F);
            punitLabel.Font = new System.Drawing.Font("Arial", 15F);
            tunitLabel.Font = new System.Drawing.Font("Arial", 15F);
            productButton.NormalBadgeColor = System.Drawing.Color.Red;
            intervalButton.NormalBadgeColor = System.Drawing.Color.Red;
            exportButton.NormalBadgeColor = System.Drawing.Color.Red;
            saveDataButton.NormalBadgeColor = System.Drawing.Color.Red;

            IntPtr ptr = CreateRoundRectRgn(0, 0, gridControl1.Width, gridControl1.Height, 15, 15);
            gridControl1.Region = System.Drawing.Region.FromHrgn(ptr);
            DeleteObject(ptr);
            IntPtr ptr2 = CreateRoundRectRgn(0, 0, dataGroup.Width, dataGroup.Height, 15, 15);
            dataGroup.Region = System.Drawing.Region.FromHrgn(ptr2);
            DeleteObject(ptr2);
            IntPtr ptr3 = CreateRoundRectRgn(0, 0, intervalGroup.Width, intervalGroup.Height, 15, 15);
            intervalGroup.Region = System.Drawing.Region.FromHrgn(ptr3);
            DeleteObject(ptr3);
            IntPtr ptr4 = CreateRoundRectRgn(0, 0, productGroup.Width, productGroup.Height, 15, 15);
            productGroup.Region = System.Drawing.Region.FromHrgn(ptr4);
            DeleteObject(ptr4);






            if (variables.numEN == 11)
            {
                variables.records = new DataTable();
                variables.records.Columns.Add("Ürün Numarası", typeof(String));

                if (variables.numT == 12)
                {
                    variables.records.Columns.Add("Sıcaklık(K)", typeof(float));
                }
                else if (variables.numT == 13)
                {
                    variables.records.Columns.Add("Sıcaklık(°F)", typeof(float));

                }
                else if (variables.numT ==1)
                {
                    variables.records.Columns.Add("Sıcaklık(°C)", typeof(float));
                }
                if (variables.numP == 14)
                {
                    variables.records.Columns.Add("Basınç(Bar)", typeof(float));
                }
                else if (variables.numP == 15)
                {
                    variables.records.Columns.Add("Basınç(Pa)", typeof(float));
                }
                else if (variables.numP == 16)
                {
                    variables.records.Columns.Add("Basınç(kg/cm2)", typeof(float));
                }
                else if (variables.numP == 17)
                {
                    variables.records.Columns.Add("Basınç(mmh2o)", typeof(float));
                }
                else if (variables.numP == 18)
                {
                    variables.records.Columns.Add("Basınç(mh2o)", typeof(float));
                }
                else if (variables.numP == 19)
                {
                    variables.records.Columns.Add("Basınç(mmHg)", typeof(float));
                }
                else if (variables.numP == 20)
                {
                    variables.records.Columns.Add("Basınç(psi)", typeof(float));
                }
                else if (variables.numP == 21)
                {
                    variables.records.Columns.Add("Basınç(kPa)", typeof(float));
                }
                else if (variables.numP == 22)
                {
                    variables.records.Columns.Add("Basınç(MPa)", typeof(float));

                }
                else if (variables.numP == 23)
                {
                    variables.records.Columns.Add("Basınç(iwg)", typeof(float));
                }
                else
                {
                    variables.records.Columns.Add("Basınç(mBar)", typeof(float));
                }
                variables.records.Columns.Add("Tarih", typeof(DateTime));
                gridControl1.DataSource = variables.records;
                txtname = variables.RandomString(5) + ".txt";
                path = AppDomain.CurrentDomain.BaseDirectory + txtname;
                File.Create(path);

            }

            else if (variables.numEN == 10)
            {
                variables.records = new DataTable();
                variables.records.Columns.Add("Product Number", typeof(String));
                if (variables.numT == 12)
                {
                    variables.records.Columns.Add("Temperature(K)", typeof(float));
                }
                else if (variables.numT == 13)
                {
                    variables.records.Columns.Add("Temperature(°F)", typeof(float));

                }
                else if (variables.numT == 1)
                {
                    variables.records.Columns.Add("Temperature(°C)", typeof(float));
                }
                if (variables.numP == 14)
                {
                    variables.records.Columns.Add("Pressure(Bar)", typeof(float));
                }
                else if (variables.numP == 15)
                {
                    variables.records.Columns.Add("Pressure(Pa)", typeof(float));
                }
                else if (variables.numP == 16)
                {
                    variables.records.Columns.Add("Pressure(kg/cm2)", typeof(float));
                }
                else if (variables.numP == 17)
                {
                    variables.records.Columns.Add("Pressure(mmh2o)", typeof(float));
                }
                else if (variables.numP == 18)
                {
                    variables.records.Columns.Add("Pressure(mh2o)", typeof(float));
                }
                else if (variables.numP == 19)
                {
                    variables.records.Columns.Add("Pressure(mmHg)", typeof(float));
                }
                else if (variables.numP == 20)
                {
                    variables.records.Columns.Add("Pressure(psi)", typeof(float));
                }
                else if (variables.numP == 21)
                {
                    variables.records.Columns.Add("Pressure(kPa)", typeof(float));
                }
                else if (variables.numP == 22)
                {
                    variables.records.Columns.Add("Pressure(MPa)", typeof(float));
                }
                else if (variables.numP == 23)
                {
                    variables.records.Columns.Add("Inch Water(iwg)", typeof(float));
                }
                else
                {
                    variables.records.Columns.Add("Pressure(mBar)", typeof(float));
                }
                variables.records.Columns.Add("Date", typeof(DateTime));
                gridControl1.DataSource = variables.records;
                txtname = variables.RandomString(5) + ".txt";
                path = AppDomain.CurrentDomain.BaseDirectory + txtname;
                File.Create(path);
            }





        }



        private void chart2_Click(object sender, EventArgs e)
        {

        }

        public void StartForm()
        {

            Application.Run(new splashScreen());
        }

        private void FormFlow_Load(object sender, EventArgs e)
        {

            if (variables.numT == 12)
            {
                tunitLabel.Text = "°K";

            }
            else if (variables.numT == 13)
            {
                tunitLabel.Text = "°F";

            }
            else if (variables.numT == 1)
            {
                tunitLabel.Text = "°C ";
            }

            if (variables.numP == 14)
            {
                punitLabel.Text = "Bar";

            }
            else if (variables.numP == 15)
            {
                punitLabel.Text = "Pa";
            }
            else if (variables.numP == 16)
            {
                punitLabel.Text = "kg/cm2";
            }
            else if (variables.numP == 17)
            {
                punitLabel.Text = "mmh2o";
            }
            else if (variables.numP == 18)
            {
                punitLabel.Text = "mh2o";
            }
            else if (variables.numP == 19)
            {
                punitLabel.Text = "mmHg";
            }
            else if (variables.numP == 20)
            {
                punitLabel.Text = "psi";
            }
            else if (variables.numP == 21)
            {
                punitLabel.Text = "kPa";
            }
            else if (variables.numP == 22)
            {
                punitLabel.Text = "MPa";
            }
            else if (variables.numP == 23)
            {
                punitLabel.Text = "MPa";
            }
            else
            {
                punitLabel.Text = "mBar";
            }

            if (variables.numEN == 11)
            {
                intervalNumber.Items.AddRange(new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60 });
                intervalKind.Items.AddRange(new object[] { "saniye", "dakika", "saat" });
            }
            else if (variables.numEN ==10)
            {
                intervalNumber.Items.AddRange(new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60 });
                intervalKind.Items.AddRange(new object[] { "second", "minute", "hour" });
            }




            intervalNumber.SelectedItem = null;
            intervalNumber.SelectedIndex = 0;
            intervalKind.SelectedIndex = 0;
            


            saveDataButton.Enabled = false;
            exportButton.Enabled = false;


            myPort = new SerialPort();
            myPort = variables.serialPort;
            serialPort1 = new SerialPort();
            serialPort1 = myPort;
            serialPort1.DataReceived += new SerialDataReceivedEventHandler(sp_DataReceived);







            if (serialPort1.IsOpen)
            {

                Enabled = true;
                timer1.Interval = 1000;
                timer2.Interval = 3000;
                timer2.Enabled = true;
                timer1.Start();
                //timer3.Start();



            }


            System.Windows.Threading.Dispatcher.CurrentDispatcher.Invoke((() =>

            {
                if (variables.numT == 12) // kelvin
                {
                    solidGauge1.From = 254;
                    solidGauge1.To = 414;
                    solidGauge1.Uses360Mode = true;
                    solidGauge2.Value = 0;

                    if (variables.numP == 14)
                    {
                        solidGauge2.Uses360Mode = true;
                        solidGauge2.To = 1000;
                        solidGauge2.From = -1;
                        solidGauge2.Value = 0;
                    }

                    else if (variables.numP == 15)
                    {
                        solidGauge2.Uses360Mode = true;
                        solidGauge2.To = 100000000;
                        solidGauge2.From = -100000;
                        solidGauge2.Value = 0;

                    }
                    else if (variables.numP == 16)
                    {
                        solidGauge2.Uses360Mode = true;
                        solidGauge2.To = 1019;
                        solidGauge2.From = -1;
                        solidGauge2.Value = 0;

                    }
                    else if (variables.numP == 17)
                    {
                        solidGauge2.Uses360Mode = true;
                        solidGauge2.To = 10197162;
                        solidGauge2.From = -10197;
                        solidGauge2.Value = 0;

                    }
                    else if (variables.numP == 18)
                    {
                        solidGauge2.Uses360Mode = true;
                        solidGauge2.To = 10197;
                        solidGauge2.From = -10;
                        solidGauge2.Value = 0;

                    }
                    else if (variables.numP == 19)
                    {
                        solidGauge2.Uses360Mode = true;
                        solidGauge2.To = 750061;
                        solidGauge2.From = -750;
                        solidGauge2.Value = 0;

                    }
                    else if (variables.numP == 20)
                    {
                        solidGauge2.Uses360Mode = true;
                        solidGauge2.To = 14500;
                        solidGauge2.From = -15;
                        solidGauge2.Value = 0;

                    }
                    else if (variables.numP == 21)
                    {
                        solidGauge2.Uses360Mode = true;
                        solidGauge2.To = 100000;
                        solidGauge2.From = -100;
                        solidGauge2.Value = 0;

                    }
                    else if (variables.numP == 22)
                    {
                        solidGauge2.Uses360Mode = true;
                        solidGauge2.To = 100;
                        solidGauge2.From = -0.1;
                        solidGauge2.Value = 0;
                    }
                    else if (variables.numP == 23)
                    {
                        solidGauge2.Uses360Mode = true;
                        solidGauge2.To = 401464;
                        solidGauge2.From = -402;
                        solidGauge2.Value = 0;
                    }
                    else
                    {
                        solidGauge2.Uses360Mode = true;
                        solidGauge2.To = 1000000;
                        solidGauge2.From = -1000;
                        solidGauge2.Value = 0;
                    }
                }

                else if (variables.numT == 13) // fahrenheit
                {
                    solidGauge1.From = 30;
                    solidGauge1.To = 284;
                    solidGauge1.Uses360Mode = true;
                    solidGauge2.Value = 0;

                    if (variables.numP == 14)
                    {
                        solidGauge2.Uses360Mode = true;
                        solidGauge2.To = 1000;
                        solidGauge2.From = -1;
                        solidGauge2.Value = 0;
                    }

                    else if (variables.numP == 15)
                    {
                        solidGauge2.Uses360Mode = true;
                        solidGauge2.To = 100000000;
                        solidGauge2.From = -100000;
                        solidGauge2.Value = 0;

                    }
                    else if (variables.numP == 16)
                    {
                        solidGauge2.Uses360Mode = true;
                        solidGauge2.To = 1019;
                        solidGauge2.From = -1;
                        solidGauge2.Value = 0;

                    }
                    else if (variables.numP == 17)
                    {
                        solidGauge2.Uses360Mode = true;
                        solidGauge2.To = 10197162;
                        solidGauge2.From = -10197;
                        solidGauge2.Value = 0;

                    }
                    else if (variables.numP == 18)
                    {
                        solidGauge2.Uses360Mode = true;
                        solidGauge2.To = 10197;
                        solidGauge2.From = -10;
                        solidGauge2.Value = 0;

                    }
                    else if (variables.numP == 19)
                    {
                        solidGauge2.Uses360Mode = true;
                        solidGauge2.To = 750061;
                        solidGauge2.From = -750;
                        solidGauge2.Value = 0;

                    }
                    else if (variables.numP == 20)
                    {
                        solidGauge2.Uses360Mode = true;
                        solidGauge2.To = 14500;
                        solidGauge2.From = -15;
                        solidGauge2.Value = 0;

                    }
                    else if (variables.numP == 21)
                    {
                        solidGauge2.Uses360Mode = true;
                        solidGauge2.To = 100000;
                        solidGauge2.From = -100;
                        solidGauge2.Value = 0;

                    }
                    else if (variables.numP == 22)
                    {
                        solidGauge2.Uses360Mode = true;
                        solidGauge2.To = 100;
                        solidGauge2.From = -0.1;
                        solidGauge2.Value = 0;
                    }
                    else if (variables.numP == 23)
                    {
                        solidGauge2.Uses360Mode = true;
                        solidGauge2.To = 401464;
                        solidGauge2.From = -402;
                        solidGauge2.Value = 0;
                    }
                    else
                    {
                        solidGauge2.Uses360Mode = true;
                        solidGauge2.To = 1000000;
                        solidGauge2.From = -1000;
                        solidGauge2.Value = 0;
                    }
                }

                else if (variables.numT == 1) // celcius
                {
                    solidGauge1.From = -20;
                    solidGauge1.To = 150;
                    solidGauge1.Uses360Mode = true;
                    solidGauge2.Value = -20;

                    if (variables.numP == 14)
                    {
                        solidGauge2.Uses360Mode = true;
                        solidGauge2.To = 1000;
                        solidGauge2.From = -1;
                        solidGauge2.Value = 0;
                    }

                    else if (variables.numP == 15)
                    {
                        solidGauge2.Uses360Mode = true;
                        solidGauge2.To = 100000000;
                        solidGauge2.From = -100000;
                        solidGauge2.Value = 0;

                    }
                    else if (variables.numP == 16)
                    {
                        solidGauge2.Uses360Mode = true;
                        solidGauge2.To = 1019;
                        solidGauge2.From = -1;
                        solidGauge2.Value = 0;

                    }
                    else if (variables.numP == 17)
                    {
                        solidGauge2.Uses360Mode = true;
                        solidGauge2.To = 10197162;
                        solidGauge2.From = -10197;
                        solidGauge2.Value = 0;

                    }
                    else if (variables.numP == 18)
                    {
                        solidGauge2.Uses360Mode = true;
                        solidGauge2.To = 10197;
                        solidGauge2.From = -10;
                        solidGauge2.Value = 0;

                    }
                    else if (variables.numP == 19)
                    {
                        solidGauge2.Uses360Mode = true;
                        solidGauge2.To = 750061;
                        solidGauge2.From = -750;
                        solidGauge2.Value = 0;

                    }
                    else if (variables.numP == 20)
                    {
                        solidGauge2.Uses360Mode = true;
                        solidGauge2.To = 14500;
                        solidGauge2.From = -15;
                        solidGauge2.Value = 0;

                    }
                    else if (variables.numP == 21)
                    {
                        solidGauge2.Uses360Mode = true;
                        solidGauge2.To = 100000;
                        solidGauge2.From = -100;
                        solidGauge2.Value = 0;

                    }
                    else if (variables.numP == 22)
                    {
                        solidGauge2.Uses360Mode = true;
                        solidGauge2.To = 100;
                        solidGauge2.From = -0.1;
                        solidGauge2.Value = 0;
                    }
                    else if (variables.numP == 23)
                    {
                        solidGauge2.Uses360Mode = true;
                        solidGauge2.To = 401464;
                        solidGauge2.From = -402;
                        solidGauge2.Value = 0;
                    }
                    else if (variables.numP == 2)
                    {
                        solidGauge2.Uses360Mode = true;
                        solidGauge2.To = 1000000;
                        solidGauge2.From = -1000;
                        solidGauge2.Value = 0;
                    }
                }
                /*solidGauge1.From = -20;
                solidGauge1.To = 150;
                solidGauge1.Uses360Mode = true;
                solidGauge2.Value = -20;

                solidGauge2.Uses360Mode = true;
                solidGauge2.To = 500000;
                solidGauge2.From = 0;
                solidGauge2.Value = 0;*/
                solidGauge1.Base.LabelsVisibility = System.Windows.Visibility.Hidden;
                solidGauge1.Base.GaugeActiveFill = new System.Windows.Media.LinearGradientBrush
                {
                    GradientStops = new System.Windows.Media.GradientStopCollection
                            {
                                new System.Windows.Media.GradientStop(System.Windows.Media.Colors.Brown,6),

                            }

                };

                solidGauge2.Base.GaugeActiveFill = new System.Windows.Media.LinearGradientBrush
                {
                    GradientStops = new System.Windows.Media.GradientStopCollection
                            {
                                new System.Windows.Media.GradientStop(System.Windows.Media.Colors.Green,6),

                            }

                };
            })); // gauge's features == graph


        }
        
        bool firstrecord = false;
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                if (variables.numEN == 11) //for TR
                {
                    if (variables.recordstate == true)
                    {
                        if (variables.numT == 12) // for Kelvin
                        {
                            if (variables.numP == 14) // for Bar
                            {
                                double kelvinS = 273.15;
                                double kelvin = (temp + kelvinS);
                                variables.records.Rows.Add(productNumber, kelvin, pressure / 1000, DateTime.Now);

                                using (var tw = new StreamWriter(path, true))
                                {
                                    if (!firstrecord)
                                    {
                                        tw.WriteLine(productNumber + "," + "Sıcaklık" + "," + "Basınç" + "," + "Tarih");
                                        firstrecord = true;
                                    }

                                    gridControl1.FirstDisplayedScrollingRowIndex = gridControl1.RowCount - 1;
                                    tw.WriteLine(productNumber + kelvin.ToString() + "," + (pressure / 1000).ToString() + "," + variables.Density.ToString() + "," + DateTime.Now.ToString());
                                    tw.Close();
                                }


                                gridControl1.Update();
                            }

                            else if (variables.numP == 15) // for Pa
                            {
                                double kelvinS = 273.15;
                                double kelvin = (temp + kelvinS);
                                variables.records.Rows.Add(productNumber, kelvin, pressure * 100, DateTime.Now);

                                using (var tw = new StreamWriter(path, true))
                                {
                                    if (!firstrecord)
                                    {
                                        tw.WriteLine(productNumber + "," + "Sıcaklık" + "," + "Basınç" + "," + "Tarih");
                                        firstrecord = true;
                                    }
                                    gridControl1.FirstDisplayedScrollingRowIndex = gridControl1.RowCount - 1;

                                    tw.WriteLine(productNumber + kelvin.ToString() + "," + (pressure * 100).ToString() + "," + variables.Density.ToString() + "," + DateTime.Now.ToString());
                                    tw.Close();
                                }


                                gridControl1.Update();
                            }

                            else if (variables.numP == 16) // for kg/cm2
                            {
                                double kelvinS = 273.15;
                                double kelvin = (temp + kelvinS);
                                variables.records.Rows.Add(productNumber, kelvin, pressure * 0.00102, DateTime.Now);

                                using (var tw = new StreamWriter(path, true))
                                {
                                    if (!firstrecord)
                                    {
                                        tw.WriteLine(productNumber + "," + "Sıcaklık" + "," + "Basınç" + "," + "Tarih");
                                        firstrecord = true;
                                    }

                                    gridControl1.FirstDisplayedScrollingRowIndex = gridControl1.RowCount - 1;
                                    tw.WriteLine(productNumber + kelvin.ToString() + "," + (pressure * 0.00102).ToString() + "," + variables.Density.ToString() + "," + DateTime.Now.ToString());
                                    tw.Close();
                                }


                                gridControl1.Update();
                            }

                            else if (variables.numP == 17) // for mmh2o
                            {
                                double kelvinS = 273.15;
                                double kelvin = (temp + kelvinS);
                                variables.records.Rows.Add(productNumber, kelvin, pressure / 0.0980665, DateTime.Now);

                                using (var tw = new StreamWriter(path, true))
                                {
                                    if (!firstrecord)
                                    {
                                        tw.WriteLine(productNumber + "," + "Sıcaklık" + "," + "Basınç" + "," + "Tarih");
                                        firstrecord = true;
                                    }

                                    gridControl1.FirstDisplayedScrollingRowIndex = gridControl1.RowCount - 1;
                                    tw.WriteLine(productNumber + kelvin.ToString() + "," + (pressure / 0.0980665).ToString() + "," + variables.Density.ToString() + "," + DateTime.Now.ToString());
                                    tw.Close();
                                }


                                gridControl1.Update();
                            }

                            else if (variables.numP == 18) // for mh2o
                            {
                                double kelvinS = 273.15;
                                double kelvin = (temp + kelvinS);
                                variables.records.Rows.Add(productNumber, kelvin, pressure / 98.0665, DateTime.Now);

                                using (var tw = new StreamWriter(path, true))
                                {
                                    if (!firstrecord)
                                    {
                                        tw.WriteLine(productNumber + "," + "Sıcaklık" + "," + "Basınç" + "," + "Tarih");
                                        firstrecord = true;
                                    }

                                    gridControl1.FirstDisplayedScrollingRowIndex = gridControl1.RowCount - 1;
                                    tw.WriteLine(productNumber + kelvin.ToString() + "," + (pressure / 98.0665).ToString() + "," + variables.Density.ToString() + "," + DateTime.Now.ToString());
                                    tw.Close();
                                }


                                gridControl1.Update();
                            }

                            else if (variables.numP == 19) // for mmHg
                            {
                                double kelvinS = 273.15;
                                double kelvin = (temp + kelvinS);
                                variables.records.Rows.Add(productNumber, kelvin, pressure * 0.750062, DateTime.Now);

                                using (var tw = new StreamWriter(path, true))
                                {
                                    if (!firstrecord)
                                    {
                                        tw.WriteLine(productNumber + "," + "Sıcaklık" + "," + "Basınç" + "," + "Tarih");
                                        firstrecord = true;
                                    }

                                    gridControl1.FirstDisplayedScrollingRowIndex = gridControl1.RowCount - 1;
                                    tw.WriteLine(productNumber + kelvin.ToString() + "," + (pressure * 0.750062).ToString() + "," + variables.Density.ToString() + "," + DateTime.Now.ToString());
                                    tw.Close();
                                }


                                gridControl1.Update();
                            }

                            else if (variables.numP == 20) // for psi
                            {
                                double kelvinS = 273.15;
                                double kelvin = (temp + kelvinS);
                                variables.records.Rows.Add(productNumber, kelvin, pressure * 0.0145037738, DateTime.Now);

                                using (var tw = new StreamWriter(path, true))
                                {
                                    if (!firstrecord)
                                    {
                                        tw.WriteLine(productNumber + "," + "Sıcaklık" + "," + "Basınç" + "," + "Tarih");
                                        firstrecord = true;
                                    }

                                    gridControl1.FirstDisplayedScrollingRowIndex = gridControl1.RowCount - 1;
                                    tw.WriteLine(productNumber + kelvin.ToString() + "," + (pressure * 0.0145037738).ToString() + "," + variables.Density.ToString() + "," + DateTime.Now.ToString());
                                    tw.Close();
                                }


                                gridControl1.Update();
                            }

                            else if (variables.numP == 21) // for kPa
                            {
                                double kelvinS = 273.15;
                                double kelvin = (temp + kelvinS);
                                variables.records.Rows.Add(productNumber, kelvin, pressure /10, DateTime.Now);

                                using (var tw = new StreamWriter(path, true))
                                {
                                    if (!firstrecord)
                                    {
                                        tw.WriteLine(productNumber + "," + "Sıcaklık" + "," + "Basınç" + "," + "Tarih");
                                        firstrecord = true;
                                    }

                                    gridControl1.FirstDisplayedScrollingRowIndex = gridControl1.RowCount - 1;
                                    tw.WriteLine(productNumber + kelvin.ToString() + "," + (pressure /10).ToString() + "," + variables.Density.ToString() + "," + DateTime.Now.ToString());
                                    tw.Close();
                                }


                                gridControl1.Update();
                            }

                            else if (variables.numP == 22) // for MPa
                            {
                                double kelvinS = 273.15;
                                double kelvin = (temp + kelvinS);
                                variables.records.Rows.Add(productNumber, kelvin, pressure /10000, DateTime.Now);

                                using (var tw = new StreamWriter(path, true))
                                {
                                    if (!firstrecord)
                                    {
                                        tw.WriteLine(productNumber + "," + "Sıcaklık" + "," + "Basınç" + "," + "Tarih");
                                        firstrecord = true;
                                    }

                                    gridControl1.FirstDisplayedScrollingRowIndex = gridControl1.RowCount - 1;
                                    tw.WriteLine(productNumber + kelvin.ToString() + "," + (pressure / 10000).ToString() + "," + variables.Density.ToString() + "," + DateTime.Now.ToString());
                                    tw.Close();
                                }


                                gridControl1.Update();
                            }
                            else if (variables.numP == 23) // for iwg
                            {
                                double kelvinS = 273.15;
                                double kelvin = (temp + kelvinS);
                                variables.records.Rows.Add(productNumber, kelvin, pressure / 2.490889, DateTime.Now);

                                using (var tw = new StreamWriter(path, true))
                                {
                                    if (!firstrecord)
                                    {
                                        tw.WriteLine(productNumber + "," + "Sıcaklık" + "," + "Basınç" + "," + "Tarih");
                                        firstrecord = true;
                                    }

                                    gridControl1.FirstDisplayedScrollingRowIndex = gridControl1.RowCount - 1;
                                    tw.WriteLine(productNumber + kelvin.ToString() + "," + (pressure / 2.490889).ToString() + "," + variables.Density.ToString() + "," + DateTime.Now.ToString());
                                    tw.Close();
                                }


                                gridControl1.Update();
                            }

                            else if (variables.numP == 2) // for mbar
                            {
                                double kelvinS = 273.15;
                                double kelvin = (temp + kelvinS);
                                variables.records.Rows.Add(productNumber, kelvin, pressure, DateTime.Now);

                                using (var tw = new StreamWriter(path, true))
                                {
                                    if (!firstrecord)
                                    {
                                        tw.WriteLine(productNumber + "," + "Sıcaklık" + "," + "Basınç" + "," + "Tarih");
                                        firstrecord = true;
                                    }

                                    gridControl1.FirstDisplayedScrollingRowIndex = gridControl1.RowCount - 1;
                                    tw.WriteLine(productNumber + kelvin.ToString() + "," + pressure.ToString() + "," + variables.Density.ToString() + "," + DateTime.Now.ToString());
                                    tw.Close();
                                }


                                gridControl1.Update();
                            }



                        }
                        else if (variables.numT == 13) // for Fahrenheit
                        {
                            /*double fahrenheit = ((temp * 18) + 32);
                            variables.records.Rows.Add(productNumber, fahrenheit, pressure, DateTime.Now);

                            using (var tw = new StreamWriter(path, true))
                            {
                                if (!firstrecord)
                                {
                                    tw.WriteLine(productNumber + "," + "Temperature" + "," + "Pressure" + "," + "Date");
                                    firstrecord = true;
                                }
                                
                                tw.WriteLine(productNumber + fahrenheit.ToString() + "," + pressure.ToString() + "," + variables.Density.ToString() + "," + DateTime.Now.ToString());
                                tw.Close();
                            }


                            gridControl1.Update();*/

                            if (variables.numP == 14) // for Bar
                            {
                                double fahrenheit = ((temp * 1.8) + 32);
                                variables.records.Rows.Add(productNumber, fahrenheit, pressure / 1000, DateTime.Now);

                                using (var tw = new StreamWriter(path, true))
                                {
                                    if (!firstrecord)
                                    {
                                        tw.WriteLine(productNumber + "," + "Sıcaklık" + "," + "Basınç" + "," + "Tarih");
                                        firstrecord = true;
                                    }

                                    gridControl1.FirstDisplayedScrollingRowIndex = gridControl1.RowCount - 1;
                                    tw.WriteLine(productNumber + fahrenheit.ToString() + "," + (pressure / 1000).ToString() + "," + variables.Density.ToString() + "," + DateTime.Now.ToString());
                                    tw.Close();
                                }


                                gridControl1.Update();
                            }

                            else if (variables.numP == 15) // for Pa
                            {
                                double fahrenheit = ((temp * 1.8) + 32);
                                variables.records.Rows.Add(productNumber, fahrenheit, pressure * 100, DateTime.Now);

                                using (var tw = new StreamWriter(path, true))
                                {
                                    if (!firstrecord)
                                    {
                                        tw.WriteLine(productNumber + "," + "Sıcaklık" + "," + "Basınç" + "," + "Tarih");
                                        firstrecord = true;
                                    }
                                    gridControl1.FirstDisplayedScrollingRowIndex = gridControl1.RowCount - 1;

                                    tw.WriteLine(productNumber + fahrenheit.ToString() + "," + (pressure * 100).ToString() + "," + variables.Density.ToString() + "," + DateTime.Now.ToString());
                                    tw.Close();
                                }


                                gridControl1.Update();
                            }

                            else if (variables.numP == 16) // for kg/cm2
                            {
                                double fahrenheit = ((temp * 1.8) + 32);
                                variables.records.Rows.Add(productNumber, fahrenheit, pressure * 0.00102, DateTime.Now);

                                using (var tw = new StreamWriter(path, true))
                                {
                                    if (!firstrecord)
                                    {
                                        tw.WriteLine(productNumber + "," + "Sıcaklık" + "," + "Basınç" + "," + "Tarih");
                                        firstrecord = true;
                                    }

                                    gridControl1.FirstDisplayedScrollingRowIndex = gridControl1.RowCount - 1;
                                    tw.WriteLine(productNumber + fahrenheit.ToString() + "," + (pressure * 0.00102).ToString() + "," + variables.Density.ToString() + "," + DateTime.Now.ToString());
                                    tw.Close();
                                }


                                gridControl1.Update();
                            }

                            else if (variables.numP == 17) // for mmh2o
                            {
                                double fahrenheit = ((temp * 1.8) + 32);
                                variables.records.Rows.Add(productNumber, fahrenheit, pressure / 0.0980665, DateTime.Now);

                                using (var tw = new StreamWriter(path, true))
                                {
                                    if (!firstrecord)
                                    {
                                        tw.WriteLine(productNumber + "," + "Sıcaklık" + "," + "Basınç" + "," + "Tarih");
                                        firstrecord = true;
                                    }

                                    gridControl1.FirstDisplayedScrollingRowIndex = gridControl1.RowCount - 1;
                                    tw.WriteLine(productNumber + fahrenheit.ToString() + "," + (pressure / 0.0980665).ToString() + "," + variables.Density.ToString() + "," + DateTime.Now.ToString());
                                    tw.Close();
                                }


                                gridControl1.Update();
                            }

                            else if (variables.numP == 18) // for mh2o
                            {
                                double fahrenheit = ((temp * 1.8) + 32);
                                variables.records.Rows.Add(productNumber, fahrenheit, pressure / 98.0665, DateTime.Now);

                                using (var tw = new StreamWriter(path, true))
                                {
                                    if (!firstrecord)
                                    {
                                        tw.WriteLine(productNumber + "," + "Sıcaklık" + "," + "Basınç" + "," + "Tarih");
                                        firstrecord = true;
                                    }

                                    gridControl1.FirstDisplayedScrollingRowIndex = gridControl1.RowCount - 1;
                                    tw.WriteLine(productNumber + fahrenheit.ToString() + "," + (pressure / 98.0665).ToString() + "," + variables.Density.ToString() + "," + DateTime.Now.ToString());
                                    tw.Close();
                                }


                                gridControl1.Update();
                            }

                            else if (variables.numP == 19) // for mmHg
                            {
                                double fahrenheit = ((temp * 1.8) + 32);
                                variables.records.Rows.Add(productNumber, fahrenheit, pressure * 0.750062, DateTime.Now);

                                using (var tw = new StreamWriter(path, true))
                                {
                                    if (!firstrecord)
                                    {
                                        tw.WriteLine(productNumber + "," + "Sıcaklık" + "," + "Basınç" + "," + "Tarih");
                                        firstrecord = true;
                                    }

                                    gridControl1.FirstDisplayedScrollingRowIndex = gridControl1.RowCount - 1;
                                    tw.WriteLine(productNumber + fahrenheit.ToString() + "," + (pressure * 0.750062).ToString() + "," + variables.Density.ToString() + "," + DateTime.Now.ToString());
                                    tw.Close();
                                }


                                gridControl1.Update();
                            }

                            else if (variables.numP == 20) // for psi
                            {
                                double fahrenheit = ((temp * 1.8) + 32);
                                variables.records.Rows.Add(productNumber, fahrenheit, pressure * 0.0145037738, DateTime.Now);

                                using (var tw = new StreamWriter(path, true))
                                {
                                    if (!firstrecord)
                                    {
                                        tw.WriteLine(productNumber + "," + "Sıcaklık" + "," + "Basınç" + "," + "Tarih");
                                        firstrecord = true;
                                    }

                                    gridControl1.FirstDisplayedScrollingRowIndex = gridControl1.RowCount - 1;
                                    tw.WriteLine(productNumber + fahrenheit.ToString() + "," + (pressure * 0.0145037738).ToString() + "," + variables.Density.ToString() + "," + DateTime.Now.ToString());
                                    tw.Close();
                                }


                                gridControl1.Update();
                            }

                            else if (variables.numP == 21) // for kPa
                            {
                                double fahrenheit = ((temp * 1.8) + 32);
                                variables.records.Rows.Add(productNumber, fahrenheit, pressure / 10, DateTime.Now);

                                using (var tw = new StreamWriter(path, true))
                                {
                                    if (!firstrecord)
                                    {
                                        tw.WriteLine(productNumber + "," + "Sıcaklık" + "," + "Basınç" + "," + "Tarih");
                                        firstrecord = true;
                                    }

                                    gridControl1.FirstDisplayedScrollingRowIndex = gridControl1.RowCount - 1;
                                    tw.WriteLine(productNumber + fahrenheit.ToString() + "," + (pressure / 10).ToString() + "," + variables.Density.ToString() + "," + DateTime.Now.ToString());
                                    tw.Close();
                                }


                                gridControl1.Update();
                            }

                            else if (variables.numP == 22) // for MPa
                            {
                                double fahrenheit = ((temp * 1.8) + 32);
                                variables.records.Rows.Add(productNumber, fahrenheit, pressure / 10000, DateTime.Now);

                                using (var tw = new StreamWriter(path, true))
                                {
                                    if (!firstrecord)
                                    {
                                        tw.WriteLine(productNumber + "," + "Sıcaklık" + "," + "Basınç" + "," + "Tarih");
                                        firstrecord = true;
                                    }

                                    gridControl1.FirstDisplayedScrollingRowIndex = gridControl1.RowCount - 1;
                                    tw.WriteLine(productNumber + fahrenheit.ToString() + "," + (pressure / 10000).ToString() + "," + variables.Density.ToString() + "," + DateTime.Now.ToString());
                                    tw.Close();
                                }


                                gridControl1.Update();
                            }
                            else if (variables.numP == 23) // for iwg
                            {
                                double fahrenheit = ((temp * 1.8) + 32);
                                variables.records.Rows.Add(productNumber, fahrenheit, pressure / 2.490889, DateTime.Now);

                                using (var tw = new StreamWriter(path, true))
                                {
                                    if (!firstrecord)
                                    {
                                        tw.WriteLine(productNumber + "," + "Sıcaklık" + "," + "Basınç" + "," + "Tarih");
                                        firstrecord = true;
                                    }
                                    gridControl1.FirstDisplayedScrollingRowIndex = gridControl1.RowCount - 1;

                                    tw.WriteLine(productNumber + fahrenheit.ToString() + "," + (pressure / 2.490889).ToString() + "," + variables.Density.ToString() + "," + DateTime.Now.ToString());
                                    tw.Close();
                                }


                                gridControl1.Update();
                            }

                            else if (variables.numP == 2) // for mbar
                            {
                                double fahrenheit = ((temp * 1.8) + 32);
                                variables.records.Rows.Add(productNumber, fahrenheit, pressure, DateTime.Now);

                                using (var tw = new StreamWriter(path, true))
                                {
                                    if (!firstrecord)
                                    {
                                        tw.WriteLine(productNumber + "," + "Sıcaklık" + "," + "Basınç" + "," + "Tarih");
                                        firstrecord = true;
                                    }

                                    gridControl1.FirstDisplayedScrollingRowIndex = gridControl1.RowCount - 1;
                                    tw.WriteLine(productNumber + fahrenheit.ToString() + "," + pressure.ToString() + "," + variables.Density.ToString() + "," + DateTime.Now.ToString());
                                    tw.Close();
                                }


                                gridControl1.Update();
                            }
                        }
                        else if (variables.numT == 1) // for Celcius
                        {


                            if (variables.numP == 14) // for Bar
                            {

                                variables.records.Rows.Add(productNumber, temp, pressure / 1000, DateTime.Now);

                                using (var tw = new StreamWriter(path, true))
                                {
                                    if (!firstrecord)
                                    {
                                        tw.WriteLine(productNumber + "," + "Sıcaklık" + "," + "Basınç" + "," + "Tarih");
                                        firstrecord = true;
                                    }
                                    gridControl1.FirstDisplayedScrollingRowIndex = gridControl1.RowCount - 1;

                                    tw.WriteLine(productNumber + temp.ToString() + "," + (pressure / 1000).ToString() + "," + variables.Density.ToString() + "," + DateTime.Now.ToString());
                                    tw.Close();
                                }


                                gridControl1.Update();
                            }

                            else if (variables.numP == 15) // for Pa
                            {

                                variables.records.Rows.Add(productNumber, temp, pressure * 100, DateTime.Now);

                                using (var tw = new StreamWriter(path, true))
                                {
                                    if (!firstrecord)
                                    {
                                        tw.WriteLine(productNumber + "," + "Sıcaklık" + "," + "Basınç" + "," + "Tarih");
                                        firstrecord = true;
                                    }

                                    gridControl1.FirstDisplayedScrollingRowIndex = gridControl1.RowCount - 1;
                                    tw.WriteLine(productNumber + temp.ToString() + "," + (pressure * 100).ToString() + "," + variables.Density.ToString() + "," + DateTime.Now.ToString());
                                    tw.Close();
                                }


                                gridControl1.Update();
                            }

                            else if (variables.numP == 16) // for kg/cm2
                            {

                                variables.records.Rows.Add(productNumber, temp, pressure * 0.00102, DateTime.Now);

                                using (var tw = new StreamWriter(path, true))
                                {
                                    if (!firstrecord)
                                    {
                                        tw.WriteLine(productNumber + "," + "Sıcaklık" + "," + "Basınç" + "," + "Tarih");
                                        firstrecord = true;
                                    }

                                    gridControl1.FirstDisplayedScrollingRowIndex = gridControl1.RowCount - 1;
                                    tw.WriteLine(productNumber + temp.ToString() + "," + (pressure * 0.00102).ToString() + "," + variables.Density.ToString() + "," + DateTime.Now.ToString());
                                    tw.Close();
                                }


                                gridControl1.Update();
                            }

                            else if (variables.numP == 17) // for mmh2o
                            {

                                variables.records.Rows.Add(productNumber, temp, pressure / 0.0980665, DateTime.Now);

                                using (var tw = new StreamWriter(path, true))
                                {
                                    if (!firstrecord)
                                    {
                                        tw.WriteLine(productNumber + "," + "Sıcaklık" + "," + "Basınç" + "," + "Tarih");
                                        firstrecord = true;
                                    }

                                    gridControl1.FirstDisplayedScrollingRowIndex = gridControl1.RowCount - 1;
                                    tw.WriteLine(productNumber + temp.ToString() + "," + (pressure / 0.0980665).ToString() + "," + variables.Density.ToString() + "," + DateTime.Now.ToString());
                                    tw.Close();
                                }


                                gridControl1.Update();
                            }

                            else if (variables.numP == 18) // for mh2o
                            {

                                variables.records.Rows.Add(productNumber, temp, pressure / 98.0665, DateTime.Now);

                                using (var tw = new StreamWriter(path, true))
                                {
                                    if (!firstrecord)
                                    {
                                        tw.WriteLine(productNumber + "," + "Sıcaklık" + "," + "Basınç" + "," + "Tarih");
                                        firstrecord = true;
                                    }

                                    gridControl1.FirstDisplayedScrollingRowIndex = gridControl1.RowCount - 1;
                                    tw.WriteLine(productNumber + temp.ToString() + "," + (pressure / 98.0665).ToString() + "," + variables.Density.ToString() + "," + DateTime.Now.ToString());
                                    tw.Close();
                                }


                                gridControl1.Update();
                            }

                            else if (variables.numP == 19) // for mmHg
                            {

                                variables.records.Rows.Add(productNumber, temp, pressure * 0.750062, DateTime.Now);

                                using (var tw = new StreamWriter(path, true))
                                {
                                    if (!firstrecord)
                                    {
                                        tw.WriteLine(productNumber + "," + "Sıcaklık" + "," + "Basınç" + "," + "Tarih");
                                        firstrecord = true;
                                    }

                                    gridControl1.FirstDisplayedScrollingRowIndex = gridControl1.RowCount - 1;
                                    tw.WriteLine(productNumber + temp.ToString() + "," + (pressure * 0.750062).ToString() + "," + variables.Density.ToString() + "," + DateTime.Now.ToString());
                                    tw.Close();
                                }


                                gridControl1.Update();
                            }

                            else if (variables.numP == 20) // for psi
                            {

                                variables.records.Rows.Add(productNumber, temp, pressure * 0.0145037738, DateTime.Now);

                                using (var tw = new StreamWriter(path, true))
                                {
                                    if (!firstrecord)
                                    {
                                        tw.WriteLine(productNumber + "," + "Sıcaklık" + "," + "Basınç" + "," + "Tarih");
                                        firstrecord = true;
                                    }

                                    gridControl1.FirstDisplayedScrollingRowIndex = gridControl1.RowCount - 1;
                                    tw.WriteLine(productNumber + temp.ToString() + "," + (pressure * 0.0145037738).ToString() + "," + variables.Density.ToString() + "," + DateTime.Now.ToString());
                                    tw.Close();
                                }


                                gridControl1.Update();
                            }

                            else if (variables.numP == 21) // for kPa
                            {

                                variables.records.Rows.Add(productNumber, temp, pressure / 10, DateTime.Now);

                                using (var tw = new StreamWriter(path, true))
                                {
                                    if (!firstrecord)
                                    {
                                        tw.WriteLine(productNumber + "," + "Sıcaklık" + "," + "Basınç" + "," + "Tarih");
                                        firstrecord = true;
                                    }

                                    gridControl1.FirstDisplayedScrollingRowIndex = gridControl1.RowCount - 1;
                                    tw.WriteLine(productNumber + temp.ToString() + "," + (pressure / 10).ToString() + "," + variables.Density.ToString() + "," + DateTime.Now.ToString());
                                    tw.Close();
                                }


                                gridControl1.Update();
                            }

                            else if (variables.numP == 22) // for MPa
                            {

                                variables.records.Rows.Add(productNumber, temp, pressure / 10000, DateTime.Now);

                                using (var tw = new StreamWriter(path, true))
                                {
                                    if (!firstrecord)
                                    {
                                        tw.WriteLine(productNumber + "," + "Sıcaklık" + "," + "Basınç" + "," + "Tarih");
                                        firstrecord = true;
                                    }
                                    gridControl1.FirstDisplayedScrollingRowIndex = gridControl1.RowCount - 1;

                                    tw.WriteLine(productNumber + temp.ToString() + "," + (pressure / 10000).ToString() + "," + variables.Density.ToString() + "," + DateTime.Now.ToString());
                                    tw.Close();
                                }


                                gridControl1.Update();
                            }

                            else if (variables.numP == 23) // for iwg
                            {

                                variables.records.Rows.Add(productNumber, temp, pressure / 2.490889, DateTime.Now);

                                using (var tw = new StreamWriter(path, true))
                                {
                                    if (!firstrecord)
                                    {
                                        tw.WriteLine(productNumber + "," + "Sıcaklık" + "," + "Basınç" + "," + "Tarih");
                                        firstrecord = true;
                                    }
                                    gridControl1.FirstDisplayedScrollingRowIndex = gridControl1.RowCount - 1;

                                    tw.WriteLine(productNumber + temp.ToString() + "," + (pressure / 2.490889).ToString() + "," + variables.Density.ToString() + "," + DateTime.Now.ToString());
                                    tw.Close();
                                }


                                gridControl1.Update();
                            }

                            else if (variables.numP == 2) // for mbar
                            {

                                variables.records.Rows.Add(productNumber, temp, pressure, DateTime.Now);

                                using (var tw = new StreamWriter(path, true))
                                {
                                    if (!firstrecord)
                                    {
                                        tw.WriteLine(productNumber + "," + "Sıcaklık" + "," + "Basınç" + "," + "Tarih");
                                        firstrecord = true;
                                    }
                                    gridControl1.FirstDisplayedScrollingRowIndex = gridControl1.RowCount - 1;

                                    tw.WriteLine(productNumber + temp.ToString() + "," + pressure.ToString() + "," + variables.Density.ToString() + "," + DateTime.Now.ToString());
                                    tw.Close();
                                }


                                gridControl1.Update();
                            }
                        }

                    }



                }

                else if(variables.numEN ==10)// for ENG // "mBar", "Bar","Pa", "kg/s2","mmh2o","mh2o","mmHg","psi","kPa","MPa"
                {
                    if (variables.recordstate == true)
                    {
                        if (variables.numT == 12) // for Kelvin
                        {
                            if (variables.numP == 14) // for Bar
                            {
                                double kelvinS = 273.15;
                                double kelvin = (temp + kelvinS);
                                variables.records.Rows.Add(productNumber, kelvin, pressure / 1000, DateTime.Now);
                                using (var tw = new StreamWriter(path, true))
                                {
                                    if (!firstrecord)
                                    {
                                        tw.WriteLine(productNumber + "," + "Temperature" + "," + "Pressure" + "," + "Date");
                                        firstrecord = true;
                                    }

                                    gridControl1.FirstDisplayedScrollingRowIndex = gridControl1.RowCount - 1;
                                    tw.WriteLine(productNumber + kelvin.ToString() + "," + (pressure / 1000).ToString() + "," + variables.Density.ToString() + "," + DateTime.Now.ToString());
                                    tw.Close();
                                }


                                gridControl1.Update();
                            }

                            else if (variables.numP == 15) // for Pa
                            {
                                double kelvinS = 273.15;
                                double kelvin = (temp + kelvinS);
                                variables.records.Rows.Add(productNumber, kelvin, pressure * 100, DateTime.Now);

                                using (var tw = new StreamWriter(path, true))
                                {
                                    if (!firstrecord)
                                    {
                                        tw.WriteLine(productNumber + "," + "Temperature" + "," + "Pressure" + "," + "Date");
                                        firstrecord = true;
                                    }

                                    gridControl1.FirstDisplayedScrollingRowIndex = gridControl1.RowCount - 1;
                                    tw.WriteLine(productNumber + kelvin.ToString() + "," + (pressure * 100).ToString() + "," + variables.Density.ToString() + "," + DateTime.Now.ToString());
                                    tw.Close();
                                }


                                gridControl1.Update();
                            }

                            else if (variables.numP == 16) // for kg/cm2
                            {
                                double kelvinS = 273.15;
                                double kelvin = (temp + kelvinS);
                                variables.records.Rows.Add(productNumber, kelvin, pressure * 0.00102, DateTime.Now);

                                using (var tw = new StreamWriter(path, true))
                                {
                                    if (!firstrecord)
                                    {
                                        tw.WriteLine(productNumber + "," + "Temperature" + "," + "Pressure" + "," + "Date");
                                        firstrecord = true;
                                    }

                                    gridControl1.FirstDisplayedScrollingRowIndex = gridControl1.RowCount - 1;
                                    tw.WriteLine(productNumber + kelvin.ToString() + "," + (pressure * 0.00102).ToString() + "," + variables.Density.ToString() + "," + DateTime.Now.ToString());
                                    tw.Close();
                                }


                                gridControl1.Update();
                            }

                            else if (variables.numP == 17) // for mmh2o
                            {
                                double kelvinS = 273.15;
                                double kelvin = (temp + kelvinS);
                                variables.records.Rows.Add(productNumber, kelvin, pressure / 0.0980665, DateTime.Now);

                                using (var tw = new StreamWriter(path, true))
                                {
                                    if (!firstrecord)
                                    {
                                        tw.WriteLine(productNumber + "," + "Temperature" + "," + "Pressure" + "," + "Date");
                                        firstrecord = true;
                                    }

                                    gridControl1.FirstDisplayedScrollingRowIndex = gridControl1.RowCount - 1;
                                    tw.WriteLine(productNumber + kelvin.ToString() + "," + (pressure / 0.0980665).ToString() + "," + variables.Density.ToString() + "," + DateTime.Now.ToString());
                                    tw.Close();
                                }


                                gridControl1.Update();
                            }

                            else if (variables.numP == 18) // for mh2o
                            {
                                double kelvinS = 273.15;
                                double kelvin = (temp + kelvinS);
                                variables.records.Rows.Add(productNumber, kelvin, pressure / 98.0665, DateTime.Now);

                                using (var tw = new StreamWriter(path, true))
                                {
                                    if (!firstrecord)
                                    {
                                        tw.WriteLine(productNumber + "," + "Temperature" + "," + "Pressure" + "," + "Date");
                                        firstrecord = true;
                                    }

                                    gridControl1.FirstDisplayedScrollingRowIndex = gridControl1.RowCount - 1;
                                    tw.WriteLine(productNumber + kelvin.ToString() + "," + (pressure / 98.0665).ToString() + "," + variables.Density.ToString() + "," + DateTime.Now.ToString());
                                    tw.Close();
                                }


                                gridControl1.Update();
                            }

                            else if (variables.numP == 19) // for mmHg
                            {
                                double kelvinS = 273.15;
                                double kelvin = (temp + kelvinS);
                                variables.records.Rows.Add(productNumber, kelvin, pressure * 0.750062, DateTime.Now);

                                using (var tw = new StreamWriter(path, true))
                                {
                                    if (!firstrecord)
                                    {
                                        tw.WriteLine(productNumber + "," + "Temperature" + "," + "Pressure" + "," + "Date");
                                        firstrecord = true;
                                    }

                                    gridControl1.FirstDisplayedScrollingRowIndex = gridControl1.RowCount - 1;
                                    tw.WriteLine(productNumber + kelvin.ToString() + "," + (pressure * 0.750062).ToString() + "," + variables.Density.ToString() + "," + DateTime.Now.ToString());
                                    tw.Close();
                                }


                                gridControl1.Update();
                            }

                            else if (variables.numP == 20) // for psi
                            {
                                double kelvinS = 273.15;
                                double kelvin = (temp + kelvinS);
                                variables.records.Rows.Add(productNumber, kelvin, pressure * 0.0145037738, DateTime.Now);

                                using (var tw = new StreamWriter(path, true))
                                {
                                    if (!firstrecord)
                                    {
                                        tw.WriteLine(productNumber + "," + "Temperature" + "," + "Pressure" + "," + "Date");
                                        firstrecord = true;
                                    }

                                    gridControl1.FirstDisplayedScrollingRowIndex = gridControl1.RowCount - 1;
                                    tw.WriteLine(productNumber + kelvin.ToString() + "," + (pressure * 0.0145037738).ToString() + "," + variables.Density.ToString() + "," + DateTime.Now.ToString());
                                    tw.Close();
                                }


                                gridControl1.Update();
                            }

                            else if (variables.numP == 21) // for kPa
                            {
                                double kelvinS = 273.15;
                                double kelvin = (temp + kelvinS);
                                variables.records.Rows.Add(productNumber, kelvin, pressure / 10, DateTime.Now);

                                using (var tw = new StreamWriter(path, true))
                                {
                                    if (!firstrecord)
                                    {
                                        tw.WriteLine(productNumber + "," + "Temperature" + "," + "Pressure" + "," + "Date");
                                        firstrecord = true;
                                    }

                                    gridControl1.FirstDisplayedScrollingRowIndex = gridControl1.RowCount - 1;
                                    tw.WriteLine(productNumber + kelvin.ToString() + "," + (pressure / 10).ToString() + "," + variables.Density.ToString() + "," + DateTime.Now.ToString());
                                    tw.Close();
                                }


                                gridControl1.Update();
                            }

                            else if (variables.numP == 22) // for MPa
                            {
                                double kelvinS = 273.15;
                                double kelvin = (temp + kelvinS);
                                variables.records.Rows.Add(productNumber, kelvin, pressure / 10000, DateTime.Now);

                                using (var tw = new StreamWriter(path, true))
                                {
                                    if (!firstrecord)
                                    {
                                        tw.WriteLine(productNumber + "," + "Temperature" + "," + "Pressure" + "," + "Date");
                                        firstrecord = true;
                                    }
                                    gridControl1.FirstDisplayedScrollingRowIndex = gridControl1.RowCount - 1;
                                    tw.WriteLine(productNumber + kelvin.ToString() + "," + (pressure / 10000).ToString() + "," + variables.Density.ToString() + "," + DateTime.Now.ToString());
                                    tw.Close();
                                }


                                gridControl1.Update();
                            }

                            else if (variables.numP == 23) // for iwg
                            {
                                double kelvinS = 273.15;
                                double kelvin = (temp + kelvinS);
                                variables.records.Rows.Add(productNumber, kelvin, pressure / 2.490889, DateTime.Now);

                                using (var tw = new StreamWriter(path, true))
                                {
                                    if (!firstrecord)
                                    {
                                        tw.WriteLine(productNumber + "," + "Temperature" + "," + "Pressure" + "," + "Date");
                                        firstrecord = true;
                                    }
                                    gridControl1.FirstDisplayedScrollingRowIndex = gridControl1.RowCount - 1;
                                    tw.WriteLine(productNumber + kelvin.ToString() + "," + (pressure / 2.490889).ToString() + "," + variables.Density.ToString() + "," + DateTime.Now.ToString());
                                    tw.Close();
                                }


                                gridControl1.Update();
                            }

                            else if (variables.numP == 2) // for mbar
                            {
                                double kelvinS = 273.15;
                                double kelvin = (temp + kelvinS);
                                variables.records.Rows.Add(productNumber, kelvin, pressure, DateTime.Now);

                                using (var tw = new StreamWriter(path, true))
                                {
                                    if (!firstrecord)
                                    {
                                        tw.WriteLine(productNumber + "," + "Temperature" + "," + "Pressure" + "," + "Date");
                                        firstrecord = true;
                                    }

                                    gridControl1.FirstDisplayedScrollingRowIndex = gridControl1.RowCount - 1;
                                    tw.WriteLine(productNumber + kelvin.ToString() + "," + pressure.ToString() + "," + variables.Density.ToString() + "," + DateTime.Now.ToString());
                                    tw.Close();
                                }


                                gridControl1.Update();
                            }



                        }
                        else if (variables.numT == 13) // for Fahrenheit
                        {
                            /*double fahrenheit = ((temp * 18) + 32);
                            variables.records.Rows.Add(productNumber, fahrenheit, pressure, DateTime.Now);

                            using (var tw = new StreamWriter(path, true))
                            {
                                if (!firstrecord)
                                {
                                    tw.WriteLine(productNumber + "," + "Temperature" + "," + "Pressure" + "," + "Date");
                                    firstrecord = true;
                                }
                                
                                tw.WriteLine(productNumber + fahrenheit.ToString() + "," + pressure.ToString() + "," + variables.Density.ToString() + "," + DateTime.Now.ToString());
                                tw.Close();
                            }


                            gridControl1.Update();*/

                            if (variables.numP == 14) // for Bar
                            {
                                double fahrenheit = ((temp * 1.8) + 32);
                                variables.records.Rows.Add(productNumber, fahrenheit, pressure / 1000, DateTime.Now);

                                using (var tw = new StreamWriter(path, true))
                                {
                                    if (!firstrecord)
                                    {
                                        tw.WriteLine(productNumber + "," + "Temperature" + "," + "Pressure" + "," + "Date");
                                        firstrecord = true;
                                    }

                                    gridControl1.FirstDisplayedScrollingRowIndex = gridControl1.RowCount - 1;
                                    tw.WriteLine(productNumber + fahrenheit.ToString() + "," + (pressure / 1000).ToString() + "," + variables.Density.ToString() + "," + DateTime.Now.ToString());
                                    tw.Close();
                                }


                                gridControl1.Update();
                            }

                            else if (variables.numP == 15) // for Pa
                            {
                                double fahrenheit = ((temp * 1.8) + 32);
                                variables.records.Rows.Add(productNumber, fahrenheit, pressure * 100, DateTime.Now);

                                using (var tw = new StreamWriter(path, true))
                                {
                                    if (!firstrecord)
                                    {
                                        tw.WriteLine(productNumber + "," + "Temperature" + "," + "Pressure" + "," + "Date");
                                        firstrecord = true;
                                    }

                                    gridControl1.FirstDisplayedScrollingRowIndex = gridControl1.RowCount - 1;
                                    tw.WriteLine(productNumber + fahrenheit.ToString() + "," + (pressure * 100).ToString() + "," + variables.Density.ToString() + "," + DateTime.Now.ToString());
                                    tw.Close();
                                }


                                gridControl1.Update();
                            }

                            else if (variables.numP == 16) // for kg/cm2
                            {
                                double fahrenheit = ((temp * 1.8) + 32);
                                variables.records.Rows.Add(productNumber, fahrenheit, pressure * 0.00102, DateTime.Now);

                                using (var tw = new StreamWriter(path, true))
                                {
                                    if (!firstrecord)
                                    {
                                        tw.WriteLine(productNumber + "," + "Temperature" + "," + "Pressure" + "," + "Date");
                                        firstrecord = true;
                                    }

                                    gridControl1.FirstDisplayedScrollingRowIndex = gridControl1.RowCount - 1;
                                    tw.WriteLine(productNumber + fahrenheit.ToString() + "," + (pressure * 0.00102).ToString() + "," + variables.Density.ToString() + "," + DateTime.Now.ToString());
                                    tw.Close();
                                }


                                gridControl1.Update();
                            }

                            else if (variables.numP == 17) // for mmh2o
                            {
                                double fahrenheit = ((temp * 1.8) + 32);
                                variables.records.Rows.Add(productNumber, fahrenheit, pressure / 0.0980665, DateTime.Now);

                                using (var tw = new StreamWriter(path, true))
                                {
                                    if (!firstrecord)
                                    {
                                        tw.WriteLine(productNumber + "," + "Temperature" + "," + "Pressure" + "," + "Date");
                                        firstrecord = true;
                                    }

                                    gridControl1.FirstDisplayedScrollingRowIndex = gridControl1.RowCount - 1;
                                    tw.WriteLine(productNumber + fahrenheit.ToString() + "," + (pressure / 0.0980665).ToString() + "," + variables.Density.ToString() + "," + DateTime.Now.ToString());
                                    tw.Close();
                                }


                                gridControl1.Update();
                            }

                            else if (variables.numP == 18) // for mh2o
                            {
                                double fahrenheit = ((temp * 1.8) + 32);
                                variables.records.Rows.Add(productNumber, fahrenheit, pressure / 98.0665, DateTime.Now);

                                using (var tw = new StreamWriter(path, true))
                                {
                                    if (!firstrecord)
                                    {
                                        tw.WriteLine(productNumber + "," + "Temperature" + "," + "Pressure" + "," + "Date");
                                        firstrecord = true;
                                    }

                                    gridControl1.FirstDisplayedScrollingRowIndex = gridControl1.RowCount - 1;
                                    tw.WriteLine(productNumber + fahrenheit.ToString() + "," + (pressure * 98.0665).ToString() + "," + variables.Density.ToString() + "," + DateTime.Now.ToString());
                                    tw.Close();
                                }


                                gridControl1.Update();
                            }

                            else if (variables.numP == 19) // for mmHg
                            {
                                double fahrenheit = ((temp * 1.8) + 32);
                                variables.records.Rows.Add(productNumber, fahrenheit, pressure * 0.750062, DateTime.Now);

                                using (var tw = new StreamWriter(path, true))
                                {
                                    if (!firstrecord)
                                    {
                                        tw.WriteLine(productNumber + "," + "Temperature" + "," + "Pressure" + "," + "Date");
                                        firstrecord = true;
                                    }
                                    gridControl1.FirstDisplayedScrollingRowIndex = gridControl1.RowCount - 1;

                                    tw.WriteLine(productNumber + fahrenheit.ToString() + "," + (pressure * 0.750062).ToString() + "," + variables.Density.ToString() + "," + DateTime.Now.ToString());
                                    tw.Close();
                                }


                                gridControl1.Update();
                            }

                            else if (variables.numP == 20) // for psi
                            {
                                double fahrenheit = ((temp * 1.8) + 32);
                                variables.records.Rows.Add(productNumber, fahrenheit, pressure * 0.0145037738, DateTime.Now);

                                using (var tw = new StreamWriter(path, true))
                                {
                                    if (!firstrecord)
                                    {
                                        tw.WriteLine(productNumber + "," + "Temperature" + "," + "Pressure" + "," + "Date");
                                        firstrecord = true;
                                    }
                                    gridControl1.FirstDisplayedScrollingRowIndex = gridControl1.RowCount - 1;

                                    tw.WriteLine(productNumber + fahrenheit.ToString() + "," + (pressure * 0.0145037738).ToString() + "," + variables.Density.ToString() + "," + DateTime.Now.ToString());
                                    tw.Close();
                                }


                                gridControl1.Update();
                            }

                            else if (variables.numP == 21) // for kPa
                            {
                                double fahrenheit = ((temp * 1.8) + 32);
                                variables.records.Rows.Add(productNumber, fahrenheit, pressure / 10, DateTime.Now);

                                using (var tw = new StreamWriter(path, true))
                                {
                                    if (!firstrecord)
                                    {
                                        tw.WriteLine(productNumber + "," + "Temperature" + "," + "Pressure" + "," + "Date");
                                        firstrecord = true;
                                    }

                                    gridControl1.FirstDisplayedScrollingRowIndex = gridControl1.RowCount - 1;
                                    tw.WriteLine(productNumber + fahrenheit.ToString() + "," + (pressure / 10).ToString() + "," + variables.Density.ToString() + "," + DateTime.Now.ToString());
                                    tw.Close();
                                }


                                gridControl1.Update();
                            }

                            else if (variables.numP == 22) // for MPa
                            {
                                double fahrenheit = ((temp * 1.8) + 32);
                                variables.records.Rows.Add(productNumber, fahrenheit, pressure / 10000, DateTime.Now);

                                using (var tw = new StreamWriter(path, true))
                                {
                                    if (!firstrecord)
                                    {
                                        tw.WriteLine(productNumber + "," + "Temperature" + "," + "Pressure" + "," + "Date");
                                        firstrecord = true;
                                    }

                                    gridControl1.FirstDisplayedScrollingRowIndex = gridControl1.RowCount - 1;
                                    tw.WriteLine(productNumber + fahrenheit.ToString() + "," + (pressure / 10000).ToString() + "," + variables.Density.ToString() + "," + DateTime.Now.ToString());
                                    tw.Close();
                                }


                                gridControl1.Update();
                            }
                            else if (variables.numP == 23) // for iwg
                            {
                                double fahrenheit = ((temp * 1.8) + 32);
                                variables.records.Rows.Add(productNumber, fahrenheit, pressure / 2.490889, DateTime.Now);

                                using (var tw = new StreamWriter(path, true))
                                {
                                    if (!firstrecord)
                                    {
                                        tw.WriteLine(productNumber + "," + "Temperature" + "," + "Pressure" + "," + "Date");
                                        firstrecord = true;
                                    }

                                    gridControl1.FirstDisplayedScrollingRowIndex = gridControl1.RowCount - 1;
                                    tw.WriteLine(productNumber + fahrenheit.ToString() + "," + (pressure / 2.490889).ToString() + "," + variables.Density.ToString() + "," + DateTime.Now.ToString());
                                    tw.Close();
                                }


                                gridControl1.Update();
                            }

                            else if (variables.numP == 2) // for mbar
                            {
                                double fahrenheit = ((temp * 1.8) + 32);
                                variables.records.Rows.Add(productNumber, fahrenheit, pressure, DateTime.Now);

                                using (var tw = new StreamWriter(path, true))
                                {
                                    if (!firstrecord)
                                    {
                                        tw.WriteLine(productNumber + "," + "Temperature" + "," + "Pressure" + "," + "Date");
                                        firstrecord = true;
                                    }

                                    gridControl1.FirstDisplayedScrollingRowIndex = gridControl1.RowCount - 1;
                                    tw.WriteLine(productNumber + fahrenheit.ToString() + "," + pressure.ToString() + "," + variables.Density.ToString() + "," + DateTime.Now.ToString());
                                    tw.Close();
                                }


                                gridControl1.Update();
                            }
                        }
                        else if (variables.numT == 1) // for Celcius
                        {


                            if (variables.numP == 14) // for Bar
                            {

                                variables.records.Rows.Add(productNumber, temp, pressure / 1000, DateTime.Now);

                                using (var tw = new StreamWriter(path, true))
                                {
                                    if (!firstrecord)
                                    {
                                        tw.WriteLine(productNumber + "," + "Temperature" + "," + "Pressure" + "," + "Date");
                                        firstrecord = true;
                                    }

                                    gridControl1.FirstDisplayedScrollingRowIndex = gridControl1.RowCount - 1;
                                    tw.WriteLine(productNumber + temp.ToString() + "," + (pressure / 1000).ToString() + "," + variables.Density.ToString() + "," + DateTime.Now.ToString());
                                    tw.Close();
                                }


                                gridControl1.Update();
                            }

                            else if (variables.numP == 15) // for Pa
                            {

                                variables.records.Rows.Add(productNumber, temp, pressure * 100, DateTime.Now);

                                using (var tw = new StreamWriter(path, true))
                                {
                                    if (!firstrecord)
                                    {
                                        tw.WriteLine(productNumber + "," + "Temperature" + "," + "Pressure" + "," + "Date");
                                        firstrecord = true;
                                    }
                                    gridControl1.FirstDisplayedScrollingRowIndex = gridControl1.RowCount - 1;

                                    tw.WriteLine(productNumber + temp.ToString() + "," + (pressure * 100).ToString() + "," + variables.Density.ToString() + "," + DateTime.Now.ToString());
                                    tw.Close();
                                }


                                gridControl1.Update();
                            }

                            else if (variables.numP == 16) // for kg/cm2
                            {

                                variables.records.Rows.Add(productNumber, temp, pressure * 0.00102, DateTime.Now);

                                using (var tw = new StreamWriter(path, true))
                                {
                                    if (!firstrecord)
                                    {
                                        tw.WriteLine(productNumber + "," + "Temperature" + "," + "Pressure" + "," + "Date");
                                        firstrecord = true;
                                    }

                                    gridControl1.FirstDisplayedScrollingRowIndex = gridControl1.RowCount - 1;
                                    tw.WriteLine(productNumber + temp.ToString() + "," + (pressure * 0.00102).ToString() + "," + variables.Density.ToString() + "," + DateTime.Now.ToString());
                                    tw.Close();
                                }


                                gridControl1.Update();
                            }

                            else if (variables.numP == 17) // for mmh2o
                            {

                                variables.records.Rows.Add(productNumber, temp, pressure / 0.0980665, DateTime.Now);

                                using (var tw = new StreamWriter(path, true))
                                {
                                    if (!firstrecord)
                                    {
                                        tw.WriteLine(productNumber + "," + "Temperature" + "," + "Pressure" + "," + "Date");
                                        firstrecord = true;
                                    }
                                    gridControl1.FirstDisplayedScrollingRowIndex = gridControl1.RowCount - 1;

                                    tw.WriteLine(productNumber + temp.ToString() + "," + (pressure / 0.0980665).ToString() + "," + variables.Density.ToString() + "," + DateTime.Now.ToString());
                                    tw.Close();
                                }


                                gridControl1.Update();
                            }

                            else if (variables.numP == 18) // for mh2o
                            {

                                variables.records.Rows.Add(productNumber, temp, pressure / 98.0665, DateTime.Now);

                                using (var tw = new StreamWriter(path, true))
                                {
                                    if (!firstrecord)
                                    {
                                        tw.WriteLine(productNumber + "," + "Temperature" + "," + "Pressure" + "," + "Date");
                                        firstrecord = true;
                                    }

                                    gridControl1.FirstDisplayedScrollingRowIndex = gridControl1.RowCount - 1;
                                    tw.WriteLine(productNumber + temp.ToString() + "," + (pressure / 98.0665).ToString() + "," + variables.Density.ToString() + "," + DateTime.Now.ToString());
                                    tw.Close();
                                }


                                gridControl1.Update();
                            }

                            else if (variables.numP == 19) // for mmHg
                            {

                                variables.records.Rows.Add(productNumber, temp, pressure * 0.750062, DateTime.Now);

                                using (var tw = new StreamWriter(path, true))
                                {
                                    if (!firstrecord)
                                    {
                                        tw.WriteLine(productNumber + "," + "Temperature" + "," + "Pressure" + "," + "Date");
                                        firstrecord = true;
                                    }

                                    gridControl1.FirstDisplayedScrollingRowIndex = gridControl1.RowCount - 1;
                                    tw.WriteLine(productNumber + temp.ToString() + "," + (pressure * 0.750062).ToString() + "," + variables.Density.ToString() + "," + DateTime.Now.ToString());
                                    tw.Close();
                                }


                                gridControl1.Update();
                            }

                            else if (variables.numP == 20) // for psi
                            {

                                variables.records.Rows.Add(productNumber, temp, pressure * 0.0145037738, DateTime.Now);

                                using (var tw = new StreamWriter(path, true))
                                {
                                    if (!firstrecord)
                                    {
                                        tw.WriteLine(productNumber + "," + "Temperature" + "," + "Pressure" + "," + "Date");
                                        firstrecord = true;
                                    }

                                    gridControl1.FirstDisplayedScrollingRowIndex = gridControl1.RowCount - 1;
                                    tw.WriteLine(productNumber + temp.ToString() + "," + (pressure * 0.0145037738).ToString() + "," + variables.Density.ToString() + "," + DateTime.Now.ToString());
                                    tw.Close();
                                }


                                gridControl1.Update();
                            }

                            else if (variables.numP == 21) // for kPa
                            {

                                variables.records.Rows.Add(productNumber, temp, pressure / 10, DateTime.Now);

                                using (var tw = new StreamWriter(path, true))
                                {
                                    if (!firstrecord)
                                    {
                                        tw.WriteLine(productNumber + "," + "Temperature" + "," + "Pressure" + "," + "Date");
                                        firstrecord = true;
                                    }

                                    gridControl1.FirstDisplayedScrollingRowIndex = gridControl1.RowCount - 1;
                                    tw.WriteLine(productNumber + temp.ToString() + "," + (pressure / 10).ToString() + "," + variables.Density.ToString() + "," + DateTime.Now.ToString());
                                    tw.Close();
                                }


                                gridControl1.Update();
                            }

                            else if (variables.numP == 22) // for MPa
                            {

                                variables.records.Rows.Add(productNumber, temp, pressure / 10000, DateTime.Now);

                                using (var tw = new StreamWriter(path, true))
                                {
                                    if (!firstrecord)
                                    {
                                        tw.WriteLine(productNumber + "," + "Temperature" + "," + "Pressure" + "," + "Date");
                                        firstrecord = true;
                                    }

                                    gridControl1.FirstDisplayedScrollingRowIndex = gridControl1.RowCount - 1;
                                    tw.WriteLine(productNumber + temp.ToString() + "," + (pressure / 10000).ToString() + "," + variables.Density.ToString() + "," + DateTime.Now.ToString());
                                    tw.Close();
                                }


                                gridControl1.Update();
                            }

                            else if (variables.numP == 23) // for iwg
                            {

                                variables.records.Rows.Add(productNumber, temp, pressure / 2.490889, DateTime.Now);

                                using (var tw = new StreamWriter(path, true))
                                {
                                    if (!firstrecord)
                                    {
                                        tw.WriteLine(productNumber + "," + "Temperature" + "," + "Pressure" + "," + "Date");
                                        firstrecord = true;
                                    }

                                    gridControl1.FirstDisplayedScrollingRowIndex = gridControl1.RowCount - 1;
                                    tw.WriteLine(productNumber + temp.ToString() + "," + (pressure / 2.490889).ToString() + "," + variables.Density.ToString() + "," + DateTime.Now.ToString());
                                    tw.Close();
                                }


                                gridControl1.Update();
                            }

                            else if (variables.numP == 2) // for mbar
                            {

                                variables.records.Rows.Add(productNumber, temp, pressure, DateTime.Now);

                                using (var tw = new StreamWriter(path, true))
                                {
                                    if (!firstrecord)
                                    {
                                        tw.WriteLine(productNumber + "," + "Temperature" + "," + "Pressure" + "," + "Date");
                                        firstrecord = true;
                                    }

                                    gridControl1.FirstDisplayedScrollingRowIndex = gridControl1.RowCount - 1;
                                    tw.WriteLine(productNumber + temp.ToString() + "," + pressure.ToString() + "," + variables.Density.ToString() + "," + DateTime.Now.ToString());
                                    tw.Close();
                                }


                                gridControl1.Update();
                            }
                        }

                    }
                }
            }
        }

        private void exportButton_Click(object sender, EventArgs e)
        {

        }

        void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {

            string data_In = serialPort1.ReadTo("^");
            Data_TempPres(data_In);
            this.BeginInvoke(new EventHandler(Show_Data));

        }

        public void Data_TempPres(string data)
        {
            sbyte indexOf_startDataChar = (sbyte)data.IndexOf("@");
            sbyte indexOfX = (sbyte)data.IndexOf("X");
            sbyte indexOfY = (sbyte)data.IndexOf("Y");

            if (indexOf_startDataChar != -1 && indexOfY != -1 && indexOfX != -1)
            {
                try
                {
                    string str_temp = data.Substring(indexOf_startDataChar + 1, (indexOfX - indexOf_startDataChar) - 1);
                    string str_pressure = data.Substring(indexOfX + 1, (indexOfY - indexOfX) - 1);
                    temp = Convert.ToDouble(str_temp);
                    pressure = Convert.ToDouble(str_pressure);
                    updateData = true;

                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
            }

            else
            {
                updateData = false;
            }
        }

        private void FormFlow_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void exportButton_Click_1(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)// && variables.connection
            {
                if (variables.exportBut == false)
                {
                    if (variables.numEN == 11)
                    {
                        variables.recordstate = true;
                        MessageBox.Show("Kayıt Başladı ");
                        exportButton.Text = "Kaydı durdur";
                        saveDataButton.Enabled = true;
                        variables.exportBut = true;
                        timer2.Start();
                        //exportButton.Enabled = false;
                    }
                    else if (variables.numEN == 10)
                    {
                        variables.recordstate = true;
                        MessageBox.Show("Record Started");
                        saveDataButton.Enabled = true;
                        exportButton.Text = "Stop Collecting Data";
                        variables.exportBut = true;
                        timer2.Start();
                        //exportButton.Enabled = false;
                    }
                }
                else
                {
                    if (variables.numEN == 11)
                    {
                        exportButton.Text = "Veri Topla";
                        variables.exportBut = false;
                        variables.recordstate = false;
                        
                        MessageBox.Show("Kayıt Durduruldu");
                        timer2.Stop();
                    }
                    else if (variables.numEN == 10)
                    {
                        variables.exportBut = false;
                        variables.recordstate = false;
                        exportButton.Text = "Start Collecting Data";
                        MessageBox.Show("Record Stopped");
                        timer2.Stop();
                    }

                }


            }
            
        }

        private void saveDataButton_Click_1(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                try
                {

                    if (variables.numEN == 11)
                    {
                        timer2.Stop();
                        SaveFileDialog saveFileDialogg = new SaveFileDialog();
                        saveFileDialogg.Filter = "Excel (*.xls)|*.xls";
                        saveFileDialogg.FilterIndex = 0;
                        saveFileDialogg.RestoreDirectory = true;
                        saveFileDialogg.CreatePrompt = true;
                        saveFileDialogg.FileName = null;
                        saveFileDialogg.Title = "Kayıt";
                        if (saveFileDialogg.ShowDialog() == DialogResult.OK)
                        {
                            DataTable dt = Excel.DataGridView_To_Datatable(gridControl1);
                            dt.ExportToEx(saveFileDialogg.FileName);
                            timer2.Start();
                        }
                        else
                        {
                            MessageBox.Show("Dosya başarıyla kaydedilmedi!");
                            timer2.Start();
                        }
                    }

                    else if (variables.numEN == 10)
                    {
                        timer2.Stop();
                        SaveFileDialog saveFileDialog = new SaveFileDialog();
                        saveFileDialog.Filter = "Excel (*.xls)|*.xls";
                        saveFileDialog.FilterIndex = 0;
                        saveFileDialog.RestoreDirectory = true;
                        saveFileDialog.CreatePrompt = true;
                        saveFileDialog.FileName = null;
                        saveFileDialog.Title = "Record";
                        //saveFileDialog.ShowDialog();
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            DataTable dt = Excel.DataGridView_To_Datatable(gridControl1);
                            dt.ExportToEx(saveFileDialog.FileName);
                            timer2.Start();
                        }
                        else
                        {
                            MessageBox.Show("The file has not been saved successfully!");
                            timer2.Start();
                        }
                       
                    }



                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            string data_In = serialPort1.ReadTo("^");
            Data_TempPres(data_In);
            this.BeginInvoke(new EventHandler(Show_Data));
        }

        private void solidGauge2_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {
            //this.solidGauge2.ForeGround = Brushes.WhiteSmoke;
        }

        private void intervalButton_Click(object sender, EventArgs e)
        {

            if (variables.numEN == 11)
            {
                if (productNumber == "")
                {
                    MessageBox.Show("Lütfen önce ürün numarasını giriniz!");
                    return; // return because we don't want to run normal code of buton click
                }
                else
                {
                    if (MessageBox.Show("Lütfen işlem başlatılmadan önce onaylayınız!" + "\n" + "Devam Etmek İstiyor Musunuz?", "Evet", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

                    {
                        exportButton.Enabled = true;

                        if (intervalKind.SelectedItem.ToString() == "saniye")
                        {
                            timer2.Interval = Convert.ToInt32(intervalNumber.SelectedItem) * 1000;
                        }
                        else if (intervalKind.SelectedItem.ToString() == "dakika")
                        {
                            timer2.Interval = Convert.ToInt32(intervalNumber.SelectedItem) * 60000;
                        }
                        else if (intervalKind.SelectedItem.ToString() == "saat")
                        {
                            timer2.Interval = Convert.ToInt32(intervalNumber.SelectedItem) * 360000;
                        }
                    }
                    else

                    {
                        //do something if NO
                    }
                }
            }
            else if (variables.numEN == 10)
            {
                if (productNumber == "")
                {
                    MessageBox.Show("Please enter product number first!");
                    return; // return because we don't want to run normal code of buton click
                }
                else
                {
                    if (MessageBox.Show("Please confirm before proceed" + "\n" + "Do you want to Continue ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

                    {
                        exportButton.Enabled = true;

                        if (intervalKind.SelectedItem.ToString() == "second")
                        {
                            timer2.Interval = Convert.ToInt32(intervalNumber.SelectedItem) * 1000;
                        }
                        else if (intervalKind.SelectedItem.ToString() == "minute")
                        {
                            timer2.Interval = Convert.ToInt32(intervalNumber.SelectedItem) * 60000;
                        }
                        else if (intervalKind.SelectedItem.ToString() == "hour")
                        {
                            timer2.Interval = Convert.ToInt32(intervalNumber.SelectedItem) * 360000;
                        }
                    }
                    else

                    {
                        //do something if NO
                    }
                }
            }


        }

        private void productButton_Click(object sender, EventArgs e)
        {
            
            if (variables.numEN == 11)
            {
                if (textBox1.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Lütfen ürün numarasını giriniz!");
                    return; // return because we don't want to run normal code of buton click
                }
                else
                {
                    if (MessageBox.Show("Lütfen işlem başlatılmadan önce onaylayınız!" + "\n" + "Devam Etmek İstiyor Musunuz?", "Evet", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

                    {
                        productNumber = textBox1.Text;
                        productButton.Enabled = false;
                        textBox1.Clear();
                    }
                    else

                    {
                        //do something if NO
                    }
                }
            }
            else if (variables.numEN == 10)
            {
                if (textBox1.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please enter product number in the textbox");
                    return; // return because we don't want to run normal code of buton click
                }
                else
                {
                    if (MessageBox.Show("Please confirm before proceed" + "\n" + "Do you want to Continue ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

                    {
                        productNumber = textBox1.Text;
                        productButton.Enabled = false;
                        textBox1.Clear();
                    }
                    else

                    {
                        productButton.Enabled = true;
                    }
                }
            }


        }

        private void gridControl1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            if (variables.tryMe == false)
            {
                variables.tryMe = true;

                if (variables.numEN == 11)
                {
                    intervalNumber.Items.AddRange(new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60 });
                    intervalKind.Items.AddRange(new object[] { "saniye", "dakika", "saat" });
                }
                else if (variables.numEN == 10)
                {
                    intervalNumber.Items.AddRange(new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60 });
                    intervalKind.Items.AddRange(new object[] { "second", "minute", "hour" });
                }


                System.Windows.Threading.Dispatcher.CurrentDispatcher.Invoke((() =>

                {
                    
                    if (variables.numT == 12) // kelvin
                    {
                        solidGauge1.From = 254;
                        solidGauge1.To = 414;
                        solidGauge1.Uses360Mode = true;
                        solidGauge2.Value = 0;

                        if (variables.numP == 14)
                        {
                            solidGauge2.Uses360Mode = true;
                            solidGauge2.To = 1000;
                            solidGauge2.From = -1;
                            solidGauge2.Value = 0;
                        }

                        else if (variables.numP == 15)
                        {
                            solidGauge2.Uses360Mode = true;
                            solidGauge2.To = 100000000;
                            solidGauge2.From = -100000;
                            solidGauge2.Value = 0;

                        }
                        else if (variables.numP == 16)
                        {
                            solidGauge2.Uses360Mode = true;
                            solidGauge2.To = 1019;
                            solidGauge2.From = -1;
                            solidGauge2.Value = 0;

                        }
                        else if (variables.numP == 17)
                        {
                            solidGauge2.Uses360Mode = true;
                            solidGauge2.To = 10197162;
                            solidGauge2.From = -10197;
                            solidGauge2.Value = 0;

                        }
                        else if (variables.numP == 18)
                        {
                            solidGauge2.Uses360Mode = true;
                            solidGauge2.To = 10197;
                            solidGauge2.From = -10;
                            solidGauge2.Value = 0;

                        }
                        else if (variables.numP == 19)
                        {
                            solidGauge2.Uses360Mode = true;
                            solidGauge2.To = 750061;
                            solidGauge2.From = -750;
                            solidGauge2.Value = 0;

                        }
                        else if (variables.numP == 20)
                        {
                            solidGauge2.Uses360Mode = true;
                            solidGauge2.To = 14500;
                            solidGauge2.From = -15;
                            solidGauge2.Value = 0;

                        }
                        else if (variables.numP == 21)
                        {
                            solidGauge2.Uses360Mode = true;
                            solidGauge2.To = 100000;
                            solidGauge2.From = -100;
                            solidGauge2.Value = 0;

                        }
                        else if (variables.numP == 22)
                        {
                            solidGauge2.Uses360Mode = true;
                            solidGauge2.To = 100;
                            solidGauge2.From = -0.1;
                            solidGauge2.Value = 0;
                        }
                        else if (variables.numP == 23)
                        {
                            solidGauge2.Uses360Mode = true;
                            solidGauge2.To = 401464;
                            solidGauge2.From = -402;
                            solidGauge2.Value = 0;
                        }
                        else if (variables.numP == 2)
                        {
                            solidGauge2.Uses360Mode = true;
                            solidGauge2.To = 1000000;
                            solidGauge2.From = -1000;
                            solidGauge2.Value = 0;
                        }
                    }

                    else if (variables.numT == 13) // fahrenheit
                    {
                        solidGauge1.From = 30;
                        solidGauge1.To = 284;
                        solidGauge1.Uses360Mode = true;
                        solidGauge2.Value = 0;

                        if (variables.numP == 14)
                        {
                            solidGauge2.Uses360Mode = true;
                            solidGauge2.To = 1000;
                            solidGauge2.From = -1;
                            solidGauge2.Value = 0;
                        }

                        else if (variables.numP == 15)
                        {
                            solidGauge2.Uses360Mode = true;
                            solidGauge2.To = 100000000;
                            solidGauge2.From = -100000;
                            solidGauge2.Value = 0;

                        }
                        else if (variables.numP == 16)
                        {
                            solidGauge2.Uses360Mode = true;
                            solidGauge2.To = 1019;
                            solidGauge2.From = -1;
                            solidGauge2.Value = 0;

                        }
                        else if (variables.numP == 17)
                        {
                            solidGauge2.Uses360Mode = true;
                            solidGauge2.To = 10197162;
                            solidGauge2.From = -10197;
                            solidGauge2.Value = 0;

                        }
                        else if (variables.numP == 18)
                        {
                            solidGauge2.Uses360Mode = true;
                            solidGauge2.To = 10197;
                            solidGauge2.From = -10;
                            solidGauge2.Value = 0;

                        }
                        else if (variables.numP == 19)
                        {
                            solidGauge2.Uses360Mode = true;
                            solidGauge2.To = 750061;
                            solidGauge2.From = -750;
                            solidGauge2.Value = 0;

                        }
                        else if (variables.numP == 20)
                        {
                            solidGauge2.Uses360Mode = true;
                            solidGauge2.To = 14500;
                            solidGauge2.From = -15;
                            solidGauge2.Value = 0;

                        }
                        else if (variables.numP == 21)
                        {
                            solidGauge2.Uses360Mode = true;
                            solidGauge2.To = 100000;
                            solidGauge2.From = -100;
                            solidGauge2.Value = 0;

                        }
                        else if (variables.numP == 22)
                        {
                            solidGauge2.Uses360Mode = true;
                            solidGauge2.To = 100;
                            solidGauge2.From = -0.1;
                            solidGauge2.Value = 0;
                        }
                        else if (variables.numP == 23)
                        {
                            solidGauge2.Uses360Mode = true;
                            solidGauge2.To = 401464;
                            solidGauge2.From = -402;
                            solidGauge2.Value = 0;
                        }
                        else if (variables.numP == 2)
                        {
                            solidGauge2.Uses360Mode = true;
                            solidGauge2.To = 1000000;
                            solidGauge2.From = -1000;
                            solidGauge2.Value = 0;
                        }
                    }

                    else if (variables.numT == 1) // celcius
                    {
                        solidGauge1.From = -20;
                        solidGauge1.To = 150;
                        solidGauge1.Uses360Mode = true;
                        solidGauge2.Value = -20;

                        if (variables.numP == 14)
                        {
                            solidGauge2.Uses360Mode = true;
                            solidGauge2.To = 1000;
                            solidGauge2.From = -1;
                            solidGauge2.Value = 0;
                        }

                        else if (variables.numP == 15)
                        {
                            solidGauge2.Uses360Mode = true;
                            solidGauge2.To = 100000000;
                            solidGauge2.From = -100000;
                            solidGauge2.Value = 0;

                        }
                        else if (variables.numP == 16)
                        {
                            solidGauge2.Uses360Mode = true;
                            solidGauge2.To = 1019;
                            solidGauge2.From = -1;
                            solidGauge2.Value = 0;

                        }
                        else if (variables.numP == 17)
                        {
                            solidGauge2.Uses360Mode = true;
                            solidGauge2.To = 10197162;
                            solidGauge2.From = -10197;
                            solidGauge2.Value = 0;

                        }
                        else if (variables.numP == 18)
                        {
                            solidGauge2.Uses360Mode = true;
                            solidGauge2.To = 10197;
                            solidGauge2.From = -10;
                            solidGauge2.Value = 0;

                        }
                        else if (variables.numP == 19)
                        {
                            solidGauge2.Uses360Mode = true;
                            solidGauge2.To = 750061;
                            solidGauge2.From = -750;
                            solidGauge2.Value = 0;

                        }
                        else if (variables.numP == 20)
                        {
                            solidGauge2.Uses360Mode = true;
                            solidGauge2.To = 14500;
                            solidGauge2.From = -15;
                            solidGauge2.Value = 0;

                        }
                        else if (variables.numP == 21)
                        {
                            solidGauge2.Uses360Mode = true;
                            solidGauge2.To = 100000;
                            solidGauge2.From = -100;
                            solidGauge2.Value = 0;

                        }
                        else if (variables.numP == 22)
                        {
                            solidGauge2.Uses360Mode = true;
                            solidGauge2.To = 100;
                            solidGauge2.From = -0.1;
                            solidGauge2.Value = 0;
                        }
                        else if (variables.numP == 23)
                        {
                            solidGauge2.Uses360Mode = true;
                            solidGauge2.To = 401464;
                            solidGauge2.From = -402;
                            solidGauge2.Value = 0;
                        }
                        else if (variables.numP == 2)
                        {
                            solidGauge2.Uses360Mode = true;
                            solidGauge2.To = 1000000;
                            solidGauge2.From = -1000;
                            solidGauge2.Value = 0;
                        }
                    }
                    /*solidGauge1.From = -20;
                    solidGauge1.To = 150;
                    solidGauge1.Uses360Mode = true;
                    solidGauge2.Value = -20;

                    solidGauge2.Uses360Mode = true;
                    solidGauge2.To = 500000;
                    solidGauge2.From = 0;
                    solidGauge2.Value = 0;*/
                    solidGauge1.Base.LabelsVisibility = System.Windows.Visibility.Hidden;
                    solidGauge1.Base.GaugeActiveFill = new System.Windows.Media.LinearGradientBrush
                    {
                        GradientStops = new System.Windows.Media.GradientStopCollection
                            {
                                new System.Windows.Media.GradientStop(System.Windows.Media.Colors.Brown,6),

                            }

                    };

                    solidGauge2.Base.GaugeActiveFill = new System.Windows.Media.LinearGradientBrush
                    {
                        GradientStops = new System.Windows.Media.GradientStopCollection
                            {
                                new System.Windows.Media.GradientStop(System.Windows.Media.Colors.Green,6),

                            }

                    };
                })); // gauge's features == graph
            }
            if (variables.numEN == 11)
            {
                intervalButton.Text = rm.GetString("Save Interval");

                if (variables.xx == true)
                {
                    exportButton.Text = "Veri Topla ";
                    variables.xx = false;
                } 
                saveDataButton.Text = rm.GetString("Save Data(xsl)");
                productButton.Text = rm.GetString("Save Product Number");
                productGroup.Text = rm.GetString("Product Number(1)");
                intervalGroup.Text = rm.GetString("İnterval(2)");
                dataGroup.Text = rm.GetString("Data and Excel(3)");
                

            }
            else if (variables.numEN == 10)
            {
                intervalButton.Text = "Save Interval";
                exportButton.Text = "Collect Data";
                saveDataButton.Text ="Save Data(xsl)";
                productButton.Text = "Save Product Number";
                productGroup.Text = "Product Number(1)";
                intervalGroup.Text = "İnterval(2)";
                dataGroup.Text = "Data and Excel(3)";
                
            }

            





            if (variables.numT == 12)
            {
                tunitLabel.Text = "°K";

            }
            else if (variables.numT == 13)
            {
                tunitLabel.Text = "°F";

            }
            else if (variables.numT == 1)
            {
                tunitLabel.Text = "°C ";
            }

            if (variables.numP == 14)
            {
                punitLabel.Text = "Bar";

            }
            else if (variables.numP == 15)
            {
                punitLabel.Text = "Pa";
            }
            else if (variables.numP == 16)
            {
                punitLabel.Text = "kg/cm2";
            }
            else if (variables.numP == 17)
            {
                punitLabel.Text = "mmh2o";
            }
            else if (variables.numP == 18)
            {
                punitLabel.Text = "mh2o";
            }
            else if (variables.numP == 19)
            {
                punitLabel.Text = "mmHg";
            }
            else if (variables.numP == 20)
            {
                punitLabel.Text = "psi";
            }
            else if (variables.numP == 21)
            {
                punitLabel.Text = "kPa";
            }
            else if (variables.numP == 22)
            {
                punitLabel.Text = "MPa";
            }
            else if (variables.numP == 23)
            {
                punitLabel.Text = "MPa";
            }
            else if (variables.numP == 2)
            {
                punitLabel.Text = "mBar";
            }





        }

        public void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {

            {
                string data_In = serialPort1.ReadTo("^");
                Data_TempPres(data_In);
                this.BeginInvoke(new EventHandler(Show_Data));



            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {

            if (serialPort1.IsOpen)
            {

                if (variables.numT == 12)
                {

                    double kelvinS = 273.15;
                    duration += 1;
                    chart1.Series[0].Points.AddXY(duration, (temp + kelvinS));

                    if (chart1.Series[0].Points.Count > 300)
                        chart1.Series[0].Points.RemoveAt(0);

                    chart1.ChartAreas[0].AxisX.Minimum = chart1.Series[0].Points[0].XValue;
                    chart1.ChartAreas[0].AxisX.Maximum = duration;

                    durationn += 1;
                }
                else if (variables.numT == 13)
                {

                    duration += 1;
                    chart1.Series[0].Points.AddXY(duration, ((temp * 1.8) + 32));

                    if (chart1.Series[0].Points.Count > 300)
                        chart1.Series[0].Points.RemoveAt(0);

                    chart1.ChartAreas[0].AxisX.Minimum = chart1.Series[0].Points[0].XValue;
                    chart1.ChartAreas[0].AxisX.Maximum = duration;

                    durationn += 1;
                }
                else if (variables.numT == 1)
                {

                    chart1.Series[0].Points.AddXY(duration, temp);

                    if (chart1.Series[0].Points.Count > 300)
                        chart1.Series[0].Points.RemoveAt(0);

                    chart1.ChartAreas[0].AxisX.Minimum = chart1.Series[0].Points[0].XValue;
                    chart1.ChartAreas[0].AxisX.Maximum = duration;

                    durationn += 1;
                }

                if (variables.numP == 14)
                {
                    chart2.Series[0].Points.AddXY(duration, pressure/1000);

                    if (chart2.Series[0].Points.Count > 300)
                        chart2.Series[0].Points.RemoveAt(0);

                    chart2.ChartAreas[0].AxisX.Minimum = chart2.Series[0].Points[0].XValue;
                    chart2.ChartAreas[0].AxisX.Maximum = duration;

                    duration += 1;
                }
                else if (variables.numP == 15)
                {
                    chart2.Series[0].Points.AddXY(duration, pressure*100);

                    if (chart2.Series[0].Points.Count > 300)
                        chart2.Series[0].Points.RemoveAt(0);

                    chart2.ChartAreas[0].AxisX.Minimum = chart2.Series[0].Points[0].XValue;
                    chart2.ChartAreas[0].AxisX.Maximum = duration;

                    duration += 1;
                }
                else if (variables.numP == 16)
                {
                    chart2.Series[0].Points.AddXY(duration, pressure * 0.00102);

                    if (chart2.Series[0].Points.Count > 300)
                        chart2.Series[0].Points.RemoveAt(0);

                    chart2.ChartAreas[0].AxisX.Minimum = chart2.Series[0].Points[0].XValue;
                    chart2.ChartAreas[0].AxisX.Maximum = duration;

                    duration += 1;
                }
                else if (variables.numP == 17)
                {
                    chart2.Series[0].Points.AddXY(duration, pressure / 0.0980665);

                    if (chart2.Series[0].Points.Count > 300)
                        chart2.Series[0].Points.RemoveAt(0);

                    chart2.ChartAreas[0].AxisX.Minimum = chart2.Series[0].Points[0].XValue;
                    chart2.ChartAreas[0].AxisX.Maximum = duration;

                    duration += 1;
                }
                else if (variables.numP == 18)
                {
                    chart2.Series[0].Points.AddXY(duration, pressure * 0.010197442889221);

                    if (chart2.Series[0].Points.Count > 300)
                        chart2.Series[0].Points.RemoveAt(0);

                    chart2.ChartAreas[0].AxisX.Minimum = chart2.Series[0].Points[0].XValue;
                    chart2.ChartAreas[0].AxisX.Maximum = duration;

                    duration += 1;
                }
                else if (variables.numP == 19)
                {
                    chart2.Series[0].Points.AddXY(duration, pressure * 0.750062);

                    if (chart2.Series[0].Points.Count > 300)
                        chart2.Series[0].Points.RemoveAt(0);

                    chart2.ChartAreas[0].AxisX.Minimum = chart2.Series[0].Points[0].XValue;
                    chart2.ChartAreas[0].AxisX.Maximum = duration;

                    duration += 1;
                }
                else if (variables.numP == 20)
                {
                    chart2.Series[0].Points.AddXY(duration, pressure * 0.0145037738);

                    if (chart2.Series[0].Points.Count > 300)
                        chart2.Series[0].Points.RemoveAt(0);

                    chart2.ChartAreas[0].AxisX.Minimum = chart2.Series[0].Points[0].XValue;
                    chart2.ChartAreas[0].AxisX.Maximum = duration;

                    duration += 1;
                }
                else if (variables.numP == 21)
                {
                    chart2.Series[0].Points.AddXY(duration, pressure / 100000);

                    if (chart2.Series[0].Points.Count > 300)
                        chart2.Series[0].Points.RemoveAt(0);

                    chart2.ChartAreas[0].AxisX.Minimum = chart2.Series[0].Points[0].XValue;
                    chart2.ChartAreas[0].AxisX.Maximum = duration;

                    duration += 1;
                }
                else if (variables.numP == 22)
                {
                    chart2.Series[0].Points.AddXY(duration, pressure / 100000000);

                    if (chart2.Series[0].Points.Count > 300)
                        chart2.Series[0].Points.RemoveAt(0);

                    chart2.ChartAreas[0].AxisX.Minimum = chart2.Series[0].Points[0].XValue;
                    chart2.ChartAreas[0].AxisX.Maximum = duration;

                    duration += 1;
                }
                else if (variables.numP == 23)
                {
                    chart2.Series[0].Points.AddXY(duration, pressure / 2.490889);

                    if (chart2.Series[0].Points.Count > 300)
                        chart2.Series[0].Points.RemoveAt(0);

                    chart2.ChartAreas[0].AxisX.Minimum = chart2.Series[0].Points[0].XValue;
                    chart2.ChartAreas[0].AxisX.Maximum = duration;

                    duration += 1;
                }
                else if (variables.numP == 2)
                {
                    chart2.Series[0].Points.AddXY(duration, pressure);

                    if (chart2.Series[0].Points.Count > 300)
                        chart2.Series[0].Points.RemoveAt(0);

                    chart2.ChartAreas[0].AxisX.Minimum = chart2.Series[0].Points[0].XValue;
                    chart2.ChartAreas[0].AxisX.Maximum = duration ;

                    duration += 1;
                }

                
            }
        }

        public static class Excel
        {
            public static void ExportToEx(System.Data.DataTable DataTable, string ExcelFilePath = null)
            {
                try
                {
                    int ColumnsCount;
                    if (DataTable == null || (ColumnsCount = DataTable.Columns.Count) == 0)
                        throw new Exception("ExportToExcel: Null or empty input table!\n");
                    Microsoft.Office.Interop.Excel.Application Excel = new Microsoft.Office.Interop.Excel.Application();
                    Excel.Workbooks.Add();
                    Microsoft.Office.Interop.Excel._Worksheet Worksheet = Excel.ActiveSheet;
                    object[] Header = new object[ColumnsCount];
                    for (int i = 0; i < ColumnsCount; i++)
                        Header[i] = DataTable.Columns[i].ColumnName;
                    Microsoft.Office.Interop.Excel.Range HeaderRange = Worksheet.get_Range((Microsoft.Office.Interop.Excel.Range)(Worksheet.Cells[1, 1]), (Microsoft.Office.Interop.Excel.Range)(Worksheet.Cells[1, ColumnsCount]));
                    HeaderRange.Value = Header;
                    HeaderRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                    HeaderRange.Font.Bold = true;
                    int RowsCount = DataTable.Rows.Count;
                    object[,] Cells = new object[RowsCount, ColumnsCount];

                    for (int j = 0; j < RowsCount; j++)
                        for (int i = 0; i < ColumnsCount; i++)
                            Cells[j, i] = DataTable.Rows[j][i];

                    Worksheet.get_Range((Microsoft.Office.Interop.Excel.Range)(Worksheet.Cells[2, 1]), (Microsoft.Office.Interop.Excel.Range)(Worksheet.Cells[RowsCount + 1, ColumnsCount])).Value = Cells;
                    if (ExcelFilePath != null && ExcelFilePath != "")
                    {
                        try
                        {
                            Worksheet.SaveAs(ExcelFilePath);
                            Excel.Quit();
                            System.Windows.Forms.MessageBox.Show("Excel file saved!");
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("ExportToExcel: Excel file could not be saved! Check filepath.\n"
                              + ex.Message);
                        }
                    }
                    else  // no filepath is given
                    {
                        Excel.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("ExportToExcel: \n" + ex.Message);
                }
            }
            public static DataTable DataGridView_To_Datatable(DataGridView dg)
            {
                DataTable ExportDataTable = new DataTable();
                foreach (DataGridViewColumn col in dg.Columns)
                {
                    ExportDataTable.Columns.Add(col.Name);
                }
                foreach (DataGridViewRow row in dg.Rows)
                {
                    DataRow dRow = ExportDataTable.NewRow();
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        dRow[cell.ColumnIndex] = cell.Value;
                    }
                    ExportDataTable.Rows.Add(dRow);
                }
                return ExportDataTable;
            }
        }

        private void Show_Data(object sender, EventArgs e)


        {
            if (updateData == true)
            {
                if (variables.numT == 12) // for kelvin
                {
                    solidGauge1.Value = temp + 273.15;
                    if (variables.numP == 14)
                    {
                        double example = pressure / 1000;
                        solidGauge2.Value = ((double)((int)(example * 1000.0))) / 1000.0;
                    }
                    else if (variables.numP == 15)
                    {
                        double example = pressure * 100;
                        solidGauge2.Value = ((double)((int)(example * 1000.0))) / 1000.0;

                    }
                    else if (variables.numP == 16)
                    {
                        double example = pressure * 0.00102;
                        solidGauge2.Value = ((double)((int)(example * 1000.0))) / 1000.0;


                    }
                    else if (variables.numP == 17)
                    {
                        double example = pressure / 0.0980665;
                        solidGauge2.Value = ((double)((int)(example * 1000.0))) / 1000.0;


                    }
                    else if (variables.numP == 18)
                    {
                        double example = pressure / 98.0665;
                        solidGauge2.Value = Math.Truncate(example * 1000) / 1000;

                    }
                    else if (variables.numP == 19)
                    {
                        double example = pressure * 0.750062;
                        solidGauge2.Value = Math.Truncate(example * 1000) / 1000;


                    }
                    else if (variables.numP == 20)
                    {
                        double example = pressure * 0.0145037738;
                        solidGauge2.Value = Math.Truncate(example * 1000) / 1000;


                    }
                    else if (variables.numP == 21)
                    {
                        double example = pressure / 10;
                        solidGauge2.Value = Math.Truncate(example * 1000) / 1000;


                    }
                    else if (variables.numP == 22)
                    {
                        double example = pressure / 10000;
                        solidGauge2.Value = Math.Truncate(example * 1000) / 1000;

                    }
                    else if (variables.numP == 23)
                    {
                        double example = pressure / 2.490889;
                        solidGauge2.Value = Math.Truncate(example * 1000) / 1000;


                    }

                    else if (variables.numP == 2)
                    {
                        solidGauge2.Value = Math.Truncate(pressure * 1000) / 1000;

                    }

                }
                else if (variables.numT == 13)// for fahrenheit
                {
                    solidGauge1.Value = (temp * 1.8) + 32;

                    if (variables.numP == 14)
                    {
                        double example = pressure / 1000;
                        solidGauge2.Value = ((double)((int)(example * 1000.0))) / 1000.0;
                    }
                    else if (variables.numP == 15)
                    {
                        double example = pressure * 100;
                        solidGauge2.Value = ((double)((int)(example * 1000.0))) / 1000.0;

                    }
                    else if (variables.numP == 16)
                    {
                        double example = pressure * 0.00102;
                        solidGauge2.Value = ((double)((int)(example * 1000.0))) / 1000.0;


                    }
                    else if (variables.numP == 17)
                    {
                        double example = pressure / 0.0980665;
                        solidGauge2.Value = ((double)((int)(example * 1000.0))) / 1000.0;


                    }
                    else if (variables.numP == 18)
                    {
                        double example = pressure / 98.0665;
                        solidGauge2.Value = Math.Truncate(example * 1000) / 1000;

                    }
                    else if (variables.numP == 19)
                    {
                        double example = pressure * 0.750062;
                        solidGauge2.Value = Math.Truncate(example * 1000) / 1000;


                    }
                    else if (variables.numP == 20)
                    {
                        double example = pressure * 0.0145037738;
                        solidGauge2.Value = Math.Truncate(example * 1000) / 1000;


                    }
                    else if (variables.numP == 21)
                    {
                        double example = pressure / 10;
                        solidGauge2.Value = Math.Truncate(example * 1000) / 1000;


                    }
                    else if (variables.numP == 22)
                    {
                        double example = pressure / 10000;
                        solidGauge2.Value = Math.Truncate(example * 1000) / 1000;

                    }
                    else if (variables.numP == 23)
                    {
                        double example = pressure / 2.490889;
                        solidGauge2.Value = Math.Truncate(example * 1000) / 1000;


                    }

                    else if (variables.numP == 2)
                    {
                        solidGauge2.Value = Math.Truncate(pressure * 1000) / 1000;

                    }
                }
                else if (variables.numT == 1) // for celcius
                {
                    solidGauge1.Value = temp;

                    if (variables.numP == 14)
                    {
                        double example = pressure / 1000;
                        solidGauge2.Value =  ((double)((int)(example * 1000.0))) / 1000.0;
                    }
                    else if (variables.numP == 15)
                    {
                        double example = pressure * 100;
                        solidGauge2.Value = ((double)((int)(example * 1000.0))) / 1000.0;

                    }
                    else if (variables.numP == 16)
                    {
                        double example = pressure * 0.00102;
                        solidGauge2.Value = ((double)((int)(example * 1000.0))) / 1000.0;
                       

                    }
                    else if (variables.numP == 17)
                    {
                        double example = pressure / 0.0980665;
                        solidGauge2.Value = ((double)((int)(example * 1000.0))) / 1000.0;
                        

                    }
                    else if (variables.numP == 18)
                    {
                        double example = pressure / 98.0665;
                        solidGauge2.Value = Math.Truncate(example * 1000) / 1000;

                    }
                    else if (variables.numP == 19)
                    {
                        double example = pressure * 0.750062;
                        solidGauge2.Value = Math.Truncate(example * 1000) / 1000;
                       

                    }
                    else if (variables.numP == 20)
                    {
                        double example = pressure * 0.0145037738;
                        solidGauge2.Value = Math.Truncate(example * 1000) / 1000;
                        

                    }
                    else if (variables.numP == 21)
                    {
                        double example = pressure / 10;
                        solidGauge2.Value = Math.Truncate(example * 1000) / 1000;
                        

                    }
                    else if (variables.numP == 22)
                    {
                        double example = pressure / 10000;
                        solidGauge2.Value = Math.Truncate(example * 1000) / 1000;

                    }
                    else if (variables.numP == 23)
                    {
                        double example = pressure / 2.490889;
                        solidGauge2.Value = Math.Truncate(example * 1000) / 1000;
                        

                    }

                    else if (variables.numP == 2)
                    {
                        solidGauge2.Value = Math.Truncate(pressure * 1000) / 1000;

                    }
                }

            }
        }


    }
}