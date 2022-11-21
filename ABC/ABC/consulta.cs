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
    public partial class consulta : Form
    {
        public consulta()
        {
            InitializeComponent();
        }

        private void consulta_Load(object sender, EventArgs e)
        {

        }

        private void btnsku_Click(object sender, EventArgs e)
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
                }
                else
                {
                   
                    MessageBox.Show("no Existe este producto");
                  
                }

            }
            catch (Exception v)
            {
                MessageBox.Show(v.Message + v.StackTrace);

            }
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
            Form consul = new cambio();
            consul.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MySqlConnection conexion = Conexion.ConnectionDB();
            try
            {
                conexion.Open();
                MySqlCommand tab = new MySqlCommand();
                tab.Connection = conexion;
                tab.CommandText = ("SELECT id,nom_departamento FROM departamentos");


                MySqlDataAdapter adap = new MySqlDataAdapter();
                adap.SelectCommand = tab;
                DataTable table = new DataTable();
                adap.Fill(table);
                dataGridView1.DataSource = table;
                conexion.Close();
            }
            catch (Exception h)
            {

                MessageBox.Show(h.Message + h.StackTrace);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MySqlConnection conexion = Conexion.ConnectionDB();
            try
            {
                conexion.Open();
                MySqlCommand tab = new MySqlCommand();
                tab.Connection = conexion;
                tab.CommandText = ("SELECT id,nom_clase FROM clase");


                MySqlDataAdapter adap = new MySqlDataAdapter();
                adap.SelectCommand = tab;
                DataTable table = new DataTable();
                adap.Fill(table);
                dataGridView1.DataSource = table;
                conexion.Close();
            }
            catch (Exception h)
            {

                MessageBox.Show(h.Message + h.StackTrace);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MySqlConnection conexion = Conexion.ConnectionDB();
            try
            {
                conexion.Open();
                MySqlCommand tab = new MySqlCommand();
                tab.Connection = conexion;
                tab.CommandText = ("SELECT id,nom_familia FROM familia");


                MySqlDataAdapter adap = new MySqlDataAdapter();
                adap.SelectCommand = tab;
                DataTable table = new DataTable();
                adap.Fill(table);
                dataGridView1.DataSource = table;
                conexion.Close();
            }
            catch (Exception h)
            {

                MessageBox.Show(h.Message + h.StackTrace);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MySqlConnection conexion = Conexion.ConnectionDB();
            try
            {
                conexion.Open();
                MySqlCommand tab = new MySqlCommand();
                tab.Connection = conexion;
                tab.CommandText = ("vertodo();");


                MySqlDataAdapter adap = new MySqlDataAdapter();
                adap.SelectCommand = tab;
                DataTable table = new DataTable();
                adap.Fill(table);
                dataGridView1.DataSource = table;
                conexion.Close();
            }
            catch (Exception h)
            {

                MessageBox.Show(h.Message + h.StackTrace);
            }
        }
    }
}
