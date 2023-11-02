using InvestimentosMais;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Forms1_
{
    public partial class Form1 : Form
    {
        private int id;
        public Form1()
        {
            InitializeComponent();
        }
        private void UpdateListView()
        {
           listView1.Items.Clear(); 
            

            UserDAO userDAO = new UserDAO();
            List<User> users = userDAO.SelectUser();
            if (users.Count == 0)
                MessageBox.Show("");
            try
            {
                foreach (User user in users)
                {
                    ListViewItem lv = new ListViewItem(user.Id.ToString());
                    lv.SubItems.Add(user.Email);
                    lv.SubItems.Add(user.Senha);
                    listView1.Items.Add(lv);
                }
                

                
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            User user = new User(textBox1.Text, textBox2.Text);
            UserDAO nomeDoObj = new UserDAO();
            nomeDoObj.InsertUser(user);

            textBox1.Clear();
            textBox2.Clear();

            UpdateListView();   

        }

        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index;

            index = listView1.FocusedItem.Index;
            id = int.Parse(listView1.Items[index].SubItems[0].Text);
            textBox1.Text = listView1.Items[index].SubItems[1].Text;
            textBox2.Text = listView1.Items[index].SubItems[2].Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                User user = new User(textBox1.Text, textBox2.Text);

                UserDAO nomeDoObj = new UserDAO();
                nomeDoObj.UpdateUser(user, id);
                textBox1.Clear();
                textBox2.Clear();

               UpdateListView();
               MessageBox.Show("Atualizado com sucesso",
               "AVISO",
               MessageBoxButtons.OK,
               MessageBoxIcon.Information);
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
           UserDAO nomeDoObj = new UserDAO();
            nomeDoObj.DeleteUser(id);
            textBox1.Clear();
            textBox2.Clear();

            UpdateListView();
            MessageBox.Show("Excluido com sucesso",
           "AVISO",
           MessageBoxButtons.OK,
           MessageBoxIcon.Information);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateListView();
        }
    }
}


