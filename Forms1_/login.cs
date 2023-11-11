using InvestimentosMais;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Forms1_
{

    public partial class login : Form
    {

        private readonly string DataBase = "PR2";
        
        public login()
        {
            InitializeComponent();

        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }



        private void button1_Click(object sender, EventArgs e)
        {
            string email = E_mail.Text;
            string senha = S_enha.Text;

            string connectionString = @"Data Source="
                    + Environment.MachineName +
                    @"\SQLEXPRESS;Initial Catalog=" +
                    DataBase + ";Integrated Security=true"; // Substitua pela sua cadeia de conexão real.

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM login WHERE Email = @Email AND Senha = @Senha";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@senha", senha); // Lembre-se de usar criptografia adequada para senhas no ambiente de produção.

                    int count = (int)command.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Autenticação bem-sucedida. O email e a senha são válidos.");

                        afterCalendar form = new afterCalendar();
                        form.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Falha na autenticação. Email ou senha incorretos.");
                    }
                }
            }






            E_mail.Clear();
            S_enha.Clear();

        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

    
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            createaccount form = new createaccount();
            form.ShowDialog();

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            editlogin form = new editlogin();
            form.ShowDialog();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateAdress form = new CreateAdress();
            form.ShowDialog();
        }
    }
}


