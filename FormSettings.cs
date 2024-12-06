using DocumentFormat.OpenXml.Presentation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
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
        private Thread listenerThread;

        bool tryMe = false;
        public int enNumber = 0;
        SerialPort myPort;
        private bool updateData2 = false;
        bool updateData = false;
        double identify = 0;
        int counterCom = 0;
        
        List<double> res_vals_pt100 = new List<double>() {18.52, 18.96, 19.39, 19.82, 20.25, 20.68, 21.11, 21.54, 21.97, 22.40,
     22.83, 23.26, 23.69, 24.12, 24.55, 24.97, 25.39, 25.82, 26.25, 26.67,
     27.10, 27.52, 27.95, 28.37, 28.80, 29.22, 29.65, 30.07, 30.49, 30.92,
     31.34, 31.76, 32.18, 32.61, 33.03, 33.45, 33.86, 34.28, 34.70, 35.12,
     35.54, 35.96, 36.38, 36.80, 37.22, 37.63, 38.05, 38.47, 38.89, 39.31,
     39.72, 40.14, 40.56, 40.97, 41.39, 41.80, 42.22, 42.64, 43.05, 43.46,
     43.88, 44.29, 44.71, 45.12, 45.53, 45.95, 46.35, 46.76, 47.18, 47.59,
     48.00, 48.41, 48.82, 49.23, 49.64, 50.06, 50.47, 50.88, 51.29, 51.70,
     52.11, 52.52, 52.92, 53.33, 53.74, 54.15, 54.56, 54.97, 55.38, 55.78,
     56.19, 56.60, 57.00, 57.41, 57.82, 58.22, 58.63, 59.04, 59.44, 59.85,
     60.26, 60.67, 61.07, 61.48, 61.87, 62.29, 62.69, 63.10, 63.50, 63.91,
     64.30, 64.70, 65.11, 65.51, 65.91, 66.31, 66.72, 67.12, 67.52, 67.92,
     68.33, 68.73, 69.13, 69.53, 69.93, 70.33, 70.73, 71.13, 71.53, 71.93,
     72.33, 72.73, 73.13, 73.53, 73.93, 74.33, 74.73, 75.13, 75.53, 75.93,
     76.33, 76.73, 77.13, 77.52, 77.92, 78.32, 78.72, 79.11, 79.51, 79.91,
     80.31, 80.70, 81.10, 81.50, 81.89, 82.29, 82.69, 83.08, 83.48, 83.88,
     84.27, 84.67, 85.06, 85.46, 85.85, 86.25, 86.64, 87.04, 87.43, 87.83,
     88.22, 88.62, 89.01, 89.40, 89.80, 90.19, 90.59, 90.98, 91.37, 91.77,
     92.16, 92.55, 92.95, 93.34, 93.73, 94.12, 94.52, 94.91, 95.30, 95.69,
     96.09, 96.48, 96.87, 97.26, 97.65, 98.04, 98.44, 98.83, 99.22, 99.61,
    100.00,100.39,100.78,101.17,101.56,101.95,102.34,102.73,103.12,103.51,
    103.90,104.29,104.68,105.07,105.46,105.85,106.24,106.63,107.02,107.40,
    107.79,108.18,108.57,108.96,109.35,109.73,110.12,110.51,110.90,111.28,
    111.67,112.06,112.45,112.83,113.22,113.61,113.99,114.38,114.77,115.15,
    115.54,115.93,116.31,116.70,117.08,117.47,117.85,118.24,118.62,119.01,
    119.40,119.78,120.16,120.55,120.93,121.32,121.70,122.09,122.47,122.86,
    123.24,123.62,124.01,124.39,124.77,125.17,125.55,125.93,126.32,126.70,
    127.08,127.46,127.85,128.23,128.61,128.99,129.38,129.76,130.14,130.52,
    130.90,131.28,131.67,132.05,132.43,132.81,133.19,133.57,133.95,134.33,
    134.71,135.09,135.47,135.85,136.23,136.61,136.99,137.37,137.75,138.13,
    138.51,138.89,139.27,139.65,140.03,140.39,140.77,141.15,141.53,141.91,
    142.29,142.66,143.04,143.42,143.80,144.18,144.56,144.94,145.32,145.69,
    146.07,146.45,146.82,147.20,147.58,147.95,148.33,148.71,149.08,149.46,
    149.83,150.21,150.58,150.96,151.34,151.71,152.09,152.46,152.84,153.21,
    153.58,153.95,154.32,154.71,155.08,155.46,155.83,156.21,156.58,156.96,
    157.33,157.71,158.08,158.45,158.83,159.20,159.56,159.94,160.31,160.68,
    161.05,161.43,161.80,162.17,162.54,162.91,163.28,163.66,164.03,164.40,
    164.77,165.14,165.51,165.88,166.25,166.62,167.00,167.37,167.74,168.11,
    168.48,168.85,169.22,169.59,169.96,170.33,170.69,171.06,171.43,171.80,
    172.17,172.54,172.91,173.27,173.64,174.01,174.39,174.75,175.12,175.49,
    175.86,176.23,176.59,176.96,177.33,177.70,178.06,178.43,178.80,179.16,
    179.53,179.90,180.26,180.63,180.99,181.36,181.73,182.09,182.46,182.82,
    183.19,183.55,183.92,184.28,184.65,185.01,185.38,185.74,186.11,186.47,
    186.84,187.20,187.56,187.93,188.29,188.65,189.02,189.38,189.74,190.11,
    190.47,190.83,191.20,191.56,191.92,192.28,192.66,193.02,193.38,193.74,
    194.10,194.47,194.83,195.19,195.55,195.90,196.26,196.62,196.98,197.35,
    197.71,198.07,198.43,198.79,199.15,199.51,199.87,200.23,200.59,200.95,
    201.31,201.67,202.03,202.38,202.74,203.10,203.46,203.82,204.18,204.54,
    204.90,205.25,205.61,205.97,206.33,206.70,207.05,207.41,207.77,208.13,
    208.48,208.84,209.20,209.55,209.91,210.27,210.62,210.98,211.34,211.69,
    212.05,212.40,212.76,213.12,213.47,213.83,214.19,214.55,214.90,215.26,
    215.61,215.97,216.32,216.68,217.03,217.39,217.73,218.08,218.44,218.79,
    219.15,219.50,219.85,220.21,220.56,220.91,221.27,221.62,221.97,222.32,
    222.68,223.03,223.38,223.73,224.09,224.45,224.80,225.15,225.50,225.85,
    226.21,226.56,226.91,227.26,227.61,227.96,228.31,228.66,229.01,229.36,
    229.72,230.07,230.42,230.77,231.12,231.47,231.81,232.16,232.51,232.86,
    233.21,233.56,233.91,234.26,234.60,234.95,235.30,235.65,236.00,236.35,
    236.70,237.05,237.40,237.75,238.09,238.44,238.79,239.14,239.48,239.83,
    240.18,240.52,240.87,241.22,241.56,241.91,242.25,242.60,242.95,243.29,
    243.64,243.98,244.33,244.67,245.02,245.36,245.71,246.05,246.40,246.74,
    247.09,247.43,247.78,248.12,248.46,248.81,249.15,249.50,249.84,250.18,
    250.53,250.89,251.21,251.55,251.90,252.24,252.59,252.94,253.28,253.62,
    253.96,254.30,254.65,254.99,255.33,255.67,256.01,256.35,256.70,257.04,
    257.38,257.72,258.06,258.40,258.74,259.08,259.42,259.76,260.10,260.44,
    260.78,261.12,261.46,261.80,262.14,262.48,262.83,263.17,263.50,263.84,
    264.18,264.52,264.86,265.20,265.54,265.87,266.21,266.55,266.89,267.22,
    267.56,267.90,268.24,268.57,268.91,269.25,269.58,269.92,270.26,270.59,
    270.93,271.27,271.60,271.94,272.27,272.61,272.95,273.28,273.62,273.95,
    274.29,274.62,274.96,275.29,275.63,275.96,276.31,276.64,276.97,277.31,
    277.64,277.98,278.31,278.64,278.98,279.31,279.64,279.98,280.31,280.64,
    280.98,281.31,281.64,281.97,282.31,282.64,282.97,283.30,283.63,283.97,
    284.30,284.63,284.96,285.29,285.62,285.95,286.30,286.63,286.96,287.29,
    287.62,287.95,288.28,288.61,288.94,289.27,289.60,289.93,290.26,290.59,
    290.92,291.25,291.58,291.90,292.23,292.56,292.90,293.23,293.56,293.89,
    294.21,294.54,294.87,295.20,295.53,295.85,296.18,296.51,296.84,297.16,
    297.49,297.82,298.14,298.47,298.80,299.12,299.45,299.78,300.10,300.43,
    300.75,301.08,301.41,301.73,302.06,302.38,302.71,303.03,303.36,303.68,
    304.01,304.33,304.66,304.98,305.30,305.63,305.95,306.28,306.60,306.92,
    307.25,307.57,307.89,308.22,308.54,308.86,309.19,309.51,309.83,310.15,
    310.48,310.80,311.12,311.45,311.78,312.10,312.43,312.75,313.07,313.39,
    313.71,314.04,314.36,314.68,315.00,315.32,315.64,315.96,316.28,316.60,
    316.92,317.24,317.56,317.88,318.20,318.52,318.85,319.17,319.49,319.81,
    320.12,320.44,320.76,321.08,321.40,321.72,322.03,322.34,322.66,322.98,
    323.30,323.61,323.93,324.25,324.57,324.88,325.21,325.53,325.85,326.16,
    326.48,326.79,327.11,327.43,327.74,328.06,328.38,328.69,329.01,329.32,
    329.64,329.95,330.27,330.58,330.90,331.21,331.53,331.84,332.16,332.47,
    332.79,333.10,333.41,333.73,334.04,334.36,334.68,334.99,335.31,335.62,
    335.93,336.25,336.56,336.87,337.18,337.50,337.81,338.12,338.43,338.75,
    339.06,339.37,339.68,339.99,340.30,340.62,340.94,341.25,341.55,341.87,
    342.18,342.49,342.80,343.11,343.42,343.73,344.04,344.35,344.66,344.97,
    345.28,345.59,345.90,346.21,346.52,346.83,347.15,347.46,347.76,348.07,
    348.38,348.69,349.00,349.31,349.61,349.92,350.23,350.54,350.85,351.15,
    351.46,351.77,352.07,352.38,352.69,352.99,353.30,353.61,353.91,354.22,
    354.53,354.83,355.14,355.44,355.75,356.06,356.37,356.68,356.98,357.29,
    357.59,357.90,358.20,358.51,358.81,359.12,359.42,359.72,360.03,360.33,
    360.64,360.94,361.24,361.55,361.85,362.15,362.46,362.76,363.06,363.36,
    363.67,363.97,364.27,364.57,364.88,365.18,365.49,365.79,366.09,366.40,
    366.70,367.00,367.30,367.60,367.90,368.20,368.50,368.81,369.11,369.41,
    369.71,370.01,370.31,370.61,370.91,371.21,371.52,371.82,372.12,372.41,
    372.71,373.01,373.31,373.61,373.91,374.21,374.51,374.80,375.10,375.40,
    375.70,376.00,376.29,376.59,376.89,377.19,377.49,377.79,378.09,378.39,
    378.68,378.98,379.28,379.57,379.87,380.17,380.46,380.76,381.05,381.35,
    381.65,381.94,382.24,382.53,382.83,383.12,383.42,383.71,384.01,384.30,
    384.60,384.89,385.18,385.48,385.77,386.07,386.37,386.66,386.96,387.25,
    387.55,387.84,388.13,388.42,388.72,389.01,389.31,389.61,389.90,390.19,
    390.48 };

        List<double> res_vals_pt1000 = new List<double>() { 68335,68727,69129,6953,69931,70332,70733,71134,71534,71934, //10
    72335,72735,73134,73534,73934,74333,74732,75132,75530,75929, //20
    76328,76726,77125,77523,77921,78319,78717,79114,79512,79909, //30
    80306,80703,81100,81497,81894,8226,82687,83083,83479,83871,
    84271,84666,85062,85457,85853,86248,86643,87038,87433,87827,
    88222,88616,89010,89404,89799,90192,90586,9098,91373,91767,
    92160,92553,92946,93339,93732,94124,94517,94909,95302,95694,
    99686,96478,9687,97261,97653,98044,98436,98827,99218,99609,
    100000,100390,100780,101170,101560,101950,102340,102730,103120,103510,
    103900,104290,104680,105070,105460,105850,106240,106630,107020,107400, //100
    107790,108180,108570,108960,109350,109730,110120,110510,110900,111290,
    111670,112060,112450,112830,113220,113610,114000,114380,114770,115150,
    115540,115930,116310,116700,117080,117470,117860,118240,118630,119010,
    119400,119780,120170,120550,120940,121320,121710,122090,122470,122860,
    123240,123630,124010,124390,124780,125160,125540,125930,126310,126690,
    127080,127460,127840,128220,128610,128990,129370,129750,130130,130520,
    130900,131280,131660,132040,132420,132800,133180,133570,133950,134330,
    134710,135090,135470,135850,136230,136610,136990,137370,137750,138130,
    138510,138880,139260,139640,140020,140400,140780,141160,141540,141910,
    142290,142670,143050,143430,143800,144180,144560,144940,145310,145690 ,//200
    146070,146440,146820,147200,147570,147950,148330,148700,149080,149460,
    149830,150210,150580,150960,151330,151710,152080,152460,152830,153210,
    153580,153960,154330,154710,155080,155460,155830,156200,156580,156950,
    157330,157700,158070,158450,158820,159190,159560,159940,160310,160680,
    161050,161430,161800,162170,162540,162910,163290,163660,164030,164400,
    164770,165140,165510,165890,166260,166630,167000,167370,167740,168110,
    168480,168850,169220,169590,169960,170330,170700,171070,171430,171800,
    172170,172540,172910,173280,173650,174020,174380,174750,175120,175490,
    175860,176220,176590,176960,177330,177690,178060,178430,178790,179160,
    179530,179890,180260,180630,180990,181360,181720,182090,182460,182820 ,//300
    183190,183550,183920,184280,184650,185010,185380,185740,186110,186470,
    186840,187200,187560,187930,188290,188660,189020,189380,189750,190110,
    190470,190840,191200,191560,191920,192290,192650,193010,193370,193740,
    194100,194460,194820,195180,195550,195910,196270,196630,196990,197350,
    197710,198070,198430,198790,199150,199510,199870,200230,200590,200950,
    201310,201670,202030,202390,202750,203110,203470,203830,204190,204550,
    204900,205260,205620,205980,206340,206700,207050,207410,207770,208130,
    208480,208840,209200,209560,209910,210270,210630,210980,211340,211700,
    212050,212410,212760,213120,213480,213830,214190,214540,214900,215250,
    215610,215960,216320,216670,217030,217380,217740,218090,218440,218800, //400
    219150,219510,219860,220210,220570,220920,221270,221630,221980,222330,
    222680,223040,223390,223740,224090,224450,224800,225150,225500,225850,
    226210,226560,226910,227260,227610,227960,228310,228660,229020,229370,
    229720,230070,230420,230770,231120,231470,231820,232170,232520,232870,
    233210,233560,233910,234260,234610,234960,235310,235660,236000,236350,
    236700,237050,237400,237740,238090,238440,238790,239130,239480,239830,
    240180,240520,240870,241220,241560,241910,242260,242600,242950,243290,
    243640,243990,244330,244680,245020,245370,245710,246060,246400,246750,
    247090,247440,247780,248130,248470,248810,249160,249500,249850,250190,
    250530,250880,251220,251560,251910,252250,252590,252930,253280,253620, //500
    253960,254300,254650,254990,255330,255670,256010,256350,256700,257040,
    257380,257720,258060,258400,258740,259080,259420,259760,260100,260440,
    260780,261120,261460,261800,262140,262480,262820,263160,263500,263840,
    264180,264520,264860,265200,265530,265870,266210,266550,266890,267220,
    267560,267900,268240,268570,268910,269250,269590,269920,270260,270600,
    270930,271270,271610,271940,272280,272610,272950,273290,273620,273960,
    274290,274630,274960,275300,275630,275970,276300,276640,276970,277310,
    277640,277980,278310,278640,278980,279310,279640,279980,280310,280640,
    280980,281310,281640,281980,282310,282640,282970,283310,283640,283970};



        public FormSettings()
        {
            InitializeComponent();
            // make panel rounded
            this.FormBorderStyle = FormBorderStyle.None;
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            //make group boxes rounded

            label13.Font = new System.Drawing.Font("Roboto", 12F);
            label14.Font = new System.Drawing.Font("Roboto", 12F);
            label19.Font = new System.Drawing.Font("Roboto", 12F);
            label20.Font = new System.Drawing.Font("Roboto", 12F);
            label23.Font = new System.Drawing.Font("Roboto", 12F);
            label1.Font = new System.Drawing.Font("Roboto", 12F);
            label2.Font = new System.Drawing.Font("Roboto", 12F);
            label5.Font = new System.Drawing.Font("Roboto", 12F);
            label3.Font = new System.Drawing.Font("Roboto", 12F);
            deviceLabel.Font = new System.Drawing.Font("Roboto", 12F);
            outputLabel.Font = new System.Drawing.Font("Roboto", 12F);
            cBoxCOMPORT.Font = new System.Drawing.Font("Roboto", 12F);
            cBoxBaudRate.Font = new System.Drawing.Font("Roboto", 12F);
            cBoxDataBits.Font = new System.Drawing.Font("Roboto", 12F);
            cBoxStopBits.Font = new System.Drawing.Font("Roboto", 12F);
            cBoxParity.Font = new System.Drawing.Font("Roboto", 12F);
            comboBox1.Font = new System.Drawing.Font("Roboto", 12F);
            comboBox2.Font = new System.Drawing.Font("Roboto", 12F);
            comboBox3.Font = new System.Drawing.Font("Roboto", 12F);
            comboBox4.Font = new System.Drawing.Font("Roboto", 12F);
            comboBox5.Font = new System.Drawing.Font("Roboto", 12F);
            comboBox6.Font = new System.Drawing.Font("Roboto", 12F);
        }

        double temp_to_resis_pt100(double temp)
        {
            var temp_vals_pt100 = Enumerable.Range(-200, 851).ToList();
            int k = 0;
            while (temp > temp_vals_pt100[k + 1])
            {
                k += 1;
            }
            double delta_r = temp_vals_pt100[k + 1] - temp_vals_pt100[k];
            double delta_t = 1.0;
            double cur_dr = temp - temp_vals_pt100[k];

            double resistance = res_vals_pt100[k] + cur_dr / delta_r;

            return resistance;
        }

        double temp_to_resis_pt1000(double temp)
        {
            var temp_vals_pt1000 = Enumerable.Range(-80, 591).ToList();
            int k = 0;
            while (temp > temp_vals_pt1000[k + 1])
            {
                k += 1;
            }
            double delta_r = temp_vals_pt1000[k + 1] - temp_vals_pt1000[k];
            double delta_t = 1.0;
            double cur_dr = temp - temp_vals_pt1000[k];

            double resistance = res_vals_pt1000[k]/100 + cur_dr / delta_r;

            return resistance;
        }

        void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if(!variables.SerialPortPendingClose)
            {
                string data_In = serialPort1.ReadTo("^");
                string data_identify = serialPort1.ReadTo("&");
                Data_Identify(data_identify);
                Data_TempPres(data_In);
            }
            
            

        }
        public void Data_Identify(string data)
        {
            sbyte indexOf_startDataCharx = (sbyte)data.IndexOf("?");
            sbyte indexOfXx = (sbyte)data.IndexOf("!");
            sbyte indexOfYx = (sbyte)data.IndexOf("%");

            if (indexOf_startDataCharx != -1 && indexOfYx != -1 && indexOfXx != -1) 
            {
                try
                {
                    string str_identify = data.Substring(indexOf_startDataCharx + 1, (indexOfXx - indexOf_startDataCharx) - 1);
                    string str_range = data.Substring(indexOfXx + 1, (indexOfYx - indexOfXx) - 1);
                    identify = Convert.ToDouble(str_identify);
                    if (identify == 1)
                    {
                        variables.data_identify = 10; // mA
                    }
                    else if (identify == 2)
                    {
                        variables.data_identify = 11; // V
                    }
                    string[] tokens = str_range.Split(')');
                    double lowRangeDouble = Convert.ToDouble(tokens[0]);
                    double upperRangeDouble = Convert.ToDouble(tokens[1]);
                    if (lowRangeDouble == 1)
                        variables.owiStatus = 1;
                    else
                        variables.owiStatus = 0;

                    if (upperRangeDouble == 999)
                        variables.connectionLost = true;
                    else
                        variables.connectionLost = false;


                    updateData2 = true;

                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
            }

            else
            {
                updateData2 = false;
            }
        }

        public void Data_TempPres(string data) // @35.97X1244.85Y^?1!0)2500%&
        {
            sbyte indexOf_startDataChar = (sbyte)data.IndexOf("@");
            sbyte indexOfX = (sbyte)data.IndexOf("X");
            sbyte indexOfY = (sbyte)data.IndexOf("Y");

            if (indexOf_startDataChar != -1 && indexOfY != -1 && indexOfX != -1)
            {
                try
                {
                    string str_tempL = data.Substring(indexOf_startDataChar + 1, (indexOfX - indexOf_startDataChar) - 1);
                    string str_temp = str_tempL.Replace('.', ',');
                    string str_pressureL = data.Substring(indexOfX + 1, (indexOfY - indexOfX) - 1);
                    string str_pressure = str_pressureL.Replace('.', ',');
                    if (variables.type == 2) // rtd
                    {
                        variables.Temperature = Convert.ToDouble(str_pressure);

                        if (variables.device == 1)
                            variables.Pressure = temp_to_resis_pt100(Convert.ToDouble(str_pressure));
                        if (variables.device == 2)
                            variables.Pressure = temp_to_resis_pt1000(Convert.ToDouble(str_pressure));

                    }
                    else if (variables.type == 1) //pressure
                    {
                        variables.Temperature = Convert.ToDouble(str_temp);
                        variables.Pressure = Convert.ToDouble(str_pressure);
                    }
                    
                    variables.updateData = true;

                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
            }

            else
            {
                variables.updateData = false;
            }
        }
        private void FormSettings_Load(object sender, EventArgs e)
        {
            
            serialPort1 = new SerialPort();
            variables.serialPort = serialPort1;
            serialPort1.DataReceived += new SerialDataReceivedEventHandler(sp_DataReceived);
            variables.scalingChange = true;
            variables.firstScaling = true;
            variables.firstAbout = true;

            label2.Enabled = false;
            comboBox2.Enabled = false;
            button2.Enabled = false;

            deviceLabel.Enabled = false;
            comboBox4.Enabled = false;
            button4.Enabled = false;

            label3.Enabled = false;
            comboBox6.Enabled = false;
            button6.Enabled = false;


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

            comboBox3.Items.AddRange(new object[] { "mA" ,"Voltage"});
            comboBox3.SelectedItem = null;
            comboBox3.SelectedIndex = 0;

            comboBox4.Items.AddRange(new object[] { "PT100", "PT1000" });
            comboBox4.SelectedItem = null;
            comboBox4.SelectedIndex = 0;

            comboBox5.Items.AddRange(new object[] { "Pressure","RTD" });
            comboBox5.SelectedItem = null;
            comboBox5.SelectedIndex = 0;

            comboBox6.Items.AddRange(new object[] { "mbar", "Bar", "Pa", "kPa", "MPa", "kg/cm2", "mmh2o", "mh2o", "mmHg", "psi", "inch water" });
            comboBox6.SelectedItem = null;
            comboBox6.SelectedIndex = 0;

            //comboBox6.Items.AddRange(new object[] { "mbar", "Bar", "Pa", "kPa", "MPa", "kg/cm2", "mmh2o", "mh2o", "mmHg", "psi", "inch water" });
            // comboBox6.SelectedItem = null;
            //comboBox6.SelectedIndex = 0;

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

       
        public void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {


           /* string data_In = serialPort1.ReadTo("^");
            string data_identify = serialPort1.ReadTo("*");
            Data_Identify(data_identify);
            Data_TempPres(data_In);*/
           





        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (variables.type == 1 || variables.type == 2)
            {
                if (variables.outputDevice == 1 || variables.outputDevice == 2)
                {
                    if (((variables.device == 1 || variables.device == 2) && ( variables.numT==1 || variables.numT==12 || variables.numT==13)) || 
                        (variables.numP==2 || variables.numP==14 || variables.numP == 15 || variables.numP == 16 || variables.numP == 17 || variables.numP == 18
                        || variables.numP == 19 || variables.numP == 20 || variables.numP == 21 || variables.numP == 22 || variables.numP == 23))
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

                                listenerThread = new Thread(ListenForPortChanges);
                                listenerThread.Start();

                                variables.status = 66;
                                variables.SerialPortPendingClose = false;
                                //variables.connection2 = true;
                                if (variables.outputDevice == 1)
                                    variables.serialPort.WriteLine("!!!!"); //mA
                                else if (variables.outputDevice == 2)
                                    variables.serialPort.WriteLine("^^^^"); //Voltage
                                if (variables.numEN == 11)
                                {
                                    progressBar1.CustomText = "BAĞLANDI";
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
                    else
                    {
                        if (variables.numEN == 10)
                            MessageBox.Show("Please set all the preferences!");
                        else if (variables.numEN == 11)
                            MessageBox.Show("Lütfen tüm tercihleri seçiniz!");
                        
                    }
                    
                }
                else
                {
                    if (variables.numEN == 10)
                        MessageBox.Show("Please choice the output of device!");
                    else if (variables.numEN == 11)
                        MessageBox.Show("Lütfen cihaz çıkışını seçiniz!");
                }
                
            }
            else
            {
                if (variables.numEN == 10)
                    MessageBox.Show("Please choice the transmitter type!");
                else if (variables.numEN == 11)
                    MessageBox.Show("Lütfen transmitter tipini seçiniz!");


            }

            
        }

        private void ListenForPortChanges()
        {
            while (variables.serialPort.IsOpen)
            {
                try
                {
                    if (!SerialPort.GetPortNames().Contains(variables.serialPort.PortName))
                    {
                        Invoke((MethodInvoker)delegate
                        {
                            MessageBox.Show("selected port connection error!");
                            Application.Restart();
                            Environment.Exit(0);
                            //variables.serialPort.Close();
                            //btnClose.Enabled = true;
                            //btnOpen.Enabled = false;
                            //cBoxCOMPORT.Text = "";
                            //string[] ports = SerialPort.GetPortNames();
                            //cBoxCOMPORT.Items.Clear();
                            //cBoxCOMPORT.Items.AddRange(ports);

                        });
                        break;
                    }
                }
                catch (Exception err) {
                    Invoke((MethodInvoker)delegate
                    {
                        MessageBox.Show("port control error!");
                        btnClose.PerformClick();
                    });
                    break;
                }

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (variables.status==66)
            {
                try
                {
                    variables.SerialPortPendingClose = true;
                    variables.status = 67;
                    Thread.Sleep(1000);
                    variables.serialPort.Close(); //close the serial port
                    progressBar1.Value=0;
                    if (variables.numEN == 11)
                            progressBar1.CustomText = "KESİLDİ";
                    else
                        progressBar1.CustomText = "DISCONNECTED";
 
                    btnOpen.Enabled = true;
                    btnClose.Enabled = false;
                    variables.SerialPortPendingClose = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message); //catch any serial port closing error messages
                }
                
            }
            else
            {
                MessageBox.Show("Serial port is already closed!");
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
            variables.scalingChange = true;
            variables.firstAbout = true;
            variables.firstScaling = true;

            

            if (comboBox1.SelectedItem.ToString() == "Türkçe")
            {

                variables.numEN = 11;
                variables.xx = true;
                variables.tryMe = false;
                variables.trP = true;
                variables.scalingphotocheck = true;


                deviceLabel.Text = "Sensor Tipi";
                label1.Text = rm.GetString("Language");
                label2.Text = rm.GetString("Temperature Unit");
                label3.Text = "Basınç Birimi";
                button6.Text = "AYARLA";
                button5.Text = "AYARLA";
                label5.Text = "Transmitter Tipi";
                outputLabel.Text = "Cihaz Cikisi";
                btnOpen.Text = rm.GetString("OPEN");
                btnClose.Text = rm.GetString("CLOSE");
                button1.Text = "AYARLA";
                button2.Text = "AYARLA";
                button3.Text = "AYARLA";
                button4.Text = "AYARLA";
                label14.Text = rm.GetString("BAUD RATE");
                label19.Text = rm.GetString("DATA BITS");
                label20.Text = rm.GetString("STOP BITS");
                label23.Text = rm.GetString("PARITY");
                
                    if (variables.status==66)
                    {
                        if (variables.numEN == 11)
                        {
                        //label4.Text = "BAĞLANDI";
                        }
                        
                    }
                    else
                    {
                        if (variables.numEN == 11)
                        {
                        //label4.Text = "KESİLDİ";

                        }
                        
                    }
            
            }
            else if (comboBox1.SelectedItem.ToString() == "English")
            {
                //variables.status = 67;
                variables.tryMe = false;
                variables.numEN = 10;
                variables.enP = false;
                variables.scalingphotocheck = true;

                label3.Text = "Pressure Unit";
                button6.Text = "SET";
                button5.Text = "SET";
                label5.Text = "Transmitter Type";
                deviceLabel.Text = "Sensor Type";
                label1.Text = "Language";
                label2.Text = "Temperature Unit";
                outputLabel.Text = "Device Output";
                btnOpen.Text = "OPEN";
                btnClose.Text = "CLOSE";
                button1.Text = "SET";
                button2.Text = "SET";
                button3.Text = "SET";
                button4.Text = "SET";
                label14.Text = "BAUD RATE";
                label19.Text = "DATA BITS";
                label20.Text = "STOP BITS";
                label23.Text = "PARITY";
               
                if (variables.status == 66)
                {
                    //label4.Text = "CONNECTED";
                }
                else
                {
                   // label4.Text = "DISCONNECTED";
                }


            }

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = BASSCOMPORT.Properties.Resources.ok2;
            variables.scalingChange = true;
            variables.firstAbout = true;
            variables.firstScaling = true;
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
            variables.scalingChange = true;
            variables.firstAbout = true;
            variables.firstScaling = true;
            if (comboBox3.SelectedItem.ToString() == "mA")
            {
                variables.outputDevice = 1;
                variables.tryMe = false;
            }
            else if (comboBox3.SelectedItem.ToString() == "Voltage")
            {
                variables.outputDevice = 2;
                variables.tryMe = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (variables.status != 66)
            {
                string[] ports = SerialPort.GetPortNames();
                cBoxCOMPORT.Items.Clear();
                cBoxCOMPORT.Items.AddRange(ports);
            }


            if (variables.numEN == 11)
            {
                if (variables.status == 66)
                {

                    if (progressBar1.Value < 100)
                    {
                        progressBar1.Value += 20;
                        this.timer1.Interval = 100;
                    }
                    else
                    {
                        progressBar1.CustomText = "BAĞLANDI";
                    }
                }
                else 
                {
                    progressBar1.Value = 0;
                    progressBar1.CustomText = "KESİLDİ";
                }
            }
            else if (variables.numEN == 10)
            {
                if (variables.status == 66)
                {
                    if (progressBar1.Value < 100)
                    {
                        progressBar1.Value += 20;
                        this.timer1.Interval = 100;
                    }
                    else
                    {
                        progressBar1.CustomText = "CONNECTED";

                    }
                }
                else 
                {
                    progressBar1.CustomText = "DISCONNECTED";
                }
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

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            pictureBox4.Image = BASSCOMPORT.Properties.Resources.ok2;

            if (comboBox4.SelectedItem.ToString() == "PT100")
            {
                variables.device = 1;

            }
            else if (comboBox4.SelectedItem.ToString() == "PT1000")
            {
                variables.device = 2;

            }
        }

        private void comboBox3_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

            pictureBox5.Image = BASSCOMPORT.Properties.Resources.ok2;

            if (comboBox5.SelectedItem.ToString() == "Pressure")
            {
                label3.Enabled = true;
                comboBox6.Enabled = true;
                button6.Enabled = true;

                deviceLabel.Enabled = false;
                comboBox4.Enabled = false;
                button4.Enabled = false;
                label2.Enabled = false;
                comboBox2.Enabled = false;
                button2.Enabled = false;

                variables.type = 1;
            }
            else if (comboBox5.SelectedItem.ToString() == "RTD")
            {
                label3.Enabled = false;
                comboBox6.Enabled = false;
                button6.Enabled = false;

                deviceLabel.Enabled = true;
                comboBox4.Enabled = true;
                button4.Enabled = true;
                label2.Enabled = true;
                comboBox2.Enabled = true;
                button2.Enabled = true;

                variables.type = 2;
            }
        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            pictureBox5.Image = BASSCOMPORT.Properties.Resources.ok2;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            pictureBox6.Image = BASSCOMPORT.Properties.Resources.ok2;

            variables.scalingChange = true;
            variables.firstAbout = true;
            variables.firstScaling = true;
            if (comboBox6.SelectedItem.ToString() == "Bar")
            {
                variables.numP = 14;
                variables.tryMe = false;
            }
            else if (comboBox6.SelectedItem.ToString() == "Pa")
            {
                variables.numP = 15;
                variables.tryMe = false;
            }
            else if (comboBox6.SelectedItem.ToString() == "kg/cm2")
            {
                variables.numP = 16;
                variables.tryMe = false;
            }
            else if (comboBox6.SelectedItem.ToString() == "mmh2o")
            {
                variables.numP = 17;
                variables.tryMe = false;
            }
            else if (comboBox6.SelectedItem.ToString() == "mh2o")
            {
                variables.numP = 18;
                variables.tryMe = false;
            }
            else if (comboBox6.SelectedItem.ToString() == "mmHg")
            {
                variables.numP = 19;
                variables.tryMe = false;
            }
            else if (comboBox6.SelectedItem.ToString() == "psi")
            {
                variables.numP = 20;
                variables.tryMe = false;
            }
            else if (comboBox6.SelectedItem.ToString() == "kPa")
            {
                variables.numP = 21;
                variables.tryMe = false;
            }
            else if (comboBox6.SelectedItem.ToString() == "MPa")
            {
                variables.numP = 22;
                variables.tryMe = false;
            }
            else if (comboBox6.SelectedItem.ToString() == "inch water")
            {
                variables.numP = 23;
                variables.tryMe = false;
            }
            else if (comboBox6.SelectedItem.ToString() == "mbar")
            {
                variables.numP = 2;
                variables.tryMe = false;
            }
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {

            if (variables.status == 66 && variables.connectionLost)
            {
                counterCom++;
                if (counterCom >= 10)
                {
                    variables.serialPort.WriteLine("++++"); // comport is open
                    counterCom = 0;
                }
            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cBoxCOMPORT_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

}
