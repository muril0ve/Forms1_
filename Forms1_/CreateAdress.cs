using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
            string aTelefone = telefone.Text;

            // Remover caracteres especiais
            string numeroSemCaracteres = RemoverCaracteresEspeciais(numeroTelefone);

            // Inserir no banco de dados
            InserirNoBancoDeDados(numeroSemCaracteres);

        }
        private string RemoverCaracteresEspeciais(string input)
        {
            // Substituir todos os caracteres que não são letras ou números por uma string vazia
            return Regex.Replace(input, "[^a-zA-Z0-9]", "");
        }

        private void InserirNoBancoDeDados(string numeroSemCaracteres)
        {
            try
            {
                // Substitua "sua_string_de_conexao" pela string de conexão real do seu banco de dados
                string connectionString = "";

                using (SqlConnection conexao = new SqlConnection(connectionString))
                {
                    conexao.Open();

                    // Substitua "NomeDaTabela" pelo nome real da tabela no seu banco de dados
                    string query = $"INSERT INTO adress (numeroTelefone) VALUES ('{numeroSemCaracteres}')";

                    using (SqlCommand comando = new SqlCommand(query, conexao))
                    {
                        comando.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Dados inseridos no banco de dados com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao inserir no banco de dados: {ex.Message}");
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

        private void telefone_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
