using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms1_
{
    public partial class createaccount : Form
    {
        private int Id;
        public createaccount()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            User user = new User(Id, email.Text, senha.Text, cpf.Text, nome.Text);
            UserDAO nomeDoObj = new UserDAO();
            nomeDoObj.InsertUser(user);

            string aemail = email.Text;
            string asenha = senha.Text;
            string acpf = cpf.Text;
            string anome = nome.Text;

            string message = "Email: " + aemail +
                         "\nSenha: " + asenha +
                         "\nCPF: " + acpf +
                         "\nNome: " + anome;

            MessageBox.Show(
                "Conta criada com sucesso!!",
                "ATENÇÃO",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            email.Clear();
            cpf.Clear();
            senha.Clear();
            nome.Clear();
            confsenha.Clear();


        }

            private void pictureBox1_Click(object sender, EventArgs e)
            {

            }

            private void button2_Click(object sender, EventArgs e)
            {
                Close();
            }
        }
    }


