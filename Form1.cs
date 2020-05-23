using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
 
using System.Drawing.Drawing2D;

namespace ElenaGalstyan
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }


       

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "user" && textBox2.Text == "1234")
            {
                menu s = new menu();
                s.Show();

                this.Hide();
            }
            else
            {
                textBox1.Text = "";
                textBox2.Text = "";

                MessageBox.Show("Неправильный логин или пароль. Введите еще раз.");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //private void pictureBox3_Click(object sender, EventArgs e)
        //{
        //    Application.Exit();
        //}

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

       

     
    }
}
    
