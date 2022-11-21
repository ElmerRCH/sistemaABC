using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ABC
{
    public partial class baja : Form
    {
        public baja()
        {
            InitializeComponent();
        }

        private void baja_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conexion = Conexion.ConnectionDB();
            try
            {

                conexion.Open();
                MySqlCommand command = new MySqlCommand();
                command.Connection = conexion;
                command.CommandText = ($"ver_por_sku('{textBox1.Text}');");
                MySqlDataReader cur = command.ExecuteReader();

                //x = Convert.ToString(adap.Fill(table));
                if (cur.Read() == true)
                {
                    conexion.Close();

                    conexion.Open();
                    MySqlCommand tab = new MySqlCommand();
                    tab.Connection = conexion;
                    tab.CommandText = ($"ver_datos_sku('{textBox1.Text}');");


                    MySqlDataAdapter adap = new MySqlDataAdapter();
                    adap.SelectCommand = tab;
                    DataTable table = new DataTable();
                    adap.Fill(table);
                    dataGridView1.DataSource = table;
                    eliminar.Enabled = true;
                    eliminar.Visible = true;
                    conexion.Close();
                }
                else
                {
                    MessageBox.Show("no Existe este producto");
                   
                }

            }
            catch (Exception c)
            {
                MessageBox.Show(c.Message + c.StackTrace);

            }
        }

        private void eliminar_Click(object sender, EventArgs e)
        {
            MySqlConnection conexion = Conexion.ConnectionDB();
            DialogResult check = MessageBox.Show("Esta seguro de eliminar", "Alerta", MessageBoxButtons.YesNo);
            if (check == DialogResult.Yes)
            {
                conexion.Open();
                MySqlCommand command = new MySqlCommand();
                command.Connection = conexion;
                command.CommandText = ($"baja('{textBox1.Text}');");
                MySqlDataReader cur = command.ExecuteReader();
                conexion.Close();
                MessageBox.Show("eliminado correctamente");
                dataGridView1.Visible = false;
                
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form consul = new consulta();
            consul.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form consul = new Form1();
            consul.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form consul = new cambio();
            consul.Show();
            this.Hide();
        }
    }
}
