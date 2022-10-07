using Ganss.Excel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Reflection;
using System.Resources;
using System.Threading;
using System.Windows.Forms;

namespace BASSCOMPORT
{


    public partial class frrmMain : Form

    {


        public static ResourceManager rm = new ResourceManager("BASSCOMPORT.tr_local", Assembly.GetExecutingAssembly());
        bool mupdateData = false;
        bool nupdateData = false;
        bool kupdateData = false;
        bool trying = false;
        bool trying2 = false;
        bool trying3 = false;
        private Form activeForm;
        

        FormSettings formSettings = new FormSettings();
        FormFlow formFlow = new FormFlow();
        FormScaling formScaling = new FormScaling();
        FormAbout formAbout = new FormAbout();
        public event Action ChangeForm;
        private Button currentButton;
        private Random random;
        private int tempIndex;




        #region my Own Method
        public abstract class LogBase
        {
            public abstract void Log(double x, double y);


        }

        public class formList
        {
            public static FormSettings formSettings = new FormSettings();
            public static FormSettings _formSettings
            {
                get { return formSettings; }

            }

            public static FormFlow formFlow = new FormFlow();
            public static FormFlow _formFlow
            {
                get { return formFlow; }

            }

            public static FormScaling formScaling = new FormScaling();
            public static FormScaling _formScaling
            {
                get { return formScaling; }

            }

            public static FormAbout formAbout = new FormAbout();
            public static FormAbout _formAbout
            {
                get { return formAbout; }

            }

        }

        public Button FlowButton
        {
            get { return button5; }
            set { button5 = value; }

        }

        public Button Button4
        {
            get { return flowButton; }
            set { flowButton = value; }

        }

        public Button Button5
        {
            get { return button5; }
            set { button5 = value; }

        }
        public void enableButton()
        {
            flowButton.Enabled = true;
            button5.Enabled = true;
            button5.Enabled = true;
        }


        public class Logger : LogBase
        {
            private string CurrentDirectory
            {
                get;
                set;
            }

            private string FileName
            {
                get;
                set;
            }

            private string FilePath
            {
                get;
                set;
            }
            public Logger()
            {
                this.CurrentDirectory = Directory.GetCurrentDirectory();
                this.FileName = "Log.txt";
                this.FilePath = this.CurrentDirectory + "/" + this.FileName;
            }

            public override void Log(double x, double y)
            {
                using (System.IO.StreamWriter w = System.IO.File.AppendText(this.FilePath))
                {
                    w.WriteLine("Time = {0}  {1}  Temperature {2} C°  Pressure = {3} bar", DateTime.Now.ToLongDateString(), DateTime.Now.ToLongTimeString(), x, y);
                    w.WriteLine(" -------------------------------------------");

                }
            }
        }

        public class dataExcel
        {
            public static void Main(double x, double y, string time)
            {
                var data_TP = new List<Data_TP>
                {

                    new Data_TP {Temperature = x , Pressure = y , Time = time},
                    new Data_TP {Temperature = x , Pressure = y , Time = time}

                };

                ExcelMapper mapper = new ExcelMapper();
                var newFile = @"C:\Users\arge2\Desktop\Arayüz - Copy - Copy - Copy - Copy - Copy\BASSCOMPORT\BASSCOMPORT\bin\Debug\dataExcel.xlsx";
                mapper.Save(newFile, data_TP, "SheetName", true);
            }
        }

        public class Data_TP
        {
            public double Temperature { get; set; }
            public double Pressure { get; set; }

            public string Time { get; set; }
        }



       

        #endregion

        
       
        #region GUI Method

        public frrmMain()
        {
            Thread t = new Thread(new ThreadStart(StartForm));
            t.Start();
            variables.numEN = 10;
            Thread.Sleep(3500);
            InitializeComponent();
            groupBox8.Font = new System.Drawing.Font("Arial", 8F);
            label8.Font = new System.Drawing.Font("Arial", 12F);
            label9.Font = new System.Drawing.Font("Arial", 12F);
            label12.Font = new System.Drawing.Font("Arial", 12F);
            label17.Font = new System.Drawing.Font("Arial", 12F);
            t.Abort();
            variables.comportx = false;

            


            random = new Random();




        }
        public void StartForm()
        {

            //Application.Run(new splashScreen());
        }

        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;

                }
            }
        }
        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;

                }
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        public void Form1_Load(object sender, EventArgs e)
        {
            settingButton.BackColor = Color.FromArgb(0, 87, 149);
            button4.BackColor = Color.FromArgb(0, 87, 149);
            flowButton.BackColor = Color.FromArgb(0, 87, 149);
            button5.BackColor = Color.FromArgb(0, 87, 149);
            button5.Enabled = false;
            flowButton.Enabled = false;
            button5.Enabled = false;
            variables.numT = 1;
            variables.numP = 2;
            variables.scalingphotocheck = false;
            
            
            timer1.Enabled = true;
            timer1.Interval = 1000;
            timer1.Start();
            

            //ActivateButton(sender);



            // OpenChildForm(new FormSettings(),  sender);



            formSettings.TopLevel = false;
            formSettings.FormBorderStyle = FormBorderStyle.None;
            formSettings.Dock = DockStyle.Fill;
            this.panelDesktopPanel.Controls.Add(formSettings);
            this.panelDesktopPanel.Tag = formSettings;
            formSettings.BringToFront();
            formSettings.Show();



            formList._formSettings.TopLevel = false;
            formList._formSettings.FormBorderStyle = FormBorderStyle.None;
            formList._formSettings.Dock = DockStyle.Fill;
            this.panelDesktopPanel.Controls.Add(formList._formSettings);
            this.panelDesktopPanel.Tag = formList._formSettings;
            formList._formSettings.BringToFront();
            formList._formSettings.Show();

            

            flowButton.Enabled = true;
            button5.Enabled = true;
            button5.Enabled = true;





        }
        private void oPENToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }




        private void OpenChildForm(Form childForm, object btnSender)
        {




            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktopPanel.Controls.Add(childForm);
            this.panelDesktopPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();




        }





        private void cLOSEToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }




        private void toolStripComboBox2_DropDownClosed(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void tBoxDataOut_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                this.doSomething();
                e.Handled = true;
                e.SuppressKeyPress = true;

            }

        }

        private void doSomething()
        {

        }

        private void chBoxWriteLine_ChangeUICues(object sender, UICuesEventArgs e)
        {

        }

        private void groupBox9_Enter(object sender, EventArgs e)
        {

        }

        private void label7_Click_1(object sender, EventArgs e)
        {

        }

        public void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {

        }







        private void lblDataInLength_Click(object sender, EventArgs e)
        {

        }

        private void chBoxDTREnable_ChangeUICues(object sender, UICuesEventArgs e)
        {

        }

        private void cOMToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void endLineToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }



        private void toolStripComboBox_appendOrOverwriteText_DropDownClosed(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox_writeLineOrwriteText_Click(object sender, EventArgs e)
        {

        }


        private void showDataToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form2 objForm2 = new Form2(this);
            objForm2.Show();
        }

        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            label8.Text = DateTime.Now.ToLongTimeString();
            label9.Text = DateTime.Now.ToLongDateString();

            if (variables.numEN == 11)
            {
                settingButton.Image = BASSCOMPORT.Properties.Resources.ayarlar;
                button4.Image = BASSCOMPORT.Properties.Resources.olceklendirme;
                flowButton.Image = BASSCOMPORT.Properties.Resources.izleme;
                button5.Image = BASSCOMPORT.Properties.Resources.hakkında;
                closeSerialButton.Text = "Yeni Ölçeklendirme";
            }
            else if (variables.numEN == 10)
            {
                settingButton.Image = BASSCOMPORT.Properties.Resources.settings;
                button4.Image = BASSCOMPORT.Properties.Resources.scaling;
                flowButton.Image = BASSCOMPORT.Properties.Resources.monitoring;
                button5.Image = BASSCOMPORT.Properties.Resources.about;
                closeSerialButton.Text = "New Scaling";
            }
        
            
            /*if (variables.numEN == 11)
            {
                if (trying2 == false)
                {
                    settingsButton.Text = rm.GetString("Settings");
                    button4.Text = rm.GetString("Scaling");
                    flowButton.Text = rm.GetString("Flow");
                    button5.Text = rm.GetString("About");
                    closeSerialButton.Text = "Yeni Ölçeklendirme";
                    trying2 = true;
                }

            }
            else if (variables.numEN == 10)
            {
                settingsButton.Text = "   Settings";
                button4.Text = "   Scaling";
                flowButton.Text = "   Flow";
                button5.Text = "   About";
                closeSerialButton.Text = "   New Scaling";
                trying2 = false;
            }*/
            if (variables.status == 66)
            {

                if (trying == false)
                {
                    lblStatusCom.Text = "ON";
                    trying = true;
                }

            }
            else if (variables.status == 67)
            {
                trying = false;
                lblStatusCom.Text = "OFF";
            }


        }

        private void label8_Click(object sender, EventArgs e)
        {

        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }



        private void tBoxDataOut_KeyDown_1(object sender, KeyEventArgs e)
        {

        }

        private void tBoxDataIN_TextChanged(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox3_Click(object sender, EventArgs e)
        {

        }

        private void serialPort1_PinChanged(object sender, SerialPinChangedEventArgs e)
        {

        }

        private void tBfilterDegree_TextChanged(object sender, EventArgs e)
        {

        }

        private void tBfilterSample_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }



        private void solidGauge1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

            //this.solidGauge1.ForeGround = Brushes.WhiteSmoke;
        }


        private void solidGauge2_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {
            //this.solidGauge2.ForeGround = Brushes.WhiteSmoke;
        }

        private void elementHost1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox11_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter_1(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void bASSINSTRUMENTSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://bass.com.tr/en/Home");
        }

        private void saveToToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void userManualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form userM = new form();
            userM.ShowDialog();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            
        }

        private void cBoxCOMPORT_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void metroSetLabel1_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick_1(object sender, EventArgs e)
        {

        }

        private void saveDataButton_Click(object sender, EventArgs e)
        {


        }

        private void maxScaleTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void productsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://bass.com.tr/en/products");
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void settingsButton_Click(object sender, EventArgs e)
        {

            /*if (variables.status == 66)
            {*/
                ActivateButton(sender);


                formList._formSettings.TopLevel = false;
                formList._formSettings.FormBorderStyle = FormBorderStyle.None;
                formList._formSettings.Dock = DockStyle.Fill;
                this.panelDesktopPanel.Controls.Add(formList._formSettings);
                this.panelDesktopPanel.Tag = formList._formSettings;
                formList._formSettings.BringToFront();
                formList._formSettings.Show();




                //OpenChildForm(new FormFlow(),sender);

            /*}

            else
            {
                if (variables.numEN == 11)
                {
                    MessageBox.Show("Lütfen seri porta bağlanınız!");
                }
                else
                {
                    MessageBox.Show("Please connect to serial port!");
                }
            }*/

        }

        private void flowButton_Click(object sender, EventArgs e)
        {
            if (variables.status ==66)
            {
                
                ActivateButton(sender);




                if (nupdateData == false)
                {
                    //settingsButton.Enabled = false;

                    nupdateData = true;
                }

                


                formList._formFlow.TopLevel = false;
                formList._formFlow.FormBorderStyle = FormBorderStyle.None;
                formList._formFlow.Dock = DockStyle.Fill;
                this.panelDesktopPanel.Controls.Add(formList._formFlow);
                this.panelDesktopPanel.Tag = formList._formFlow;
                formList._formFlow.BringToFront();
                formList._formFlow.Show();




                //OpenChildForm(new FormFlow(),sender);

            }

            else
            {
                if (variables.numEN == 11)
                {
                    MessageBox.Show("Lütfen seri porta bağlanınız!");
                }
                else
                {
                    MessageBox.Show("Please connect to serial port!");
                }
            }



        }



        private void button4_Click(object sender, EventArgs e)
        {
            if (variables.status == 66)
            {
                ActivateButton(sender);
                /*formList._formFlow.Hide();
                formList._formSettings.Hide();*/

                if (kupdateData == false)
                {
                    //settingsButton.Enabled = false;

                    kupdateData = true;
                }

                


                formList._formScaling.TopLevel = false;
                formList._formScaling.FormBorderStyle = FormBorderStyle.None;
                formList._formScaling.Dock = DockStyle.Fill;
                this.panelDesktopPanel.Controls.Add(formList._formScaling);
                this.panelDesktopPanel.Tag = formList._formScaling;
                formList._formScaling.BringToFront();
                formList._formScaling.Show();

                //OpenChildForm(new FormScaling(), sender);

            }

            else
            {
                if (variables.numEN == 11)
                {
                    MessageBox.Show("Lütfen seri porta bağlanınız!");
                }
                else
                {
                    MessageBox.Show("Please connect to serial port!");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (variables.status == 66)
            {
                ActivateButton(sender);
                if (kupdateData == false)
                {
                    // settingsButton.Enabled = false;

                    kupdateData = true;
                }

                

                formList._formAbout.TopLevel = false;
                formList._formAbout.FormBorderStyle = FormBorderStyle.None;
                formList._formAbout.Dock = DockStyle.Fill;
                this.panelDesktopPanel.Controls.Add(formList._formAbout);
                this.panelDesktopPanel.Tag = formList._formAbout;
                formList._formAbout.BringToFront();
                formList._formAbout.Show();

                //OpenChildForm(new FormAbout(), sender);

            }

            else
            {
                if (variables.numEN == 11)
                {
                    MessageBox.Show("Lütfen seri porta bağlanınız!");
                }
                else
                {
                    MessageBox.Show("Please connect to serial port!");
                }
            }
        }



        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void cartesianChart1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }


        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void scaleButton_Click(object sender, EventArgs e)
        {


        }

        private void label12_Click_1(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void panelDesktopPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {

            //e.Cancel = true;

        }

        private void closeSerialButton_Click(object sender, EventArgs e)
        {
            Application.Restart();
            Environment.Exit(0);

        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {

        }

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
