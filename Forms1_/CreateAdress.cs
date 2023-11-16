using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
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
            Adress adress = new Adress(Id, rua.Text, numero.Text, bairro.Text, cidade.Text, estado.Text, telefone.Text);
            string numeroTelefone = adress.Telefone.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
            bool valido = ValidarNumeroTelefone(numeroTelefone);
            if (valido)
            {

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
                numero.Clear();

            }
            else
            {
                MessageBox.Show(
                "O número de telefone é inválido!",
                "ATENÇÃO",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information) ;
            }



        }
        static bool ValidarNumeroTelefone(string numero)
        {
            string padrao = @"^([1-9]{2}|[1-9]{2})9\d{8}$";

            return Regex.IsMatch(numero, padrao);
        }




        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            EditAdress form = new EditAdress();
            form.ShowDialog();
        }

        private void rua_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void telefone_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
