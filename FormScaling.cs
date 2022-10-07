using System;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BASSCOMPORT
{
    public partial class FormScaling : Form


    {

        PointF firstLocation = new PointF(500f, 200f);  // upper değer
        PointF fourthLocation = new PointF(775f, 40f); // lower limit 
        PointF secondLocation = new PointF(475f, 40f); // upper limit
        PointF thirdLocation = new PointF(800f, 200f); // lower değer
        PointF fifthLocation = new PointF(120f, 80f); // output
        PointF sixthLocation = new PointF(120f, 130f); // output değer

        String lowerTemp;
        String upperTemp;

        String tempUpper;
        String tempLower;






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
        string dataminScale, datamaxScale;
        public static ResourceManager rm = new ResourceManager("BASSCOMPORT.tr_local", Assembly.GetExecutingAssembly());
        public static FormScaling client;
        public bool check = false;
        
        public FormScaling()
        {
            InitializeComponent();

            
            IntPtr ptr4 = CreateRoundRectRgn(0, 0, scaleButton.Width, scaleButton.Height, 15, 15);
            scaleButton.Region = System.Drawing.Region.FromHrgn(ptr4);
            DeleteObject(ptr4);

            
            scaleButton.NormalBadgeColor = System.Drawing.Color.Red;
            groupBox1.Font = new System.Drawing.Font("Arial", 12F);
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
            
            progressBar1.Maximum = 130;      
            variables.comportx = true;
            maxScaleSetTextBox.Enabled = false;
            minScaleSetTextBox.Enabled = false;
            setButton.Enabled = false;
        }

       
       

        private void scaleButton_Click(object sender, EventArgs e)
        {
            
            if (variables.status == 66)
            {
                if (minScaleTextBox.Text.Trim() == string.Empty || maxScaleTextBox.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please enter something in the textbox");
                    return; // return because we don't want to run normal code of buton click
                }
                else if (minScaleTextBox.Text.Trim() == maxScaleTextBox.Text.Trim())
                {
                    MessageBox.Show("Please enter different values");
                    return;
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

                                variables.timerScaling = true;

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

                                variables.serialPort.WriteLine("?" + dataminScale + "?" + datamaxScale + "?");


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

                                variables.timerScaling = true;

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

                                variables.serialPort.WriteLine("?" + dataminScale + "?" + datamaxScale + "?");

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
                                variables.timerScaling = true;

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

                                variables.serialPort.WriteLine("?" + dataminScale + "?" + datamaxScale + "?");

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
                                variables.timerScaling = true;


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

                                variables.serialPort.WriteLine("?" + dataminScale + "?" + datamaxScale + "?");

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
                                variables.timerScaling = true;


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

                                variables.serialPort.WriteLine("?" + dataminScale + "?" + datamaxScale + "?");

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

                                variables.timerScaling = true;

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

                                variables.serialPort.WriteLine("?" + dataminScale + "?" + datamaxScale + "?");

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

                                variables.timerScaling = true;

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

                                variables.serialPort.WriteLine("?" + dataminScale + "?" + datamaxScale + "?");

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

                                variables.timerScaling = true;

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

                                variables.serialPort.WriteLine("?" + dataminScale + "?" + datamaxScale + "?");

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

                        if (minScaleBar < -0.01 || maxScaleBar > 100)
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


                                variables.timerScaling = true;
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

                                variables.serialPort.WriteLine("?" + dataminScale + "?" + datamaxScale + "?");

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

                        if (minScaleBar < -402 || maxScaleBar > 401464)
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


                                variables.timerScaling = true;
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

                                variables.serialPort.WriteLine("?" + dataminScale + "?" + datamaxScale + "?");

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

                                variables.timerScaling = true;

                                dataminScale = minScaleTextBox.Text;
                                datamaxScale = maxScaleTextBox.Text;



                                label3.Text = maxScaleTextBox.Text;
                                label4.Text = minScaleTextBox.Text;

                                variables.serialPort.WriteLine("?" + dataminScale + "?" + datamaxScale + "?");

                                timer1.Interval = 1000;//1 second
                                timer1.Tick += new System.EventHandler(timer1_Tick);
                                timer1.Start();

                                minScaleTextBox.Clear();
                                maxScaleTextBox.Clear();




                            }

                        }

                    }



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

            if (variables.timerScaling)
            {
                pictureBox1.Image = BASSCOMPORT.Properties.Resources.output_onlinegiftools;
                pictureBox2.Image = BASSCOMPORT.Properties.Resources.output_onlinegiftools;
                progressBar1.Value += 13;
                if (progressBar1.Value == progressBar1.Maximum)
                {
                    progressBar1.Value = 0;
                    pictureBox1.Image = BASSCOMPORT.Properties.Resources.ok;
                    pictureBox2.Image = BASSCOMPORT.Properties.Resources.ok;
                    variables.timerScaling = false;
                }
            }
        }
        
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (variables.status == 66)
            {     
                        
                        if (variables.numP == 14)
                        {
                            double lowRange = variables.lowRange / 1000;
                            double upperRange = variables.upperRange /1000;

                            lowerTemp = variables.lowRange.ToString()+" Bar";
                            upperTemp = variables.upperRange.ToString() + " Bar";

                        }
                        else if (variables.numP == 15)
                        {
                            double lowRange = variables.lowRange * 100;
                            double upperRange = variables.upperRange * 100;

                            lowerTemp = lowRange.ToString() + " Pa";
                            upperTemp = upperRange.ToString() + " Pa";

                        }
                        else if (variables.numP == 16)
                        {
                            double lowRange = variables.lowRange * 0.0010197;
                            double upperRange = variables.upperRange * 0.0010197;

                            lowerTemp = lowRange.ToString() + " kg/cm2";
                            upperTemp = upperRange.ToString() + " kg/cm2";


                        }
                        else if (variables.numP == 17)
                        {
                            double lowRange = variables.lowRange * 10.20;
                            double upperRange = variables.upperRange * 10.20;
                            lowerTemp = lowRange.ToString() + " mmh2o";
                            upperTemp = upperRange.ToString() + " mmh2o";


                        }
                        else if (variables.numP == 18)
                        {

                            double lowRange = variables.lowRange * 0.010197;
                            double upperRange = variables.upperRange * 0.010197;

                            lowerTemp = lowRange.ToString() + " mh2o";
                            upperTemp = upperRange.ToString() + " mh2o";

                        }
                        else if (variables.numP == 19)
                        {
                            double lowRange = variables.lowRange * 0.750061683;
                            double upperRange = variables.upperRange * 0.750061683;

                            lowerTemp = lowRange.ToString() + " mmHg";
                            upperTemp = upperRange.ToString() + " mmHg";


                        }
                        else if (variables.numP == 20)
                        {
                            double lowRange = variables.lowRange * 0.0145037738;
                            double upperRange = variables.upperRange * 0.0145037738;

                            lowerTemp = lowRange.ToString() + " psi";
                            upperTemp = upperRange.ToString() + " psi";


                        }
                        else if (variables.numP == 21)
                        {
                            double lowRange = variables.lowRange * 0.1;
                            double upperRange = variables.upperRange * 0.1;

                            lowerTemp = lowRange.ToString() + " kPa";
                            upperTemp = upperRange.ToString() + " kPa";


                        }
                        else if (variables.numP == 22)
                        {
                            double lowRange = variables.lowRange * 0.0001;
                            double upperRange = variables.upperRange * 0.0001; 

                            lowerTemp = lowRange.ToString() + " MPa";
                            upperTemp = upperRange.ToString() + " MPa";

                        }
                        else if (variables.numP == 23)
                        {
                            double lowRange = variables.lowRange * 0.401325981;
                            double upperRange = variables.upperRange * 0.401325981;

                            lowerTemp = lowRange.ToString() + " inch water";
                            upperTemp = upperRange.ToString() + " inch water";


                        }

                        else if (variables.numP == 2)
                        {
                            double lowRange = variables.lowRange ;
                            double upperRange = variables.upperRange;

                            lowerTemp = lowRange.ToString() + " mbar";
                            upperTemp = upperRange.ToString() + " mbar";


                        }

                        label5.Text = upperTemp;
                        label7.Text = lowerTemp;

                if (variables.data_identify == 9)
                {
                    label6.Text = "---";
                }
                else if (variables.data_identify == 10)
                {
                    label6.Text = "4-20mA";
                }
                else if (variables.data_identify == 11)
                {
                    label6.Text = "0-10V";
                }







                if (variables.numEN == 11)
                {
                label1.Text = "Çıkış :";
                scaleButton.Text = rm.GetString("CHANGE");
                setButton.Text = "AYARLA";
                metroSetCheckBox1.Text = "El ile giriş";
                    label9.Text = "Tepe =";
                    label8.Text = "Dip  =";
                    pictureBox3.Image = BASSCOMPORT.Properties.Resources.tr;
                    pictureBox4.Image = BASSCOMPORT.Properties.Resources.trupper;
                    //groupBox1.Text = rm.GetString("Scaling");
                    // guideGroupBox.Text = rm.GetString("Guide");
                    // richTextBox2.Text = "Sonra ölçeklendirmek istediğiniz minimum ve maksimum değerleri giriniz ve DEĞİŞTİR butonuna tıklayınız. Lütfen 'OK' işaretini görene kadar bekleyiniz.";
                    //richTextBox1.Text = "Lütfen ürün etiketi üzerinde bulunan ölçeklendirme aralığını kontrol ediniz. Ardından minimum ve maksimum değerleri belirtilen kutucuklara giriniz ve AYARLA butonuna tıklayınız. Bu şekilde cihaza referans ölçeklendirme aralığı vermiş oluyoruz. ";





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
                   
                    label16.Text = rm.GetString("Ayarlanacak minScale") + "(mbar)";
                    label18.Text = rm.GetString("Ayarlanacak maxScale") + "(mbar)";

                }

            }

            else if (variables.numEN == 10)
            {
            
                label1.Text = "Output :";
                scaleButton.Text = "SCALE";
                metroSetCheckBox1.Text = "Manual";
                    setButton.Text = "SET";
                    label9.Text = "Upper =";
                    label8.Text = "Lower =";
                pictureBox3.Image = BASSCOMPORT.Properties.Resources.eng;
                    pictureBox4.Image = BASSCOMPORT.Properties.Resources.engupper;

              
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
            variables.scalingChange = false;



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

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void metroSetCheckBox1_CheckedChanged(object sender)
        {
            if (metroSetCheckBox1.Checked)
            {
                minScaleSetTextBox.Enabled = true;
                maxScaleSetTextBox.Enabled = true;
                setButton.Enabled = true;
            }
            else
            {
                minScaleSetTextBox.Enabled = false;
                maxScaleSetTextBox.Enabled = false;
                setButton.Enabled = false;
            }
            
        }

        private void setButton_Click(object sender, EventArgs e)
        {
            if (variables.status==66)
            {
                String dataminSetScale;
                String datamaxSetScale;
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

                                label12.Text = maxScaleSetTextBox.Text;
                                label13.Text = minScaleSetTextBox.Text;

                                variables.serialPort.WriteLine("*" + dataminSetScale + "*" + datamaxSetScale + "*");

                                minScaleSetTextBox.Clear();
                                maxScaleSetTextBox.Clear();


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
                                label12.Text = maxScaleSetTextBox.Text;
                                label13.Text = minScaleSetTextBox.Text;

                                variables.serialPort.WriteLine("*" + dataminSetScale + "*" + datamaxSetScale + "*");

                                minScaleSetTextBox.Clear();
                                maxScaleSetTextBox.Clear();


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

                                label12.Text = maxScaleSetTextBox.Text;
                                label13.Text = minScaleSetTextBox.Text;

                                variables.serialPort.WriteLine("*" + dataminSetScale + "*" + datamaxSetScale + "*");

                                minScaleSetTextBox.Clear();
                                maxScaleSetTextBox.Clear();


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

                                label12.Text = maxScaleSetTextBox.Text;
                                label13.Text = minScaleSetTextBox.Text;

                                variables.serialPort.WriteLine("*" + dataminSetScale + "*" + datamaxSetScale + "*");

                                minScaleSetTextBox.Clear();
                                maxScaleSetTextBox.Clear();



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

                                label12.Text = maxScaleSetTextBox.Text;
                                label13.Text = minScaleSetTextBox.Text;

                                variables.serialPort.WriteLine("*" + dataminSetScale + "*" + datamaxSetScale + "*");

                                minScaleSetTextBox.Clear();
                                maxScaleSetTextBox.Clear();


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

                                label12.Text = maxScaleSetTextBox.Text;
                                label13.Text = minScaleSetTextBox.Text;

                                variables.serialPort.WriteLine("*" + dataminSetScale + "*" + datamaxSetScale + "*");

                                minScaleSetTextBox.Clear();
                                maxScaleSetTextBox.Clear();


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

                                label12.Text = maxScaleSetTextBox.Text;
                                label13.Text = minScaleSetTextBox.Text;

                                variables.serialPort.WriteLine("*" + dataminSetScale + "*" + datamaxSetScale + "*");

                                minScaleSetTextBox.Clear();
                                maxScaleSetTextBox.Clear();

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
                                label12.Text = maxScaleSetTextBox.Text;
                                label13.Text = minScaleSetTextBox.Text;

                                variables.serialPort.WriteLine("*" + dataminSetScale + "*" + datamaxSetScale + "*");

                                minScaleSetTextBox.Clear();
                                maxScaleSetTextBox.Clear();


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

                                label12.Text = maxScaleSetTextBox.Text;
                                label13.Text = minScaleSetTextBox.Text;

                                variables.serialPort.WriteLine("*" + dataminSetScale + "*" + datamaxSetScale + "*");

                                minScaleSetTextBox.Clear();
                                maxScaleSetTextBox.Clear();


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

                                label12.Text = maxScaleSetTextBox.Text;
                                label13.Text = minScaleSetTextBox.Text;

                                variables.serialPort.WriteLine("*" + dataminSetScale + "*" + datamaxSetScale + "*");

                                minScaleSetTextBox.Clear();
                                maxScaleSetTextBox.Clear();



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

                                label12.Text = maxScaleSetTextBox.Text;
                                label13.Text = minScaleSetTextBox.Text;

                                variables.minscale = minScaleBar;
                                variables.maxscale = maxScaleBar;

                                variables.serialPort.WriteLine("*" + dataminSetScale + "*" + datamaxSetScale + "*");

                                minScaleSetTextBox.Clear();
                                maxScaleSetTextBox.Clear();


                            }

                        }
                    }
                   

                }


            }
            else
            {
                MessageBox.Show("You have not been communicated!");
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
