using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forms1_
{
    internal class User
    {
        private string _id;
        private string _email;
        private string _senha;

        public User(string email, string senha, string id)
        {
            Email = email;
            Senha = senha;
            Id = id;
        }

        public string Email
        {
            set { Email = value; }
            get { return _email; }
        }

        public string Senha
        {
            set { Senha = value; }
            get { return _senha; }
        }
        public string Id
        {
            set { _id = value; }
            get { return _id; }
        }
    }
}
