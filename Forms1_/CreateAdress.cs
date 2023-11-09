using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Forms1_
{
    
    public partial class CreateAdress : Form
    {
        private int Id;
        public CreateAdress()
        {
            InitializeComponent();
        }

        private void CreateAdress_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Adress adress = new Adress();
            AdressDAO nomeDoObj = new AdressDAO();
            nomeDoObj.InsertAdress(adress);

            string arua = rua.Text;
            string anumero = numero.Text;
            string abairro = bairro.Text;
            string acidade = cidade.Text;
            string aestado = estado.Text;
            string atelefone = telefone.Text;

            string message = "Rua: " + arua +
                         "\nNumero: " + anumero +
                         "\nBairro: " + abairro +
                         "\nCidade: " + acidade +
                         "\nEstado: " + aestado +
                         "\nTelefone: " + atelefone;
                         

            MessageBox.Show(
                "Conta criada com sucesso!!",
                "ATENÇÃO",
            MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            rua.Clear();
            bairro.Clear();
            cidade.Clear();
            estado.Clear();
            telefone.Clear();

        }
    }
}
