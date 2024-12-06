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

        int counter = 0;





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
            groupBox1.Font = new System.Drawing.Font("Arial", 8F);
            groupBox2.Font = new System.Drawing.Font("Arial", 8F);
            
            


        }

        private void FormScaling_Load(object sender, EventArgs e)
        {
            
             
            variables.comportx = true;
            
        }

       
       

        private void scaleButton_Click(object sender, EventArgs e)
        {
            
            if (variables.status == 66)
            {
                if(!variables.connectionLost)
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

                        /*if (variables.outputDevice == 1)
                            variables.serialPort.WriteLine("!!!!"); //mA
                        else if (variables.outputDevice == 2)
                            variables.serialPort.WriteLine("^^^^"); //Voltage*/



                        string tempMinn;
                        string tempMaxx;
                        double minxx;
                        double maxxx;

                        if (variables.type == 1)
                        {
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
                        else if (variables.type == 2)
                        {
                            if (variables.numT == 1)
                            {
                                double minScaleBar = Convert.ToDouble(minScaleTextBox.Text);
                                double maxScaleBar = Convert.ToDouble(maxScaleTextBox.Text);

                                if (minScaleBar < -250 || maxScaleBar > 850)
                                {
                                    MessageBox.Show("The value must be between -250 and 850 ");
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
                            else if (variables.numT == 12)//k
                            {
                                double minScaleBar = Convert.ToDouble(minScaleTextBox.Text);
                                double maxScaleBar = Convert.ToDouble(maxScaleTextBox.Text);

                                if (minScaleBar < 23.15 || maxScaleBar > 1123.15)
                                {
                                    MessageBox.Show("The value must be between 23.15 and 1123.15 ");
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

                                        minxx -= 273.15;
                                        maxxx -= 273.15;

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
                            else if (variables.numT == 13)//f
                            {
                                double minScaleBar = Convert.ToDouble(minScaleTextBox.Text);
                                double maxScaleBar = Convert.ToDouble(maxScaleTextBox.Text);

                                if (minScaleBar < -156.6667 || maxScaleBar > 454.4444)
                                {
                                    MessageBox.Show("The value must be between -156.6667 and 454.4444 ");
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

                                        minxx = (minxx - 32) / 1.8;
                                        maxxx = (maxxx - 32) / 1.8;

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
                        }



                    }
                }
                else
                {
                    if (variables.numEN == 10)
                        MessageBox.Show("No connection with device!");
                    else if (variables.numEN == 11)
                        MessageBox.Show("Cihazla bağlantınız yok!");
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
                counter = counter + 1; ;

                if (counter>=45)
                {
                    pictureBox1.Image = BASSCOMPORT.Properties.Resources.ok;
                    counter = 0;
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

                            lowerTemp = lowRange.ToString()+" Bar";
                            upperTemp = upperRange.ToString() + " Bar";

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



                        if(variables.owiStatus==1)
                            if(variables.numEN ==11)
                                label7.Text = "BAGLANILDI";
                            else if (variables.numEN == 10)
                                label7.Text = "CONNECTED";

                        if(variables.connectionLost)
                            if (variables.numEN == 11)
                                label7.Text = "BAGLANILAMADI";
                            else if (variables.numEN == 10)
                                label7.Text = "DISCONNECTED";
                           


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
                    
                    if (variables.isClickedScaling)
                    {
                        //pictureBox3.Image = BASSCOMPORT.Properties.Resources.tr;
                        //pictureBox4.Image = BASSCOMPORT.Properties.Resources.trupper;

                        statusLabel.Text = "Durum";

                        label1.Text = "Çıkış :";
                        scaleButton.Text = rm.GetString("CHANGE");
                        setButton.Text = "AYARLA";
                        //metroSetCheckBox1.Text = "El ile";
                        //label9.Text = "Tepe =";
                        //label8.Text = "Dip  =";

                        if (variables.type == 1)
                        {
                            if (variables.numP == 14)
                            {

                                label10.Text = "Default minScale" + "(Bar)";
                                label11.Text = "Default maxScale" + "(Bar)";
                                label16.Text = rm.GetString("Ayarlanacak minScale") + "(Bar)";
                                label18.Text = rm.GetString("Ayarlanacak maxScale") + "(Bar)";
                            }
                            else if (variables.numP == 15)
                            {

                                label16.Text = rm.GetString("Ayarlanacak minScale") + "(Pa)";
                                label18.Text = rm.GetString("Ayarlanacak maxScale") + "(Pa)";
                                label10.Text = "Default minScale" + "(Pa)";
                                label11.Text = "Default maxScale" + "(Pa)";
                            }
                            else if (variables.numP == 16)
                            {

                                label16.Text = rm.GetString("Ayarlanacak minScale") + "(kg/cm2)";
                                label18.Text = rm.GetString("Ayarlanacak maxScale") + "(kg/cm2)";
                                label10.Text = "Default minScale" + "(kg/cm2)";
                                label11.Text = "Default maxScale" + "(kg/cm2)";
                            }
                            else if (variables.numP == 17)
                            {

                                label16.Text = rm.GetString("Ayarlanacak minScale") + "(mmh2o)";
                                label18.Text = rm.GetString("Ayarlanacak maxScale") + "(mmh2o)";
                                label10.Text = "Default minScale" + "(mmh2o)";
                                label11.Text = "Default maxScale" + "(mmh2o)";
                            }
                            else if (variables.numP == 18)
                            {
                                label16.Text = rm.GetString("Ayarlanacak minScale") + "(mh2o)";
                                label18.Text = rm.GetString("Ayarlanacak maxScale") + "(mh2o)";
                                label10.Text = "Default minScale" + "(mh2o)";
                                label11.Text = "Default maxScale" + "(mh2o)";
                            }
                            else if (variables.numP == 19)
                            {
                                label16.Text = rm.GetString("Ayarlanacak minScale") + "(mmHg)";
                                label18.Text = rm.GetString("Ayarlanacak maxScale") + "(mmHg)";
                                label10.Text = "Default minScale" + "(mmHg)";
                                label11.Text = "Default maxScale" + "(mmHg)";
                            }
                            else if (variables.numP == 20)
                            {

                                label16.Text = rm.GetString("Ayarlanacak minScale") + "(psi)";
                                label18.Text = rm.GetString("Ayarlanacak maxScale") + "(psi)";
                                label10.Text = "Default minScale" + "(psi)";
                                label11.Text = "Default maxScale" + "(psi)";
                            }
                            else if (variables.numP == 21)
                            {

                                label16.Text = rm.GetString("Ayarlanacak minScale") + "(kPa)";
                                label18.Text = rm.GetString("Ayarlanacak maxScale") + "(kPa)";
                                label10.Text = "Default minScale" + "(kPa)";
                                label11.Text = "Default maxScale" + "(kPa)";
                            }
                            else if (variables.numP == 22)
                            {

                                label16.Text = rm.GetString("Ayarlanacak minScale") + "(MPa)";
                                label18.Text = rm.GetString("Ayarlanacak maxScale") + "(MPa)";
                                label10.Text = "Default minScale" + "(MPa)";
                                label11.Text = "Default maxScale" + "(MPa)";
                            }
                            else if (variables.numP == 23)
                            {

                                label16.Text = rm.GetString("Ayarlanacak minScale") + "(iwg)";
                                label18.Text = rm.GetString("Ayarlanacak maxScale") + "(iwg)";
                                label10.Text = "Default minScale" + "(iwg)";
                                label11.Text = "Default maxScale" + "(iwg)";
                            }
                            else
                            {

                                label16.Text = rm.GetString("Ayarlanacak minScale") + "(mbar)";
                                label18.Text = rm.GetString("Ayarlanacak maxScale") + "(mbar)";
                                label10.Text = "Default minScale" + "(mbar)";
                                label11.Text = "Default maxScale" + "(mbar)";
                            }
                        }
                        else if (variables.type == 2)
                        {
                            if (variables.numT == 12)
                            {
                                label10.Text = "Default minScale" + "(K°)";
                                label11.Text = "Default maxScale" + "(K°)";
                                label16.Text = rm.GetString("Ayarlanacak minScale") + "(K°)";
                                label18.Text = rm.GetString("Ayarlanacak maxScale") + "(K°)";
                            }
                            else if (variables.numT == 13)
                            {
                                label10.Text = "Default minScale" + "(F°)";
                                label11.Text = "Default maxScale" + "(F°)";
                                label16.Text = rm.GetString("Ayarlanacak minScale") + "(F°)";
                                label18.Text = rm.GetString("Ayarlanacak maxScale") + "(F°)";
                            }
                            else if (variables.numT == 1)
                            {
                                label10.Text = "Default minScale" + "(C°)";
                                label11.Text = "Default maxScale" + "(C°)";
                                label16.Text = rm.GetString("Ayarlanacak minScale") + "(C°)";
                                label18.Text = rm.GetString("Ayarlanacak maxScale") + "(C°)";
                            }

                        }


                        variables.isClickedScaling = false;
                    }




                    

            }

            else if (variables.numEN == 10)
            {
                    
                    if (variables.isClickedScaling)
                    {
                        //pictureBox3.Image = BASSCOMPORT.Properties.Resources.eng;
                        //pictureBox4.Image = BASSCOMPORT.Properties.Resources.engupper;

                        statusLabel.Text = "Status";

                        label1.Text = "Output :";
                        scaleButton.Text = "SCALE";
                        //metroSetCheckBox1.Text = "Manual";
                        setButton.Text = "SET";
                        //label9.Text = "Upper =";
                        //label8.Text = "Lower =";

                        if (variables.type == 1)
                        {
                            if (variables.numP == 14)
                            {

                                label16.Text = "minScale(Bar) to set";
                                label18.Text = "maxScale(Bar) to set";
                                label10.Text = "minScale(Bar) to set";
                                label11.Text = "maxScale(Bar) to set";
                            }
                            else if (variables.numP == 15)
                            {
                                label16.Text = "minScale(Pa) to set";
                                label18.Text = "maxScale(Pa) to set";
                                label10.Text = "minScale(Pa) to set";
                                label11.Text = "maxScale(Pa) to set";
                            }
                            else if (variables.numP == 16)
                            {

                                label16.Text = "minScale(kg/cm2) to set";
                                label18.Text = "maxScale(kg/cm2) to set";
                                label10.Text = "minScale(kg/cm2) to set";
                                label11.Text = "maxScale(kg/cm2) to set";
                            }
                            else if (variables.numP == 17)
                            {

                                label16.Text = "minScale(mmh2o) to set";
                                label18.Text = "maxScale(mmh2o) to set";
                                label10.Text = "minScale(mmh2o) to set";
                                label11.Text = "maxScale(mmh2o) to set";
                            }
                            else if (variables.numP == 18)
                            {

                                label16.Text = "minScale(mh2o) to set";
                                label18.Text = "maxScale(mh2o) to set";
                                label10.Text = "minScale(mh2o) to set";
                                label11.Text = "maxScale(mh2o) to set";
                            }
                            else if (variables.numP == 19)
                            {

                                label16.Text = "minScale(mmHg) to set";
                                label18.Text = "maxScale(mmHg) to set";
                                label10.Text = "minScale(mmHg) to set";
                                label11.Text = "maxScale(mmHg) to set";
                            }
                            else if (variables.numP == 20)
                            {

                                label16.Text = "minScale(psi) to set";
                                label18.Text = "maxScale(psi) to set";
                                label10.Text = "minScale(psi) to set";
                                label11.Text = "maxScale(psi) to set";
                            }
                            else if (variables.numP == 21)
                            {

                                label16.Text = "minScale(kPa) to set";
                                label18.Text = "maxScale(kPa) to set";
                                label10.Text = "minScale(kPa) to set";
                                label11.Text = "maxScale(kPa) to set";
                            }
                            else if (variables.numP == 22)
                            {

                                label16.Text = "minScale(MPa) to set";
                                label18.Text = "maxScale(MPa) to set";
                                label10.Text = "minScale(MPa) to set";
                                label11.Text = "maxScale(MPa) to set";
                            }
                            else if (variables.numP == 23)
                            {

                                label16.Text = "minScale(iwg) to set";
                                label18.Text = "maxScale(iwg) to set";
                                label10.Text = "minScale(iwg) to set";
                                label11.Text = "maxScale(iwg) to set";
                            }
                            else
                            {

                                label16.Text = "minScale(mbar) to set";
                                label18.Text = "maxScale(mbar) to set";
                                label10.Text = "minScale(mbar) to set";
                                label11.Text = "maxScale(mbar) to set";
                            }
                        }
                        else if (variables.type == 2)
                        {
                            if (variables.numT == 12)
                            {
                                label16.Text = "minScale(K°) to set";
                                label18.Text = "maxScale(K°) to set";
                                label10.Text = "minScale(K°) to set";
                                label11.Text = "maxScale(K°) to set";
                            }
                            else if (variables.numT == 13)
                            {
                                label16.Text = "minScale(F°) to set";
                                label18.Text = "maxScale(F°) to set";
                                label10.Text = "minScale(F°) to set";
                                label11.Text = "maxScale(F°) to set";
                            }
                            else if (variables.numT == 1)
                            {
                                label16.Text = "minScale(C°) to set";
                                label18.Text = "maxScale(C°) to set";
                                label10.Text = "minScale(C°) to set";
                                label11.Text = "maxScale(C°) to set";
                            }
                        }

                        variables.isClickedScaling = false;
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

        /*private void metroSetCheckBox1_CheckedChanged(object sender)
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
            
        }*/

        private void setButton_Click(object sender, EventArgs e)
        {
            if (variables.status==66)
            {
                if (!variables.connectionLost)
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

                        if (variables.type == 1)
                        {

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
                                        variables.timerScaling = true;

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

                                        timer1.Interval = 1000;//1 second
                                        timer1.Tick += new System.EventHandler(timer1_Tick);
                                        timer1.Start();

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
                                        variables.timerScaling = true;

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

                                        timer1.Interval = 1000;//1 second
                                        timer1.Tick += new System.EventHandler(timer1_Tick);
                                        timer1.Start();

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
                                        variables.timerScaling = true;

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

                                        timer1.Interval = 1000;//1 second
                                        timer1.Tick += new System.EventHandler(timer1_Tick);
                                        timer1.Start();

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
                                        variables.timerScaling = true;

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

                                        timer1.Interval = 1000;//1 second
                                        timer1.Tick += new System.EventHandler(timer1_Tick);
                                        timer1.Start();

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
                                        variables.timerScaling = true;

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

                                        timer1.Interval = 1000;//1 second
                                        timer1.Tick += new System.EventHandler(timer1_Tick);
                                        timer1.Start();

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
                                        variables.timerScaling = true;

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

                                        timer1.Interval = 1000;//1 second
                                        timer1.Tick += new System.EventHandler(timer1_Tick);
                                        timer1.Start();

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
                                        variables.timerScaling = true;

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

                                        timer1.Interval = 1000;//1 second
                                        timer1.Tick += new System.EventHandler(timer1_Tick);
                                        timer1.Start();

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
                                        variables.timerScaling = true;

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

                                        timer1.Interval = 1000;//1 second
                                        timer1.Tick += new System.EventHandler(timer1_Tick);
                                        timer1.Start();

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
                                        variables.timerScaling = true;

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

                                        //dataminSetScale = minScaleSetTextBox.Text;
                                        //datamaxSetScale = maxScaleSetTextBox.Text;

                                        timer1.Interval = 1000;//1 second
                                        timer1.Tick += new System.EventHandler(timer1_Tick);
                                        timer1.Start();

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
                                        variables.timerScaling = true;

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

                                        //dataminSetScale = minScaleSetTextBox.Text;
                                        //datamaxSetScale = maxScaleSetTextBox.Text;

                                        label12.Text = maxScaleSetTextBox.Text;
                                        label13.Text = minScaleSetTextBox.Text;

                                        timer1.Interval = 1000;//1 second
                                        timer1.Tick += new System.EventHandler(timer1_Tick);
                                        timer1.Start();

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
                                    MessageBox.Show("The value must be between -1000 and 1000000 ");
                                    minScaleSetTextBox.Clear();
                                    maxScaleSetTextBox.Clear();
                                    return;


                                }
                                else
                                {
                                    if (MessageBox.Show("Please confirm before proceed" + "\n" + "Do you want to Continue ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

                                    {
                                        variables.timerScaling = true;

                                        dataminSetScale = minScaleSetTextBox.Text;
                                        datamaxSetScale = maxScaleSetTextBox.Text;

                                        label12.Text = maxScaleSetTextBox.Text;
                                        label13.Text = minScaleSetTextBox.Text;

                                        variables.minscale = minScaleBar;
                                        variables.maxscale = maxScaleBar;

                                        timer1.Interval = 1000;//1 second
                                        timer1.Tick += new System.EventHandler(timer1_Tick);
                                        timer1.Start();

                                        variables.serialPort.WriteLine("*" + dataminSetScale + "*" + datamaxSetScale + "*");

                                        minScaleSetTextBox.Clear();
                                        maxScaleSetTextBox.Clear();


                                    }

                                }
                            }

                        }
                        else if (variables.type == 2)
                        {
                            if (variables.numT == 1)
                            {
                                double minScaleBar = Convert.ToDouble(minScaleSetTextBox.Text);
                                double maxScaleBar = Convert.ToDouble(maxScaleSetTextBox.Text);

                                if (minScaleBar < -250 || maxScaleBar > 850)
                                {
                                    MessageBox.Show("The value must be between -250 and 850 ");
                                    minScaleSetTextBox.Clear();
                                    maxScaleSetTextBox.Clear();
                                    return;


                                }
                                else
                                {
                                    if (MessageBox.Show("Please confirm before proceed" + "\n" + "Do you want to Continue ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

                                    {
                                        variables.timerScaling = true;

                                        dataminSetScale = minScaleSetTextBox.Text;
                                        datamaxSetScale = maxScaleSetTextBox.Text;

                                        label12.Text = maxScaleSetTextBox.Text;
                                        label13.Text = minScaleSetTextBox.Text;

                                        variables.minscale = minScaleBar;
                                        variables.maxscale = maxScaleBar;

                                        timer1.Interval = 1000;//1 second
                                        timer1.Tick += new System.EventHandler(timer1_Tick);
                                        timer1.Start();

                                        variables.serialPort.WriteLine("*" + dataminSetScale + "*" + datamaxSetScale + "*");

                                        minScaleSetTextBox.Clear();
                                        maxScaleSetTextBox.Clear();
                                    }



                                }

                            }
                            else if (variables.numT == 12) //k
                            {
                                double minScaleBar = Convert.ToDouble(minScaleSetTextBox.Text);
                                double maxScaleBar = Convert.ToDouble(maxScaleSetTextBox.Text);

                                if (minScaleBar < 23.15 || maxScaleBar > 1123.15)
                                {
                                    MessageBox.Show("The value must be between 23.15 and 1123.15 ");
                                    minScaleSetTextBox.Clear();
                                    maxScaleSetTextBox.Clear();
                                    return;


                                }
                                else
                                {
                                    if (MessageBox.Show("Please confirm before proceed" + "\n" + "Do you want to Continue ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

                                    {
                                        variables.timerScaling = true;

                                        tempMin = minScaleSetTextBox.Text;
                                        tempMax = maxScaleSetTextBox.Text;

                                        minx = Convert.ToDouble(tempMin);
                                        maxx = Convert.ToDouble(tempMax);

                                        minx -= 273.15;
                                        maxx -= 273.15;

                                        variables.minscale = minx;
                                        variables.maxscale = maxx;

                                        dataminSetScale = minx.ToString();
                                        datamaxSetScale = maxx.ToString();

                                        //dataminSetScale = minScaleSetTextBox.Text;
                                        //datamaxSetScale = maxScaleSetTextBox.Text;

                                        label12.Text = maxScaleSetTextBox.Text;
                                        label13.Text = minScaleSetTextBox.Text;

                                        timer1.Interval = 1000;//1 second
                                        timer1.Tick += new System.EventHandler(timer1_Tick);
                                        timer1.Start();

                                        variables.serialPort.WriteLine("*" + dataminSetScale + "*" + datamaxSetScale + "*");

                                        minScaleSetTextBox.Clear();
                                        maxScaleSetTextBox.Clear();



                                    }

                                }

                            }
                            else if (variables.numT == 13)//f
                            {
                                double minScaleBar = Convert.ToDouble(minScaleSetTextBox.Text);
                                double maxScaleBar = Convert.ToDouble(maxScaleSetTextBox.Text);

                                if (minScaleBar < -156.6667 || maxScaleBar > 454.4444)
                                {
                                    MessageBox.Show("The value must be between -156.6667 and 454.4444 ");
                                    minScaleSetTextBox.Clear();
                                    maxScaleSetTextBox.Clear();
                                    return;


                                }
                                else
                                {
                                    if (MessageBox.Show("Please confirm before proceed" + "\n" + "Do you want to Continue ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

                                    {
                                        variables.timerScaling = true;

                                        tempMin = minScaleSetTextBox.Text;
                                        tempMax = maxScaleSetTextBox.Text;

                                        minx = Convert.ToDouble(tempMin);
                                        maxx = Convert.ToDouble(tempMax);

                                        minx = (minx - 32) / 1.8;
                                        maxx = (maxx - 32) / 1.8;

                                        variables.minscale = minx;
                                        variables.maxscale = maxx;

                                        dataminSetScale = minx.ToString();
                                        datamaxSetScale = maxx.ToString();

                                        //dataminSetScale = minScaleSetTextBox.Text;
                                        //datamaxSetScale = maxScaleSetTextBox.Text;

                                        label12.Text = maxScaleSetTextBox.Text;
                                        label13.Text = minScaleSetTextBox.Text;

                                        timer1.Interval = 1000;//1 second
                                        timer1.Tick += new System.EventHandler(timer1_Tick);
                                        timer1.Start();

                                        variables.serialPort.WriteLine("*" + dataminSetScale + "*" + datamaxSetScale + "*");

                                        minScaleSetTextBox.Clear();
                                        maxScaleSetTextBox.Clear();



                                    }

                                }

                            }
                        }


                    }

                }
                else
                {
                    if (variables.numEN == 10)
                        MessageBox.Show("No connection with device!");
                    else if (variables.numEN == 11)
                        MessageBox.Show("Cihazla bağlantınız yok!");
                }

            }
            else
            {
                if (variables.numEN == 10)
                    MessageBox.Show("You have not been communicated w USB!");
                else if (variables.numEN == 11)
                    MessageBox.Show("USB ile bağlantınız yapılamadı!");
                
            }
        }

        private void progressBar1_ValueChanged(object sender)
        {

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
