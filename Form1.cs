using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace Atelier__Lobjet_DataReader_
{
    public partial class Form1 : Form
    {
        static string conn_string = ConfigurationManager.ConnectionStrings["mon_db"].ConnectionString;
        SqlConnection connection;
        SqlCommand command ;
        SqlDataReader reader;
        public Form1()
        {
            InitializeComponent();
           
              
        }

        private void Afficher_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            try
            {
                connection = new SqlConnection(conn_string);
                command = new SqlCommand("select * from avion;", connection);
                connection.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader.GetInt16(0).ToString(), reader.GetString(1), reader.GetString(2));
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("erreur : " + ex.Message);
            }
            reader.Close();
            connection.Close();
        }
    }
}
