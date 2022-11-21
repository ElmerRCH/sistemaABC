using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace ABC
{
    class Conexion
    {
        public static MySqlConnection ConnectionDB()
        {
            string STRconnection = "server=localhost;Database=abcc;uid=root;Pwd=rootroot;";
            MySqlConnection DBConetion = new MySqlConnection(STRconnection);
            try
            {
                return DBConetion;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message + e.StackTrace);
                return null;
            }

        }
       
    }
}
