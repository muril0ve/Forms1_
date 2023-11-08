using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forms1_
{
    internal class User
    {
        private int _id;
        private string _email;
        private string _senha;
        private string _cpf;
        private string _nome;
        private string text1;
        private string text2;
        private string text3;
        private string text4;

        public User(string text1, string text2, string text3, string text4)
        {
            this.text1 = text1;
            this.text2 = text2;
            this.text3 = text3;
            this.text4 = text4;
        }
        public User()
        {

        }

        public User(int id, string email, string senha, string cpf, string nome)
        {
            Id = id;
            Email = email;
            Senha = senha;
            Cpf = cpf;
            Nome = nome;
        }

        public string Email
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("campo email esta vazio");
                _email = value;
               
            }
            
            get { return _email; }
        }

        public string Senha
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("campo senha esta vazio");
                _senha = value;

            }
            get { return _senha; }
        }
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        public string Cpf
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("campo senha esta vazio");
                _cpf = value;

            }
            get { return _cpf; }

        } 
        public string Nome
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("campo senha esta vazio");
                _nome = value;

            }
            get { return _nome; }

        }

        
    }
}
