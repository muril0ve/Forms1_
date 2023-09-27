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

namespace Forms1_
{
    public partial class Form1 : Form
    {
        private int id;
        public Form1()
        {
            InitializeComponent();
        }
        private void UpdateListView()
        {
           listView1.Items.Clear(); 
            connection conn = new connection();
            SqlCommand sqlCom = new SqlCommand();

            sqlCom.Connection = conn.ReturnConnection();
            sqlCom.CommandText = "SELECT * FROM login";

            try
            {
                SqlDataReader dr = sqlCom.ExecuteReader();

                //Enquanto for possível continuar a leitura das linhas que foram retornadas na consulta, execute.
                while (dr.Read())
                {
                    id = (int)dr["id"];
                    string name = (string)dr["email"];
                    string pass = (string)dr["senha"];

                    ListViewItem lv = new ListViewItem(id.ToString());

                    lv.SubItems.Add(name);
                    lv.SubItems.Add(pass);
                    listView1.Items.Add(lv);

                }
                dr.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                conn.CloseConnection();
            }
            
            
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
            

            connection conexao1 = new connection();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = conexao1.ReturnConnection();
            sqlCommand.CommandText = @"INSERT INTO login VALUES
            (@email, @senha)";

            sqlCommand.Parameters.AddWithValue("@id", id);
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

            UpdateListView();

        }

        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index;

            index = listView1.FocusedItem.Index;
            id = int.Parse(listView1.Items[index].SubItems[0].Text);
            textBox1.Text = listView1.Items[index].SubItems[1].Text;
            textBox2.Text = listView1.Items[index].SubItems[2].Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserDAO nomeDoObj = new UserDAO();
            nomeDoObj.DeleteUser(id);
            textBox1.Clear();
            textBox2.Clear();

            UpdateListView();
            MessageBox.Show("Atualizado com sucesso",
           "AVISO",
           MessageBoxButtons.OK,
           MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
           UserDAO nomeDoObj = new UserDAO();
            nomeDoObj.DeleteUser(id);
            textBox1.Clear();
            textBox2.Clear();

            UpdateListView();
            MessageBox.Show("Excluido com sucesso",
           "AVISO",
           MessageBoxButtons.OK,
           MessageBoxIcon.Information);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateListView();
        }
    }
}


