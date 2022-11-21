using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABC
{
    public partial class Index : Form
    {
        public Index()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form cambio = new cambio();
            cambio.Show();
            this.Hide();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form consulta = new consulta();
            consulta.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form alta = new Form1();
            alta.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form baja = new baja();
            baja.Show();
            this.Hide();
        }
    }
}
