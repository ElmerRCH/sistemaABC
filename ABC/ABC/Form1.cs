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
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
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
                }
                else
                {
                        conexion.Close();
                        MessageBox.Show("no Existe este producto");
                        textBox2.Enabled = true;
                        modelo.Enabled = true;
                        marca.Enabled = true;
                        numericUpDown1.Enabled = true;
                        numericUpDown2.Enabled = true;
                        numdep.Enabled = true;
                        numcla.Enabled = true;
                        numfam.Enabled = true;
                        button6.Enabled = true;
                        textBox1.Enabled = false;
                    //========================================================
                       


                }

            }
            catch (Exception c)
            {
                MessageBox.Show(c.Message + c.StackTrace);
                
            }
        }
        

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("solo puedes escribir letras");
                e.Handled = true;
                
                return;
            }
            //if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255)){
            //  MessageBox.Show("solo puedes escribir letras");
            //e.Handled = true;
           //return;
            //}
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("solo puedes escribir numeros");
                e.Handled = true;
                return;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("solo puedes escribir numeros");
                e.Handled = true;
                return;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("solo puedes escribir letras");
                e.Handled = true;

                return;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("solo puedes escribir letras");
                e.Handled = true;

                return;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("solo puedes escribir letras");
                e.Handled = true;

                return;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form camb = new cambio();
            camb.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            try
            {      
                if (numericUpDown2.Value < numericUpDown1.Value)
                {
                    string fa = null;
                    string fd = null;
                    // int id = Convert.ToInt32(comboBox1.SelectedIndex);
                    //int id1 = Convert.ToInt32(clasecombo.SelectedIndex);
                    //int id2 = Convert.ToInt32(familicombo.SelectedIndex);
                    

                    fa = DateTime.Now.ToString("yyyy-MM-dd");
                    fd = "1900-01-01";
                    
                    
                    
                    MySqlConnection conexion = Conexion.ConnectionDB();
                    conexion.Open();
                    MySqlCommand command = new MySqlCommand();
                    command.Connection = conexion;
                    //command.CommandText = ($"ver_por_sku('{textBox1.Text}');");
                    command.CommandText = ($"Alta_producto('{textBox1.Text}','{textBox2.Text}','{marca.Text}','{modelo.Text}','{numdep.Value}','{numcla.Value}','{numfam.Value}','{numericUpDown1.Value}','{numericUpDown2.Value}','{fa}','{fd}','0');");
                    //command.CommandText = ($"Alta_producto('dadwd','fef','fef','lg','1','2','1','5','5','2022-11-17','1900-01-01','0');");
                    MySqlDataReader cur = command.ExecuteReader();
                    MessageBox.Show("registro creado");
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
                    MessageBox.Show("la cantidad no debe ser mayor al stock");
                }
            }
            catch (Exception c)
            {
                MessageBox.Show("Departamentos no asociados");
                MessageBox.Show(c.Message + c.StackTrace);

            }

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form baja = new baja();
            baja.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form consul = new consulta();
            consul.Show();
            this.Hide();
        }

        private void familicombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void clasecombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void numcla_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
