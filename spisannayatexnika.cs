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
    public partial class spisannayatexnika : Form
    {
        private void LoadDatatocombobox1()
        {
            if (comboBox1.Items.Count != 0)
            {
                comboBox1.Items.Clear();
            }
            List<string> values = Class1.loadDataNameizmenen();
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
            List<string> values = Class1.loadDataOtdelRazmeshen();
            foreach (var value in values)
            {
                comboBox2.Items.Add(value.ToString());
            }
        }

        private void LoadDatatocombobox3()
        {
            if (comboBox3.Items.Count != 0)
            {
                comboBox3.Items.Clear();
            }
            List<string> values = Class1.loadDataZakemchisl();
            foreach (var value in values)
            {
                comboBox3.Items.Add(value.ToString());
            }
        }
        public spisannayatexnika(menu menu)
        {
            InitializeComponent();
            LoadDatatocombobox1();
            LoadDatatocombobox2();
            LoadDatatocombobox3();
        }
        SqlConnection con = new SqlConnection("Data Source =.\\SQLEXPRESS; Initial Catalog = reestr17; Integrated Security = true;");
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0);
        }
        Bitmap bmp;


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            bmp = new Bitmap(this.Size.Width, this.Size.Height, g);
            Graphics mg = Graphics.FromImage(bmp);
            mg.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, this.Size);
            printPreviewDialog1.ShowDialog();
        }

        //private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    Application.Exit();
        //}

        //private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    dopinfa newForm = new dopinfa(this);
        //    newForm.Show();
        //}
        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            comboBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            comboBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox7.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            textBox8.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
        }


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
            MessageBox.Show("Запись успешно удалена!");
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
        private void button1_Click(object sender, EventArgs e)
        {
            meExit();
        }

        private void save_button_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "INSERT INTO SPISANNAYATEXNIKA (INV_NOMER, ID_NAZVANIE, ID_OTDEL_RAZM, ID_ZA_KEM_CHISL,NAIMENOVANIE,GDE_PRIOBRETENO,WHY_SPIS) VALUES ('" + textBox2.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + comboBox3.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "')";
            SqlDataAdapter SDA = new SqlDataAdapter(query, con);
            SDA.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Данные успешно добавлены!");

        }


        private void button5_Click_1(object sender, EventArgs e)
        {
            con.Open();
            String query = "SELECT  * FROM SPISANNAYATEXNIKA ";
            SqlDataAdapter SDA = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            SDA.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        //исправить
        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "UPDATE SPISANNAYATEXNIKA SET INV_NOMER = '" + textBox2.Text + "',ID_NAZVANIE='" + comboBox1.Text + "', ID_RAZDEL_IZMENENIA='" + comboBox2.Text + "',IZMENENIA='" + textBox2.Text + "'";
            SqlDataAdapter SDA = new SqlDataAdapter(query, con);
            SDA.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("   Данные успешно обновлены!");
        }


        //private void textBox1_TextChanged(object sender, EventArgs e)
        //{

        //}
        //данная функция не разрешает вводить в номере  инвентаризации число, KeyPress в свойствах текстбокса
        //https://codeby.net/blogs/kak-vvesti-v-textbox-tolko-cifry/
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
                
            {
                MessageBox.Show("   Необходимо ввести цифры!");
                e.Handled = true;
            }
           
            //{
            //    if (Char.IsDigit(e.KeyChar))
            //    {

            //    }

            //    else 
            //    {
            //        MessageBox.Show("   Необходимо ввести цифры!");
            //        e.Handled = true; 
            //    }

        }
        }
    }

