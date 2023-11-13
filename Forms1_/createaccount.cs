using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Forms1_
{

    public partial class createaccount : Form
    {
        private readonly string DataBase = "PR2";
        // private const string connectionString = "Data Source=" + Environment.MachineName + "@SQLEXPRESS;Initial Catalog=" + DataBase + ";Integrated Security=true";
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


            //// Obtém a senha da TextBox
            //string senhaOriginal = senha.Text;

            //// Criptografa a senha usando SHA-256
            //string senhaCriptografada = CalcularSHA256(senhaOriginal);

            //// Insere a senha criptografada no banco de dados
            //InserirSenhaNoBanco(senhaCriptografada);

            //// Exibe uma mensagem indicando que a senha foi inserida no banco de dados (opcional)
            //MessageBox.Show("Senha criptografada inserida no banco de dados com sucesso.");

            //// Limpa a TextBox após a operação (opcional)
            //senha.Text = "";
        }

        private string CalcularSHA256(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Converte a string de entrada em bytes
                byte[] bytes = Encoding.UTF8.GetBytes(input);

                // Calcula o hash SHA-256
                byte[] hashBytes = sha256.ComputeHash(bytes);

                // Converte o resultado do hash em uma string hexadecimal
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    builder.Append(hashBytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }

        //private void InserirSenhaNoBanco(string senhaCriptografada)
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        try
        //        {
        //            connection.Open();

        //            // Substitua "NomeDaTabela" pelo nome real da tabela onde você deseja armazenar as senhas
        //            string query = "INSERT INTO login (senha) VALUES (@senha)";

        //            using (SqlCommand command = new SqlCommand(query, connection))
        //            {
        //                // Adiciona o parâmetro para a senha criptografada
        //                command.Parameters.AddWithValue("@Senha", senhaCriptografada);

        //                // Executa o comando SQL
        //                command.ExecuteNonQuery();
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show($"Erro ao inserir a senha no banco de dados: {ex.Message}");
        //        }
        //    }

        //}

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void senha_TextChanged(object sender, EventArgs e)
        {

        }
    }
}


