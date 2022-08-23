using System;
using System.Data;
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

            IntPtr ptr = CreateRoundRectRgn(0, 0, groupBox1.Width, groupBox1.Height, 15, 15);
            groupBox1.Region = System.Drawing.Region.FromHrgn(ptr);
            DeleteObject(ptr);
            IntPtr ptr2 = CreateRoundRectRgn(0, 0, groupBox2.Width, groupBox2.Height, 15, 15);
            groupBox2.Region = System.Drawing.Region.FromHrgn(ptr2);
            DeleteObject(ptr2);
            IntPtr ptr3 = CreateRoundRectRgn(0, 0, setButton.Width, setButton.Height, 15, 15);
            setButton.Region = System.Drawing.Region.FromHrgn(ptr3);
            DeleteObject(ptr3);
            IntPtr ptr4 = CreateRoundRectRgn(0, 0, scaleButton.Width, scaleButton.Height, 15, 15);
            scaleButton.Region = System.Drawing.Region.FromHrgn(ptr4);
            DeleteObject(ptr4);

            setButton.NormalBadgeColor = System.Drawing.Color.Red;
            scaleButton.NormalBadgeColor = System.Drawing.Color.Red;

            //richTextBox1.Font = new System.Drawing.Font("Arial", 15F);
            //richTextBox2.Font = new System.Drawing.Font("Arial", 15F);
            groupBox1.Font = new System.Drawing.Font("Arial", 12F);
            groupBox2.Font = new System.Drawing.Font("Arial", 12F);
            if (variables.numEN == 11)
            {
                setButton.Text = rm.GetString("SET");
                scaleButton.Text = rm.GetString("CHANGE");
                groupBox1.Text = rm.GetString("Scaling");
               // guideGroupBox.Text = rm.GetString("Guide");

                

                if (variables.numP == 14)
                {
                    label10.Text = rm.GetString("Güncel maxScale") + "(Bar)";
                    label11.Text = rm.GetString("Güncel minScale") + "(Bar)";
                    label16.Text = rm.GetString("Ayarlanacak minScale") + "(Bar)";
                    label18.Text = rm.GetString("Ayarlanacak maxScale") + "(Bar)";
                }
                else if (variables.numP == 15)
                {
                    label10.Text = rm.GetString("Güncel maxScale") + "(Pa)";
                    label11.Text = rm.GetString("Güncel minScale") + "(Pa)";
                    label16.Text = rm.GetString("Ayarlanacak minScale") + "(Pa)";
                    label18.Text = rm.GetString("Ayarlanacak maxScale") + "(Pa)";
                }
                else if (variables.numP == 16)
                {
                    label10.Text = rm.GetString("Güncel maxScale") + "(kg/cm2)";
                    label11.Text = rm.GetString("Güncel minScale") + "(kg/cm2)";
                    label16.Text = rm.GetString("Ayarlanacak minScale") + "(kg/cm2)";
                    label18.Text = rm.GetString("Ayarlanacak maxScale") + "(kg/cm2)";
                }
                else if (variables.numP == 17)
                {
                    label10.Text = rm.GetString("Güncel maxScale") + "(mmh2o)";
                    label11.Text = rm.GetString("Güncel minScale") + "(mmh2o)";
                    label16.Text = rm.GetString("Ayarlanacak minScale") + "(mmh2o)";
                    label18.Text = rm.GetString("Ayarlanacak maxScale") + "(mmh2o)";
                }
                else if (variables.numP == 18)
                {
                    label10.Text = rm.GetString("Güncel maxScale") + "(mh2o)";
                    label11.Text = rm.GetString("Güncel minScale") + "(mh2o)";
                    label16.Text = rm.GetString("Ayarlanacak minScale") + "(mh2o)";
                    label18.Text = rm.GetString("Ayarlanacak maxScale") + "(mh2o)";
                }
                else if (variables.numP == 19)
                {
                    label10.Text = rm.GetString("Güncel maxScale") + "(mmHg)";
                    label11.Text = rm.GetString("Güncel minScale") + "(mmHg)";
                    label16.Text = rm.GetString("Ayarlanacak minScale") + "(mmHg)";
                    label18.Text = rm.GetString("Ayarlanacak maxScale") + "(mmHg)";
                }
                else if (variables.numP == 20)
                {
                    label10.Text = rm.GetString("Güncel maxScale") + "(psi)";
                    label11.Text = rm.GetString("Güncel minScale") + "(psi)";
                    label16.Text = rm.GetString("Ayarlanacak minScale") + "(psi)";
                    label18.Text = rm.GetString("Ayarlanacak maxScale") + "(psi)";
                }
                else if (variables.numP == 21)
                {
                    label10.Text = rm.GetString("Güncel maxScale") + "(kPa)";
                    label11.Text = rm.GetString("Güncel minScale") + "(kPa)";
                    label16.Text = rm.GetString("Ayarlanacak minScale") + "(kPa)";
                    label18.Text = rm.GetString("Ayarlanacak maxScale") + "(kPa)";
                }
                else if (variables.numP == 22)
                {
                    label10.Text = rm.GetString("Güncel maxScale") + "(MPa)";
                    label11.Text = rm.GetString("Güncel minScale") + "(MPa)";
                    label16.Text = rm.GetString("Ayarlanacak minScale") + "(MPa)";
                    label18.Text = rm.GetString("Ayarlanacak maxScale") + "(MPa)";
                }
                else if (variables.numP == 23)
                {
                    label10.Text = rm.GetString("Güncel maxScale") + "(iwg)";
                    label11.Text = rm.GetString("Güncel minScale") + "(iwg)";
                    label16.Text = rm.GetString("Ayarlanacak minScale") + "(iwg)";
                    label18.Text = rm.GetString("Ayarlanacak maxScale") + "(iwg)";
                }
                else
                {
                    label10.Text = rm.GetString("Güncel maxScale") + "(mBar)";
                    label11.Text = rm.GetString("Güncel minScale") + "(mBar)";
                    label16.Text = rm.GetString("Ayarlanacak minScale") + "(mBar)";
                    label18.Text = rm.GetString("Ayarlanacak maxScale") + "(mBar)";

                }

            }

            else if(variables.numEN ==10)
            {


                if (variables.numP == 14)
                {
                    label10.Text = "Current maxScale(Bar)";
                    label11.Text = "Current minScale(Bar)";
                    label16.Text = "minScale(Bar) to set";
                    label18.Text = "maxScale(Bar) to set";
                }
                else if (variables.numP == 15)
                {
                    label10.Text = "Current maxScale(Pa)";
                    label11.Text = "Current minScale(Pa)";
                    label16.Text = "minScale(Pa) to set";
                    label18.Text = "maxScale(Pa) to set";
                }
                else if (variables.numP == 16)
                {
                    label10.Text = "Current maxScale(kg/cm2)";
                    label11.Text = "Current minScale(kg/cm2)";
                    label16.Text = "minScale(kg/cm2) to set";
                    label18.Text = "maxScale(kg/cm2) to set";
                }
                else if (variables.numP == 17)
                {
                    label10.Text = "Current maxScale(mmh2o)";
                    label11.Text = "Current minScale(mmh2o)";
                    label16.Text = "minScale(mmh2o) to set";
                    label18.Text = "maxScale(mmh2o) to set";
                }
                else if (variables.numP == 18)
                {
                    label10.Text = "Current maxScale(mh2o)";
                    label11.Text = "Current minScale(mh2o)";
                    label16.Text = "minScale(mh2o) to set";
                    label18.Text = "maxScale(mh2o) to set";
                }
                else if (variables.numP == 19)
                {
                    label10.Text = "Current maxScale(mmHg)";
                    label11.Text = "Current minScale(mmHg)";
                    label16.Text = "minScale(mmHg) to set";
                    label18.Text = "maxScale(mmHg) to set";
                }
                else if (variables.numP == 20)
                {
                    label10.Text = "Current maxScale(psi)";
                    label11.Text = "Current minScale(psi)";
                    label16.Text = "minScale(psi) to set";
                    label18.Text = "maxScale(psi) to set";
                }
                else if (variables.numP == 21)
                {
                    label10.Text = "Current maxScale(kPa)";
                    label11.Text = "Current minScale(kPa)";
                    label16.Text = "minScale(kPa) to set";
                    label18.Text = "maxScale(kPa) to set";
                }
                else if (variables.numP == 22)
                {
                    label10.Text = "Current maxScale(MPa)";
                    label11.Text = "Current minScale(MPa)";
                    label16.Text = "minScale(MPa) to set";
                    label18.Text = "maxScale(MPa) to set";
                }
                else if (variables.numP == 23)
                {
                    label10.Text = "Current maxScale(iwg)";
                    label11.Text = "Current minScale(iwg)";
                    label16.Text = "minScale(iwg) to set";
                    label18.Text = "maxScale(iwg) to set";
                }
                else
                {
                    label10.Text = "Current maxScale(mBar)";
                    label11.Text = "Current minScale(mBar)";
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
            progressBar1.Maximum = 100;
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


            scaleButton.Enabled = false;
            minScaleTextBox.Enabled = false;
            maxScaleTextBox.Enabled = false;
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

                                setButton.Enabled = true;
                                scaleButton.Enabled = false;
                                minScaleSetTextBox.Enabled = true;
                                maxScaleSetTextBox.Enabled = true;

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

                                setButton.Enabled = true;
                                scaleButton.Enabled = false;
                                minScaleSetTextBox.Enabled = true;
                                maxScaleSetTextBox.Enabled = true;

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

                                setButton.Enabled = true;
                                scaleButton.Enabled = false;
                                minScaleSetTextBox.Enabled = true;
                                maxScaleSetTextBox.Enabled = true;

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

                                setButton.Enabled = true;
                                scaleButton.Enabled = false;
                                minScaleSetTextBox.Enabled = true;
                                maxScaleSetTextBox.Enabled = true;

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

                                setButton.Enabled = true;
                                scaleButton.Enabled = false;
                                minScaleSetTextBox.Enabled = true;
                                maxScaleSetTextBox.Enabled = true;

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

                                setButton.Enabled = true;
                                scaleButton.Enabled = false;
                                minScaleSetTextBox.Enabled = true;
                                maxScaleSetTextBox.Enabled = true;

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

                                setButton.Enabled = true;
                                scaleButton.Enabled = false;
                                minScaleSetTextBox.Enabled = true;
                                maxScaleSetTextBox.Enabled = true;

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

                                setButton.Enabled = true;
                                scaleButton.Enabled = false;
                                minScaleSetTextBox.Enabled = true;
                                maxScaleSetTextBox.Enabled = true;

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

                                setButton.Enabled = true;
                                scaleButton.Enabled = false;
                                minScaleSetTextBox.Enabled = true;
                                maxScaleSetTextBox.Enabled = true;

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

                                setButton.Enabled = true;
                                scaleButton.Enabled = false;
                                minScaleSetTextBox.Enabled = true;
                                maxScaleSetTextBox.Enabled = true;

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

                                setButton.Enabled = true;
                                scaleButton.Enabled = false;
                                minScaleSetTextBox.Enabled = true;
                                maxScaleSetTextBox.Enabled = true;

                            }

                        }

                    }

                    minScaleSetTextBox.Enabled = true;
                    maxScaleSetTextBox.Enabled = true;
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
                pictureBox4.Image = BASSCOMPORT.Properties.Resources.output_onlinegiftools;
                progressBar1.Value += 10;
                if(progressBar1.Value == progressBar1.Maximum)
                {
                    pictureBox1.Image = BASSCOMPORT.Properties.Resources.ok;
                    pictureBox4.Image = BASSCOMPORT.Properties.Resources.ok;
                }

            }

                
            

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (variables.numEN == 11)
            {
                setButton.Text = rm.GetString("SET");
                scaleButton.Text = rm.GetString("CHANGE");
                pictureBox3.Image = BASSCOMPORT.Properties.Resources.tr;
                //groupBox1.Text = rm.GetString("Scaling");
               // guideGroupBox.Text = rm.GetString("Guide");
               // richTextBox2.Text = "Sonra ölçeklendirmek istediğiniz minimum ve maksimum değerleri giriniz ve DEĞİŞTİR butonuna tıklayınız. Lütfen 'OK' işaretini görene kadar bekleyiniz.";
                //richTextBox1.Text = "Lütfen ürün etiketi üzerinde bulunan ölçeklendirme aralığını kontrol ediniz. Ardından minimum ve maksimum değerleri belirtilen kutucuklara giriniz ve AYARLA butonuna tıklayınız. Bu şekilde cihaza referans ölçeklendirme aralığı vermiş oluyoruz. ";



                if (variables.numP == 14)
                {
                    label10.Text = rm.GetString("Güncel maxScale") + "(Bar)";
                    label11.Text = rm.GetString("Güncel minScale") + "(Bar)";
                    label16.Text = rm.GetString("Ayarlanacak minScale") + "(Bar)";
                    label18.Text = rm.GetString("Ayarlanacak maxScale") + "(Bar)";
                }
                else if (variables.numP == 15)
                {
                    label10.Text = rm.GetString("Güncel maxScale") + "(Pa)";
                    label11.Text = rm.GetString("Güncel minScale") + "(Pa)";
                    label16.Text = rm.GetString("Ayarlanacak minScale") + "(Pa)";
                    label18.Text = rm.GetString("Ayarlanacak maxScale") + "(Pa)";
                }
                else if (variables.numP == 16)
                {
                    label10.Text = rm.GetString("Güncel maxScale") + "(kg/cm2)";
                    label11.Text = rm.GetString("Güncel minScale") + "(kg/cm2)";
                    label16.Text = rm.GetString("Ayarlanacak minScale") + "(kg/cm2)";
                    label18.Text = rm.GetString("Ayarlanacak maxScale") + "(kg/cm2)";
                }
                else if (variables.numP == 17)
                {
                    label10.Text = rm.GetString("Güncel maxScale") + "(mmh2o)";
                    label11.Text = rm.GetString("Güncel minScale") + "(mmh2o)";
                    label16.Text = rm.GetString("Ayarlanacak minScale") + "(mmh2o)";
                    label18.Text = rm.GetString("Ayarlanacak maxScale") + "(mmh2o)";
                }
                else if (variables.numP == 18)
                {
                    label10.Text = rm.GetString("Güncel maxScale") + "(mh2o)";
                    label11.Text = rm.GetString("Güncel minScale") + "(mh2o)";
                    label16.Text = rm.GetString("Ayarlanacak minScale") + "(mh2o)";
                    label18.Text = rm.GetString("Ayarlanacak maxScale") + "(mh2o)";
                }
                else if (variables.numP == 19)
                {
                    label10.Text = rm.GetString("Güncel maxScale") + "(mmHg)";
                    label11.Text = rm.GetString("Güncel minScale") + "(mmHg)";
                    label16.Text = rm.GetString("Ayarlanacak minScale") + "(mmHg)";
                    label18.Text = rm.GetString("Ayarlanacak maxScale") + "(mmHg)";
                }
                else if (variables.numP == 20)
                {
                    label10.Text = rm.GetString("Güncel maxScale") + "(psi)";
                    label11.Text = rm.GetString("Güncel minScale") + "(psi)";
                    label16.Text = rm.GetString("Ayarlanacak minScale") + "(psi)";
                    label18.Text = rm.GetString("Ayarlanacak maxScale") + "(psi)";
                }
                else if (variables.numP == 21)
                {
                    label10.Text = rm.GetString("Güncel maxScale") + "(kPa)";
                    label11.Text = rm.GetString("Güncel minScale") + "(kPa)";
                    label16.Text = rm.GetString("Ayarlanacak minScale") + "(kPa)";
                    label18.Text = rm.GetString("Ayarlanacak maxScale") + "(kPa)";
                }
                else if (variables.numP == 22)
                {
                    label10.Text = rm.GetString("Güncel maxScale") + "(MPa)";
                    label11.Text = rm.GetString("Güncel minScale") + "(MPa)";
                    label16.Text = rm.GetString("Ayarlanacak minScale") + "(MPa)";
                    label18.Text = rm.GetString("Ayarlanacak maxScale") + "(MPa)";
                }
                else if (variables.numP == 23)
                {
                    label10.Text = rm.GetString("Güncel maxScale") + "(iwg)";
                    label11.Text = rm.GetString("Güncel minScale") + "(iwg)";
                    label16.Text = rm.GetString("Ayarlanacak minScale") + "(iwg)";
                    label18.Text = rm.GetString("Ayarlanacak maxScale") + "(iwg)";
                }
                else
                {
                    label10.Text = rm.GetString("Güncel maxScale") + "(mBar)";
                    label11.Text = rm.GetString("Güncel minScale") + "(mBar)";
                    label16.Text = rm.GetString("Ayarlanacak minScale") + "(mBar)";
                    label18.Text = rm.GetString("Ayarlanacak maxScale") + "(mBar)";

                }

            }

            else if (variables.numEN == 10)
            {

                setButton.Text = "SET";
                scaleButton.Text = "CHANGE";
                pictureBox3.Image = BASSCOMPORT.Properties.Resources.eng;
                //groupBox1.Text = "Scaling";
                // guideGroupBox.Text = "Guide";

                // richTextBox2.Text = "After that, enter the minimum and maximum values you want to scale, click the CHANGE button . Please wait until you see the 'OK' tick.";
                //richTextBox1.Text = "Please check the scaling range on product label. Then enter the minimum and maximum values and click to SET button. In this way, we are saying the device that what's its reference scaling range.";

                if (variables.numP == 14)
                {
                    label10.Text = "Current maxScale(Bar)";
                    label11.Text = "Current minScale(Bar)";
                    label16.Text = "minScale(Bar) to set";
                    label18.Text = "maxScale(Bar) to set";
                }
                else if (variables.numP == 15)
                {
                    label10.Text = "Current maxScale(Pa)";
                    label11.Text = "Current minScale(Pa)";
                    label16.Text = "minScale(Pa) to set";
                    label18.Text = "maxScale(Pa) to set";
                }
                else if (variables.numP == 16)
                {
                    label10.Text = "Current maxScale(kg/cm2)";
                    label11.Text = "Current minScale(kg/cm2)";
                    label16.Text = "minScale(kg/cm2) to set";
                    label18.Text = "maxScale(kg/cm2) to set";
                }
                else if (variables.numP == 17)
                {
                    label10.Text = "Current maxScale(mmh2o)";
                    label11.Text = "Current minScale(mmh2o)";
                    label16.Text = "minScale(mmh2o) to set";
                    label18.Text = "maxScale(mmh2o) to set";
                }
                else if (variables.numP == 18)
                {
                    label10.Text = "Current maxScale(mh2o)";
                    label11.Text = "Current minScale(mh2o)";
                    label16.Text = "minScale(mh2o) to set";
                    label18.Text = "maxScale(mh2o) to set";
                }
                else if (variables.numP == 19)
                {
                    label10.Text = "Current maxScale(mmHg)";
                    label11.Text = "Current minScale(mmHg)";
                    label16.Text = "minScale(mmHg) to set";
                    label18.Text = "maxScale(mmHg) to set";
                }
                else if (variables.numP == 20)
                {
                    label10.Text = "Current maxScale(psi)";
                    label11.Text = "Current minScale(psi)";
                    label16.Text = "minScale(psi) to set";
                    label18.Text = "maxScale(psi) to set";
                }
                else if (variables.numP == 21)
                {
                    label10.Text = "Current maxScale(kPa)";
                    label11.Text = "Current minScale(kPa)";
                    label16.Text = "minScale(kPa) to set";
                    label18.Text = "maxScale(kPa) to set";
                }
                else if (variables.numP == 22)
                {
                    label10.Text = "Current maxScale(MPa)";
                    label11.Text = "Current minScale(MPa)";
                    label16.Text = "minScale(MPa) to set";
                    label18.Text = "maxScale(MPa) to set";
                }
                else if (variables.numP == 23)
                {
                    label10.Text = "Current maxScale(iwg)";
                    label11.Text = "Current minScale(iwg)";
                    label16.Text = "minScale(iwg) to set";
                    label18.Text = "maxScale(iwg) to set";
                }
                else
                {
                    label10.Text = "Current maxScale(mBar)";
                    label11.Text = "Current minScale(mBar)";
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

        private void setButton_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                progressBar1.Value = 0;
                pictureBox1.Image = null;
                pictureBox4.Image = null;
                timer1.Stop(); 
                if (minScaleSetTextBox.Text.Trim() == string.Empty || maxScaleSetTextBox.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please enter something in the textbox");
                    return; // return because we don't want to run normal code of buton click
                }
                else
                {

                    string tempMin;
                    string tempMax;
                    double minx;
                    double maxx;

                    if (variables.numP == 14)
                    {
                        double minScaleBar = Convert.ToDouble(minScaleSetTextBox.Text);
                        double maxScaleBar = Convert.ToDouble(maxScaleSetTextBox.Text);

                        if (minScaleBar < -1 || maxScaleBar > 1000)
                        {
                            MessageBox.Show("The value must be between -1 and 1000 ");
                            minScaleSetTextBox.Clear();
                            maxScaleSetTextBox.Clear();
                            return;


                        }
                        else
                        {
                            if (MessageBox.Show("Please confirm before proceed" + "\n" + "Do you want to Continue ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

                            {
                                tempMin = minScaleSetTextBox.Text;
                                tempMax = maxScaleSetTextBox.Text;

                                minx = Convert.ToDouble(tempMin);
                                maxx = Convert.ToDouble(tempMax);

                                minx *= 1000;
                                maxx *= 1000;

                                variables.minscale = minx;
                                variables.maxscale = maxx;

                                dataminSetScale = minx.ToString();
                                datamaxSetScale = maxx.ToString();

                                label1.Text = maxScaleSetTextBox.Text;
                                label2.Text = minScaleSetTextBox.Text;

                                serialPort1.WriteLine("*" + dataminSetScale + "*" + datamaxSetScale + "*");

                                minScaleSetTextBox.Clear();
                                maxScaleSetTextBox.Clear();

                                setButton.Enabled = false;
                                scaleButton.Enabled = true;
                                minScaleTextBox.Enabled = true;
                                maxScaleTextBox.Enabled = true;

                            }

                        }
                    }

                    else if (variables.numP == 15)
                    {
                        double minScaleBar = Convert.ToDouble(minScaleSetTextBox.Text);
                        double maxScaleBar = Convert.ToDouble(maxScaleSetTextBox.Text);

                        if (minScaleBar < -100000 || maxScaleBar > 100000000)
                        {
                            MessageBox.Show("The value must be between -100000 and 100000000 ");
                            minScaleSetTextBox.Clear();
                            maxScaleSetTextBox.Clear();
                            return;


                        }
                        else
                        {
                            if (MessageBox.Show("Please confirm before proceed" + "\n" + "Do you want to Continue ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

                            {
                                tempMin = minScaleSetTextBox.Text;
                                tempMax = maxScaleSetTextBox.Text;

                                minx = Convert.ToDouble(tempMin);
                                maxx = Convert.ToDouble(tempMax);

                                minx /= 100;
                                maxx /= 100;

                                variables.minscale = minx;
                                variables.maxscale = maxx;

                                dataminSetScale = minx.ToString();
                                datamaxSetScale = maxx.ToString();

                                label1.Text = maxScaleSetTextBox.Text;
                                label2.Text = minScaleSetTextBox.Text;

                                serialPort1.WriteLine("*" + dataminSetScale + "*" + datamaxSetScale + "*");

                                minScaleSetTextBox.Clear();
                                maxScaleSetTextBox.Clear();

                                setButton.Enabled = false;
                                scaleButton.Enabled = true;
                                minScaleTextBox.Enabled = true;
                                maxScaleTextBox.Enabled = true;

                            }

                        }
                    }
                    else if (variables.numP == 16)
                    {
                        double minScaleBar = Convert.ToDouble(minScaleSetTextBox.Text);
                        double maxScaleBar = Convert.ToDouble(maxScaleSetTextBox.Text);

                        if (minScaleBar < -1 || maxScaleBar > 1019)
                        {
                            MessageBox.Show("The value must be between -1 and 1019 ");
                            minScaleSetTextBox.Clear();
                            maxScaleSetTextBox.Clear();
                            return;


                        }
                        else
                        {
                            if (MessageBox.Show("Please confirm before proceed" + "\n" + "Do you want to Continue ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

                            {
                                tempMin = minScaleSetTextBox.Text;
                                tempMax = maxScaleSetTextBox.Text;

                                minx = Convert.ToDouble(tempMin);
                                maxx = Convert.ToDouble(tempMax);

                                minx /= 0.00102;
                                maxx /= 0.00102;

                                variables.minscale = minx;
                                variables.maxscale = maxx;

                                dataminSetScale = minx.ToString();
                                datamaxSetScale = maxx.ToString();

                                label1.Text = maxScaleSetTextBox.Text;
                                label2.Text = minScaleSetTextBox.Text;

                                serialPort1.WriteLine("*" + dataminSetScale + "*" + datamaxSetScale + "*");

                                minScaleSetTextBox.Clear();
                                maxScaleSetTextBox.Clear();

                                setButton.Enabled = false;
                                scaleButton.Enabled = true;
                                minScaleTextBox.Enabled = true;
                                maxScaleTextBox.Enabled = true;

                            }

                        }
                    }
                    else if (variables.numP == 17)
                    {
                        double minScaleBar = Convert.ToDouble(minScaleSetTextBox.Text);
                        double maxScaleBar = Convert.ToDouble(maxScaleSetTextBox.Text);

                        if (minScaleBar < -10197 || maxScaleBar > 10197162)
                        {
                            MessageBox.Show("The value must be between -10197 and 10197162 ");
                            minScaleSetTextBox.Clear();
                            maxScaleSetTextBox.Clear();
                            return;


                        }
                        else
                        {
                            if (MessageBox.Show("Please confirm before proceed" + "\n" + "Do you want to Continue ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

                            {
                                tempMin = minScaleSetTextBox.Text;
                                tempMax = maxScaleSetTextBox.Text;

                                minx = Convert.ToDouble(tempMin);
                                maxx = Convert.ToDouble(tempMax);

                                minx *= 0.0980665;
                                maxx *= 0.0980665;

                                variables.minscale = minx;
                                variables.maxscale = maxx;

                                dataminSetScale = minx.ToString();
                                datamaxSetScale = maxx.ToString();

                                label1.Text = maxScaleSetTextBox.Text;
                                label2.Text = minScaleSetTextBox.Text;

                                serialPort1.WriteLine("*" + dataminSetScale + "*" + datamaxSetScale + "*");

                                minScaleSetTextBox.Clear();
                                maxScaleSetTextBox.Clear();

                                setButton.Enabled = false;
                                scaleButton.Enabled = true;
                                minScaleTextBox.Enabled = true;
                                maxScaleTextBox.Enabled = true;

                            }

                        }
                    }
                    else if (variables.numP == 18)
                    {
                        double minScaleBar = Convert.ToDouble(minScaleSetTextBox.Text);
                        double maxScaleBar = Convert.ToDouble(maxScaleSetTextBox.Text);

                        if (minScaleBar < -10 || maxScaleBar > 10197)
                        {
                            MessageBox.Show("The value must be between -10 and 10197 ");
                            minScaleSetTextBox.Clear();
                            maxScaleSetTextBox.Clear();
                            return;


                        }
                        else
                        {
                            if (MessageBox.Show("Please confirm before proceed" + "\n" + "Do you want to Continue ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

                            {
                                tempMin = minScaleSetTextBox.Text;
                                tempMax = maxScaleSetTextBox.Text;

                                minx = Convert.ToDouble(tempMin);
                                maxx = Convert.ToDouble(tempMax);

                                minx *= 98.0665;
                                maxx *= 98.0665;

                                variables.minscale = minx;
                                variables.maxscale = maxx;

                                dataminSetScale = minx.ToString();
                                datamaxSetScale = maxx.ToString();

                                label1.Text = maxScaleSetTextBox.Text;
                                label2.Text = minScaleSetTextBox.Text;

                                serialPort1.WriteLine("*" + dataminSetScale + "*" + datamaxSetScale + "*");

                                minScaleSetTextBox.Clear();
                                maxScaleSetTextBox.Clear();

                                setButton.Enabled = false;
                                scaleButton.Enabled = true;
                                minScaleTextBox.Enabled = true;
                                maxScaleTextBox.Enabled = true;

                            }

                        }
                    }
                    else if (variables.numP == 19)
                    {
                        double minScaleBar = Convert.ToDouble(minScaleSetTextBox.Text);
                        double maxScaleBar = Convert.ToDouble(maxScaleSetTextBox.Text);

                        if (minScaleBar < -750 || maxScaleBar > 750061)
                        {
                            MessageBox.Show("The value must be between -750 and 750061 ");
                            minScaleSetTextBox.Clear();
                            maxScaleSetTextBox.Clear();
                            return;


                        }
                        else
                        {
                            if (MessageBox.Show("Please confirm before proceed" + "\n" + "Do you want to Continue ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

                            {
                                tempMin = minScaleSetTextBox.Text;
                                tempMax = maxScaleSetTextBox.Text;

                                minx = Convert.ToDouble(tempMin);
                                maxx = Convert.ToDouble(tempMax);

                                minx /= 0.750062;
                                maxx /= 0.750062;

                                variables.minscale = minx;
                                variables.maxscale = maxx;

                                dataminSetScale = minx.ToString();
                                datamaxSetScale = maxx.ToString();

                                label1.Text = maxScaleSetTextBox.Text;
                                label2.Text = minScaleSetTextBox.Text;

                                serialPort1.WriteLine("*" + dataminSetScale + "*" + datamaxSetScale + "*");

                                minScaleSetTextBox.Clear();
                                maxScaleSetTextBox.Clear();

                                setButton.Enabled = false;
                                scaleButton.Enabled = true;
                                minScaleTextBox.Enabled = true;
                                maxScaleTextBox.Enabled = true;

                            }

                        }
                    }

                    else if (variables.numP == 20)
                    {
                        double minScaleBar = Convert.ToDouble(minScaleSetTextBox.Text);
                        double maxScaleBar = Convert.ToDouble(maxScaleSetTextBox.Text);

                        if (minScaleBar < -15 || maxScaleBar > 14500)
                        {
                            MessageBox.Show("The value must be between -15 and 14500 ");
                            minScaleSetTextBox.Clear();
                            maxScaleSetTextBox.Clear();
                            return;


                        }
                        else
                        {
                            if (MessageBox.Show("Please confirm before proceed" + "\n" + "Do you want to Continue ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

                            {
                                tempMin = minScaleSetTextBox.Text;
                                tempMax = maxScaleSetTextBox.Text;

                                minx = Convert.ToDouble(tempMin);
                                maxx = Convert.ToDouble(tempMax);

                                minx /= 0.0145037738;
                                maxx /= 0.0145037738;

                                variables.minscale = minx;
                                variables.maxscale = maxx;

                                dataminSetScale = minx.ToString();
                                datamaxSetScale = maxx.ToString();

                                label1.Text = maxScaleSetTextBox.Text;
                                label2.Text = minScaleSetTextBox.Text;

                                serialPort1.WriteLine("*" + dataminSetScale + "*" + datamaxSetScale + "*");

                                minScaleSetTextBox.Clear();
                                maxScaleSetTextBox.Clear();

                                setButton.Enabled = false;
                                scaleButton.Enabled = true;
                                minScaleTextBox.Enabled = true;
                                maxScaleTextBox.Enabled = true;

                            }

                        }
                    }
                    else if (variables.numP == 21)
                    {
                        double minScaleBar = Convert.ToDouble(minScaleSetTextBox.Text);
                        double maxScaleBar = Convert.ToDouble(maxScaleSetTextBox.Text);

                        if (minScaleBar < -100 || maxScaleBar > 100000)
                        {
                            MessageBox.Show("The value must be between -100 and 100000 ");
                            minScaleSetTextBox.Clear();
                            maxScaleSetTextBox.Clear();
                            return;


                        }
                        else
                        {
                            if (MessageBox.Show("Please confirm before proceed" + "\n" + "Do you want to Continue ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

                            {
                                tempMin = minScaleSetTextBox.Text;
                                tempMax = maxScaleSetTextBox.Text;

                                minx = Convert.ToDouble(tempMin);
                                maxx = Convert.ToDouble(tempMax);

                                minx *= 10;
                                maxx *= 10;

                                variables.minscale = minx;
                                variables.maxscale = maxx;

                                dataminSetScale = minx.ToString();
                                datamaxSetScale = maxx.ToString();

                                label1.Text = maxScaleSetTextBox.Text;
                                label2.Text = minScaleSetTextBox.Text;

                                serialPort1.WriteLine("*" + dataminSetScale + "*" + datamaxSetScale + "*");

                                minScaleSetTextBox.Clear();
                                maxScaleSetTextBox.Clear();

                                setButton.Enabled = false;
                                scaleButton.Enabled = true;
                                minScaleTextBox.Enabled = true;
                                maxScaleTextBox.Enabled = true;

                            }

                        }
                    }

                    else if (variables.numP == 22)
                    {
                        double minScaleBar = Convert.ToDouble(minScaleSetTextBox.Text);
                        double maxScaleBar = Convert.ToDouble(maxScaleSetTextBox.Text);

                        if (minScaleBar < -0.1 || maxScaleBar > 100)
                        {
                            MessageBox.Show("The value must be between -0.1 and 100 ");
                            minScaleSetTextBox.Clear();
                            maxScaleSetTextBox.Clear();
                            return;


                        }
                        else
                        {
                            if (MessageBox.Show("Please confirm before proceed" + "\n" + "Do you want to Continue ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

                            {
                                tempMin = minScaleSetTextBox.Text;
                                tempMax = maxScaleSetTextBox.Text;

                                minx = Convert.ToDouble(tempMin);
                                maxx = Convert.ToDouble(tempMax);

                                minx *= 10000;
                                maxx *= 10000;

                                variables.minscale = minx;
                                variables.maxscale = maxx;

                                dataminSetScale = minx.ToString();
                                datamaxSetScale = maxx.ToString();

                                dataminSetScale = minScaleSetTextBox.Text;
                                datamaxSetScale = maxScaleSetTextBox.Text;

                                label1.Text = maxScaleSetTextBox.Text;
                                label2.Text = minScaleSetTextBox.Text;

                                serialPort1.WriteLine("*" + dataminSetScale + "*" + datamaxSetScale + "*");

                                minScaleSetTextBox.Clear();
                                maxScaleSetTextBox.Clear();

                                setButton.Enabled = false;
                                scaleButton.Enabled = true;
                                minScaleTextBox.Enabled = true;
                                maxScaleTextBox.Enabled = true;

                            }

                        }
                    }

                    else if (variables.numP == 23)
                    {
                        double minScaleBar = Convert.ToDouble(minScaleSetTextBox.Text);
                        double maxScaleBar = Convert.ToDouble(maxScaleSetTextBox.Text);

                        if (minScaleBar < -402 || maxScaleBar > 401464)
                        {
                            MessageBox.Show("The value must be between -402 and 401464 ");
                            minScaleSetTextBox.Clear();
                            maxScaleSetTextBox.Clear();
                            return;


                        }
                        else
                        {
                            if (MessageBox.Show("Please confirm before proceed" + "\n" + "Do you want to Continue ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

                            {
                                tempMin = minScaleSetTextBox.Text;
                                tempMax = maxScaleSetTextBox.Text;

                                minx = Convert.ToDouble(tempMin);
                                maxx = Convert.ToDouble(tempMax);

                                minx *= 2.490889;
                                maxx *= 2.490889;

                                variables.minscale = minx;
                                variables.maxscale = maxx;

                                dataminSetScale = minx.ToString();
                                datamaxSetScale = maxx.ToString();

                                dataminSetScale = minScaleSetTextBox.Text;
                                datamaxSetScale = maxScaleSetTextBox.Text;

                                label1.Text = maxScaleSetTextBox.Text;
                                label2.Text = minScaleSetTextBox.Text;

                                serialPort1.WriteLine("*" + dataminSetScale + "*" + datamaxSetScale + "*");

                                minScaleSetTextBox.Clear();
                                maxScaleSetTextBox.Clear();

                                setButton.Enabled = false;
                                scaleButton.Enabled = true;
                                minScaleTextBox.Enabled = true;
                                maxScaleTextBox.Enabled = true;

                            }

                        }
                    }

                    else //for mBar
                    {
                        double minScaleBar = Convert.ToDouble(minScaleSetTextBox.Text);
                        double maxScaleBar = Convert.ToDouble(maxScaleSetTextBox.Text);

                        if (minScaleBar < -1000 || maxScaleBar > 1000000)
                        {
                            MessageBox.Show("The value must be between -0.000001 and 0.001 ");
                            minScaleSetTextBox.Clear();
                            maxScaleSetTextBox.Clear();
                            return;


                        }
                        else
                        {
                            if (MessageBox.Show("Please confirm before proceed" + "\n" + "Do you want to Continue ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

                            {
                                dataminSetScale = minScaleSetTextBox.Text;
                                datamaxSetScale = maxScaleSetTextBox.Text;

                                label1.Text = maxScaleSetTextBox.Text;
                                label2.Text = minScaleSetTextBox.Text;

                                variables.minscale = minScaleBar;
                                variables.maxscale = maxScaleBar;

                                serialPort1.WriteLine("*" + dataminSetScale + "*" + datamaxSetScale + "*");

                                minScaleSetTextBox.Clear();
                                maxScaleSetTextBox.Clear();

                                setButton.Enabled = false;
                                scaleButton.Enabled = true;
                                minScaleTextBox.Enabled = true;
                                maxScaleTextBox.Enabled = true;

                            }

                        }
                    }
                    /*if (MessageBox.Show("Please confirm before proceed" + "\n" + "Do you want to Continue ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

                    {

                        
                        if (variables.numP == 14)
                        {
                           
                        }
                        else if (variables.numP == 15)
                        {
                            tempMin = minScaleSetTextBox.Text;
                            tempMax = maxScaleSetTextBox.Text;

                            minx = Convert.ToDouble(tempMin);
                            maxx = Convert.ToDouble(tempMax);

                            minx /= 100;
                            maxx /= 100;

                            dataminSetScale = minx.ToString();
                            datamaxSetScale = maxx.ToString();
                        }
                        else if (variables.numP == 16)
                        {
                            tempMin = minScaleSetTextBox.Text;
                            tempMax = maxScaleSetTextBox.Text;

                            minx = Convert.ToDouble(tempMin);
                            maxx = Convert.ToDouble(tempMax);

                            minx /= 0.00102;
                            maxx /= 0.00102;

                            dataminSetScale = minx.ToString();
                            datamaxSetScale = maxx.ToString();
                        }
                        else if (variables.numP == 17)
                        {
                            tempMin = minScaleSetTextBox.Text;
                            tempMax = maxScaleSetTextBox.Text;

                            minx = Convert.ToDouble(tempMin);
                            maxx = Convert.ToDouble(tempMax);

                            minx *= 0.0980665;
                            maxx *= 0.0980665;

                            dataminSetScale = minx.ToString();
                            datamaxSetScale = maxx.ToString();
                        }
                        else if (variables.numP == 18)
                        {
                            tempMin = minScaleSetTextBox.Text;
                            tempMax = maxScaleSetTextBox.Text;

                            minx = Convert.ToDouble(tempMin);
                            maxx = Convert.ToDouble(tempMax);

                            minx /= 0.010197442889221;
                            maxx /= 0.010197442889221;

                            dataminSetScale = minx.ToString();
                            datamaxSetScale = maxx.ToString();
                        }
                        else if (variables.numP == 19)
                        {
                            tempMin = minScaleSetTextBox.Text;
                            tempMax = maxScaleSetTextBox.Text;

                            minx = Convert.ToDouble(tempMin);
                            maxx = Convert.ToDouble(tempMax);

                            minx /= 0.750062;
                            maxx /= 0.750062;

                            dataminSetScale = minx.ToString();
                            datamaxSetScale = maxx.ToString();
                        }
                        else if (variables.numP == 20)
                        {
                            tempMin = minScaleSetTextBox.Text;
                            tempMax = maxScaleSetTextBox.Text;

                            minx = Convert.ToDouble(tempMin);
                            maxx = Convert.ToDouble(tempMax);

                            minx /= 0.0145037738;
                            maxx /= 0.0145037738;

                            dataminSetScale = minx.ToString();
                            datamaxSetScale = maxx.ToString();
                        }
                        else if (variables.numP == 21)
                        {
                            tempMin = minScaleSetTextBox.Text;
                            tempMax = maxScaleSetTextBox.Text;

                            minx = Convert.ToDouble(tempMin);
                            maxx = Convert.ToDouble(tempMax);

                            minx *= 1000000;
                            maxx *= 1000000;

                            dataminSetScale = minx.ToString();
                            datamaxSetScale = maxx.ToString();
                        }
                        else if (variables.numP == 22)
                        {
                            tempMin = minScaleSetTextBox.Text;
                            tempMax = maxScaleSetTextBox.Text;

                            minx = Convert.ToDouble(tempMin);
                            maxx = Convert.ToDouble(tempMax);

                            minx *= 1000000000;
                            maxx *= 1000000000;

                            dataminSetScale = minx.ToString();
                            datamaxSetScale = maxx.ToString();
                        }
                        else
                        {
                            dataminSetScale = minScaleSetTextBox.Text;
                            datamaxSetScale = maxScaleSetTextBox.Text;
                        }


                        label1.Text = maxScaleSetTextBox.Text;
                        label2.Text = minScaleSetTextBox.Text;

                        serialPort1.WriteLine("*" + dataminSetScale + "*" + datamaxSetScale + "*");

                        minScaleSetTextBox.Clear();
                        maxScaleSetTextBox.Clear();

                        setButton.Enabled = false;
                        scaleButton.Enabled = true;
                        minScaleTextBox.Enabled = true;
                        maxScaleTextBox.Enabled = true;
                    }

                    else

                    {
                        //do something if NO
                    }*/
                    minScaleSetTextBox.Enabled = false;
                    maxScaleSetTextBox.Enabled = false;
                    minScaleTextBox.Enabled = true;
                    maxScaleTextBox.Enabled = true;
                }


            }
            else
            {
                MessageBox.Show("You have not been communicated!");
            }
        }
    }
}
