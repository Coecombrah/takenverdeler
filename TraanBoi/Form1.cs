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
using System.Data.Sql;
using System.Data.SqlTypes;
using System.Data.Common;
using MySql.Data.MySqlClient;

namespace TraanBoi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            MySql.Data.MySqlClient.MySqlConnection connection;
            string server = "127.0.0.1";
            string database = "db_voorkeuren";
            string uid = "root";
            string password = "usbw";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";


            connection = new MySqlConnection(connectionString);
        }

        private void btn_rooster_Click(object sender, EventArgs e)
        {
            rooster rooster = new rooster();
            rooster.Show();
        }

        private void btn_opslaan_Click(object sender, EventArgs e)
        {


            string a = dd_voorkeur1.Text;
            string b = dd_voorkeur2.Text;
            string c = dd_voorkeur3.Text;
            string d = dd_voorkeur4.Text;
            string f = dd_voorkeur5.Text;

            string naam = tb_naam.Text;

            if (string.IsNullOrWhiteSpace(dd_voorkeur1.Text) || string.IsNullOrWhiteSpace(dd_voorkeur2.Text) || string.IsNullOrWhiteSpace(dd_voorkeur3.Text) || 
                string.IsNullOrWhiteSpace(dd_voorkeur4.Text) || string.IsNullOrWhiteSpace(dd_voorkeur5.Text) || string.IsNullOrWhiteSpace(tb_naam.Text) || string.IsNullOrWhiteSpace(dd_geslacht.Text))
            {
                MessageBox.Show("Je moet natuurlijk wel alles invullen.");
            } else if ((a.Equals(b) || a.Equals(c) || a.Equals(d) || a.Equals(f) ||
                    b.Equals(c) || b.Equals(d) || b.Equals(f) ||
                    c.Equals(d) || c.Equals(f) ||
                    d.Equals(f)))  {
                MessageBox.Show("Je mag helaas niet 2 keer dezelfde activiteit kiezen.");
            } else {
                using (SqlConnection connection = new SqlConnection(""))
                {
                    connection.Open();

                    string query = "INSERT INTO naam_voorkeur(Naam, Voorkeur 1, Voorkeur 2, Voorkeur 3, Voorkeur 4, Voorkeur 5) " +
                    "Values('" + naam + "', '" + a + "', '" + b + "', '" + c + "', '" + d + "', '" + f + "')";

                    using (SqlConnection connection = new SqlConnection("Data Source=PCM13812;Initial Catalog=Kronhjorten;Integrated Security=True"))
                    {
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                        }
                    }


                    MessageBox.Show("Je informatie is opgezonden!");
                    dd_voorkeur1.Text = null;
                    dd_voorkeur2.Text = null;
                    dd_voorkeur3.Text = null;
                    dd_voorkeur4.Text = null;
                    dd_voorkeur5.Text = null;
                    tb_naam.Text = null;
                    dd_geslacht.Text = null;
                }

            }
        }
    }
}
