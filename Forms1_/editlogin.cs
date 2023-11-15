using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Forms1_
{
    public partial class editlogin : Form
    {
        private int Id;
        public editlogin()
        {
            InitializeComponent();
            UpdateListView();
        }
        private void UpdateListView()
        {
            listView1.Items.Clear();


            UserDAO userDAO = new UserDAO();
            List<User> users = userDAO.SelectUser();
            
            try
            {
                foreach (User user in users)
                {
                    ListViewItem lv = new ListViewItem(user.Id.ToString());

                    lv.SubItems.Add(user.Cpf);
                    lv.SubItems.Add(user.Senha);
                    lv.SubItems.Add(user.Nome);
                    lv.SubItems.Add(user.Email);


                    listView1.Items.Add(lv);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }


        }
        private void button2_Click(object sender, EventArgs e)
        {

            User user = new User(Id,email.Text, cpf.Text, nome.Text );
            UserDAO nomeDoObj = new UserDAO();
            nomeDoObj.UpdateUser(user);
            email.Clear();
            
            nome.Clear();
            cpf.Clear();

            UpdateListView();
            MessageBox.Show("Atualizado com sucesso",
           "AVISO",
           MessageBoxButtons.OK,
           MessageBoxIcon.Information);
           UpdateListView();

        }

      

        private void Form4_Load(object sender, EventArgs e)
        {
            UpdateListView();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            UserDAO nomeDoObj = new UserDAO();
            nomeDoObj.DeleteUser(Id);
            email.Clear();
            
            cpf.Clear();
            nome.Clear();

           
            MessageBox.Show("Excluido com sucesso",
           "AVISO",
           MessageBoxButtons.OK,
           MessageBoxIcon.Information);
            UpdateListView();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            int index;

            index = listView1.FocusedItem.Index;
            Id = int.Parse(listView1.Items[index].SubItems[0].Text);
            nome.Text = listView1.Items[index].SubItems[1].Text;
            email.Text = listView1.Items[index].SubItems[2].Text;
            cpf.Text = listView1.Items[index].SubItems[3].Text;
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void senha_TextChanged(object sender, EventArgs e)
        {

        }

        private void nome_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void email_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
