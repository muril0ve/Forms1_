using InvestimentosMais;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms1_
{
    internal class UserDAO
    {
        public void DeleteUser(int id)
        {
            connection conexao1 = new connection();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = conexao1.ReturnConnection();
            sqlCommand.CommandText = @"DELETE FROM login WHERE id = @id";
            sqlCommand.Parameters.AddWithValue("@id", id);
            try
            {
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                throw new Exception("Erro: Problemas ao excluir usuário no banco.\n" + err.Message);
            }
            finally
            {
                conexao1.CloseConnection();
            }
            
        }
        public void UpdateUser(int id, string textBox1,string textBox2)
        {
            connection conexao1 = new connection();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = conexao1.ReturnConnection();
            sqlCommand.CommandText = @"UPDATE login SET
            email = @email,
            senha = @senha
            WHERE id = @id";
            sqlCommand.Parameters.AddWithValue("@id", id);
            sqlCommand.Parameters.AddWithValue("@email", textBox1.Text);
            sqlCommand.Parameters.AddWithValue("@senha", textBox2.Text);

            sqlCommand.ExecuteNonQuery();

            MessageBox.Show("Cadastrado com sucesso",
            "AVISO",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
        }
    }
}
