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
    public partial class cambio : Form
    {
        public cambio()
        {
            InitializeComponent();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void cambio_Load(object sender, EventArgs e)
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
                    conexion.Close();

                    articulo.Enabled = true;
                    modelo.Enabled = true;
                    marca.Enabled = true;
                    stock.Enabled = true;
                    cantidad.Enabled = true;
                    numdep.Enabled = true;
                    numcla.Enabled = true;
                    numfa.Enabled = true;
                    button6.Enabled = true;
                    textBox1.Enabled = false;
                    descon.Enabled = true;
                    
                    button6.Enabled = true;
                    button6.Visible = true;

                    //========================================================
                    

                }
                else
                {
                    //conexion.Close();
                    MessageBox.Show("no Existe este producto");
                   
                }

            }
            catch (Exception c)
            {
                MessageBox.Show(c.Message + c.StackTrace);

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                string fb = null;
                fb = "1900-01-01";
                int d = 0;
                if (cantidad.Value < stock.Value)
                {
                    if (descon.Checked == true)
                    {
                        d = 1;
                        fb = DateTime.Now.ToString("yyyy-MM-dd");
                    }
                   // int id = Convert.ToInt32(departamento.SelectedIndex);
                   // int id1 = Convert.ToInt32(clase.SelectedIndex);
                   // int id2 = Convert.ToInt32(familia.SelectedIndex);

                    string fa = null;
                    fa = DateTime.Now.ToString("yyyy-MM-dd");
                    
           
                    MySqlConnection conexion = Conexion.ConnectionDB();
                    conexion.Open();
                    MySqlCommand command = new MySqlCommand();
                    command.Connection = conexion;
                    command.CommandText = ($"cambio('{textBox1.Text}','{articulo.Text}','{marca.Text}','{modelo.Text}','{numdep.Value}','{numcla.Value}','{numfa.Value}','{stock.Value}','{cantidad.Value}','{fa}','{fb}','{d}');");
                    MySqlDataReader cur = command.ExecuteReader();
                    MessageBox.Show("registro creado");
                    conexion.Close();
                }
                else
                {
                    MessageBox.Show("la cantidad no debe ser mayor al stock");
                }
            }
            catch (Exception z)
            {
                MessageBox.Show("problema con las relaciones");
                MessageBox.Show(z.Message + z.StackTrace);

            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form consul = new Form1();
            consul.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form consul = new baja();
            consul.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form consul = new consulta();
            consul.Show();
            this.Hide();
        }
    }
}
