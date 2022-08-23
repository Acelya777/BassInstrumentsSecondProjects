
using System;
using System.Data;
using System.Windows.Forms;

namespace BASSCOMPORT
{
    public partial class Form2 : Form
    {

       
        DataSet myDataSet;
        frrmMain objForm1;

        private void RefreshAndShowDataOnDataGridView()
        {
            try
            {
               
                dataGridView1.DataSource = myDataSet;
                dataGridView1.DataMember = "Serial Data";
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.Refresh();

                
            }
            catch (Exception error)
            {

                MessageBox.Show(error.Message);
            }
        }
        


        public Form2(frrmMain obj)
        {
            InitializeComponent();
            objForm1 = obj;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            RefreshAndShowDataOnDataGridView();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
