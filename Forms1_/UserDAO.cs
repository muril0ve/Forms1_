using InvestimentosMais;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Forms1_
{
    internal class UserDAO
    {
        public void InsertUser(int id)
        {
            


            connection conexao1 = new connection();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = conexao1.ReturnConnection();
            sqlCommand.CommandText = @"INSERT INTO login VALUES
            (@email, @senha)"
            ;

            sqlCommand.Parameters.AddWithValue("@id", id);
            sqlCommand.Parameters.AddWithValue("@email", textBox1.Text);
            sqlCommand.Parameters.AddWithValue("@senha", textBox2.Text);
            sqlCommand.ExecuteNonQuery();

           
        }
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
            sqlCommand.Parameters.AddWithValue("@email", textBox1);
            sqlCommand.Parameters.AddWithValue("@senha", textBox2);

            sqlCommand.ExecuteNonQuery();

            MessageBox.Show("Cadastrado com sucesso",
            "AVISO",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
        }
        
        public List<User> SelectUser ()
        {
            connection conexao1 = new connection();
            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Connection = conexao1.ReturnConnection();
            sqlCommand.CommandText = "SELECT * FROM usuario";

            
           List<User> users = new List<User>();
            try
            {
                SqlDataReader dr = sqlCommand.ExecuteReader();
                while (dr.Read())
                {
                    User objeto = new User(
                    (int)dr["id"],
                    (string)dr["email"],
                    (string)dr["senha"]
                       );
                    dr.Close();
                }

            }
            catch (Exception err)
            {
                throw new Exception
                    ("erro na leitura de dados .\n"+ err.Message);
                
            }
            finally
            {
                conexao1.CloseConnection();
            }
            return users;

        }
    }
}
