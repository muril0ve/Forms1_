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

            // Obter a string da TextBox
            string input = telefone.Text;

            // Remover caracteres não numéricos
            string numerosApenas = RemoverNaoNumericos(input);

            // Inserir no banco de dados
            InserirNoBancoDeDados(numerosApenas);
        }
        private string RemoverNaoNumericos(string input)
        {
            // Utilizar expressão regular para manter apenas os dígitos
            return Regex.Replace(input, @"[^\d]", "");
        }

        private void InserirNoBancoDeDados(string numerosApenas)
        {
            try
            {
                string servidor = "DESKTOP-MBDNUGB\\SQLEXPRESS"; // substitua pelo endereço do seu servidor de banco de dados
                string bancoDeDados = "PR2";
               

                string connectionString = $"Data Source={servidor};Initial Catalog={bancoDeDados}";

                

                using (SqlConnection conexao = new SqlConnection(connectionString))
                {
                    conexao.Open();

                    // Substitua "NomeDaTabela" pelo nome real da tabela no seu banco de dados
                    string query = $"INSERT INTO adress (@telefone) VALUES ('{numerosApenas}')";

                    using (SqlCommand comando = new SqlCommand(query, conexao))
                    {
                        comando.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Dados inseridos no banco de dados com sucesso!");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao inserir no banco de dados: {ex.Message}");
            }
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
