using ElenaGalstyan;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElenaGalstyan
{
    public partial class reestr : Form
    {
        //public object ConfigurationManager { get; private set; }

        public reestr(menu f)
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()

        {
           
            string connectString = ("Data Source =.\\SQLEXPRESS; Initial Catalog = reestr17; Integrated Security = true;");

            //@"Server=MZSASPRUT\SPRUT;Initial Catalog=reestr17;Integrated Security= true;";
            //"Data Source=.\\SQLEXPRESS;Initial Catalog=reestr17;Integrated Security= true;";
            SqlConnection myConnection = new SqlConnection(connectString);

            myConnection.Open();

            string query = "SELECT * FROM OBSHIESVEDENIA ORDER BY ID_OBSHIESVEDENIA";

            SqlCommand command = new SqlCommand(query, myConnection);

            SqlDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();
            while (reader.Read())
            {
                data.Add(new string[20]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();
                data[data.Count - 1][4] = reader[4].ToString();
                data[data.Count - 1][5] = reader[5].ToString();
                data[data.Count - 1][6] = reader[6].ToString();
                data[data.Count - 1][7] = reader[7].ToString();
                data[data.Count - 1][8] = reader[8].ToString();
                data[data.Count - 1][9] = reader[9].ToString();
                data[data.Count - 1][10] = reader[10].ToString();
                data[data.Count - 1][11] = reader[11].ToString();
                data[data.Count - 1][12] = reader[12].ToString();
                data[data.Count - 1][13] = reader[13].ToString();
                data[data.Count - 1][14] = reader[14].ToString();
                data[data.Count - 1][15] = reader[15].ToString();
                data[data.Count - 1][16] = reader[16].ToString();
                data[data.Count - 1][17] = reader[17].ToString();
                data[data.Count - 1][18] = reader[18].ToString();
                data[data.Count - 1][19] = reader[19].ToString();
            }

            reader.Close();
            myConnection.Close();

            foreach (string[] s in data)
                dataGridView1.Rows.Add(s);

        }

        //private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{

        //}
        //private void search_text_TextChanged(object sender, EventArgs e)
        //{

        //}

       

        private void dataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            {
                if (e.Exception.Message == "DataGridViewComboboxCell vsalue is not valid.")
                {
                    object value = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    if (!((DataGridViewComboBoxColumn)dataGridView1.Columns[e.ColumnIndex]).Items.Contains(value))
                    {
                        ((DataGridViewComboBoxColumn)dataGridView1.Columns[e.ColumnIndex]).Items.Add(value);
                        e.ThrowException = false;
                    }
                }
            }
        }

        private void meExit()
        {
            DialogResult iExit;
            iExit = MessageBox.Show("Вы действительно хотите завершить работу?", "Сохранить данные", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (iExit == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
 
        private void button2_Click(object sender, EventArgs e)
        {
            meExit();
        }

              
        //private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    Application.Exit();

        //}

        //private void допинформацияToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    dopinfa d = new dopinfa(this);
        //    d.Show();
        //    Hide(); 
        //}

        //private void colorDialog1_HelpRequest(object sender, EventArgs e)
        //{

        //}

       
     

        private void iDelete()
        {
            foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.RemoveAt(item.Index);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            iDelete();
        }

        Bitmap bitmap;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            int height = dataGridView1.Height;
            dataGridView1.Height = dataGridView1.RowCount * dataGridView1.RowTemplate.Height * 2;
            bitmap = new Bitmap(dataGridView1.Width, dataGridView1.Height);
            dataGridView1.DrawToBitmap(bitmap, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            printPreviewDialog1.ShowDialog();
            dataGridView1.Height = height;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, 0, 0);
        }

      
        
    }



}

