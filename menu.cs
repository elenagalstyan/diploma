using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElenaGalstyan
{
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            reestr newForm = new reestr(this);
            newForm.Show();
        }
           

        private void button2_Click(object sender, EventArgs e)
        {
            spisannayatexnika newForm = new spisannayatexnika(this);
            newForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            izmenenia newForm = new izmenenia(this);
            newForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dopinfa newForm = new dopinfa(this);
            newForm.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

     
    }
}
