﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestimentosMais

{
    internal class connection
    {
        //Propriedades ou atributos
        private readonly SqlConnection con;
        private readonly string DataBase = "PR2";

        //Construtor
        public connection()                            //LAPTOP-9TN8R1CF\SQLEXPRESS
        {
            //Data Source=LAPTOP-9TN8R1CF\SQLEXPRESS;Initial Catalog=InvestimentosMais;Integrated Security=True
            string stringConnection = @"Data Source="
                    + Environment.MachineName +
                    @"\SQLEXPRESS;Initial Catalog=" +
                    DataBase + ";Integrated Security=true";

            con = new SqlConnection(stringConnection);
            con.Open();   //Abrir a conexão com o banco de dados
        }
        //Tenta fechar a conexão com o banco
        public void CloseConnection()
        {
            if (con.State == ConnectionState.Open)
                con.Close();
        }
        //Retorna a conexão que foi aberta
        public SqlConnection ReturnConnection()
        {
            return con;
        }

    }

}
