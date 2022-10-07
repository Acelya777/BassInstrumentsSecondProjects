using BASSCOMPORT.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace BASSCOMPORT
{
    public partial class FormAbout : Form
    {
        private Bitmap image1 = BASSCOMPORT.Properties.Resources.image1;
        private Bitmap image2 = BASSCOMPORT.Properties.Resources.image2;
        private Bitmap image3 = BASSCOMPORT.Properties.Resources.image3;
        private Bitmap image4 = BASSCOMPORT.Properties.Resources.image4;
        private Bitmap image6 = BASSCOMPORT.Properties.Resources.image6;
        private Bitmap image7 = BASSCOMPORT.Properties.Resources.image7;
        private Bitmap image8 = BASSCOMPORT.Properties.Resources.image8;
        private Bitmap image9 = BASSCOMPORT.Properties.Resources.image9;

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


        public static ResourceManager rm = new ResourceManager("BASSCOMPORT.tr_local", Assembly.GetExecutingAssembly());
        Image instagram = Resources.icons8_instagram_65;
        //Image home = Resources.icons8_home_65;
        Image twitter = Resources.icons8_twitter_65;
        Image linkedn = Resources.linkedn2;
        private Random random;
        bool trying = false;
        bool trying2 = false;
        private int tempIndex;
        public SmtpClient client = new SmtpClient();
        public MailMessage msg = new MailMessage();
        public System.Net.NetworkCredential smtpCreds = new System.Net.NetworkCredential("mail", "password");
        MailMessage message = new MailMessage();
        SmtpClient smtp = new SmtpClient();
        

        public FormAbout()
        {
            InitializeComponent();
            groupBox1.Font = new System.Drawing.Font("Arial", 12F);
            
            IntPtr ptr = CreateRoundRectRgn(0, 0, groupBox1.Width, groupBox1.Height, 15, 15);
            groupBox1.Region = System.Drawing.Region.FromHrgn(ptr);
            DeleteObject(ptr);
            /*IntPtr ptr2 = CreateRoundRectRgn(0, 0, pictureBox8.Width, pictureBox8.Height, 30, 30);
            pictureBox8.Region = System.Drawing.Region.FromHrgn(ptr2);
            DeleteObject(ptr2);*/

            //pictureBox1.Image = home;
            /*pictureBox2.Image = instagram;
            pictureBox3.Image = twitter;
            pictureBox4.Image = linkedn;
            */
        }

        private int imageno = 1;
        private int imageno2 = 6;

        private void loadimage()
        {
            
            if (imageno == 4)
            {
                imageno = 1;
                
            }
            
            //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox8.ImageLocation = string.Format(@"Images\{0}.png", imageno);

            imageno++;
        }
        private void loadimage2()
        {

            if (imageno2 == 9)
            {
                imageno2 = 6;

            }

            //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox8.ImageLocation = string.Format(@"Images\{0}.png", imageno2);

            imageno2++;
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
        private void FormAbout_Load(object sender, EventArgs e)
        {
            if (variables.numEN == 11)
            {
                pictureBox5.Image = BASSCOMPORT.Properties.Resources.com2;
                pictureBox8.Image = image1;
            }
            else if (variables.numEN == 10)
            {
                pictureBox5.Image = BASSCOMPORT.Properties.Resources.com3;
                pictureBox8.Image = image6;
            }
            variables.comportx = true;


        }
        private void btnTest_Click(object sender, EventArgs e)
        {

            try
            {

                if (variables.numEN == 11)
                {

                    if (subjectText.Text.Trim() == string.Empty | messageText.Text.Trim() == string.Empty)
                    {

                        return; // return because we don't want to run normal code of buton click
                    }
                    else
                    {
                        if (System.Windows.Forms.MessageBox.Show("Lütfen işlem başlatılmadan önce onaylayınız!" + "\n" + "Devam Etmek İstiyor Musunuz?", "Evet", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

                        {
                            message.From = new MailAddress("argebassfirebase@gmail.com");
                            message.To.Add(new MailAddress("destek@bass.com.tr"));
                            message.Subject = subjectText.Text.ToString();
                            message.Body =  firmText.Text.ToString()+"//"+telText.Text.ToString()+"//"+messageText.Text.ToString();


                            smtp.Port = 587;
                            smtp.Host = "smtp.gmail.com";
                            smtp.EnableSsl = true;
                            smtp.UseDefaultCredentials = false;
                            smtp.Credentials = new NetworkCredential("argebassfirebase@gmail.com", "xkvlltikstiyjxvg"); //BassArgeFirebase13
                            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                            smtp.Send(message);
                            System.Windows.Forms.MessageBox.Show("Mesajınız başarıyla gönderildi!");
                            subjectText.Clear();
                            messageText.Clear();
                            telText.Clear();
                            firmText.Clear();
                            button1.Text = "Ekle";
                        }
                        else

                        {
                            //do something if NO
                        }
                    }
                }
                else if(variables.numEN==10)

                {
                    if (subjectText.Text.Trim() == string.Empty | messageText.Text.Trim() == string.Empty)
                    {

                        return; // return because we don't want to run normal code of buton click
                    }
                    else
                    {
                        if (System.Windows.Forms.MessageBox.Show("Please confirm before proceed" + "\n" + "Do you want to Continue ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

                        {
                            message.From = new MailAddress("argebassfirebase@gmail.com");
                            message.To.Add(new MailAddress("destek@bass.com.tr"));
                            message.Subject = subjectText.Text.ToString();
                            message.Body = firmText.Text.ToString() + "//" + telText.Text.ToString() + "//" + messageText.Text.ToString();


                            smtp.Port = 587;
                            smtp.Host = "smtp.gmail.com";
                            smtp.EnableSsl = true;
                            smtp.UseDefaultCredentials = false;
                            smtp.Credentials = new NetworkCredential("argebassfirebase@gmail.com", "xkvlltikstiyjxvg"); //BassArgeFirebase13
                            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                            smtp.Send(message);
                            System.Windows.Forms.MessageBox.Show("Message has been successfully sent!");

                            subjectText.Clear();
                            messageText.Clear();
                            telText.Clear();
                            firmText.Clear();
                            button1.Text = "Attach";
                        }
                        else

                        {
                            //do something if NO
                        }
                    }
                

                    

                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("err: " + ex.Message);
            }
        }

        protected void SendEmail(string _subject, MailAddress _from, MailAddress _to, List<MailAddress> _cc, List<MailAddress> _bcc = null)
        {
            string Text = "";
            SmtpClient mailClient = new SmtpClient("Mailhost");
            MailMessage msgMail;
            Text = "Stuff";
            msgMail = new MailMessage();
            msgMail.From = _from;
            msgMail.To.Add(_to);
            foreach (MailAddress addr in _cc)
            {
                msgMail.CC.Add(addr);
            }
            if (_bcc != null)
            {
                foreach (MailAddress addr in _bcc)
                {
                    msgMail.Bcc.Add(addr);
                }
            }
            msgMail.Subject = _subject;
            msgMail.Body = Text;
            msgMail.IsBodyHtml = true;
            mailClient.Send(msgMail);
            msgMail.Dispose();
        }

        public void Send(string sendTo, string sendFrom, string subject, string body)
        {
            try
            {
                //setup SMTP Host Here
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                client.UseDefaultCredentials = false;
                client.Credentials = smtpCreds;
                client.EnableSsl = true;

                //converte string to MailAdress

                MailAddress to = new MailAddress(sendTo);
                MailAddress from = new MailAddress(sendFrom);

                //set up message settings

                msg.Subject = subject;
                msg.Body = body;
                msg.From = from;
                msg.To.Add(to);

                // Enviar E-mail

                client.Send(msg);

            }
            catch (Exception error)
            {
                System.Windows.MessageBox.Show("Unexpected Error: " + error);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://bass.com.tr/en/Home");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.instagram.com/bassinstruments/");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://twitter.com/instrumentsbass");
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://tr.linkedin.com/company/bass-%C3%B6l%C3%A7me-enstr%C3%BCmanlar%C4%B1-ltd-%C5%9Fti");
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (variables.numEN == 11)
            {
                pictureBox5.Image = BASSCOMPORT.Properties.Resources.com2;
                if (variables.trP == false)
                {
                    pictureBox8.Image = image1;
                    variables.trP = true;
                }
                if (pictureBox8.Image == image1)
                {
                    pictureBox8.Image = image2;
                }
                else if (pictureBox8.Image == image2)
                {
                    pictureBox8.Image = image3;
                }
                else if (pictureBox8.Image == image3)
                {
                    pictureBox8.Image = image4;
                }
                else if(pictureBox8.Image == image4)
                {
                    pictureBox8.Image = image1;
                }

            }
            else if (variables.numEN == 10)
            {
                pictureBox5.Image = BASSCOMPORT.Properties.Resources.com3;
                if (variables.enP == false)
                {
                    pictureBox8.Image = image6;
                    variables.enP = true;
                }

                if (pictureBox8.Image == image6)
                {
                    pictureBox8.Image = image7;
                }
                else if (pictureBox8.Image == image7)
                {
                    pictureBox8.Image = image8;
                }
                else if (pictureBox8.Image == image8)
                {
                    pictureBox8.Image = image9;
                }
                else if (pictureBox8.Image == image9)
                {
                    pictureBox8.Image = image6;
                }
            }
            
            if (variables.numEN == 11)
            {
                
                
                if (trying2 == false)
                {
                    subjectLabel.Text = rm.GetString("Subject");
                    messageLabel.Text = rm.GetString("Message");
                    attachLabel.Text = "Dosya";
                    button1.Text = "Ekle";
                    btnTest.Text = rm.GetString("SEND");
                    groupBox1.Text = rm.GetString("Help");
                    firmLabel.Text = "Firma İsmi";
                    telLabel.Text = "İletişim";
                    trying2 = true;
                }

            }
            else if (variables.numEN == 10)
            {
                
                subjectLabel.Text = "Subject";
                messageLabel.Text = "Message";
                attachLabel.Text = "File";
                button1.Text = "Attach";
                btnTest.Text = "SEND";
                groupBox1.Text = "Help";
                firmLabel.Text = "Firm Name";
                telLabel.Text = "Contact";
                trying2 = false;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Select File";
            openFileDialog1.InitialDirectory = @"C:\";//--"C:\\";
            openFileDialog1.Filter = "All files (*.*)|*.*|Excel (*.xls)|*.xls";
            openFileDialog1.FilterIndex = 2;
            

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                foreach (string fileName in openFileDialog1.FileNames)
                {
                    button1.Text = openFileDialog1.SafeFileName;
                    message.Attachments.Add(new Attachment(fileName));
                }
            }
            
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

       

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            if (variables.numEN == 11)
            {
                System.Diagnostics.Process.Start("https://bass.com.tr/urunler");
            }
            else if (variables.numEN == 10)
            {
                System.Diagnostics.Process.Start("https://bass.com.tr/en/products");
            }
        }
    }
    
}
