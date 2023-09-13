using InvestimentosMais;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms1_
{
    public partial class Form1 : Form
    {
        public Form1()
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

            string name = textBox1.Text;
            string enrollment = textBox2.Text;

            string message = "Login: " + name +
                             "\nSenha: " + enrollment;
            MessageBox.Show(
                message,
                "Atenção",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            textBox1.Clear();
            textBox2.Clear();





            connection conexao1 = new connection();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = conexao1.ReturnConnection();
            sqlCommand.CommandText = @"INSERT INTO login VALUES
            (@email, @senha)";
            sqlCommand.Parameters.AddWithValue("@email", textBox1.Text);
            sqlCommand.Parameters.AddWithValue("@senha", textBox2.Text);
            sqlCommand.ExecuteNonQuery();

            MessageBox.Show(
                "Login realizado com sucesso !",
                "AVISO",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
                );

            textBox1.Clear();
            textBox2.Clear();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

    
}
