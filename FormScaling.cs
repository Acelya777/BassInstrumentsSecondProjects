using System;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace BASSCOMPORT
{
    public partial class FormScaling : Form
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

        string dataminScale, datamaxScale, dataminSetScale, datamaxSetScale;
        public static ResourceManager rm = new ResourceManager("BASSCOMPORT.tr_local", Assembly.GetExecutingAssembly());
        public static FormScaling client;
        public FormScaling()
        {
            InitializeComponent();

            
            IntPtr ptr4 = CreateRoundRectRgn(0, 0, scaleButton.Width, scaleButton.Height, 15, 15);
            scaleButton.Region = System.Drawing.Region.FromHrgn(ptr4);
            DeleteObject(ptr4);

            
            scaleButton.NormalBadgeColor = System.Drawing.Color.Red;

            //richTextBox1.Font = new System.Drawing.Font("Arial", 15F);
            //richTextBox2.Font = new System.Drawing.Font("Arial", 15F);
            groupBox1.Font = new System.Drawing.Font("Arial", 13F);
            groupBox2.Font = new System.Drawing.Font("Arial", 12F);
            if (variables.numEN == 11)
            {
               
                scaleButton.Text = rm.GetString("CHANGE");
                
               // guideGroupBox.Text = rm.GetString("Guide");

                

                if (variables.numP == 14)
                {
                    
                    label16.Text = rm.GetString("Ayarlanacak minScale") + "(Bar)";
                    label18.Text = rm.GetString("Ayarlanacak maxScale") + "(Bar)";
                }
                else if (variables.numP == 15)
                {
                    
                    label16.Text = rm.GetString("Ayarlanacak minScale") + "(Pa)";
                    label18.Text = rm.GetString("Ayarlanacak maxScale") + "(Pa)";
                }
                else if (variables.numP == 16)
                {
                   
                    label16.Text = rm.GetString("Ayarlanacak minScale") + "(kg/cm2)";
                    label18.Text = rm.GetString("Ayarlanacak maxScale") + "(kg/cm2)";
                }
                else if (variables.numP == 17)
                {
                    
                    label16.Text = rm.GetString("Ayarlanacak minScale") + "(mmh2o)";
                    label18.Text = rm.GetString("Ayarlanacak maxScale") + "(mmh2o)";
                }
                else if (variables.numP == 18)
                {
                    label16.Text = rm.GetString("Ayarlanacak minScale") + "(mh2o)";
                    label18.Text = rm.GetString("Ayarlanacak maxScale") + "(mh2o)";
                }
                else if (variables.numP == 19)
                {
                   
                    label16.Text = rm.GetString("Ayarlanacak minScale") + "(mmHg)";
                    label18.Text = rm.GetString("Ayarlanacak maxScale") + "(mmHg)";
                }
                else if (variables.numP == 20)
                {
                    
                    label16.Text = rm.GetString("Ayarlanacak minScale") + "(psi)";
                    label18.Text = rm.GetString("Ayarlanacak maxScale") + "(psi)";
                }
                else if (variables.numP == 21)
                {
                    
                    label16.Text = rm.GetString("Ayarlanacak minScale") + "(kPa)";
                    label18.Text = rm.GetString("Ayarlanacak maxScale") + "(kPa)";
                }
                else if (variables.numP == 22)
                {
                    
                    label16.Text = rm.GetString("Ayarlanacak minScale") + "(MPa)";
                    label18.Text = rm.GetString("Ayarlanacak maxScale") + "(MPa)";
                }
                else if (variables.numP == 23)
                {
                   
                    label16.Text = rm.GetString("Ayarlanacak minScale") + "(iwg)";
                    label18.Text = rm.GetString("Ayarlanacak maxScale") + "(iwg)";
                }
                else
                {
                    
                    label16.Text = rm.GetString("Ayarlanacak minScale") + "(mBar)";
                    label18.Text = rm.GetString("Ayarlanacak maxScale") + "(mBar)";

                }

            }

            else if(variables.numEN ==10)
            {


                if (variables.numP == 14)
                {
                   
                    label16.Text = "minScale(Bar) to set";
                    label18.Text = "maxScale(Bar) to set";
                }
                else if (variables.numP == 15)
                {
                    
                    label16.Text = "minScale(Pa) to set";
                    label18.Text = "maxScale(Pa) to set";
                }
                else if (variables.numP == 16)
                {
                   
                    label16.Text = "minScale(kg/cm2) to set";
                    label18.Text = "maxScale(kg/cm2) to set";
                }
                else if (variables.numP == 17)
                {
                    
                    label16.Text = "minScale(mmh2o) to set";
                    label18.Text = "maxScale(mmh2o) to set";
                }
                else if (variables.numP == 18)
                {
                    
                    label16.Text = "minScale(mh2o) to set";
                    label18.Text = "maxScale(mh2o) to set";
                }
                else if (variables.numP == 19)
                {
                    
                    label16.Text = "minScale(mmHg) to set";
                    label18.Text = "maxScale(mmHg) to set";
                }
                else if (variables.numP == 20)
                {
                   
                    label16.Text = "minScale(psi) to set";
                    label18.Text = "maxScale(psi) to set";
                }
                else if (variables.numP == 21)
                {
                    
                    label16.Text = "minScale(kPa) to set";
                    label18.Text = "maxScale(kPa) to set";
                }
                else if (variables.numP == 22)
                {
                   
                    label16.Text = "minScale(MPa) to set";
                    label18.Text = "maxScale(MPa) to set";
                }
                else if (variables.numP == 23)
                {
                   
                    label16.Text = "minScale(iwg) to set";
                    label18.Text = "maxScale(iwg) to set";
                }
                else
                {
                    
                    label16.Text = "minScale(mBar) to set";
                    label18.Text = "maxScale(mBar) to set";

                }
            }



        }

        private void FormScaling_Load(object sender, EventArgs e)
        {


            serialPort1 = new SerialPort();
            serialPort1 = variables.serialPort;
            //serialPort1.DataReceived += new SerialDataReceivedEventHandler(sp_DataReceived);
            progressBar1.Maximum = 130;
            //metroSetDivider1.ForeColor = System.Drawing.Color.White;
            //metroSetDivider2.ForeColor = System.Drawing.Color.White;

            /*if (variables.numEN == 11)
            {
                richTextBox2.Text = "Sonra ölçeklendirmek istediğiniz minimum ve maksimum değerleri giriniz ve DEĞİŞTİR butonuna tıklayınız. Lütfen 'OK' işaretini görene kadar bekleyiniz.";
                richTextBox1.Text = "Lütfen ürün etiketi üzerinde bulunan ölçeklendirme aralığını kontrol ediniz. Ardından minimum ve maksimum değerleri belirtilen kutucuklara giriniz ve AYARLA butonuna tıklayınız. Bu şekilde cihaza referans ölçeklendirme aralığı vermiş oluyoruz. ";
            }
            else if ( variables.numEN == 10)
            {
               
                richTextBox2.Text = "After that, enter the minimum and maximum values you want to scale, click the CHANGE button . Please wait until you see the 'OK' tick.";
                richTextBox1.Text = "Please check the scaling range on product label. Then enter the minimum and maximum values and click to SET button. In this way, we are saying the device that what's its reference scaling range.";
            }*/


            
            minScaleTextBox.Enabled = false;
            maxScaleTextBox.Enabled = false;
            variables.comportx = true;
        }

        private void scaleButton_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                if (minScaleTextBox.Text.Trim() == string.Empty || maxScaleTextBox.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please enter something in the textbox");
                    return; // return because we don't want to run normal code of buton click
                }
                else
                {

                 

                    string tempMinn;
                    string tempMaxx;
                    double minxx;
                    double maxxx;

                    if (variables.numP == 14)
                    {
                        double minScaleBar = Convert.ToDouble(minScaleTextBox.Text);
                        double maxScaleBar = Convert.ToDouble(maxScaleTextBox.Text);

                        if (minScaleBar < -1 || maxScaleBar > 1000)
                        {
                            MessageBox.Show("The value must be between -1 and 1000 ");
                            minScaleTextBox.Clear();
                            maxScaleTextBox.Clear();
                            return;


                        }
                        else
                        {
                            if (MessageBox.Show("Please confirm before proceed" + "\n" + "Do you want to Continue ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

                            {



                                tempMinn = minScaleTextBox.Text;
                                tempMaxx = maxScaleTextBox.Text;

                                minxx = Convert.ToDouble(tempMinn);
                                maxxx = Convert.ToDouble(tempMaxx);

                                minxx *= 1000;
                                maxxx *= 1000;

                                dataminScale = minxx.ToString();
                                datamaxScale = maxxx.ToString();

                                label3.Text = maxScaleTextBox.Text;
                                label4.Text = minScaleTextBox.Text;

                                serialPort1.WriteLine("?" + dataminScale + "?" + datamaxScale + "?");


                                timer1.Interval = 1000;//1 second
                                timer1.Tick += new System.EventHandler(timer1_Tick);
                                timer1.Start();

                                minScaleTextBox.Clear();
                                maxScaleTextBox.Clear();

                                
                                

                            }

                        }

                    }

                    else if (variables.numP == 15)
                    {
                        double minScaleBar = Convert.ToDouble(minScaleTextBox.Text);
                        double maxScaleBar = Convert.ToDouble(maxScaleTextBox.Text);

                        if (minScaleBar < -100000 || maxScaleBar > 100000000)
                        {
                            MessageBox.Show("The value must be between -100000 and 100000000 ");
                            minScaleTextBox.Clear();
                            maxScaleTextBox.Clear();
                            return;


                        }
                        else
                        {
                            if (MessageBox.Show("Please confirm before proceed" + "\n" + "Do you want to Continue ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

                            {

                               

                                tempMinn = minScaleTextBox.Text;
                                tempMaxx = maxScaleTextBox.Text;

                                minxx = Convert.ToDouble(tempMinn);
                                maxxx = Convert.ToDouble(tempMaxx);

                                minxx /= 100;
                                maxxx /= 100;

                                dataminScale = minxx.ToString();
                                datamaxScale = maxxx.ToString();

                                label3.Text = maxScaleTextBox.Text;
                                label4.Text = minScaleTextBox.Text;

                                serialPort1.WriteLine("?" + dataminScale + "?" + datamaxScale + "?");

                                timer1.Interval = 1000;//1 second
                                timer1.Tick += new System.EventHandler(timer1_Tick);
                                timer1.Start();

                                minScaleTextBox.Clear();
                                maxScaleTextBox.Clear();

                                
                               
                               

                            }

                        }

                    }

                    else if (variables.numP == 16)
                    {
                        double minScaleBar = Convert.ToDouble(minScaleTextBox.Text);
                        double maxScaleBar = Convert.ToDouble(maxScaleTextBox.Text);

                        if (minScaleBar < -1 || maxScaleBar > 1019)
                        {
                            MessageBox.Show("The value must be between -1 and 1019 ");
                            minScaleTextBox.Clear();
                            maxScaleTextBox.Clear();
                            return;


                        }
                        else
                        {
                            if (MessageBox.Show("Please confirm before proceed" + "\n" + "Do you want to Continue ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

                            {

                                
                                tempMinn = minScaleTextBox.Text;
                                tempMaxx = maxScaleTextBox.Text;

                                minxx = Convert.ToDouble(tempMinn);
                                maxxx = Convert.ToDouble(tempMaxx);

                                minxx /= 0.00102;
                                maxxx /= 0.00102;

                                dataminScale = minxx.ToString();
                                datamaxScale = maxxx.ToString();

                                label3.Text = maxScaleTextBox.Text;
                                label4.Text = minScaleTextBox.Text;

                                serialPort1.WriteLine("?" + dataminScale + "?" + datamaxScale + "?");

                                timer1.Interval = 1000;//1 second
                                timer1.Tick += new System.EventHandler(timer1_Tick);
                                timer1.Start();


                                minScaleTextBox.Clear();
                                maxScaleTextBox.Clear();

                                
                               

                            }

                        }

                    }

                    else if (variables.numP == 17)
                    {
                        double minScaleBar = Convert.ToDouble(minScaleTextBox.Text);
                        double maxScaleBar = Convert.ToDouble(maxScaleTextBox.Text);

                        if (minScaleBar < -10197 || maxScaleBar > 10197162)
                        {
                            MessageBox.Show("The value must be between -10197 and 10197162 ");
                            minScaleTextBox.Clear();
                            maxScaleTextBox.Clear();
                            return;


                        }
                        else
                        {
                            if (MessageBox.Show("Please confirm before proceed" + "\n" + "Do you want to Continue ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

                            {

                                

                                tempMinn = minScaleTextBox.Text;
                                tempMaxx = maxScaleTextBox.Text;

                                minxx = Convert.ToDouble(tempMinn);
                                maxxx = Convert.ToDouble(tempMaxx);

                                minxx *= 0.0980665;
                                maxxx *= 0.0980665;

                                dataminScale = minxx.ToString();
                                datamaxScale = maxxx.ToString();

                                label3.Text = maxScaleTextBox.Text;
                                label4.Text = minScaleTextBox.Text;

                                serialPort1.WriteLine("?" + dataminScale + "?" + datamaxScale + "?");

                                timer1.Interval = 1000;//1 second
                                timer1.Tick += new System.EventHandler(timer1_Tick);
                                timer1.Start();

                                minScaleTextBox.Clear();
                                maxScaleTextBox.Clear();

                                
                                

                            }

                        }

                    }

                    else if (variables.numP == 18)
                    {
                        double minScaleBar = Convert.ToDouble(minScaleTextBox.Text);
                        double maxScaleBar = Convert.ToDouble(maxScaleTextBox.Text);

                        if (minScaleBar < -10 || maxScaleBar > 10197162)
                        {
                            MessageBox.Show("The value must be between -10 and 10197 ");
                            minScaleTextBox.Clear();
                            maxScaleTextBox.Clear();
                            return;


                        }
                        else
                        {
                            if (MessageBox.Show("Please confirm before proceed" + "\n" + "Do you want to Continue ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

                            {

                               

                                tempMinn = minScaleTextBox.Text;
                                tempMaxx = maxScaleTextBox.Text;

                                minxx = Convert.ToDouble(tempMinn);
                                maxxx = Convert.ToDouble(tempMaxx);

                                minxx *= 98.0665;
                                maxxx *= 98.0665;

                                dataminScale = minxx.ToString();
                                datamaxScale = maxxx.ToString();

                                label3.Text = maxScaleTextBox.Text;
                                label4.Text = minScaleTextBox.Text;

                                serialPort1.WriteLine("?" + dataminScale + "?" + datamaxScale + "?");

                                timer1.Interval = 1000;//1 second
                                timer1.Tick += new System.EventHandler(timer1_Tick);
                                timer1.Start();

                                minScaleTextBox.Clear();
                                maxScaleTextBox.Clear();

                                
                               
                                

                            }

                        }

                    }
                    else if (variables.numP == 19)
                    {
                        double minScaleBar = Convert.ToDouble(minScaleTextBox.Text);
                        double maxScaleBar = Convert.ToDouble(maxScaleTextBox.Text);

                        if (minScaleBar < -750 || maxScaleBar > 750061)
                        {
                            MessageBox.Show("The value must be between -750 and 750061 ");
                            minScaleTextBox.Clear();
                            maxScaleTextBox.Clear();
                            return;


                        }
                        else
                        {
                            if (MessageBox.Show("Please confirm before proceed" + "\n" + "Do you want to Continue ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

                            {

                               

                                tempMinn = minScaleTextBox.Text;
                                tempMaxx = maxScaleTextBox.Text;

                                minxx = Convert.ToDouble(tempMinn);
                                maxxx = Convert.ToDouble(tempMaxx);

                                minxx /= 0.750062;
                                maxxx /= 0.750062;

                                dataminScale = minxx.ToString();
                                datamaxScale = maxxx.ToString();

                                label3.Text = maxScaleTextBox.Text;
                                label4.Text = minScaleTextBox.Text;

                                serialPort1.WriteLine("?" + dataminScale + "?" + datamaxScale + "?");

                                timer1.Interval = 1000;//1 second
                                timer1.Tick += new System.EventHandler(timer1_Tick);
                                timer1.Start();

                                minScaleTextBox.Clear();
                                maxScaleTextBox.Clear();

                                
                               
                               

                            }

                        }

                    }
                    else if (variables.numP == 20)
                    {
                        double minScaleBar = Convert.ToDouble(minScaleTextBox.Text);
                        double maxScaleBar = Convert.ToDouble(maxScaleTextBox.Text);

                        if (minScaleBar < -15 || maxScaleBar > 14500)
                        {
                            MessageBox.Show("The value must be between -15 and 14500 ");
                            minScaleTextBox.Clear();
                            maxScaleTextBox.Clear();
                            return;


                        }
                        else
                        {
                            if (MessageBox.Show("Please confirm before proceed" + "\n" + "Do you want to Continue ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

                            {

                                

                                tempMinn = minScaleTextBox.Text;
                                tempMaxx = maxScaleTextBox.Text;

                                minxx = Convert.ToDouble(tempMinn);
                                maxxx = Convert.ToDouble(tempMaxx);

                                minxx /= 0.0145037738;
                                maxxx /= 0.0145037738;

                                dataminScale = minxx.ToString();
                                datamaxScale = maxxx.ToString();

                                label3.Text = maxScaleTextBox.Text;
                                label4.Text = minScaleTextBox.Text;

                                serialPort1.WriteLine("?" + dataminScale + "?" + datamaxScale + "?");

                                timer1.Interval = 1000;//1 second
                                timer1.Tick += new System.EventHandler(timer1_Tick);
                                timer1.Start();

                                minScaleTextBox.Clear();
                                maxScaleTextBox.Clear();

                                
                               
                                

                            }

                        }

                    }
                    else if (variables.numP == 21)
                    {
                        double minScaleBar = Convert.ToDouble(minScaleTextBox.Text);
                        double maxScaleBar = Convert.ToDouble(maxScaleTextBox.Text);

                        if (minScaleBar < -100 || maxScaleBar > 100000)
                        {
                            MessageBox.Show("The value must be between -100  and 100000 ");
                            minScaleTextBox.Clear();
                            maxScaleTextBox.Clear();
                            return;


                        }
                        else
                        {
                            if (MessageBox.Show("Please confirm before proceed" + "\n" + "Do you want to Continue ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

                            {

                                

                                tempMinn = minScaleTextBox.Text;
                                tempMaxx = maxScaleTextBox.Text;

                                minxx = Convert.ToDouble(tempMinn);
                                maxxx = Convert.ToDouble(tempMaxx);

                                minxx *= 10;
                                maxxx *= 10;

                                dataminScale = minxx.ToString();
                                datamaxScale = maxxx.ToString();

                                label3.Text = maxScaleTextBox.Text;
                                label4.Text = minScaleTextBox.Text;

                                serialPort1.WriteLine("?" + dataminScale + "?" + datamaxScale + "?");

                                timer1.Interval = 1000;//1 second
                                timer1.Tick += new System.EventHandler(timer1_Tick);
                                timer1.Start();

                                minScaleTextBox.Clear();
                                maxScaleTextBox.Clear();

                                

                                

                            }

                        }

                    }
                    else if (variables.numP == 22)
                    {
                        double minScaleBar = Convert.ToDouble(minScaleTextBox.Text);
                        double maxScaleBar = Convert.ToDouble(maxScaleTextBox.Text);

                        if (minScaleBar < -0.01|| maxScaleBar >100)
                        {
                            MessageBox.Show("The value must be between -0.01 and 100 ");
                            minScaleTextBox.Clear();
                            maxScaleTextBox.Clear();
                            return;


                        }
                        else
                        {
                            if (MessageBox.Show("Please confirm before proceed" + "\n" + "Do you want to Continue ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

                            {

                                

                                tempMinn = minScaleTextBox.Text;
                                tempMaxx = maxScaleTextBox.Text;

                                minxx = Convert.ToDouble(tempMinn);
                                maxxx = Convert.ToDouble(tempMaxx);

                                minxx *= 10000;
                                maxxx *= 10000;

                                dataminScale = minxx.ToString();
                                datamaxScale = maxxx.ToString();

                                label3.Text = maxScaleTextBox.Text;
                                label4.Text = minScaleTextBox.Text;

                                serialPort1.WriteLine("?" + dataminScale + "?" + datamaxScale + "?");

                                timer1.Interval = 1000;//1 second
                                timer1.Tick += new System.EventHandler(timer1_Tick);
                                timer1.Start();

                                minScaleTextBox.Clear();
                                maxScaleTextBox.Clear();

                                
                             
                                

                            }

                        }

                    }
                    else if (variables.numP == 23)
                    {
                        double minScaleBar = Convert.ToDouble(minScaleTextBox.Text);
                        double maxScaleBar = Convert.ToDouble(maxScaleTextBox.Text);

                        if (minScaleBar < -402  || maxScaleBar > 401464)
                        {
                            MessageBox.Show("The value must be between -402 and 401464 ");
                            minScaleTextBox.Clear();
                            maxScaleTextBox.Clear();
                            return;


                        }
                        else
                        {
                            if (MessageBox.Show("Please confirm before proceed" + "\n" + "Do you want to Continue ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

                            {



                                tempMinn = minScaleTextBox.Text;
                                tempMaxx = maxScaleTextBox.Text;

                                minxx = Convert.ToDouble(tempMinn);
                                maxxx = Convert.ToDouble(tempMaxx);

                                minxx *= 2.490889;
                                maxxx *= 2.490889;

                                dataminScale = minxx.ToString();
                                datamaxScale = maxxx.ToString();

                                label3.Text = maxScaleTextBox.Text;
                                label4.Text = minScaleTextBox.Text;

                                serialPort1.WriteLine("?" + dataminScale + "?" + datamaxScale + "?");

                                timer1.Interval = 1000;//1 second
                                timer1.Tick += new System.EventHandler(timer1_Tick);
                                timer1.Start();

                                minScaleTextBox.Clear();
                                maxScaleTextBox.Clear();

                                
                             
                                

                            }

                        }

                    }

                    else //for mBar
                    {
                        double minScaleBar = Convert.ToDouble(minScaleTextBox.Text);
                        double maxScaleBar = Convert.ToDouble(maxScaleTextBox.Text);

                        if (minScaleBar < -1000 || maxScaleBar > 1000000)
                        {
                            MessageBox.Show("The value must be between -1000 and 1000000 ");
                            minScaleTextBox.Clear();
                            maxScaleTextBox.Clear();
                            return;


                        }
                        else
                        {
                            if (MessageBox.Show("Please confirm before proceed" + "\n" + "Do you want to Continue ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

                            {

                                

                                dataminScale = minScaleTextBox.Text;
                                datamaxScale = maxScaleTextBox.Text;



                                label3.Text = maxScaleTextBox.Text;
                                label4.Text = minScaleTextBox.Text;

                                serialPort1.WriteLine("?" + dataminScale + "?" + datamaxScale + "?");

                                timer1.Interval = 1000;//1 second
                                timer1.Tick += new System.EventHandler(timer1_Tick);
                                timer1.Start();

                                minScaleTextBox.Clear();
                                maxScaleTextBox.Clear();

                                
                                

                            }

                        }

                    }

                    
                    minScaleTextBox.Enabled = false;
                    maxScaleTextBox.Enabled = false;

                }


            }
            else
            {
                MessageBox.Show("You have not been communicated!");
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void minScaleSetTextBox_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value == progressBar1.Maximum)
            {
                timer1.Stop();
            }

            else
            {
                pictureBox1.Image = BASSCOMPORT.Properties.Resources.output_onlinegiftools;
                pictureBox2.Image = BASSCOMPORT.Properties.Resources.output_onlinegiftools;
                progressBar1.Value += 13;
                if(progressBar1.Value == progressBar1.Maximum)
                {
                    pictureBox1.Image = BASSCOMPORT.Properties.Resources.ok;
                    pictureBox2.Image = BASSCOMPORT.Properties.Resources.ok;
                }

            }

                
            

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                if (variables.lowRange != 0 && variables.upperRange != 0)
                {
                    if (variables.numP == 14)
                    {

                        label5.Text = variables.lowRange.ToString();
                        label7.Text = variables.upperRange.ToString();

                    }
                    else if (variables.numP == 15)
                    {
                        double lowRange = variables.lowRange * 100000;
                        double upperRange = variables.upperRange * 100000;

                        label5.Text = lowRange.ToString();
                        label7.Text = upperRange.ToString();

                    }
                    else if (variables.numP == 16)
                    {
                        double lowRange = variables.lowRange * 1.02;
                        double upperRange = variables.upperRange * 1.02;

                        label5.Text = lowRange.ToString();
                        label7.Text = upperRange.ToString();


                    }
                    else if (variables.numP == 17)
                    {
                        double lowRange = variables.lowRange / 0.0000980665;
                        double upperRange = variables.upperRange / 0.0000980665;

                        label5.Text = lowRange.ToString();
                        label7.Text = upperRange.ToString();


                    }
                    else if (variables.numP == 18)
                    {

                        double lowRange = variables.lowRange / 0.0980665;
                        double upperRange = variables.upperRange / 0.0980665;

                        label5.Text = lowRange.ToString();
                        label7.Text = upperRange.ToString();

                    }
                    else if (variables.numP == 19)
                    {
                        double lowRange = variables.lowRange * 750.061;
                        double upperRange = variables.upperRange * 750.061;

                        label5.Text = lowRange.ToString();
                        label7.Text = upperRange.ToString();


                    }
                    else if (variables.numP == 20)
                    {
                        double lowRange = variables.lowRange * 14.5037738;
                        double upperRange = variables.upperRange * 14.5037738;

                        label5.Text = lowRange.ToString();
                        label7.Text = upperRange.ToString();


                    }
                    else if (variables.numP == 21)
                    {
                        double lowRange = variables.lowRange * 100;
                        double upperRange = variables.upperRange * 100;

                        label5.Text = lowRange.ToString();
                        label7.Text = upperRange.ToString();


                    }
                    else if (variables.numP == 22)
                    {
                        double lowRange = variables.lowRange * 0.1;
                        double upperRange = variables.upperRange * 0.1;

                        label5.Text = lowRange.ToString();
                        label7.Text = upperRange.ToString();

                    }
                    else if (variables.numP == 23)
                    {
                        double lowRange = variables.lowRange * 401.325981;
                        double upperRange = variables.upperRange * 401.325981;

                        label5.Text = lowRange.ToString();
                        label7.Text = upperRange.ToString();


                    }

                    else if (variables.numP == 2)
                    {
                        double lowRange = variables.lowRange * 1000;
                        double upperRange = variables.upperRange * 1000;

                        label5.Text = lowRange.ToString();
                        label7.Text = upperRange.ToString();


                    }
                }
                
            }

            

            if (variables.numEN == 11)
            {
                label1.Text = "Çıkış :";
                label2.Text = "Aralık :";
                scaleButton.Text = rm.GetString("CHANGE");
                pictureBox3.Image = BASSCOMPORT.Properties.Resources.tr;
                //groupBox1.Text = rm.GetString("Scaling");
                // guideGroupBox.Text = rm.GetString("Guide");
                // richTextBox2.Text = "Sonra ölçeklendirmek istediğiniz minimum ve maksimum değerleri giriniz ve DEĞİŞTİR butonuna tıklayınız. Lütfen 'OK' işaretini görene kadar bekleyiniz.";
                //richTextBox1.Text = "Lütfen ürün etiketi üzerinde bulunan ölçeklendirme aralığını kontrol ediniz. Ardından minimum ve maksimum değerleri belirtilen kutucuklara giriniz ve AYARLA butonuna tıklayınız. Bu şekilde cihaza referans ölçeklendirme aralığı vermiş oluyoruz. ";

                if (variables.data_identify == 0)
                {
                    label6.Text = "4-20mA";
                }
                else if (variables.data_identify == 1)
                {
                    label6.Text = "0-10V";
                }

               


                if (variables.numP == 14)
                {
                   
                    label16.Text = rm.GetString("Ayarlanacak minScale") + "(Bar)";
                    label18.Text = rm.GetString("Ayarlanacak maxScale") + "(Bar)";
                }
                else if (variables.numP == 15)
                {
                   
                    label16.Text = rm.GetString("Ayarlanacak minScale") + "(Pa)";
                    label18.Text = rm.GetString("Ayarlanacak maxScale") + "(Pa)";
                }
                else if (variables.numP == 16)
                {
                   
                    label16.Text = rm.GetString("Ayarlanacak minScale") + "(kg/cm2)";
                    label18.Text = rm.GetString("Ayarlanacak maxScale") + "(kg/cm2)";
                }
                else if (variables.numP == 17)
                {
                   
                    label16.Text = rm.GetString("Ayarlanacak minScale") + "(mmh2o)";
                    label18.Text = rm.GetString("Ayarlanacak maxScale") + "(mmh2o)";
                }
                else if (variables.numP == 18)
                {
                    label16.Text = rm.GetString("Ayarlanacak minScale") + "(mh2o)";
                    label18.Text = rm.GetString("Ayarlanacak maxScale") + "(mh2o)";
                }
                else if (variables.numP == 19)
                {
                    label16.Text = rm.GetString("Ayarlanacak minScale") + "(mmHg)";
                    label18.Text = rm.GetString("Ayarlanacak maxScale") + "(mmHg)";
                }
                else if (variables.numP == 20)
                {
                   
                    label16.Text = rm.GetString("Ayarlanacak minScale") + "(psi)";
                    label18.Text = rm.GetString("Ayarlanacak maxScale") + "(psi)";
                }
                else if (variables.numP == 21)
                {
                   
                    label16.Text = rm.GetString("Ayarlanacak minScale") + "(kPa)";
                    label18.Text = rm.GetString("Ayarlanacak maxScale") + "(kPa)";
                }
                else if (variables.numP == 22)
                {
                   
                    label16.Text = rm.GetString("Ayarlanacak minScale") + "(MPa)";
                    label18.Text = rm.GetString("Ayarlanacak maxScale") + "(MPa)";
                }
                else if (variables.numP == 23)
                {
                    
                    label16.Text = rm.GetString("Ayarlanacak minScale") + "(iwg)";
                    label18.Text = rm.GetString("Ayarlanacak maxScale") + "(iwg)";
                }
                else
                {
                   
                    label16.Text = rm.GetString("Ayarlanacak minScale") + "(mBar)";
                    label18.Text = rm.GetString("Ayarlanacak maxScale") + "(mBar)";

                }

            }

            else if (variables.numEN == 10)
            {
                if (variables.data_identify == 0)
                {
                    label6.Text = "4-20mA";
                }
                else if (variables.data_identify == 1)
                {
                    label6.Text = "0-10V";
                }

                label5.Text = variables.lowRange.ToString();
                label7.Text = variables.upperRange.ToString();

                label1.Text = "Output :";
                label2.Text = "Range :";
                scaleButton.Text = "SCALE";
                pictureBox3.Image = BASSCOMPORT.Properties.Resources.eng;
                //groupBox1.Text = "Scaling";
                // guideGroupBox.Text = "Guide";

                // richTextBox2.Text = "After that, enter the minimum and maximum values you want to scale, click the CHANGE button . Please wait until you see the 'OK' tick.";
                //richTextBox1.Text = "Please check the scaling range on product label. Then enter the minimum and maximum values and click to SET button. In this way, we are saying the device that what's its reference scaling range.";

                if (variables.numP == 14)
                {
                    
                    label16.Text = "minScale(Bar) to set";
                    label18.Text = "maxScale(Bar) to set";
                }
                else if (variables.numP == 15)
                {
                    label16.Text = "minScale(Pa) to set";
                    label18.Text = "maxScale(Pa) to set";
                }
                else if (variables.numP == 16)
                {
                    
                    label16.Text = "minScale(kg/cm2) to set";
                    label18.Text = "maxScale(kg/cm2) to set";
                }
                else if (variables.numP == 17)
                {
                    
                    label16.Text = "minScale(mmh2o) to set";
                    label18.Text = "maxScale(mmh2o) to set";
                }
                else if (variables.numP == 18)
                {
                    
                    label16.Text = "minScale(mh2o) to set";
                    label18.Text = "maxScale(mh2o) to set";
                }
                else if (variables.numP == 19)
                {
                    
                    label16.Text = "minScale(mmHg) to set";
                    label18.Text = "maxScale(mmHg) to set";
                }
                else if (variables.numP == 20)
                {
                    
                    label16.Text = "minScale(psi) to set";
                    label18.Text = "maxScale(psi) to set";
                }
                else if (variables.numP == 21)
                {
                   
                    label16.Text = "minScale(kPa) to set";
                    label18.Text = "maxScale(kPa) to set";
                }
                else if (variables.numP == 22)
                {
                  
                    label16.Text = "minScale(MPa) to set";
                    label18.Text = "maxScale(MPa) to set";
                }
                else if (variables.numP == 23)
                {
                    
                    label16.Text = "minScale(iwg) to set";
                    label18.Text = "maxScale(iwg) to set";
                }
                else
                {
                    
                    label16.Text = "minScale(mBar) to set";
                    label18.Text = "maxScale(mBar) to set";

                }
            }

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void maxScaleSetTextBox_TextChanged(object sender, EventArgs e)
        {
            string org = maxScaleTextBox.Text;
            string formated = string.Concat(org.Where(c => (c >= '0' && c <= '9')));
            if (formated != org)
            {
                int s = maxScaleTextBox.SelectionStart;
                if (s > 0 && formated.Length > s && org[s - 1] != formated[s - 1]) s--;
                maxScaleTextBox.Text = formated;
                maxScaleTextBox.SelectionStart = s;
            }
        }



        private void minScaleSetTextBox_TextChanged(object sender, EventArgs e)
        {
            string org = minScaleTextBox.Text;
            string formated = string.Concat(org.Where(c => (c >= '0' && c <= '9')));
            if (formated != org)
            {
                int s = minScaleTextBox.SelectionStart;
                if (s > 0 && formated.Length > s && org[s - 1] != formated[s - 1]) s--;
                minScaleTextBox.Text = formated;
                minScaleTextBox.SelectionStart = s;
            }
        }

        
    }
}
