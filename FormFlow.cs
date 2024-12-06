using System;
using System.Data;
using System.IO;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
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
        
      
        bool updateData = false;
        bool updateData2 = false;
        double duration,durationn;
        


        SerialPort myPort;
        FormSettings formS = new FormSettings();
        private delegate void SetTextDeleg(string text);
        String productNumber = "";

        private void loadGaugeInit()
        {

            if (variables.device == 1)
            {
                solidGauge2.Uses360Mode = true;
                solidGauge2.To = 391;
                solidGauge2.From = 18.52;
                solidGauge2.Value = 18.52;
            }
            else if (variables.device == 2)
            {
                solidGauge2.Uses360Mode = true;
                solidGauge2.To = 2840;
                solidGauge2.From = 683;
                solidGauge2.Value = 683;
            }
            else
            {
                solidGauge2.Uses360Mode = true;
                solidGauge2.To = 10000;
                solidGauge2.From = 0;
                solidGauge2.Value = 0;
            }
        }

        private void showDataInit()
        {
            if (!variables.connectionLost)
                if (variables.type == 1) // pressure
                {
                    switch (variables.numP)
                    {
                        case 2:
                            solidGauge2.Value = Math.Truncate(variables.Pressure * 1000) / 1000;
                            break;
                        case 14:
                            solidGauge2.Value = Math.Truncate((variables.Pressure/1000) * 1000) / 1000;
                            break;
                        case 15:
                            solidGauge2.Value = Math.Truncate((variables.Pressure * 100) * 1000) / 1000;
                            break;
                        case 16:
                            solidGauge2.Value = Math.Truncate((variables.Pressure * 0.00102) * 1000) / 1000;
                            break;
                        case 17:
                            solidGauge2.Value = Math.Truncate((variables.Pressure / 0.0980665) * 1000) / 1000;
                            break;
                        case 18:
                            solidGauge2.Value = Math.Truncate((variables.Pressure / 98.0665) * 1000) / 1000;
                            break;
                        case 19:
                            solidGauge2.Value = Math.Truncate((variables.Pressure * 0.75006) * 1000) / 1000;
                            break;
                        case 20:
                            solidGauge2.Value = Math.Truncate((variables.Pressure * 0.0145037738) * 1000) / 1000;
                            break;
                        case 21:
                            solidGauge2.Value = Math.Truncate((variables.Pressure / 10) * 1000) / 1000;
                            break;
                        case 22:
                            solidGauge2.Value = Math.Truncate((variables.Pressure / 10000) * 1000) / 1000;
                            break;
                        case 23:
                            solidGauge2.Value = Math.Truncate((variables.Pressure/ 2.490889) * 1000) / 1000;
                            break;
                    }
                }
                else if (variables.type == 2)
                {
                    solidGauge2.Value = Math.Truncate(variables.Pressure * 1000) / 1000;
                }
                
            else
                solidGauge2.Value = -999;
            
        }

        private void excelKelvinInitDivide(double x,String y) // y = "," + "Sıcaklık" + "," + "Basınç" + "," + "Tarih" // y = "," + "Temperature" + "," + "Pressure" + "," + "Date"
        {
            double kelvinS = 273.15;
            double kelvin = (variables.Temperature + kelvinS);
            variables.records.Rows.Add(productNumber, kelvin, variables.Pressure/ x, DateTime.Now);

            using (var tw = new StreamWriter(path, true))
            {
                if (!firstrecord)
                {
                    tw.WriteLine(productNumber + y);
                    firstrecord = true;
                }

                gridControl1.FirstDisplayedScrollingRowIndex = gridControl1.RowCount - 1;
                tw.WriteLine(productNumber + kelvin.ToString() + "," + (variables.Pressure /x).ToString() + "," + variables.Density.ToString() + "," + DateTime.Now.ToString());
                tw.Close();
            }


            gridControl1.Update();
        }
        private void excelKelvinInitMultiple(double x,String y)
        {

            double kelvinS = 273.15;
            double kelvin = (variables.Temperature + kelvinS);
            double fahrenheit = ((variables.Temperature * 1.8) + 32);
            variables.records.Rows.Add(productNumber, kelvin, variables.Pressure * x, DateTime.Now);

            using (var tw = new StreamWriter(path, true))
            {
                if (!firstrecord)
                {
                    tw.WriteLine(productNumber + y);
                    firstrecord = true;
                }

                gridControl1.FirstDisplayedScrollingRowIndex = gridControl1.RowCount - 1;
                tw.WriteLine(productNumber + kelvin.ToString() + "," + (variables.Pressure * x).ToString() + "," + variables.Density.ToString() + "," + DateTime.Now.ToString());
                tw.Close();
            }


            gridControl1.Update();
        }

        private void excelFahrenheitInitDivide(double x,String y)
        {
            double fahrenheit = ((variables.Temperature * 1.8) + 32);
            variables.records.Rows.Add(productNumber, fahrenheit, variables.Pressure / x, DateTime.Now);

            using (var tw = new StreamWriter(path, true))
            {
                if (!firstrecord)
                {
                    tw.WriteLine(productNumber + y);
                    firstrecord = true;
                }

                gridControl1.FirstDisplayedScrollingRowIndex = gridControl1.RowCount - 1;
                tw.WriteLine(productNumber + fahrenheit.ToString() + "," + (variables.Pressure / x).ToString() + "," + variables.Density.ToString() + "," + DateTime.Now.ToString());
                tw.Close();
            }


            gridControl1.Update();
        }
        private void excelFahrenheitInitMultiple(double x,String y)
        {
            double fahrenheit = ((variables.Temperature * 1.8) + 32);
            variables.records.Rows.Add(productNumber, fahrenheit, variables.Pressure * x, DateTime.Now);

            using (var tw = new StreamWriter(path, true))
            {
                if (!firstrecord)
                {
                    tw.WriteLine(productNumber + y);
                    firstrecord = true;
                }

                gridControl1.FirstDisplayedScrollingRowIndex = gridControl1.RowCount - 1;
                tw.WriteLine(productNumber + fahrenheit.ToString() + "," + (variables.Pressure * x).ToString() + "," + variables.Density.ToString() + "," + DateTime.Now.ToString());
                tw.Close();
            }


            gridControl1.Update();
        }

        private void excelCelciusInitMultiple(double x,String y)
        {
            variables.records.Rows.Add(productNumber, variables.Temperature, variables.Pressure * x, DateTime.Now);

            using (var tw = new StreamWriter(path, true))
            {
                if (!firstrecord)
                {
                    tw.WriteLine(productNumber + y);
                    firstrecord = true;
                }
                gridControl1.FirstDisplayedScrollingRowIndex = gridControl1.RowCount - 1;

                tw.WriteLine(productNumber + variables.Temperature.ToString() + "," + (variables.Pressure * x).ToString() + "," + variables.Density.ToString() + "," + DateTime.Now.ToString());
                tw.Close();
            }


            gridControl1.Update();
        }
        private void excelCelciusInitDivide(double x,String y)
        {
            variables.records.Rows.Add(productNumber, variables.Temperature, variables.Pressure / x, DateTime.Now);

            using (var tw = new StreamWriter(path, true))
            {
                if (!firstrecord)
                {
                    tw.WriteLine(productNumber + y);
                    firstrecord = true;
                }
                gridControl1.FirstDisplayedScrollingRowIndex = gridControl1.RowCount - 1;

                tw.WriteLine(productNumber + variables.Temperature.ToString() + "," + (variables.Pressure / x).ToString() + "," + variables.Density.ToString() + "," + DateTime.Now.ToString());
                tw.Close();
            }


            gridControl1.Update();
        }





        public FormFlow()
        {

           
            InitializeComponent();
            
            productGroup.Font = new System.Drawing.Font("Arial", 8F);
            dataGroup.Font = new System.Drawing.Font("Arial", 8F);
            intervalGroup.Font = new System.Drawing.Font("Arial", 8F);
            punitLabel.Font = new System.Drawing.Font("Arial", 16F);
            tunitLabel.Font = new System.Drawing.Font("Arial", 16F);
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
            variables.flowOpen = true;
            variables.comportx = true;

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
                else if (variables.numT == 1)
                {
                    variables.records.Columns.Add("Sıcaklık(°C)", typeof(float));
                }
                if (variables.type == 1)
                {
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
                        variables.records.Columns.Add("Basınç(mbar)", typeof(float));
                    }
                }
                else if (variables.type == 2)
                    variables.records.Columns.Add("   Ω", typeof(float));

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

                if (variables.type == 1)
                {
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
                        variables.records.Columns.Add("Pressure(mbar)", typeof(float));
                    }
                }
                else if (variables.type == 2)
                    variables.records.Columns.Add("   Ω", typeof(float));

                variables.records.Columns.Add("Date", typeof(DateTime));
                gridControl1.DataSource = variables.records;
                txtname = variables.RandomString(5) + ".txt";
                path = AppDomain.CurrentDomain.BaseDirectory + txtname;
                File.Create(path);
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


            if (variables.status == 66)
            {

                timer1.Enabled = true;
                timer1.Interval = 1000;
                timer2.Interval = 3000;
                timer2.Enabled = true;
                timer1.Start();

            }


            System.Windows.Threading.Dispatcher.CurrentDispatcher.Invoke((() =>

            {
                if (variables.numT == 12) // kelvin
                {
                    solidGauge1.From = 23.15;
                    solidGauge1.To = 1123.15;
                    solidGauge1.Uses360Mode = true;
                    solidGauge2.Value = 0;
                }

                else if (variables.numT == 13) // fahrenheit
                {
                    solidGauge1.From = -418;
                    solidGauge1.To = 1562;
                    solidGauge1.Uses360Mode = true;
                    solidGauge2.Value = 0;
                }

                else if (variables.numT == 1) // celcius
                {
                    solidGauge1.From = -250;
                    solidGauge1.To = 850;
                    solidGauge1.Uses360Mode = true;
                    solidGauge2.Value = -20;
                }

                loadGaugeInit();

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
            })); 


        }
        
        bool firstrecord = false;
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (variables.status == 66 && !variables.connectionLost)
            {
                if (variables.type == 1)
                {
                    variables.trY = "," + "Sıcaklık" + "," + "Basınç" + "," + "Tarih";
                    variables.enY = "," + "Temperature" + "," + "Pressure" + "," + "Date";
                }
                else if (variables.type == 2)
                {
                    variables.trY = "," + "Sıcaklık" + "," + "Omaj" + "," + "Tarih";
                    variables.enY = "," + "Temperature" + "," + "Ohm" + "," + "Date";
                }
                
                if (variables.numEN == 11) //for TR
                {
                    if (variables.recordstate == true)
                    {
                        if (variables.numT == 12) // for Kelvin
                        {
                            if (variables.numP == 14) // for Bar
                            {
                                excelKelvinInitDivide(1000,variables.trY);
                            }

                            else if (variables.numP == 15) // for Pa
                            {
                                excelKelvinInitMultiple(100, variables.trY);
                            }

                            else if (variables.numP == 16) // for kg/cm2
                            {
                                excelKelvinInitMultiple(0.00102, variables.trY);
                            }

                            else if (variables.numP == 17) // for mmh2o
                            {
                                excelKelvinInitDivide(0.0980665, variables.trY);
                            }

                            else if (variables.numP == 18) // for mh2o
                            {
                                excelKelvinInitDivide(98.0665, variables.trY);
                            }

                            else if (variables.numP == 19) // for mmHg
                            {
                                excelKelvinInitMultiple(0.75006, variables.trY);
                            }

                            else if (variables.numP == 20) // for psi
                            {
                                excelKelvinInitMultiple(0.0145037738, variables.trY);
                            }

                            else if (variables.numP == 21) // for kPa
                            {
                                excelKelvinInitDivide(10, variables.trY);
                            }

                            else if (variables.numP == 22) // for MPa
                            {
                                excelKelvinInitDivide(10000, variables.trY);
                            }
                            else if (variables.numP == 23) // for iwg
                            {
                                excelKelvinInitDivide(2.490889, variables.trY);
                            }

                            else if (variables.numP == 2) // for mbar
                            {
                                double kelvinS = 273.15;
                                double kelvin = (variables.Temperature + kelvinS);
                                variables.records.Rows.Add(productNumber, kelvin, variables.Pressure, DateTime.Now);

                                using (var tw = new StreamWriter(path, true))
                                {
                                    if (!firstrecord)
                                    {
                                        tw.WriteLine(productNumber + "," + "Sıcaklık" + "," + "Basınç" + "," + "Tarih");
                                        firstrecord = true;
                                    }

                                    gridControl1.FirstDisplayedScrollingRowIndex = gridControl1.RowCount - 1;
                                    tw.WriteLine(productNumber + kelvin.ToString() + "," + variables.Pressure.ToString() + "," + variables.Density.ToString() + "," + DateTime.Now.ToString());
                                    tw.Close();
                                }


                                gridControl1.Update();
                            }



                        }
                        else if (variables.numT == 13) // for Fahrenheit
                        {
                            if (variables.numP == 14) // for Bar
                            {
                                excelFahrenheitInitDivide(1000, variables.trY);
                            }

                            else if (variables.numP == 15) // for Pa
                            {
                                excelFahrenheitInitMultiple(100, variables.trY);
                            }

                            else if (variables.numP == 16) // for kg/cm2
                            {
                                excelFahrenheitInitMultiple(0.00102, variables.trY);
                            }

                            else if (variables.numP == 17) // for mmh2o
                            {
                                excelFahrenheitInitDivide(0.0980665, variables.trY);
                            }

                            else if (variables.numP == 18) // for mh2o
                            {
                                excelFahrenheitInitDivide(98.0665, variables.trY);
                            }

                            else if (variables.numP == 19) // for mmHg
                            {
                                excelFahrenheitInitMultiple(0.75006, variables.trY);
                            }

                            else if (variables.numP == 20) // for psi
                            {
                                excelFahrenheitInitMultiple(0.0145037738, variables.trY);
                            }

                            else if (variables.numP == 21) // for kPa
                            {
                                excelFahrenheitInitDivide(10, variables.trY);
                            }

                            else if (variables.numP == 22) // for MPa
                            {
                                excelFahrenheitInitDivide(10000, variables.trY);
                            }
                            else if (variables.numP == 23) // for iwg
                            {
                                excelFahrenheitInitDivide(2.490889, variables.trY);
                            }

                            else if (variables.numP == 2) // for mbar
                            {
                                double fahrenheit = ((variables.Temperature * 1.8) + 32);
                                variables.records.Rows.Add(productNumber, fahrenheit, variables.Pressure, DateTime.Now);

                                using (var tw = new StreamWriter(path, true))
                                {
                                    if (!firstrecord)
                                    {
                                        tw.WriteLine(productNumber + "," + "Sıcaklık" + "," + "Basınç" + "," + "Tarih");
                                        firstrecord = true;
                                    }

                                    gridControl1.FirstDisplayedScrollingRowIndex = gridControl1.RowCount - 1;
                                    tw.WriteLine(productNumber + fahrenheit.ToString() + "," + variables.Pressure.ToString() + "," + variables.Density.ToString() + "," + DateTime.Now.ToString());
                                    tw.Close();
                                }


                                gridControl1.Update();
                            }
                        }
                        else if (variables.numT == 1) // for Celcius
                        {
                            if (variables.numP == 14) // for Bar
                            {
                                excelCelciusInitDivide(1000, variables.trY);  
                            }

                            else if (variables.numP == 15) // for Pa
                            {
                                excelCelciusInitMultiple(100, variables.trY);
                            }

                            else if (variables.numP == 16) // for kg/cm2
                            {
                                excelCelciusInitMultiple(0.00102, variables.trY);
                            }

                            else if (variables.numP == 17) // for mmh2o
                            {
                                excelCelciusInitDivide(0.0980665, variables.trY);
                            }

                            else if (variables.numP == 18) // for mh2o
                            {
                                excelCelciusInitDivide(98.0665, variables.trY);
                            }

                            else if (variables.numP == 19) // for mmHg
                            {
                                excelCelciusInitMultiple(0.750062, variables.trY);
                            }

                            else if (variables.numP == 20) // for psi
                            {
                                excelCelciusInitMultiple(0.0145037738, variables.trY);
                            }

                            else if (variables.numP == 21) // for kPa
                            {
                                excelCelciusInitDivide(10, variables.trY);
                            }

                            else if (variables.numP == 22) // for MPa
                            {
                                excelCelciusInitDivide(10000, variables.trY);
                            }

                            else if (variables.numP == 23) // for iwg
                            {
                                excelCelciusInitDivide(2.490889, variables.trY);
                            }

                            else if (variables.numP == 2) // for mbar
                            {

                                variables.records.Rows.Add(productNumber, variables.Temperature, variables.Pressure, DateTime.Now);

                                using (var tw = new StreamWriter(path, true))
                                {
                                    if (!firstrecord)
                                    {
                                        tw.WriteLine(productNumber + "," + "Sıcaklık" + "," + "Basınç" + "," + "Tarih");
                                        firstrecord = true;
                                    }
                                    gridControl1.FirstDisplayedScrollingRowIndex = gridControl1.RowCount - 1;

                                    tw.WriteLine(productNumber + variables.Temperature.ToString() + "," + variables.Pressure.ToString() + "," + variables.Density.ToString() + "," + DateTime.Now.ToString());
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
                                excelKelvinInitDivide(1000, variables.enY);
                            }

                            else if (variables.numP == 15) // for Pa
                            {
                                excelKelvinInitMultiple(100, variables.enY);
                            }

                            else if (variables.numP == 16) // for kg/cm2
                            {
                                excelKelvinInitMultiple(0.00102, variables.enY);
                            }

                            else if (variables.numP == 17) // for mmh2o
                            {
                                excelKelvinInitDivide(0.0980665, variables.enY);
                            }

                            else if (variables.numP == 18) // for mh2o
                            {
                                excelKelvinInitDivide(98.0665, variables.enY);
                            }

                            else if (variables.numP == 19) // for mmHg
                            {
                                excelKelvinInitMultiple(0.75006, variables.enY);
                            }

                            else if (variables.numP == 20) // for psi
                            {
                                excelKelvinInitMultiple(0.0145037738, variables.enY);
                            }

                            else if (variables.numP == 21) // for kPa
                            {
                                excelKelvinInitDivide(10, variables.enY);
                            }

                            else if (variables.numP == 22) // for MPa
                            {
                                excelKelvinInitDivide(10000, variables.enY);
                            }
                            else if (variables.numP == 23) // for iwg
                            {
                                excelKelvinInitDivide(2.490889, variables.enY);
                            }

                            else if (variables.numP == 2) // for mbar
                            {
                                double kelvinS = 273.15;
                                double kelvin = (variables.Temperature + kelvinS);
                                variables.records.Rows.Add(productNumber, kelvin, variables.Pressure, DateTime.Now);

                                using (var tw = new StreamWriter(path, true))
                                {
                                    if (!firstrecord)
                                    {
                                        if(variables.type == 2)
                                            tw.WriteLine(productNumber + "," + "Temperature" + "," + "Ω" + "," + "Date");
                                        else if (variables.type == 1)
                                            tw.WriteLine(productNumber + "," + "Temperature" + "," + "Pressure" + "," + "Date");
                                        firstrecord = true;
                                    }

                                    gridControl1.FirstDisplayedScrollingRowIndex = gridControl1.RowCount - 1;
                                    tw.WriteLine(productNumber + kelvin.ToString() + "," + variables.Pressure.ToString() + "," + variables.Density.ToString() + "," + DateTime.Now.ToString());
                                    tw.Close();
                                }


                                gridControl1.Update();
                            }



                        }
                        else if (variables.numT == 13) // for Fahrenheit
                        {
                            if (variables.numP == 14) // for Bar
                            {
                                excelFahrenheitInitDivide(1000, variables.enY);
                            }

                            else if (variables.numP == 15) // for Pa
                            {
                                excelFahrenheitInitMultiple(100, variables.enY);
                            }

                            else if (variables.numP == 16) // for kg/cm2
                            {
                                excelFahrenheitInitMultiple(0.00102, variables.enY);
                            }

                            else if (variables.numP == 17) // for mmh2o
                            {
                                excelFahrenheitInitDivide(0.0980665, variables.enY);
                            }

                            else if (variables.numP == 18) // for mh2o
                            {
                                excelFahrenheitInitDivide(98.0665, variables.enY);
                            }

                            else if (variables.numP == 19) // for mmHg
                            {
                                excelFahrenheitInitMultiple(0.75006, variables.enY);
                            }

                            else if (variables.numP == 20) // for psi
                            {
                                excelFahrenheitInitMultiple(0.0145037738, variables.enY);
                            }

                            else if (variables.numP == 21) // for kPa
                            {
                                excelFahrenheitInitDivide(10, variables.enY);
                            }

                            else if (variables.numP == 22) // for MPa
                            {
                                excelFahrenheitInitDivide(10000, variables.enY);
                            }
                            else if (variables.numP == 23) // for iwg
                            {
                                excelFahrenheitInitDivide(2.490889, variables.enY);
                            }

                            else if (variables.numP == 2) // for mbar
                            {
                                double fahrenheit = ((variables.Temperature * 1.8) + 32);
                                variables.records.Rows.Add(productNumber, fahrenheit, variables.Pressure, DateTime.Now);

                                using (var tw = new StreamWriter(path, true))
                                {
                                    if (!firstrecord)
                                    {
                                        if (variables.type == 2)
                                            tw.WriteLine(productNumber + "," + "Temperature" + "," + "Ω" + "," + "Date");
                                        else if (variables.type == 1)
                                            tw.WriteLine(productNumber + "," + "Temperature" + "," + "Pressure" + "," + "Date"); ;
                                        firstrecord = true;
                                    }

                                    gridControl1.FirstDisplayedScrollingRowIndex = gridControl1.RowCount - 1;
                                    tw.WriteLine(productNumber + fahrenheit.ToString() + "," + variables.Pressure.ToString() + "," + variables.Density.ToString() + "," + DateTime.Now.ToString());
                                    tw.Close();
                                }


                                gridControl1.Update();
                            }
                        }
                        else if (variables.numT == 1) // for Celcius
                        {
                            if (variables.numP == 14) // for Bar
                            {
                                excelCelciusInitDivide(1000, variables.enY);
                            }

                            else if (variables.numP == 15) // for Pa
                            {
                                excelCelciusInitMultiple(100, variables.enY);
                            }

                            else if (variables.numP == 16) // for kg/cm2
                            {
                                excelCelciusInitMultiple(0.00102, variables.enY);
                            }

                            else if (variables.numP == 17) // for mmh2o
                            {
                                excelCelciusInitDivide(0.0980665, variables.enY);
                            }

                            else if (variables.numP == 18) // for mh2o
                            {
                                excelCelciusInitDivide(98.0665, variables.enY);
                            }

                            else if (variables.numP == 19) // for mmHg
                            {
                                excelCelciusInitMultiple(0.750062, variables.enY);
                            }

                            else if (variables.numP == 20) // for psi
                            {
                                excelCelciusInitMultiple(0.0145037738, variables.enY);
                            }

                            else if (variables.numP == 21) // for kPa
                            {
                                excelCelciusInitDivide(10, variables.enY);
                            }

                            else if (variables.numP == 22) // for MPa
                            {
                                excelCelciusInitDivide(10000, variables.enY);
                            }

                            else if (variables.numP == 23) // for iwg
                            {
                                excelCelciusInitDivide(2.490889, variables.enY);
                            }


                            else if (variables.numP == 2) // for mbar
                            {

                                variables.records.Rows.Add(productNumber, variables.Temperature, variables.Pressure, DateTime.Now);

                                using (var tw = new StreamWriter(path, true))
                                {
                                    if (!firstrecord)
                                    {
                                        if (variables.type == 2)
                                            tw.WriteLine(productNumber + "," + "Temperature" + "," + "Ω" + "," + "Date");
                                        else if (variables.type == 1)
                                            tw.WriteLine(productNumber + "," + "Temperature" + "," + "Pressure" + "," + "Date");
                                        firstrecord = true;
                                    }

                                    gridControl1.FirstDisplayedScrollingRowIndex = gridControl1.RowCount - 1;
                                    tw.WriteLine(productNumber + variables.Temperature.ToString() + "," + variables.Pressure.ToString() + "," + variables.Density.ToString() + "," + DateTime.Now.ToString());
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

        

        private void FormFlow_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void exportButton_Click_1(object sender, EventArgs e)
        {
            if (variables.status == 66)// && variables.connection
            {
                if (!variables.exportBut)
                {
                    if (variables.numEN == 11)
                    {
                        variables.recordstate = true;
                        MessageBox.Show("Kayıt Başladı ");
                        exportButton.Text = "Kaydı durdur";
                        saveDataButton.Enabled = true;
                        variables.exportBut = true;
                        timer2.Start();
                        variables.comportx = true;
                    }
                    else if (variables.numEN == 10)
                    {
                        variables.recordstate = true;
                        MessageBox.Show("Record Started");
                        saveDataButton.Enabled = true;
                        exportButton.Text = "Stop Collecting Data";
                        variables.exportBut = true;
                        timer2.Start();
                        variables.exportBut = true;
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
            if (variables.status == 66)
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
                        timer1.Interval = timer2.Interval;
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
                        timer1.Interval = timer2.Interval;
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
            if (IsHandleCreated && variables.flowOpen == true)
            {
                this.BeginInvoke(new EventHandler(Show_Data));
            }

            if (variables.tryMe == false)
            {
                variables.tryMe = true;

                if (variables.numEN == 11)
                {
                    intervalNumber.Items.Clear();
                    intervalKind.Items.Clear();
                    intervalNumber.Items.AddRange(new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60 });
                    intervalKind.Items.AddRange(new object[] { "saniye", "dakika", "saat" });
                    intervalNumber.SelectedItem = null;
                    intervalNumber.SelectedIndex = 0;
                    intervalKind.SelectedIndex = 0;
                }
                else if (variables.numEN == 10)
                {
                    intervalNumber.Items.Clear();
                    intervalKind.Items.Clear();
                    intervalNumber.Items.AddRange(new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60 });
                    intervalKind.Items.AddRange(new object[] { "second", "minute", "hour" });
                    intervalNumber.SelectedItem = null;
                    intervalNumber.SelectedIndex = 0;
                    intervalKind.SelectedIndex = 0;
                }


                System.Windows.Threading.Dispatcher.CurrentDispatcher.Invoke((() =>

                {

                    if (variables.numT == 12) // kelvin
                    {
                        solidGauge1.From = 23.15;
                        solidGauge1.To = 1123.15;
                        solidGauge1.Uses360Mode = true;
                        solidGauge2.Value = 0;
                    }

                    else if (variables.numT == 13) // fahrenheit
                    {
                        solidGauge1.From = -418;
                        solidGauge1.To = 1562;
                        solidGauge1.Uses360Mode = true;
                        solidGauge2.Value = 0;
                    }

                    else if (variables.numT == 1) // celcius
                    {
                        solidGauge1.From = -250;
                        solidGauge1.To = 850;
                        solidGauge1.Uses360Mode = true;
                        solidGauge2.Value = -20;
                    }

                    loadGaugeInit();

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
                

                if (!variables.exportBut)
                {
                    exportButton.Text = "Veri Topla";
                }
                if (variables.isClickedFlowing)
                {
                    saveDataButton.Text = rm.GetString("Save Data(xsl)");
                    productButton.Text = rm.GetString("Save Product Number");
                    productGroup.Text = rm.GetString("Product Number(1)");
                    intervalGroup.Text = rm.GetString("İnterval(2)");
                    dataGroup.Text = rm.GetString("Data and Excel(3)");
                    intervalButton.Text = rm.GetString("Save Interval");
                    
                }
                
                

            }
            else if (variables.numEN == 10)
            {
                
                // exportButton.Text = "Collect Data";
                if (!variables.exportBut)
                {
                    exportButton.Text = "Collect Data";
                }
                if (variables.isClickedFlowing)
                {
                    intervalButton.Text = "Save Interval";
                    saveDataButton.Text = "Save Data(xsl)";
                    productButton.Text = "Save Product Number";
                    productGroup.Text = "Product Number(1)";
                    intervalGroup.Text = "İnterval(2)";
                    dataGroup.Text = "Data and Excel(3)";
                    
                }
            }
            if (variables.isClickedFlowing)
            {
                switch (variables.numT)
                {
                    case 12:
                        tunitLabel.Text = "°K";
                        break;
                    case 13:
                        tunitLabel.Text = "°F";
                        break;
                    case 14:
                        tunitLabel.Text = "°C ";
                        break;
                }

                if (variables.type == 1)
                {
                    switch (variables.numP)
                    {
                        case 14:
                            punitLabel.Text = "Bar";
                            punitLabel.Text = "Bar";
                            break;
                        case 15:
                            punitLabel.Text = "Pa";
                            punitLabel.Text = "Pa";
                            break;
                        case 16:
                            punitLabel.Text = "kg/cm2";
                            punitLabel.Text = "kg/cm2";
                            break;
                        case 17:
                            punitLabel.Text = "mmh2o";
                            punitLabel.Text = "mmh2o";
                            break;
                        case 18:
                            punitLabel.Text = "mh2o";
                            punitLabel.Text = "mh2o";
                            break;
                        case 19:
                            punitLabel.Text = "mmHg";
                            punitLabel.Text = "mmHg";
                            break;
                        case 20:
                            punitLabel.Text = "psi";
                            punitLabel.Text = "psi";
                            break;
                        case 21:
                            punitLabel.Text = "kPa";
                            punitLabel.Text = "kPa";
                            break;
                        case 22:
                            punitLabel.Text = "MPa";
                            punitLabel.Text = "MPa";
                            break;
                        case 23:
                            punitLabel.Text = "iwg";
                            punitLabel.Text = "iwg";
                            break;
                        case 2:
                            punitLabel.Text = "mbar";
                            punitLabel.Text = "mbar";
                            break;
                        default:
                            punitLabel.Text = "mbar";
                            punitLabel.Text = "mbar";
                            break;

                    }

                }
                else if (variables.type == 2)
                    punitLabel.Text = "Ω";

                variables.isClickedFlowing = false;
            }

            
        }


        private void timer1_Tick(object sender, EventArgs e)
        {

            if (variables.status == 66 && !variables.connectionLost)
            {

                
                if (variables.numT == 12)
                    {

                        double kelvinS = 273.15;
                    double maksval = 0;
                    double minval = 0;
                    double val = variables.Temperature + kelvinS;
                    if (val > maksval)
                        maksval = val;
                    if(val<minval)
                        minval = val;
                    chart1.Series[0].Points.AddXY(DateTime.Now, val);
                    chart1.Series[0].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
                    chart1.ChartAreas[0].AxisX.IntervalType = (DateTimeIntervalType)DateRangeType.Hour;
                    chart1.ChartAreas[0].AxisX.LabelStyle.Format = "hh:mm";

                    chart1.ChartAreas[0].AxisY.Maximum = maksval+100;
                    chart1.ChartAreas[0].AxisY.Minimum = minval - 100;
                    

                        
                    }
                    else if (variables.numT == 13)
                    {

                    double maksval = 0;
                    double minval = 0;
                    double val = ((variables.Temperature * 1.8) + 32);
                    if (val > maksval)
                        maksval = val;
                    if (val < minval)
                        minval = val;
                    chart1.Series[0].Points.AddXY(DateTime.Now, val);
                    chart1.Series[0].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
                    chart1.ChartAreas[0].AxisX.IntervalType = (DateTimeIntervalType)DateRangeType.Hour;
                    chart1.ChartAreas[0].AxisX.LabelStyle.Format = "hh:mm";

                    chart1.ChartAreas[0].AxisY.Maximum = maksval + 100;
                    chart1.ChartAreas[0].AxisY.Minimum = minval - 100;


                    

                    

                }
                    else if (variables.numT == 1)
                    {

                    double maksval = 0;
                    double minval = 0;
                    double val = variables.Temperature;
                    if (val > maksval)
                        maksval = val;
                    if (val < minval)
                        minval = val;
                    chart1.Series[0].Points.AddXY(DateTime.Now, val);
                    chart1.Series[0].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
                    chart1.ChartAreas[0].AxisX.IntervalType = (DateTimeIntervalType)DateRangeType.Hour;
                    chart1.ChartAreas[0].AxisX.LabelStyle.Format = "hh:mm";


                    chart1.ChartAreas[0].AxisY.Maximum = maksval + 100;
                    chart1.ChartAreas[0].AxisY.Minimum = minval - 100;

                    
                        
                    }
                    if (variables.numP == 14)
                    {
                    double maksval = 0;
                    double minval = 0;
                    double val = variables.Pressure / 1000;
                    if (val > maksval)
                        maksval = val;
                    if (val < minval)
                        minval = val;
                    chart2.Series[0].Points.AddXY(DateTime.Now, val);
                    chart2.Series[0].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
                    chart2.ChartAreas[0].AxisX.IntervalType = (DateTimeIntervalType)DateRangeType.Hour;
                    chart2.ChartAreas[0].AxisX.LabelStyle.Format = "hh:mm";


                    chart2.ChartAreas[0].AxisY.Maximum = maksval + 5;
                    chart2.ChartAreas[0].AxisY.Minimum = minval - 5;
                    

                    }
                    else if (variables.numP == 15)
                    {
                    double maksval = 0;
                    double minval = 0;
                    double val = variables.Pressure * 100;
                    if (val > maksval)
                        maksval = val;
                    if (val < minval)
                        minval = val;
                    chart2.Series[0].Points.AddXY(DateTime.Now, val);
                    chart2.Series[0].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
                    chart2.ChartAreas[0].AxisX.IntervalType = (DateTimeIntervalType)DateRangeType.Hour;
                    chart2.ChartAreas[0].AxisX.LabelStyle.Format = "hh:mm";


                    chart2.ChartAreas[0].AxisY.Maximum = maksval + 100;
                    chart2.ChartAreas[0].AxisY.Minimum = minval - 100;
                    
                }
                    else if (variables.numP == 16)
                    {
                    double maksval = 0;
                    double minval = 0;
                    double val = variables.Pressure * 0.00102;
                    if (val > maksval)
                        maksval = val;
                    if (val < minval)
                        minval = val;
                    chart2.Series[0].Points.AddXY(DateTime.Now, val);
                    chart2.Series[0].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
                    chart2.ChartAreas[0].AxisX.IntervalType = (DateTimeIntervalType)DateRangeType.Hour;
                    chart2.ChartAreas[0].AxisX.LabelStyle.Format = "hh:mm";


                    chart2.ChartAreas[0].AxisY.Maximum = maksval + 100;
                    chart2.ChartAreas[0].AxisY.Minimum = minval - 100;
                    
                }
                    else if (variables.numP == 17)
                    {

                    double maksval = 0;
                    double minval = 0;
                    double val = variables.Pressure / 0.0980665;
                    if (val > maksval)
                        maksval = val;
                    if (val < minval)
                        minval = val;
                    chart2.Series[0].Points.AddXY(DateTime.Now, val);
                    chart2.Series[0].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
                    chart2.ChartAreas[0].AxisX.IntervalType = (DateTimeIntervalType)DateRangeType.Hour;
                    chart2.ChartAreas[0].AxisX.LabelStyle.Format = "hh:mm";


                    chart2.ChartAreas[0].AxisY.Maximum = maksval + 100;
                    chart2.ChartAreas[0].AxisY.Minimum = minval - 100;
                    
                }
                    else if (variables.numP == 18)
                    {

                    double maksval = 0;
                    double minval = 0;
                    double val = variables.Pressure * 0.010197442889221;
                    if (val > maksval)
                        maksval = val;
                    if (val < minval)
                        minval = val;
                    chart2.Series[0].Points.AddXY(DateTime.Now, val);
                    chart2.Series[0].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
                    chart2.ChartAreas[0].AxisX.IntervalType = (DateTimeIntervalType)DateRangeType.Hour;
                    chart2.ChartAreas[0].AxisX.LabelStyle.Format = "hh:mm";


                    chart2.ChartAreas[0].AxisY.Maximum = maksval + 100;
                    chart2.ChartAreas[0].AxisY.Minimum = minval - 100;
                    

                }
                    else if (variables.numP == 19)
                    {
                    double maksval = 0;
                    double minval = 0;
                    double val = variables.Pressure * 0.750062;
                    if (val > maksval)
                        maksval = val;
                    if (val < minval)
                        minval = val;
                    chart2.Series[0].Points.AddXY(DateTime.Now, val);
                    chart2.Series[0].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
                    chart2.ChartAreas[0].AxisX.IntervalType = (DateTimeIntervalType)DateRangeType.Hour;
                    chart2.ChartAreas[0].AxisX.LabelStyle.Format = "hh:mm";


                    chart2.ChartAreas[0].AxisY.Maximum = maksval + 100;
                    chart2.ChartAreas[0].AxisY.Minimum = minval - 100;
                   

                }
                    else if (variables.numP == 20)
                    {

                    double maksval = 0;
                    double minval = 0;
                    double val = variables.Pressure * 0.0145037738;
                    if (val > maksval)
                        maksval = val;
                    if (val < minval)
                        minval = val;
                    chart2.Series[0].Points.AddXY(DateTime.Now, val);
                    chart2.Series[0].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
                    chart2.ChartAreas[0].AxisX.IntervalType = (DateTimeIntervalType)DateRangeType.Hour;
                    chart2.ChartAreas[0].AxisX.LabelStyle.Format = "hh:mm";


                    chart2.ChartAreas[0].AxisY.Maximum = maksval + 100;
                    chart2.ChartAreas[0].AxisY.Minimum = minval - 100;
                    

                }
                    else if (variables.numP == 21)
                    {
                    double maksval = 0;
                    double minval = 0;
                    double val = variables.Pressure / 100000;
                    if (val > maksval)
                        maksval = val;
                    if (val < minval)
                        minval = val;
                    chart2.Series[0].Points.AddXY(DateTime.Now, val);
                    chart2.Series[0].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
                    chart2.ChartAreas[0].AxisX.IntervalType = (DateTimeIntervalType)DateRangeType.Hour;
                    chart2.ChartAreas[0].AxisX.LabelStyle.Format = "hh:mm";


                    chart2.ChartAreas[0].AxisY.Maximum = maksval + 1;
                    chart2.ChartAreas[0].AxisY.Minimum = minval - 1;
                    

                }
                    else if (variables.numP == 22)
                    {
                    double maksval = 0;
                    double minval = 0;
                    double val = variables.Pressure / 100000000;
                    if (val > maksval)
                        maksval = val;
                    if (val < minval)
                        minval = val;
                    chart2.Series[0].Points.AddXY(DateTime.Now, val);
                    chart2.Series[0].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
                    chart2.ChartAreas[0].AxisX.IntervalType = (DateTimeIntervalType)DateRangeType.Hour;
                    chart2.ChartAreas[0].AxisX.LabelStyle.Format = "hh:mm";


                    chart2.ChartAreas[0].AxisY.Maximum = maksval + 1;
                    chart2.ChartAreas[0].AxisY.Minimum = minval - 1;
                    

                }
                    else if (variables.numP == 23)
                    {
                    double maksval = 0;
                    double minval = 0;
                    double val = variables.Pressure / 2.490889;
                    if (val > maksval)
                        maksval = val;
                    if (val < minval)
                        minval = val;
                    chart2.Series[0].Points.AddXY(DateTime.Now, val);
                    chart2.Series[0].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
                    chart2.ChartAreas[0].AxisX.IntervalType = (DateTimeIntervalType)DateRangeType.Hour;
                    chart2.ChartAreas[0].AxisX.LabelStyle.Format = "hh:mm";


                    chart2.ChartAreas[0].AxisY.Maximum = maksval + 100;
                    chart2.ChartAreas[0].AxisY.Minimum = minval - 100;
                    
                }
                    else if (variables.numP == 2)
                    {
                    double maksval = 0;
                    double minval = 0;
                    double val = variables.Pressure;
                    if (val > maksval)
                        maksval = val;
                    if (val < minval)
                        minval = val;
                    chart2.Series[0].Points.AddXY(DateTime.Now, Math.Round(val,0));
                    chart2.Series[0].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
                    chart2.ChartAreas[0].AxisX.IntervalType = (DateTimeIntervalType)DateRangeType.Hour;
                    chart2.ChartAreas[0].AxisX.LabelStyle.Format = "hh:mm";


                    chart2.ChartAreas[0].AxisY.Maximum = maksval + 100;
                    chart2.ChartAreas[0].AxisY.Minimum = minval - 100;
                    
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

        private void chart2_Click_1(object sender, EventArgs e)
        {

        }

        private void solidGauge1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void punitLabel_Click(object sender, EventArgs e)
        {

        }

        public void Show_Data(object sender, EventArgs e)


        {
            if (variables.updateData == true)
            {
                if (variables.numT == 12) // for kelvin
                {
                    
                    if (!variables.connectionLost)
                        solidGauge1.Value = variables.Temperature + 273.15;
                    else
                        solidGauge1.Value = -999;

                    showDataInit();

                }
                else if (variables.numT == 13)// for fahrenheit
                {
                    if (!variables.connectionLost)
                        solidGauge1.Value = (variables.Temperature * 1.8) + 32;
                    else
                        solidGauge1.Value = -999;
                    showDataInit();
                }
                else if (variables.numT == 1) // for celcius
                {
                    if (!variables.connectionLost)
                        solidGauge1.Value = variables.Temperature;
                    else
                        solidGauge1.Value = -999;
                    showDataInit();
                }

            }
        }


    }
}
