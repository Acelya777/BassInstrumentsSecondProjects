using System;
using System.Collections.Generic;
using System.Data;
using System.IO.Ports;
using System.Linq;

namespace BASSCOMPORT
{
    public static class variables
    {   
        public static bool scalingChange { get; set; }
        public static bool scalingphotocheck { get; set; }
        public static bool updateData { get; set; }
        public static bool flowOpen { get; set; }
        public static bool timerScaling { get; set; }
        public static double lowRange { get; set; }
        public static double upperRange { get; set; }
        public static double data_identify { get; set; }// is it voltage?
        public static bool enP { get; set; }// about page english photo
        public static bool trP { get; set; }// about page tr photo
        public static int exportBut2 { get; set; }
        public static bool comportx { get; set; } // for comport
        public static bool xx { get; set; } // for exportbutton
        public static bool tryMe { get; set; }
        public static double minscale { get; set; }
        public static double maxscale { get; set; }
        public static bool exportBut { get; set; } // for collect data button
        public static int connection2 { get; set; } // not used
        public static int status { get; set; }  // if 66 = connected to serial port , if 67 = not connected to serial port
        public static int numP { get; set; } // for pressure 
        public static int numT { get; set; } // for temperature
        public static int numEN { get; set; } // for language 11  = TR  , 10  =  EN
        public static float InstantFlow { get; set; }
        public static float TotalFlow { get; set; }
        public static float Density { get; set; }
        public static double Temperature { get; set; }
        public static double Pressure { get; set; }
        public static float Today { get; set; }
        public static DataTable records { get; set; }
        public static bool recordstate { get; set; }
        public static bool connection { get; set; }
        public static string comport { get; set; }
        public static int baudrate { get; set; }
        public static System.IO.Ports.StopBits stopbits { get; set; }
        public static Parity parity { get; set; }
        public static SerialPort serialPort { get; set; }
        public static int databits { get; set; }
       
        public static Dictionary<string, int> recordtime { get; set; }

        public static float[] UshortFloat(ushort[] parameters)
        {
            List<float> floatlist = new List<float>();
            for (int i = 0; i < parameters.Length; i += 2)
            {
                byte[] one = BitConverter.GetBytes(parameters[i]);
                byte[] two = BitConverter.GetBytes(parameters[i + 1]);
                byte[] combined = new byte[one.Length + two.Length];
                for (int k = 0; k < combined.Length; k++)
                {
                    combined[k] = k < one.Length ? one[k] : two[k - one.Length];
                }

                float temp = BitConverter.ToSingle(combined, 0);
                floatlist.Add(temp);
            }
            return floatlist.ToArray();
        }
        public static float CalcSaturatedPressuree(float t)
        {
            float n1 = (float)(0.11670521452767 * 10000);
            float n2 = (float)(-0.72421316703206 * 1000000);
            float n3 = (float)(-0.17073846940092 * 100);
            float n4 = (float)(0.12020824702470 * 100000);
            float n5 = (float)(-0.32325550322333 * 10000000);
            float n6 = (float)(0.14915108613530 * 100);
            float n7 = (float)(-0.48232657361591 * 10000);
            float n8 = (float)(0.40511340542057 * 1000000);
            float n9 = (float)-0.23855557567849;
            float n10 = (float)(0.65017534844798 * 1000);
            float v = t + (n9 / (t - n10));
            float a = (v * v) + (n1 * v) + n2;
            float b = (n3 * v * v) + (n4 * v) + n5;
            float c = (n6 * v * v) + (n7 * v) + n8;
            float p = (float)Math.Pow(((2 * c) / (-b + Math.Pow((b * b - 4 * a * c), 0.5))), 4);
            return p;

        }
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
