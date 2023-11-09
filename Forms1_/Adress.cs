using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Forms1_
{
    internal class Adress 
    {
        private int _id;
        private string _rua;
        private string _numero;
        private string _bairro;
        private string _cidade;
        private string _estado;
        private string _telefone;

        public Adress()
        {
        }

        public Adress(int id, string rua, string numero, string bairro, string cidade, string estado, string telefone)
        {
            Id = id;
            Rua = rua;
            Numero = numero;          
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Telefone = telefone;
                


        }
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }

        public string Rua 
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("campo email esta vazio");
                _rua = value;

            }

            get { return _rua; }
        }
        public string Numero
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("campo email esta vazio");
                _numero = value;

            }

            get { return _numero; }
        }
        public string Bairro 
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("campo email esta vazio");
                _bairro = value;

            }

            get { return _bairro; }
        } 
        public string Cidade
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("campo email esta vazio");
                _cidade = value;

            }

            get { return _cidade; }
        }
        
        public string Estado
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("campo email esta vazio");
                _estado = value;

            }

            get { return _estado; }
        }
        public string Telefone
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("campo email esta vazio");
                _telefone = value;

            }

            get { return _telefone; }
        }
    }
}
