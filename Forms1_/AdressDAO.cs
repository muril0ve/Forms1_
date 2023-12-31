﻿using InvestimentosMais;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms1_
{
    internal class AdressDAO
    {
       
        public void InsertAdress(Adress adress)
        {
            connection conexao1 = new connection();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = conexao1.ReturnConnection();
            sqlCommand.CommandText = @"INSERT INTO adress VALUES
            (@rua, @numero, @bairro, @cidade, @estado, @telefone)";
            

            sqlCommand.Parameters.AddWithValue("@rua", adress.Rua);
            sqlCommand.Parameters.AddWithValue("@numero", adress.Numero);
            sqlCommand.Parameters.AddWithValue("@bairro", adress.Bairro);
            sqlCommand.Parameters.AddWithValue("@cidade", adress.Cidade);
            sqlCommand.Parameters.AddWithValue("@estado", adress.Estado);
            sqlCommand.Parameters.AddWithValue("@telefone", adress.Telefone);

            sqlCommand.ExecuteNonQuery();
        }

        public void DeleteAdress(int Id)
        {
            connection conexao1 = new connection();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = conexao1.ReturnConnection();
            sqlCommand.CommandText = @"DELETE FROM adress WHERE Id = @id";
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
        public void UpdateAdress(Adress adress)
        {

            connection conexao1 = new connection();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = conexao1.ReturnConnection();
            sqlCommand.CommandText = @"UPDATE adress SET
            rua = @rua, 
            numero = @numero,  
            bairro = @bairro,
            cidade = @cidade, 
            estado = @estado,
            telefone = @telefone 
            WHERE Id = @id";

            sqlCommand.Parameters.AddWithValue("@Id", adress.Id);
            sqlCommand.Parameters.AddWithValue("@rua", adress.Rua);
            sqlCommand.Parameters.AddWithValue("@numero", adress.Numero);
            sqlCommand.Parameters.AddWithValue("@bairro", adress.Bairro);
            sqlCommand.Parameters.AddWithValue("@cidade", adress.Cidade);
            sqlCommand.Parameters.AddWithValue("@estado", adress.Estado);
            sqlCommand.Parameters.AddWithValue("@telefone", adress.Telefone);


            sqlCommand.ExecuteNonQuery();

            MessageBox.Show("Cadastrado com sucesso",
            "AVISO",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
        }
        public List<Adress> SelectAdress()
        {
            connection conexao1 = new connection();
            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Connection = conexao1.ReturnConnection();
            sqlCommand.CommandText = "SELECT * FROM adress";


            List<Adress> users = new List<Adress>();
            try
            {
                SqlDataReader dr = sqlCommand.ExecuteReader();
                while (dr.Read())
                {
                    Adress objeto = new Adress(
                    (int)dr["Id"],
                    (string)dr["rua"],
                    (string)dr["numero"],
                    (string)dr["bairro"],
                    (string)dr["cidade"],
                    (string)dr["estado"],
                    (string)dr["telefone"]
                       ) ;
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
