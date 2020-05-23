using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ElenaGalstyan
{
    public partial class izmenenia : Form
    {
        private void LoadDatatocombobox1()
        {
            if (comboBox1.Items.Count != 0)
            {
                comboBox1.Items.Clear();
            }
            List<string> values = Class1.loadDataNamTech();
            foreach (var value in values)
            {
                comboBox1.Items.Add(value.ToString());
            }
        }
        private void LoadDatatocombobox2()
        {
            if (comboBox2.Items.Count != 0)
            {
                comboBox2.Items.Clear();
            }
            List<string> values = Class1.loadDataRazdel();
            foreach (var value in values)
            {
                comboBox2.Items.Add(value.ToString());
            }
        }

        public izmenenia(menu menu)
        {
            InitializeComponent();
            LoadDatatocombobox1();
            LoadDatatocombobox2();
        }

        SqlConnection con = new SqlConnection("Data Source =.\\SQLEXPRESS; Initial Catalog = reestr17; Integrated Security = true;");

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0);
        }
        Bitmap bmp;
        //private void печатьToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    Graphics g = this.CreateGraphics();
        //    bmp = new Bitmap(this.Size.Width, this.Size.Height, g);
        //    Graphics mg = Graphics.FromImage(bmp);
        //    mg.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, this.Size);
        //    printPreviewDialog1.ShowDialog();
        //}

      

  

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            bmp = new Bitmap(this.Size.Width, this.Size.Height, g);
            Graphics mg = Graphics.FromImage(bmp);
            mg.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, this.Size);
            printPreviewDialog1.ShowDialog();
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


        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "INSERT INTO IZMENENIA (INV_NOMER1,ID_NAZVANIE, ID_RAZDEL_IZMENENIA, IZMENENIA) VALUES ('" + textBox1.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + textBox2.Text + "')";
            SqlDataAdapter SDA = new SqlDataAdapter(query, con);
            SDA.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Данные успешно добавлены!");

        }

        private void button5_Click(object sender, EventArgs e)
        {
            con.Open();
            String query = "SELECT  * FROM IZMENENIA ";
            SqlDataAdapter SDA = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            SDA.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "UPDATE IZMENENIA SET INV_NOMER1 = '" + textBox1.Text + "',ID_NAZVANIE='" + comboBox1.Text + "', ID_RAZDEL_IZMENENIA='" + comboBox2.Text + "',IZMENENIA='" + textBox2.Text + "'";
            SqlDataAdapter SDA = new SqlDataAdapter(query, con);
            SDA.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("   Данные успешно обновлены!");
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            comboBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
        }
        private void iDelete()
        {
            foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.RemoveAt(item.Index);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            iDelete();
            MessageBox.Show("Запись успешно удалена!");

            //https://www.youtube.com/watch?v=K1Wgpc-ZFbg
        }

      

        //private void button6_Click(object sender, EventArgs e)
        //{
        //               SqlConnection con = new SqlConnection("Data Source =.\\SQLEXPRESS; Initial Catalog = reestr17; Integrated Security = true;");

        //    con = new SqlConnection(constring);

        //    con.Open();

        //    string query = "INSERT INTO IZMENEINA ( INV_NOMER1,ID_NAZVANIE, ID_RAZDEL_IZMENENIE ,IZMENENIA) VALUES('" + this.textBox1.Text + "','" + this.comboBox1.Text + "','" + this.comboBox2.Text + "','" + this.textBox2.Text + "');";
        //        //"= '" + this.textBox1.Text + "',ID_NAZVANIE='" + comboBox1.Text + "', ID_RAZDEL_IZMENENIE='" + comboBox2.Text + "',IZMENENIA='" + textBox2.Text + "'";
        //    SqlConnection conDataBase = new SqlConnection(constring);
        //    SqlCommand cmdDataBase = new SqlCommand(query, conDataBase);
        //    SqlDataReader myReader;
        //    try{
        //        conDataBase.Open();
        //        myReader = cmdDataBase.ExecuteReader();
        //        MessageBox.Show("Данные успешно сохранены");
        //        while (myReader.Read())
        //        {

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
        //https://www.youtube.com/watch?v=YNeFKtgSgQY 13:11
    }
}


