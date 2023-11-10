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
    public partial class EditAdress : Form

    {
        private int Id;
        public EditAdress()
        {
            InitializeComponent();
            UpdateListView();
        }
        private void UpdateListView()
        {
            LV.Items.Clear();


            AdressDAO adressDAO = new AdressDAO();
            List<Adress> adresses = adressDAO.SelectAdress();

            try
            {
                foreach (Adress adress in adresses)
                {
                    ListViewItem lv = new ListViewItem(adress.Id.ToString());

                    lv.SubItems.Add(adress.Rua);
                    lv.SubItems.Add(adress.Numero);
                    lv.SubItems.Add(adress.Bairro);
                    lv.SubItems.Add(adress.Cidade);
                    lv.SubItems.Add(adress.Estado);
                    lv.SubItems.Add(adress.Telefone);


                    LV.Items.Add(lv);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void EditAdress_Load(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Adress adress = new Adress(Id, rua.Text, numero.Text, bairro.Text, cidade.Text, estado.Text, telefone.Text);
            AdressDAO nomeDoObj = new AdressDAO();
            nomeDoObj.UpdateAdress(adress);
            rua.Clear();
            bairro.Clear();
            cidade.Clear();
            estado.Clear();
            telefone.Clear();
            numero.Clear();


            MessageBox.Show("Atualizado com sucesso",
           "AVISO",
           MessageBoxButtons.OK,
           MessageBoxIcon.Information);
            UpdateListView();
        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
       

        private void LV_MouseDoubleClick(object sender, EventArgs e)
        {
            int index;

            index = LV.FocusedItem.Index;
            Id = int.Parse(LV.Items[index].SubItems[0].Text);
            rua.Text = LV.Items[index].SubItems[1].Text;
            numero.Text = LV.Items[index].SubItems[2].Text;
            bairro.Text = LV.Items[index].SubItems[3].Text;
            cidade.Text = LV.Items[index].SubItems[4].Text;
            estado.Text = LV.Items[index].SubItems[5].Text;
            telefone.Text = LV.Items[index].SubItems[6].Text;
        }
    }
}
