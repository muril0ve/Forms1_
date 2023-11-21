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
        public void InsertUser(User user)
        {
            connection conexao1 = new connection();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = conexao1.ReturnConnection();
            sqlCommand.CommandText = @"INSERT INTO login VALUES
            (@email, @senha,  @nome, @cpf)"
            ;

            sqlCommand.Parameters.AddWithValue("@email", user.Email);
            sqlCommand.Parameters.AddWithValue("@senha", user.Senha);
            sqlCommand.Parameters.AddWithValue("@nome", user.Nome);
            sqlCommand.Parameters.AddWithValue("@cpf", user.Cpf);
            
            sqlCommand.ExecuteNonQuery();
        }
        public void DeleteUser(int Id)
        {
            connection conexao1 = new connection();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = conexao1.ReturnConnection();
            sqlCommand.CommandText = @"DELETE FROM login WHERE Id = @id";
            sqlCommand.Parameters.AddWithValue("@id", Id);
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
        public void UpdateUser(User user)
        {

            connection conexao1 = new connection();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = conexao1.ReturnConnection();
            sqlCommand.CommandText = @"UPDATE login SET
            email = @email,  
            nome = @nome,
            cpf = @cpf 
            WHERE Id = @id";
            sqlCommand.Parameters.AddWithValue("@id", user.Id);
            sqlCommand.Parameters.AddWithValue("@email", user.Email); 
            sqlCommand.Parameters.AddWithValue("@nome", user.Nome);
            sqlCommand.Parameters.AddWithValue("@cpf", user.Cpf);
            

            sqlCommand.ExecuteNonQuery();

            MessageBox.Show("Cadastrado com sucesso",
            "AVISO",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
        }

        public List<User> SelectUser()
        {
            connection conexao1 = new connection();
            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Connection = conexao1.ReturnConnection();
            sqlCommand.CommandText = "SELECT * FROM login";


            List<User> users = new List<User>();
            try
            {
                SqlDataReader dr = sqlCommand.ExecuteReader();
                while (dr.Read())
                {
                    User objeto = new User(
                    (int)dr["Id"],
                    (string)dr["email"],
                    (string)dr["senha"],
                    (string)dr["cpf"],
                    (string)dr["nome"]
                    

                       );
                    users.Add(objeto);

                }
                dr.Close();
            }
            catch (Exception err)
            {
                throw new Exception
                    ("erro na leitura de dados .\n" + err.Message);

            }
            finally
            {
                conexao1.CloseConnection();
            }
            return users;

        }


    }
}
