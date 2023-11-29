using System;
using System.Collections.Generic;

using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using InvestimentosMais;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;



namespace Forms1_
{
    public partial class editlogin : Form
    {

        private int Id;



        public editlogin()
        {
            InitializeComponent();
            UpdateListView();
        }
        private void UpdateListView()
        {
            listView1.Items.Clear();


            UserDAO userDAO = new UserDAO();
            List<User> users = userDAO.SelectUser();

            try
            {
                foreach (User user in users)
                {
                    ListViewItem lv = new ListViewItem(user.Id.ToString());

                    lv.SubItems.Add(user.Nome);
                    lv.SubItems.Add(user.Email);
                    lv.SubItems.Add(user.Cpf);

                    listView1.Items.Add(lv);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }


        }
        private void button2_Click(object sender, EventArgs e)
        {

            User user = new User(Id, email.Text, cpf.Text, Nome.Text);
            UserDAO nomeDoObj = new UserDAO();
            nomeDoObj.UpdateUser(user);
            email.Clear();

            Nome.Clear();
            cpf.Clear();

            UpdateListView();
            MessageBox.Show("Atualizado com sucesso",
           "AVISO",
           MessageBoxButtons.OK,
           MessageBoxIcon.Information);
            UpdateListView();

        }



        private void Form4_Load(object sender, EventArgs e)
        {
            UpdateListView();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            UserDAO nomeDoObj = new UserDAO();
            nomeDoObj.DeleteUser(Id);
            email.Clear();

            cpf.Clear();
            Nome.Clear();


            MessageBox.Show("Excluido com sucesso",
           "AVISO",
           MessageBoxButtons.OK,
           MessageBoxIcon.Information);
            UpdateListView();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            int index;

            index = listView1.FocusedItem.Index;
            Id = int.Parse(listView1.Items[index].SubItems[0].Text);
            Nome.Text = listView1.Items[index].SubItems[1].Text;
            email.Text = listView1.Items[index].SubItems[2].Text;
            cpf.Text = listView1.Items[index].SubItems[3].Text;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }



        private void nome_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }


        private void email_TextChanged(object sender, EventArgs e)
        {

        }

        private void imprimir_Click(object sender, EventArgs e)
        {
            // Configurações de conexão com o banco de dados
            string connectionString = @"Data Source=DESKTOP-MBDNUGB\SQLEXPRESS;Initial Catalog=PR2;Integrated Security=True";
            string query = "SELECT * FROM login";

            // Configurações do servidor SMTP para envio de e-mail
            string smtpServer = "smtp.gmail.com";
            int smtpPort = 587;
            string smtpUsername = "muriloemateuscoutinho@gmail.com";
            string smtpPassword = "Murilo2024@";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Configuração do cliente SMTP
                            using (SmtpClient smtpClient = new SmtpClient(smtpServer))
                            {
                                smtpClient.Port = smtpPort;
                                smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
                                smtpClient.EnableSsl = true;

                                // Configuração do e-mail
                                using (MailMessage mailMessage = new MailMessage())
                                {
                                    mailMessage.From = new MailAddress(smtpUsername);
                                    mailMessage.Subject = "Dados da Tabela";
                                    mailMessage.Body = "Aqui estão os dados da tabela:\n\n";

                                    while (reader.Read())
                                    {
                                        // Adicione os dados da tabela ao corpo do e-mail
                                        string email = reader["email"].ToString();
                                        string senha = "***"; // Substitua pelo valor que você deseja exibir para senha
                                        string nome = reader["nome"].ToString();
                                        string cpf = reader["cpf"].ToString();

                                        mailMessage.Body += $"Email: {email}\nSenha: {senha}\nNome: {nome}\nCPF: {cpf}\n\n";
                                    }

                                    // Adicione o destinatário
                                    mailMessage.To.Add("xxxsouzax@gmail.com");

                                    // Envie o e-mail
                                    smtpClient.Send(mailMessage);

                                    Console.WriteLine("E-mail enviado com sucesso.");
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }
    }
}





