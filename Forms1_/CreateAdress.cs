using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Forms1_
{
    
    public partial class CreateAdress : Form
    {
        private int Id;
        public CreateAdress()
        {
            InitializeComponent();
        }

        private void CreateAdress_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Adress adress = new Adress(Id, rua.Text, numero.Text, bairro.Text, cidade.Text, estado.Text, telefone.Text);
            AdressDAO nomeDoObj = new AdressDAO();
            nomeDoObj.InsertAdress(adress);

            string arua = rua.Text;
            string anumero = numero.Text;
            string abairro = bairro.Text;
            string acidade = cidade.Text;
            string aestado = estado.Text;
            string atelefone = telefone.Text;

            string message = "Rua: " + arua +
                         "\nNumero: " + anumero +
                         "\nBairro: " + abairro +
                         "\nCidade: " + acidade +
                         "\nEstado: " + aestado +
                         "\nTelefone: " + atelefone;
                         

            MessageBox.Show(
                "Conta criada com sucesso!!",
                "ATENÇÃO",
            MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            rua.Clear();
            bairro.Clear();
            cidade.Clear();
            estado.Clear();
            telefone.Clear();
            numero.Clear();
            string numeroTelefone = telefone.Text;

            if (ValidarTelefone(numeroTelefone))
            {
                MessageBox.Show("Número de telefone válido!");
            }
            else
            {
                MessageBox.Show("Número de telefone inválido. Por favor, insira um número válido.");
            }
        }

        private bool ValidarTelefone(string numeroTelefone)
        {
            // Utilizando uma expressão regular que aceita diversos formatos comuns de números de telefone.
            // Adaptar conforme necessário para atender aos requisitos específicos.
            string pattern = @"^(\+\d{1,2}\s?)?[0-10\-\.]+\d$";

            Regex regex = new Regex(pattern);

            return regex.IsMatch(numeroTelefone);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();    
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            EditAdress form = new EditAdress();
            form.ShowDialog();
        }

        private void rua_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
