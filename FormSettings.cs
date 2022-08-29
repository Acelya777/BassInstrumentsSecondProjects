using System;
using System.ComponentModel;
using System.Drawing;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static BASSCOMPORT.frrmMain;


namespace BASSCOMPORT
{
    
    public partial class FormSettings : Form
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

        bool tryMe = false;
        public int enNumber = 0;
        SerialPort myPort;
        private bool updateData2 = false;
        double identify = 0, empty = 0;


        public FormSettings()
        {
            InitializeComponent();
            // make panel rounded
            this.FormBorderStyle = FormBorderStyle.None;
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            //make group boxes rounded
            IntPtr ptr = CreateRoundRectRgn(0, 0, groupBox1.Width, groupBox1.Height, 40, 40);
            groupBox1.Region = Region.FromHrgn(ptr);
            DeleteObject(ptr);
            IntPtr ptr2 = CreateRoundRectRgn(0, 0, groupBox2.Width, groupBox2.Height, 15, 15);
            groupBox2.Region = Region.FromHrgn(ptr2);
            DeleteObject(ptr2);
            IntPtr ptr3 = CreateRoundRectRgn(0, 0, btnOpen.Width, btnOpen.Height, 15, 15);
            btnOpen.Region = Region.FromHrgn(ptr3);
            DeleteObject(ptr3);


            groupBox1.Font = new System.Drawing.Font("Arial", 12F);
            groupBox2.Font = new System.Drawing.Font("Arial", 12F);

            label4.Font = new System.Drawing.Font("Arial", 12F);
           

         

        }

        private void FormSettings_Load(object sender, EventArgs e)
        {

            
            if (variables.numEN == 11)
            {
                progressBar1.CustomText = "Bekleniyor...";
            }
            else if (variables.numEN == 10)
            {
                progressBar1.CustomText = "Waiting...";
            }
            

            comboBox1.Items.AddRange(new object[] { "Türkçe", "English" });
            comboBox1.SelectedItem = null;
            comboBox1.SelectedIndex = 1;

            comboBox2.Items.AddRange(new object[] { "Celcius(°C)", "Kelvin(K)", "Fahrenheit(°F)" });
            comboBox2.SelectedItem = null;
            comboBox2.SelectedIndex = 0;

            comboBox3.Items.AddRange(new object[] { "mBar", "Bar", "Pa", "kPa", "MPa", "kg/cm2", "mmh2o", "mh2o", "mmHg", "psi" ,"inch water"});
            comboBox3.SelectedItem = null;
            comboBox3.SelectedIndex = 0;

            if (variables.status == 66)
            {
                btnClose.Enabled = true;
            }
            else 
            {
                btnClose.Enabled = false;
            }
            

            try
            {



                string[] ports = SerialPort.GetPortNames();
                cBoxCOMPORT.Items.Clear();
                cBoxCOMPORT.Items.AddRange(ports);

                cBoxBaudRate.SelectedItem = null;
                cBoxBaudRate.SelectedText = "9600";
                cBoxDataBits.SelectedItem = null;
                cBoxDataBits.SelectedText = "8";
                cBoxStopBits.SelectedItem = null;
                cBoxStopBits.SelectedText = "One";
                cBoxParity.SelectedItem = null;
                cBoxParity.SelectedText = "None";




                serialPort1.PortName = cBoxCOMPORT.Text;
                serialPort1.BaudRate = Convert.ToInt32(cBoxBaudRate.Text);
                serialPort1.DataBits = Convert.ToInt32(cBoxDataBits.Text);
                serialPort1.StopBits = (StopBits)Enum.Parse(typeof(StopBits), cBoxStopBits.Text);
                serialPort1.Parity = (Parity)Enum.Parse(typeof(Parity), cBoxParity.Text);
                progressBar1.Value = 100;

            }

            catch (Exception err)
            {

                //MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }

        }
        

        
        private void btnOpen_Click(object sender, EventArgs e)
        {


            try
            {



                serialPort1.PortName = cBoxCOMPORT.Text;
                serialPort1.BaudRate = Convert.ToInt32(cBoxBaudRate.Text);
                serialPort1.DataBits = Convert.ToInt32(cBoxDataBits.Text);
                serialPort1.StopBits = (StopBits)Enum.Parse(typeof(StopBits), cBoxStopBits.Text);
                serialPort1.Parity = (Parity)Enum.Parse(typeof(Parity), cBoxParity.Text);
                variables.serialPort = serialPort1;
                try
                {
                    variables.serialPort.Open();
                    variables.status = 66;
                    //variables.connection2 = true;
                    
                    progressBar1.Value = 100;
                    if (variables.numEN == 11)
                    {
                        
                        progressBar1.CustomText = "BAĞLANDI";
                        //label4.BackColor = System.Drawing.Color.Transparent;



                    }
                    else
                    {
                        
                        progressBar1.CustomText = "CONNECTED";
                        //label4.BackColor = System.Drawing.Color.Transparent;

                    }

                    progressBar1.Visible = true;
                    

                    btnOpen.Enabled = false;
                    btnClose.Enabled = true;
                }
                catch (Exception)
                {

                    throw;
                }
                


            }

            catch (Exception err)
            {

                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnOpen.Enabled = true;
                btnClose.Enabled = false;

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (variables.serialPort.IsOpen)
            {
                try
                {
                    variables.serialPort.Close(); //close the serial port
                    this.Invoke(new EventHandler(NowClose)); //now close back in the main thread
                    progressBar1.Value = 0;
                    if (variables.numEN == 11)
                    {
                        progressBar1.CustomText = "KESİLDİ";
                        
                        


                    }
                    else
                    {
                        progressBar1.CustomText = "DISCONNECTED";
                        
                        

                    }
                    btnOpen.Enabled = true;
                    btnClose.Enabled = false;
                    variables.status = 67;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message); //catch any serial port closing error messages
                }
                
            }
            else
            {
                MessageBox.Show("Serial port is already close!");
            }


        }

        private void NowClose(object sender, EventArgs e)
        {
            //this.Close(); //now close the form
        }





        private void cBoxCOMPORT_DropDown(object sender, EventArgs e)
        {

            string[] ports = SerialPort.GetPortNames();
            cBoxCOMPORT.Items.Clear();
            cBoxCOMPORT.Items.AddRange(ports);

        }

        private void FormSettings_FormClosing(object sender, FormClosingEventArgs e)
        {

            e.Cancel = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = BASSCOMPORT.Properties.Resources.ok2;
            //variables.numEN = 11;

            if (comboBox1.SelectedItem.ToString() == "Türkçe")
            {
                variables.numEN = 11;
                variables.xx = true;
                variables.tryMe = false;
                variables.trP = false;


                label1.Text = rm.GetString("Language");
                label2.Text = rm.GetString("Temperature Unit");
                label3.Text = rm.GetString("Pressure Unit");
                btnOpen.Text = rm.GetString("OPEN");
                btnClose.Text = rm.GetString("CLOSE");
                button1.Text = rm.GetString("CHANGE");
                button2.Text = rm.GetString("CHANGE");
                button3.Text = rm.GetString("CHANGE");
                label14.Text = rm.GetString("BAUD RATE");
                label19.Text = rm.GetString("DATA BITS");
                label20.Text = rm.GetString("STOP BITS");
                label23.Text = rm.GetString("PARITY");
                groupBox1.Text = rm.GetString("COM PORT SETTINGS");
                groupBox2.Text = rm.GetString("PREFERENCES");
                    if (variables.status==66)
                    {
                        if (variables.numEN == 11)
                        {
                        label4.Text = "BAĞLANDI";
                        }
                        
                    }
                    else
                    {
                        if (variables.numEN == 11)
                        {
                        label4.Text = "KESİLDİ";

                        }
                        
                    }
            
            }
            else if (comboBox1.SelectedItem.ToString() == "English")
            {
                variables.tryMe = false;
                variables.numEN = 10;
                variables.enP = false;
                label1.Text = "Language";
                label2.Text = "Temperature Unit";
                label3.Text = "Pressure Unit";
                btnOpen.Text = "OPEN";
                btnClose.Text = "CLOSE";
                button1.Text = "CHANGE";
                button2.Text = "CHANGE";
                button3.Text = "CHANGE";
                label14.Text = "BAUD RATE";
                label19.Text = "DATA BITS";
                label20.Text = "STOP BITS";
                label23.Text = "PARITY";
                groupBox1.Text = "COM PORT SETTINGS";
                groupBox2.Text = "PREFERENCES";
                if (variables.status == 66)
                {
                    label4.Text = "CONNECTED";
                }
                else
                {
                    label4.Text = "DISCONNECTED";
                }
            }

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = BASSCOMPORT.Properties.Resources.ok2;
            if (comboBox2.SelectedItem.ToString() == "Kelvin(K)")
            {
                variables.numT = 12;
                variables.tryMe = false;
            }
            else if (comboBox2.SelectedItem.ToString() == "Fahrenheit(°F)")
            {
                variables.numT = 13;
                variables.tryMe = false;
            }
            else if (comboBox2.SelectedItem.ToString() == "Celcius(°C)")
            {
                variables.numT = 1;
                variables.tryMe = false;
            }

            

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {   // "mBar", "Bar","Pa", "kg/s2","mmh2o","mh2o","mmHg","psi","kPa","MPa"
            pictureBox3.Image = BASSCOMPORT.Properties.Resources.ok2;
            if (comboBox3.SelectedItem.ToString() == "Bar")
            {
                variables.numP = 14;
                variables.tryMe = false;
            }
            else if (comboBox3.SelectedItem.ToString() == "Pa")
            {
                variables.numP = 15;
                variables.tryMe = false;
            }
            else if (comboBox3.SelectedItem.ToString() == "kg/cm2")
            {
                variables.numP = 16;
                variables.tryMe = false;
            }
            else if (comboBox3.SelectedItem.ToString() == "mmh2o")
            {
                variables.numP = 17;
                variables.tryMe = false;
            }
            else if (comboBox3.SelectedItem.ToString() == "mh2o")
            {
                variables.numP = 18;
                variables.tryMe = false;
            }
            else if (comboBox3.SelectedItem.ToString() == "mmHg")
            {
                variables.numP = 19;
                variables.tryMe = false;
            }
            else if (comboBox3.SelectedItem.ToString() == "psi")
            {
                variables.numP = 20;
                variables.tryMe = false;
            }
            else if (comboBox3.SelectedItem.ToString() == "kPa")
            {
                variables.numP = 21;
                variables.tryMe = false;
            }
            else if (comboBox3.SelectedItem.ToString() == "MPa")
            {
                variables.numP = 22;
                variables.tryMe = false;
            }
            else if (comboBox3.SelectedItem.ToString() == "inch water")
            {
                variables.numP = 23;
                variables.tryMe = false;
            }
            else if (comboBox3.SelectedItem.ToString() == "mBar")
            {
                variables.numP = 2;
                variables.tryMe = false;
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (variables.numEN == 11)
            {
                if (variables.status == 66)
                {
                    progressBar1.CustomText = "BAĞLANDI";
                }
                else 
                {
                    progressBar1.CustomText = "KESİLDİ";
                }
            }
            else if (variables.numEN == 10)
            {
                if (variables.status == 66)
                {
                    progressBar1.CustomText = "CONNECTED";
                }
                else 
                {
                    progressBar1.CustomText = "DISCONNECTED";
                }
            }
            if (!variables.comportx)
            {
                groupBox1.Enabled = true;

            }
            else if (variables.comportx)
            {
                groupBox1.Enabled = false;
            }
        }

        public class MyLabel : Label
        {
            private bool fTransparent = false;
            public bool Transparent
            {
                get { return fTransparent; }
                set { fTransparent = value; }
            }
            public MyLabel() : base()
            {
            }
            protected override CreateParams CreateParams
            {
                get
                {
                    if (fTransparent)
                    {
                        CreateParams cp = base.CreateParams;
                        cp.ExStyle |= 0x00000020; //WS_EX_TRANSPARENT
                        return cp;
                    }
                    else return base.CreateParams;
                }
            }
            protected override void WndProc(ref Message m)
            {
                if (fTransparent)
                {
                    if (m.Msg != 0x14 /*WM_ERASEBKGND*/ && m.Msg != 0x0F /*WM_PAINT*/)
                        base.WndProc(ref m);
                    else
                    {
                        if (m.Msg == 0x0F) // WM_PAINT
                            base.OnPaint(new PaintEventArgs(Graphics.FromHwnd(Handle), ClientRectangle));
                        DefWndProc(ref m);
                    }
                }
                else base.WndProc(ref m);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

       
    }




}
