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
      

        
        public User(string email, string senha)
        {
            Email = email;
            Senha = senha;
            
        } public User(string email, string senha, int id):this(email,senha)
        {
            
            Id = id;
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
    }
}
